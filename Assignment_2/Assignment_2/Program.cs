using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Linked List \n2. Stack \n3. Queue \n4. Priority Queue \n5. N-Child Tree \n6. Hash Table");
            Console.WriteLine("Enter your choice: ");
            int exerciseChoice = Convert.ToInt16(Console.ReadLine());

            switch (exerciseChoice)
            {
                #region Linked List
                case 1:
                    Console.Clear();
                    SingleLL<int> list = new SingleLL<int>();
                    list.Insert(1);
                    list.Insert(2);
                    list.InsertAtPosition(5, 3);
                    list.InsertAtPosition(6, 5);
                    list.Insert(4);
                    list.Insert(3);
                    list.Traverse();
                    list.Delete(2);
                    list.Traverse();
                    list.DeleteAtPosition(2);
                    list.Traverse();
              
                    Console.WriteLine("Traversing through iterator");
                    IEnumerable<int> iteratedList = list.ListIterator();
                    foreach(var i in iteratedList)
                    {
                        Console.WriteLine(i);
                    }

                    list.Reverse();
                    var center = list.Center();
                    if(center != null)
                    {
                        Console.WriteLine("Center Node is {0}", center.Data);
                    } 
                    else
                    {
                        Console.WriteLine("List is empty");
                    }

                    Console.ReadLine();
                    break;
                    #endregion

                #region Stack
                case 2:
                    Console.Clear();
                    StackLL<int> st = new StackLL<int>();
                    st.Push(1);
                    st.Push(2);
                    st.Push(3);
                    st.Push(4);
                    st.Push(5);
                    st.Pop();
                    st.Traverse();
                    bool check = st.Contains(3);
                    if(check == true)
                        Console.WriteLine("Element present");
                    else
                        Console.WriteLine("Element not present");

                    st.Reverse();
                    
                    Console.WriteLine("Top element of stack is {0}", st.Peek());

                    Console.WriteLine("Traversing through iterator");
                    IEnumerable<int> iteratedStack = st.StackIterator();
                    foreach(var i in iteratedStack)
                    {
                        Console.WriteLine(i);
                    }

                    Console.ReadLine();
                    break;
                    #endregion

                #region Queue
                case 3:
                    Console.Clear();
                    QueueLL<int> q = new QueueLL<int>();
                    q.Enqueue(1);
                    q.Enqueue(2);
                    q.Enqueue(3);
                    q.Enqueue(4);
                    q.Enqueue(5);
                    q.Enqueue(6);
                    q.Traverse();
                    q.Dequeue();
                    q.Reverse();

                    Console.WriteLine("Front element of Queue is {0}", q.Peek());

                    Console.WriteLine("Traversing through Iterator");
                    IEnumerable<int> iteratedQueue = q.QueueIterator();
                    foreach(var i in iteratedQueue)
                    {
                        Console.WriteLine(i);
                    }

                    Console.ReadLine();
                    break;
                    #endregion

                #region Priority Queue
                case 4:
                    Console.Clear();
                    PriorityQueue<string> pq = new PriorityQueue<string>();

                    pq.Enqueue(1, "Niket");
                    pq.Enqueue(2, "Nikhil");
                    pq.Enqueue(3, "Uttkarsh");
                    pq.Enqueue(6, "Navneet");
                    pq.Enqueue(4, "Pawas");
                    pq.Enqueue(5, "Raghav");
                    pq.Traverse();

                    Console.WriteLine();
                    Console.WriteLine("Checking for element Nikhil");
                    Console.WriteLine($"Result is {pq.Contains("Nikhil")}");

                    Console.WriteLine();
                    Console.WriteLine($"Top element of Priority Queue is {pq.Peek()}");

                    Console.WriteLine();
                    Console.WriteLine($"Deleting element {pq.Dequeue()}");

                    Console.WriteLine();
                    Console.WriteLine("Traversing through Iterator");
                    IEnumerable<IList<string>> iteratedPQ = pq.PQIterator();
                    foreach(var items in iteratedPQ)
                    {
                        foreach(var item in items)
                        {
                            Console.Write(item);
                        }
                        Console.WriteLine();
                    }

                    Console.ReadLine();
                    break;
                    #endregion

                #region N-Child Tree
                case 5:
                    Console.Clear();

                    Console.WriteLine("Creating a tree with three children...");
                    Console.WriteLine("Inserting nodes...\n");


                    var ntree = new NTree();                        
                    ntree.AddRoot(new NTreeNodeFactory.NTreeNode(0, 3));
                    ntree.GetRoot().AddNode(new NTreeNodeFactory.NTreeNode(1, 3));
                    ntree.GetRoot().AddNode(new NTreeNodeFactory.NTreeNode(2, 3));
                    ntree.GetRoot().AddNode(new NTreeNodeFactory.NTreeNode(3, 3));
                    ntree.GetRoot().GetChild(0).AddNode(new NTreeNodeFactory.NTreeNode(11, 3));
                    ntree.GetRoot().GetChild(0).AddNode(new NTreeNodeFactory.NTreeNode(12, 3));
                    ntree.GetRoot().GetChild(0).AddNode(new NTreeNodeFactory.NTreeNode(13, 3));
                    ntree.GetRoot().GetChild(1).AddNode(new NTreeNodeFactory.NTreeNode(21, 3));
                    ntree.GetRoot().GetChild(1).AddNode(new NTreeNodeFactory.NTreeNode(22, 3));
                    ntree.GetRoot().GetChild(1).AddNode(new NTreeNodeFactory.NTreeNode(23, 3));


                    Console.WriteLine("BFS Traversal using Iterator:");
                    foreach (var elem in ntree.GetRoot().BreadthFirstSearch())
                    {
                        Console.WriteLine(elem != null ? elem.GetValue() : "NULL");
                    }


                    Console.WriteLine("\nDFS Traversal using Iterator:");
                    foreach (var elem in ntree.GetRoot().DepthFirstSearch())
                    {
                        Console.WriteLine(elem != null ? elem.GetValue() : "NULL");
                    }


                    Console.WriteLine("\nPrinting elements of tree using BFS:");
                    ntree.GetRoot().PrintBreathFirst();


                    Console.WriteLine("\nPrinting elements of tree using DFS:");
                    ntree.GetRoot().PrintDepthFirst();


                    Console.WriteLine("\nElements of level 3:");
                    foreach (var elem in ntree.GetRoot().GetElementsByLevel(3))
                        Console.WriteLine(elem != null ? elem.GetValue() : "NULL");


                    Console.WriteLine("\nElements of node by value 2:");
                    foreach (var elem in ntree.GetRoot().GetElementsByValue(2))
                        Console.WriteLine(elem != null ? elem.GetValue() : "NULL");

                    Console.WriteLine();
                    Console.WriteLine($"Does tree contain node value 1: {ntree.GetRoot().Contains(1)}");

                    Console.WriteLine("Removing first element of level 1");
                    ntree.GetRoot().RemoveNode(0);

                    Console.WriteLine($"Does tree contain node value 1: {ntree.GetRoot().Contains(1)}");            
        
                    Console.ReadLine();
                    break;
                    #endregion

                #region Hash Table
                case 6:
                    Console.Clear();

                    Console.WriteLine("Creating a Hash Table...\n");

                    HashTable<string, int> ht = new HashTable<string, int>();
                    ht.Add("Niket", 14);
                    ht.Add("Nikhil", 15);
                    ht.Add("Nidhi", 15);
                    ht.Add("Anita", 18);
                    ht.Traverse();

                    Console.WriteLine("\nChecking for Key Atul...");
                    Console.WriteLine("Result is {0}", ht.Contains("Atul"));

                    Console.WriteLine("\nGetting Value of Key Niket...");
                    Console.WriteLine($"Value of Niket is {ht.GetValueByKey("Niket")}");

                    Console.WriteLine($"\nSize of Hash Table is: {ht.Size()}");

                    Console.WriteLine("\nTraversal by iterator:");
                    IEnumerable<KeyValuePair<string, int>> iteratedHT = ht.HTIterator();
                    foreach(var i in iteratedHT)
                    {
                        Console.WriteLine($"Key: {i.Key} Value: {i.Value}");
                    }

                    Console.ReadLine();
                    break;
                    #endregion

                default:
                    Console.WriteLine("Please enter a valid choice !!!");
                    break;
            }
        }
    }
}
