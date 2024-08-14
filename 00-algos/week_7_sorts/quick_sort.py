from week_7_sorts.partition import partition

numbers1 = [11, 8, 14, 3, 6, 2, 7]
expected1 = [2, 3, 6, 7, 8, 11, 14]

numbers2 = [1, 17, 12, 3, 9, 13, 21, 4, 27]
expected2 = [1, 3, 4, 9, 12, 13, 17, 21, 27]

numbers3 = [11, 8, 14, 3, 3, 3, 6, 2, 7]
expected3 = [2, 3, 3, 3, 6, 7, 8, 11, 14]

numbers4 = [1, 17, 12, 3, 9, 13, 21, 4, 27]
expected4 = [1, 3, 4, 9, 12, 13, 17, 21, 27]


def quick_sort(numbers, left_idx=0, right_idx=None):
    """
    Recursively sorts the given array in-place by mutating the array.
    Best: O(n log(n)) linearithmic.
    Average: O(n log(n)) linearithmic.
    Worst: O(n^2) quadratic.
    @see https://www.hackerearth.com/practice/algorithms/sorting/quick-sort/visualize/
         visualization.
    :param numbers: List[int] - The list of numbers to be sorted.
    :param left_idx: int - The index indicating the start of the slice of the
        given array being processed.
    :param right_idx: int - The index indicating the end of the slice of the
        given array being processed.
    :returns: List[int] - The given list after being sorted.
    """
    if right_idx is None:
        right_idx = len(numbers) - 1
