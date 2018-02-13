create database testdb;
go

use testdb;
go

create table Customers
(
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(100),
	SecondName nvarchar(100),
	FamilyName nvarchar(100),
	CDate datetime default(getdate())
);

create table Addresses
(
	Id int not null identity(1,1) primary key,
	CustomerId int unique not null,
	Region nvarchar(100),
	City nvarchar(100),
	Street nvarchar(200),
	Number nvarchar(20),
	Postcode nvarchar(20),
	CDate datetime default(getdate())
);

alter table Addresses add constraint fk_addressescustomers foreign key (CustomerId) references Customers(Id);
create unique index uix_addressesCustomerId on Addresses(CustomerId);

Go

insert into Customers (FirstName, FamilyName) values ('User1', 'baba');
insert into Addresses (CustomerId, City) values (1,'Sofia');
