USE [ODS]
GO
/****** Object:  Table [dbo].[Country_Currency]    Script Date: 1/3/2023 11:33:03 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country_Currency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ISO_Code] [nvarchar](3) NULL,
	[Symbol] [nchar](3) NULL,
	[OrderBy] [int] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblproposedsurcharge]    Script Date: 1/3/2023 11:33:05 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblproposedsurcharge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardName] [varchar](50) NOT NULL,
	[Rate] [money] NOT NULL,
 CONSTRAINT [PK_tblproposedsurcharge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction_Details]    Script Date: 1/3/2023 11:33:05 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Receipt_Number] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[Reference] [nvarchar](50) NULL,
	[stnumber] [nvarchar](50) NULL,
	[PaymentMethodID] [nvarchar](100) NULL,
	[baseamount] [nvarchar](50) NULL,
	[localamount] [nvarchar](50) NULL,
	[surchargeamount] [nvarchar](50) NULL,
	[localsurchargeamount] [nvarchar](50) NULL,
	[localcurrencytype] [nvarchar](50) NULL,
	[basecurrencytype] [nvarchar](50) NULL,
	[paymentmethod] [nvarchar](50) NULL,
	[basetotalamount] [nvarchar](50) NULL,
	[localtotalamount] [nvarchar](50) NULL,
	[customerid] [nvarchar](100) NULL,
	[SourceType] [nvarchar](50) NULL,
	[resCode] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
	[surchargepercent] [nvarchar](10) NULL,
	[Transaction_DT] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country_Currency] ON 
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (1, N'AUD', N'$  ', 1, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (2, N'USD', N'$  ', 2, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (3, N'INR', N'₹  ', 3, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (4, N'CNY', N'¥  ', 4, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (5, N'BGN', N'лв ', 5, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (6, N'BRL', N'R$ ', 6, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (7, N'CAD', N'$  ', 7, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (8, N'CHF', N'Fr ', 8, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (9, N'CZK', N'Kc ', 9, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (10, N'DKK', N'kr.', 10, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (11, N'EUR', N'€  ', 11, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (12, N'GBP', N'£  ', 12, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (13, N'HKD', N'$  ', 13, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (14, N'HRK', N'kn ', 14, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (15, N'HUF', N'Ft ', 15, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (16, N'JPY', N'¥  ', 16, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (17, N'MXN', N'$  ', 17, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (18, N'MYR', N'RM ', 18, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (19, N'NOK', N'kr.', 19, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (20, N'NZD', N'$  ', 20, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (21, N'PLN', N'zl ', 21, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (22, N'RON', N'lei', 22, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (23, N'SEK', N'kr.', 23, 0)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (24, N'SGD', N'$  ', 24, 1)
GO
INSERT [dbo].[Country_Currency] ([ID], [ISO_Code], [Symbol], [OrderBy], [Active]) VALUES (25, N'THB', N'฿  ', 25, 0)
GO
SET IDENTITY_INSERT [dbo].[Country_Currency] OFF
GO
SET IDENTITY_INSERT [dbo].[tblproposedsurcharge] ON 
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (1, N'VISA CREDIT', 1.6000)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (2, N'VISA DEBIT', 0.7100)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (3, N'MASTERCARD CREDIT', 1.2500)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (4, N'MASTERCARD DEBIT', 0.6600)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (5, N'AMEX', 1.9000)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (6, N'BECS*', 0.0000)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (7, N'WEBCHAT-PER STRIPE CONTACT', 2.0000)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (8, N'ALIPAY-PER STRIPE CONTACT', 2.0000)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (9, N'VISA PREPAID', 0.7100)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (10, N'MASTERCARD PREPAID', 0.6600)
GO
INSERT [dbo].[tblproposedsurcharge] ([Id], [CardName], [Rate]) VALUES (11, N'AFTERPAY_CLEARPAY', 0.0000)
GO
SET IDENTITY_INSERT [dbo].[tblproposedsurcharge] OFF
GO
ALTER TABLE [dbo].[Country_Currency] ADD  CONSTRAINT [DF_Country_Currency_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_GetCurrencies]    Script Date: 1/3/2023 11:33:14 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_WebApp_GetCurrencies]  
AS  
BEGIN  
select ID,ISO_Code,Symbol  
from [dbo].[Country_Currency] where Active=1
order by OrderBy  
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_GetSurchargePrice]    Script Date: 1/3/2023 11:33:14 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Select * from tblproposedsurcharge
CREATE PROCEDURE [dbo].[PROC_WebApp_GetSurchargePrice]
AS
BEGIN
select Id,CardName,Rate
from [dbo].[tblproposedsurcharge]
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_INSERT_Transaction_Details]    Script Date: 1/3/2023 11:33:14 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_WebApp_INSERT_Transaction_Details]
@Receipt_Number nvarchar(50) null,
 @email nvarchar(50) null,
 @Reference nvarchar(50) null,
 @stnumber nvarchar(50) null,
 @PaymentMethodID nvarchar(100) null,
 @baseamount nvarchar(50) null,
 @presentmentamount nvarchar(50) null,
 @surchargepercent nvarchar(50) null,
 @surchargeamount nvarchar(50) null,
 @presentmentsurchargeamount nvarchar(50) null,
 @presentmentcurrencytype nvarchar(50) null,
 @basecurrencytype nvarchar(50) null,
 @paymentmethod nvarchar(50) null,
 @basetotalamount nvarchar(50) null,
 @presentmenttotalamount nvarchar(50) null,
 --@customerid nvarchar(100) null,
 @SourceType nvarchar(50) null,
 @Timespan nvarchar(50) null,
 @T_DT datetime null,
 @resCode nvarchar(50) null
AS
BEGIN
Insert into Transaction_Details(Receipt_Number,email,Reference,stnumber,
PaymentMethodID,baseamount,localamount,surchargeamount,localsurchargeamount,
localcurrencytype,basecurrencytype,paymentmethod,basetotalamount,
localtotalamount,customerid,SourceType,resCode,Transaction_DT,surchargepercent,Created) Values 
(@Receipt_Number,@email,@Reference,@stnumber,@PaymentMethodID,@baseamount,@presentmentamount,
@surchargeamount,@presentmentsurchargeamount,@presentmentcurrencytype,@basecurrencytype,
@paymentmethod,@basetotalamount,@presentmenttotalamount,'',@SourceType,
@resCode,@Timespan,@surchargepercent,@T_DT)
END
GO
