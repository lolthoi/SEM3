create table Staffs(
	Staff_ID int identity(1,1) primary key, 
	Staff_FirstName nvarchar(255) not null,
	Staff_LastName nvarchar(255) not null,
	Staff_Phone varchar(50) not null unique,
	Staff_Email varchar(50) not null unique,
	Staff_Roles varchar(50) not null,
);

create table Customers (
	Customer_ID int identity(1,1) primary key, 
	Customer_FirstName nvarchar(255) not null,
	Customer_LastName nvarchar(255) not null,
	Customer_Phone varchar(50) not null unique,
	Customer_Email varchar(50) not null unique,
	Customer_Address nvarchar(255) not null,
);

create table Payments (
	Payment_ID int identity(1,1) primary key, 
	Payment_Method nvarchar(100) not null,
	Payment_Status nvarchar(10) not null,
);

create table Materials (
	Material_ID int identity(1,1) primary key,
	Material_Description nvarchar(255),
	Material_Price float not null,
);

create table Sizes (
	Size_ID int identity(1,1) primary key,
	Size_Description nvarchar(255),
	Size_Price float not null,
);

create table Customer_Payment (
	ID int identity(1,1) primary key,
	Customer_Id int foreign key references Customers(Customer_ID),
	Payment_Id int foreign key references Payments(Payment_ID)
);

create table Orders(
	Order_ID int identity(1,1) primary key,
	Order_Status nvarchar(50) not null,
	Order_Date datetime not null,
	Staff_Id int foreign key references Staffs(Staff_ID),
	Customer_Id int foreign key references Customers(Customer_ID),
);

create table Order_Material (
	ID int identity(1,1) primary key,
	Order_Id int foreign key references Orders(Order_ID),
	Material_Id int foreign key references Materials(Material_ID),
	quantity int not null,
);

create table Order_Size (
	ID int identity(1,1) primary key,
	Order_Id int foreign key references Orders(Order_ID),
	Size_Id int foreign key references Sizes(Size_ID),
	quantity int not null,
);

