// src/main/java/com/gcu/controller/LoginController.java
package com.gcu.activity2;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class LoginController {

    @Autowired
    @Qualifier("ordersBusinessService")
    private OrdersBusinessInterface service;

    @Autowired
    private SecurityBusinessService security;

    @GetMapping("/login")
    public String showLogin(Model model) {
        return "login";
    }

    @PostMapping("/login")
    public String doLogin(Model model) {
        security.authenticate("username", "password");
        List<OrderModel> orders = service.getOrders();
        if (orders != null) {
            System.out.println("Orders fetched: " + orders.size());
        } else {
            System.out.println("No orders fetched.");
        }
        model.addAttribute("orders", orders);
        return "orders";
    }
}
