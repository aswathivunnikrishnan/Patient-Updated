CREATE TABLE Patient 
( 
   Patient_id int NOT NULL PRIMARY KEY,
   Patient_FName varchar(50),
   Patient_LName varchar(50),
   Patient_Gender varchar(50),
   Patient_Age varchar(50),
   Patient_Address varchar(50),
   PhoneNumber int,
   Email Varchar(100),
   isactive int

);
Go

CREATE TABLE Hospital 
( 
   Hospital_id int NOT NULL PRIMARY KEY,
   Hospital_Name varchar(200),
   StateName varchar(50),
   District varchar(50),
   City varchar(50),
   ContactP_Name varchar(50),
   ContactP_PhoneNumber int,
   Office_PhoneNumber int,
   isactive int

);
Go


CREATE TABLE H_Patient 
( 
   Hospital_id int ,
   Patient_id int,
   isactive int

);
Go

CREATE TABLE Product 
( 
   Product_id int NOT NULL PRIMARY KEY,
   Product_Name varchar(200),
   Category varchar(100),
   Min_Quantity int,
   Reorder varchar(50),
   UOM int
);
Go

CREATE TABLE Stock 
( 
   Product_id int NOT NULL PRIMARY KEY,
   Quantity int,
   UOM int,
   BatchNumber int ,
   Expiary_Date date
   
);
Go

CREATE TABLE Employee 
( 
   Employee_id int NOT NULL PRIMARY KEY,
   Employee_FName varchar(100),
   Employee_LName varchar(100),
   Employee_Gender varchar(50),
   E_PhoneNumber int,
   E_Address varchar(100),
   Department varchar(100) ,
   DOJ date,
   Designation Varchar(50),
   isactive int  
);
Go

CREATE TABLE Doctor 
( 
   Doctor_id int NOT NULL PRIMARY KEY,
   Doctor_Name varchar(100),
   Speciality varchar(100),
   Qualification varchar(50),
   D_PhoneNumber int,
   Timeofconsultancy time,
   No_of_patientperday int ,
   Fee int, 

);
Go

