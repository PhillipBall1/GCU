package app;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class FilePlay
{
	
	public static void main(String[] args) throws IOException
	{
		int err = FilePlay.CopyFile("src/InUsers", "src/OutFile");
		
		switch(err) 
		{
		case 0: System.out.println("File was copied successfully."); break;
		case -1: System.out.println("File could not be opened."); break;
		case -2: System.out.println("File I/O error."); break;
		}
	}
	
	private static Integer CopyFile(String input, String output) throws IOException
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
		in.close();
		out.close();
		return 0;
	}

}
