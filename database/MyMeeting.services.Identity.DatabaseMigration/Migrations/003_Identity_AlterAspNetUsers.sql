Alter Table [AspNetUsers]
ADD 
CreatedAt DATETIME Default 'now()',
UserState INT Default 1;
