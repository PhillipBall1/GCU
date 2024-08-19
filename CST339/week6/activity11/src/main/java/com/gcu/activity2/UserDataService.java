package com.gcu.activity2;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserDataService implements UserDataAccessInterface<UserEntity> {

    private final UserRepository usersRepository;

    @Autowired
    public UserDataService(UserRepository usersRepository) {
        this.usersRepository = usersRepository;
    }

    @Override
    public UserEntity findByUsername(String username) {
        return usersRepository.findByUsername(username);
    }
}
