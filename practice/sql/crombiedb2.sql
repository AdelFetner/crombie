CREATE DATABASE CROMBIEEMPLEADOS;

USE CROMBIEEMPLEADOS;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    City VARCHAR(50)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    TotalPrice DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

INSERT INTO Customers VALUES
(1, 'Juan Pérez', 'Madrid'),
(2, 'Ana López', 'Lima'),
(3, 'Carlos Gómez', 'Bogotá');

INSERT INTO Orders VALUES
(101, 1, 2000),
(102, 2, 1200),
(103, 3, 300),
(104, 2, 500);

-- Encontrar al cliente premium:
-- Identificar a los clientes con un gasto total mayor a $1500, utilizando las funciones de agregación y JOINs.
-- Utilizando un JOIN, GROUP BY, y HAVING, escribe una consulta que obtenga el nombre y la ciudad de los clientes cuyo gasto total (suma de TotalPrice) sea mayor a $1500.

SELECT Customers.CustomerName, Orders.TotalPrice 
FROM Customers 
JOIN Orders ON orders.CustomerID = customers.CustomerID 
Where orders.TotalPrice > 1500;

-- ponerme más a tono después con no confundir where con having

 SELECT c.CustomerName, c.City, sum(o.TotalPrice) as TotalSpent
FROM customers c
INNER JOIN orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CustomerName, c.City	
HAVING SUM(o.TotalPrice) > 1500;

-- Actividad 1: Análisis de Ventas
        -- Usar funciones de agregación para obtener información como:
        -- Número de productos vendidos por categoría.
        -- Total de ingresos generados por cliente.

-- Actividad 2: Relacionar Tablas
        -- Usar un JOIN para combinar datos de las tablas orders y products.
        -- Encontrar qué producto generó más ingresos:
        
