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
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using  fmsf.lib;


namespace fmsf.DAL
{
    public class DalAddStudent_CS
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();

        public TransportationPacket GetStudentlistforStudentReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {

                LIBStudent objStudent = new LIBStudent();
                objStudent = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@aid", objStudent.aid));
                LIBStudentListing objStudentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentCompleteDetails", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {


                                LIBStudent objStudentInner = new LIBStudent();
                                objStudentListing.Add(objStudentInner);



                                objStudentListing[i].StudentEmail = ds.Tables[0].Rows[i]["email"].ToString();

                                objStudentListing[i].FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                                objStudentListing[i].MiddleName = ds.Tables[0].Rows[i]["MiddleName"].ToString();
                                objStudentListing[i].LastName = ds.Tables[0].Rows[i]["LastName"].ToString();


                                objStudentListing[i].DOB = ds.Tables[0].Rows[i]["DOB"].ToString();
                                objStudentListing[i].Address1 = ds.Tables[0].Rows[i]["Address1"].ToString();
                                objStudentListing[i].Address2 = ds.Tables[0].Rows[i]["Address2"].ToString();
                                objStudentListing[i].ContactNumber1 = ds.Tables[0].Rows[i]["ContactNumber1"].ToString();
                                objStudentListing[i].ContactNumber2 = ds.Tables[0].Rows[i]["ContactNumber2"].ToString();
                                objStudentListing[i].Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                                objStudentListing[i].CuurentProfession = ds.Tables[0].Rows[i]["CurProfession"].ToString();
                                objStudentListing[i].Nationality = ds.Tables[0].Rows[i]["Nationality"].ToString();
                                objStudentListing[i].category = ds.Tables[0].Rows[i]["Category"].ToString();

                                objStudentListing[i].edboard1 = ds.Tables[0].Rows[i]["edboard1"].ToString();
                                objStudentListing[i].edstream1 = ds.Tables[0].Rows[i]["edstream1"].ToString();
                                objStudentListing[i].edmarks1 = ds.Tables[0].Rows[i]["edmarks1"].ToString();
                                objStudentListing[i].edyrs1 = ds.Tables[0].Rows[i]["edyrs1"].ToString();



                                objStudentListing[i].edboard2 = ds.Tables[0].Rows[i]["edboard2"].ToString();
                                objStudentListing[i].edstream2 = ds.Tables[0].Rows[i]["edstream2"].ToString();
                                objStudentListing[i].edmarks2 = ds.Tables[0].Rows[i]["edmarks2"].ToString();
                                objStudentListing[i].edyrs2 = ds.Tables[0].Rows[i]["edyrs2"].ToString();



                                objStudentListing[i].edboard3 = ds.Tables[0].Rows[i]["edboard3"].ToString();
                                objStudentListing[i].edstream3 = ds.Tables[0].Rows[i]["edstream3"].ToString();
                                objStudentListing[i].edmarks3 = ds.Tables[0].Rows[i]["edmarks3"].ToString();
                                objStudentListing[i].edyrs3 = ds.Tables[0].Rows[i]["edyrs3"].ToString();



                                objStudentListing[i].edboard4 = ds.Tables[0].Rows[i]["edboard4"].ToString();
                                objStudentListing[i].edstream4 = ds.Tables[0].Rows[i]["edstream4"].ToString();
                                objStudentListing[i].edmarks4 = ds.Tables[0].Rows[i]["edmarks4"].ToString();
                                objStudentListing[i].edyrs4 = ds.Tables[0].Rows[i]["edyrs4"].ToString();



                                objStudentListing[i].ExOrg1 = ds.Tables[0].Rows[i]["ExOrg1"].ToString();
                                objStudentListing[i].ExPh1 = ds.Tables[0].Rows[i]["ExPh1"].ToString();
                                objStudentListing[i].ExDesignation1 = ds.Tables[0].Rows[i]["ExDesignation1"].ToString();
                                objStudentListing[i].ExService1 = ds.Tables[0].Rows[i]["ExService1"].ToString();


                                objStudentListing[i].ExOrg2 = ds.Tables[0].Rows[i]["ExOrg2"].ToString();
                                objStudentListing[i].ExPh2 = ds.Tables[0].Rows[i]["ExPh2"].ToString();
                                objStudentListing[i].ExDesignation2 = ds.Tables[0].Rows[i]["ExDesignation2"].ToString();
                                objStudentListing[i].ExService2 = ds.Tables[0].Rows[i]["ExService2"].ToString();

                                objStudentListing[i].totExp = ds.Tables[0].Rows[i]["totexp"].ToString();
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objStudentListing;

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return packet;
        }

