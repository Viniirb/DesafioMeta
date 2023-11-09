create table Endreco
(
	Id int not null identity(1,1) primary key,
	PessoaId int not null constraint FK_Pessoa_Endereco foreign key (PessoaId) references dbo.Pessoa(Id),
	Logradouro varchar(100) not null,
	Numero varchar(50) null,
	Complemento varchar(100) null,
	Cidade varchar (50) not null,
	Bairro varchar(50) null,
	Estado varchar(100) null,
	CódigoPostal varchar(50) null
)