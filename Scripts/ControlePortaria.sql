USE [Controle_Portaria]
GO
/****** Object:  Table [dbo].[Encomendas]    Script Date: 13/03/2021 23:15:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomendas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeRemetente] [varchar](100) NOT NULL,
	[NumApartamento] [int] NOT NULL,
	[Torre] [varchar](10) NOT NULL,
	[DataRecebimento] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[DocRetirada] [varchar](20) NULL,
	[NomeRetirada] [varchar](100) NULL,
	[DataEntrega] [datetime] NULL,
	[StatusEntrega] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
