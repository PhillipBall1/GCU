package com.gcu.activity2;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
@RequestMapping("/orders")
public class OrderController {

    @Autowired
    private OrdersBusinessInterface service;

    @GetMapping("/display")
    public String displayOrders(Model model) {
        List<OrderModel> orders = service.getOrders();
        System.err.println("Orders: " + orders.size());
        
        model.addAttribute("orders", orders);
        return "orders";
    }

    @GetMapping("/getJSON")
    @ResponseBody
    public List<OrderModel> getOrders() {
        return service.getOrders();
    }

    @GetMapping(value = "/getXML", produces = "application/xml")
    @ResponseBody
    public List<OrderModel> getOrdersXml() {
        return service.getOrders();
    }

    @GetMapping("/getorder/{id}")
    @ResponseBody
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
