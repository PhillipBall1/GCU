package com.gcu.model;

import java.math.BigDecimal;

public class OrderModel {
    private String id;
    private String orderNo;
    private String productName;
    private BigDecimal price;
    private int quantity;

    // Default constructor
    public OrderModel() {
        this.id = "";
        this.orderNo = "";
        this.productName = "";
        this.price = BigDecimal.ZERO;
        this.quantity = 0;
    }

    // Non-default constructor
    public OrderModel(String id, String orderNo, String productName, BigDecimal price, int quantity) {
        this.id = id;
        this.orderNo = orderNo;
        this.productName = productName;
        this.price = price;
        this.quantity = quantity;
    }

    // Getters and Setters
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getOrderNo() {
        return orderNo;
    }

    public void setOrderNo(String orderNo) {
        this.orderNo = orderNo;
    }

    public String getProductName() {
        return productName;
    }

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }
}
