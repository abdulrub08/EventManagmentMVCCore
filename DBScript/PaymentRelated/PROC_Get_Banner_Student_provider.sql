USE [ODS]
GO
/****** Object:  StoredProcedure [bpoint].[PROC_Get_Banner_Student_provider]    Script Date: 16/12/2022 10:52:54 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/* =============================================
	Author:			Iftekhar Imran
	Created:		3/06/2019
	Description:	

   =============================================*/
ALTER PROCEDURE  [bpoint].[PROC_Get_Banner_Student_provider]
@SPRIDEN_ID varchar(25)='A00049980',
@Error_Code int = 0 OUTPUT,
@Error_Message nvarchar(max) = '' OUTPUT
as
Begin	
	SET NOCOUNT ON;
	
--set ANSI_NULLS ON; 

--SET ANSI_WARNINGS ON;
	BEGIN TRY

	Declare @PIDM varchar(55)=''
	Declare @H_Status as varchar(10)='N'
	--Declare @Hold_status as varchar(10)='N'
	
	if (@SPRIDEN_ID not like '%T')
	begin

			select  @PIDM =SGBSTDN_PIDM
			from [ODS].[shared].T_BANNER_Student_Enrolment_All 
			where SPRIDEN_ID=@SPRIDEN_ID 

			if isnull(@PIDM,'')<>''
			Begin
					EXEC ('BEGIN  SP_IS_ON_HOLD(P_PIDM => ?,P_HLDD_CODE => ?,  P_HOLD_STATUS =>? ); END;'
					, @PIDM,'CC', @H_Status OUTPUT) at BannerProto


					If  @H_Status='N'
					Begin
						delete 
						FROM [bpoint].[T_BKT_BPOINT_ON_HOLD]
						Where [STUDENT_ID]=@SPRIDEN_ID;
					end
					--IF @SPRIDEN_ID like 'A%'
					--Begin
					SELECT top 1   Provider_Name,  Hold_status from 
					(select 
					isnull(p.Provider_Account__c,'')Provider_Name
					--,[shared].[f_Is_onHold](e.SGBSTDN_PIDM,@SPRIDEN_ID,'CC')  Hold_status 
					,iif(@H_Status='Y',1,0) Hold_status
					FROM [shared].T_BANNER_Student_Enrolment_All e
					left join [shared].[V_Banner_College]  p
					on p.Banner_Unique_ID__c=e.SORLCUR_COLL_CODE
					where e.SGBSTDN_PIDM= @PIDM
					union 
					SELECT distinct
					p.Provider_Account__c Provider_Name, '0' Hold_status
					FROM 
					[LANZ_Source].[crm].[SF_ENROLMENT__C] e WITH (READUNCOMMITTED)
					left join  [crm].[V_SF_College] c  WITH (READUNCOMMITTED)
					on cast(e.[COLLEGE__C] as varchar(50))= cast(c.id as varchar(50))
					left join 
					[shared].[V_Banner_College]  p
					on p.BANNER_UNIQUE_ID__C=c.BANNER_UNIQUE_ID__C
					where  cast(e.[STUDENT_ID_FORMULA__C] as varchar(50))=@SPRIDEN_ID
					and   p.Provider_Account__c is not null
						) t
					order by Hold_status desc,Provider_Name desc
					--end
					--else
					--begin
			
					--SELECT top 1   Provider_Name,  Hold_status from 
					--(
					----select 
					----isnull(p.Provider_Account__c,'')Provider_Name
					------,[shared].[f_Is_onHold](e.SGBSTDN_PIDM,@SPRIDEN_ID,'CC')  Hold_status 
					----,iif(@H_Status='Y',1,0) Hold_status
					----FROM [shared].T_BANNER_Student_Enrolment_All e
					----left join [shared].[V_Banner_College]  p
					----on p.Banner_Unique_ID__c=e.SORLCUR_COLL_CODE
					----where e.SGBSTDN_PIDM= @PIDM
					------union 
					--SELECT distinct
					--p.Provider_Account__c Provider_Name, '0' Hold_status
					--FROM 
					--[LANZ_Source].[crm].[SF_ENROLMENT__C] e
					--left join  [crm].[V_SF_College] c
					--on cast(e.[COLLEGE__C] as varchar(50))= cast(c.id as varchar(50))
					--left join 
					--[shared].[V_Banner_College]  p
					--on p.BANNER_UNIQUE_ID__C=c.BANNER_UNIQUE_ID__C
					--where  cast(e.[STUDENT_ID_FORMULA__C] as varchar(50))=@SPRIDEN_ID
					--and   p.Provider_Account__c is not null
					--	) t
					--order by Hold_status desc,Provider_Name desc
					--end

			end
			else
			Begin
				select top 1 [Provider__c] Provider_Name ,0 Hold_status 
				from  CRM_Staging.[dbo].[v_CRM_to_Banner_Students] 
				where [Student_ID]=@SPRIDEN_ID
				order by [Process_date] desc
				--from Banner_PROD.[dbo].[V_SATURN_SPRIDEN]
		  --   where spriden_change_ind is null
			   --and spriden_id=@SPRIDEN_ID
			End
		End
      else
	  begin
	      select  'Think: Colleges Pty Ltd'Provider_Name ,0 Hold_status 
	  end
	END TRY

	BEGIN CATCH
		SET @Error_Code = ERROR_NUMBER()  
		SET @Error_Message = ERROR_MESSAGE()  
		SELECT  'Error #'+ cast(ERROR_NUMBER() as varchar(200))+ ' - '+ERROR_MESSAGE() AS ErrorMessage;   
	END CATCH

end
