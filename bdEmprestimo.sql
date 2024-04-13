create database bdEmprestimo;
use bdEmprestimo;

create table tbUsuario(
CodUsu int primary key auto_increment,
nomeUsu varchar(50));

create table tbLivro(
codLvro int primary key auto_increment,
nomeLivro varchar(50),
imgLivro varchar(255));

create table tbEmprestimo(
codEmp int primary key auto_increment,
dataEmp varchar(20),
datDev varchar(20),
codUsu int references tbUsuario(codUsu));

create table itensEmp(
codItem int primary key auto_increment,
codEmp int references tbEmprestimo(codEmp),
codLivro int references tbLivro(codLivro));
