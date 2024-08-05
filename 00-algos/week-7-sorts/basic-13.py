"""
1. Print 1 to 255
"""


def print_1_to_255():
    # range takes in start, stop, step
    for i in range(1, 256):
        print(i)


print_1_to_255()

"""
2. Print Odds 1-255
"""

"""
3. Print Ints and Sum 0-255
"""


def print_ints_and_sum_0_to_255():
    sum = 0
    for i in range(256):
        sum += i
        print(i, sum)


print_ints_and_sum_0_to_255()

"""
4. Iterate and Print List
"""

"""
5. Find and Print Max
print_max_of_list(lst)
Given a list, find and print its largest element.
"""

"""
6. Get and Print Average
print_average_of_list(lst)
Analyze a list's values and print the average. 
"""

"""
7. List with Odds
return_odds_list_1_to_255()
Create a list with all the odd integers between 1 and 255 (inclusive).
"""

"""
8. Square the Values
square_list_vals(lst)
Square each value in a given list, returning that same list with changed values. 
"""

"""
9. Greater than Y
print_list_count_greater_than_y(lst, y)
Given a list and a value Y, count and print the number of list values greater than Y. 
"""

"""
10. Zero Out Negative Numbers
zero_out_list_negative_vals(lst)
Return the given list, after setting any negative values to zero. 
"""

"""
11. Max, Min, Average
print_max_min_average_list_vals(lst)
Given a list, print the max, min and average values for that list.
"""

"""
12. Shift List Values
shift_list_vals_left(lst)
Given a list, move all values forward (to the left) by one index,
dropping the first value and leaving a 0 (zero) value at the end
of the list.
"""

"""
13. Swap String For List Negative Values
swap_string_for_list_negative_vals(lst)
Given a list of numbers, replace any negative values with the string
'Dojo'.
"""
