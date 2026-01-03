USE [WEBSHOPDB]
GO

INSERT INTO [dbo].[UserGroup]
           ([GroupName]
           ,[Description]
           ,[Deleted])
     VALUES
           ('Administrator'
           ,'Administrator user'
           ,0)

INSERT INTO [dbo].[UserGroup]
           ([GroupName]
           ,[Description]
           ,[Deleted])
     VALUES
           ('Sales'
           ,'Sales person'
           ,0)
GO

INSERT INTO [dbo].[UserAccount]
           ([UserGroupID]
           ,[Status]
           ,[FirstName]
           ,[LastName]
           ,[Username]
           ,[Password]
           ,[Email]
           ,[Phone]
           ,[Mobile]
           ,[AddressLine1]
           ,[Gender]
           ,[Builtin]
           ,[CreatedOn]
           ,[CreatedBy])
     VALUES
           (1
           ,1
           ,'Nhat'
           ,'Nguyen'
           ,'nhatnguyen'
           ,'123456'
           ,'nhat@mail.com'
           ,'0292827263'
           ,'9383736367'
           ,'2200 Prospect'
           ,1
           ,1
           ,GETDATE()
           ,1)
GO



