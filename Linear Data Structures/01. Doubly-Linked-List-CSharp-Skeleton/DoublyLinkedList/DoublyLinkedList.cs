using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private ListNode<T> Head;

    private ListNode<T> Tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        ListNode<T> newNode = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.Head = newNode;
            this.Tail = newNode;
        }
        else
        {
            newNode.NextNode = this.Head;
            this.Head.PrevNode = newNode;
            this.Head = newNode;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        ListNode<T> newNode = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.Head = newNode;
            this.Tail = newNode;
        }
        else
        {
            this.Tail.NextNode = newNode;
            newNode.PrevNode = this.Tail;
            this.Tail = newNode;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        var value = this.Head.Value;
        if (this.Head == this.Tail)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            var nextNode = this.Head.NextNode;
            this.Head = nextNode;
        }
        this.Count--;
        return value;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        var value = this.Tail.Value;

        this.Tail = this.Tail.PrevNode;
        if (this.Tail == null)
        {
            this.Head = null;
        }
        else
        {
           this.Tail.NextNode= null;
        }
        this.Count--;
        return value;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.Head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.Head;
        while(currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] list = new T[Count];
        int i = 0;
        var currentNode = this.Head;
        while (currentNode != null)
        {
            list[i] = currentNode.Value;
            i++;
            currentNode = currentNode.NextNode;
        }
        return list;
    }

    
}

 class ListNode<T>
{
    public T Value { get; private set; }
    public ListNode<T> PrevNode { get; set; }
    public ListNode<T> NextNode { get; set; }

    public ListNode(T value)
    {
        this.Value = value;
    }
}

class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
