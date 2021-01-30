CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[Email] [varchar](255) NULL,
	[Adresse] [varchar](255) NOT NULL,
	[Coment] [varchar](255) NULL,
	[DateEtHeure] [datetime2](7) NOT NULL,
    CONSTRAINT PK_Client PRIMARY KEY (ClientId)
)

CREATE TABLE [dbo].[Pizza](
	[PizzaId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
    CONSTRAINT PK_Pizza PRIMARY KEY (PizzaId)
)

CREATE TABLE [dbo].[Client_Pizza](
	[ClientId] [int] NOT NULL,
	[PizzaId] [int] NOT NULL,
    CONSTRAINT FK_Client FOREIGN KEY (ClientId) REFERENCES Client (ClientId),
    CONSTRAINT FK_Pizza FOREIGN KEY (PizzaId) REFERENCES Pizza (PizzaId)
)

CREATE TABLE [dbo].[Retour](
	[AvisId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[Avis] [varchar](max) NULL,
    CONSTRAINT PK_Avis PRIMARY KEY (AvisId)
)