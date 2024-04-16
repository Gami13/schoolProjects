import path from 'path';
import getConfig from 'next/config';

export const serverPath = (staticFilePath: string) => {
  console.log('serverPath', getConfig().serverRuntimeConfig.PROJECT_ROOT);
  return path.join(
    getConfig().serverRuntimeConfig.PROJECT_ROOT,
    staticFilePath
  );
};

import { join } from 'path';
export function getDbFilePath() {
  return join(process.cwd(), 'db.db'); // adjust the path accordingly
}


export function caesarCipher(str: string, shift: number) {
  return str
    .split('')
    .map((char) => {
      const code = char.charCodeAt(0);
      if (code >= 65 && code <= 90) {
        return String.fromCharCode(((code - 65 + shift) % 26) + 65);
      }
      if (code >= 97 && code <= 122) {
        return String.fromCharCode(((code - 97 + shift) % 26) + 97);
      }
      if (code >= 48 && code <= 57) {
        
        return String.fromCharCode(((code - 48 + shift) % 10) + 48);
      }
      return char;
    })
    .join('');
}

export function caesarDecipher(str: string, shift: number, isPesel = false) {
  
  if (isPesel) {
    return caesarCipher(str, 10 - shift);
  }
  return caesarCipher(str, 26 - shift);
}