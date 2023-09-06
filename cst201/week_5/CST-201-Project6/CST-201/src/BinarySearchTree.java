import java.util.Scanner;
import java.io.*;

public class BinarySearchTree 
{
    private String data;
    private BinarySearchTree left;
    private BinarySearchTree right;
 
    public BinarySearchTree()
    {
        this.data = null;
        this.left = null;
        this.right = null;
    }
     
    public BinarySearchTree(String data) 
    {
        this.data = data;
        this.left = null;
        this.right = null;
    }

    public static void main(String[] args) throws FileNotFoundException
    {
        File file = new File("src/words.txt");
        Scanner fileInput = new Scanner(file); 
        BinarySearchTree tree = new BinarySearchTree();
        
        while (fileInput.hasNext()) 
        {
            String word = fileInput.next();

            tree.addNode(word);
        }

        fileInput.close();

        Scanner userInput = new Scanner(System.in);

        while(true) 
        {
            System.out.println("Enter string, enter -1 to quit");
             
            String str = userInput.nextLine(); 

            if(str.compareTo("-1") == 0) break;

            tree.Search(tree, str);
        }
        
        while(true) 
        {
            System.out.println("Enter string to remove, enter -1  to quit");
             
            String str = userInput.nextLine(); 

            if(str.compareTo("-1") == 0) break;

            tree = tree.Remove(tree, str);

            tree.Print();
        }
        userInput.close();
    }
 
    public void addNode(String data) 
    {
        if (this.data == null) 
        {
            this.data = data;
        } 
        else 
        {
            if(this.data.compareTo(data) == 0) 
            {
                System.out.println("Exists");
            }
            else if (this.data.compareTo(data) < 0) 
            {  
                if (this.left != null) this.left.addNode(data);
                else this.left = new BinarySearchTree(data);
            } 
            else 
            {   
                if (this.right != null) this.right.addNode(data);
                else this.right = new BinarySearchTree(data);
            }
        }
    }

 
    public void Print() 
    {
        System.out.println(this.data);

        if (this.left != null) this.left.Print();

        if (this.right != null) this.right.Print();
    }
    
    
    public void Search(BinarySearchTree head, String str) 
    {
        int count = 0;
        while(head != null) 
        {
            count++;
            if(str.compareTo(head.data) > 0) head = head.right;
            else if(str.compareTo(head.data) < 0) head = head.left;
            else 
            {
                System.out.println("Inspected " + count + " elements");
                System.out.println("'" + str + "'" + " located");
                return;
            }
        }
        System.out.println("Inspected " + count + " elements");
        System.out.println("'" + str + "'" + " not in tree");
    } 
    
    public static String Minimum(BinarySearchTree head) 
    {
        String min = head.data;
        while(head.left != null) 
        {
            min = head.left.data;
            head = head.left;
        }
        return min;
    }
    
    public BinarySearchTree Remove(BinarySearchTree head, String str) 
    {
        if(head==null) return null;
            
        if(str.compareTo(head.data) < 0) head.left = Remove(head.left, str);
        else if(str.compareTo(head.data) > 0) head.right = Remove(head.right, str);    
        else 
        {
            if(head.left == null) return head.right;
            else if(head.right == null) return head.left;
                
            head.data = Minimum(head.right);
            head.right = Remove(head.right, head.data);
        }
        return head;
    }
}