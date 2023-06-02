using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.DAL
{
    internal class DBConstant
    {
        #region Alumni
        public const string UPSERTALUMNIORDERDETAIL = "PROC_WebApp_UpsertAlumniOrderDetail";
        public const string UPSERTALUMNIORDER = "PROC_WebApp_UpsertAlumniOrder";
        public const string DELETEALUMNIORDERDETAIL = "PROC_WebApp_DeleteAlumniOrderDetail";
        public const string GETCOURSE = "PROC_WebApp_GetCourse";
        public const string GETCOLLEGE = "PROC_WebApp_GetCollege";
        public const string GETDOCUMENTPRICE = "PROC_WebApp_GetDocumentPrice";
        public const string INSERTALUMNIORDER_ORDERDETAIL = "PROC_WebApp_InsertAlumniOrder_OrderDetail";
        #endregion
    }
}
