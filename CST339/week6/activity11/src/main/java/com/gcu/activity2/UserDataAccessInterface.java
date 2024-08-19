package com.gcu.activity2;

public interface UserDataAccessInterface <T> {
    public T findByUsername(String username);
}
