using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;
namespace fmsf.DAL
{
    public class DALCaseStudy
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();

        public int AddCaseStudySet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBCaseStudy objAssignment = new LIBCaseStudy();
                objAssignment = (LIBCaseStudy)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@CSCode", objAssignment.CSCode));
                objParamList.Add(new SqlParameter("@CourseId", objAssignment.CourseId));
                objParamList.Add(new SqlParameter("@SemId", objAssignment.SemesterId));
                objParamList.Add(new SqlParameter("@ModuleId", objAssignment.ModuleId));
                objParamList.Add(new SqlParameter("@PaperId", objAssignment.paperId));
                objParamList.Add(new SqlParameter("@TimeAllowted", objAssignment.TimeAllowted));
                objParamList.Add(new SqlParameter("@CaseStudyType", objAssignment.CaseStudyType));
                objParamList.Add(new SqlParameter("@CaseStudyPath", objAssignment.CaseStudyPath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertCaseStudySet", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetCaseStudySetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CourseId", objLIBAssignment.CourseId));

                objParamList.Add(new SqlParameter("@Year", objLIBAssignment.Year));
                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetCaseStudySetList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLibAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].CSId = Convert.ToInt32(ds.Tables[0].Rows[i]["CSId"].ToString());
                                objAssignmentListing[i].CSCode = ds.Tables[0].Rows[i]["CSCode"].ToString();
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objAssignmentListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objAssignmentListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objAssignmentListing[i].CreateDate = ds.Tables[0].Rows[i]["createdate"].ToString();
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objAssignmentListing[i].CaseStudyType = ds.Tables[0].Rows[i]["CaseStudyType"].ToString();
                                objAssignmentListing[i].CaseStudyPath = ds.Tables[0].Rows[i]["CaseStudyPath"].ToString();
                                objAssignmentListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int DeleteCaseStudy(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteCaseStudyset", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int UpdateCaseStudySet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBCaseStudy objAssignment = new LIBCaseStudy();
                objAssignment = (LIBCaseStudy)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@CSId", objAssignment.CSId));

                objParamList.Add(new SqlParameter("@TimeAllowted", objAssignment.TimeAllowted));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateCaseStudySet", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetCaseStudyInstruction(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));
                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCaseStudyInstruction", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLibAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].CourseTitle = (ds.Tables[0].Rows[i]["CourseTitle"].ToString());
                                objAssignmentListing[i].CourseCode = ds.Tables[0].Rows[i]["CourseCode"].ToString();
                                objAssignmentListing[i].CSCode = ds.Tables[0].Rows[i]["CSCode"].ToString();
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objAssignmentListing[i].CaseStudyText = ds.Tables[0].Rows[i]["CaseStudyText"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public int AddCaseStudyText(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBCaseStudy objAssignment = new LIBCaseStudy();
                objAssignment = (LIBCaseStudy)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@CSId", objAssignment.CSId));
                objParamList.Add(new SqlParameter("@CaseStudyText", objAssignment.CaseStudyText));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddCaseStudyText", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetBatchByCSId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));
                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchByCaseStudySet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLIBAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objAssignmentListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddActivateCaseStudySet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBCaseStudy objAssignment = new LIBCaseStudy();
                objAssignment = (LIBCaseStudy)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@CSId", objAssignment.CSId));
                objParamList.Add(new SqlParameter("@batchid", objAssignment.BatchId));
                objParamList.Add(new SqlParameter("@activatedate", objAssignment.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objAssignment.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddCaseStudyActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetActivateCaseStudySetData(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetActiveCaseStudyData", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int UpdateActivateCaseStudySet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBCaseStudy objAssignment = new LIBCaseStudy();
                objAssignment = (LIBCaseStudy)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@CSId", objAssignment.CSId));
                objParamList.Add(new SqlParameter("@batchid", objAssignment.BatchId));
                objParamList.Add(new SqlParameter("@activatedate", objAssignment.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objAssignment.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateActivateCaseStudy", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet ReportStudentActivateCaseStudy(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));
                objParamList.Add(new SqlParameter("@bid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@activate", objLIBAssignment.Activate));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ReportCaseStudyActvateStudentInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet StudentInActivateCaseStudy(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));


                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentListForActivateCaseStudy", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public TransportationPacket GetStudentCaseStudySetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UserId", objLIBAssignment.UserId));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentCaseStudySet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLibAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].CSId = Convert.ToInt32(ds.Tables[0].Rows[i]["CSId"].ToString());
                                objAssignmentListing[i].CSCode = ds.Tables[0].Rows[i]["CSCode"].ToString();
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objAssignmentListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objAssignmentListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objAssignmentListing[i].CaseStudyPath = ds.Tables[0].Rows[i]["CaseStudyPath"].ToString();
                                objAssignmentListing[i].CaseStudyType = ds.Tables[0].Rows[i]["CaseStudyType"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public string GetCaseStudyPathByCsId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetCaseStudyPath", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int AddUpdateOfflineCaseStudyAnswers(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibAssignment.UploadAnsPath));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddCaseStudyOfflineAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateOnlineCaseStudyAnswers(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@AnsText", objLibAssignment.AnsText));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibAssignment.UploadAnsPath));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddCaseStudyOnlineAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

       
        public TransportationPacket GetCaseStudyAnswers(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCaseStudyAnswers", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLibAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                
                                objAssignmentListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                                objAssignmentListing[i].UploadAnsPath = ds.Tables[0].Rows[i]["UploadAnsPath"].ToString();
                                objAssignmentListing[i].Feedback = ds.Tables[0].Rows[i]["Feedback"].ToString();
                               // objAssignmentListing[i].Review = Convert.ToBoolean(ds.Tables[0].Rows[i]["Review"]);
                               // objAssignmentListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetSubmitedCaseStudyByBatchId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));
                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedCaseStudyList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLIBAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].CSId = Convert.ToInt32(ds.Tables[0].Rows[i]["CSId"].ToString());
                                objAssignmentListing[i].CSCode = ds.Tables[0].Rows[i]["CSCode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public string GetCaseStudyTypeByCSId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetCaseStudyType", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public DataSet GetUserListBySubmiitedCaseStudy(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));
                //objParamList.Add(new SqlParameter("@activateDate", objLIBAssignment.activateDate));
                //objParamList.Add(new SqlParameter("@deactivateDate", objLIBAssignment.DeactivateDate));
                objParamList.Add(new SqlParameter("@CaseStudyType", objLIBAssignment.CaseStudyType));
                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetUserListSubmittedCaseStudy", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLIBAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].CSId = Convert.ToInt32(ds.Tables[0].Rows[i]["CSId"].ToString());
                                objAssignmentListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public TransportationPacket GetStudenInfo(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Studentid", objLibAssignment.StudentEmail));
                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLibAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].StudentName = (ds.Tables[0].Rows[i]["stuname"].ToString());
                                objAssignmentListing[i].Stid = Convert.ToInt32(ds.Tables[0].Rows[i]["stid"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetCaseStudyDate(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLibExam = new LIBCaseStudy();
                objLibExam = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLibExam.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                LIBCaseStudyListing objExamListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCaseStudyDate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLibExamInner = new LIBCaseStudy();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].activateDate = Convert.ToDateTime((ds.Tables[0].Rows[i]["activateDate"].ToString()));

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public string GetCaseStudyAnswerByCSId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLIBAssignment.UserId));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetCaseStudyAnswerOfflineandManual", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public DataSet GetCaseStudyDetailsById(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetCaseStudyDetails", objParamList);

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
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetAssignedCaseStudyttoFaculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CSId", objLIBAssignment.CSId));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignedCaseStudytoFaculty", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddUpdateCaseStudyToFaculty(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddCaseStudyToFaculty", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetCourse(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCaseStudy objLIBAssignmentInner = new LIBCaseStudy();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetCaseStudyListToFaculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
                objLIBAssignment = (LIBCaseStudy)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Username", objLIBAssignment.UserId));
                objParamList.Add(new SqlParameter("@bid", objLIBAssignment.BatchId));

                LIBCaseStudyListing objAssignmentListing = new LIBCaseStudyListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetListOfCaseStudyToFaculty", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBCaseStudyListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddUpdateCaseStudyFinalMarks(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@Fid", objLibAssignment.FacultyId));
                objParamList.Add(new SqlParameter("@Feedback", objLibAssignment.Feedback));
                objParamList.Add(new SqlParameter("@TotalMarks", objLibAssignment.TotalMarks));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateCaseStudyFinalMarks", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateManualCaseStudyFinalMarks(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCaseStudy objLibAssignment = new LIBCaseStudy();
                objLibAssignment = (LIBCaseStudy)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CSId", objLibAssignment.CSId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@Feedback", objLibAssignment.Feedback));
                objParamList.Add(new SqlParameter("@Fid", objLibAssignment.FacultyId));
                objParamList.Add(new SqlParameter("@TotalMarks", objLibAssignment.TotalMarks));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateManualCaseStudyFinalMarks", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        private void oppenconnection()
        {
            // strcon=ConfigurationManager.AppSettings["constring"];
            con = new SqlConnection();
            //con.ConnectionString = ConfigurationManager.AppSettings["conString"];
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            com.Connection = con;
            ada.SelectCommand = com;

        }

        private void closeconn()
        {
            //con.ConnectionString = ConfigurationManager.AppSettings["fmsfConnectionString2"];
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ConnectionString;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }
        public DataTable getdata(string sql)
        {

            oppenconnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            com.CommandType = CommandType.Text;
            com.CommandText = sql;
            ada.Fill(dt);
            return dt;
            closeconn();
        }

        public void ExeNQcomsp(string strQ)
        {
            String strSQLConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ConnectionString;

            SqlConnection con = new SqlConnection(strSQLConnectionString);

            SqlCommand ObjSqlCommand = null;
            int intReturnValue = 0;
            try
            {
                con.Open();
                ObjSqlCommand = new SqlCommand(strQ, con);
                intReturnValue = ObjSqlCommand.ExecuteNonQuery();
                ObjSqlCommand.Connection.Close();


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}