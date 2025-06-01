CREATE DATABASE[RailwayStationDB]
CREATE TABLE[Trains]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[train_number] VARCHAR(10) UNIQUE,
[capacity] INT 
)
INSERT INTO Trains (train_number, capacity)
VALUES 
('EXP100', 300), 
('REG200', 150), 
('FRT300', 500); 

CREATE TABLE[Routes]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[train_id] INT FOREIGN KEY REFERENCES [Trains]([id]),
[departure_station] VARCHAR(100),
[arrival_station] VARCHAR(100),
[departure_time] DATETIME,
[arrival_time] DATETIME
)
INSERT INTO Routes (train_id, departure_station, arrival_station, departure_time, arrival_time) 
VALUES 
(1, 'Sofia', 'Varna', '2025-03-16 08:00:00', '2025-03-16 14:30:00'), 
(2, 'Sofia', 'Plovdiv', '2025-03-16 09:30:00', '2025-03-16 11:00:00'), 
(3, 'Burgas', 'Ruse', '2025-03-16 10:00:00', '2025-03-16 18:00:00'); 
CREATE TABLE[Tracks]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[station_name] VARCHAR(100),
[track_number] INT UNIQUE,
[train_id] INT FOREIGN KEY REFERENCES [Trains]([id])
)
INSERT INTO Tracks (station_name, track_number, train_id) 
VALUES 
('Central Station Sofia', 1, 1), 
('Central Station Sofia', 2, 2), 
('Plovdiv Station', 3, NULL), 
('Varna Station', 4, 3); 
CREATE TABLE[Tickets]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[passenger_name] VARCHAR(100),
[train_id] INT FOREIGN KEY REFERENCES [Trains]([id]),
[route_id] INT FOREIGN KEY REFERENCES [Routes]([id]),
[seat_number] VARCHAR(10),
[price] DECIMAL(10,2)
)
INSERT INTO Tickets (passenger_name, train_id, route_id, seat_number, price) 
VALUES 
('John Smith', 1, 1, '12A', 45.50), 
('Emma Johnson', 2, 2, '8B', 15.00), 
('George Brown', 3, 3, '5C', 60.00), 
('Sophia Wilson', 1, 1, '7D', 45.50); 
CREATE TABLE [Employees]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(100),
[position] VARCHAR(50),
[train_id] INT FOREIGN KEY REFERENCES [Trains]([id]),
)
INSERT INTO Employees (name, position, train_id) 
VALUES 
('Michael Davis', 'Train Driver', 1), 
('James Miller', 'Conductor', 2), 
('Robert Taylor', 'Operator', NULL), 
('William Anderson', 'Train Driver', 3); 