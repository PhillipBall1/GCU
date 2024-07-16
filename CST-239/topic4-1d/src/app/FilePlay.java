package app;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class FilePlay
{
	
	public static void main(String[] args) throws IOException
	{
		try
		{
			FilePlay.CopyFile("src/InUsers", "src/OutFile");
			System.out.println("File was successfully copied.");
		}
		catch (FileNotFoundException e)
		{
			e.printStackTrace();
			System.out.println("File could not be opened.");
		}
		catch (IOException e)
		{
			e.printStackTrace();
			System.out.println("File I/O error.");
		}

	}
	
	private static void CopyFile(String input, String output) throws IOException
	{
		BufferedReader in = null;
		BufferedWriter out = null;
		
		in = new BufferedReader(new FileReader(input));
		out = new BufferedWriter(new FileWriter(output));

		String line;
		while ((line = in.readLine()) != null) 
		{
			String[] tokens = line.split("\\|");
			out.write(String.format("Name is %s %s of age %s \n", tokens[0], tokens[1], tokens[2]));
		}
		try
		{
			if(in != null)
				in.close();
			if(out != null)
				out.close();
		} catch (IOException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
