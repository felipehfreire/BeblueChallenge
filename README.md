# BeblueChallenge
Desafio técnico - Engenheiro back-end

# Overview
O projeto foi escrito em C# utilizando .Net Core;
Versão do SDK:2.2.300

# API Documentation
(URl Raiz)/swagger/index.html
Ex: https://localhost:44385/swagger/index.html

# Build
Basta clonar o projeto, e abrir com Visual Studio 2017+ e realizar bulid;

Após o bulid completar verificar se o projedo WebApi esta como Startup( se não basta colocar) e executar o projeto.

O projeto foi configurado para utlizar o banco de dados local(LocalDb).

# External Packages

Web-api

	MediatR.Extensions.Microsoft.DependencyInjection
  
	Swashbuckle.AspNetCore
  
Application layer

	AutoMapper	
  
Domain

	FluentValidation.AspNetCore
  
	MediatR
  
Data	

	Microsoft.EntityFrameworkCore
  
	Microsoft.EntityFrameworkCore.Design
  
	Microsoft.EntityFrameworkCore.SqlServer
  
	Microsoft.EntityFrameworkCore.Tools
  
	Microsoft.Extensions.Configuration
  
	Microsoft.Extensions.Configuration.FileExtensions
  
	Microsoft.Extensions.Configuration.Json
  
IOC

	Microsoft.Extensions.DependencyInjection
  
	Install-Package Microsoft.AspNetCore.Http 
  
