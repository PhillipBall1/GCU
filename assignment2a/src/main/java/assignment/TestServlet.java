package assignment;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class TestServlet
 */
@WebServlet("/TestServlet")
public class TestServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private String firstName;
	private String lastName;
	
	@Override
	public void init() 
	{
		System.out.println("Initialize");
	}
	
	@Override
	public void destroy() 
	{
		System.out.println("Destroy");
	}
       
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public TestServlet()
    {
        super();
        // TODO Auto-generated constructor stub
    }

	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
	{
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		firstName = request.getParameter("firstName");
		lastName = request.getParameter("lastName");
		out.println("First Name:" + firstName);
		out.println("Last Name:" + lastName);

	}

	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
		doGet(request, response);
	}

}
