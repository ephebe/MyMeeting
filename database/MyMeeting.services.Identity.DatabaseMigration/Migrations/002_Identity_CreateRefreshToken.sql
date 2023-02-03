CREATE TABLE [RefreshTokens] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [Token]                VARCHAR (100)   NOT NULL,
    [UserId]               UNIQUEIDENTIFIER     NOT NULL,
    CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT FK_RefreshTokens_AspNetUsers_UserId FOREIGN KEY ([Id])
        REFERENCES AspNetUsers (Id)
        ON DELETE CASCADE
);

CREATE UNIQUE INDEX IX_RefreshTokens_Token_UserId ON dbo.RefreshTokens (Token ASC, UserId ASC);
GO
