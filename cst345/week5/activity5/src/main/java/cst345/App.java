package cst345;

import java.util.ArrayList;

public class App
{
    public static PetStoreDAO dao = new PetStoreDAO();
    public static int choice = -1;
    public static void main(String[] args)
    {
        System.out.println("Welcome to the pet shop");
        while(choice != 0)
        {
            Menu();
            switch(choice)
            {
                case 1: DisplayAllPets(); break;
                case 2: DisplayOnePet(); break;
                case 3: FindPetsBySearch(); break;
                case 4: RemoveOnePet(); break;
                case 5: UpdateOnePet(); break;
                case 0: System.out.println("Good bye"); break;  
            }
        }
    }

    static void Menu()
    {
        System.out.println("Please Choose an Option! (integer values only)");
        System.out.println("1:Show all pets\n2:Show one pet\n3:Find pets by name\n4:Remove a pet\n5:Update a pet\n0:Quit");
        choice = Integer.parseInt(System.console().readLine());
    }

    static void DisplayAllPets()
    {
        System.out.println("==========Showing all of the pets==========");
        for(Pets pet : dao.GetAllPets() ) System.out.println(pet.toString());
    }

    static void DisplayOnePet()
    {
        System.out.println("Enter the ID of the pet that you would like to see (integer values only)...");
        int petId = Integer.parseInt(System.console().readLine());
        System.out.println(dao.GetPetByID(petId).toString());
    }

    static void FindPetsBySearch()
    {
        System.out.println("Enter the search phrase you are going to use...");
        for(Pets pet : dao.GetPetsBySearch(System.console().readLine()) ) System.out.println(pet.toString());
    }

    static void RemoveOnePet()
    {
        System.out.println("Enter the ID of the pet that you would like to remove (integer values only)...");
        int deleteID = Integer.parseInt(System.console().readLine());
        System.out.println(dao.DeleteOnePet(deleteID) + " Pet Removed");
    }

    static void UpdateOnePet()
    {
        System.out.println("Enter all of the pets information...(ID, Name, Price, Description, Category)\nMake sure it is split by commas");
        String[] input = System.console().readLine().split(",");
        Pets p = new Pets();
        p.SetID(Integer.parseInt(input[0].strip()));
        p.SetName(input[1]);
        p.SetPrice((int)Double.parseDouble(input[2].strip()));
        p.SetDescription(input[3]);        
        p.SetCategory(Integer.parseInt(input[4].strip()));
        dao.UpdateOnePet(p);
    }
}



