package com.gcu.activity2;

import java.util.List;

public interface OrdersBusinessInterface {
    List<OrderModel> getOrders();
    public OrderModel getOrderById(String id);
    
}
