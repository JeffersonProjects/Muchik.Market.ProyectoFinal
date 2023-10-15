create database db_security
go
use db_security
go
create table [security]
(
id_user int identity primary key,
[username] varchar (100),
[password] varchar (100)
)
go 
insert into [security] ( username, password) values ('admin','NewHorizons_2023@')