function isPalindrome(s) {
  s = s.toLowerCase().replaceAll(' ', '');

  for (let i = 0; i < s.length / 2; i++) {
    if (s[i] !== s[s.length - i - 1]) {
      return false;
    }
  }
  return true;
}

console.log(isPalindrome('racecar'));
console.log(isPalindrome('kayak'));
console.log(isPalindrome('hello'));
console.log(isPalindrome('a a'));
console.log(isPalindrome('a b'));
console.log(isPalindrome('kobyła ma mały bok'));
