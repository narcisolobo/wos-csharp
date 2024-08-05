"""
1. Print 1 to 255
print_1_to_255()
Print all the integers from 1 to 255. 
"""


def print_1_to_255():
    # range takes in start, stop, step
    for i in range(1, 256):
        print(i)


print(" print_1_to_255 ".center(50, "*"))
print_1_to_255()

"""
2. Print Odds 1-255
print_odds_1_to_255()
Print all odd integers from 1 to 255.
"""


def print_odds_1_to_255():
    for i in range(1, 256):
        if i % 2 != 0:
            print(i)


print(" print_odds_1_to_255 ".center(50, "*"))
print_odds_1_to_255()

"""
3. Print Ints and Sum 0-255
print_ints_and_sum_0_to_255()
Print integers from 0 to 255, and with each integer
print the sum so far.
"""


def print_ints_and_sum_0_to_255():
    sum = 0
    for i in range(256):
        sum += i
        print(i, sum)


print(" print_ints_and_sum_0_to_255 ".center(50, "*"))
print_ints_and_sum_0_to_255()

"""
4. Iterate and Print List
print_list_vals(lst)
Iterate through a given list, printing each value. 
"""

colors = ["red", "blue", "yellow", "green", "purple"]


def print_list_vals(lst):
    for item in lst:
        print(item)


print(" print_list_vals ".center(50, "*"))
print_list_vals(colors)

"""
5. Find and Print Max
print_max_of_list(lst)
Given a list, find and print its largest element.
"""


def print_max_of_list(lst):
    max = lst[0]
    for number in lst:
        if number > max:
            max = number
    print(max)


numbers = [83, 66, 24, 58, 1, 83, 6, 11, 17, 29]
print(" print_max_of_list ".center(50, "*"))
print_max_of_list(numbers)

"""
6. Get and Print Average
print_average_of_list(lst)
Analyze a list's values and print the average. 
"""


def print_average_of_list(lst):
    sum = 0
    for i in range(len(lst)):
        sum += lst[i]

    print(sum / len(lst))


numbers = [1, 2, 3, 4, 5]
print(" print_average_of_list ".center(50, "*"))
print_average_of_list(numbers)

"""
7. List with Odds
return_odds_list_1_to_255()
Create a list with all the odd integers between 1 and 255 (inclusive).
"""


def return_odds_list_1_to_255():
    odds_list = []
    for i in range(1, 256, 2):
        odds_list.append(i)
    return odds_list


print(" return_odds_list_1_to_255 ".center(50, "*"))
print(return_odds_list_1_to_255())

"""
8. Square the Values
square_list_vals(lst)
Square each value in a given list, returning that same list with changed values. 
"""


def square_list_vals(lst):
    for i in range(len(lst)):
        lst[i] *= lst[i]
    return lst


numbers = [1, 2, 3, 4]
print(" square_list_vals ".center(50, "*"))
print(square_list_vals(numbers))

"""
9. Greater than Y
print_list_count_greater_than_y(lst, y)
Given a list and a value Y, count and print the number
of list values greater than Y. 
"""


def print_list_count_greater_than_y(lst, y):
    count = 0
    for i in range(len(lst)):
        if lst[i] > y:
            count += 1
            print(lst[i])
    print(f"count greater than y: {count}")


numbers = [83, 66, 24, 58, 1, 83, 6, 11, 17, 29]
val = 20
print(" print_list_count_greater_than_y ".center(50, "*"))
print_list_count_greater_than_y(numbers, val)

"""
10. Zero Out Negative Numbers
zero_out_list_negative_vals(lst)
Return the given list, after setting any negative values to zero. 
"""


def zero_out_list_negative_vals(lst):
    for i in range(len(lst)):
        if lst[i] < 0:
            lst[i] = 0
    return lst


numbers = [83, -66, -24, 58, 1, -83, 6, -11, 17, -29]
print(" zero_out_list_negative_vals ".center(50, "*"))
print(zero_out_list_negative_vals(numbers))

"""
11. Max, Min, Average
print_max_min_average_list_vals(lst)
Given a list, print the max, min and average values for that list.
"""


def print_max_min_average_list_vals(lst):
    max = lst[0]
    min = lst[0]
    sum = lst[0]
    for i in range(1, len(lst)):
        if lst[i] > max:
            max = lst[i]
        if lst[i] < min:
            min = lst[i]
        sum += lst[i]
    average = sum / len(lst)

    print(f"Max: {max}, Min: {min}, Average: {average}")


numbers = [1, 2, 3, 4, 5]
print(" print_max_min_average_list_vals ".center(50, "*"))
print_max_min_average_list_vals(numbers)

"""
12. Shift List Values
shift_list_vals_left(lst)
Given a list, move all values forward (to the left) by one index,
dropping the first value and leaving a 0 (zero) value at the end
of the list.
"""


def shift_list_vals_left(lst):
    for i in range(1, len(lst)):
        lst[i - 1] = lst[i]
    lst[len(lst) - 1] = 0
    return lst


numbers = [1, 2, 3, 4, 5]
print(" shift_list_vals_left ".center(50, "*"))
print(shift_list_vals_left(numbers))

"""
13. Swap String For List Negative Values
swap_string_for_list_negative_vals(lst)
Given a list of numbers, replace any negative values with the string
'Dojo'.
"""


def swap_string_for_list_negative_vals(lst):
    for i in range(len(lst)):
        if lst[i] < 0:
            lst[i] = "Dojo"
    return lst


numbers = [83, -66, -24, 58, 1, -83, 6, -11, 17, -29]
print(" swap_string_for_list_negative_vals ".center(50, "*"))
print(swap_string_for_list_negative_vals(numbers))
