public class SinglyLinkedList 
{
    public class Node
    {
        int data;
        Node link;

        public Node(int data)
        {
            this.data = data;
            this.link = null;
        }
    }

    Node head = null;
    Node tail = null;

    public void InsertData(int val)
    {
        Node node = new Node(val);

        if(head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.link = node;
            tail = node;
        }
    }

    public void Sort()
    {
        Node curr = head;
        Node next = null;
        int holder = 0;

        while(curr != null)
        {
            next = curr.link;
            while(next != null)
            {
                if(curr.data > next.data)
                {
                    holder = curr.data;
                    curr.data = next.data;
                    next.data = holder;
                    
                }
                next = next.link;
            }
            curr = curr.link;
        }

    }

    public Node Front(){return head;}

    public Node Back(){return tail;}

    public int Size()
    {
        Node curr = null;
        if(head != null) curr = head;
        int cnt = 0;
        while(curr != null)
        {
            cnt++;
            curr = curr.link;
        }
        return cnt;
    }

    public void RemoveAtFront()
    {
        Node curr = head.link;
        head = null;
        while(curr != null)
        {
            InsertData(curr.data);
            curr = curr.link;
        }
    }

    public void RemoveAtBack()
    {
        Node curr = head;
        head = null;
        while(curr.link != null)
        {
            InsertData(curr.data);
            curr = curr.link;
        }
    }

    public boolean Empty()
    {
        if(head == null) return true;

        return false;
    }

    public void Reverse()
    {
        Node holder = head;
        Node last = null;
        Node curr = null;
        while(holder != null)
        {
            curr = holder;
            holder = holder.link;
            curr.link = last;
            last = curr;
            head = curr;
        }
    }

    public Node Merge(Node main, Node other)
    {
        Node result = new Node(0);

        Node holder = result;

        while(true)
        {
            if(main == null)
            {
                holder.link = other;
                break;
            }

            if(other == null)
            {
                holder.link = main;
                break;
            }

            if(main.data <= other.data)
            {
                holder.link = main;
                main = main.link;
            }
            else
            {
                holder.link = other;
                other = other.link;
            }
            holder = holder.link;
        }
        return result.link;

    }

    public void DisplayList(Node main, String message)
    {
        Node curr = null;
        if(main != null) curr = main;
        System.out.println("\n" + message);
        while(curr != null)
        {
            System.out.print("[" + curr.data + "]");
            curr = curr.link;
        }
    }
}
