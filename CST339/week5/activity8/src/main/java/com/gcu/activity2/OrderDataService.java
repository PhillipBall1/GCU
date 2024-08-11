package com.gcu.activity2;

import java.util.List;

import org.springframework.stereotype.Service;

@Service
public class OrderDataService implements DataAccessInterface<OrderEntity> {

    private final OrderRepository orderRepository;

    public OrderDataService(OrderRepository orderRepository) {
        this.orderRepository = orderRepository;
    }

    @Override
    public List<OrderEntity> findAll() {
        return orderRepository.findAll();
    }

    @Override
    public OrderEntity findById(String id) {
        return orderRepository.findById(String.valueOf(id)).orElse(null); 
    }

    @Override
    public boolean create(OrderEntity entity) {
        try {
            orderRepository.save(entity);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    @Override
    public boolean update(OrderEntity entity) {
        return create(entity); 
    }

    @Override
    public boolean delete(OrderEntity entity) {
        try {
            orderRepository.deleteById(entity.getId()); 
            return true;
        } catch (Exception e) {
            return false;
        }
    }
}
