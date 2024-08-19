from typing import Any, Self


class NonNumericDataError(Exception):
    """
    Raised when adding numeric data to non-numeric data.
    """

    def __init__(self, data: Any) -> None:
        super().__init__(f"Non-numeric data '{data}' encountered in the list.")


class ListNode:
    """
    A class to represent a single item of a SinglyLinkedList that can be
    linked to other Node instances to form a list of linked nodes.
    """

    # (dunder init/constructor)
    def __init__(self, data: Any):
        """
        Constructs a new Node instance.

        Args:
            data (Any): The data to be added into this new instance of a Node.
        """
        self.data = data
        self.next = None

    def __str__(self):
        return f"{self.data} -> {self.next}"


class SinglyLinkedList:
    """
    This class keeps track of the start (head) of the list and stores all the
    functionality (methods) that each list should have.
    """

    def __init__(self):
        """
        Constructs a new instance of an empty linked list.
        """
        self.head = None

    def __str__(self):
        return f"head: {self.head}"

    def is_empty(self) -> bool:
        """
        Determines if this list is empty.

        Returns:
            `bool` - `True` if the list is empty, `False` otherwise.
        """
        return self.head is None

    def insert_at_back(self, data: Any) -> Self:
        """
        Creates a new node with the given data and inserts itat the
        back of this list.

        Args:
            `data` (`Any`): The data to be added to the new node.

        Returns:
            `Self`: `SinglyLinkedList` - This list.
        """
        # create a new ListNode
        new_node = ListNode(data)

        # check if SLL is empty
        # if so, set head to new ListNode
        if self.is_empty():
            self.head = new_node

        # if not, we need to find the last node
        # we create a runner, set it to self.head
        else:
            runner = self.head
            # while runner.next is not None
            while runner.next:
                # increment the runner (i++)
                runner = runner.next
            # after the while loop, runner.next = new_node
            runner.next = new_node

        # this is for chaining methods
        return self

    def insert_at_back_many(self, vals: list[Any]) -> Self:
        """
        Calls `insert_at_back` on each item of the given list.

        Args:
            `vals` (`list[Any]`): List of values to be added to the list.

        Returns:
            `Self`: `SinglyLinkedList` - This list.
        """
        for item in vals:
            self.insert_at_back(item)
        return self

    def to_list(self) -> list[Any]:
        """
        Converts this list into a list containing the data of each node.

        Returns:
            `list[Any]`: A list of each node's data.
        """
        lst = []
        runner = self.head
        while runner:
            lst.append(runner.data)
            runner = runner.next
        return lst

    def insert_at_front(self, data: Any) -> Self:
        """
        Creates a new node with the given data and inserts that
        node at the front of this list.

        Args:
            `data` (`Any`): The data to be added to the new node.

        Returns:
            `Self`: `SinglyLinkedList` - This list.
        """
        new_node = ListNode(data)
        if self.is_empty():
            self.head = new_node

        else:
            new_node.next = self.head
            self.head = new_node

        return self

    def remove_head(self) -> Any:
        """
        Removes the first node of this list and returns its data.
        If list is empty, return None.

        Returns:
            `Any`: The data from the removed node.
        """
        if self.is_empty():
            return None

        else:
            data = self.head.data
            self.head = self.head.next
            return data

    def calculate_average(self) -> float | None:
        """
        Calculates the average of this list. Return None if
        list is empty. Raise exception if non-numerical data is
        in the list.

        Returns:
            float|None: The average of the node's data.
        """
        if self.is_empty():
            return None

        else:
            count = 0
            sum = 0
            runner = self.head

            while runner:
                try:
                    sum += runner.data
                    count += 1
                    runner = runner.next
                except:
                    raise NonNumericDataError(runner.data)
            return sum / count

    def remove_back(self):
        """
        Removes the last node of this list.

        Returns:
            `Any`: The data from the node that was removed.
        """

        # empty list
        if self.is_empty():
            return None

        # if there is only one node
        if not self.head.next:
            data = self.head.data
            self.head = None
            return data

        # loop to second-to-last node
        runner = self.head
        while runner.next.next:
            runner = runner.next

        data = runner.next.data
        runner.next = None
        return data

    def contains(self, val):
        """
        Determines whether or not the given search value
        exists in this list.

        Args:
            val (`Any`): The data to search for in the nodes of this list.

        Returns:
            `boolean`: `True` if `val` exists in list, `False` if not.
        """
        runner = self.head
        while runner:
            if runner.data == val:
                return True
            runner = runner.next
        return False

    def contains_recursive(self, val, runner=None):
        # Start recursion from the head if runner is not provided
        if runner is None:
            return self._contains_recursive(val, self.head)

    def _contains_recursive(self, val, runner):
        # Base case: end of list
        if runner is None:
            return False

        # Base case: found the value
        if runner.data == val:
            return True

        # Recursive call: move to the next node
        return self._contains_recursive(val, runner.next)

    def recursive_max(self):
        # Use a helper function to perform the recursion
        def _recursive_max(runner, max_node):
            # Base case: end of list
            if runner is None:
                return max_node.data if max_node else None

            # Update max_node if runner's data is larger
            if runner.data > max_node.data:
                max_node = runner

            # Recursive call: move to the next node
            return _recursive_max(runner.next, max_node)

        # Start the recursion from the head of the list
        if self.head is None:
            return None
        return _recursive_max(self.head, self.head)


# Test case
my_sll = SinglyLinkedList()
my_sll.insert_at_back_many([5, 10, 4, 3, 6, 1, 7, 2])

# Convert the singly linked list to a list and print it
print(my_sll.to_list())

# Print the singly linked list with the __str__ method
print(my_sll)

print("insert_at_front")
my_sll.insert_at_front(23)
print(my_sll)

print("remove_head")
print(my_sll.remove_head())
print(my_sll)

# calculate average
test_sll = SinglyLinkedList()
test_sll.insert_at_back_many([1, 2, 3, 4])
print(test_sll.calculate_average())

# calculate average with exception
""" test_sll2 = SinglyLinkedList()
test_sll2.insert_at_back_many([1, "hello"])
print(test_sll2.calculate_average()) """

print(my_sll.remove_back())
print(my_sll)

print(my_sll.contains(10))
print(my_sll.contains(11))

print(my_sll.contains_recursive(10))
print(my_sll.contains_recursive(11))

print(my_sll.recursive_max())
