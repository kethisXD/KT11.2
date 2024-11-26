// Task 2
using System;

public class LinkedList<T> where T : class
{
    private class Node
    {
        public T Data;
        public Node Next;
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
            current = current.Next;
        current.Next = newNode;
    }

    public bool Remove(T item)
    {
        if (head == null)
            return false;

        if (head.Data.Equals(item))
        {
            head = head.Next;
            return true;
        }

        Node current = head;
        while (current.Next != null && !current.Next.Data.Equals(item))
            current = current.Next;

        if (current.Next == null)
            return false;

        current.Next = current.Next.Next;
        return true;
    }

    public bool Contains(T item)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Equals(item))
                return true;
            current = current.Next;
        }
        return false;
    }
}

public class Person
{
    public string Name { get; set; }
}

public class Book
{
    public string Title { get; set; }
}

class Program
{
    static void Main()
    {
        LinkedList<string> stringList = new LinkedList<string>();
        stringList.Add("Hello");
        stringList.Add("World");
        Console.WriteLine(stringList.Contains("Hello")); // True
        stringList.Remove("Hello");
        Console.WriteLine(stringList.Contains("Hello")); // False

        LinkedList<Person> personList = new LinkedList<Person>();
        personList.Add(new Person { Name = "Alice" });
        personList.Add(new Person { Name = "Bob" });
        Console.WriteLine(personList.Contains(new Person { Name = "Alice" })); // False (different instance)

        LinkedList<Book> bookList = new LinkedList<Book>();
        bookList.Add(new Book { Title = "C# Programming" });
        bookList.Add(new Book { Title = "Data Structures" });
        Console.WriteLine(bookList.Contains(new Book { Title = "C# Programming" })); // False (different instance)
    }
}
