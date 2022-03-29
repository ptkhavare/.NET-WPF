USE Personnel;

CREATE TABLE Employee (
EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
Position VARCHAR(100),
PayPerHour MONEY
);


SELECT * FROM Employee;

DROP table Employee;

ALTER TABLE
Employee
ALTER COLUMN 
EmployeeID int NOT NULL IDENTITY PRIMARY KEY;
 

INSERT
	INTO
	Employee
	(Name,
	Position,
	PayPerHour)
VALUES
	('Pranav Khavare',
	'Software Developer',
	35.00)

	INSERT
	INTO
	Employee
	(Name,
	Position,
	PayPerHour)
VALUES
	('John Doe',
	'Business Analyst',
	40.00)

	INSERT
	INTO
	Employee
	(Name,
	Position,
	PayPerHour)
VALUES
	('Chris Martin',
	'Quality Analyst',
	25.00)

	INSERT
	INTO
	Employee
	(Name,
	Position,
	PayPerHour)
VALUES
	('Brian Johnson',
	'Development Manager',
	45.00)

	INSERT
	INTO
	Employee
	(Name,
	Position,
	PayPerHour)
VALUES
	('Tom Araya',
	'Software Developer',
	35.00);


	SELECT * 
	FROM 
	Employee
	WHERE 
	Name like '%Pra%';
