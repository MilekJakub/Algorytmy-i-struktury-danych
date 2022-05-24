using lab_10_task;
using System;
using System.Collections.Generic;

namespace lab10
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }
    class BinaryTree<T>
    {
        public Node<T> Root { get; set; }
        public void PreorderTraversal(Action<Node<T>> action)
        {
            Preorder(Root, action);
        }
        private void Preorder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }
            action.Invoke(node);
            Preorder(node.Left, action);
            Preorder(node.Right, action);
        }
        public void InOrderTraversal(Action<Node<T>> action)
        {
            InOrder(Root, action);
        }

        private void InOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.Left, action);
            action.Invoke(node);
            InOrder(node.Right, action);
        }

        public void PostOrderTraversal(Action<Node<T>> action)
        {
            PostOrder(Root, action);
        }

        private void PostOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.Left, action);
            PostOrder(node.Right, action);
            action.Invoke(node);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Node<string> node = new Node<string>() { Value = "+" };

            //node.Left = new Node<string>() { Value = "*" };
            //node.Right = new Node<string>() { Value = "3" };

            //node.Left.Left = new Node<string>() { Value = "7" };
            //node.Left.Right = new Node<string>() { Value = "9" };

            //BinaryTree<string> tree = new BinaryTree<string>() { Root = node };

            //tree.InOrderTraversal(n => Console.Write(n.Value));
            //Console.WriteLine();

            //tree.PostOrderTraversal(n => Console.Write(n.Value));
            //Console.WriteLine();

            //tree.PreorderTraversal(n => Console.Write(n.Value));
            //Console.WriteLine();

            App.AppMain();
        }
    }
}