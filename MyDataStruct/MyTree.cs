using System;


public class Node<T>
{
    public T data;
    public Node<T> sibling;//右兄弟
    public Node<T> child;//左孩子
}

public class MyTree<T>
{

    private Node<T> root ;

    public Node<T> CreateRoot(T data)
    {
        root = new Node<T>();
        root.data = data;
        return root;
    }

    public Node<T> InserSibling(Node<T> current,T siblingData)
    {
        if(current.sibling != null) return current.sibling;
        current.sibling = new Node<T>{data = siblingData};
        return  current.sibling;
    }
    public Node<T> InserChild(Node<T> current,T childData)
    {
        if(current.child != null) return current.child;
        current.child = new Node<T>{data = childData};
        return  current.child;
    }

/// <summary>
/// 广度优先（先遍历兄弟）
/// </summary>
    public void TraversalSiblingFirst(Node<T> current)
    {
        Console.WriteLine(current.data);
        if(current.sibling != null)
        {
            TraversalSiblingFirst(current.sibling);
        }
        if(current.child != null)
        {
            TraversalSiblingFirst(current.child);
        }
    }
    /// <summary>
    /// 深度优先
    /// </summary>
    /// <param name="current"></param>
    public void TraversalChildFirst(Node<T> current)
    {
        Console.WriteLine(current.data);
        if(current.child != null)
        {
            TraversalChildFirst(current.child);
        }
        if(current.sibling != null)
        {
            TraversalChildFirst(current.sibling);
        }
    }


}
