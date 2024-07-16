package app;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class FilePlay
{
	
	public static void main(String[] args) throws IOException
	{
		int err = FilePlay.CopyFile("InUse", "OutUsers");
		
		switch(err) 
		{
		case 0: System.out.println("File was copied successfully."); break;
		case -1: System.out.println("File could not be opened."); break;
		case -2: System.out.println("File I/O error."); break;
		}
	}
	
	private static Integer CopyFile(String input, String output) throws IOException
	{
		FileReader in = null;
		FileWriter out = null;
		
		in = new FileReader(input);
		out = new FileWriter(output);
		
		int c; 
		while ((c = in.read()) != -1) 
		{
			out.write(c);
		}
		return 0;
	}

}
