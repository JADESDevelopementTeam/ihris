CREATE DATABASE SDMBA
GO
USE SDMBA
GO
CREATE SCHEMA Employees
GO
CREATE SCHEMA Occupation
GO
CREATE SCHEMA Operational
GO
USE SDMBA
GO
CREATE TABLE Occupation.Division
(
	DivisionID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DivisionName VARCHAR(100) NOT NULL,
	DivisionDescription VARCHAR(100) NOT NULL,
)
GO
CREATE TABLE Occupation.Position
(
	PositionID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	PositionName VARCHAR(100) NOT NULL,
	PositionPayrollBase MONEY NOT NULL,
	DivisionID INT NOT NULL,
)
GO
CREATE TABLE Employees.Employee
(
	EmployeeNIP VARCHAR(10) PRIMARY KEY NOT NULL,
	EmployeePassword VARCHAR(10) NOT NULL,
	EmployeeLevel VARCHAR(3) NOT NULL,
	EmployeeName VARCHAR(40) NOT NULL,
	EmployeeGender VARCHAR(6) NOT NULL,
	EmployeeDOB DATE NOT NULL,
	EmployeeEmail VARCHAR(100) NOT NULL,
	EmployeePhone VARCHAR(20) NOT NULL,
	EmployeePhoto VARCHAR(100),
	DivisionID INT NOT NULL,
	PositionID INT NOT NULL,
)
CREATE TABLE Employees.Payroll
(
	PayrolID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	PayrollTotal MONEY NOT NULL,
	PayrollPositionAllowanceTotal MONEY NOT NULL,
	PayrollTransportationAllowanceTotal MONEY NOT NULL,
	PayrollHouseAllowanceTotal MONEY NOT NULL,
	PayrollAnotherAllowanceTotal MONEY NOT NULL,
	PayrollReductionTotal MONEY NOT NULL,
	EmployeeNIP VARCHAR(10) NOT NULL,
	PositionID INT NOT NULL
)
CREATE TABLE Occupation.Contracts
(
	ContractNumber VARCHAR (10) PRIMARY KEY NOT NULL,
	ContractName NTEXT NOT NULL,
	ContractDescription NTEXT NOT NULL,
	ContractTimePeriod VARCHAR(100) NOT NULL,
	ContractStartDate DATE NOT NULL,
	ContractEndDate DATE NOT NULL,
	ContractStatus VARCHAR(9) NOT NULL,
	ContractInfo NTEXT NOT NULL,
	EmployeeNIP VARCHAR(10) NOT NULL,
)
GO
CREATE TABLE Operational.Inventories
(
	InventoryNumber VARCHAR (10) PRIMARY KEY NOT NULL,
	InventoryName NTEXT NOT NULL,
	InventoryDescription NTEXT NOT NULL,
	InventoryCategory NTEXT NOT NULL,
	InventoryStock BIGINT NOT NULL,
	EmployeeNIP VARCHAR(10) NOT NULL
)
GO
ALTER TABLE Employees.Employee ADD CONSTRAINT uqNIP UNIQUE (EmployeeNIP)
GO
ALTER TABLE Employees.Payroll
ADD CONSTRAINT fkPayrollBase FOREIGN KEY (PositionID) REFERENCES Occupation.Position(PositionID)
GO
ALTER TABLE Occupation.Position
ADD CONSTRAINT fkDivisionID FOREIGN KEY (DivisionID) REFERENCES Occupation.Division(DivisionID)
GO
ALTER TABLE Employees.Employee
ADD CONSTRAINT fkDivisionIDEmp FOREIGN KEY (DivisionID) REFERENCES Occupation.Division(DivisionID)
GO
ALTER TABLE Employees.Employee
ADD CONSTRAINT fkPositionIDEmp FOREIGN KEY (PositionID) REFERENCES Occupation.Position(PositionID)
GO
ALTER TABLE Occupation.Contracts
ADD CONSTRAINT fkEmployeeNIPContracts FOREIGN KEY (EmployeeNIP) REFERENCES Employees.Employee(EmployeeNIP)
GO
ALTER TABLE Operational.Inventories
ADD CONSTRAINT fkEmployeeNIPInventories FOREIGN KEY (EmployeeNIP) REFERENCES Employees.Employee(EmployeeNIP)
GO


--------test field---------

INSERT INTO Occupation.Division VALUES ('SDM Dan Umum', 'Divisi SDM Dan Umum')
GO
INSERT INTO Occupation.Position VALUES ('Manajer SDM Dan Umum', 5000000,1)
GO
INSERT INTO Employees.Employee VALUES ('BA123', '123', 'Yes', 'Eja', 'MALE', '1995-11-22', 'asd@asd.asd', '081242131412', '2.jpeg', 1, 1)
GO


SELECT EmployeeNIP, PositionPayrollBase FROM Employees.Employee E JOIN Occupation.Position P on  E.PositionID = P.PositionID WHERE EmployeeNIP='ASD123'
---------------


---------------------------------------------------------------untouched-----------------------------------------------------------
CREATE TABLE Operational.PettyCash
(
	CashID INT IDENTITY(1,1) PRIMARY KEY,
	TakeDate DATE NULL,
	BackDate DATE NULL,
	CashDescription NTEXT NOT NULL,
	Cash Total MONEY NOT NULL,
	SALDO, 
)
GO
GO
CREATE TABLE Employees.Attendance
(
	EmloyeeID varchar(10) not null,
	EmployeeName varchar(30) not null,
	AttendanceDate date not null,
	InTime time not null,
	OutTime time not null,
	NotAttend int not null,
	Overtime int not null,
	OverTimeAmount int not null
)
GO
create table Employees.TempAttendance
(
	eventtime datetime not null,
	userid varchar(30) not null,
	username varchar(50) not null,
	department varchar(50),
	terminalid int,
	terminalname varchar(30),
	authenticationtype varchar(30),
	result varchar(50),
	functionkey varchar(20) not null
)
