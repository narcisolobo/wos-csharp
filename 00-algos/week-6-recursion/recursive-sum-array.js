/* 
  Recursively sum an arr of ints
*/

const nums1 = [1, 2, 3];
const expected1 = 6;

const nums2 = [1];
const expected2 = 1;

const nums3 = [];
const expected3 = 0;

/**
 * Add params if needed for recursion
 * Recursively sums the given array.
 * - Time: O(?).
 * - Space: O(?).
 * @param {Array<number>} nums
 * @returns {number} The sum of the given nums.
 */
function sumArr(nums, i = 0, sum = 0) {
  // base case
  if (i === nums.length) {
    return sum;
  }

  // update sum
  sum += nums[i];

  // progression to base case
  // and recursive call
  return sumArr(nums, i + 1, sum);
}

const result1 = sumArr(nums1);
console.log(`${result1} should equal ${expected1}`);

const result2 = sumArr(nums2);
console.log(`${result2} should equal ${expected2}`);

const result3 = sumArr(nums3);
console.log(`${result3} should equal ${expected3}`);
