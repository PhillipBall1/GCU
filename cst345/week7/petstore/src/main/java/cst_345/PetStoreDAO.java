package cst_345;

import com.mongodb.ConnectionString;
import com.mongodb.MongoClientSettings;
import com.mongodb.MongoException;
import com.mongodb.ServerApi;
import com.mongodb.ServerApiVersion;
import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoClients;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Filters;
import com.mongodb.client.result.DeleteResult;
import com.mongodb.client.result.InsertOneResult;

import java.util.ArrayList;
import java.util.List;

import org.bson.Document;
import org.bson.conversions.Bson;
import org.bson.types.ObjectId;

public class PetStoreDAO {

    String connectionString = "mongodb+srv://MyAtlasDBUser:MyAtlas-001@cluster0.rdbbu6f.mongodb.net/?retryWrites=true&w=majority";
    ServerApi serverApi = ServerApi.builder().version(ServerApiVersion.V1).build();
    MongoClientSettings settings = MongoClientSettings.builder().applyConnectionString(new ConnectionString(connectionString)).serverApi(serverApi).build();
    MongoClient mongoClient = MongoClients.create(settings);
    MongoDatabase database = mongoClient.getDatabase("Pets");

    MongoCollection<Document> collection = database.getCollection("petscollection");

    public void TestConnection(){
        System.out.println("Using the database " + database.getName());        
        System.out.println("Using the collection " + collection.getNamespace());
    }

    public String AddOnePet(Pets newPet){
        Document document = new Document();
        document.put("Name", newPet.GetName());        
        document.put("Price", newPet.GetPrice());
        document.put("Description", newPet.GetDescription());
        InsertOneResult result = collection.insertOne(document);

        return result.getInsertedId().toString();
    }

    public List<Pets> GetAllPets(){
        List<Pets> pets = new ArrayList<Pets>();

        FindIterable<Document> found = collection.find();

        for(Document document : found){
            Pets p = new Pets();
            p.SetID(document.getObjectId("_id"));
            p.SetName(document.getString("Name"));
            p.SetPrice(document.getInteger("Price"));
            p.SetDescription(document.getString("Description"));

            pets.add(p);
        }

        return pets;
    }

    public Pets UpdateOnePet(Pets p){

        Document update = new Document();
        update.put("Name", p.GetName());        
        update.put("Price", p.GetPrice());
        update.put("Description", p.GetDescription());

        Bson filter = Filters.eq("_id", p.GetID());

        Document newDocument = collection.findOneAndReplace(filter, update);

        Pets updatedPet = new Pets();

        try{
            updatedPet.SetID(newDocument.getObjectId("_id"));
            updatedPet.SetName(newDocument.getString("Name"));            
            updatedPet.SetPrice(newDocument.getInteger("Price"));
            updatedPet.SetDescription(newDocument.getString("Description"));
        }
        catch(Exception e){
            System.out.println(e.getMessage());
        }
        return updatedPet;
    }

    public ArrayList<Pets> SearchForPets(String term){
        ArrayList<Pets> pets = new ArrayList<Pets>();

        String regexString = ".*" + term + ".*";

        Bson filter = Filters.regex("Name", regexString);
        FindIterable<Document> found = collection.find(filter);

        for(Document document : found){
            Pets p = new Pets();
            p.SetID(document.getObjectId("_id"));
            p.SetName(document.getString("Name"));
            p.SetPrice(document.getInteger("Price"));
            p.SetDescription(document.getString("Description"));

            pets.add(p);
        }

        return pets;
    }

    public long DeleteOnePet(Pets p){
        Bson filter = Filters.eq("_id", p.GetID());
        DeleteResult result = collection.deleteOne(filter);
        return result.getDeletedCount();
    }

    public Pets GetPetByID(String ID){
        Bson filter = Filters.eq("_id", new ObjectId(ID));
        FindIterable<Document> foundItems = collection.find(filter);
        Document foundFirst = foundItems.first();
        Pets p = new Pets();

        try{
            p.SetID(foundFirst.getObjectId("_id"));            
            p.SetName(foundFirst.getString("Name"));
            p.SetPrice(foundFirst.getInteger("Price"));
            p.SetDescription(foundFirst.getString("Description"));
        }
        catch(Exception e){
            System.out.println(e.getMessage());
        }

        return p;
    }
}

