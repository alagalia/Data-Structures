using System;
using System.Collections;
using System.Collections.Generic;

class ReversedList<T> : IEnumerable<T>
{
    private T[] arr;
    private const int DefaultCapacity = 2;
    public int Count { get; private set; }
    public int Capacity { get; private set; }

    public ReversedList(int capacity = DefaultCapacity)
    {
        this.arr = new T[capacity];
        this.Capacity = capacity;
        this.Count = 0;
    }

    public void Add(T item)
    {
        if (Count >= this.arr.Length)
        {
            this.Resize();
        }
        this.arr[this.Count++] = item;
    }

    public T RemoveAt(int index)
    {
        this.CheckIndexValidity(index);
        
        T element = this[this.Count - 1 - index];
        this.ShiftLeft(this.Count - 1 - index);
        this.Count--;
        return element;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.arr[i] = this.arr[i + 1];
        }
    }

    public T this[int index]
    {
        get
        {
            this.CheckIndexValidity(index);

            return this.arr[this.Count - 1 - index];
        }
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Resize()
    {
        var newArray = new T[this.Capacity * 2];
        this.arr.CopyTo(newArray, 0);
        this.arr = newArray;
        this.Capacity *= 2;
    }

    private void CheckIndexValidity(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ReversedList<string> arr = new ReversedList<string>(1)
        {
            "a1",
            "b2",
            "c3",
            "d4",
            "e5",
            "f6"
        };

        arr.RemoveAt(2);
        Console.WriteLine(arr[0]);
        Console.WriteLine(arr[1]);
        Console.WriteLine(arr[2]);
        Console.WriteLine(arr[3]);
        Console.WriteLine(arr[4]);
        Console.WriteLine(arr.Count);
        Console.WriteLine(arr.Capacity);
        foreach (var item in arr)
        {
            Console.Write(item + "---");
        }
    }
}