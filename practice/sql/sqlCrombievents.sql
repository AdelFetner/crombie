-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Crombievents')
BEGIN
    CREATE DATABASE Crombievents;
END
GO
-- Switch to the database context
USE Crombievents;
-- Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(15) NULL,
    RegisterDate DATETIME DEFAULT GETDATE()
);
-- EmployeeTypes Table
CREATE TABLE EmployeeTypes (
    EmployeeTypeID INT PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL UNIQUE
);
-- Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(15) NULL,
    HireDate DATETIME DEFAULT GETDATE(),
    EmployeeTypeID INT NOT NULL,
    FOREIGN KEY (EmployeeTypeID) REFERENCES EmployeeTypes(EmployeeTypeID) ON DELETE CASCADE
);
-- Insert the employee type for organizers
INSERT INTO EmployeeTypes (TypeName) VALUES ('Organizer');
-- Events Table
CREATE TABLE Events (
    EventID INT PRIMARY KEY,
    EventName NVARCHAR(200) NOT NULL,
    Date DATE DEFAULT GETDATE() NOT NULL,
    Time TIME NOT NULL,
    Location NVARCHAR(200) NOT NULL,
    MaxCapacity INT NOT NULL,
    OrganizerID INT NOT NULL,
    FOREIGN KEY (OrganizerID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
);
-- Reservations Table
CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    UserEmail NVARCHAR(100) NOT NULL UNIQUE,
    EventName NVARCHAR(200) NOT NULL,
    EventDate DATE NOT NULL,
    TicketQuantity INT NOT NULL CHECK (TicketQuantity > 0),
    ReservationDate DATETIME DEFAULT GETDATE()
);
-- TicketSales Table
CREATE TABLE TicketSales (
    SaleID INT PRIMARY KEY,
    ReservationID INT NOT NULL,
    EmployeeID INT NOT NULL,
    SaleDate DATETIME DEFAULT GETDATE(),
    TotalSale DECIMAL(10, 2) NOT NULL CHECK (TotalSale > 0),
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID) ON DELETE CASCADE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
);
-- Payments Table
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY,
    ReservationID INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL CHECK (Amount > 0),
    PaymentDate DATETIME DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50) NOT NULL,
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID) ON DELETE CASCADE
);
-- Attendance Table (Many-to-Many Relationship between Users and Events)
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY,
    UserID INT NOT NULL,
    EventID INT NOT NULL,
    AttendanceDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE,
    FOREIGN KEY (EventID) REFERENCES Events(EventID) ON DELETE CASCADE,
    UNIQUE (UserID, EventID) -- Prevents duplicate attendance records for the same user and event
);