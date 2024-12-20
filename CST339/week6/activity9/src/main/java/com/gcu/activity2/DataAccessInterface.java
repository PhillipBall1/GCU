package com.gcu.activity2;

import java.util.List;

public interface DataAccessInterface<T> {
    List<T> findAll();
    T findById(String id);
    boolean create(T t);
    boolean update(T t);
    boolean delete(T t);
}
