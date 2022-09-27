CREATE TABLE [StoreMessages]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[DeliveryType] VARCHAR(50) NOT NULL,
	[MessageStatus] VARCHAR(50) NOT NULL,
	[Data] TEXT NULL,
	[DataType] TEXT NULL,
	[RetryCount] INT NULL,
	CONSTRAINT [PK_meetings_MStoreMessages_Id] PRIMARY KEY ([Id] ASC)
)
GO