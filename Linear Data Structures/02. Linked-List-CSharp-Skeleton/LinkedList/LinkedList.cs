using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node Head { get; set; }

    private Node Tail { get; set; }

    //private List<Node> List { get; set; }

    public int Count { get; private set; }

    public LinkedList()
    {
        this.Head = null;
        this.Tail = null;
        this.Count = 0;
    }

    public void AddFirst(T item)
    {
        Node node = new Node(item);
        if (this.Count == 0)
        {
            this.Head = node;
            this.Tail = node;
        }
        else
        {
            node.Next = this.Head;
            this.Head = node;
        }
        this.Count++;
    }

    public void AddLast(T item)
    {
        Node node = new Node(item);
        if (this.Count == 0)
        {
            this.Head = node;
            this.Tail = node;
        }
        else
        {
            this.Tail.Next = node;
            this.Tail = node;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            T value = this.Head.Value;
            this.Count--;
            if (this.Count == 0)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                this.Head = this.Head.Next;
            }
            return value;
        }
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            T value = this.Tail.Value;
            this.Count--;
            if(this.Count == 0)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                Node start = this.Head;
                while (start.Next != this.Tail)
                {
                    start = start.Next;
                }
                this.Tail = start;
            }
            return value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node start = this.Head;
        while(start != null)
        {
            yield return start.Value;
            start = start.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public T Value { get; set; }

        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
