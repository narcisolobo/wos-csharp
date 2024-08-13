def selection_sort(numbers):
    """
    Sorts the given list in-place using the selection sort algorithm.

    Parameters:
        numbers (list): The list of numbers to be sorted.

    Returns:
        list: The sorted list.
    """
    n = len(numbers)
    for i in range(n):
        min_index = i
        for j in range(i + 1, n):
            if numbers[j] < numbers[min_index]:
                min_index = j
        numbers[i], numbers[min_index] = numbers[min_index], numbers[i]
    return numbers


# Test cases
numbers_ordered = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
numbers_random_order = [9, 2, 5, 6, 4, 3, 7, 10, 1, 8]
numbers_reversed = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

print(selection_sort(numbers_ordered) == expected)
print(selection_sort(numbers_random_order) == expected)
print(selection_sort(numbers_reversed) == expected)
