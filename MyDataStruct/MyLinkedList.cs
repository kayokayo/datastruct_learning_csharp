using System;


public class Node
{
    public string data;
    public Node next;
}
public class MyLinkedList
{
    public Node head;
    /// <summary>
    /// 注意node.next = head这句代码，过几天再看的时候总觉得node.next = null应该是这样
    /// 其实假设有下面的场景insert(0,"数据1") insert(0,"数据2")，第一次insert的时候 head就不是null了
    /// 所以应该是node.next = head
    /// </summary>
    /// <param name="index"></param>
    /// <param name="data"></param>
    public void insert(int index, string data)
    {
        if (index < 0) throw new IndexOutOfRangeException();
        //头部插入
        Node node;
        if (index == 0)
        {
            node = new Node();
            node.data = data;
            node.next = head;
            head = node;
            return;
        }

        //中部或者尾部插入（中、尾部的插入逻辑其实一样的）
        int count = 0;
        for (node = head; node != null; node = node.next)
        {
            if (count == index - 1)
            {
                Node newNode = new Node();
                newNode.data = data;
                newNode.next = node.next;
                node.next = newNode;
                return;
            }
            count++;

        }
        //抛出异常
        throw new IndexOutOfRangeException();

    }

    public void Delete(int index)
    {
        if (index < 0) throw new IndexOutOfRangeException();
        if (head == null) throw new IndexOutOfRangeException();
        int count = 0;
        if (index == 0)
        {
            head = head.next;
            return;
        }
        //注意，这里判断的是node.next != null，和insert的不一样
        for (Node node = head; node.next != null; node = node.next)
        {
            if (count == index - 1)
            {
                node.next = node.next.next;
                return;
            }
            count++;
        }
        throw new IndexOutOfRangeException();
    }

    /// <summary>
    /// 查找数据对应的节点，并返回该节点
    /// </summary>
    /// <param name="data"></param>
    /// <returns>没找到就返回null</returns>
    public Node Find(string data)
    {
        for (Node node = head; node != null; node = node.next)
        {
            if (node.data == data) return node;
        }
        return null;
    }
}

class Test1
{
    // static void Main(string[] args)
    // {
    //     MyLinkedList ll = new MyLinkedList();
    //     // ll.insert(0,"小皮");
    //     // ll.insert(0,"小皮妈");
    //     // ll.insert(0,"小皮爸");
    //     // ll.insert(1,"小皮爸1");
    //     // ll.insert(4,"小皮爸4");
    //     // ll.insert(6,"小皮爸6");
    //     // ll.Delete(0);
    //     for(Node node = ll.head;node != null;node = node.next)
    //     {
    //         Console.WriteLine(node.data);
    //     }

    //     Console.WriteLine(ll.Find("小皮"));
    // }

}
