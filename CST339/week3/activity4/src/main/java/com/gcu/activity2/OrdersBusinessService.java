package com.gcu.activity2;

import java.util.ArrayList;
import java.util.List;

import org.springframework.context.annotation.Primary;
import org.springframework.stereotype.Service;

@Service
@Primary
public class OrdersBusinessService implements OrdersBusinessInterface {
    @Override
    public void init() {
        System.out.println("OrdersBusinessService: init() called");
    }

    @Override
    public void destroy() {
        System.out.println("OrdersBusinessService: destroy() called");
    }
    @Override
    public void test() {
        System.out.println("Hello from the OrdersBusinessService");
    }

    @Override
    public List<OrderModel> getOrders() {
        List<OrderModel> list = new ArrayList<OrderModel>();
        list.add(new OrderModel(1, "Order 1", (float) 100.0));
        list.add(new OrderModel(2, "Order 2", (float) 200.0));
        list.add(new OrderModel(3, "Order 3", (float) 300.0));
        return list;
    }
}
