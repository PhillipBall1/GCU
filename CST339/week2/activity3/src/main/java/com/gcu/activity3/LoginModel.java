package com.gcu.activity3;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

public class LoginModel {

    @NotNull(message="Username is a required field!")
    @Size(min=2, max=32, message="Username must be between 2 - 32 characters")
    private String username;

    @NotNull(message="Password is a required field!")
    @Size(min=2, max=32, message="Password must be between 2 - 32 characters")
    private String password;

    public String getUsername() { return username; }
    public void setUsername(String username) { this.username = username; }

    public String getPassword() { return password; }
    public void setPassword(String password) { this.password = password; }
}
