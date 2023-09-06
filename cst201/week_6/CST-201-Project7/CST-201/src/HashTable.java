import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class HashTable 
{
    public static void main(String[] args) throws FileNotFoundException {
		
		Scanner sc = new Scanner(new File("src/words.txt"));
		Implementation hashtable = new Implementation(10);
		
		while(sc.hasNext())
        {
			String s = sc.nextLine();
			hashtable.Insert(s);			
		}
		
		hashtable.DisplayTable();
	}
}

class Node
{
    String data;
    Node next;

    public Node(String d,Node n)
    {
        data=d;
        next=n;
    }

    public String Display(){return data;}
}

class ChainList
{
    private Node head = null;

	public void Insert(String d) 
    {
		Node current = head;

		if (head == null) 
        {
			head = new Node(d, null);
		}
        else 
        {
			while (current.next != null) 
            {
				current = current.next;
			}
			current.next = new Node(d, null);
		}
	}

	public void Find(String k) 
    {
		Node current = head;

		int count = 0;

		boolean found = false;

		while (current != null) 
        {
			count++;
			if (current.data.equals(k)) 
            {
				found = true;
				break;
			}
			current = current.next;
		}

		System.out.println("Inspected " + count + " elements");

		if (found) System.out.println(" and found the element " + k);
		else System.out.println(" and does not found the element " + k);
	}

	public String DisplayList() 
    {
		Node current = head;

		if(current != null)
        {
            String output = current.Display();

            while (current != null) 
            {
			    current = current.next;
			    if(current != null) output = output + " --> " + current.Display();
		    }
		    return output;
		}
		return null;
	}

	public int Size() 
    {
		int size = 0;

		Node current = head;

		while (current != null) 
        {
			size++;
			current = current.next;
		}
		return size;
	}
}

class Implementation
{
	private ChainList[] hashArray;

	public Implementation(int size) 
    {
		hashArray = new ChainList[size];

		for(int j=0; j<hashArray.length; j++)
        {
            hashArray[j] = new ChainList();
        }      
	}

	public Implementation() 
    {
		hashArray = new ChainList[5];
	}

	public int HashFunction(String key) 
    {
		int hashValue = 0;

		for (int i = 0; i < key.length(); i++) 
        {
            hashValue = hashValue+key.charAt(i);
		}

		return hashValue % hashArray.length;
	}

	public void Insert(String key) 
    {
		int hashVal = HashFunction(key);   
	    hashArray[hashVal].Insert(key);
	}

	public void Find(String k) 
    {
		int hashVal = HashFunction(k);
		hashArray[hashVal].Find(k);
	}

	public void DisplayTable() 
    {
		for (int j = 0; j < hashArray.length; j++)
        {
            if(hashArray[j]!=null) System.out.println(hashArray[j].DisplayList());
        }	
	}
}
