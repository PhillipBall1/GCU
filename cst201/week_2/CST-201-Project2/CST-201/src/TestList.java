import java.util.Random;

public class TestList 
{
    public static void main(String args[])
    {
        
        //Create lists
        SinglyLinkedList listOne = CreateList(11, 50);
        SinglyLinkedList listTwo = CreateList(7, 50);

        //Sort lists
        listOne.Sort();
        listTwo.Sort();

        //List size
        System.out.println("List One Size: " + listOne.Size());

        //Lists display
        listOne.DisplayList(listOne.head, ": Linked List 1 :");
        listOne.DisplayList(listTwo.head, ": Linked List 2 :");

        //Removed front
        System.out.println("\n\nFront:  [" + listOne.Front().data + "]");
        listOne.RemoveAtFront();
        listOne.DisplayList(listOne.head, ": Removed Front :");

        //Removed back
        System.out.println("\n\nBack:   [" + listOne.Back().data + "]");
        listOne.RemoveAtBack();
        listOne.DisplayList(listOne.head, ": Removed Back :");

        //Empty check
        System.out.println("\n\nEmpty: " + listOne.Empty());

        //Reversed list
        listOne.Reverse();
        listOne.DisplayList(listOne.head, ": Reversed :");
        System.out.print("\n");

        //Sort after reversal
        listOne.Sort();
        listTwo.Sort();

        //Merge lists
        listOne.DisplayList(listOne.Merge(listOne.head, listTwo.head), ": Merged :");
    }


    public static SinglyLinkedList CreateList(int size, int max)
    {
        SinglyLinkedList list = new SinglyLinkedList();
        for(int i = 0; i < size; i++)
        {
            Random rand = new Random();
            int r = rand.nextInt(max);
            list.InsertData(r);
        }
        return list;
    }
}
