/*
  Sum To One Digit
  Implement a function sumToOne(num)​ that,
  given a number, sums that number’s digits
  repeatedly until the sum is only one digit. Return
  that final one digit result.

  Tips:
    to access digits from a number, need to convert it .toString() to access each digit via index
    parseInt(arg) returns arg parsed as an integer, or NaN if it couldn't be converted to an int
    isNaN(arg) used to check if something is NaN
*/

const num1 = 5;
const expected1 = 5;

const num2 = 10;
const expected2 = 1;

const num3 = 25;
const expected3 = 7;

/**
 * Sums the given number's digits until the number becomes one digit.
 * @param {number} num The number to sum to one digit.
 * @returns {number} One digit.
 */
function rSumToOneDigit(num) {
  // your code here
}

const result1 = rSumToOneDigit(num1);
console.log(`${result1} should equal ${expected1}`);

/**
 * This function takes in an integer as input and
 * sums that number’s digits repeatedly until the
 * sum is only one digit.
 * @param {number} num
 * @returns {number}
 */
function sumToOne(num) {
  if (String(num).length === 1) {
    return num;
  }

  const nums = String(num)
    .split('')
    .map((char) => Number(char));

  let sum = 0;
  for (const num of nums) {
    sum += num;
  }
  return sumToOne(sum);
}
