'use server';

import Database from 'better-sqlite3';
import { NextResponse } from 'next/server';
import { caesarCipher, caesarDecipher, getDbFilePath } from './utils';
const db = new Database(getDbFilePath()).exec(
  'CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT,login TEXT, password TEXT, name TEXT, lastname TEXT, city TEXT, postal TEXT, street TEXT, pesel TEXT)'
);
export async function signup(formData: FormData) {
  'use server';
  console.log('received');
  let login = formData.get('login')?.toString() || '';
  let password = formData.get('password')?.toString() || '';
  let name = formData.get('name')?.toString() || '';
  let lastname = formData.get('lastname')?.toString() || '';
  let city = formData.get('city')?.toString() || '';
  let postal = formData.get('postal')?.toString() || '';
  let street = formData.get('street')?.toString() || '';
  let pesel = formData.get('pesel')?.toString() || '';
  const errors = [];
  if (!login) {
    errors.push('Login jest wymagany');
  }
  if (!password) {
    errors.push('Hasło jest wymagane');
  }
  if (!name) {
    errors.push('Imie jest wymagane');
  }
  if (!lastname) {
    errors.push('Nazwisko jest wymagane');
  }
  if (!city) {
    errors.push('Miasto jest wymagane');
  }
  if (!postal) {
    errors.push('Kod pocztowy jest wymagany');
  }
  if (!street) {
    errors.push('Ulica jest wymagana');
  }
  if (!pesel) {
    errors.push('Pesel jest wymagany');
  }
  if (pesel.length !== 11) {
    errors.push('Pesel musi zawierać 11 znaków');
  }
  if (errors.length > 0) {
    return { ok: false, errors };
  }
  console.log(name, lastname, city, postal, street, pesel);

  pesel = caesarCipher(pesel, 3);
  password = caesarCipher(password, 3);
  lastname = caesarCipher(lastname, 3);
  street = caesarCipher(street, 3);

  const isTaken= await db.prepare('SELECT * FROM users WHERE login = ?').get(login);
  if(isTaken){
    return {ok: false, errors: ['Login jest zajęty']};
  }
  const insert = await db
    .prepare(
      'INSERT INTO users (login, password, name, lastname, city, postal, street, pesel) VALUES (?,?,?, ?, ?, ?, ?, ?)'
    )
    .run(login, password,name, lastname, city, postal, street, pesel);
  console.log(insert);

  const rows = await db.prepare('SELECT * FROM users').all();
  console.log(rows);

  return { ok: true };
}

export async function login(formData: FormData) {
  'use server';
  let login = formData.get('login')?.toString() || '';
  let password = formData.get('password')?.toString() || '';
  password = caesarCipher(password, 3);
  const user = await db.prepare('SELECT * FROM users WHERE login = ? AND password = ?').get(login, password) as {login: string, name: string, lastname: string, city: string, postal: string, street: string, pesel: string};
  if(user){
    return {ok: true, login: user.login, name: user.name, lastname: caesarDecipher(user.lastname,3), city: user.city, postal: user.postal, street: caesarDecipher(user.street,3), pesel: caesarDecipher(user.pesel,3,true)};
  }
  return {ok: false, errors: ['Niepoprawne dane']};
}