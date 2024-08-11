package com.gcu.activity2;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/service")
public class OrderController {

    @Autowired
    private OrdersBusinessInterface service;

    @GetMapping("/getjson")
    public List<OrderModel> getOrders() {
        return service.getOrders();
    }

    @GetMapping(value = "/getxml", produces = "application/xml")
    public List<OrderModel> getOrdersXml() {
        return service.getOrders();
    }

    @GetMapping("/getorder/{id}")
    public ResponseEntity<OrderModel> getOrder(@PathVariable String id) {
        try {
            OrderModel order = service.getOrderById(id);
            if (order == null) {
                return new ResponseEntity<>(HttpStatus.NOT_FOUND);
            }
            return new ResponseEntity<>(order, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
}
