Create PROCEDURE [dbo].[PROC_ValidateUser]
	@UserName varchar(200),
	@Password varchar(200)
AS
BEGIN

select *
from [dbo].[Registration] 
where Username = @UserName and Password=@Password

END
