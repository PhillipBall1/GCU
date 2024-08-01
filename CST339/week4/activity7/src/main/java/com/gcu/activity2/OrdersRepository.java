package com.gcu.activity2;

import java.util.List;

import org.springframework.data.jdbc.repository.query.Query;
import org.springframework.data.repository.CrudRepository;

public interface OrdersRepository extends CrudRepository<OrderEntity, Long> {

    @Query(value = "SELECT * FROM ORDERS")
    List<OrderEntity> findAll();
}
