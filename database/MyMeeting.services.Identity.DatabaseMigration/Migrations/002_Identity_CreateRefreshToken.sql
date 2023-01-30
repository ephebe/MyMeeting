CREATE TABLE [refresh_tokens] (
    [id]                   UNIQUEIDENTIFIER NOT NULL,
    [token]                 VARCHAR (100)   NOT NULL,
    [user_id]               UNIQUEIDENTIFIER     NOT NULL,
    CONSTRAINT [pk_identity_refresh_tokens_id] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE UNIQUE INDEX idx_token_user_id ON dbo.refresh_tokens (token ASC, user_id ASC);
GO