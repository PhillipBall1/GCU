package cst345;

import java.sql.*;
import java.util.ArrayList;

public class PetStoreDAO 
{
    static final String DATABASE_URL = "jdbc:mysql://localhost/cst345";
    static final String USERNAME = "root";
    static final String PASSWORD = "root";

    public ArrayList<Pets> GetAllPets()
    {
        ArrayList<Pets> returnThese = new ArrayList<>();

        try
        {
            Connection con = DriverManager.getConnection(DATABASE_URL, USERNAME, PASSWORD);
            Statement stat = con.createStatement();
            ResultSet resultSet = stat.executeQuery("SELECT * FROM pets");

            while(resultSet.next())
            {
                Pets p = new Pets();
                p.SetID(resultSet.getInt("id"));                
                p.SetName(resultSet.getString("Name"));
                p.SetPrice(resultSet.getInt("Price"));
                p.SetDescription(resultSet.getString("Description"));
                p.SetCategory(resultSet.getInt("pet_categories_id"));
                returnThese.add(p);
            }
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return returnThese;
    }

    public Pets GetPetByID(int id)
    {
        Pets returnThese = new Pets();

        try
        {
            Connection con = DriverManager.getConnection(DATABASE_URL, USERNAME, PASSWORD);
            Statement stat = con.createStatement();
            ResultSet resultSet = stat.executeQuery("SELECT * FROM pets WHERE id = " + id);

            while(resultSet.next())
            {
                Pets p = new Pets();
                p.SetID(resultSet.getInt("id"));                
                p.SetName(resultSet.getString("Name"));
                p.SetPrice(resultSet.getInt("Price"));
                p.SetDescription(resultSet.getString("Description"));
                p.SetCategory(resultSet.getInt("pet_categories_id"));
                returnThese = p;
            }
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return returnThese;
    }

    public ArrayList<Pets> GetPetsBySearch(String search)
    {
        ArrayList<Pets> returnThese = new ArrayList<>();

        try
        {
            Connection con = DriverManager.getConnection(DATABASE_URL, USERNAME, PASSWORD);
            String sqlString = "SELECT * FROM pets WHERE Name LIKE ?";
            PreparedStatement prep = con.prepareStatement(sqlString);
            prep.setString(1, "%" + search + "%");

            ResultSet resultSet = prep.executeQuery();

            while(resultSet.next())
            {
                Pets p = new Pets();
                p.SetID(resultSet.getInt("id"));                
                p.SetName(resultSet.getString("Name"));
                p.SetPrice(resultSet.getInt("Price"));
                p.SetDescription(resultSet.getString("Description"));
                p.SetCategory(resultSet.getInt("pet_categories_id"));
                returnThese.add(p);
            }
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return returnThese;
    }

    public int AddOnePet(Pets newPet){
        try
        {
            Connection con = DriverManager.getConnection(DATABASE_URL, USERNAME, PASSWORD);
            con.createStatement();
            String sqlString = "INSERT INTO pets (id, Name, Price, Description, pet_categories_id) VALUES (?,?,?,?,?)";
            PreparedStatement prep = con.prepareStatement(sqlString);
            prep.setInt(1, newPet.GetID()); 
            prep.setString(2, newPet.GetName());
            prep.setInt(3, newPet.GetPrice());
            prep.setString(4, newPet.GetDescription());
            prep.setInt(5, newPet.GetCategory());

            int updates = prep.executeUpdate();
            return updates;
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return 0;
    }

    public int UpdateOnePet(Pets newPet){
        try
        {
            Connection con = DriverManager.getConnection(DATABASE_URL, USERNAME, PASSWORD);
            con.createStatement();
            String sqlString = "UPDATE pets SET Name = ?, Price = ?, Description = ?, pet_categories_id = ? WHERE id = ?";
            PreparedStatement prep = con.prepareStatement(sqlString);
            prep.setString(1, newPet.GetName());
            prep.setInt(2, newPet.GetPrice());
            prep.setString(3, newPet.GetDescription());
            prep.setInt(4, newPet.GetCategory());
            prep.setInt(5, newPet.GetID()); 

            int updates = prep.executeUpdate();
            return updates;
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return 0;
    }

    public int DeleteOnePet(int id){
        try
        {
            Connection con = DriverManager.getConnection(DATABASE_URL, USERNAME, PASSWORD);
            con.createStatement();
            String sqlString = "DELETE FROM pets WHERE id = " + id;
            PreparedStatement prep = con.prepareStatement(sqlString);

            int updates = prep.executeUpdate();
            return updates;
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return 0;
    }
}
