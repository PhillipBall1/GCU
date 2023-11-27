package cst345;

public class Pets {
    private int ID;    
    private String name;
    private int price;
    private String description;
    private int category;

    @Override
    public String toString(){
        return "Pet [ID=" + ID + ", Name=" + name + ", Price=" + price + 
        ", Description=" + description + ", Category=" + category + "]";
    }

    //Get
    public int GetID(){ return ID; }    
    public String GetName(){ return name; }
    public int GetPrice(){ return price; }
    public String GetDescription(){ return description; }
    public int GetCategory(){ return category; }

    //Set
    public void SetID(int ID){ this.ID = ID; }
    public void SetName(String name){ this.name = name; }
    public void SetPrice(int price){ this.price = price; }
    public void SetDescription(String description){ this.description = description; }
    public void SetCategory(int category){ this.category = category; }

}
