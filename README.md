# CRUD de Funcionários

Este é um projeto de CRUD (Create, Read, Update, Delete) simples para gerenciar informações de funcionários em um banco de dados. O projeto foi desenvolvido em C# com Windows Forms e utiliza um banco de dados MySQL.

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes pré-requisitos instalados:

- [Visual Studio](https://visualstudio.microsoft.com/): É necessário ter o Visual Studio instalado para compilar e executar o projeto.
- [MySQL Server](https://dev.mysql.com/downloads/mysql/): Você deve ter um servidor MySQL instalado para armazenar os dados dos funcionários.
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/): O MySQL Workbench é útil para criar e administrar o banco de dados MySQL utilizado no projeto.

## Configuração das Variáveis de Ambiente

Este projeto utiliza variáveis de ambiente necessárias para a conexão com o banco de dados, siga estas etapas:

1. Abra as "Variáveis de ambiente" no seu sistema operacional (consulte as instruções específicas para o sistema Windows abaixo).

### Windows

- No Windows 10, pressione a tecla Windows, digitando "Variáveis de ambiente" e selecionando "Editar variáveis de ambiente do sistema".

2. Na seção "Variáveis de sistema", clique em "Novo" para adicionar as seguintes variáveis:

   - `SERVIDOR_CRUD`: O endereço do servidor MySQL (por exemplo, "localhost").
   - `BANCO_DADOS_CRUD`: O nome do banco de dados (por exemplo, "dbfuncionarios").
   - `USUARIO_CRUD`: O nome de usuário do MySQL (por exemplo, "root").
   - `SENHA_CRUD`: A senha do usuário do MySQL.

3. Preencha os valores das variáveis com as informações do seu servidor MySQL.

4. Clique em "OK" para salvar as variáveis de ambiente.
 
## Script de Criação do Banco de Dados

Para criar o banco de dados necessário para este projeto, você pode utilizar o seguinte script SQL:

```sql
-- Crie um banco de dados chamado "dbfuncionarios"
CREATE DATABASE IF NOT EXISTS dbfuncionarios
DEFAULT CHARACTER SET utf8mb4
DEFAULT COLLATE utf8mb4;

-- Use o banco de dados "dbfuncionarios"
USE dbfuncionarios;

-- Crie uma tabela chamada "funcionarios"
CREATE TABLE IF NOT EXISTS funcionarios (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nome VARCHAR(100) NOT NULL,
  email VARCHAR(100) NOT NULL,
  cpf VARCHAR(14) NOT NULL,
  endereco VARCHAR(200) NOT NULL
)default char set utf8mb4;
```

## Executando o Projeto

Siga estas etapas para executar o projeto:

1. Abra o projeto no Visual Studio.

2. Compile o projeto para garantir que não haja erros de compilação.

3. Execute o projeto pressionando F5 ou escolhendo "Iniciar" no Visual Studio.

4. O aplicativo CRUD de funcionários será iniciado e você poderá começar a gerenciar os dados dos funcionários.

## Contribuindo

Se você deseja contribuir para este projeto, fique à vontade para abrir problemas (issues) ou enviar solicitações de pull (pull requests).

## Objetivo do Projeto

Esta é uma aplicação simples que serve como um ambiente de treinamento pessoal, com o propósito de aprimorar algumas habilidades e conhecimentos.
