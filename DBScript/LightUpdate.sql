USE [EventDB]
GO
/****** Object:  StoredProcedure [dbo].[LightUpdate]    Script Date: 13/6/2023 11:16:04 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[LightUpdate]
@LightID int,
@LightType nvarchar(50) ,
@LightName nvarchar(50) ,
@LightFilename nvarchar(max),
@LightFilePath nvarchar(max) ,
@Createdby int ,
@Createdate datetime,
@LightCost int
AS
BEGIN
Update [dbo].[Light]
           set [LightType]=@LightType
           ,[LightName]=@LightName
           ,[LightFilename]=@LightFilename
           ,[LightFilePath]=@LightFilePath
           ,[Createdby]=@Createdby
           ,[Createdate]=@Createdate
           ,[LightCost]=@LightCost
where LightID=@LightID

End


