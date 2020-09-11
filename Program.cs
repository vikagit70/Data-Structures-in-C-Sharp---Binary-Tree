using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Node
    {
        public Node left, right;
        public string data;
        public void DisplayNode()
        {
            Console.Write(data + " ");
        }

        public Node(string i)
        {
            data = i;
            left = null;
            right = null;
        }
    }

    public class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }

        public Node Insert(Node root, string i)
        {
            bool find = Contains(i, root);
            if (find == true)
            {
                Console.Write(i+" already exists.");
                return root;
            }
            else
            {
                Node newNode = new Node(i);

                if (root == null)
                {
                   return newNode;
                }
                else
                {
                    int convertedI = StringToNumber(i);
                    int convertedData = StringToNumber(root.data);

                    if (convertedI <= convertedData)
                    {
                            root.left = Insert(root.left, i);
                    }
                    if(convertedI > convertedData)
                    {
                            root.right = Insert(root.right,i);
                    }
                    return root;
                }
            }
        }
        public void Insert(string i)
        {
            root = Insert(root, i);
        }

        
        public bool Contains(string i, Node current)
        {
            int convertedI = StringToNumber(i);
            if (current == null)
            {
                return false;
            }
            else
            {
                int convertedData = StringToNumber(current.data);

                if (i == current.data)
                {
                    return true;
                }
                else if (convertedI < convertedData)
                {
                    if (current.left == null)
                    {
                        return false;
                    }
                    else
                    {
                        current = current.left;
                        return Contains(i, current);
                    }
                }
                else
                {
                    if (current.right == null)
                    {
                        return false;
                    }
                    else
                    {
                        current = current.right;
                        return Contains(i, current);
                    }
                }
            }
        }
        public bool Contains(string i)
        {
            return Contains(i, root);
        }

        public void Inorder(Node root)
        {
            if (root == null) { return; }
            else
            {
                Inorder(root.left);
                Console.Write(root.data + " ");
                Inorder(root.right);
            }
        }
        public void Display()
        {
            if (root == null) { Console.Write("Empty tree"); }
            else { Inorder(root); }
        }

        public int StringToNumber(string str)
        {
            if (str == null)
            {
                return 0;
            }
            else
            {
                int count = 0;
                int sum = 0;
                foreach (char character in str)
                {
                    var convert = Char.ConvertToUtf32(str, count);
                    sum = sum + convert;
                }
                return sum;
            }
        }

        public Node Delete (Node root, string str)
        {
            var str1 = StringToNumber(str);
            var data = StringToNumber(root.data);
                if (root.data == null) return root;
                else if (data < str1)
                    root.right = Delete(root.right, str);
                else if (data > str1)
                    root.left = Delete(root.left, str);
                else
                {
                    if (root.left == null)
                        return root.right;
                    if (root.right == null)
                        return root.left;

                Node min = findmin(root.right);
                root.data = min.data;
                root.right = Delete(root.right, min.data);

            }
            return root;
        }
        private Node findmin(Node root)
        {
            while (root != null && root.left != null)
                root = root.left;
            return root;
        }

        static void Main(string[] args)
        {
            Tree strs = new Tree();
            strs.Insert("vika");
            strs.Insert("maxim");
            strs.Insert("anton");
            strs.Insert("lisa");
            strs.Insert("melissa");
            strs.Insert("lisa");
            strs.Insert("musa");
            Console.WriteLine();
            strs.Display();
            strs.Delete(strs.root,"vika");

            Console.WriteLine();
            strs.Display();
            Console.WriteLine();
            Console.WriteLine("Type a name to check if name exists: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("Answer: "+strs.Contains(userInput));

            Console.WriteLine("The End");
        }

    }
}


