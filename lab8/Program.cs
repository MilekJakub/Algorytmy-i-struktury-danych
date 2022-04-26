using System;
using System.Collections;
using System.Collections.Generic;

namespace lab8
{ 
    record Student(string Name, int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 4, 7, 1, 6, 8, 1, 9, 2 };
            Array.Sort(arr);
            int index = Array.BinarySearch(arr, 9);
            Console.WriteLine("indeks: " + index);

            var students = new Student[]
            {
                new Student("Ewa", 34),
                new Student("Karol", 44),
                new Student("Adam", 3),
                new Student("Robert", 74),
                new Student("Ola", 38),
            };

            Array.Sort(students, (a, b) =>
            {
                return a.Ects.CompareTo(b.Ects);
            });

            var result = Array.BinarySearch(students, new Student("Ewa", 34), new StudentComparer());
            Console.WriteLine("BinarySearch(Student( \"Ewa\", 34 ))");
            Console.WriteLine("Index:" + result);
            Console.WriteLine($"students[{result}]: {students[result]}");

            TreeNode<int> Root = new TreeNode<int>() { Value = 16 };

            Root.Left = new TreeNode<int>() { Value = 8 };
            Root.Right = new TreeNode<int>() { Value = 20 };

            Root.Left.Left = new TreeNode<int>() { Value = 5 };
            Root.Left.Right = new TreeNode<int>() { Value = 11 };

            Root.Right.Left = new TreeNode<int>() { Value = 18 };
            Root.Right.Right = new TreeNode<int>() { Value = 23 };

            BST<int> bst = new BST<int>() { Root = Root };

            Console.WriteLine(bst.Contains(18));
            Console.WriteLine(bst.Contains(23));

            Console.WriteLine();

            Console.WriteLine($"Insert: {bst.InsertNode(17)}");
            Console.WriteLine($"Contains: {bst.Contains(17)}");

            Console.WriteLine();

            Console.WriteLine($"Insert: {bst.InsertNode(23)}");
            Console.WriteLine($"Contains: {bst.Contains(23)}");
        }
    }
    class StudentComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Student a = (Student) x;
            Student b = (Student) y;

            return a.Ects.CompareTo(b.Ects);
        }
    }

    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }

    class BST<T> where T: IComparable<T>
    {
        public TreeNode<T> Root { get; set; }

        public bool Contains(T value)
        {
            return Search(Root, value);
        }

        private bool Search(TreeNode<T> node, T value)
        {
            if (node == null)
                return false;

            var compare = value.CompareTo(node.Value);

            if (compare == 0)
                return true;

            if (compare < 0)
                return Search(node.Left, value);

            if (compare > 0)
                return Search(node.Right, value);

            else
                return false;
        }

        public bool InsertNode(T value)
        {
            return InsertNode(Root, value);
        }

        private bool InsertNode(TreeNode<T> Root, T value)
        {
            if (Root == null)
            {
                Root = new TreeNode<T> { Value = value };
                return true;
            }

            var compare = value.CompareTo(Root.Value);

            if (compare == 0)
                return false;

            if (compare < 0 && Root.Left != null)
                return InsertNode(Root.Left, value);

            if (compare > 0 && Root.Right != null)
                return InsertNode(Root.Right, value);

            if (compare < 0 && Root.Left == null)
            {
                Root.Left = new TreeNode<T> { Value = value };
                return true;
            }

            if (compare > 0 && Root.Right == null)
            {
                Root.Right = new TreeNode<T> { Value = value };
                return true;
            }

            else
                return false;
        }
    }
}
