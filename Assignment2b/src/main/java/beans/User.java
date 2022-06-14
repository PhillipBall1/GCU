package beans;

import javax.faces.bean.ManagedBean;
@ManagedBean(name="user")
public class User
{
	private String name = "Phillipo";
	private String lastName;
	
	public String GetFirstName() {return name;}

	public String GetLastName() {return lastName;}
	
	public void SetFirstName(String newFirstName) {this.name = newFirstName;}
	
	public void SetLastName(String newLastName) {this.lastName = newLastName;}
}
