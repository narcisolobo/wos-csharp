"""
  https://www.hackerearth.com/practice/algorithms/sorting/bubble-sort/visualize/

  Stable sort
  
  Time Complexity
    - Best: O(n) linear when numbersay is already sorted.
    - Average: O(n^2) quadratic.
    - Worst: O(n^2) quadratic when the numbersay is reverse sorted.

  Space: O(1) constant.

  For review, create a function that uses Bubble_sort to sort an unsorted
  numbersay in-place.

  For every pair of adjacent indices, swap them if the item on the left
  is larger than the item on the right until numbersay is fully sorted
"""

numbersOrdered = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
numbersRandomOrder = [9, 2, 5, 6, 4, 3, 7, 10, 1, 8]
numbersReversed = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]
expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]


def bubble_sort(numbers: list[int]):
    """
    Sorts the given list of numbers in place using the Bubble Sort algorithm.

    This function mutates the input list to sort the elements in ascending order.
    It iterates through the list, repeatedly swapping adjacent elements that are
    out of order.

    Time Complexity:
        Best: O(n) - when the list is already sorted.
        Average: O(n^2) - typical performance.
        Worst: O(n^2) - when the list is reverse sorted.

    Args:
        numbers (list[int]): The list of numbers to sort. Defaults to an empty list if not provided.

    Returns:
        list[int]: The sorted list of numbers.
    """
    n = len(numbers)
    is_sorted = False

    while not is_sorted:
        is_sorted = True

        for i in range(n - 1):
            j = i + 1
            if numbers[i] > numbers[j]:
                is_sorted = False
                # one-line swap
                numbers[i], numbers[j] = numbers[j], numbers[i]
    return numbers


print(bubble_sort(numbersOrdered))
print(bubble_sort(numbersRandomOrder))
print(bubble_sort(numbersReversed))


def bubble_sort_2(numbers):
    """
    Sorts a list of numbers in ascending order using the iterative Bubble Sort algorithm.

    This function iterates through the list multiple times, comparing adjacent elements
    and swapping them if they are in the wrong order. The process repeats until no
    more swaps are needed, indicating that the list is sorted.

    Time Complexity:
        Best: O(n) - when the list is already sorted.
        Average: O(n^2) - typical performance.
        Worst: O(n^2) - when the list is reverse sorted.

    Space Complexity:
        O(1) - only a constant amount of extra space is used.

    Args:
        numbers (list[int]): The list of numbers to sort.

    Returns:
        list[int]: The sorted list of numbers.
    """
    n = len(numbers)
    for i in range(n):
        swapped = False

        for j in range(n - i - 1):
            if numbers[j] > numbers[j + 1]:
                temp = numbers[j]
                numbers[j] = numbers[j + 1]
                numbers[j + 1] = temp
                swapped = True

        if not swapped:
            break
    return numbers


print(bubble_sort_2(numbersOrdered))
print(bubble_sort_2(numbersRandomOrder))
print(bubble_sort_2(numbersReversed))
