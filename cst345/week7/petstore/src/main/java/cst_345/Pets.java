package cst_345;

import org.bson.types.ObjectId;

public class Pets {
    private ObjectId ID;    
    private String name;
    private int price;
    private String description;

    @Override
    public String toString(){
        return "Pet [ID=" + ID + ", Name=" + name + ", Price=" + price + 
        ", Description=" + description + "]";
    }

    //Get
    public ObjectId GetID(){ return ID; }    
    public String GetName(){ return name; }
    public int GetPrice(){ return price; }
    public String GetDescription(){ return description; }

    //Set
    public void SetID(ObjectId ID){ this.ID = ID; }
    public void SetName(String name){ this.name = name; }
    public void SetPrice(int price){ this.price = price; }
    public void SetDescription(String description){ this.description = description; }
}
