import java.io.*;
import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Scanner;


class Project0
{
    static String words = "";
    public static void main(String args[])
    {
        //Get words from file
        GenerateWordsFromFile();

        //Generate array of words
        String[] strArr = words.split(" ");

        //Unsorted print
        System.out.println("Unsorted: ");
        for(int i = 0; i < strArr.length; i++)
        {
            System.out.println(" " + strArr[i]);
        }

        //Sort
        Arrays.sort(strArr);

        //Sorted print
        System.out.println("Sorted: ");
        for(int i = 0; i < strArr.length; i++)
        {
            System.out.println(" " + strArr[i]);
        }

        //Create scanner obj
        Scanner scanner = new Scanner(System.in);

        //Holder variables from user input
        String input = "";
        int hold =0;

        //Loop that allows user to keep searching
        while(hold == 0)
        {
            //Get user input
            System.out.println("\nEnter a word to search for... or 0 to quit\n");
            input = scanner.next();

            //If input is 0 break out of the loop
            if(input.equals("0"))
            {
                hold = 1;
                break;
            }

            //Index holder
            int idx = -1;

            //Loop through array to find if any word is equal to input
            for(int i = 0; i < strArr.length; i++)
            {
                if(input.equals(strArr[i])){
                    idx = i;
                    break;
                }
            }

            //Word was found so idx would be greater than or equal to 0
            if(idx != -1){
                System.out.println("\n" + input + " is inside of this list at the " + idx + " index\n");
            }

            //Word was not found so idx did not change
            if(idx == -1){
                System.out.println("\n" + input + " is not in this list\n");
            }
        }

        //Close scanner and print goodbye
        scanner.close();
        System.out.println("Goodbye!");
    }

    //Gets the words from the text.txt file and sets it to the words variable
    public static void GenerateWordsFromFile()
    {
        try 
        {
            //Get file
            File file = new File("text.txt");
            //Reader obj
            Scanner reader = new Scanner(file);
            //Read file
            while (reader.hasNextLine()) 
            {
                //Set file to variable
                words = reader.nextLine();
            }
            //Close reader
            reader.close();
        } 
        catch (FileNotFoundException e) 
        {
            //File not found
            System.out.println("File not found");
            e.printStackTrace();
        }
    }
}