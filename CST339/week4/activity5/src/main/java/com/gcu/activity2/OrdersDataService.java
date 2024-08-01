package com.gcu.activity2;

import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Service;

@Service
public class OrdersDataService implements DataAccessInterface<OrderModel> {

    @Autowired
    private DataSource dataSource;

    private final JdbcTemplate jdbcTemplate;

    @Autowired
    public OrdersDataService(DataSource dataSource) {
        this.dataSource = dataSource;
        this.jdbcTemplate = new JdbcTemplate(dataSource);
    }

    @Override
    public List<OrderModel> findAll() {
        String sql = "SELECT * FROM ORDERS";
        List<OrderModel> orders = new ArrayList<>();
        try {
            SqlRowSet srs = jdbcTemplate.queryForRowSet(sql);
            while (srs.next()) {
                orders.add(new OrderModel(
                        srs.getInt("ORDER_NO"),
                        srs.getString("PRODUCT_NAME"),
                        srs.getDouble("PRICE")
                ));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return orders;
    }

    @Override
    public OrderModel findById(int id) {
        return null; // Not implemented
    }

    @Override
    public boolean create(OrderModel order) {
        String sql = "INSERT INTO ORDERS (ORDER_NO, PRODUCT_NAME, PRICE) VALUES (?, ?, ?)";
        try {
            int rows = jdbcTemplate.update(sql, order.getOrderId(), order.getOrderName(), order.getOrderPrice());
            return rows == 1;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }

    @Override
    public boolean update(OrderModel order) {
        return true; // Not implemented
    }

    @Override
    public boolean delete(OrderModel order) {
        return true; // Not implemented
    }
}
