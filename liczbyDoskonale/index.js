const DESIRED_AMOUNT = 50;
let perfectNumbers = [];

function isPerfectNumber(number) {
  let sum = 0n;
  for (let i = 1; i < number; i++) {
    if (number % i === 0) {
      sum += i;
    }
  }
  return sum === number;
}
function isPrimeNumber(number) {
  if (number % 2n === 0n && number != 2n) return false;
  if (number % 3n === 0n && number != 3n) return false;
  for (let i = 4n; i < number; i++) {
    if (number % i === 0n) return false;
  }
  return true;
}
let power = 1n;
while (perfectNumbers.length < DESIRED_AMOUNT) {
  let number = 2n ** power - 1n;
  if (isPrimeNumber(number)) {
    let newNumber = number * 2n ** (power - 1n);

    perfectNumbers.push(newNumber);
    console.log(newNumber);
  }
  power++;
}

console.log(perfectNumbers);

// const bn = require('bn-str-256');
// const DESIRED_AMOUNT = 50;
// let perfectNumbers = [];
// function isPrimeNumber(number) {
//   if (bn.eq(bn.mod(number, 2), 0)) return false;
//   if (bn.eq(bn.mod(number, 3), 0)) return false;

//   let i = bn.parse('5');
//   while (bn.lt(i, number)) {
//     if (bn.eq(bn.mod(number, i), 0)) {
//       return false;
//     }

//     i = bn.add(i, 1);
//   }
//   return true;
// }
// let power = bn.parse('1');
// while (perfectNumbers.length < DESIRED_AMOUNT) {
//   let number = bn.sub(bn.pow(2, power), 1);
//   if (isPrimeNumber(number)) {
//     let newNumber = bn.mul(number, bn.pow(2, bn.sub(power, 1)));

//     console.log(newNumber);
//     perfectNumbers.push(newNumber);
//   }
//   power = bn.add(power, 1);
//   console.log('power', power);
// }

// console.log(perfectNumbers);
