CREATE SCHEMA [messaging]
	AUTHORIZATION [dbo];  
GO

CREATE TABLE [messaging].[store_messages]
(
	[id] UNIQUEIDENTIFIER NOT NULL,
	[delivery_type] VARCHAR(50) NOT NULL,
	[message_status] VARCHAR(50) NOT NULL,
	[data] TEXT NULL,
	[data_type] TEXT NULL,
	[retry_count] INT NULL,
	[created] datetime NOT NULL
	CONSTRAINT [pk_meetings_store_messages_id] PRIMARY KEY ([id] ASC)
)
GO