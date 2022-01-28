CREATE TABLE DeductionType (      
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,      
DeductionName VARCHAR(20) NOT NULL,    
DeductionCode VARCHAR(5) NOT NULL,
DeductionAmount DECIMAL(10,2) NOT NULL,        
)      
GO 

CREATE TABLE Employee (      
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,      
Name VARCHAR(20) NOT NULL,     
PayPerPeriod DECIMAL(10,2) NOT NULL,
DeductionTypeId INT NOT NULL FOREIGN KEY REFERENCES DeductionType(Id)                 
)      
GO 

CREATE TABLE [Dependent] (      
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,      
Name VARCHAR(20) NOT NULL,        
EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employee(Id),
DeductionTypeId INT NOT NULL FOREIGN KEY REFERENCES DeductionType(Id)          
)      
GO 


INSERT INTO DeductionType (DeductionName, DeductionCode, DeductionAmount)
VALUES
('Standard Dependent', 'STNDT', 500),
('Standard Employee', 'STND', 1000),
('Special Employee', 'SPE', 500),
('Special Dependent', 'SPD', 450)
