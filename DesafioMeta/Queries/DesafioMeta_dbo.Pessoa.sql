create table Pessoa 
(
	Id int identity(1,1) not null primary key,
	Nome varchar(100) not null,
	Idade int not null,
	CPF varchar(14) null,
	Email varchar(100) null,
	Nacionalidade varchar(100) not null,
	Genero varchar(50) not null
)