        public TransportationPacket GetStudentlistforStudentReportForActiveReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {

                LIBStudent objStudent = new LIBStudent();
                objStudent = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objStudent.stid));
                LIBStudentListing objStudentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentCompleteDetailsForActiveStudents", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {


                                LIBStudent objStudentInner = new LIBStudent();
                                objStudentListing.Add(objStudentInner);



                                objStudentListing[i].StudentEmail = ds.Tables[0].Rows[i]["email"].ToString();

                                objStudentListing[i].FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                                objStudentListing[i].MiddleName = ds.Tables[0].Rows[i]["MiddleName"].ToString();
                                objStudentListing[i].LastName = ds.Tables[0].Rows[i]["LastName"].ToString();


                                objStudentListing[i].DOB = ds.Tables[0].Rows[i]["DOB"].ToString();
                                objStudentListing[i].Address1 = ds.Tables[0].Rows[i]["Address1"].ToString();
                                objStudentListing[i].Address2 = ds.Tables[0].Rows[i]["Address2"].ToString();
                                objStudentListing[i].ContactNumber1 = ds.Tables[0].Rows[i]["ContactNumber1"].ToString();
                                objStudentListing[i].ContactNumber2 = ds.Tables[0].Rows[i]["ContactNumber2"].ToString();
                                objStudentListing[i].Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                                objStudentListing[i].CuurentProfession = ds.Tables[0].Rows[i]["CurProfession"].ToString();
                                objStudentListing[i].Nationality = ds.Tables[0].Rows[i]["Nationality"].ToString();
                                objStudentListing[i].category = ds.Tables[0].Rows[i]["Category"].ToString();

                                objStudentListing[i].edboard1 = ds.Tables[0].Rows[i]["edboard1"].ToString();
                                objStudentListing[i].edstream1 = ds.Tables[0].Rows[i]["edstream1"].ToString();
                                objStudentListing[i].edmarks1 = ds.Tables[0].Rows[i]["edmarks1"].ToString();
                                objStudentListing[i].edyrs1 = ds.Tables[0].Rows[i]["edyrs1"].ToString();



                                objStudentListing[i].edboard2 = ds.Tables[0].Rows[i]["edboard2"].ToString();
                                objStudentListing[i].edstream2 = ds.Tables[0].Rows[i]["edstream2"].ToString();
                                objStudentListing[i].edmarks2 = ds.Tables[0].Rows[i]["edmarks2"].ToString();
                                objStudentListing[i].edyrs2 = ds.Tables[0].Rows[i]["edyrs2"].ToString();



                                objStudentListing[i].edboard3 = ds.Tables[0].Rows[i]["edboard3"].ToString();
                                objStudentListing[i].edstream3 = ds.Tables[0].Rows[i]["edstream3"].ToString();
                                objStudentListing[i].edmarks3 = ds.Tables[0].Rows[i]["edmarks3"].ToString();
                                objStudentListing[i].edyrs3 = ds.Tables[0].Rows[i]["edyrs3"].ToString();



                                objStudentListing[i].edboard4 = ds.Tables[0].Rows[i]["edboard4"].ToString();
                                objStudentListing[i].edstream4 = ds.Tables[0].Rows[i]["edstream4"].ToString();
                                objStudentListing[i].edmarks4 = ds.Tables[0].Rows[i]["edmarks4"].ToString();
                                objStudentListing[i].edyrs4 = ds.Tables[0].Rows[i]["edyrs4"].ToString();



                                objStudentListing[i].ExOrg1 = ds.Tables[0].Rows[i]["ExOrg1"].ToString();
                                objStudentListing[i].ExPh1 = ds.Tables[0].Rows[i]["ExPh1"].ToString();
                                objStudentListing[i].ExDesignation1 = ds.Tables[0].Rows[i]["ExDesignation1"].ToString();
                                objStudentListing[i].ExService1 = ds.Tables[0].Rows[i]["ExService1"].ToString();


                                objStudentListing[i].ExOrg2 = ds.Tables[0].Rows[i]["ExOrg2"].ToString();
                                objStudentListing[i].ExPh2 = ds.Tables[0].Rows[i]["ExPh2"].ToString();
                                objStudentListing[i].ExDesignation2 = ds.Tables[0].Rows[i]["ExDesignation2"].ToString();
                                objStudentListing[i].ExService2 = ds.Tables[0].Rows[i]["ExService2"].ToString();

                                objStudentListing[i].totExp = ds.Tables[0].Rows[i]["totexp"].ToString();
                            }
                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objStudentListing;

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return packet;
        }







        public TransportationPacket GetStudentsInMultipleCourse(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objStudent = new LIBStudent();
                objStudent = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBStudentListing objStudentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentsInMultipleCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objStudentInner = new LIBStudent();
                                objStudentListing.Add(objStudentInner);
                                objStudentListing[i].StudentName = ds.Tables[0].Rows[i]["StudentName"].ToString();
                                objStudentListing[i].StudentEmail = ds.Tables[0].Rows[i]["StudentEmail"].ToString();
                                objStudentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                            }
                        }
                    }
                }

                packet.MessageResultset = (LIBStudentListing)objStudentListing;

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return packet;
        }



        public TransportationPacket GetStudentLoginReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objStudent = new LIBStudent();
                objStudent = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@fromDate", objStudent.fromDate));
                objParamList.Add(new SqlParameter("@toDate", objStudent.toDate));
                objParamList.Add(new SqlParameter("@batchid", objStudent.batchid));
                objParamList.Add(new SqlParameter("@Courseid", objStudent.Courseid));

                LIBStudentListing objStudentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentLoginReport", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objStudentInner = new LIBStudent();
                                objStudentListing.Add(objStudentInner);

                                objStudentListing[i].StudentLogId = Convert.ToInt32(ds.Tables[0].Rows[i]["StudentLogId"].ToString());
                                objStudentListing[i].StudentName = Convert.ToString(ds.Tables[0].Rows[i]["StudentName"].ToString());
                                objStudentListing[i].LoginFrom = Convert.ToString(ds.Tables[0].Rows[i]["LoginFrom"].ToString());
                                objStudentListing[i].LoginDate1 = Convert.ToString(ds.Tables[0].Rows[i]["LoginDate1"].ToString());
                                objStudentListing[i].LoginTime1 = Convert.ToString(ds.Tables[0].Rows[i]["LoginTime1"].ToString());
                                //objStudentListing[i].LoginOut = Convert.ToDateTime(ds.Tables[0].Rows[i]["LoginOut"].ToString());
                                objStudentListing[i].LoginOutTime1 = Convert.ToString(ds.Tables[0].Rows[i]["LoginOutTime1"].ToString());
                                //objStudentListing[i].THr =Convert.ToInt32(ds.Tables[0].Rows[i]["totalHour"].ToString());


                            }
                        }
                    }
                }

                packet.MessageResultset = (LIBStudentListing)objStudentListing;

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return packet;
        }



        public TransportationPacket GetActiveStudentLoginReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objStudent = new LIBStudent();
                objStudent = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@stid", objStudent.stid));


                LIBStudentListing objStudentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetActiveStudentLoginReport", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objStudentInner = new LIBStudent();
                                objStudentListing.Add(objStudentInner);

                                objStudentListing[i].StudentLogId = Convert.ToInt32(ds.Tables[0].Rows[i]["StudentLogId"].ToString());
                                objStudentListing[i].StudentName = Convert.ToString(ds.Tables[0].Rows[i]["StudentName"].ToString());
                                objStudentListing[i].LoginFrom = Convert.ToString(ds.Tables[0].Rows[i]["LoginFrom"].ToString());
                                objStudentListing[i].LoginDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["LoginDate"].ToString());
                                objStudentListing[i].LoginOut = Convert.ToDateTime(ds.Tables[0].Rows[i]["LoginOut"].ToString());



                            }
                        }
                    }
                }

                packet.MessageResultset = (LIBStudentListing)objStudentListing;

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return packet;
        }
        public TransportationPacket GetFacultyLastLoginReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objStudent = new LIBStudent();
                objStudent = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Fid", objStudent.Fid));


                LIBStudentListing objStudentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetFacultyLastLoginReport", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objStudentInner = new LIBStudent();
                                objStudentListing.Add(objStudentInner);

                                objStudentListing[i].FacultyLogId = Convert.ToInt32(ds.Tables[0].Rows[i]["FacultyLogId"].ToString());
                                objStudentListing[i].FacultyName = Convert.ToString(ds.Tables[0].Rows[i]["FacultyName"].ToString());
                                objStudentListing[i].LoginFrom = Convert.ToString(ds.Tables[0].Rows[i]["LoginFrom"].ToString());
                                objStudentListing[i].LoginDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["LoginDate"].ToString());
                                objStudentListing[i].LoginOut = Convert.ToDateTime(ds.Tables[0].Rows[i]["LoginOut"].ToString());



                            }
                        }
                    }
                }

                packet.MessageResultset = (LIBStudentListing)objStudentListing;

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return packet;
        }


        public TransportationPacket GetStudentDetails(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objStudent = new LIBStudent();
                objStudent = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@email", objStudent.StudentEmail));


                LIBStudentListing objStudentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_getUserDetail", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objStudentInner = new LIBStudent();
                                objStudentListing.Add(objStudentInner);

                                objStudentListing[i].stid =Convert.ToInt32(ds.Tables[0].Rows[i]["stid"].ToString());
                                objStudentListing[i].StudentEmail = ds.Tables[0].Rows[i]["email"].ToString();
                                objStudentListing[i].Password = Convert.ToString(ds.Tables[0].Rows[i]["password"].ToString());
                                objStudentListing[i].FirstName = Convert.ToString(ds.Tables[0].Rows[i]["firstname"].ToString());
                                objStudentListing[i].LastName = ds.Tables[0].Rows[i]["lastname"].ToString();
                                



                            }
                        }
                    }
                }

                packet.MessageResultset = (LIBStudentListing)objStudentListing;

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return packet;
        }
        public int CreateStudentIdCard(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)tp.MessagePacket;
                
                objParamList.Add(new SqlParameter("@batchid", objExam.batchid));
                objParamList.Add(new SqlParameter("@stid", objExam.stid));
                objParamList.Add(new SqlParameter("@email", objExam.StudentEmail));
                //objParamList.Add(new SqlParameter("@BatchCode", objExam.BatchCode));

                //objParamList.Add(new SqlParameter("@name", objExam.FirstName));
                //objParamList.Add(new SqlParameter("@dob", objExam.DOB));

                //objParamList.Add(new SqlParameter("@ProfileImage", objExam.ProfileImage));

               
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_StudentIdCard", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }


        public DataSet GetStudentDetailsforOnlienPayment(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objLIBAssignment = new LIBStudent();
                objLIBAssignment = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objLIBAssignment.stid));
                objParamList.Add(new SqlParameter("@cid", objLIBAssignment.Courseid));
                LIBStudentListing objAssignmentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("GetStudentDetails", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objLIBAssignmentInner = new LIBStudent();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].stid = Convert.ToInt32(ds.Tables[0].Rows[i]["stid"].ToString());
                                objAssignmentListing[i].StudentEmail = ds.Tables[0].Rows[i]["email"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddUpdateKnowledgeCenter(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ID", objLibExam.KCID));
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.Courseid));
                objParamList.Add(new SqlParameter("@Caption", objLibExam.Caption));
                objParamList.Add(new SqlParameter("@SubjectType ", objLibExam.KnowledgeCenterType));
                objParamList.Add(new SqlParameter("@KnowledgeCenterDescription", objLibExam.KnowledgeCenterDescription));
                objParamList.Add(new SqlParameter("@FileName", objLibExam.FileName));
                objParamList.Add(new SqlParameter("@FilePath", objLibExam.FilePath));
                objParamList.Add(new SqlParameter("@FileMode", objLibExam.FileMode));
                objParamList.Add(new SqlParameter("@URLlink", objLibExam.URLlink));
                objParamList.Add(new SqlParameter("@Check", objLibExam.Check));
               
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateKnowledgeCenter", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateDemofile(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ID", objLibExam.KCID));
                objParamList.Add(new SqlParameter("@Caption", objLibExam.Caption));
                objParamList.Add(new SqlParameter("@Type ", objLibExam.KnowledgeCenterType));
                //objParamList.Add(new SqlParameter("@Description", objLibExam.KnowledgeCenterDescription));
                objParamList.Add(new SqlParameter("@FileName", objLibExam.FileName));
                objParamList.Add(new SqlParameter("@FilePath", objLibExam.FilePath));
                objParamList.Add(new SqlParameter("@Check", objLibExam.Check));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateDemoManual", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdatTestimonials(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@stid", objLibExam.stid));
                objParamList.Add(new SqlParameter("@Description", objLibExam.KnowledgeCenterDescription));
                objParamList.Add(new SqlParameter("@Check", objLibExam.Check));
                //objParamList.Add(new SqlParameter("@courseId", objLibExam.Courseid));
                //objParamList.Add(new SqlParameter("@batchid", objLibExam.batchid));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateTestimonials", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateCallBack(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Name", objLibExam.StudentName));
                objParamList.Add(new SqlParameter("@Email", objLibExam.StudentEmail));
                objParamList.Add(new SqlParameter("@Mobile", objLibExam.ContactNumber1));
                
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateCallBack", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateInduction(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ID", objLibExam.KCID));
                objParamList.Add(new SqlParameter("@Caption", objLibExam.Caption));
                objParamList.Add(new SqlParameter("@CourseId ", objLibExam.Courseid));
                objParamList.Add(new SqlParameter("@Type ", objLibExam.KnowledgeCenterType));
                
                objParamList.Add(new SqlParameter("@FileName", objLibExam.FileName));
                objParamList.Add(new SqlParameter("@FilePath", objLibExam.FilePath));
                objParamList.Add(new SqlParameter("@Check", objLibExam.Check));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateInduction", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetKnowledgeCenterListByID(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@KCID", objLibExam.KCID));
                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetKnowledgeCenterListByID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objLibExamInner = new LIBStudent();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].KCID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                                objExamListing[i].Courseid = Convert.ToInt32(ds.Tables[0].Rows[i]["Courseid"].ToString());
                                objExamListing[i].Caption = ds.Tables[0].Rows[i]["Caption"].ToString();
                                objExamListing[i].KnowledgeCenterType = ds.Tables[0].Rows[i]["SubjectType"].ToString();
                              
                                objExamListing[i].KnowledgeCenterDescription = ds.Tables[0].Rows[i]["KnowledgeCenterDescription"].ToString();
                                objExamListing[i].FileName = ds.Tables[0].Rows[i]["FileName"].ToString();
                                objExamListing[i].FilePath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                objExamListing[i].FileMode = ds.Tables[0].Rows[i]["FileMode"].ToString();
                                objExamListing[i].URLlink = ds.Tables[0].Rows[i]["URLlink"].ToString();
                                objExamListing[i].Check = Convert.ToBoolean(ds.Tables[0].Rows[i]["Checked"].ToString());
                                
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public int DeleteKnowledgeCenter(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@KCID", objLibExam.KCID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteKnowledgeCenter", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int DeleteDemoFile(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ID", objLibExam.KCID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteDemoFile", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public DataSet GetKNDetails(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@KCID", objExam.KCID));

                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetKnowledgeCenterListByID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetDemoList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ID", objExam.KCID));

                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetDemoListByID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetTestimonialsList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objExam.stid));

                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GettestimonialsListByID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetCallbackList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Search", objExam.Search));

                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_CallBackList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetFAQList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Courseid", objExam.Courseid));
                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetFAQList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetInductionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ID", objExam.KCID));

                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetInductionListByID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int DeleteInductionFile(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ID", objLibExam.KCID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteInductionFile", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public DataSet GetSourceMaterialVideoList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objExam.Courseid));
                objParamList.Add(new SqlParameter("@stid", objExam.stid));
                objParamList.Add(new SqlParameter("@semid", objExam.SemesterId));
                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ListOfvideoBySemesterwise", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetSourceMaterialVideoList_Test(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objExam = new LIBStudent();
                objExam = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objExam.Courseid));
                objParamList.Add(new SqlParameter("@stid", objExam.stid));
                objParamList.Add(new SqlParameter("@semid", objExam.SemesterId));
                LIBStudentListing objExamListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ListOfvideoBySemesterwise_test", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int AddNote(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Userid", objLibExam.stid));
                objParamList.Add(new SqlParameter("CourseId", objLibExam.Courseid));
                objParamList.Add(new SqlParameter("@UnitId", objLibExam.UnitId));
                objParamList.Add(new SqlParameter("@Note", objLibExam.Note));
               
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddNote", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public LIBStudentListing GetNoteList(TransportationPacket tp)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> objParamList = new List<SqlParameter>();
            LIBStudentListing objLIBUSERSListing = new LIBStudentListing();

            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;

                objParamList.Add(new SqlParameter("@Userid", objLibExam.stid));
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.Courseid));
                objParamList.Add(new SqlParameter("@UnitId", objLibExam.UnitId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetNoteByUser", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (Int16 i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    LIBStudent oLIBUSERS = new LIBStudent();
                                    objLIBUSERSListing.Add(oLIBUSERS);
                                    objLIBUSERSListing[i].Note = ds.Tables[0].Rows[i]["Note"].ToString();
                                    objLIBUSERSListing[i].Caption = ds.Tables[0].Rows[i]["Dtt"].ToString();
                                    objLIBUSERSListing[i].RowNumber = ds.Tables[0].Rows[i]["RowNumber"].ToString();

                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Throw ex   
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return objLIBUSERSListing;
        }

        public LIBStudentListing GetEmailAddress(TransportationPacket tp)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> objParamList = new List<SqlParameter>();
            LIBStudentListing objLIBUSERSListing = new LIBStudentListing();

            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;

                objParamList.Add(new SqlParameter("@StudentEmail", objLibExam.StudentEmail));
               

                ds = objDbConnection.ExecuteSPDataSet("SP_GetNoteByUser", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (Int16 i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    LIBStudent oLIBUSERS = new LIBStudent();
                                    objLIBUSERSListing.Add(oLIBUSERS);
                                    objLIBUSERSListing[i].StudentEmail = ds.Tables[0].Rows[i]["StudentEmail"].ToString();
                                   
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Throw ex   
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return objLIBUSERSListing;
        }

        public DataSet GetNotificationList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBStudent objLIBAssignment = new LIBStudent();
                objLIBAssignment = (LIBStudent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objLIBAssignment.stid));
                
                LIBStudentListing objAssignmentListing = new LIBStudentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_NotificationList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBStudent objLIBAssignmentInner = new LIBStudent();
                                //objAssignmentListing.Add(objLIBAssignmentInner);
                                //objAssignmentListing[i].stid = Convert.ToInt32(ds.Tables[0].Rows[i]["stid"].ToString());
                                //objAssignmentListing[i].StudentEmail = ds.Tables[0].Rows[i]["email"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBStudentListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public LIBStudentListing GetVideoPathList(TransportationPacket tp)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> objParamList = new List<SqlParameter>();
            LIBStudentListing objLIBUSERSListing = new LIBStudentListing();

            try
            {
                LIBStudent objLibExam = new LIBStudent();
                objLibExam = (LIBStudent)tp.MessagePacket;

               
                objParamList.Add(new SqlParameter("@PaperId", objLibExam.PaperId));
                objParamList.Add(new SqlParameter("@UnitId", objLibExam.UnitId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetVideoPath", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (Int16 i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    LIBStudent oLIBUSERS = new LIBStudent();
                                    objLIBUSERSListing.Add(oLIBUSERS);
                                    objLIBUSERSListing[i].CourseCode = ds.Tables[0].Rows[i]["CourseCode"].ToString();
                                    objLIBUSERSListing[i].FilePath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                   

                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Throw ex   
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return objLIBUSERSListing;
        }
    }
}



