-- Create database
CREATE DATABASE Ead;


-- Use the database
USE Ead;

-- Create table to store user logins
CREATE TABLE UserLogins (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);

SELECT * FROM UserLogins;
--Drop table UserLogins

INSERT INTO UserLogins (Username, Password, Role) VALUES ('Mahnoor', '12345', '0');
INSERT INTO UserLogins (Username, Password, Role) VALUES ('admin', '6789', '1');
INSERT INTO UserLogins (Username, Password, Role) VALUES ('guard', '1122', '2');

CREATE TABLE BusesData (
    BID INT PRIMARY KEY IDENTITY(100,3),
    numplate NVARCHAR(50) NOT NULL,
);
SELECT * FROM BusesData;
--Drop table BusesData;
INSERT INTO BusesData(numplate) VALUES ('LDA');
INSERT INTO BusesData(numplate) VALUES ('APL');
INSERT INTO BusesData(numplate) VALUES ('AEC');
INSERT INTO BusesData(numplate) VALUES ('ISL');

CREATE TABLE checkouts (
    ID INT PRIMARY KEY IDENTITY(1,1),
	BID INT NOT NULL, 
    itime TIME NOT NULL,
    otime TIME NOT NULL,
    status NVARCHAR(50) NOT NULL,
    ctime DATETIME DEFAULT GETDATE() NOT NULL
);


Select * from checkouts;
--Drop table checkouts;