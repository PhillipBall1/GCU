package com.gcu.activity2;

import org.springframework.data.repository.CrudRepository;

public interface OrdersRepository extends CrudRepository<OrderEntity, Long> {
}
