numbers1 = [11, 8, 14, 3, 6, 2, 7]
""" 
There are many possible answers for numbers1 depending on which number is chosen
as the pivot.

E.g., if 3 is chosen as the pivot, the below are some solutions because
numbers smaller than 3 are to the left and larger numbers are to the right
[2, 3, 7, 6, 11, 8, 14]
[2, 3, 11, 8, 7, 6, 14]
[2, 3, 8, 7, 11, 6, 14]
[2, 3, 8, 6, 14, 7, 11]
"""
numbers2 = [11, 8, 14, 3, 3, 3, 6, 2, 7]
numbers3 = [1, 17, 12, 3, 9, 13, 21, 4, 27]
numbers4 = [2, 1]


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

    pivot_idx = 0
    pivot_value = numbers[right_idx]

    for i in range(left_idx, right_idx):
        if numbers[i] <= pivot_value:
            numbers[i], numbers[pivot_idx] = numbers[pivot_idx], numbers[i]
            pivot_idx += 1

    numbers[pivot_idx], numbers[right_idx] = numbers[right_idx], numbers[pivot_idx]
    return pivot_idx
