package com.gcu.service;

import java.util.List;
import java.util.stream.Collectors;

import org.springframework.stereotype.Service;

import com.gcu.data.UsersRepository;
import com.gcu.entity.UserEntity;
import com.gcu.model.UserModel;

@Service
public class UserBusinessService {

    private final UsersRepository service;

    public UserBusinessService(UsersRepository service) {
        this.service = service;
    }

    public List<UserModel> getAllUsers() {
        List<UserEntity> entities = service.findAll();
        return entities.stream()
                .map(entity -> new UserModel(entity.getId(), entity.getUsername(), entity.getPassword()))
                .collect(Collectors.toList());
    }
}
