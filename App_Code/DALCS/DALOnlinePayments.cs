using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;
namespace fmsf.DAL
{
public class DALOnlinePayments
{   

        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();

        public int InsertOnlinePayment(TransportationPacket tp)
    {

        int Result = 0;
        try
        {
            string[] strResult;
            LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
            objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();
            objParamList.Add(new SqlParameter("@TID", objLIBOnlinePayments.TID));
            objParamList.Add(new SqlParameter("@Status", objLIBOnlinePayments.Status));
            objParamList.Add(new SqlParameter("@ID", objLIBOnlinePayments.ID));
            objParamList.Add(new SqlParameter("@SiteId", objLIBOnlinePayments.SiteId));
            objParamList.Add(new SqlParameter("@SiteTransactionId", objLIBOnlinePayments.SiteTransactionId));
            objParamList.Add(new SqlParameter("@OrderID", objLIBOnlinePayments.OrderID));
            objParamList.Add(new SqlParameter("@BankTransactionId", objLIBOnlinePayments.BankTransactionId));
            objParamList.Add(new SqlParameter("@BankAuthorisationCode", objLIBOnlinePayments.BankAuthorisationCode));
            objParamList.Add(new SqlParameter("@DisplayResponse", objLIBOnlinePayments.DisplayResponse));
            objParamList.Add(new SqlParameter("@CurrId", objLIBOnlinePayments.CurrId));
            objParamList.Add(new SqlParameter("@OrderDetails", objLIBOnlinePayments.OrderDetails));
            objParamList.Add(new SqlParameter("@Method", objLIBOnlinePayments.Method));
            objParamList.Add(new SqlParameter("@MethodCode", objLIBOnlinePayments.MethodCode));
            objParamList.Add(new SqlParameter("@TransactionDate", objLIBOnlinePayments.TransactionDate));
            objParamList.Add(new SqlParameter("@Type", objLIBOnlinePayments.Type));
            objParamList.Add(new SqlParameter("@Amount", objLIBOnlinePayments.Amount));
            strResult = objDbConnection.ExecuteSPNonQueryOutPut("JP_InsertOnlinePayment", objParamList, objParamListOut);
            Result = strResult.Length;
        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return Result;



    }
    public int UpdateOnlinePayment(TransportationPacket tp)
    {

        int Result = 0;
        try
        {
            string[] strResult;
            LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
            objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();
           
            objParamList.Add(new SqlParameter("@Status", objLIBOnlinePayments.Status));
            objParamList.Add(new SqlParameter("@ID", objLIBOnlinePayments.ID));
            objParamList.Add(new SqlParameter("@SiteId", objLIBOnlinePayments.SiteId));
            objParamList.Add(new SqlParameter("@SiteTransactionId", objLIBOnlinePayments.SiteTransactionId));
            objParamList.Add(new SqlParameter("@OrderID", objLIBOnlinePayments.OrderID));
            objParamList.Add(new SqlParameter("@BankTransactionId", objLIBOnlinePayments.BankTransactionId));
            objParamList.Add(new SqlParameter("@BankAuthorisationCode", objLIBOnlinePayments.BankAuthorisationCode));
            objParamList.Add(new SqlParameter("@DisplayResponse", objLIBOnlinePayments.DisplayResponse));
            objParamList.Add(new SqlParameter("@CurrId", objLIBOnlinePayments.CurrId));
            objParamList.Add(new SqlParameter("@Method", objLIBOnlinePayments.Method));
            objParamList.Add(new SqlParameter("@MethodCode", objLIBOnlinePayments.MethodCode));
            objParamList.Add(new SqlParameter("@paymentstatus", objLIBOnlinePayments.PaymentStatus));
           // objParamList.Add(new SqlParameter("@TID", objLIBOnlinePayments.TID));
            strResult = objDbConnection.ExecuteSPNonQueryOutPut("JP_UpdateOnlinePayment", objParamList, objParamListOut);
            Result = strResult.Length;
        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return Result;



    }
    public int UpdateOnlinePayment4HardCopy(TransportationPacket tp)
    {

        int Result = 0;
        try
        {
            string[] strResult;
            LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
            objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();

           
            objParamList.Add(new SqlParameter("@UserID", objLIBOnlinePayments.UserID));
            objParamList.Add(new SqlParameter("@Paymentstatus", objLIBOnlinePayments.PaymentStatus));
            strResult = objDbConnection.ExecuteSPNonQueryOutPut("JP_UpdateOnlinePayment4HardCopy", objParamList, objParamListOut);
            Result = strResult.Length;
        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return Result;



    }
    public int InsertOnlinePaymentJ(TransportationPacket tp)
    {

        int Result = 0;
        try
        {
            string[] strResult;
            LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
            objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();
            objParamList.Add(new SqlParameter("@TID", objLIBOnlinePayments.TID));
            objParamList.Add(new SqlParameter("@Status", objLIBOnlinePayments.Status));
            objParamList.Add(new SqlParameter("@ID", objLIBOnlinePayments.ID));
            objParamList.Add(new SqlParameter("@SiteId", objLIBOnlinePayments.SiteId));
            objParamList.Add(new SqlParameter("@SiteTransactionId", objLIBOnlinePayments.SiteTransactionId));
            objParamList.Add(new SqlParameter("@OrderID", objLIBOnlinePayments.OrderID));
            objParamList.Add(new SqlParameter("@BankTransactionId", objLIBOnlinePayments.BankTransactionId));
            objParamList.Add(new SqlParameter("@BankAuthorisationCode", objLIBOnlinePayments.BankAuthorisationCode));
            objParamList.Add(new SqlParameter("@DisplayResponse", objLIBOnlinePayments.DisplayResponse));
            objParamList.Add(new SqlParameter("@CurrId", objLIBOnlinePayments.CurrId));
            objParamList.Add(new SqlParameter("@OrderDetails", objLIBOnlinePayments.OrderDetails));
            objParamList.Add(new SqlParameter("@Method", objLIBOnlinePayments.Method));
            objParamList.Add(new SqlParameter("@MethodCode", objLIBOnlinePayments.MethodCode));
            objParamList.Add(new SqlParameter("@TransactionDate", objLIBOnlinePayments.TransactionDate));
            //objParamList.Add(new SqlParameter("@Type", objLIBOnlinePayments.Type));
            objParamList.Add(new SqlParameter("@Amount", objLIBOnlinePayments.Amount));
            strResult = objDbConnection.ExecuteSPNonQueryOutPut("JP_InsertOnlinePaymentJ", objParamList, objParamListOut);
            Result = strResult.Length;
        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return Result;



    }
    public int UpdateOnlinePaymentJ(TransportationPacket tp)
    {

        int Result = 0;
        try
        {
            string[] strResult;
            LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
            objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();

            objParamList.Add(new SqlParameter("@Status", objLIBOnlinePayments.Status));
            objParamList.Add(new SqlParameter("@ID", objLIBOnlinePayments.ID));
            objParamList.Add(new SqlParameter("@SiteId", objLIBOnlinePayments.SiteId));
            objParamList.Add(new SqlParameter("@SiteTransactionId", objLIBOnlinePayments.SiteTransactionId));
            objParamList.Add(new SqlParameter("@OrderID", objLIBOnlinePayments.OrderID));
            objParamList.Add(new SqlParameter("@BankTransactionId", objLIBOnlinePayments.BankTransactionId));
            objParamList.Add(new SqlParameter("@BankAuthorisationCode", objLIBOnlinePayments.BankAuthorisationCode));
            objParamList.Add(new SqlParameter("@DisplayResponse", objLIBOnlinePayments.DisplayResponse));
            objParamList.Add(new SqlParameter("@CurrId", objLIBOnlinePayments.CurrId));
            objParamList.Add(new SqlParameter("@Method", objLIBOnlinePayments.Method));
            objParamList.Add(new SqlParameter("@MethodCode", objLIBOnlinePayments.MethodCode));
            objParamList.Add(new SqlParameter("@paymentstatus", objLIBOnlinePayments.PaymentStatus));

            strResult = objDbConnection.ExecuteSPNonQueryOutPut("JP_UpdateOnlinePaymentJ", objParamList, objParamListOut);
            Result = strResult.Length;
        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return Result;



    }

    //wahid
    public int InsertOnlinePurchase4Payment(TransportationPacket tp)
    {

        int Result = 0;
        try
        {
            string[] strResult;
            LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
            objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();
            objParamList.Add(new SqlParameter("@USERID", objLIBOnlinePayments.UserID));
            objParamList.Add(new SqlParameter("@Status", objLIBOnlinePayments.Status));
            objParamList.Add(new SqlParameter("@ID", objLIBOnlinePayments.ID));
            objParamList.Add(new SqlParameter("@SiteId", objLIBOnlinePayments.SiteId));
            objParamList.Add(new SqlParameter("@SiteTransactionId", objLIBOnlinePayments.SiteTransactionId));
            objParamList.Add(new SqlParameter("@OrderID", objLIBOnlinePayments.OrderID));
            objParamList.Add(new SqlParameter("@BankTransactionId", objLIBOnlinePayments.BankTransactionId));
            objParamList.Add(new SqlParameter("@BankAuthorisationCode", objLIBOnlinePayments.BankAuthorisationCode));
            objParamList.Add(new SqlParameter("@DisplayResponse", objLIBOnlinePayments.DisplayResponse));
            objParamList.Add(new SqlParameter("@CurrId", objLIBOnlinePayments.CurrId));
            objParamList.Add(new SqlParameter("@OrderDetails", objLIBOnlinePayments.OrderDetails));
            objParamList.Add(new SqlParameter("@Method", objLIBOnlinePayments.Method));
            objParamList.Add(new SqlParameter("@MethodCode", objLIBOnlinePayments.MethodCode));
            objParamList.Add(new SqlParameter("@TransactionDate", objLIBOnlinePayments.TransactionDate));
            objParamList.Add(new SqlParameter("@TYPE", objLIBOnlinePayments.Type));
            objParamList.Add(new SqlParameter("@Amount", objLIBOnlinePayments.Amount));
            strResult = objDbConnection.ExecuteSPNonQueryOutPut("JP_InsertOnlinePurchase4Payment", objParamList, objParamListOut);
            Result = strResult.Length;
        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return Result;



    }





    public int UpdateOnlinePurchase4Payment(TransportationPacket tp)
    {

        int Result = 0;
        try
        {
            string[] strResult;
            LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
            objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

            List<SqlParameter> objParamList = new List<SqlParameter>();
            List<SqlParameter> objParamListOut = new List<SqlParameter>();

            objParamList.Add(new SqlParameter("@Status", objLIBOnlinePayments.Status));
            objParamList.Add(new SqlParameter("@ID", objLIBOnlinePayments.ID));
            objParamList.Add(new SqlParameter("@SiteId", objLIBOnlinePayments.SiteId));
            objParamList.Add(new SqlParameter("@SiteTransactionId", objLIBOnlinePayments.SiteTransactionId));
            objParamList.Add(new SqlParameter("@OrderID", objLIBOnlinePayments.OrderID));
            objParamList.Add(new SqlParameter("@BankTransactionId", objLIBOnlinePayments.BankTransactionId));
            objParamList.Add(new SqlParameter("@BankAuthorisationCode", objLIBOnlinePayments.BankAuthorisationCode));
            objParamList.Add(new SqlParameter("@DisplayResponse", objLIBOnlinePayments.DisplayResponse));
            objParamList.Add(new SqlParameter("@CurrId", objLIBOnlinePayments.CurrId));
            objParamList.Add(new SqlParameter("@Method", objLIBOnlinePayments.Method));
            objParamList.Add(new SqlParameter("@MethodCode", objLIBOnlinePayments.MethodCode));
            strResult = objDbConnection.ExecuteSPNonQueryOutPut("JP_UpdateOnlinePurchase4Payment", objParamList, objParamListOut);
            Result = strResult.Length;
        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return Result;



    }

        public string[] InsertPayment4DD(TransportationPacket tp, ref Int16 Result)
        {

            //int Result = 0;
            string[] strResult=null ;
            try
            {
               
                LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
                objLIBOnlinePayments = (LIBOnlinePayments)tp.MessagePacket;

                List<SqlParameter> objParamList = new List<SqlParameter>();
                List<SqlParameter> objParamListOut = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@DDNo", objLIBOnlinePayments.DDNo));
                objParamList.Add(new SqlParameter("@Amount", objLIBOnlinePayments.Amount));
                objParamList.Add(new SqlParameter("@BranchName", objLIBOnlinePayments.BranchName));
                objParamList.Add(new SqlParameter("@BankName", objLIBOnlinePayments.BankName));
                objParamList.Add(new SqlParameter("@PaymentMode", objLIBOnlinePayments.PaymentMode));
                objParamList.Add(new SqlParameter("@PaymentType", objLIBOnlinePayments.PaymentType));
                objParamList.Add(new SqlParameter("@stid", objLIBOnlinePayments.stid));
                objParamList.Add(new SqlParameter("@CourseId", objLIBOnlinePayments.CourseId));
                objParamList.Add(new SqlParameter("@SemId", objLIBOnlinePayments.SemId));
                objParamList.Add(new SqlParameter("@DDdate", objLIBOnlinePayments.DDdate));
                objParamListOut.Add(new SqlParameter("@RETURNVALUE", SqlDbType.Int));

                strResult = objDbConnection.ExecuteSPNonQueryOutPut("SP_InsertUpdatepayment", objParamList, objParamListOut);
              //  Result = strResult.Length;
            }
            catch (Exception ex)
            {

                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return strResult;



        }

        public DataSet GetUserPaymentsDetails(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBOnlinePayments objLIBOnlinePayments = new LIBOnlinePayments();
                objLIBOnlinePayments = (LIBOnlinePayments)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CourseId", objLIBOnlinePayments.CourseId));
                objParamList.Add(new SqlParameter("@stid", objLIBOnlinePayments.stid));
                objParamList.Add(new SqlParameter("@PaymentMode", objLIBOnlinePayments.PaymentMode));

                ds = objDbConnection.ExecuteSPDataSet("SP_UserPaymentsDetails", objParamList);
            }
            catch (Exception ex)
            {
                //packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            finally
            {
            }
            return ds;
        }
    }
}
