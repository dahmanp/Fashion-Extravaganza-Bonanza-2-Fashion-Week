public class CircularLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public CircularLinkedList()
    {
        head = null;
        tail = null;
    }

    // Add an item to the list
    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            newNode.Next = head;  // Circular link
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head;  // Circular link
        }
    }

    // Get the next node in the circular list
    public Node<T> GetNext(Node<T> current)
    {
        if (current == null)
            return null;

        return current.Next;  // Return the next node in the circular list
    }

    // Get the head node of the list
    public Node<T> GetHead()
    {
        return head;
    }
}