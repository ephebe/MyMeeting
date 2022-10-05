CREATE TABLE [meeting_group_proposals]
(
	[id] UNIQUEIDENTIFIER NOT NULL,
	[name] NVARCHAR(255) NOT NULL,
	[description] VARCHAR(200) NULL,
    [location_city] NVARCHAR(50) NOT NULL,
    [location_country_code] NVARCHAR(3) NOT NULL,
    [proposal_user_id] UNIQUEIDENTIFIER NOT NULL,
    [proposal_date] DATETIME NOT NULL,
    [status_code] NVARCHAR(50) NOT NULL
	CONSTRAINT [pk_meetings_meeting_group_proposals_id] PRIMARY KEY ([id] ASC)
)
GO