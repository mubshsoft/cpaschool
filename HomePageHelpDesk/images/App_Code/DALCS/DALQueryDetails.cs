using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;


namespace fmsf.DAL
{
    public class DALQueryDetails
    {
       
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        public DALQueryDetails()
        {
         }




        public DataSet GetQueryReport1(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Status", objLIBQueryDetails.Status));
                objParamList.Add(new SqlParameter("@FID", objLIBQueryDetails.FID));
                objParamList.Add(new SqlParameter("@bid", objLIBQueryDetails.bid));
                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_GetQueryReport", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                //LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                //objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);
                                //objLIBQueryDetailsListing[i].QuerySubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                                //objLIBQueryDetailsListing[i].Query = ds.Tables[0].Rows[i]["Query"].ToString();
                                //objLIBQueryDetailsListing[i].Reply = ds.Tables[0].Rows[i]["Reply"].ToString();
                                //objLIBQueryDetailsListing[i].QueryDate = ds.Tables[0].Rows[i]["QueryDate"].ToString();
                                //objLIBQueryDetailsListing[i].ReplyDate = ds.Tables[0].Rows[i]["ReplyDate"].ToString();
                                //objLIBQueryDetailsListing[i].QueryId = Convert.ToInt32(ds.Tables[0].Rows[i]["QueryId"].ToString());
                            }


                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }



