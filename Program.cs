using System.Runtime.Intrinsics.Arm;

public class Node
{
    public object data;
    public Node link;

    public Node(object newdata)
    {
        data = newdata;
    }
}
public class LinkedList
{
    public Node header;

    public LinkedList()
    {
        header = new Node("Header");
    }
    public Node FindNode(object value)
    {
        Node current = header;
        while (current.data != value)
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
        while (current.link.data != value)
            current = current.link;
        return current;
    }
    public void Remove(object deleteddata)
    {
        Node current = FindPrevNode(deleteddata);
        current.link = current.link.link;
    }
    public int Count()
    {
        Node current = header;
        int count = 0;
        while (current.link != null)
        {
            count++;
            current = current.link;
        }
        return count;
    }
    public int Sum()
    {
        Node current = header.link;
        int sum = 0;
        while (current != null)
        {
            sum += Convert.ToInt32(current.data);
            current = current.link;
        }
        return sum;
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
public class Node2
{
    public object element;
    public Node2 flink, blink;
    public Node2()
    {
        element = null;
        flink = blink = null;
    }
    public Node2(object element)
    {
        this.element = element;
        flink = blink = null;
    }
}
public class DoubleLinkedList
{
    public Node2 header;
    public DoubleLinkedList()
    {
        header = new Node2("Header");
    }
    private Node2 Find(object element)
    {
        Node2 current = new Node2();
        current = header;
        while (current.element != element)
        {
            current = current.flink;
        }
        return current;
    }
    public void Insert(object newelement, object afterelement)
    {
        Node2 current = new Node2();
        Node2 newnode = new Node2(newelement);
        current = Find(afterelement);
        if (current.flink != null)
            current.flink.blink = newnode;
        newnode.flink = current.flink;
        current.flink = newnode;
        newnode.blink = current;
    }
    public void Remove(object element)
    {
        Node2 current = Find(element);
        if (current.flink != null)
        {
            current.blink.flink = current.flink;
            current.flink.blink = current.blink;
            current.flink = null;
            current.blink = null;
        }
    }
    private Node2 FindLast()
    {
        Node2 current = new Node2();
        current = header;
        while (!(current.flink == null))
            current = current.flink;
        return current;
    }
    public void Print()
    {
        Node2 current = new Node2();
        current = FindLast();
        while (!(current.blink == null))
        {
            Console.WriteLine(current.element);
            current = current.blink;
        }
    }
    public int Count()
    {
        Node2 current = FindLast();
        int count = 0;
        while (current != header)
        {
            count++;
            current = current.blink;
        }
        return count;
    }
    public int Sum()
    {
        int sum = 0;
        Node2 current = FindLast();
        while (current != header)
        {
            sum += Convert.ToInt32(current.element);
            current = current.blink;
        }
        return sum;
    }
}


public class Program
{
    static void Main(string[] args)
    {
        //LinkedList list = new LinkedList();
        DoubleLinkedList list = new DoubleLinkedList();
        list.Insert("23", "Header");
        list.Insert("56", "23");
        list.Insert("44", "56");
        list.Print();
        Console.WriteLine("====");
        Console.WriteLine(list.Count());
        Console.WriteLine(list.Sum());
        //list.Remove("56");
        //list.Print();
    }
}