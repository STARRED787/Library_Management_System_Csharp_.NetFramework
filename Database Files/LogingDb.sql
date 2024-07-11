-- Create the database
CREATE DATABASE LibManagementSystem;

-- Use the database
USE LibManagementSystem;

-- Create the table
CREATE TABLE LogingTb (
    email VARCHAR(20),
    username VARCHAR(50) PRIMARY KEY,
    password VARCHAR(50)
);

-- Add sample data
INSERT INTO LogingTb (email, username, password) VALUES 
('sample1@example.com', 'user1', 'password1'),
('sample2@example.com', 'user2', 'password2');
