CREATE DATABASE HR

CREATE TABLE Employee(
ID_Employee nvarchar(30), 
Name nvarchar(255), 
DateBirth nvarchar(255), 
Gender bit, 
PlaceBirth nvarchar(255), 
ID_Department nvarchar(30)
)

GO

CREATE TABLE Department(
ID_Department nvarchar(30),
Name nvarchar(255)
)

INSERT INTO Employee VALUES ('C53418', N'Trần Tiến', '11/10/2000', 'true', N'Hà Nội', 'KT')
INSERT INTO Employee VALUES ('X53416', N'Nguyễn Cường', '21/07/1999', 'false', N'Đắk Lắk', 'KD')
INSERT INTO Employee VALUES ('M53417', N'Nguyễn Hào', '25/12/2001', 'true', N'TP.Hồ Chí Minh', 'NS')

INSERT INTO Department VALUES ('NS', N'Nhân sự')
INSERT INTO Department VALUES ('KT', N'Kế toán')
INSERT INTO Department VALUES ('KD', 'Kinh doanh')

SELECT *FROM Employee
SELECT *FROM Department

DROP TABLE Employee