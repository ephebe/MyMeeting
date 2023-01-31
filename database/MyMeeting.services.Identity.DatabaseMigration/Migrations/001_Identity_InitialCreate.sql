

CREATE TABLE [dbo].[asp_net_users](
	[id] [nvarchar](128) NOT NULL,
	[email] [nvarchar](256) NULL,
	[email_confirmed] [bit] NOT NULL,
	[password_hash] [nvarchar](max) NULL,
	[security_stamp] [nvarchar](max) NULL,
	[phone_number] [nvarchar](max) NULL,
	[phone_number_confirmed] [bit] NOT NULL,
	[two_factor_enabled] [bit] NOT NULL,
	[lockout_end_date_utc] [datetime] NULL,
	[lockout_enabled] [bit] NOT NULL,
	[access_failed_count] [int] NOT NULL,
	[user_name] [nvarchar](256) NOT NULL,
 CONSTRAINT [pk_asp_net_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[asp_net_user_roles](
	[user_id] [nvarchar](128) NOT NULL,
	[role_id] [nvarchar](128) NOT NULL,
 CONSTRAINT [pk_asp_net_user_roles] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[asp_net_roles](
	[id] [nvarchar](128) NOT NULL,
	[name] [nvarchar](256) NOT NULL,
 CONSTRAINT [pk_asp_net_roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[asp_net_user_roles]  WITH CHECK ADD  CONSTRAINT [fk_asp_net_user_roles_asp_net_roles_RoleId] FOREIGN KEY([role_id])
REFERENCES [dbo].[asp_net_roles] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[asp_net_user_roles] CHECK CONSTRAINT [fk_asp_net_user_roles_asp_net_roles_role_id]
GO

ALTER TABLE [dbo].[asp_net_user_roles]  WITH CHECK ADD  CONSTRAINT [fk_asp_net_user_roles_asp_net_users_userId] FOREIGN KEY([user_id])
REFERENCES [dbo].[asp_net_users] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[asp_net_user_roles] CHECK CONSTRAINT [fk_asp_net_user_roles_asp_net_users_user_id]
GO

CREATE TABLE [dbo].[asp_net_user_logins](
	[login_provider] [nvarchar](128) NOT NULL,
	[provider_key] [nvarchar](128) NOT NULL,
	[user_id] [nvarchar](128) NOT NULL,
 CONSTRAINT [pk_asp_net_user_logins] PRIMARY KEY CLUSTERED 
(
	[login_provider] ASC,
	[provider_key] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[asp_net_user_logins]  WITH CHECK ADD  CONSTRAINT [fk_asp_net_user_logins_asp_net_users_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[asp_net_users] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[asp_net_user_logins] CHECK CONSTRAINT [fk_asp_net_user_logins_asp_net_users_user_id]
GO

CREATE TABLE [dbo].[asp_net_user_claims](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [nvarchar](128) NOT NULL,
	[claim_type] [nvarchar](max) NULL,
	[claim_value] [nvarchar](max) NULL,
 CONSTRAINT [pk_asp_net_user_claims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[asp_net_user_claims]  WITH CHECK ADD  CONSTRAINT [fk_asp_net_user_claims_asp_net_users_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[asp_net_users] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[asp_net_user_claims] CHECK CONSTRAINT [fk_asp_net_user_claims_asp_net_users_user_id]
GO