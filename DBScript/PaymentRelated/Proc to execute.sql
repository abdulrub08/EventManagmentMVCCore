USE [ODS]
exec [bpoint].[PROC_BPOINT_FILE_SET] 'A00075259','2022-12-22 09:52:23','succeeded','succeeded','A000256390','Academic Transcript','100','payment',
'3600002211','Test','3600002211','101.6','automatic','{"id":"pi_3MHlRrJeW1y1htrf0og2lLqX","object":"payment_intent","amount":100,"amount_capturable":0,"amount_details":{"tip":{"amount":0}},"amount_received":100,"application":null,"application_fee_amount":null,"automatic_payment_methods":{"enabled":true},"canceled_at":null,"cancellation_reason":null,"capture_method":"automatic","client_secret":"pi_3MHlRrJeW1y1htrf0og2lLqX_secret_2ZrGZ4dSZE6k62x3828olypWt","confirmation_method":"automatic","created":1671702743,"currency":"aud","customer":null,"description":null,"invoice":null,"last_payment_error":null,"latest_charge":"ch_3MHlRrJeW1y1htrf0h9H9T9d","livemode":false,"metadata":{"student_id":"{\"publishablekey\":\"pk_test_51M5KJlJeW1y1htrflEomxOGfcs9H1iQLMOaiWpPYVzVcCkRpsQHmpwhHpnGdxJNTf6dX8ZRrz1aEN2TQdDNGgWKK00AE0jWZN1\",\"email\":\"abdul.rub@torrens.edu.au\",\"reference\":\"\",\"stnumber\":\"A00075259\",\"desc\":\"Academic Transcript\",\"paydesc\":\"Academic Transcript\",\"amount\":\"100\",\"surcharge\":\"1.6\",\"currencytype\":\"INR\",\"paymentmethod\":\"VISA CREDIT\",\"localamount\":\"5565.39\",\"localsurcharges\":\"1.6\",\"total\":\"101.6\",\"localtotal\":\"5566.990000000001\"}"},"next_action":null,"on_behalf_of":null,"payment_method":"pm_1MHlSFJeW1y1htrf40nUYbKt","payment_method_options":{"acss_debit":null,"affirm":null,"afterpay_clearpay":{"capture_method":null,"reference":null,"setup_future_usage":null},"alipay":null,"au_becs_debit":{"setup_future_usage":null},"bacs_debit":null,"bancontact":null,"blik":null,"boleto":null,"card":{"capture_method":null,"installments":null,"mandate_options":null,"network":null,"request_three_d_secure":"automatic","setup_future_usage":null,"statement_descriptor_suffix_kana":null,"statement_descriptor_suffix_kanji":null},"card_present":null,"customer_balance":null,"eps":null,"fpx":null,"giropay":null,"grabpay":null,"ideal":null,"interac_present":null,"klarna":null,"konbini":null,"link":null,"oxxo":null,"p24":null,"paynow":null,"pix":null,"promptpay":null,"sepa_debit":null,"sofort":null,"us_bank_account":null,"wechat_pay":null},"payment_method_types":["card","afterpay_clearpay","au_becs_debit"],"processing":null,"receipt_email":null,"review":null,"setup_future_usage":null,"shipping":null,"source":null,"statement_descriptor":null,"statement_descriptor_suffix":null,"status":"succeeded","transfer_data":null,"transfer_group":null}',
'abdul.rub@torrens.edu.au'

exec bpoint.PROC_Get_Banner_Student_provider 'A00010981'

exec [bpoint].[PROC_WebApp_GetStudentHoldStatus] 'A00016852'

exec PROC_WebApp_GetSurchargePrice

Select top(50) * from [bpoint].[T_BKT_BPOINT] where TRN_REC_ID>15808 order by TRN_REC_ID desc

Select top(5) * from Transaction_Details order by Id Desc

 where bt_email='abdul.rub@torrens.edu.au' 
Delete from [bpoint].[T_BKT_BPOINT] where TRN_REC_ID >15494

