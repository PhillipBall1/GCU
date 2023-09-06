import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class RecursiveStrings 
{
    public static void main(String[] args) throws FileNotFoundException 
    {
        File file = new File("String.in");
        Scanner in = new Scanner(file);

        int n = in.nextInt();

        ArrayList<String> list = new ArrayList<String>();

        for(int i = 0; i < n; i++)
        {
            list.add(in.next());
        }
        
        System.out.println(":Slops Output:");
        for(int i = 0; i < n; i++)
        {
            if(!isSlop(list.get(i)))
            {
                System.out.println("No");
            }
            else
            {
                System.out.println("Yes");
            }
        }
        System.out.println(":End of Output:");
        in.close();
    }


    public static boolean isSlip(String str)
    {
        if(str.length() <= 2) return false;

        if(str.charAt(0) != 'D' && str.charAt(0) != 'E') return false;

        if(str.charAt(1) != 'F') return false;

        int cnt = 1;

        while(cnt < str.length() && str.charAt(cnt)=='F')
        {
            cnt += 1;
        }

        if(cnt == str.length()) return false;

        if((str.length() == cnt + 1 && str.charAt(cnt) == 'G') || isSlip(str.substring(cnt))) return true;

        return false;
    }

    public static boolean isSlap(String str)
    {
        if(str.length() == 2) if(str.charAt(0) == 'A' && str.charAt(1) == 'H') return true;

        if(str.length() <= 4) return false;

        if(str.charAt(0) != 'A') return false;

        if((str.charAt(1) == 'B' && isSlap(str.substring(2, str.length() - 1)) && (str.charAt(str.length() - 1) == 'C'))) return true;

        if(isSlip(str.substring(1, str.length() - 1)) && str.charAt(str.length() - 1) == 'C') return true;

        return false;
    }

    public static boolean isSlop(String str)
    {
        if(str.length() < 5) return false;
        
        if(isSlap(str.substring(0,2)) && isSlip(str.substring(2))) return true;

        int lastIDX = str.lastIndexOf('C');

        if(lastIDX == -1) return false;
        
        if(isSlap(str.substring(0,lastIDX+1)) && isSlip(str.substring(lastIDX+1))) return true;

        return false;
    }   
}