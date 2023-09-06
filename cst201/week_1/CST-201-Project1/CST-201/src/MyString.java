

public class MyString 
{
    private char[] charArr;
    private int currLength;

    public MyString()
    {
        charArr = null;
        currLength = 0;
    }
    public MyString(String f)
    {
        charArr = new char[f.length()];
        char[] g = f.toCharArray();
        for(int i = 0; i < f.length(); i++)
        {
            charArr[i] = g[i];
        }
        currLength = f.length();
    }
    public MyString(MyString string)
    {
        this.charArr = string.charArr;
        this.currLength = string.currLength;
    }

    public int Length(){return currLength;}

    public String toString()
    {
        String holder = "";
        for(int i = 0; i < this.charArr.length; i++)
        {
            holder+=this.charArr[i];
        }
        return holder;
    }

    public MyString Concat(MyString string)
    {
        String holder1 = "";
        for(int i = 0; i < this.charArr.length; i++)
        {
            holder1+=this.charArr[i];
        }
        String holder2 = "";
        for(int i = 0; i < string.charArr.length; i++)
        {
            holder2+=string.charArr[i];
        }
        String concatString = holder1 + holder2;
        return new MyString(concatString);
    }

    public boolean equals(MyString string)
    {
        int min = Math.min(this.charArr.length, string.charArr.length);
        int cnt = 0;
        for(int i = 0; i < min; i++)
        {
            if(this.charArr[i] != string.charArr[i])
            {
                cnt++;
            }
        }

        if(cnt == 0)
        {
            return true;
        }
        return false;
    }

    public int compareTo(MyString string)
    {
        if(string.equals(this))
        {
            return 0;
        }

        int min = Math.min(this.charArr.length, string.charArr.length);
        
        for(int i =0; i < min; i++)
        {
            char thisChar = this.charArr[i];
            char otherChar = string.charArr[i];
            if(thisChar != otherChar) return thisChar - otherChar;
        }
        return this.charArr.length - string.charArr.length;
    }

    public char GetChar(int idx)
    {
        if(idx < 0) return ' ';

        for(int i = 0; i < this.charArr.length; i++)
        {
            if(i == idx) return this.charArr[i];
        }
        return ' ';
    }

    public MyString toUpper()
    {
        char[] newArr = new char[this.charArr.length];
        for(int i = 0; i < this.charArr.length; i++)
        {
            newArr[i] += Character.toUpperCase(this.charArr[i]);
        }
        this.charArr = newArr;
        return this;
    }

    public MyString toLower()
    {
        char[] newArr = new char[this.charArr.length];
        for(int i = 0; i < this.charArr.length; i++){
            newArr[i] += Character.toLowerCase(this.charArr[i]);
        }
        this.charArr = newArr;
        return this;
    }

    public String substring(int idx)
    {
        String holder = "";
        for(int i = 0; i < this.charArr.length; i++)
        {
            if(i >= idx) holder += this.charArr[i];
        }
        return holder;
    }
    public String substring(int idx1, int idx2)
    {
        String holder = "";
        for(int i = 0; i < this.charArr.length; i++)
        {
            if(i >= idx1 && i < idx2) holder += this.charArr[i];
        }
        return holder;
    }

    public char indexOf(MyString string){return string.charArr[0];}

    public char lastIndexOf(MyString string){return string.charArr[string.charArr.length - 1];}
    
}
