package com.gcu.activity2;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Service;

@Service
public class AnotherOrdersBusinessService implements OrdersBusinessInterface {
    @Override
    public void test() {
        System.out.println("Hello from the AnotherOrdersBusinessService");
    }

    @Override
    public List<OrderModel> getOrders() {
        List<OrderModel> list = new ArrayList<OrderModel>();
        list.add(new OrderModel(4, "Order 4", (float) 400.0));
        list.add(new OrderModel(5, "Order 5", (float) 500.0));
        list.add(new OrderModel(6, "Order 6", (float) 600.0));
        return list;
    }
}
