import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

import org.w3c.dom.Node;
/***provided file for DLinkedList Assignment**@author lkfritz*/
public class DLinkedList<T extends Comparable<T>> 
{
    public static void main(String[] args) throws FileNotFoundException 
    {
        DLinkedList<String> lst1 = new DLinkedList<>();
        DLinkedList<String> lst2 = new DLinkedList<>();
        Scanner fin = new Scanner(new File("text1.in"));
        String str;
        while (fin.hasNext()) 
        {
            str = fin.next();
            str = cleanUp(str);
            lst1.insertOrderUnique(str);
        }
        fin.close();
        fin = new Scanner(new File("text2.in"));
        while (fin.hasNext()) 
        {
            str = fin.next();
            str = cleanUp(str);
            lst2.insertOrderUnique(str);
        }
        System.out.println("List 1:  " + lst1);
        System.out.println("List 2:  " + lst2);
        DLinkedList<String> combined = lst1.merge(lst2);
        System.out.println("\nAFTER MERGE");
        System.out.println("List 1:  " + lst1);
        System.out.println("List 2:  " + lst2);
        System.out.println("\n" + combined);
        lst1.remove("baby");
        System.out.println("\nList 1:  " + lst1);
    }
    /***ASSIGNED*@param str*@return str in all lower case with LEADING and TRAILING non-alpha*chars removed*/
    public static String cleanUp(String str) 
    {
        str = str.toLowerCase();
        str = str.replaceAll("[^A-Za-z0-9]", "");
        return str;
    }
    //inner DNode class:  

    private class DNode 
    {
        private DNode next, prev;
        private T data;
        private DNode(T val) 
        {
            this.data = val;
            next = prev = this;
        }
    }
    //DLinkedList fields:  PROVIDED
    private DNode header;
    //create an empty list:  PROVIDED
    public DLinkedList() 
    {
        header = new DNode(null);
    }
    /***PROVIDED 
     * add**@param item return ref to newly inserted node
     */
    public DNode add(T item) 
    {
        //make a new node
        DNode newNode = new DNode(item);
        //update newNode
        newNode.prev = header;
        newNode.next = header.next;
        //update surrounding nodes
        header.next.prev = newNode;
        header.next = newNode;
        return newNode;
    }
    //PROVIDED
    public String toString() 
    {
        String str = "[";
        DNode curr = header.next;
        while (curr != header) 
        {
            if(curr.next.data == null) 
            {
                str += curr.data + " ";
            }
            else
            {
                str += curr.data + ", ";
            }
            curr = curr.next;
        }
        str = str.substring(0, str.length() - 1);
        return str + "]";
    }

    /**
     * Assigned
     * remove val from list
     * @param val
     * @param lst
     * @return true if successful, false otherwise
     */
    public boolean remove(T val) 
    {
        DNode curr = this.header.next;
        DNode prev = header;
        //O(N)
        while(curr != header)
        {
            if(val.equals(curr.data))
            {
                prev.next = curr.next;
                return true;
            }
            prev = curr;
            curr = curr.next;
        }
        return false;
    }

    public void insertOrder(T item) 
    {
        //O(1)
        this.add(item);

        //O(N) if sorted, else O(N^2)
        if(this.Length() > 1) Sort(this);
    }

    public boolean insertOrderUnique(T item) 
    {
        //O(N)
        if(this.contains(item)) return false;

        //O(1)
        this.add(item);

        //O(N) if sorted, else O(N^2)
        if(this.Length() > 1) Sort(this);

        return true;
    }

    public boolean contains(T item)
    {
        DNode curr = header.next;

        while (curr.data != null) 
        {
            if(curr.data.equals(item))
            {
                return true;
            }
            curr = curr.next;
        }
        return false;
    }

    public int Length()
    {
        DNode curr = header.next;
        int cnt = 0;
        
        while (curr.data != null) 
        {
            cnt++;
            curr = curr.next;
        }
        return cnt;
    }

    public void Sort(DLinkedList<T> lst)
    {
        DNode curr = lst.header.next;
        DNode next = null;
        T holder = null;

        while(curr.data != null)
        {
            next = curr.next;
            while(next.data != null)
            {
                if(curr.data.compareTo(next.data) > 0)
                {
                    holder = curr.data;
                    curr.data = next.data;
                    next.data = holder;
                }
                
                next = next.next;
            }
            curr = curr.next;
        }
    }

    /***ASSIGNED
    * PRE:  this and rhs are sorted lists
    *@param rhs*@return list that contains this and rhs merged into a sorted list
    *POST:  returned list will not contain duplicates*/
    public DLinkedList<T> merge(DLinkedList<T> rhs) 
    {
        DLinkedList<T> finalList = new DLinkedList<T>();

        DNode main = this.header.next;
        DNode other = rhs.header.next;
        
        while(main.data != null)
        {
            if(!finalList.contains(main.data))
            {
                finalList.add(main.data);
            }
            main = main.next;
        }
        
        while(other.data != null)
        {
            if(!finalList.contains(other.data))
            {
                finalList.add(other.data);
            }
            other = other.next;
        }
        //O(N^2)
        Sort(finalList);
        return finalList;
    }
}