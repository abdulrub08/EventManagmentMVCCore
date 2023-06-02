using Dapper;
using Event.DOM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Event.DAL.Repositories
{
    public class Account : BaseRepository, IAccount
    {
        public Account(IConfiguration configuration) : base(configuration)
        { }

        public bool GetLogedinUser()
        {
            throw new NotImplementedException();
        }

        public bool IsUserNameAvailable()
        {
            throw new NotImplementedException();
        }

        public bool IsUserValid()
        {
            throw new NotImplementedException();
        }

        public Registration GetLogedinUserByID(int _recId)
        {
            using (var connection = CreateConnection())
            {
                var sql = "select * from tbl_Order where RecID = " + _recId;
                Registration orders = connection.QuerySingle<Registration>(sql);
                return orders;
            }
        }
        public Registration GetLogedinUserByUserIDPassword(string userID,string password)
        {
            using (var connection = CreateConnection())
            {
                var sql = "select * from Registration where Username = '" + userID+ "' and Password='E10ADC3949BA59ABBE56E057F20F883E'";
                Registration orders = connection.QuerySingle<Registration>(sql);
                return orders;
                //var reader = connection.QueryMultiple(DBConstant.GETCOURSE, param: new { OrderID = userID }, commandType: CommandType.StoredProcedure);
                //List<Orders> orders = reader.Read<Orders>().ToList();
                //List<OrderDetail> orderDetails = reader.Read<OrderDetail>().ToList();
                //orderSummary.Orders = orders;
                //orderSummary.OrderDetails = orderDetails;
            }
        }

        //public Student GetStudent(string email)
        //{
        //    var query = @"EXEC GetStudentByEmail @email";

        //    using (var connection = CreateConnection())
        //    {
        //        var student = connection.QuerySingle<Student>(query, new { email });
        //        return student;
        //    }
        //}
        //public IEnumerable<Course> GetCoursesByStudent(string studentId)
        //{

        //    var query = @"EXEC PROC_WebApp_GetCoursesByStudentID @StudentID";

        //    using (var connection = CreateConnection())
        //    {
        //        var courses = connection.Query<Course>(query, new { studentId });
        //        return courses.ToList();
        //    }
        //}
        //public int AddAlumniOrderSummaries(AlumniStudent model)
        //{
        //    int rowAffected = 0;
        //    #region Commented for Not in Use
        //    using (var connection = CreateConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", model.OrderID);
        //        parameters.Add("@StudentID", model.StudentID);
        //        parameters.Add("@StudentType", "ALUMNI");
        //        parameters.Add("@FirstName", model.FullName);
        //        parameters.Add("@LastName", "");
        //        parameters.Add("@DateOfBirth", model.DOB);
        //        parameters.Add("@CollegeCode", model.College);
        //        parameters.Add("@CollegeDescription", model.CollegeDesc);
        //        parameters.Add("@YearOFStudy", model.YearofStudy);
        //        parameters.Add("@USI", model.USIChessen);
        //        parameters.Add("@CHESSN", "");
        //        parameters.Add("@PersonalEmail", model.Email);
        //        parameters.Add("@MobilePhone", model.MobileNo);
        //        parameters.Add("@MailingAddressLine1", model.MailingAddressLine1);
        //        parameters.Add("@MailingAddressLine2", model.MailingAddressLine2);
        //        parameters.Add("@MailingCity", model.MailingCity);
        //        parameters.Add("@MailingState", model.MailingState);
        //        parameters.Add("@MailingPostCode", model.MailingPostCode);
        //        parameters.Add("@MailingCountry", model.MailingCountry);
        //        parameters.Add("@ShippingType", model.ShippingType);
        //        parameters.Add("@Order_omments", "Alumni Student");
        //        parameters.Add("@LineNumber", 1);
        //        parameters.Add("@OrderType", model.DocumentFormat);
        //        parameters.Add("@CourseCode", model.CourseCode);
        //        parameters.Add("@CourseDescription", model.CourseDesc);
        //        parameters.Add("@CollegeCode", model.College);
        //        parameters.Add("@RequestedDocument", model.DocumentType);
        //        parameters.Add("@DocFormat", model.DocumentFormat);
        //        parameters.Add("@NumberOfCopies", model.DocumentCopies);
        //        parameters.Add("@Price", model.Price);
        //        parameters.Add("@TotalPrice", (model.Price * model.DocumentCopies));
        //        parameters.Add("@Comments", "Alumni Student");
        //        rowAffected = connection.Execute(DBConstant.INSERTALUMNIORDER_ORDERDETAIL, parameters, commandType: CommandType.StoredProcedure);
        //    }
        //    #endregion            
        //    return rowAffected;
        //}
        //public int AddMoreAlumniOrderDetails(AlumniStudent model)
        //{
        //    int rowAffected = 0;
        //    using (var connection = CreateConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", model.OrderID);
        //        parameters.Add("@LineNumber", model.LineNumber ? 1 : GenrateLineNo(model.OrderID));
        //        parameters.Add("@OrderDate", DateTime.Now);
        //        parameters.Add("@OrderType", Convert.ToString(model.ShippingType));
        //        parameters.Add("@CourseCode", Convert.ToString(model.CourseCode));
        //        parameters.Add("@CourseDescription", Convert.ToString(model.CourseDesc));
        //        parameters.Add("@CollegeCode", Convert.ToString(model.College));
        //        parameters.Add("@RequestedDocument", Convert.ToString(model.DocumentType));
        //        parameters.Add("@DocFormat", Convert.ToString(model.DocumentFormat));
        //        parameters.Add("@NumberOfCopies", Convert.ToString(model.DocumentCopies));
        //        parameters.Add("@Price", model.Price);
        //        parameters.Add("@TotalPrice", (model.Price * model.DocumentCopies));
        //        parameters.Add("@Comments", "Aumni Student Added Item");
        //        rowAffected = connection.Execute(DBConstant.UPSERTALUMNIORDERDETAIL, parameters, commandType: CommandType.StoredProcedure);

        //    }
        //    return rowAffected;
        //}
        //public int AddMoreAlumniOrder(AlumniStudent model)
        //{
        //    int rowAffected = 0;
        //    using (var connection = CreateConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", model.OrderID);
        //        parameters.Add("@StudentID", model.StudentID);
        //        parameters.Add("@StudentType", "ALUMNI");
        //        parameters.Add("@FirstName", Convert.ToString(model.FullName));
        //        parameters.Add("@LastName", "");
        //        parameters.Add("@DateOfBirth", model.DOB);
        //        parameters.Add("@CollegeCode", Convert.ToString(model.College));
        //        parameters.Add("@CollegeDescription", Convert.ToString(model.CollegeDesc));
        //        parameters.Add("@YearOFStudy", Convert.ToString(model.YearofStudy));
        //        parameters.Add("@USI", Convert.ToString(model.USIChessen));
        //        parameters.Add("@CHESSN", "");
        //        parameters.Add("@PersonalEmail", Convert.ToString(model.Email));
        //        parameters.Add("@MobilePhone", Convert.ToString(model.MobileNo));
        //        parameters.Add("@MailingAddressLine1", Convert.ToString(model.MailingAddressLine1));
        //        parameters.Add("@MailingAddressLine2", Convert.ToString(model.MailingAddressLine2));
        //        parameters.Add("@MailingCity", Convert.ToString(model.MailingCity));
        //        parameters.Add("@MailingState", Convert.ToString(model.MailingState));
        //        parameters.Add("@MailingPostCode", Convert.ToString(model.MailingPostCode));
        //        parameters.Add("@MailingCountry", Convert.ToString(model.MailingCountry));
        //        parameters.Add("@ShippingType", Convert.ToString(model.ShippingType));
        //        parameters.Add("@Comments", "Aumni Student");
        //        rowAffected = connection.Execute(DBConstant.UPSERTALUMNIORDER, parameters, commandType: CommandType.StoredProcedure);
        //    }
        //    return rowAffected;
        //}
        //private int GenrateLineNo(string orderId)
        //{
        //    OrderSummaryDetails orderSummary = GetOrderSummaries(orderId);
        //    if (orderSummary != null && orderSummary.OrderDetails.Count > 0)
        //    {
        //        return (orderSummary.OrderDetails.Count + 1);
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}
        //public OrderSummaryDetails GetOrderSummaries(string _orderId)
        //{
        //    OrderSummaryDetails orderSummary = new OrderSummaryDetails();
        //    using (var connection = CreateConnection())
        //    {
        //        var reader = connection.QueryMultiple(DBConstant.SELECTALUMNIORDER, param: new { OrderID = _orderId }, commandType: CommandType.StoredProcedure);
        //        List<Orders> orders = reader.Read<Orders>().ToList();
        //        List<OrderDetail> orderDetails = reader.Read<OrderDetail>().ToList();
        //        orderSummary.Orders = orders;
        //        orderSummary.OrderDetails = orderDetails;
        //    }
        //    return orderSummary;
        //}
        //public int UpdateAddress(Orders model)
        //{
        //    int rowAffected = 0;

        //    using (var connection = CreateConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", model.OrderID);
        //        //parameters.Add("@StudentID", model.StudentID);
        //        //parameters.Add("@FirstName", Convert.ToString(model.FirstName));
        //        //parameters.Add("@LastName", Convert.ToString(model.LastName));
        //        //parameters.Add("@DateOfBirth", model.DateOfBirth);
        //        //parameters.Add("@YearOFStudy", Convert.ToString(model.YearOFStudy));
        //        //parameters.Add("@USI", Convert.ToString(model.USI));
        //        //parameters.Add("@CHESSN", Convert.ToString(model.CHESSN));
        //        parameters.Add("@PersonalEmail", Convert.ToString(model.Email));
        //        //parameters.Add("@MobilePhone", Convert.ToString(model.MobilePhone));
        //        parameters.Add("@MailingAddressLine1", Convert.ToString(model.MailingAddressLine1));
        //        parameters.Add("@MailingAddressLine2", Convert.ToString(model.MailingAddressLine2));
        //        parameters.Add("@MailingCity", Convert.ToString(model.MailingCity));
        //        parameters.Add("@MailingState", Convert.ToString(model.MailingState));
        //        parameters.Add("@MailingPostCode", Convert.ToString(model.MailingPostCode));
        //        parameters.Add("@MailingCountry", Convert.ToString(model.MailingCountry));
        //        parameters.Add("@ShippingType", Convert.ToString(model.ShippingType));
        //        parameters.Add("@Comments", "Address Updated");
        //        rowAffected = connection.Execute(DBConstant.UPDATEMAILINGADDRESS, parameters, commandType: CommandType.StoredProcedure);
        //    }
        //    return rowAffected;
        //}
        //public bool Delete(OrderDetail order)
        //{
        //    int rowAffected = 0;
        //    using (var connection = CreateConnection())
        //    {
        //        var parameters = new { OrderID = order.OrderID, LineNumber = order.LineNumber, Comments = "Deleted by User" };
        //        rowAffected = connection.Execute(DBConstant.DELETEALUMNIORDERDETAIL, parameters, commandType: CommandType.StoredProcedure);
        //    }
        //    if (rowAffected > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //public Orders GetAddress(int _recId)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        var sql = "select * from tbl_Order where RecID = " + _recId;
        //        Orders orders = connection.QuerySingle<Orders>(sql);
        //        return orders;
        //    }
        //}
        //public IEnumerable<AddressType> GetAddressType()
        //{
        //    AddressType[] addressTypes =
        //     {
        //        new AddressType()
        //        {
        //            ID = "10001",
        //            Name = "Domestic"
        //        },
        //        new AddressType()
        //        {
        //            ID = "10002",
        //            Name = "International"
        //        }
        //     };
        //    return addressTypes;
        //}
        //public int AddCurrentOrderSummaries(CurrentStudent model)
        //{
        //    int rowAffected = 0;
        //    #region Commented for Not in Use
        //    using (var connection = CreateConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", model.OrderID);
        //        parameters.Add("@StudentID", model.StudentID);
        //        parameters.Add("@StudentType", "CURRENT");
        //        parameters.Add("@YearOFStudy", "");
        //        parameters.Add("@FirstName", model.FirstName);
        //        parameters.Add("@LastName", model.LastName);
        //        parameters.Add("@DateOfBirth", model.DOB);
        //        parameters.Add("@CollegeCode", model.College);
        //        parameters.Add("@CollegeDescription", model.CollegeDesc);
        //        parameters.Add("@YearOFStudy", model.Yearofstudy);
        //        parameters.Add("@USI", "");
        //        parameters.Add("@CHESSN", "");
        //        parameters.Add("@PersonalEmail", model.Email);
        //        parameters.Add("@MobilePhone", model.MobileNo);
        //        parameters.Add("@MailingAddressLine1", model.MailingAddressLine1);
        //        parameters.Add("@MailingAddressLine2", model.MailingAddressLine2);
        //        parameters.Add("@MailingCity", model.MailingCity);
        //        parameters.Add("@MailingState", model.MailingState);
        //        parameters.Add("@MailingPostCode", model.MailingPostCode);
        //        parameters.Add("@MailingCountry", model.MailingCountry);
        //        parameters.Add("@ShippingType", model.ShippingType);
        //        parameters.Add("@Order_omments", "Current Student");
        //        parameters.Add("@LineNumber", 1);
        //        parameters.Add("@OrderType", model.DocumentFormat);
        //        parameters.Add("@CourseCode", model.CourseCode);
        //        parameters.Add("@CourseDescription", model.CourseDesc);
        //        parameters.Add("@RequestedDocument", model.DocumentType);
        //        parameters.Add("@DocFormat", model.DocumentFormat);
        //        parameters.Add("@NumberOfCopies", model.DocumentCopies);
        //        parameters.Add("@Price", model.Price);
        //        parameters.Add("@TotalPrice", (model.Price * model.DocumentCopies));
        //        parameters.Add("@Comments", "Current Student");
        //        rowAffected = connection.Execute(DBConstant.INSERTALUMNIORDER_ORDERDETAIL, parameters, commandType: CommandType.StoredProcedure);
        //    }
        //    #endregion            
        //    return rowAffected;
        //}
        //public int AddMoreCurrentOrderDetails(CurrentStudent model)
        //{
        //    int rowAffected = 0;
        //    using (var connection = CreateConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", model.OrderID);
        //        parameters.Add("@LineNumber", model.LineNumber ? 1 : GenrateLineNo(model.OrderID));
        //        parameters.Add("@OrderDate", DateTime.Now);
        //        parameters.Add("@OrderType", Convert.ToString(model.ShippingType));
        //        parameters.Add("@CourseCode", Convert.ToString(model.CourseCode));
        //        parameters.Add("@CourseDescription", Convert.ToString(model.CourseDesc));
        //        parameters.Add("@CollegeCode", model.College);
        //        parameters.Add("@RequestedDocument", Convert.ToString(model.DocumentType));
        //        parameters.Add("@DocFormat", Convert.ToString(model.DocumentFormat));
        //        parameters.Add("@NumberOfCopies", Convert.ToString(model.DocumentCopies));
        //        parameters.Add("@Price", model.Price);
        //        parameters.Add("@TotalPrice", (model.Price * model.DocumentCopies));
        //        parameters.Add("@Comments", "Current Student Added Item");
        //        rowAffected = connection.Execute(DBConstant.UPSERTALUMNIORDERDETAIL, parameters, commandType: CommandType.StoredProcedure);

        //    }
        //    return rowAffected;
        //}
        //public int AddMoreCurrentOrder(CurrentStudent model)
        //{
        //    int rowAffected = 0;
        //    using (var connection = CreateConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", model.OrderID);
        //        parameters.Add("@StudentID", model.StudentID);
        //        parameters.Add("@StudentType", "CURRENT");
        //        parameters.Add("@FirstName", Convert.ToString(model.FirstName));
        //        parameters.Add("@LastName", Convert.ToString(model.LastName));
        //        parameters.Add("@DateOfBirth", null);
        //        parameters.Add("@CollegeCode", Convert.ToString(model.College));
        //        parameters.Add("@CollegeDescription", Convert.ToString(model.CollegeDesc));
        //        parameters.Add("@YearOFStudy", "");
        //        parameters.Add("@USI", "");
        //        parameters.Add("@CHESSN", "");
        //        parameters.Add("@PersonalEmail", Convert.ToString(model.Email));
        //        parameters.Add("@MobilePhone", Convert.ToString(model.MobileNo));
        //        parameters.Add("@MailingAddressLine1", Convert.ToString(model.MailingAddressLine1));
        //        parameters.Add("@MailingAddressLine2", Convert.ToString(model.MailingAddressLine2));
        //        parameters.Add("@MailingCity", Convert.ToString(model.MailingCity));
        //        parameters.Add("@MailingState", Convert.ToString(model.MailingState));
        //        parameters.Add("@MailingPostCode", Convert.ToString(model.MailingPostCode));
        //        parameters.Add("@MailingCountry", Convert.ToString(model.MailingCountry));
        //        parameters.Add("@ShippingType", Convert.ToString(model.ShippingType));
        //        parameters.Add("@Comments", "Current Student");
        //        rowAffected = connection.Execute(DBConstant.UPSERTALUMNIORDER, parameters, commandType: CommandType.StoredProcedure);
        //    }
        //    return rowAffected;
        //}
    }
}
