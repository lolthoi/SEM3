create database aspfirstdb

use aspfirstdb

create schema edu
go

create table edu.Student(
	ID int identity(1,1) not null primary key,
	LastName nvarchar(255) null,
	FirstName nvarchar(255) null,
	EnrollDate Datetime
)

create table edu.Course(
	ID int identity (1,1) not null primary key,
	Title nvarchar(255) null,
	Credits int null
)

create table edu.Student_Course(
	EnrollID int identity(1,1) not null primary key,
	Grade decimal(4,2) null,
	StudentID int not null foreign key references edu.Student(ID),
	CourseID int not null foreign key references edu.Course(ID) ,
)