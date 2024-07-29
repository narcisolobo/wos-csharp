/* 
  Array: Binary Search (non recursive)

  Given a sorted array and a value, return whether the array contains that value.
  Do not sequentially iterate the array. Instead, ‘divide and conquer’,
  taking advantage of the fact that the array is sorted.

  Bonus (alumni interview): 
    first complete it without the bonus, because they ask for additions
    after the initial algo is complete

    return how many times the given number occurs
*/

const numbers1 = [1, 3, 5, 6];
const searchNumber1 = 4;
const expected1 = false;

const numbers2 = [4, 5, 6, 8, 12];
const searchNumber2 = 5;
const expected2 = true;

const numbers3 = [3, 4, 6, 8, 12];
const searchNum3 = 3;
const expected3 = true;

// bonus, how many times does the search num appear?
const numbers4 = [2, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9];
const searchNumber4 = 2;
const expected4 = 4;

/**
 * Efficiently determines if the given num exists in the given array.
 * - Time: O(?).
 * - Space: O(?).
 * @param {Array<number>} sortedNumbers
 * @param {number} searchNum
 * @returns {boolean} Whether the given num exists in the given array.
 */
function binarySearch(sortedNumbers, searchNum) {
  let start = 0;
  let end = sortedNumbers.length - 1;

  while (start <= end) {
    let midIdx = Math.floor(start + (end - start) / 2);

    if (sortedNumbers[midIdx] === searchNum) {
      // return true;
      return countAdjacentDupes(sortedNumbers, midIdx);
    }

    if (searchNum < sortedNumbers[midIdx]) {
      end = midIdx - 1;
    } else {
      start = midIdx + 1;
    }
  }
  // return false;
  return 0;
}

function countAdjacentDupes(array, idx) {
  let count = 1;

  let leftIdx = idx - 1;
  while (leftIdx >= 0 && array[leftIdx] === array[idx]) {
    count++;
    leftIdx--;
  }

  let rightIdx = idx + 1;
  while (rightIdx < array.length && array[rightIdx] === array[idx]) {
    count++;
    rightIdx++;
  }

  return count;
}

console.log(binarySearch(numbers4, searchNumber4));
