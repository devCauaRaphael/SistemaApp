CREATE DATABASE dbCrudApplication;
USE dbCrudApplication;

CREATE TABLE tbFuncionario(
	IdFuncionario int primary key auto_increment,
    Email varchar(50) not null,
    Nome varchar(50) not null,
    Senha char(16) not null
);

CREATE TABLE tbProduto(
	IdProduto int primary key auto_increment,
    Descricao text not null,
    NomeProduto varchar(50) not null,
    Quantidade int not null,
    Preco decimal(8,2) not null
);

INSERT INTO tbFuncionario(Email, Nome, Senha) VALUES ('adm@gmail.com', 'admin', 123);
SELECT * FROM tbFuncionario;
SELECT * FROM tbProduto;
