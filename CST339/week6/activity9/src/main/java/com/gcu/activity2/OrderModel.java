package com.gcu.activity2;

public class OrderModel {

    private String id;
    private String orderNo;
    private String productName;
    private float price;
    private int quantity;

    // Default constructor
    public OrderModel() {}

    // Non-default constructor
    public OrderModel(String id, String orderNo, String productName, float price, int quantity) {
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

    public float getPrice() {
        return price;
    }

    public void setPrice(float price) {
        this.price = price;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    @Override
    public String toString() {
        return "OrderModel{" +
               "id=" + id +
               ", orderNo='" + orderNo + '\'' +
               ", productName='" + productName + '\'' +
               ", price=" + price +
               ", quantity=" + quantity +
               '}';
    }
}