package com.gcu;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.gcu.activity2.AnotherOrdersBusinessService;
import com.gcu.activity2.OrdersBusinessInterface;
import com.gcu.activity2.OrdersBusinessService;

@Configuration
public class SpringConfig {

    @Bean(name = "ordersBusinessService")
    public OrdersBusinessInterface getOrdersBusiness() {
        return new OrdersBusinessService();
    }



    @Bean(name = "anotherOrdersBusinessService")
    public OrdersBusinessInterface getAnotherOrdersBusinessService() {
        return new AnotherOrdersBusinessService();
    }
}
