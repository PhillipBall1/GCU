package com.gcu.activity2;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class OrderDataService implements DataAccessInterface<OrderEntity> {

    private final OrdersRepository ordersRepository;

    @Autowired
    public OrderDataService(OrdersRepository ordersRepository) {
        this.ordersRepository = ordersRepository;
    }

    @Override
    public List<OrderEntity> findAll() {
        return (List<OrderEntity>) ordersRepository.findAll();
    }

    @Override
    public OrderEntity findById(int id) {
        return ordersRepository.findById((long) id).orElse(null);
    }

    @Override
    public boolean create(OrderEntity entity) {
        try {
            ordersRepository.save(entity);
            return true;
        } catch (Exception e) {
            e.printStackTrace();
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
            ordersRepository.delete(entity);
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }
}
