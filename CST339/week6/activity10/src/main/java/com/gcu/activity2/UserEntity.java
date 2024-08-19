package com.gcu.activity2;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.index.Indexed;
import org.springframework.data.mongodb.core.mapping.Document;

@Document(collection="users")
public class UserEntity {

    @Id
    String id;
    @Indexed(unique=true)
    String username;
    String password;

    public String getUsername() { return username;}

    public String getPassword() { return password;}
    
}
