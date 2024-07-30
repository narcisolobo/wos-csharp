/* 
  Return the fibonacci number at the nth position, recursively.
  
  Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...

  The next number is found by adding up the two numbers before it,
  starting with 0 and 1 as the first two numbers of the sequence.
*/

const num1 = 0;
const expected1 = 0;

const num2 = 1;
const expected2 = 1;

const num3 = 2;
const expected3 = 1;

const num4 = 3;
const expected4 = 2;

const num5 = 4;
const expected5 = 3;

const num6 = 8;
const expected6 = 21;

function iFibonacci(num) {
  const fibArr = [0, 1];
  for (let i = 2; i <= num; i++) {
    fibArr.push(fibArr[i - 2] + fibArr[i - 1]);
  }
  return fibArr[num];
}

/**
 * Recursively finds the nth number in the fibonacci sequence.
 * - Time: O(?).
 * - Space: O(?).
 * @param {number} num The position of the desired number in the fibonacci sequence.
 * @returns {number} The fibonacci number at the given position.
 */
function rFibonacci(num) {
  if (num < 0) {
    return null;
  }

  if (num < 2) {
    return num;
  }
  return rFibonacci(num - 1) + rFibonacci(num - 2);
}

const result1 = rFibonacci(num1);
console.log(`${result1} should equal ${expected1}`);

const result2 = rFibonacci(num2);
console.log(`${result2} should equal ${expected2}`);

const result3 = rFibonacci(num3);
console.log(`${result3} should equal ${expected3}`);

const result4 = rFibonacci(num4);
console.log(`${result4} should equal ${expected4}`);

const result5 = rFibonacci(num5);
console.log(`${result5} should equal ${expected5}`);

const result6 = rFibonacci(num6);
console.log(`${result6} should equal ${expected6}`);
