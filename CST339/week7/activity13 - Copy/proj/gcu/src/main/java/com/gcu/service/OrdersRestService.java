package com.gcu.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.gcu.model.OrderModel;

@RestController
@RequestMapping("/service")
public class OrdersRestService {

    @Autowired
    private OrdersBusinessService service;

    @GetMapping("/orders")
    public ResponseEntity<List<OrderModel>> getOrders() {
        try {
            List<OrderModel> orders = service.getAllOrders();
            return new ResponseEntity<>(orders, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
}
