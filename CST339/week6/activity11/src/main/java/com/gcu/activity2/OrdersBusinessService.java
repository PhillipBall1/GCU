package com.gcu.activity2;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Service;

@Service("ordersBusinessService")
public class OrdersBusinessService implements OrdersBusinessInterface {

    private final OrderDataService orderDataService;

    public OrdersBusinessService(OrderDataService orderDataService) {
        this.orderDataService = orderDataService;
    }


    @Override
    public List<OrderModel> getOrders() {
        List<OrderModel> ordersDomain = new ArrayList<>();
        try {
            List<OrderEntity> ordersEntity = orderDataService.findAll();
            for (OrderEntity order : ordersEntity) {
                ordersDomain.add(new OrderModel(order.getId(), order.getOrderNo(), order.getProductName(), order.getPrice(), order.getQuantity()));
            }
        } catch (Exception e) {
        }
        return ordersDomain;
    }

    @Override
    public OrderModel getOrderById(String id) {
        OrderEntity entity = orderDataService.findById(id);
        if (entity != null) {
            return new OrderModel(entity.getId(), entity.getOrderNo(), entity.getProductName(), entity.getPrice(), entity.getQuantity());
        }
        return null;
    }
}
