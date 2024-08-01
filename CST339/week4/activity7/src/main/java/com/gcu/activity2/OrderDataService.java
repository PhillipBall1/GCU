package com.gcu.activity2;

import java.util.List;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Service;

@Service
public class OrderDataService implements DataAccessInterface<OrderEntity> {

    private final OrdersRepository ordersRepository;
    private final JdbcTemplate jdbcTemplateObject;

    @Autowired
    public OrderDataService(OrdersRepository ordersRepository, DataSource dataSource) {
        this.ordersRepository = ordersRepository;
        this.jdbcTemplateObject = new JdbcTemplate(dataSource);
    }

    @Override
    public List<OrderEntity> findAll() {
        // Use JdbcTemplate to execute custom SQL query
        String sql = "SELECT * FROM ORDERS";
        return jdbcTemplateObject.query(sql, (rs, rowNum) -> {
            OrderEntity order = new OrderEntity();
            order.setId(rs.getLong("id"));
            order.setOrderNo(rs.getString("order_no"));
            order.setProductName(rs.getString("product_name"));
            order.setPrice((float) rs.getDouble("price"));
            order.setQuantity(rs.getInt("quantity"));
            return order;
        });
    }

    @Override
    public OrderEntity findById(int id) {
        // Use JdbcTemplate to query by ID
        String sql = "SELECT * FROM ORDERS WHERE id = ?";
        return jdbcTemplateObject.queryForObject(sql, new Object[]{id}, (rs, rowNum) -> {
            OrderEntity order = new OrderEntity();
            order.setId(rs.getLong("id"));
            order.setOrderNo(rs.getString("order_no"));
            order.setProductName(rs.getString("product_name"));
            order.setPrice((float) rs.getDouble("price"));
            order.setQuantity(rs.getInt("quantity"));
            return order;
        });
    }

    @Override
    public boolean create(OrderEntity entity) {
        try {
            String sql = "INSERT INTO ORDERS (order_no, product_name, price, quantity) VALUES (?, ?, ?, ?)";
            jdbcTemplateObject.update(sql, entity.getOrderNo(), entity.getProductName(), entity.getPrice(), entity.getQuantity());
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }

    @Override
    public boolean update(OrderEntity entity) {
        return create(entity); 
    }

    @Override
    public boolean delete(OrderEntity entity) {
        try {
            String sql = "DELETE FROM ORDERS WHERE id = ?";
            jdbcTemplateObject.update(sql, entity.getId());
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }
}
