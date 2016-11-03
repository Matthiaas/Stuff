using System;


namespace TaschenRechner.Functions
{
    class RechnerList
    {
        private Node last, first = new Node("-1");
        public int Count { get; private set; }
        public void AddLast(string value)
        {
            Count++;
            if (last == null)
            {
                first.next = new Node(value);
                last = first.next;
            }
            else
            {
                last.next = new Node(value);
                last = last.next;
            }
        }
        public void AddFirst(string value)
        {
            Count++;
            Node x = first.next;
            first.next = new Node(value);
            first.next.next = x;
        }
        public void deleteAt(int index)
        {
            Count--;
            Node curr = first.next;
            Node drag = first;
            for(int i = 0; i < index; i++)
            {
                drag = curr;
                curr = curr.next;
            }
            drag.next = curr.next;
        }
        public string ElementAt(int index)
        {
            Node curr = first.next;
            for (int i = 0; i < index; i++)
            {
                curr = curr.next;
            }
            return curr.value;
        }
        public void InsertAt(int index, string value)
        {
            Count++;
            Node curr = first.next;
            Node drag = first;
            for (int i = 0; i < index; i++)
            {
                drag = curr;
                curr = curr.next;
            }
            drag.next = new Node(value, curr);
        }


        private class Node
        {
            public Node next = null;
            public String value;

            public Node(string value)
            {
                this.value = value;
            }

            public Node(string v , Node n)
            {
                value = v;
                next = n;
            }

        }
    }
}
