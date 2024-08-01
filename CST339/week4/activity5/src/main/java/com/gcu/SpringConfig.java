package com.gcu;

import javax.sql.DataSource;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.gcu.activity2.DataAccessInterface;
import com.gcu.activity2.OrderModel;
import com.gcu.activity2.OrdersBusinessInterface;
import com.gcu.activity2.OrdersBusinessService;
import com.gcu.activity2.OrdersDataService;

@Configuration
public class SpringConfig {

    @Bean
    public DataAccessInterface<OrderModel> getOrdersDataService(DataSource dataSource) {
        return new OrdersDataService(dataSource);
    }

    @Bean
    public OrdersBusinessInterface getOrdersBusinessService(DataAccessInterface<OrderModel> dataService) {
        return (OrdersBusinessInterface) new OrdersBusinessService(dataService);
    }
}
