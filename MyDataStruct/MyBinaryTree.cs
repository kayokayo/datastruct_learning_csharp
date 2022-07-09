using System.Diagnostics;
using System.Collections.Generic;
using System;


public class BNode<T>
{
    public T data;
    public BNode<T> leftChild;
    public BNode<T> rightChild;

}

public class MyBinaryTree<T>
{

    private BNode<T> root;

    public BNode<T> CreateRoot(T data)
    {
        root = new BNode<T>();
        root.data = data;
        return root;
    }

    public BNode<T> insertLeftChild(BNode<T> current, T data)
    {
        if (current.leftChild != null) return current.leftChild;
        current.leftChild = new BNode<T>();
        current.leftChild.data = data;
        return current.leftChild;
    }

    public BNode<T> insertRightChild(BNode<T> current, T data)
    {
        if (current.rightChild != null) return current.rightChild;
        current.rightChild = new BNode<T>();
        current.rightChild.data = data;
        return current.rightChild;
    }
    /// <summary>
    /// 先序
    /// </summary>
    /// <param name="current"></param>
    public void PreOrderTraversal(BNode<T> current)
    {
        if (current == null) return;
        Console.WriteLine(current.data);//用打印来表示对根节点的访问
        PreOrderTraversal(current.leftChild);
        PreOrderTraversal(current.rightChild);
    }
    /// <summary>
    /// 中序
    /// </summary>
    /// <param name="current"></param>
    public void MidOrderTraversal(BNode<T> current)
    {
        if (current == null) return;
        MidOrderTraversal(current.leftChild);
        Console.WriteLine(current.data);//用打印来表示对根节点的访问
        MidOrderTraversal(current.rightChild);
    }
    /// <summary>
    /// 后序
    /// </summary>
    /// <param name="current"></param>
    public void PostOrderTraversal(BNode<T> current)
    {
        if (current == null) return;
        PostOrderTraversal(current.leftChild);
        PostOrderTraversal(current.rightChild);
        Console.WriteLine(current.data);//用打印来表示对根节点的访问
    }
    /// <summary>
    /// 层序遍历
    /// </summary>
    /// <param name="current"></param>
    public void LayerOrderTraversal(BNode<T> current)
    {
        if(current == null) return;
        MyQueue<BNode<T>> queue = new MyQueue<BNode<T>>(10);//这个可以取大点，最好等于数的所有节点数+1
        queue.Enqueue(current);
        while(!queue.IsEmpty())
        {
            BNode<T> node = queue.Peek();
            Console.WriteLine(node.data);
            queue.Dequeue();
            if(node.leftChild != null) queue.Enqueue(node.leftChild);
            if(node.rightChild != null) queue.Enqueue(node.rightChild);
        }
    }



    public static void Test()
    {
        MyBinaryTree<string> tree = new MyBinaryTree<string>();
        BNode<string> root = tree.CreateRoot("A");

        BNode<string> b = tree.insertLeftChild(root, "B");
        BNode<string> c = tree.insertRightChild(root, "C");

        BNode<string> d = tree.insertLeftChild(b, "D");
        BNode<string> e = tree.insertLeftChild(c, "E");
        BNode<string> f = tree.insertRightChild(c, "F");

        BNode<string> g = tree.insertLeftChild(d, "G");
        BNode<string> h = tree.insertRightChild(d, "H");
        BNode<string> i = tree.insertRightChild(e, "I");

        tree.LayerOrderTraversal(root);
        Console.WriteLine("---------------");
        tree.PreOrderTraversal(root);
        Console.WriteLine("---------------");
        tree.MidOrderTraversal(root);
        Console.WriteLine("---------------");
        tree.PostOrderTraversal(root);

    }


}
