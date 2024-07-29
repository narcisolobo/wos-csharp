/* 
Recursive Sigma

Input: integer
Output: sum of integers from 1 to Input integer
*/

const num1 = 5;
const expected1 = 15;
// Explanation: (1 + 2 + 3 + 4 + 5)

const num2 = 2.5;
const expected2 = 3;
// Explanation: (1 + 2)

const num3 = -1;
const expected3 = 0;

/**
 * Recursively sum the given int and every previous positive int.
 * - Time: O(?).
 * - Space: O(?).
 * @param {number} num
 * @returns {number}
 */
function recursiveSigma(num) {
  // turn num into int if decimal
  num = parseInt(num);

  // base case
  if (num < 1) {
    return 0;
  }

  // progression to base case and recursive call
  return num + recursiveSigma(num - 1);
}

const result1 = recursiveSigma(num1);
console.log(`${result1} should equal ${expected1}`);

const result2 = recursiveSigma(num2);
console.log(`${result2} should equal ${expected2}`);

const result3 = recursiveSigma(num3);
console.log(`${result3} should equal ${expected3}`);
