package com.gcu.service;

import java.util.List;
import java.util.stream.Collectors;

import org.springframework.stereotype.Service;

import com.gcu.data.OrdersRepository;
import com.gcu.entity.OrderEntity;
import com.gcu.model.OrderModel;

@Service
public class OrdersBusinessService {

    private final OrdersRepository service;

    public OrdersBusinessService(OrdersRepository service) {
        this.service = service;
    }

    public List<OrderModel> getAllOrders() {
        List<OrderEntity> entities = service.findAll();
        return entities.stream()
                .map(entity -> new OrderModel(entity.getId(), entity.getOrderNo(), entity.getProductName(),
                        entity.getPrice(), entity.getQuantity()))
                .collect(Collectors.toList());
    }
}
