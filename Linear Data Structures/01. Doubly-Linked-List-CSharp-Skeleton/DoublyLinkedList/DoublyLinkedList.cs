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
            
            this.Head.NextNode = null;
            this.Head.PrevNode = null;
        }
        else
        {
            ListNode<T> sourceHead = this.Head;
            this.Head = newNode;
            newNode.PrevNode = null;
            newNode.NextNode = sourceHead;
            sourceHead.PrevNode = this.Head;
        }
    }

    public void AddLast(T element)
    {
        throw new NotImplementedException();
    }

    public T RemoveFirst()
    {
        throw new NotImplementedException();
    }

    public T RemoveLast()
    {
        throw new NotImplementedException();
    }

    public void ForEach(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

    private class ListNode<T> 
    {
        public T Value { get; private set; }
        public ListNode<T> PrevNode { get; set; }
        public ListNode<T> NextNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
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
