public class Node
{
    public object data;
    public Node link;

    public Node(object newdata)
    {
        data = newdata;
    }
}
public class LinkedList{
    public Node header;
    
    public LinkedList()
    {
        header = new Node("Header");
    }  
    public Node FindNode(object value)
    {
        Node current = header;
        while(current.data!=value)
            current = current.link;
        return current;
    }
    public void Insert(object newdata, object afterelement)
    {
       Node current = FindNode(afterelement); 
       Node newnode = new Node(newdata);
       newnode.link = current.link;
       current.link = newnode;
    }  
    public Node FindPrevNode(object value)
    {
        Node current = header;
        while(current.link.data!=value)
            current = current.link;
        return current;
    }
    public void Remove(object deleteddata)
    {
        Node current = FindPrevNode(deleteddata);
        current.link = current.link.link;
    }
    public void Print()
    {
        Node current = header.link;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.link;
        }
    }
}
public class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.Insert("First", "Header");
        list.Insert("Second", "First");
        list.Insert("Third", "Second");
        list.Print();
        Console.WriteLine("====");
        list.Remove("Second");
        list.Print();
    }
}