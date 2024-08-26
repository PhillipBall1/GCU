package com.gcu.data;

import org.springframework.data.mongodb.repository.MongoRepository;
import com.gcu.entity.UserEntity;

public interface UsersRepository extends MongoRepository<UserEntity, String> {
}
