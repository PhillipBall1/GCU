package com.gcu.activity2;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/service")
public class OrdersRestService {

    @Autowired
    @Qualifier("ordersBusinessService")
    private OrdersBusinessService service;

    @GetMapping(path = "/getjson", produces = MediaType.APPLICATION_JSON_VALUE)
    public List<OrderModel> getOrdersAsJson() {
        return service.getOrders();
    }

    @GetMapping(path = "/getxml", produces = MediaType.APPLICATION_XML_VALUE)
    public OrderList getOrdersAsXml() {
        OrderList orderList = new OrderList();
        orderList.setOrders(service.getOrders());
        return orderList;
    }
}
