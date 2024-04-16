'use client';
import Image from 'next/image';
import * as React from 'react';

import { Button } from '@/components/ui/button';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { Textarea } from '@/components/ui/textarea';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import { login, signup } from './actions';
export default function Home() {
  const [errors, setErrors] = React.useState<string[]>([]);
  return (
    <main className="flex min-h-screen flex-row items-center justify-center gap-8 p-8">
      {errors.length > 0 && (
        <Card className="w-[250px]">
          <CardHeader>
            <CardTitle>Błędy w formularzu</CardTitle>
            <CardDescription>
              Błędy w danych które zostały wprowadzone
            </CardDescription>
          </CardHeader>
          <CardContent>
            <ol>
              {errors.map((error) => (
                <li className="text-red-500 list-disc mx-4" key={error}>
                  {error}
                </li>
              ))}
            </ol>
          </CardContent>
          <CardFooter className="flex justify-between"></CardFooter>
        </Card>
      )}

      <Card className="w-[450px]">
        <CardHeader>
          <CardTitle>Dodaj dane</CardTitle>
          <CardDescription>
            Dodaj dane ktore zostana zaszyfrowane w bazie danych
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form
            action={async (formData: FormData) => {
              console.log('sending');
              let result = await signup(formData);

              console.log(result);
              if (result.ok) {
                alert('Dodano dane');
                setErrors([]);
                document.querySelector('form')?.reset();
              } else {
                alert('Nie udało się dodać danychx');
                setErrors(result.errors || []);
              }
            }}
          >
            <div className="grid w-full items-center gap-4">
              <div className="grid grid-cols-2 gap-4">
                <div>
                  <Label htmlFor="login">Login</Label>
                  <Input name="login" id="login" placeholder="Login" />
                </div>
                <div>
                  <Label htmlFor="password">Hasło</Label>
                  <Input
                    id="password"
                    name="password"
                    type="password"
                    placeholder="Hasło"
                  />
                </div>
              </div>
              <div className="grid grid-cols-2 gap-4">
                <div>
                  <Label htmlFor="name">Imię</Label>
                  <Input name="name" id="name" placeholder="Imie" />
                </div>
                <div>
                  <Label htmlFor="lastname">Nazwisko</Label>
                  <Input id="lastname" name="lastname" placeholder="Nazwisko" />
                </div>
              </div>

              <div className="grid grid-cols-2 gap-4">
                <div>
                  <Label htmlFor="city">Miasto</Label>
                  <Input id="city" name="city" placeholder="Miasto" />
                </div>
                <div>
                  <Label htmlFor="street">Ulica</Label>
                  <Input id="street" name="street" placeholder="Ulica" />
                </div>
              </div>
              <Label htmlFor="postal">Kod pocztowy</Label>
              <Input id="postal" name="postal" placeholder="Kod pocztowy" />
              <Label htmlFor="pesel">Pesel</Label>
              <Input id="pesel" name="pesel" placeholder="Pesel" />
              <Button type="submit">Dodaj</Button>
            </div>
          </form>
        </CardContent>
        <CardFooter className="flex justify-between"></CardFooter>
      </Card>
      <Card className="w-[450px]">
        <CardHeader>
          <CardTitle>Wyświetl dane</CardTitle>
          <CardDescription>
            Wyświetl dane które zostały zaszyfrowane w bazie danych
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form
            id="form2"
            action={async (formData: FormData) => {
              console.log('sending');
              let result = await login(formData);

              console.log(result);
              if (result.ok) {
                alert(
                  result.login +
                    '\n' +
                    result.name +
                    '\n' +
                    result.lastname +
                    '\n' +
                    result.city +
                    '\n' +
                    result.postal +
                    '\n' +
                    result.street +
                    '\n' +
                    result.pesel
                );
                setErrors([]);
                (document.querySelector('#form2') as HTMLFormElement).reset();
              } else {
                alert('Nie ma konta');
                setErrors(result.errors || []);
              }
            }}
          >
            <div className="grid w-full items-center gap-4">
              <Label htmlFor="login">Login</Label>
              <Input name="login" id="login" placeholder="Login" />

              <Label htmlFor="password">Hasło</Label>
              <Input
                id="password"
                name="password"
                type="password"
                placeholder="Hasło"
              />

              <Button type="submit">Zaloguj</Button>
            </div>
          </form>
        </CardContent>
        <CardFooter className="flex justify-between"></CardFooter>
      </Card>
    </main>
  );
}
