use Auth
go



--#region app.Setting
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Membership' AND type IN ('N','U')) 
BEGIN
	CREATE TABLE [dbo].[Membership](
		[Id]  uniqueidentifier DEFAULT NEWSEQUENTIALID(), 
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

	
	BEGIN TRANSACTION;
	INSERT INTO [dbo].[Membership](   [Name], [Password], [PasswordSalt] )
	SELECT  N'dev',   N'aaa',   N''   UNION ALL
	SELECT  N'admin',   N'aaa',   N'' 
	COMMIT; 
END
GO


