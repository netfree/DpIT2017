USE [ConnectToUE]
GO

/****** Object:  Table [dbo].[Articol]    Script Date: 23.08.2017 16:19:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titlu] [nvarchar](max) NOT NULL,
	[Continut] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[Autor] [nvarchar](max) NOT NULL,
	[Este_publicat] [bit] NOT NULL,
 CONSTRAINT [PK_Articol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--------------------------


USE [ConnectToUE]
GO

/****** Object:  Table [dbo].[Articol_canal]    Script Date: 23.08.2017 16:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articol_canal](
	[Id] [int] NOT NULL,
	[Id_canal] [int] NOT NULL,
	[Id_articol] [int] NOT NULL,
 CONSTRAINT [PK_Articol_canal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Articol_canal]  WITH CHECK ADD  CONSTRAINT [FK_Articol_canal_articol] FOREIGN KEY([Id_articol])
REFERENCES [dbo].[Articol] ([Id])
GO

ALTER TABLE [dbo].[Articol_canal] CHECK CONSTRAINT [FK_Articol_canal_articol]
GO

ALTER TABLE [dbo].[Articol_canal]  WITH CHECK ADD  CONSTRAINT [FK_Articol_canal_Canal] FOREIGN KEY([Id_canal])
REFERENCES [dbo].[Canal] ([ID])
GO

ALTER TABLE [dbo].[Articol_canal] CHECK CONSTRAINT [FK_Articol_canal_Canal]
GO


------------