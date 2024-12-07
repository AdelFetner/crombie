CREATE DATABASE SalesAnalysis;

USE SalesAnalysis;

-- Tabla de Categorías
CREATE TABLE categories (
    category_id INT AUTO_INCREMENT PRIMARY KEY,
    category_name VARCHAR(50) NOT NULL
);

-- Tabla de Productos
CREATE TABLE products (
    product_id INT AUTO_INCREMENT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    category_id INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

-- Tabla de Clientes
CREATE TABLE customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE
);

-- Tabla de Órdenes
CREATE TABLE orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATE NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

-- Tabla de Detalles de la Orden
CREATE TABLE order_details (
    order_detail_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    total_price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- Insertar categorías
INSERT INTO categories (category_name)
VALUES ('Electronics'), ('Clothing'), ('Home Appliances');

-- Insertar productos
INSERT INTO products (product_name, category_id, price)
VALUES 
('Laptop', 1, 800),
('Smartphone', 1, 500),
('T-shirt', 2, 20),
('Jeans', 2, 50),
('Blender', 3, 100),
('Microwave', 3, 150);

-- Insertar clientes
INSERT INTO customers (customer_name, email)
VALUES 
('Alice', 'alice@example.com'),
('Bob', 'bob@example.com'),
('Charlie', 'charlie@example.com');

-- Insertar órdenes
INSERT INTO orders (customer_id, order_date)
VALUES 
(1, '2024-01-15'),
(2, '2024-02-20'),
(3, '2024-03-05'),
(1, '2024-03-15');

-- Insertar detalles de la orden
INSERT INTO order_details (order_id, product_id, quantity, total_price)
VALUES 
(1, 1, 1, 800),   -- Laptop
(1, 2, 2, 1000),  -- Smartphone x2
(2, 3, 3, 60),    -- T-shirt x3
(3, 5, 1, 100),   -- Blender
(3, 6, 1, 150),   -- Microwave
(4, 4, 2, 100);   -- Jeans x2

-- Actividad 1: Análisis de Ventas
	-- Usar funciones de agregación para obtener información como:
	-- Número de productos vendidos por categoría.
SELECT c.category_name, SUM(od.quantity) AS total_products_sold
FROM categories c
JOIN products p ON c.category_id = p.category_id
JOIN order_details od ON p.product_id = od.product_id
GROUP BY c.category_name;

	-- Total de ingresos generados por cliente.
SELECT c.customer_id, c.customer_name, SUM(od.total_price) AS total_customer_sales
FROM ORDER_DETAILS od
JOIN ORDERS o ON od.order_id = o.order_id
JOIN CUSTOMERS c ON o.customer_id = c.customer_id
GROUP BY c.customer_id, c.customer_name;

-- Actividad 2: Relacionar Tablas
	-- Usar un JOIN para combinar datos de las tablas orders y products.
SELECT o.order_id, p.product_name, od.quantity, od.total_price, o.order_date
FROM orders o
JOIN order_details od ON o.order_id = od.order_id
JOIN products p ON od.product_id = p.product_id;

	-- Encontrar qué producto generó más ingresos:
SELECT p.product_name as most_sold, SUM(od.total_price) AS total_revenue, SUM(od.quantity) AS total_quantity_sold
FROM order_details od
JOIN products p ON od.product_id = p.product_id
GROUP BY p.product_name
ORDER BY total_revenue DESC
LIMIT 1;