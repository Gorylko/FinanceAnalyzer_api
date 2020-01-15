CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] VARBINARY(MAX) NOT NULL,
	[PasswordSalt] VARBINARY(MAX) NOT NULL,
	PRIMARY KEY CLUSTERED([Id]ASC)
);
GO

CREATE TABLE [dbo].[Income]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[UserId] INT NOT NULL,
   	[Amount] DECIMAL(10, 3) NOT NULL,
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),

 	PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

CREATE TABLE [dbo].[Expense]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[UserId] INT NOT NULL,
   	[Amount] DECIMAL(10, 3) NOT NULL,
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),

 	PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

CREATE TABLE [dbo].[Tax]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[UserId] INT NOT NULL,
   	[Amount] DECIMAL(10, 3) NOT NULL,
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),

 	PRIMARY KEY CLUSTERED([Id] ASC)
);

CREATE TABLE [dbo].[FinanceOperationHistory]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[UserId] INT NOT NULL,
	[OperationType] INT NOT NULL,
	[Date] DATETIME NOT NULL,
	[Amount] DECIMAL(10, 3) NOT NULL,

	FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),
 	PRIMARY KEY CLUSTERED([Id] ASC)
);