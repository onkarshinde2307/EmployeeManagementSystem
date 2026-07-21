CREATE DATABASE DBEmployee;
GO

USE DBEmployee;
GO

CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Password NVARCHAR(100)
);

CREATE TABLE Employees
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Department NVARCHAR(100),
    Salary DECIMAL(18,2),
    City NVARCHAR(100),
    CreatedDate DATETIME
);

INSERT INTO Users(Name,Email,Password)
VALUES ('Admin','admin@gmail.com','12345');

INSERT INTO Employees(Name,Department,Salary,City,CreatedDate)
VALUES
('Onkar Shinde','IT',45000,'Pune',GETDATE()),
('Rahul Patil','HR',35000,'Mumbai',GETDATE()),
('Sneha Joshi','IT',48000,'Pune',GETDATE()),
('Sagar Jadhav','Finance',60000,'Satara',GETDATE()),
('Komal Pawar','IT',58000,'Thane',GETDATE());