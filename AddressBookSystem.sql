use AddressBookDB;

----Create table AddressBookSystem
Create table AddressBookSystem(
FirstName varchar(50),
LastName varchar(50),
Address varchar(50),
City varchar(50), 
State varchar(50),
Zip varchar(10),
PhoneNumber varchar(20),
EmailId varchar(50),
AddressBookType varchar(50),
AddressBookName varchar(50) 
);
select * from AddressBookSystem;

--insert record into table
insert into AddressBookSystem values('Shubham','Seth','Patrahi','Jaunpur','UP','222129','8788616249','shubham@gmail.com','Family','FamilyBook');
select * from AddressBookSystem;
