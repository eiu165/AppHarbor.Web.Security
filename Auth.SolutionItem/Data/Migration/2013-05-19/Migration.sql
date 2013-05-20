use Auth
go



--#region app.Setting
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Membership' AND type IN ('N','U')) 
BEGIN
	CREATE TABLE [dbo].[Membership](
		[Id] [int] IDENTITY(1,1) NOT NULL, 
		[Name] [varchar](25) NOT NULL,
		[CreateDate] [datetime] NULL,
		[ConfirmationToken] [nvarchar](128) NULL,
		[IsConfirmed] [bit] NULL default(0),
		[LastPasswordFailureDate] [datetime] NULL,
		[PasswordFailuresSinceLastSuccess] [int] NOT NULL default(0),
		[Password] [nvarchar](128) NOT NULL,
		[PasswordChangedDate] [datetime] NULL,
		[PasswordSalt] [nvarchar](128) NOT NULL,
		[PasswordVerificationToken] [nvarchar](128) NULL,
		[PasswordVerificationTokenExpirationDate] [datetime] NULL,
	 CONSTRAINT [PK_Membership] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	SET IDENTITY_INSERT [dbo].[Membership] ON;

	BEGIN TRANSACTION;
	INSERT INTO [dbo].[Membership]([Id],   [Name], [Password], [PasswordSalt] )
	SELECT 1,   N'a',   N'aaa',   N''   UNION ALL
	SELECT 2,   N'b',   N'aaa',   N''   UNION ALL
	SELECT 3,   N'c',   N'aaa',   N''   UNION ALL
	SELECT 4,   N'd',   N'aaa',   N''     
	COMMIT;

	SET IDENTITY_INSERT [dbo].[Membership] OFF;

END
GO


