from typing import Any, Self


class ListNode:
    """
    A class to represent a single item of a SinglyLinkedList that can be
    linked to other Node instances to form a list of linked nodes.
    """

    # (dunder init/constructor)
    def __init__(self, data: int):
        """
        Constructs a new Node instance.
        :param data: The data to be added into this new instance of a Node.
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
            :returns: bool - True if the list is empty, False otherwise.
        """
        return self.head is None

    def insert_at_back(self, data: int) -> Self:
        """
        Creates a new node with the given data and inserts it at the back of
        this list.
            :param data: The data to be added to the new node.
            :returns: SinglyLinkedList - This list.
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

    def insert_at_back_many(self, vals: list[int]) -> Self:
        """
        Calls insert_at_back on each item of the given list.
            :param vals: List of values to be added to the list.
            :returns: SinglyLinkedList - This list.
        """
        for item in vals:
            self.insert_at_back(item)
        return self

    def to_list(self) -> list[Any]:
        """
        Converts this list into a list containing the data of each node.
            :returns: List - A list of each node's data.
        """
        lst = []
        runner = self.head
        while runner:
            lst.append(runner.data)
            runner = runner.next
        return lst


# Test case
my_sll = SinglyLinkedList().insert_at_back_many([5, 10, 4, 3, 6, 1, 7, 2])

# Convert the singly linked list to a list and print it
print(my_sll.to_list())

# Print the singly linked list with the __str__ method
print(my_sll)
