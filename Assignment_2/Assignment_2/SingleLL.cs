using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class SingleLL<T>
    {
        public class Node
        {
            private T data;
            private Node next = null;

            // Pointer to next node
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            // Data of node
            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            // Constructor of Node Class
            public Node(T d)
            {
                data = d;
            }
        }

        private int _length;
        private Node _head;

        public int Length
        {
            get { return _length; }
        }


        public SingleLL()
        {
            _length = 0;
            _head = null;
        }

        public void Traverse()
        {
            Console.WriteLine();
            Node current = _head;
            if (current == null)
            {
                Console.WriteLine("Linked List is Empty !!!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Contents of linked list are: ");
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }

        public IEnumerable<T> ListIterator()
        {
            Node currentNode = _head;
            while(currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        public void Insert(T d)
        {
            Console.WriteLine(String.Format("Add node {0}.", d.ToString()));
            // Create a new Node instance with given data;
            Node newNode = new Node(d);
            Node currentNode = _head;
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                // Traverse till the end of the list....
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                // Add new node as the next node to the last node.
                currentNode.Next = newNode;
            }
            _length++;
        }

        public void InsertAtPosition(T d, int pos)
        {
            if (pos > this.Length + 1)
            {
                Console.WriteLine("Please enter a valid Position !!!");
                return;
            }

            Console.WriteLine("Add node {0} at position {1}", d.ToString(), pos.ToString());

            Node newNode = new Node(d);
            Node currentNode1 = _head;
            Node currentNode2 = _head.Next.Next;
            if (_head == null)
            {
                _head = newNode;
            }

            else if (pos == this.Length + 1)
            {
                while (currentNode1.Next != null)
                {
                    currentNode1 = currentNode1.Next;
                }
                currentNode1.Next = newNode;
            }

            else
            {
                int i = 0;
                while (i < pos && currentNode2.Next != null)
                {
                    currentNode1 = currentNode1.Next;
                    currentNode2 = currentNode2.Next;
                    i++;
                }
                currentNode1.Next = newNode;
                newNode.Next = currentNode2;
            }
            _length++;
        }

        public void Delete(T d)
        {
            Console.WriteLine(String.Format("Delete node {0}.", d.ToString()));
            // Find the node to be deleted. 
            Node current = _head;

            if (current != null)
            {
                // Handle the case for 'head' node when first node matches the node to be deleted.
                if (current.Data.Equals(d))
                {
                    // If first node is not the only node
                    if (current.Next != null)
                    {
                        current = current.Next;
                    }
                    else
                    {
                        current = null;
                    }
                    _head = current;
                    _length--;
                }
                else
                {
                    while (current.Next != null && current.Next.Data.ToString() != d.ToString())
                    {
                        current = current.Next;
                    }
                    if (current.Next != null && current.Next.Data.Equals(d))
                    {
                        // Set the next pointer of the previous node to be the node next to the one that is being deleted.
                        current.Next = current.Next.Next;
                        // Delete the node
                        current = null;
                        _length--;
                    }
                    else
                    {
                        Console.WriteLine(d.ToString() + " could not be found in the list.");
                    }
                }
            }

        }

        public void DeleteAtPosition(int pos)
        {
            Console.WriteLine();
            if (pos > this.Length)
            {
                Console.WriteLine("Enter a valid position!!!");
                return;
            }

            Console.WriteLine("Deleting Node at position {0}...", pos);
            Node currentNode1 = _head;

            if (pos == 1)
            {
                // Handle the case for 'head' node when first node matches the node to be deleted.
                if (_head.Next == null)
                {
                    _head = null;
                    _length--;
                    return;
                }

                currentNode1 = currentNode1.Next;
                _head = currentNode1;
            }

            else if (pos == this.Length)
            {
                while (currentNode1.Next.Next != null)
                {
                    currentNode1 = currentNode1.Next;
                }
                currentNode1.Next = null;
            }

            else
            {
                int i = 1;
                while (i < pos - 1 && currentNode1.Next != null)
                {
                    currentNode1 = currentNode1.Next;
                    i++;
                }
                Node currentNode2 = currentNode1.Next.Next;

                currentNode1.Next = currentNode2;
            }
            _length--;
        }

        public void Reverse()
        {
            Console.WriteLine();
            Node prevNode = null, currentNode = _head, nextNode = null;
            while(currentNode != null)
            {
                nextNode = currentNode.Next;
                currentNode.Next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            _head = prevNode;

            Console.WriteLine("List after Reversal");
            this.Traverse();
        }

        public Node Center()
        {
            if(_head == null || _head.Next == null)
                return _head;

            Node slowNode=_head, fastNode=_head;
            while(fastNode.Next != null)
            {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
            }

            return slowNode;
        }

    }

    public class StackLL<T>
	{
            public class StackNode
            {
                private T data;
                private StackNode next = null;

                // Pointer to next node
                public StackNode Next
                {
                    get { return next; }
                    set { next = value; }
                }

                // Data of node
                public T Data
                {
                    get { return data; }
                    set { data = value; }
                }

                // Constructor of Node Class
                public StackNode(T d)
                {
                    data = d;
                }
            }

        private int _length;
        private StackNode _top;

        public int Size
        {
            get { return _length; }
        }

        public StackLL()
        {
            _length = 0;
            this._top = null;
        }

        public void Push(T d)
        {
            StackNode newNode = new StackNode(d);
            if (_top == null)
                newNode.Next = null;

            else
                newNode.Next = _top;

            _top = newNode;
            _length++;
            Console.WriteLine("Pushed element {0} into stack", d.ToString());
        }

        public T Peek()
        {
            if (_top == null)
                return _top.Data;

            return _top.Data;
        }

        public void Pop()
        {
            if(_top == null)
            {
                Console.WriteLine("Stack underflow!!!");
                return;
            }

            Console.WriteLine("Popped {0} from stack", _top.Data.ToString());
            _top = _top.Next;
            _length--;
        }

        public bool Contains(T d)
        {
            if (_top == null)
                return false;

            StackNode newNode = _top;

            while(newNode.Next != null)
            {
                if (newNode.Data.Equals(d))
                    return true;

                newNode = newNode.Next;
            }
            return false;
        }

        public void Traverse()
        {
            Console.WriteLine();
            if(_top == null)
            {
                Console.WriteLine("Stack Underflow!!!");
                return;
            }

            Console.WriteLine("Printing Stack");
            StackNode currentNode = _top;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next;
            }
        }

        public void Reverse()
        {
            Console.WriteLine();
            StackNode prevNode = null, currentNode = _top, nextNode = null;
            while(currentNode != null)
            {
                nextNode = currentNode.Next;
                currentNode.Next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            _top = prevNode;

            Console.WriteLine("Stack after Reversal");
            this.Traverse();
        }

        public IEnumerable<T> StackIterator()
        {
            StackNode currentNode = _top;
            while(currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }
	}

    public class QueueLL<T>
    {
         public class QueueNode
         {
                private T data;
                private QueueNode next = null;

                // Pointer to next node
                public QueueNode Next
                {
                    get { return next; }
                    set { next = value; }
                }

                // Data of node
                public T Data
                {
                    get { return data; }
                    set { data = value; }
                }

                // Constructor of Node Class
                public QueueNode(T d)
                {
                    data = d;
                }
         }

        private int _length;
        private QueueNode _front;
        private QueueNode _rear;

        public int Size
        {
            get { return _length; }
        }

        public QueueLL()
        {
            _front = null;
            _rear = null;
            _length = 0;
        }

        public void Enqueue(T d)
        {
            QueueNode newNode = new QueueNode(d);
            Console.WriteLine("Pushed element {0} in Queue", d.ToString());
            if(_front == null)
            {
                _front = _rear = newNode;
                return;
            }

            _rear.Next = newNode;
            _rear = newNode;
            _length++;
        }

        public void Dequeue()
        {
            if(this.Size == 0)
            {
                Console.WriteLine("Queue is empty!!!");
                return;
            }

            if(this.Size == 1)
                _front = _rear = null;

            _front = _front.Next;
            _length--;
        }

        public T Peek()
        {
            if(this.Size == 0)
            {
                return _front.Data;
            }

            return _front.Data;
        }

        public bool Contains(T d)
        {
            if(this.Size == 0)
                return false;

            QueueNode currentNode = _front;
            while(currentNode != null)
            {
                if(currentNode.Data.Equals(d))
                    return true;

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void Reverse()
        {
            if(this.Size == 0)
            {
                Console.WriteLine("Queue is empty!!!");
                return;
            }
            Console.WriteLine();
            QueueNode prevNode = null, currentNode = _front, nextNode = null;
            while(currentNode != null)
            {
                nextNode = currentNode.Next;
                currentNode.Next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            _rear = _front;
            _front = prevNode;

            Console.WriteLine("Reversing Queue....");
            this.Traverse();
        }

        public IEnumerable<T> QueueIterator()
        {
            QueueNode currentNode = _front;
            while(currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        public void Traverse()
        {
            Console.WriteLine();
            if(this.Size == 0)
            {
                Console.WriteLine("Queue is empty!!!");
                return;
            }

            Console.WriteLine("Elements in Queue are");
            QueueNode currentNode = _front;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next;
            }
        }
    }

    public class PriorityQueue<T>
    {
        private IDictionary<int, IList<T>> elements;
        private readonly bool reversed;

        public PriorityQueue(bool reversed=false)
        {
            elements = new SortedDictionary<int, IList<T>>();
            this.reversed = reversed;
        }

        public int Count()
        {
            return elements.Count();
        }

        public bool Contains(T item)
        {
            foreach(KeyValuePair<int, IList<T>> pair in elements)
            {
                if(pair.Value.Contains(item))
                    return true;
            }
            return false;
        }

        public T Dequeue()
        {
            IList<T> topPriorityList = elements[elements.Keys.First()];
            int priority = elements.Keys.First();
            T topElement = topPriorityList.First();
            topPriorityList.Remove(topElement);
            if(topPriorityList.Count() == 0)
            {
                elements.Remove(priority);
            }
            return topElement;
        }

        public void Enqueue(int priority, T item)
        {
            Console.WriteLine($"Added item {item} at priority {priority}");
            IList<T> list;
            if(!elements.ContainsKey(priority))
                elements.Add(priority, new List<T>());

            list = elements[priority];
            list.Add(item);
        }

        public T Peek()
        {
            IList<T> topPriorityList = elements[elements.Keys.First()];
            T topElement = topPriorityList.First();
            return topElement;
        }

        public int GetHighestPriority()
        {
            return elements.Keys.First();
        }

        public void Traverse()
        {
            Console.WriteLine();
            if(this.Count() == 0)
            {
                Console.WriteLine("Priority Queue is Empty!!!");
                return;
            }

            foreach(var item in elements)
            {
                Console.Write($"{item.Key}");
                foreach(var value in item.Value)
                    Console.Write($" {value} ");
                Console.WriteLine();
            }
        }

        public IEnumerable<IList<T>> PQIterator()
        {
            foreach(var item in elements)
            {
                yield return item.Value;
            }
        }
    }

    public class NTree
    {
        public NTree() { maxChildren = int.MaxValue; }
        public NTree(int maxNumChildren) { maxChildren = maxNumChildren; }     // The root node of the tree


        protected NTreeNodeFactory.NTreeNode root = null;     // The maximum number of child nodes that a parent node may contain


        protected int maxChildren = 0;
        public void AddRoot(NTreeNodeFactory.NTreeNode node) { root = node; }
        public NTreeNodeFactory.NTreeNode GetRoot() { return (root); }
        public int MaxChildren { get { return (maxChildren); } }
    }

    public class NTreeNodeFactory
    {
        public NTreeNodeFactory(NTree root) { maxChildren = root.MaxChildren; }
        private int maxChildren = 0; public int MaxChildren { get { return (maxChildren); } }
        public NTreeNode CreateNode(IComparable value) { return (new NTreeNode(value, maxChildren)); }     // Nested Node class


        public class NTreeNode
        {
            public NTreeNode(IComparable value, int maxChildren)
            {
                if (value != null) { nodeValue = value; }
                childNodes = new NTreeNode[maxChildren];
            }


            protected IComparable nodeValue = null;
            protected NTreeNode[] childNodes = null;


            public int NumOfChildren { get { return (CountChildren()); } }
            public int CountChildren() { int currCount = 0; for (int index = 0; index <= childNodes.GetUpperBound(0); index++) { if (childNodes[index] != null) { ++currCount; currCount += childNodes[index].CountChildren(); } } return (currCount); }
            public int CountImmediateChildren() { int currCount = 0; for (int index = 0; index <= childNodes.GetUpperBound(0); index++) { if (childNodes[index] != null) { ++currCount; } } return (currCount); }
            public NTreeNode[] Children { get { return (childNodes); } }
            public NTreeNode GetChild(int index) { return (childNodes[index]); }
            public IComparable GetValue() { return (nodeValue); }
            public void AddNode(NTreeNode node) { int numOfNonNullNodes = CountImmediateChildren(); if (numOfNonNullNodes < childNodes.Length) { childNodes[numOfNonNullNodes] = node; } else { throw (new Exception("Cannot add more children to this node.")); } }


            public IEnumerable<NTreeNode> GetElementsByValue(IComparable value)
            {
                foreach (var elem in BreadthFirstSearch())
                {
                    var val = elem.GetValue();
                    if (val != null && val.CompareTo(value) == 0)
                        return elem.Children;
                }


                return null;
            }


            public IEnumerable<NTreeNode> GetElementsByLevel(int level)
            {
                if (level == 0)
                {
                    yield return this;
                    yield break;
                }


                level--;


                for (int index = 0; index < childNodes.Length; index++)
                {                    
                    if (childNodes[index] != null)
                    {
                        if (level == 0)
                            yield return childNodes[index];
                        else
                        {
                            foreach (var elem in childNodes[index].GetElementsByLevel(level - 1))
                                yield return elem;
                        }                        
                    }
                }
            }


            public bool Contains(IComparable value)
            {
                foreach (var elem in BreadthFirstSearch())
                {
                    var val = elem.GetValue();
                    if (val != null && val.CompareTo(value) == 0)
                        return true;
                }


                return false;
            }


            public IEnumerable<NTreeNode> BreadthFirstSearch()
            {
                Queue<Object> row = new Queue<Object>();
                row.Enqueue(this);
                while (row.Count > 0)
                {
                    NTreeNode currentNode = (NTreeNode)row.Dequeue();


                    yield return currentNode;
                    
                    for (int index = 0; index < currentNode.CountImmediateChildren(); index++)
                    {
                        if (currentNode.Children[index] != null)
                        {
                            row.Enqueue(currentNode.Children[index]);
                        }
                    }
                }                
            }


            public void PrintDepthFirst()
            {
                Console.WriteLine("Parent: " + nodeValue.ToString());
                for (int index = 0; index < childNodes.Length; index++)
                {
                    if (childNodes[index] != null)
                    {
                        Console.WriteLine("\tchildNodes[" + index + "]:  " + childNodes[index].nodeValue.ToString());
                    }
                    else
                    {
                        Console.WriteLine("\tchildNodes[" + index + "]:  NULL");
                    }
                }
                for (int index = 0; index < childNodes.Length; index++)
                {
                    if (childNodes[index] != null)
                    {
                        childNodes[index].PrintDepthFirst();
                    }
                }
            }


            public void PrintBreathFirst()
            {
                foreach (var elem in BreadthFirstSearch())
                {
                    Console.WriteLine(elem != null ? elem.GetValue() : "NULL");
                }
            }


            public IEnumerable<NTreeNode> DepthFirstSearch()
            {
                yield return this;
                foreach (var elem in DepthFirstSearchInternal())
                    yield return elem;                
            }


            private IEnumerable<NTreeNode> DepthFirstSearchInternal()
            {                
                for (int index = 0; index < childNodes.Length; index++)
                {
                    if (childNodes[index] != null)
                    {
                        yield return childNodes[index];
                        foreach (var elem in childNodes[index].DepthFirstSearchInternal())
                            yield return elem;
                    }
                }                
            }


            public void RemoveNode(int index)
            {


                if (index < childNodes.GetLowerBound(0) || index > childNodes.GetUpperBound(0))
                {
                    throw (new ArgumentOutOfRangeException("index", index, "Array index out of bounds."));
                }
                else if (index < childNodes.GetUpperBound(0))
                {
                    Array.Copy(childNodes, index + 1, childNodes, index, childNodes.Length - index - 1);
                }
                childNodes.SetValue(null, childNodes.GetUpperBound(0));
            }
        }
    }

    public class HashTable<TKey, TValue>
    {
        private List<TKey> keys = new List<TKey>();
        private List<TValue> values = new List<TValue>();

        public TValue GetValueByKey(TKey K)
        {
            int index = keys.IndexOf(K);
            return values[index];
        }

        public void Add(TKey K, TValue V)
        {
            keys.Add(K);
            values.Add(V);
        }

        public void Remove(TKey K)
        {
            int index = keys.IndexOf(K);
            keys.RemoveAt(index);
            values.RemoveAt(index);
        }

        public bool Contains(TKey K)
        {
            foreach(var i in keys)
            {
                if(i.Equals(K))
                    return true;
            }
            return false;
        }

        public int Size()
        {
            return values.Count();
        }

        public void Traverse()
        {
            Console.WriteLine("Contents of Hash Table are:");
            for(var i=0; i<keys.Count(); i++)
            {
                Console.WriteLine($"Key: {keys[i]} Value: {values[i]}");
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> HTIterator()
        {
            for(var i=0; i<keys.Count(); i++)
            {
                yield return (new KeyValuePair<TKey, TValue>(keys[i], values[i]));
            }
        }
    }
}