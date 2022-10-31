CREATE SCHEMA [administration]
    AUTHORIZATION [dbo];  
GO


CREATE TABLE [administration].[meeting_group_proposals] (
    [id]                   UNIQUEIDENTIFIER NOT NULL,
    [name]                 NVARCHAR (255)   NOT NULL,
    [description]          VARCHAR (200)    NULL,
    [location_city]         NVARCHAR (50)    NOT NULL,
    [location_country_code]  NVARCHAR (3)     NOT NULL,
    [proposal_user_id]       UNIQUEIDENTIFIER NOT NULL,
    [proposal_date]         DATETIME         NOT NULL,
    [status_code]           NVARCHAR (50)    NOT NULL,
    [decision_date]         DATETIME         NULL,
    [decision_user_id]       UNIQUEIDENTIFIER NULL,
    [decision_code]         NVARCHAR (50)    NULL,
    [decision_reject_reason] NVARCHAR (250)   NULL,
    CONSTRAINT [pk_administration_meeting_group_proposals_id] PRIMARY KEY CLUSTERED ([id] ASC)
);

GO

CREATE TABLE [administration].[members] (
    [id]        UNIQUEIDENTIFIER NOT NULL,
    [login]     NVARCHAR (100)   NOT NULL,
    [email]     NVARCHAR (255)   NOT NULL,
    [first_name] NVARCHAR (50)    NOT NULL,
    [last_name]  NVARCHAR (50)    NOT NULL,
    [name]      NVARCHAR (255)   NOT NULL,
    CONSTRAINT [pk_administration_members_id] PRIMARY KEY CLUSTERED ([id] ASC)
);

GO