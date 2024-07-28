package com.gcu.activity2;

public class OrderModel {
    private int orderId;
    private String orderName;
    private double orderPrice;

    public OrderModel(int orderId, String orderName, double orderPrice) {
        this.orderId = orderId;
        this.orderName = orderName;
        this.orderPrice = orderPrice;
    }

    public int getOrderId() {
        return orderId;
    }

    public String getOrderName() {
        return orderName;
    }

    public double getOrderPrice() {
        return orderPrice;
    }
}
