package com.gcu;

import com.gcu.model.OrderModel;
import com.gcu.model.UserModel;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.client.RestTemplate;

import java.util.Arrays;
import java.util.List;

@Controller
@RequestMapping("/app")
public class TestController {

    @GetMapping("/")
    public String home(Model model) {
        return "home";
    }

    @GetMapping("/getusers")
    public String getUsers(Model model) {
        RestTemplate restTemplate = new RestTemplate();
        List<UserModel> users = Arrays.asList(restTemplate.getForObject("http://localhost:8080/service/users", UserModel[].class));
        model.addAttribute("users", users);
        return "users";
    }

    @GetMapping("/getorders")
    public String getOrders(Model model) {
        RestTemplate restTemplate = new RestTemplate();
        List<OrderModel> orders = Arrays.asList(restTemplate.getForObject("http://localhost:8080/service/orders", OrderModel[].class));
        model.addAttribute("orders", orders);
        return "orders";
    }
}
