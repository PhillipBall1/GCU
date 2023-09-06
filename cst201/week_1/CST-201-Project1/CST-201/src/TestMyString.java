

public class TestMyString 
{
    public static void main(String args[])
    {
        String main = "Phillip Ball";
        String secondaryString = "Aregory";
        MyString string = new MyString(main);
        MyString secondary = new MyString(secondaryString);

        //Test length
        System.out.println("Length: " + string.Length());
        System.out.println("ToString: " + string.toString());
        System.out.println("Concat: " + string.Concat(secondary));
        System.out.println("Equals: " + string.equals(secondary));
        System.out.println("CompareTo: " + string.compareTo(secondary));
        System.out.println("GetChar: " + string.GetChar(4));
        System.out.println("ToUpper: " + string.toUpper());
        System.out.println("ToLower: " + string.toLower());
        System.out.println("Substring Single: " + string.substring(5));
        System.out.println("Substring Both: " + string.substring(5, 10));
        System.out.println("IndexOf: " + string.indexOf(string));
        System.out.println("LastIndexOf: " + string.lastIndexOf(string));
    }
}
