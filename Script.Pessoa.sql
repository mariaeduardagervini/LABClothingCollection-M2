CREATE DATABASE [labclothingcollectionbd]
GO
USE [labclothingcollectionbd]
GO
------------------------------------------------------------------------------

CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Genero] [varchar](20) NULL,
	[DataNascimento] [date] NOT NULL,
	[CpfCnpj] [varchar](14) UNIQUE NOT NULL,
	[Telefone] [varchar] (20) NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------------------------------------------------------
INSERT [dbo].[Pessoa]([Nome], [Genero], [DataNascimento],[CpfCnpj],[Telefone]) VALUES('Maria da Silva', 'F', '1994-05-06', '482.312.889-37', '(48) 9921-5463')
GO

INSERT [dbo].[Pessoa]([Nome], [Genero], [DataNascimento],[CpfCnpj],[Telefone]) VALUES('José Andrade', 'M', '1991-09-19', '374.228.579-35', '(48) 99181-9785')
GO

INSERT [dbo].[Pessoa]([Nome], [Genero], [DataNascimento],[CpfCnpj],[Telefone]) VALUES('Bruna Lopez', 'F', '1981-11-29', '566.587.579-17', '(48) 99973-1546')
GO

INSERT [dbo].[Pessoa]([Nome], [Genero], [DataNascimento],[CpfCnpj],[Telefone]) VALUES('Manoel Dias', 'M', '1979-10-02', '604.710.669-23', '(48) 99932-4569')
GO

INSERT [dbo].[Pessoa]([Nome], [Genero], [DataNascimento],[CpfCnpj],[Telefone]) VALUES('Karine Melo', 'F', '1995-03-12', '717.191.289-28', '(48) 99168-9644')
GO

SELECT * FROM [dbo].[Pessoa]

------------------------------------------------------------------------------