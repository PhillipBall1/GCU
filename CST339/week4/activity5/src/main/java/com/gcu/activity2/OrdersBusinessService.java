package com.gcu.activity2;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class OrdersBusinessService implements OrdersBusinessInterface {

    private final DataAccessInterface<OrderModel> service;

    @Autowired
    public OrdersBusinessService(DataAccessInterface<OrderModel> service) {
        this.service = service;
    }

    @Override
    public void test() {
        // Implement test logic if needed
    }

    @Override
    public List<OrderModel> getOrders() {
        return service.findAll();
    }

    @Override
    public void init() {
        // Initialization logic if needed
    }

    @Override
    public void destroy() {
        // Destruction logic if needed
    }
}
