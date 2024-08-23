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
            `SinglyLinkedList`: This list.
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
            `SinglyLinkedList`: This list.
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
            `SinglyLinkedList`: This list.
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

    def second_to_last(self):
        """
        Retrieves the data of the second to last node in this list.

        Returns:
            `Any`: The data of the second to last node or `None` if there is no second to last node.
        """
        if self.is_empty() or self.head.next is None:
            return None

        runner = self.head
        while runner.next.next:
            runner = runner.next

        return runner.data

    def remove_val(self, val):
        """
        Removes the first node that has the matching given val as it's data.

        Args:
            `val` (`Any`): The value to compare to the node's data to find the node to be removed.

        Returns:
            `bool`: Indicates if a node was removed or not.
        """
        if self.is_empty():
            return False

        # If the head needs to be removed
        if self.head.data == val:
            self.head = self.head.next
            return True

        runner = self.head
        while runner.next:
            if runner.next.data == val:
                runner.next = runner.next.next
                return True
            runner = runner.next

        return False

    # EXTRA
    def prepend(self, new_val, target_val):
        """
        Inserts a new node before a node that has the given `target_val` as its data.

        Args:
            `new_val` (`Any`): The value to use for the new node that is being added.
            `target_val` (`Any`): The value to use to find the node that the new_val should be inserted in front of.

        Returns:
            `bool`: To indicate whether the node was pre-pended or not.
        """
        if self.is_empty():
            return False

        new_node = ListNode(new_val)

        # If we need to prepend before the head
        if self.head.data == target_val:
            new_node.next = self.head
            self.head = new_node
            return True

        runner = self.head
        while runner.next:
            if runner.next.data == target_val:
                new_node.next = runner.next
                runner.next = new_node
                return True
            runner = runner.next

        return False

    def concat(self, add_list):
        """
        Concatenates the nodes of a given list onto the back of this list.

        Args:
            `add_list`: An instance of a different list whose nodes will be added to the back of this list.

        Returns:
            `SinglyLinkedList`: This list with the added nodes.
        """
        # your code here

    def move_min_to_front(self):
        """
        Finds the node with the smallest data and moves that node to the front of this list.

        Returns:
            `SinglyLinkedList`: This list with the smallest node moved to the front.
        """
        # your code here

    def split_on_val(self, val):
        """
        Splits this list into two lists where the second list starts with the node that has the given value.

        Args:
            `val`: The value in the node that the list should be split on.

        Returns:
            `SinglyLinkedList`: The new list containing the nodes that are no longer in this list.
        """
        # your code here


# Test case
my_sll = SinglyLinkedList()
my_sll.insert_at_back_many([5, 10, 4, 3, 6, 1, 7, 2])

print("before:")
print(my_sll)
# head: 5 -> 10 -> 4 -> 3 -> 6 -> 1 -> 7 -> 2 -> None

print(f"second to last: {my_sll.second_to_last()}")

my_sll.remove_val(4)
print("after removing 4:")
print(my_sll)

my_sll.prepend(12, 6)
print("after prepending 12 before 6:")
print(my_sll)
# head: 5 -> 10 -> 4 -> 3 -> 12 -> 6 -> 1 -> 7 -> 2 -> None

second_list = SinglyLinkedList()
second_list.insert_at_back_many([32, 19, 88, 14])

my_sll.concat(second_list)
# head: 5 -> 10 -> 4 -> 3 -> 12 -> 6 -> 1 -> 7 -> 2 -> 32 -> 19 -> 88 -> 14 -> None

my_sll.move_min_to_front()
# head: 1 -> 5 -> 10 -> 4 -> 3 -> 12 -> 6 -> 7 -> 2 -> 32 -> 19 -> 88 -> 14 -> None

my_sll.split_on_val(7)
# head: 7 -> 2 -> 32 -> 19 -> 88 -> 14 -> None
