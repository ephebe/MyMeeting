Alter Table [AspNetUsers]
ADD FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
UserName NVARCHAR(50) NOT NULL,
NormalizedUserName NVARCHAR(50) NOT NULL,
Email VARCHAR(50) NOT NULL,
NormalizedEmail VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NULL,
CreatedAt DATETIME Default 'now()',
UserState INT Default 1;

CREATE UNIQUE INDEX idx_Email ON dbo.AspNetUsers (email ASC);
CREATE UNIQUE INDEX idx_NormalizedEmail ON dbo.AspNetUsers (NormalizedEmail ASC);
