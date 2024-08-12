"""
steps:
1. create a merge function to merge two already sorted lists into a single
    sorted list.
    - you do NOT need to work in place, ok to use a new list
2. create mergeSort function to sort the provided list
    - split the list in half and recursively merge the halves using the
        previously created merge function.
    - splitting of lists stops when list can no longer be split.
    - an list of 1 item is by definition sorted, so two lists of 1 item
        can therefore be merged into a sorted list.
"""


def merge(left, right):
    """
    Efficiently merges two already sorted lists into a new sorted list.
    Do not mutate the given lists.

    Time: O(n)
    Space: O(n)

    Args:
    left (list of int): The first sorted list.
    right (list of int): The second sorted list.

    Returns:
    list of int: A new sorted list containing all the elements of both given halves.
    """
    merged = []
    left_index, right_index = 0, 0

    # Continue to merge until one of the lists is exhausted
    while left_index < len(left) and right_index < len(right):
        if left[left_index] < right[right_index]:
            merged.append(left[left_index])
            left_index += 1
        else:
            merged.append(right[right_index])
            right_index += 1

    # If there are remaining elements in the left list, add them to the merged list
    while left_index < len(left):
        merged.append(left[left_index])
        left_index += 1

    # If there are remaining elements in the right list, add them to the merged list
    while right_index < len(right):
        merged.append(right[right_index])
        right_index += 1

    return merged


# Test cases
sortedA1 = []
sortedB1 = []
expectedMerge1 = []

sortedA2 = [5]
sortedB2 = [2]
expectedMerge2 = [2, 5]

sortedA3 = [3]
sortedB3 = [2, 3, 4, 7]
expectedMerge3 = [2, 3, 3, 4, 7]

sortedA4 = [1, 2, 4, 5, 6, 9]
sortedB4 = [3, 7, 8, 10]
expectedMerge4 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

print(merge(sortedA1, sortedB1))
print(merge(sortedA2, sortedB2))
print(merge(sortedA3, sortedB3))
print(merge(sortedA4, sortedB4))


def merge_sort(lst):
    """
    Sorts the provided list using the merge sort algorithm.

    Time: O(n log n)
    Space: O(n)

    Args:
    lst (list of int): The list to sort.

    Returns:
    list of int: A new sorted list.
    """
    if len(lst) <= 1:
        return lst

    mid = len(lst) // 2
    left_half = merge_sort(lst[:mid])
    right_half = merge_sort(lst[mid:])

    return merge(left_half, right_half)


# Test cases
numbersOrdered = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
numbersRandomOrder = [9, 2, 5, 6, 4, 3, 7, 10, 1, 8]
numbersReversed = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
expectedSort = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