        public TransportationPacket GetNumberOfQueries(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objLIBQueryDetails.stid));
                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetNumberOfQueries", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);

                                objLIBQueryDetailsListing[i].NumberofQueriesPosted = Convert.ToInt32(ds.Tables[0].Rows[i]["Number_Of_Queries"].ToString());
                                objLIBQueryDetailsListing[i].NumberofUnRepliedQueries = Convert.ToInt32(ds.Tables[0].Rows[i]["Number_Of_UnReplied_Queries"].ToString());
                            }


                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }



        public TransportationPacket GetStatus(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objLIBQueryDetails.stid));
                objParamList.Add(new SqlParameter("@Course", objLIBQueryDetails.Course));
                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetStatusForReport", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);

                                objLIBQueryDetailsListing[i].feeStauts = Convert.ToString(ds.Tables[0].Rows[i]["FeeStatus"].ToString());
                                objLIBQueryDetailsListing[i].Course = Convert.ToString(ds.Tables[0].Rows[i]["Course"].ToString());
                                objLIBQueryDetailsListing[i].Semester = Convert.ToString(ds.Tables[0].Rows[i]["Semester"].ToString());
                                objLIBQueryDetailsListing[i].CourseStauts = Convert.ToString(ds.Tables[0].Rows[i]["PassStatus"].ToString());
                            }


                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }









        public TransportationPacket GetQueryReport2(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_GetQueryReport2", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);
                                objLIBQueryDetailsListing[i].QuerySubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                                objLIBQueryDetailsListing[i].Query = ds.Tables[0].Rows[i]["Query"].ToString();
                                objLIBQueryDetailsListing[i].Reply = ds.Tables[0].Rows[i]["Reply"].ToString();
                                objLIBQueryDetailsListing[i].QueryDate = ds.Tables[0].Rows[i]["QueryDate"].ToString();
                                objLIBQueryDetailsListing[i].ReplyDate = ds.Tables[0].Rows[i]["ReplyDate"].ToString();
                                objLIBQueryDetailsListing[i].QueryId = Convert.ToInt32(ds.Tables[0].Rows[i]["QueryId"].ToString());
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetQueryReport3(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_GetQueryReport3", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);
                                objLIBQueryDetailsListing[i].QuerySubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                                objLIBQueryDetailsListing[i].Query = ds.Tables[0].Rows[i]["Query"].ToString();
                                objLIBQueryDetailsListing[i].Reply = ds.Tables[0].Rows[i]["Reply"].ToString();
                                objLIBQueryDetailsListing[i].QueryDate = ds.Tables[0].Rows[i]["QueryDate"].ToString();
                                objLIBQueryDetailsListing[i].ReplyDate = ds.Tables[0].Rows[i]["ReplyDate"].ToString();
                                objLIBQueryDetailsListing[i].QueryId = Convert.ToInt32(ds.Tables[0].Rows[i]["QueryId"].ToString());
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }



        public TransportationPacket GetQueryReport4(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_GetQueryReport4", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);
                                objLIBQueryDetailsListing[i].QuerySubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                                objLIBQueryDetailsListing[i].Query = ds.Tables[0].Rows[i]["Query"].ToString();
                                objLIBQueryDetailsListing[i].Reply = ds.Tables[0].Rows[i]["Reply"].ToString();
                                objLIBQueryDetailsListing[i].QueryDate = ds.Tables[0].Rows[i]["QueryDate"].ToString();
                                objLIBQueryDetailsListing[i].ReplyDate = ds.Tables[0].Rows[i]["ReplyDate"].ToString();
                                objLIBQueryDetailsListing[i].QueryId = Convert.ToInt32(ds.Tables[0].Rows[i]["QueryId"].ToString());
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }




        public TransportationPacket GetQueryReport5(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
              
                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_GetQueryReport5", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);
                                objLIBQueryDetailsListing[i].QuerySubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                                objLIBQueryDetailsListing[i].Query = ds.Tables[0].Rows[i]["Query"].ToString();
                                objLIBQueryDetailsListing[i].Reply = ds.Tables[0].Rows[i]["Reply"].ToString();
                                objLIBQueryDetailsListing[i].QueryDate = ds.Tables[0].Rows[i]["QueryDate"].ToString();
                                objLIBQueryDetailsListing[i].QueryId = Convert.ToInt32(ds.Tables[0].Rows[i]["QueryId"].ToString());
                                objLIBQueryDetailsListing[i].ReplyDate = ds.Tables[0].Rows[i]["ReplyDate"].ToString();
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }




        public TransportationPacket GetQueryReport6(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_GetQueryReport6", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);
                                objLIBQueryDetailsListing[i].QuerySubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                                objLIBQueryDetailsListing[i].Query = ds.Tables[0].Rows[i]["Query"].ToString();
                                objLIBQueryDetailsListing[i].Reply = ds.Tables[0].Rows[i]["Reply"].ToString();
                                objLIBQueryDetailsListing[i].QueryDate = ds.Tables[0].Rows[i]["QueryDate"].ToString();
                                objLIBQueryDetailsListing[i].ReplyDate = ds.Tables[0].Rows[i]["ReplyDate"].ToString();
                                objLIBQueryDetailsListing[i].QueryId = Convert.ToInt32(ds.Tables[0].Rows[i]["QueryId"].ToString());
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }


        public TransportationPacket GetNumberOfQueries4Faculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBQueryDetails objLIBQueryDetails = new LIBQueryDetails();
                objLIBQueryDetails = (LIBQueryDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@FID", objLIBQueryDetails.FID));
                LIBQueryDetailsListing objLIBQueryDetailsListing = new LIBQueryDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetNumberOfQueriesOf_Faculty", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBQueryDetails objLIBQueryDetailsInner = new LIBQueryDetails();
                                objLIBQueryDetailsListing.Add(objLIBQueryDetailsInner);

                                objLIBQueryDetailsListing[i].NumberofQueriesPosted = Convert.ToInt32(ds.Tables[0].Rows[i]["Number_Of_Queries"].ToString());
                                objLIBQueryDetailsListing[i].NumberofUnRepliedQueries = Convert.ToInt32(ds.Tables[0].Rows[i]["Number_Of_UnReplied_Queries"].ToString());
                                objLIBQueryDetailsListing[i].NumberofRepliedQueries = Convert.ToInt32(ds.Tables[0].Rows[i]["Number_Of_Replied_Queries"].ToString());
                            }


                        }
                    }
                }
                packet.MessageResultset = (LIBQueryDetailsListing)objLIBQueryDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

    }
}
