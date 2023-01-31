Alter Table [asp_net_users]
ADD first_name NVARCHAR(100) NOT NULL,
last_name NVARCHAR(100) NOT NULL,
user_name NVARCHAR(50) NOT NULL,
normalized_user_name NVARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL,
normalized_email VARCHAR(50) NOT NULL,
phone_number VARCHAR(15) NULL,
created_at DATETIME Default 'now()',
user_state INT Default 1;

CREATE UNIQUE INDEX idx_asp_net_users_email ON dbo.asp_net_users (email ASC);
CREATE UNIQUE INDEX idx_asp_net_users_normalized_email ON dbo.asp_net_users (normalized_email ASC);
