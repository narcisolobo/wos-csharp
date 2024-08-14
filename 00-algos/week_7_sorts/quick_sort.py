numbers1 = [11, 8, 14, 3, 6, 2, 7]
expected1 = [2, 3, 6, 7, 8, 11, 14]

numbers2 = [1, 17, 12, 3, 9, 13, 21, 4, 27]
expected2 = [1, 3, 4, 9, 12, 13, 17, 21, 27]

numbers3 = [11, 8, 14, 3, 3, 3, 6, 2, 7]
expected3 = [2, 3, 3, 3, 6, 7, 8, 11, 14]

numbers4 = [1, 17, 12, 3, 9, 13, 21, 4, 27]
expected4 = [1, 3, 4, 9, 12, 13, 17, 21, 27]


def partition(numbers, left_idx=0, right_idx=None):
    """
    Partitions the given array in-place by selecting the number at the middle
    index to use it as a "pivot" value, then arranges all numbers less than the
    pivot to be on its left and all larger numbers to be on its right.

    - Time: O(n) where n is the number of elements between left_idx and right_idx.
    - Space: O(1), as the partitioning is done in-place.

    Args:
        numbers (list of int): The array of numbers to be partitioned.
        left_idx (int): The index indicating the start of the slice of the array
            being processed. Defaults to 0.
        right_idx (int): The index indicating the end of the slice of the array
            being processed. Defaults to None, which is set to the last index.

    Returns:
        int: The index where the left section of smaller items ends.
    """
    if right_idx is None:
        right_idx = len(numbers) - 1

    pivot_value = numbers[right_idx]
    pivot_idx = left_idx

    for i in range(left_idx, right_idx):
        if numbers[i] <= pivot_value:
            numbers[i], numbers[pivot_idx] = numbers[pivot_idx], numbers[i]
            pivot_idx += 1

    [numbers[pivot_idx], numbers[right_idx]] = [numbers[right_idx], numbers[pivot_idx]]
    return pivot_idx


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

    if left_idx < right_idx:
        pivot_index = partition(numbers, left_idx, right_idx)
        quick_sort(numbers, left_idx, pivot_index - 1)
        quick_sort(numbers, pivot_index + 1, right_idx)

    return numbers


print(quick_sort(numbers1))
print(quick_sort(numbers2))
print(quick_sort(numbers3))
print(quick_sort(numbers4))
