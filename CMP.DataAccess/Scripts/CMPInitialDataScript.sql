USE [CMP]
GO

INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name])
     VALUES
           (1
           ,'Admin')
GO

INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name])
     VALUES
           (2
           ,'User')
GO


INSERT [dbo].[AspNetUsers] 
([Id], 
[RoleId], 
[Email], 
[EmailConfirmed], 
[PasswordHash],
[SecurityStamp], 
[PhoneNumber], 
[PhoneNumberConfirmed],
[TwoFactorEnabled], 
[LockoutEndDateUtc],
[LockoutEnabled],
[AccessFailedCount],
[UserName]) VALUES 
(N'c76fa500-c993-473a-a2d6-8790b8dbd468',
N'1',
N'admin@abc.com', 
0, 
N'ACsXYWnQ0iYl+ocMGNy5IFeSZfoDyrWsKvgs7G4lnQDsyn/583LciH1PQYx6qq0u9A==', 
N'9481353a-071b-4c2e-8412-244af2d8ea9d', 
NULL,
0, 
0,
NULL,
1, 
0, 
N'admin@abc.com')
GO



insert into AspNetUserRoles values(N'c76fa500-c993-473a-a2d6-8790b8dbd468', 1)



