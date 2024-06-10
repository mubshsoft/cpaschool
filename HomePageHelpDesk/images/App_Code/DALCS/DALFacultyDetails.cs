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
    public class DALFacultyDetails
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();

        public DALFacultyDetails()
        {
        }



        public TransportationPacket GetFacultyReport1(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
                objLIBFacultyDetails = (LIBFacultyDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
                objParamList.Add(new SqlParameter("Fid", objLIBFacultyDetails.Fid));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetFacultyReport1", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBFacultyDetails objLIBFacultyDetailsInner = new LIBFacultyDetails();
                                objLIBFacultyDetailsListing.Add(objLIBFacultyDetailsInner);
                                objLIBFacultyDetailsListing[i].CourseTitle = Convert.ToString(ds.Tables[0].Rows[i]["CourseTitle"].ToString());
                                objLIBFacultyDetailsListing[i].SemesterTitle = Convert.ToString(ds.Tables[0].Rows[i]["SemesterTitle"].ToString());
                                objLIBFacultyDetailsListing[i].ModuleTitle = Convert.ToString(ds.Tables[0].Rows[i]["ModuleTitle"].ToString());
                                objLIBFacultyDetailsListing[i].PaperTitle = Convert.ToString(ds.Tables[0].Rows[i]["PaperTitle"].ToString());
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBFacultyDetailsListing)objLIBFacultyDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetFacultyLoginReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
                objLIBFacultyDetails = (LIBFacultyDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
                objParamList.Add(new SqlParameter("fromDate", objLIBFacultyDetails.fromDate));
                objParamList.Add(new SqlParameter("toDate", objLIBFacultyDetails.toDate));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetFacultyLoginReport", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBFacultyDetails objLIBFacultyDetailsInner = new LIBFacultyDetails();
                                objLIBFacultyDetailsListing.Add(objLIBFacultyDetailsInner);
                                objLIBFacultyDetailsListing[i].FacultyLogId = Convert.ToInt32(ds.Tables[0].Rows[i]["FacultyLogId"].ToString());
                                objLIBFacultyDetailsListing[i].FacultyName = Convert.ToString(ds.Tables[0].Rows[i]["FacultyName"].ToString());
                                objLIBFacultyDetailsListing[i].loginfrom = Convert.ToString(ds.Tables[0].Rows[i]["loginfrom"].ToString());
                                //objLIBFacultyDetailsListing[i].logInDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["logInDate"].ToString());
                                //objLIBFacultyDetailsListing[i].logOutDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["LoginOut"].ToString());
                                objLIBFacultyDetailsListing[i].logInDate1 = Convert.ToString(ds.Tables[0].Rows[i]["logInDate1"].ToString());
                                objLIBFacultyDetailsListing[i].logInTime1 = Convert.ToString(ds.Tables[0].Rows[i]["logInTime1"].ToString());
                                objLIBFacultyDetailsListing[i].logOutTime1 = Convert.ToString(ds.Tables[0].Rows[i]["logOutTime1"].ToString());
                                //objLIBFacultyDetailsListing[i].THr = Convert.ToInt32(ds.Tables[0].Rows[i]["totalHour"].ToString());
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBFacultyDetailsListing)objLIBFacultyDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }








        public TransportationPacket GetFacultyNameforReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
                objLIBFacultyDetails = (LIBFacultyDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_GetFacultyNameForReport", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                LIBFacultyDetails objLIBFacultyDetailsInner = new LIBFacultyDetails();
                                objLIBFacultyDetailsListing.Add(objLIBFacultyDetailsInner);
                                objLIBFacultyDetailsListing[i].FacultyName = ds.Tables[0].Rows[i]["FacultyName"].ToString();
                                objLIBFacultyDetailsListing[i].Fid = Convert.ToInt32(ds.Tables[0].Rows[i]["Fid"].ToString());
                                objLIBFacultyDetailsListing[i].Email = ds.Tables[0].Rows[i]["Email"].ToString();
                                objLIBFacultyDetailsListing[i].ContactNumber1 = ds.Tables[0].Rows[i]["contactnumber1"].ToString();
                                objLIBFacultyDetailsListing[i].Address1 = ds.Tables[0].Rows[i]["address1"].ToString();
                                objLIBFacultyDetailsListing[i].PaperTitle = ds.Tables[0].Rows[i]["paperassigned"].ToString();
                                objLIBFacultyDetailsListing[i].CourseTitle = ds.Tables[0].Rows[i]["course"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBFacultyDetailsListing)objLIBFacultyDetailsListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }



        public TransportationPacket GetFacultyCompleteReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
                objLIBFacultyDetails = (LIBFacultyDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
                objParamList.Add(new SqlParameter("Fid", objLIBFacultyDetails.Fid));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetFacultyCompleteReport", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBFacultyDetails objLIBFacultyDetailsInner = new LIBFacultyDetails();
                                objLIBFacultyDetailsListing.Add(objLIBFacultyDetailsInner);
                                objLIBFacultyDetailsListing[i].Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"].ToString());
                                objLIBFacultyDetailsListing[i].firstName = Convert.ToString(ds.Tables[0].Rows[i]["firstName"].ToString());
                                objLIBFacultyDetailsListing[i].MiddleName = Convert.ToString(ds.Tables[0].Rows[i]["MiddleName"].ToString());
                                objLIBFacultyDetailsListing[i].LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"].ToString());
                                objLIBFacultyDetailsListing[i].DOB = Convert.ToString(ds.Tables[0].Rows[i]["DOB"].ToString());
                                objLIBFacultyDetailsListing[i].Address1 = Convert.ToString(ds.Tables[0].Rows[i]["Address1"].ToString());
                                objLIBFacultyDetailsListing[i].Address2 = Convert.ToString(ds.Tables[0].Rows[i]["Address2"].ToString());
                                objLIBFacultyDetailsListing[i].ContactNumber1 = Convert.ToString(ds.Tables[0].Rows[i]["ContactNumber1"].ToString());
                                objLIBFacultyDetailsListing[i].ContactNumber2 = Convert.ToString(ds.Tables[0].Rows[i]["ContactNumber2"].ToString());
                                objLIBFacultyDetailsListing[i].Gender = Convert.ToString(ds.Tables[0].Rows[i]["Gender"].ToString());
                                objLIBFacultyDetailsListing[i].Nationality = Convert.ToString(ds.Tables[0].Rows[i]["Nationality"].ToString());
                                objLIBFacultyDetailsListing[i].category = Convert.ToString(ds.Tables[0].Rows[i]["category"].ToString());
                                objLIBFacultyDetailsListing[i].Profile = Convert.ToString(ds.Tables[0].Rows[i]["Profile"].ToString());



                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBFacultyDetailsListing)objLIBFacultyDetailsListing;
            }



            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }




        public TransportationPacket GetFacultyPaperReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
                objLIBFacultyDetails = (LIBFacultyDetails)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
                objParamList.Add(new SqlParameter("Fid", objLIBFacultyDetails.Fid));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetFacultyPaperReport", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBFacultyDetails objLIBFacultyDetailsInner = new LIBFacultyDetails();
                                objLIBFacultyDetailsListing.Add(objLIBFacultyDetailsInner);
                                objLIBFacultyDetailsListing[i].PaperId = Convert.ToInt32(ds.Tables[0].Rows[i]["PaperId"].ToString());
                                objLIBFacultyDetailsListing[i].PaperTitle = Convert.ToString(ds.Tables[0].Rows[i]["PaperTitle"].ToString());
                                
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBFacultyDetailsListing)objLIBFacultyDetailsListing;
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
