"""
  https://www.hackerearth.com/practice/algorithms/sorting/bubble-sort/visualize/

  Stable sort
  
  Time Complexity
    - Best: O(n) linear when array is already sorted.
    - Average: O(n^2) quadratic.
    - Worst: O(n^2) quadratic when the array is reverse sorted.

  Space: O(1) constant.

  For review, create a function that uses BubbleSort to sort an unsorted array in-place.

  For every pair of adjacent indices, swap them if the item on the left is larger than the item on the right until array is fully sorted
"""

numbersOrdered = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
numbersRandomOrder = [9, 2, 5, 6, 4, 3, 7, 10, 1, 8]
numbersReversed = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]


def bubbleSort(numbers=[]):
    """
    Sorts the given numbers in-place by mutating the array.
    Best: O(n) linear when array is already sorted.
    Average: O(n^2) quadratic.
    Worst: O(n^2) quadratic when the array is reverse sorted.
    @param {Array<number>} numbers
    @returns {Array<number>} The given numbers after being sorted.

    Args:
        numbers (numbers): the list to sort. Defaults to [].
    """
    # your code here
    # nested loops
