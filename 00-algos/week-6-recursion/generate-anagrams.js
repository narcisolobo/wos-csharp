// http://algorithms.dojo.news/static/Algorithms/index.html#LinkTarget_2129
/* 
  String Anagrams

  Given a string, return array where each element is a string representing a
  different anagram (a different sequence of the letters in that string).

  Ok to use built in methods
*/

const str1 = 'lim';
const expected1 = ['ilm', 'iml', 'lim', 'lmi', 'mil', 'mli'];
// Order of the output array does not matter

/**
 * Generates all anagrams (permutations) for the given string
 * @see https://www.geeksforgeeks.org/time-complexity-permutations-string/
 * - Time: O(n^2 * n!)
 * - Space: O(n!) factorial due to the call stack.
 */
function generateAnagrams(str, solutions = [], partial = '') {
  // base case
  if (!str) {
    solutions.push(partial);
  }

  for (let i = 0; i < str.length; i++) {
    const leftSlice = str.slice(0, i);
    const rightSlice = str.slice(i + 1);
    generateAnagrams(leftSlice + rightSlice, solutions, partial + str[i]);
  }
  return solutions;
}

const result1 = generateAnagrams(str1);
console.log('Expected:');
console.log(expected1);
console.log('Result:');
console.log(result1);
