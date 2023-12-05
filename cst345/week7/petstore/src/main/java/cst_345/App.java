package cst_345;

import org.bson.types.ObjectId;

public class App
{
    public static PetStoreDAO dao = new PetStoreDAO();
    public static int choice = -1;
    public static void main(String[] args)
    {
        dao.TestConnection();
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
                case 6: AddOnePet(); break;
                case 0: System.out.println("Good bye"); break;  
            }
        }
    }

    static void Menu()
    {
        System.out.println("Please Choose an Option! (integer values only)");
        System.out.println("1:Show all pets\n2:Show one pet\n3:Find pets by name\n4:Remove a pet\n5:Update a pet\n6:Add one pet\n0:Quit");
        choice = Integer.parseInt(System.console().readLine());
    }

    static void AddOnePet(){
        Pets p = new Pets();
        System.out.println("Input the information of the pet you want to add");
        System.out.println("-Name-");
        p.SetName(System.console().readLine());
        System.out.println("-Price-");
        p.SetPrice((int)Float.parseFloat(System.console().readLine()));
        System.out.println("-Description-");
        p.SetDescription(System.console().readLine());

        String newID = dao.AddOnePet(p);
        System.out.println("The new pet has an ID of " + newID);
    }

    
    static void DisplayAllPets()
    {
        System.out.println("==========Showing all of the pets==========");
        for(Pets pet : dao.GetAllPets() ) System.out.println(pet.toString());
    }

    static void UpdateOnePet()
    {
        System.out.println("Enter all of the pets information...(ID, Name, Price, Description, Category)\nMake sure it is split by commas");
        String[] input = System.console().readLine().split(",");
        Pets p = new Pets();
        p.SetID(new ObjectId(input[0].strip()));
        p.SetName(input[1]);
        p.SetPrice((int)Double.parseDouble(input[2].strip()));
        p.SetDescription(input[3]);        
        dao.UpdateOnePet(p);
    }

    static void FindPetsBySearch()
    {
        System.out.println("Enter the search phrase you are going to use...");
        for(Pets pet : dao.SearchForPets(System.console().readLine())) System.out.println(pet.toString());
    }

    static void RemoveOnePet()
    {
        System.out.println("Enter the ID of the pet that you would like to remove (integer values only)...");
        Pets p = new Pets();
        p.SetID(new ObjectId(System.console().readLine()));
        System.out.println(dao.DeleteOnePet(p) + " Pet Removed");
    }

    static void DisplayOnePet()
    {
        System.out.println("Enter the ID of the pet that you would like to see...");
        System.out.println(dao.GetPetByID(System.console().readLine()).toString());
    }
}



