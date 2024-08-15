class ListNode:
    """
    A class to represent a single item of a SinglyLinkedList that can be
    linked to other Node instances to form a list of linked nodes.
    """

    # (dunder init/constructor)
    def __init__(self, data):
        """
        Constructs a new Node instance.
        :param data: The data to be added into this new instance of a Node.
        """
        self.data = data
        self.next = None

    def __str__(self):
        return f"data: {self.data}, next: {self.next}"


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

    def is_empty(self):
        """
        Determines if this list is empty.
            :returns: bool - True if the list is empty, False otherwise.
        """
        pass

    def insert_at_back(self, data):
        """
        Creates a new node with the given data and inserts it at the back of
        this list.
            :param data: The data to be added to the new node.
            :returns: SinglyLinkedList - This list.
        """
        # create a new ListNode
        # check if SLL is empty
        # if so, set head to new ListNode
        # if not, we need to find the last node
        # we create a runner, set it to self.head
        # while runner.next is not None
        # runner = runner.next (i++)
        # after the while loop, runner.next = new_node
        pass

    def to_list(self):
        """
        Converts this list into a list containing the data of each node.
            :returns: List - A list of each node's data.
        """
        pass


my_sll = SinglyLinkedList()
print(my_sll)
my_sll.insert_at_back(5)
