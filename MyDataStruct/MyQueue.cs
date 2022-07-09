using System;

/// <summary>
/// 循环队列
/// </summary>
/// <typeparam name="T"></typeparam>
public class MyQueue<T>
{

    private T[] elements;
    private int front = 0;
    private int rear = 0;
    public MyQueue(int capacity)
    {
        elements = new T[capacity];

    }

    public bool IsFull
    {
        get
        {
            return (rear + 1) % elements.Length == front;
        }

    }

    public int Count
    {
        get
        {
            return (rear - front + elements.Length)%elements.Length;
        }
    }

    public T Peek()
    {
        return elements[front];
    }

    public void Enqueue(T t)
    {
        if(IsFull) return;
        elements[rear] = t;
        rear = (rear + 1)%elements.Length;

    }

    public T Dequeue()
    {
        if(Count == 0) throw new IndexOutOfRangeException();
        T ret = elements[front];
        front = (front + 1)%elements.Length;
        return ret;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    

    

}
