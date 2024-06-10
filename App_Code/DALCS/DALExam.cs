using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;
namespace fmsf.DAL
{
    public class DALExam
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        public DataSet GetDatedetail(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objExam.UserId));
                objParamList.Add(new SqlParameter("@BatchId", objExam.BatchId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetDatedetail", objParamList);

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
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetBatchClosuredetail(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objExam.CourseId));
                objParamList.Add(new SqlParameter("@UserId", objExam.UserId));
                objParamList.Add(new SqlParameter("@BatchId", objExam.BatchId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_BatchClosuredetail", objParamList);

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
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public TransportationPacket GetExamSetList_(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));

                objParamList.Add(new SqlParameter("@Year", objLIBExam.Year));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetExamSetList_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());
                                objExamListing[i].examcode = ds.Tables[0].Rows[i]["ExamCode"].ToString();
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objExamListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objExamListing[i].CreateDate = ds.Tables[0].Rows[i]["CreateDate"].ToString();
                                objExamListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetActivateExamSetData_(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));

                objParamList.Add(new SqlParameter("@Year", objLIBExam.Year));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetActiveExamData_", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int DeleteExamCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteExamCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddExamCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CategoryName", objLibExam.CategoryName));

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddExamCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }


        public int DeleteExamQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteExamSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSubQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibExam.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteSubQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibExam.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSubQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteExam(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteExam", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteCourseDetail(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteCourseDetail", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateExamQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibExam.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibExam.Answer));
                objParamList.Add(new SqlParameter("@MaxQueMarks", objLibExam.MaxQueMarks));
                objParamList.Add(new SqlParameter("@Descriptive", objLibExam.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibExam.QUESTYPE));
                //objParamList.Add(new SqlParameter("@QuesNo ", objLibExam.QuesNo));
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@CategoryId", objLibExam.CategoryID));
                objParamList.Add(new SqlParameter("@UploadQuestionImagePath", objLibExam.UploadQuestionImagePath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateExamQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateExamSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibExam.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibExam.Answer));
                objParamList.Add(new SqlParameter("@Type", objLibExam.Type));
                objParamList.Add(new SqlParameter("@Descriptive", objLibExam.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibExam.QUESTYPE));
                objParamList.Add(new SqlParameter("@QuesNo ", objLibExam.QuesNo));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));
                //objParamList.Add(new SqlParameter("@CategoryId", objLibExam.CategoryID));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateExamSubQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddQueInSection(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ExamId", objExam.ExamId));
                objParamList.Add(new SqlParameter("@CategoryId", objExam.CategoryID));
                objParamList.Add(new SqlParameter("@MaxNoQue", objExam.MaxQueInSection));
                objParamList.Add(new SqlParameter("@AttemptQue", objExam.MaxAttemptQue));



                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertQuextInSection", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetSectionInQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetSectionInQuestionList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public TransportationPacket GetNoQuestionInSection(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@categoryId", objLibExam.CategoryID));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetNoSectionQuestion", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objExamListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public int AddUpdateQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibExam.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibExam.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibExam.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibExam.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateSubQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibExam.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibExam.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibExam.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@SubQuestionId ", objLibExam.SubQuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateSubQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetQuestionOptionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objExamListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetSubQuestionOptionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objExamListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objExamListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public TransportationPacket GetQuestionListbyCategory(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@CategoryID", objLibExam.CategoryID));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionbyCategoryId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objExamListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                                objExamListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                objExamListing[i].UploadQuestionImagePath = ds.Tables[0].Rows[i]["UploadQuestionImagePath"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetBalQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetRandomlyBalanceQuestion", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetRandomlyQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetRandomlyBalanceQuestion", objParamList);

                //if (ds != null)
                //{
                //    if (ds.Tables != null)
                //    {
                //        if (ds.Tables[0].Rows != null)
                //        {
                //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //            {
                //                LIBExam objLibExamInner = new LIBExam();
                //                objExamListing.Add(objLibExamInner);
                //                objExamListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                //                //objExamListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                //                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                //                //objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                //                objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                //                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                //                objExamListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                //            }

                //        }
                //    }
                //}
                //packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetMarkedQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetMarkedQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objExamListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public TransportationPacket GetSubQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].SubQuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubQuestionId"].ToString());
                                objExamListing[i].QuesNo = ds.Tables[0].Rows[i]["QuesNo"].ToString();
                                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objExamListing[i].Type = ds.Tables[0].Rows[i]["Type"].ToString();


                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetQuestion(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestion_List", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());

                                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetQuestionOptionList2(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public TransportationPacket GetQuestionOptionListByOptionType(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                //objExamListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objExamListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetSubQuestionOptionListByOptionType(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                //objExamListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objExamListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int GetMaxCtmExamNo(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetCtmExamNo", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int CheckQuestionOptionAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibExam.AnsText));
                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_CheckOptionByQuestionId", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int CheckQuestionSubOptionAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.SubQuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibExam.AnsText));
                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_CheckSubOptionByQuestionId", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public TransportationPacket GetAnsText(TransportationPacket tp)
        {

            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetAnsText", objParamList);
                LIBExamListing objExamListing = new LIBExamListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBExam objLibExam1 = new LIBExam();
                    objExamListing.Add(objLibExam1);
                    objExamListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                    objExamListing[i].UploadAnsPath = (ds.Tables[0].Rows[i]["uploadanspath"].ToString());
                    string review = (ds.Tables[0].Rows[i]["Review"].ToString());
                    if (review == "0")
                    {
                        objExamListing[i].Review = false;
                    }
                    else
                    {
                        objExamListing[i].Review = true;
                    }

                }

                tp.MessageResultset = (LIBExamListing)objExamListing;

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return tp;
        }

        public TransportationPacket GetSubAnsText(TransportationPacket tp)
        {

            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubAnsText", objParamList);
                LIBExamListing objExamListing = new LIBExamListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBExam objLibExam1 = new LIBExam();
                    objExamListing.Add(objLibExam1);
                    objExamListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                    //string review = (ds.Tables[0].Rows[i]["Review"].ToString());
                    //if (review == "0")
                    //{
                    //    objExamListing[i].Review = false;
                    //}
                    //else
                    //{
                    //    objExamListing[i].Review = true;
                    //}

                }

                tp.MessageResultset = (LIBExamListing)objExamListing;

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return tp;
        }

        public bool GetReviewMark(TransportationPacket tp)
        {
            bool review = false;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetReviewMark", objParamList);
                LIBExamListing objExamListing = new LIBExamListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBExam objLibExam1 = new LIBExam();
                    objExamListing.Add(objLibExam1);

                    review = Convert.ToBoolean(ds.Tables[0].Rows[i]["Review"].ToString());


                }

                tp.MessageResultset = (LIBExamListing)objExamListing;

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return review;
        }
        public TransportationPacket GetSubQuestionAnsText(TransportationPacket tp)
        {

            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubquestionAnsText", objParamList);
                LIBExamListing objExamListing = new LIBExamListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBExam objLibExam1 = new LIBExam();
                    objExamListing.Add(objLibExam1);
                    objExamListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());

                }

                tp.MessageResultset = (LIBExamListing)objExamListing;

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return tp;
        }

        public TransportationPacket GetQuestionOptionListByOptionTypeAll(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objExamListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetSubQuestionOptionListByOptionTypeAll(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objExamListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objExamListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetQuestionListByExamId(string ExamId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", ExamId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQues_Ans_", objParamList);
            }
            catch (Exception ex)
            {
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetSubQuestionListByExamId(int QuestionId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", QuestionId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubQues_Ans_", objParamList);
            }
            catch (Exception ex)
            {
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public TransportationPacket GetCourse(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetSemester(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSem", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].SemesterId = Convert.ToInt32(ds.Tables[0].Rows[i]["SemId"].ToString());
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetModule(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SemId", objLIBExam.SemesterId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetModule", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].ModuleId = Convert.ToInt32(ds.Tables[0].Rows[i]["ModuleId"].ToString());
                                objExamListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetPaper(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ModuleId", objLIBExam.ModuleId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetPaper", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].paperId = Convert.ToInt32(ds.Tables[0].Rows[i]["PaperId"].ToString());
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int AddExamSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ExamCode", objExam.examcode));
                objParamList.Add(new SqlParameter("@CourseId", objExam.CourseId));
                objParamList.Add(new SqlParameter("@SemId", objExam.SemesterId));
                objParamList.Add(new SqlParameter("@ModuleId", objExam.ModuleId));
                objParamList.Add(new SqlParameter("@PaperId", objExam.paperId));
                objParamList.Add(new SqlParameter("@TimeAllowted", objExam.TimeAllowted));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertExamSet", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int CloseBatch(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
               
                objParamList.Add(new SqlParameter("@BatchId", objExam.BatchId));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_CloseBatch", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddExamDate(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ExamId", objExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objExam.UserId));
                objParamList.Add(new SqlParameter("@BatchId", objExam.BatchId));
                objParamList.Add(new SqlParameter("@SentDate", objExam.SentDate1));
                objParamList.Add(new SqlParameter("@ReceiveDate", objExam.ReceiveDate1));
             
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertExamDate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddBatchClosureDetails(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@CourseId", objExam.CourseId));
                objParamList.Add(new SqlParameter("@UserId", objExam.UserId));
                objParamList.Add(new SqlParameter("@BatchId", objExam.BatchId));
                objParamList.Add(new SqlParameter("@TestimonialsDate", objExam.TestimonialsDate1));
                objParamList.Add(new SqlParameter("@CertificateDispatchedDate", objExam.CertificateDispatchedDate1));
                objParamList.Add(new SqlParameter("@StudentTestimonialsDate", objExam.StudentTestimonialsDate1));
                objParamList.Add(new SqlParameter("@StudentCertificateDispatchedDate", objExam.StudentCertificateDispatchedDate1));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddBatchClosureDetails", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddPaperFile(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
              
                objParamList.Add(new SqlParameter("@CourseId", objExam.CourseId));
                objParamList.Add(new SqlParameter("@SemId", objExam.SemesterId));
                objParamList.Add(new SqlParameter("@ModuleId", objExam.ModuleId));
                objParamList.Add(new SqlParameter("@PaperId", objExam.paperId));
                objParamList.Add(new SqlParameter("@FileCaption", objExam.FileCaption));
                objParamList.Add(new SqlParameter("@UploadFilePath", objExam.UploadFilePath));
                objParamList.Add(new SqlParameter("@BatchId", objExam.BatchId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdatePaperFile", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public string GetCourseCodeByID(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalarString("[SP_GetCourseCodeByID]", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int UpdateExamSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ExamId", objExam.ExamId));

                objParamList.Add(new SqlParameter("@TimeAllowted", objExam.TimeAllowted));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateExamSet", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetExamSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetExamSetList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());
                                objExamListing[i].examcode = ds.Tables[0].Rows[i]["ExamCode"].ToString();
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objExamListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objExamListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetExamListByBatch(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetExamListByBatch", objParamList);
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetPaperFile(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetPaperFile", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetPaperFileBySemId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@semid", objLIBExam.SemesterId));
		objParamList.Add(new SqlParameter("@stid", objLIBExam.stid));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetPaperFileBySemid", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int GetCurrentSem(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@courseid", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@stid", objLibExam.Stid));

                addResult = objDbConnection.ExecuteSPScalar("sp_getcurrentsemeste", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int SubmitExamAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@Review", objLibExam.Review));
                objParamList.Add(new SqlParameter("@CategoryId", objLibExam.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibExam.AnsText));
                objParamList.Add(new SqlParameter("@option", objLibExam.Option));
                objParamList.Add(new SqlParameter("@bid", objLibExam.BatchId));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibExam.UploadAnsPath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddQuestionAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int SubmitSubExamAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));
                objParamList.Add(new SqlParameter("@CategoryId", objLibExam.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibExam.AnsText));
                objParamList.Add(new SqlParameter("@bid", objLibExam.BatchId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSubQuestionAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public string CheckMaxLimit(TransportationPacket packet)
        {
            string addResult = "0";
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@categoryid", objLibExam.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                //objParamList.Add(new SqlParameter("@qustionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_CheckMaxLimit", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int GetMaxAttemptQue(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@categoryid", objLibExam.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetMaxAttempQues", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int DeleteCheckboxExamAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));

                objParamList.Add(new SqlParameter("@CategoryId", objLibExam.CategoryID));

                objParamList.Add(new SqlParameter("@bid", objLibExam.BatchId));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_DeleteChechboxanswer", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int DeleteExamAnswer(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteAssigmentExamAnswer(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@AsgnId", objLibExam.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteExamAnswerofsubquestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAnswerfromSubQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int GetCATEGORYID(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@categoryId", objLibExam.CategoryID));
                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("Sp_GetCategoryIdforCopyQuestion", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int GetMaxQuesNo(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("getmaxquestionNo", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int GetBid(TransportationPacket packet)
        {
            int addResult = 0;

            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Stid", objLibExam.Stid));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetBid", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int AddCopyQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@oldQuestionId ", objLibExam.OldQuestionId));
                objParamList.Add(new SqlParameter("@newQuestionId ", objLibExam.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddOldQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddCopySectionQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newexamid ", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@oldexamid ", objLibExam.OldExamId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddOldSectionQues", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddCopyExamSection(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newexamid ", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@oldexamid ", objLibExam.OldExamId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddOldExamSection", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetExamInstruction(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetExamInstruction", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseTitle = (ds.Tables[0].Rows[i]["CourseTitle"].ToString());
                                objExamListing[i].CourseCode = ds.Tables[0].Rows[i]["CourseCode"].ToString();
                                objExamListing[i].examcode = ds.Tables[0].Rows[i]["examcode"].ToString();
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetExamDate(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetExamDate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].activateDate = Convert.ToDateTime((ds.Tables[0].Rows[i]["activateDate"].ToString()));

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetAssignmentDate(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibExam.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentDate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].activateDate = Convert.ToDateTime((ds.Tables[0].Rows[i]["activateDate"].ToString()));

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetStudenInfo(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Studentid", objLibExam.StudentEmail));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].StudentName = (ds.Tables[0].Rows[i]["stuname"].ToString());
                                objExamListing[i].Stid = Convert.ToInt32(ds.Tables[0].Rows[i]["stid"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetInstructionSummary(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@userid", objLibExam.StudentEmail));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetInstructionTotalSummary_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());
                                objExamListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objExamListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                // objExamListing[i].CategoryName = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryName"].ToString());
                                //objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int GetToatalAttemptQue(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));
                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_TotalAttemptQue", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }


        public DataSet GetBatch(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatch", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objExamListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int AddActivateExamSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@examid", objExam.ExamId));
                objParamList.Add(new SqlParameter("@batchid", objExam.BatchId));
                objParamList.Add(new SqlParameter("@activatedate", objExam.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objExam.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddExamActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetStudentExamSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UserId", objLIBExam.UserId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentExamSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());
                                objExamListing[i].examcode = ds.Tables[0].Rows[i]["ExamCode"].ToString();
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objExamListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetSubmiitedExamByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLIBExam.UserId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmitedExamByUserId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objExamListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objExamListing[i].AnsText = ds.Tables[0].Rows[i]["AnsText"].ToString();
                                objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objExamListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetSubmiitedCaseStudyExamByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLIBExam.UserId));
                objParamList.Add(new SqlParameter("@QuesId", objLIBExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("[SP_GetSubmitedCaseStudyExamByUserId]", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objExamListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objExamListing[i].AnsText = ds.Tables[0].Rows[i]["AnsText"].ToString();
                                objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objExamListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        //code by wahid

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


        public int AddUserInstruction(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ExamId", objExam.ExamId));
                objParamList.Add(new SqlParameter("@CategoryID", objExam.CategoryID));
                objParamList.Add(new SqlParameter("@InstructionText", objExam.InstructionText));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateStudentInstruction", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public string GetInstruction(int ExamID, int CatID)
        {
            DataSet ds = new DataSet();
            string strInstruction = "";
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", ExamID));
                objParamList.Add(new SqlParameter("@categoryId", CatID));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetSectionSummary", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strInstruction = ds.Tables[0].Rows[0]["InstructionText"].ToString();
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return (strInstruction);
        }
        public DataSet GetBatchByExamId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLIBExam.ExamId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchByExamSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objExamListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetActivateExamSetData(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetActiveExamData", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int UpdateActivateExamSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@examid", objExam.ExamId));
                objParamList.Add(new SqlParameter("@batchid", objExam.BatchId));
                objParamList.Add(new SqlParameter("@activatedate", objExam.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objExam.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateActivateExam", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetQuestionByQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionByQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objExamListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());


                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetScreeningQuestionByQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionByQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objExamListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetQuestionBySubQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionBySubQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objExamListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetScreeningQuestionBySubQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibExam.SubQuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionBySubQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objExamListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetEvaluationCriteria(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetEvaluationCriteria", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].ExamMarks = Convert.ToBoolean((ds.Tables[0].Rows[i]["ExamMarks"].ToString()));
                                objExamListing[i].AssignmentMarks = Convert.ToBoolean(ds.Tables[0].Rows[i]["AssignmentMarks"].ToString());
                                objExamListing[i].DiscussionForumMarks = Convert.ToBoolean((ds.Tables[0].Rows[i]["DiscussionForumMarks"].ToString()));
                                objExamListing[i].ProjectMarks = Convert.ToBoolean(ds.Tables[0].Rows[i]["ProjectMarks"].ToString());
                                objExamListing[i].CaseStudyMarks = Convert.ToBoolean(ds.Tables[0].Rows[i]["CaseStudyMarks"].ToString());
                                objExamListing[i].ColumnName1 = ((ds.Tables[0].Rows[i]["ColumnName1"].ToString()));
                                objExamListing[i].ColumnName2 = (ds.Tables[0].Rows[i]["ColumnName2"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetSignupCriteria(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSignupCriteria", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32((ds.Tables[0].Rows[i]["CourseId"].ToString()));
                                objExamListing[i].ApplicantCategory = Convert.ToBoolean((ds.Tables[0].Rows[i]["ApplicantCategory"].ToString()));
                                objExamListing[i].CurrentProfession = Convert.ToBoolean(ds.Tables[0].Rows[i]["CurrentProfession"].ToString());
                                objExamListing[i].EvaluationCategory = Convert.ToBoolean((ds.Tables[0].Rows[i]["Category"].ToString()));
                                objExamListing[i].EducationalDetails = Convert.ToBoolean(ds.Tables[0].Rows[i]["EducationalDetails"].ToString());
                                objExamListing[i].WorkExperience = Convert.ToBoolean(ds.Tables[0].Rows[i]["WorkExperience"].ToString());
                                
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int AddEvaluationCriteria(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamMarks", objLibExam.ExamMarks));
                objParamList.Add(new SqlParameter("@AssignmentMarks", objLibExam.AssignmentMarks));
                objParamList.Add(new SqlParameter("@DiscussionForumMarks", objLibExam.DiscussionForumMarks));
                objParamList.Add(new SqlParameter("@ProjectMarks", objLibExam.ProjectMarks));
                objParamList.Add(new SqlParameter("@CaseStudyMarks", objLibExam.CaseStudyMarks));
                objParamList.Add(new SqlParameter("@ColumnName1 ", objLibExam.ColumnName1));
                objParamList.Add(new SqlParameter("@ColumnName2 ", objLibExam.ColumnName2));
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddEvaluationCriteria", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddSignupCriteria(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@ApplicantCategory", objLibExam.ApplicantCategory));
                objParamList.Add(new SqlParameter("@CurrentProfession", objLibExam.CurrentProfession));
                objParamList.Add(new SqlParameter("@Category", objLibExam.EvaluationCategory));
                objParamList.Add(new SqlParameter("@WorkExperience", objLibExam.WorkExperience));
                objParamList.Add(new SqlParameter("@EducationalDetails ", objLibExam.EducationalDetails));
               
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSignupCriteria", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetCourseList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetCourseList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet ReportStudentActivateExam(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                objParamList.Add(new SqlParameter("@activate", objLIBExam.Activate));
              
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ReportActvateStudentInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet ReportActivateExam(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                objParamList.Add(new SqlParameter("@frmdt", objLIBExam.FromDate));
                objParamList.Add(new SqlParameter("@todt", objLIBExam.ToDate));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ReportActvateExam", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }


        public DataSet GetBatchByCourseId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchByCourseId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objExamListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetStudentData(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("BatchId", objLIBExam.BatchId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentData", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }





        public int UpdateStudentPassword(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@FirstName", objExam.FirstName));
                objParamList.Add(new SqlParameter("@Stid", objExam.Stid));
                objParamList.Add(new SqlParameter("@LastName", objExam.LastName));
                objParamList.Add(new SqlParameter("@Password", objExam.Password));
                objParamList.Add(new SqlParameter("@StudentEmail", objExam.StudentEmail));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateStudentPassword", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;

        }


        public TransportationPacket GetBatchByCourseid(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchById", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].bid1 = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objExamListing[i].BatchCode1 = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }





        public TransportationPacket GetFacultySetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));
                objParamList.Add(new SqlParameter("@Stid", objLIBExam.Stid));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetFacultybyStudentidandCourseId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].Name = ds.Tables[0].Rows[i]["Name"].ToString();
                                objExamListing[i].fid = Convert.ToInt32(ds.Tables[0].Rows[i]["fid"].ToString());
                                //objExamListing[i].examcode = ds.Tables[0].Rows[i]["ExamCode"].ToString();
                                //objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objExamListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objExamListing[i].paperId = Convert.ToInt32(ds.Tables[0].Rows[i]["paperid"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }




        public TransportationPacket GetCourseBYid(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Stid", objLIBExam.Stid));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCoursebyStudentid", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }


        public DataSet GetSubQuestionList_CopyQuestion(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            //{
                            //    LIBExam objLibExamInner = new LIBExam();
                            //    objExamListing.Add(objLibExamInner);
                            //    objExamListing[i].SubQuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubQuestionId"].ToString());
                            //    objExamListing[i].QuesNo = ds.Tables[0].Rows[i]["QuesNo"].ToString();
                            //    objExamListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                            //    objExamListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                            //    objExamListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                            //    objExamListing[i].Type = ds.Tables[0].Rows[i]["Type"].ToString();


                            //}

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int GetMaxSubQuesNo(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@questionid", objLibExam.QuestionId));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("getmaxSubquestionNo", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int AddsubCopyQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@oldQuestionId ", objLibExam.OldSubQuestionId));
                objParamList.Add(new SqlParameter("@newQuestionId ", objLibExam.SubQuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddOldsubQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }



        public DataSet GetSemesterByCourseId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSemesterByCourseId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].SemesterId = Convert.ToInt32(ds.Tables[0].Rows[i]["SemId"].ToString());
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetSuccessfullyCompleteCourse(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("CourseID", objLIBExam.CourseId));
                objParamList.Add(new SqlParameter("BatchId", objLIBExam.BatchId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetSuccessfullyCompletedCourse", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }





        public TransportationPacket GetBatchReturningBatchId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatch", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);

                                objExamListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objExamListing[i].BatchTitle = ds.Tables[0].Rows[i]["BatchCode"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }



        public DataSet GetStudentDataforReport1(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("CourseId", objLIBExam.CourseId));
                objParamList.Add(new SqlParameter("App_Status", objLIBExam.App_Status));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentDataforReport1", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }














        public DataSet GetStudentDataforReport2(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("CourseId", objLIBExam.CourseId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentDataforReport2", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }











        public DataSet GetStudentDataforReport3(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("CourseId", objLIBExam.CourseId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentDataforReport3", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }


        public TransportationPacket GetBatchReturningCourseId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchReturningCourseId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);

                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].BatchTitle = ds.Tables[0].Rows[i]["BatchCode"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }















        public DataSet GetCurrentBatchStatusByCourseId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@BatchId", objLIBExam.BatchId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_CurrentBatchStatus_Testing", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].StudentName = ds.Tables[0].Rows[i]["StudentName"].ToString();
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objExamListing[i].PassStatus = ds.Tables[0].Rows[i]["PassStatus"].ToString();
                                objExamListing[i].FeeStatus = ds.Tables[0].Rows[i]["FeeStatus"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public TransportationPacket GetBatchforReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatch", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);

                                objExamListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objExamListing[i].BatchTitle = ds.Tables[0].Rows[i]["BatchCode"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }












        public DataSet GetBatchReportData(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("@BatchId", objLIBExam.BatchId));
                objParamList.Add(new SqlParameter("@Gender", objLIBExam.Gender));
                objParamList.Add(new SqlParameter("@Category", objLIBExam.Category));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchReportData", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }



        public DataSet GetTopicBySemId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SemesterId", objLIBExam.SemesterId));
                objParamList.Add(new SqlParameter("@BatchId", objLIBExam.BatchId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetTopicBySemId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].Topic = ds.Tables[0].Rows[i]["Topic"].ToString();
                                objExamListing[i].SubjectId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubjectId"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }











        public DataSet GetTopicReportBySubjectId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubjectId", objLIBExam.SubjectId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentTopicReport", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].StudentName = ds.Tables[0].Rows[i]["StudentName"].ToString();
                                objExamListing[i].PostReply = ds.Tables[0].Rows[i]["PostReply"].ToString();
                                objExamListing[i].DateOfPost = ds.Tables[0].Rows[i]["DateOfPost"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int AddUpdateCourse(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@CourseName", objLibExam.CourseName));
                objParamList.Add(new SqlParameter("@Text1", objLibExam.Text1));
                //objParamList.Add(new SqlParameter("@Text2", objLibExam.Text2));
                //objParamList.Add(new SqlParameter("@Text3 ", objLibExam.Text3));
                //objParamList.Add(new SqlParameter("@Text4 ", objLibExam.Text4));
                objParamList.Add(new SqlParameter("@TextDetails ", objLibExam.TextDetails));
                objParamList.Add(new SqlParameter("@ImagePath", objLibExam.ImagePath));
                objParamList.Add(new SqlParameter("@Check", objLibExam.Check));
                objParamList.Add(new SqlParameter("@ChkCourseOffered", objLibExam.ChkCourseOffered));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateCourse", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }


        public int AddUpdateBanner(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@BannerHeading", objLibExam.BannerHeading));
                objParamList.Add(new SqlParameter("@BannerDesc", objLibExam.BannerDesc));
                objParamList.Add(new SqlParameter("@dataorientation", objLibExam.dataorientation));
                objParamList.Add(new SqlParameter("@dataslice1rotation ", objLibExam.dataslice1rotation));
                objParamList.Add(new SqlParameter("@dataslice2rotation ", objLibExam.dataslice2rotation));
                objParamList.Add(new SqlParameter("@dataslice1scale ", objLibExam.dataslice1scale));
                objParamList.Add(new SqlParameter("@dataslice2scale ", objLibExam.dataslice2scale));
                objParamList.Add(new SqlParameter("@ImagePath", objLibExam.Bannerimages));
                objParamList.Add(new SqlParameter("@CourseOfferedIcon", objLibExam.CourseOfferedIcon));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateBanner", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetCourseListdetails(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCoursedetailList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].CourseName = ds.Tables[0].Rows[i]["CourseName"].ToString();
                                objExamListing[i].Text1 = ds.Tables[0].Rows[i]["Text1"].ToString();
                                objExamListing[i].Text2 = ds.Tables[0].Rows[i]["Text2"].ToString();
                                objExamListing[i].Text3 = ds.Tables[0].Rows[i]["Text3"].ToString();
                                objExamListing[i].Text4 = ds.Tables[0].Rows[i]["Text4"].ToString();
                                objExamListing[i].OrderNumber = Convert.ToInt32(ds.Tables[0].Rows[i]["OrderNumber"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetCourseListByID(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCoursedetailListBYID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].CourseName = ds.Tables[0].Rows[i]["CourseName"].ToString();
                                objExamListing[i].Text1 = ds.Tables[0].Rows[i]["Text1"].ToString();
                                //objExamListing[i].Text2 = ds.Tables[0].Rows[i]["Text2"].ToString();
                                //objExamListing[i].Text3 = ds.Tables[0].Rows[i]["Text3"].ToString();
                                //objExamListing[i].Text4 = ds.Tables[0].Rows[i]["Text4"].ToString();
                                objExamListing[i].TextDetails = ds.Tables[0].Rows[i]["TextDetails"].ToString();
                                objExamListing[i].ImagePath = ds.Tables[0].Rows[i]["ImagePath"].ToString();
                                objExamListing[i].Check = Convert.ToBoolean(ds.Tables[0].Rows[i]["Checked"].ToString());
                                objExamListing[i].ChkCourseOffered = Convert.ToBoolean(ds.Tables[0].Rows[i]["ChkCourseOffered"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetCourseBannerListByID(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCoursedetailListBYID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].BannerHeading = ds.Tables[0].Rows[i]["BannerHeading"].ToString();
                                objExamListing[i].BannerDesc = ds.Tables[0].Rows[i]["BannerDesc"].ToString();
                                objExamListing[i].dataorientation = ds.Tables[0].Rows[i]["dataorientation"].ToString();
                               
                                objExamListing[i].dataslice1rotation = ds.Tables[0].Rows[i]["dataslice1rotation"].ToString();
                                objExamListing[i].dataslice2rotation = ds.Tables[0].Rows[i]["dataslice2rotation"].ToString();

                                objExamListing[i].dataslice1scale = ds.Tables[0].Rows[i]["dataslice1scale"].ToString();
                                objExamListing[i].dataslice2scale = ds.Tables[0].Rows[i]["dataslice2scale"].ToString();

                                objExamListing[i].ImagePath = ds.Tables[0].Rows[i]["ImagePath"].ToString();
                                objExamListing[i].Bannerimages = ds.Tables[0].Rows[i]["images"].ToString();
                                objExamListing[i].CourseOfferedIcon = ds.Tables[0].Rows[i]["CourseOfferedIcon"].ToString();

                                objExamListing[i].Check = Convert.ToBoolean(ds.Tables[0].Rows[i]["Checked"].ToString());
                                objExamListing[i].ChkCourseOffered = Convert.ToBoolean(ds.Tables[0].Rows[i]["ChkCourseOffered"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int DeleteCourse(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteCourse", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public string GetContactus()
        {
            DataSet ds = new DataSet();
            string strInstruction = "";
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetContactus", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strInstruction = ds.Tables[0].Rows[0]["Text1"].ToString();
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return (strInstruction);
        }
        public string GetAboutus()
        {
            DataSet ds = new DataSet();
            string strInstruction = "";
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetAboutus", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strInstruction = ds.Tables[0].Rows[0]["Text1"].ToString();
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            return (strInstruction);
        }






        public int AddContactus(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@InstructionText", objExam.InstructionText));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateContactUs", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddAboutus(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@InstructionText", objExam.InstructionText));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateAboutUs", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet ReportStudentActivateExamDetails(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@userid", objLIBExam.UserId));
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentAssignExamInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int CountStudenttotalsubtopic(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@SubjectId", objExam.SubjectId));
                objParamList.Add(new SqlParameter("@StudentEmail", objExam.StudentEmail));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_GettotalTopic", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet ReportStudentTopicDetails(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                objParamList.Add(new SqlParameter("@email", objLIBExam.StudentEmail));


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentTopicDetails", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetActiveStudentReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("BatchId", objLIBExam.BatchId));
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetActiveStudentsReport", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetActiveStudentReportwithoutparameter(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();


                ds = objDbConnection.ExecuteSPDataSet("Sp_GetActiveStudentsReport1", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetActiveStudentReport4Search1(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("StudentName", objLIBExam.StudentName));
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetActiveStudentsReport4Search1", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }


        public DataSet GetActiveStudentReport4Search2(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("StudentEmail", objLIBExam.StudentEmail));
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetActiveStudentsReport4Search2", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int AddActivateStudentExamSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@examid", objExam.ExamId));
                objParamList.Add(new SqlParameter("@batchid", objExam.BatchId));
                objParamList.Add(new SqlParameter("@userid", objExam.UserId));



                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddStudentExamActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }


        public DataSet StudentInActivateExam(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@batchid", objLIBExam.BatchId));


                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentListForActivate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetFacultyIntegratedReport(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("BatchId", objLIBExam.BatchId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetFacultyIntegratedReport1", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }









        public DataSet GetFacultyIntegratedReportwithoutparameter(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();


                ds = objDbConnection.ExecuteSPDataSet("Sp_GetFacultyIntegratedReportWithoutParameter", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }







        public DataSet GetfacultytReport4Search1(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("FacultyName", objLIBExam.FacultyName));
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetFacultyIntegratedReport4search1", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }



        public DataSet GetfacultytReport4Search2(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("FacultyEmail", objLIBExam.FacultyEmail));
                ds = objDbConnection.ExecuteSPDataSet("Sp_GetFacultyIntegratedReport4search2", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public TransportationPacket GetCourseEmaliDetailByCID(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@colnam", objLibExam.ColName));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCourseEmaildetailListBYID", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].EmailContent = ds.Tables[0].Rows[i]["emailcontent"].ToString();
                                objExamListing[i].courseEmail = ds.Tables[0].Rows[i]["courseidmail"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }


        public int AddUpdateCourseRegEmailContent(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@EmailContent", objLibExam.EmailContent));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateCourseRegEmailContent", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateCourseApprovEmailContent(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@EmailContent", objLibExam.EmailContent));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateCourseApprovEmailContent", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        //-------------------------------Ankit Function Begin--------------------------------------------
        public DataSet fnCheckDs(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("@UserId", objLIBExam.userid));
                objParamList.Add(new SqlParameter("@BID", objLIBExam.Bid));
                ds = objDbConnection.ExecuteSPDataSet("testExamSample1234", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet fnGrvDs(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                objParamList.Add(new SqlParameter("UserId", objLIBExam.UserId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentExamSet", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public TransportationPacket GetStudentExamSetList_1(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UserName", objLIBExam.UserId));
                objParamList.Add(new SqlParameter("@StId", objLIBExam.stid));
                objParamList.Add(new SqlParameter("@BID", objLIBExam.bid));
                objParamList.Add(new SqlParameter("@Paperid", objLIBExam.paperid));

                LIBExamListing objExamListing = new LIBExamListing();

                //ds = objDbConnection.ExecuteSPDataSet("testExamSetSample1234Last", objParamList);
                ///////////////////BeforeUsed ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentExamSet_New", objParamList);
                //ds = objDbConnection.ExecuteSPDataSet("testExamSetSample1234Last_Modify", objParamList);
                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentExamSet_NewFinal", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());
                                objExamListing[i].examcode = ds.Tables[0].Rows[i]["ExamCode"].ToString();
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objExamListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        //-------------------------------Activate Student List By Fee Check Page------------------------------------
        public DataSet ReportStudentActivateExam_FeeStatus(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                objParamList.Add(new SqlParameter("@paperId", objLIBExam.paperId));
                //objParamList.Add(new SqlParameter("@stid", objLIBExam.stid));
                //objParamList.Add(new SqlParameter("@activate", objLIBExam.Activate));

                LIBExamListing objExamListing = new LIBExamListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_ReportActivateStudentInfoFeeStatus_Supply", objParamList);
                //ds = objDbConnection.ExecuteSPDataSet("SP_ReportActvateStudentInfo_FeeStatus", objParamList);
                //ds = objDbConnection.ExecuteSPDataSet("SP_ReportActivateStudentInfoFeeStatus", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet ReportStudentActivateExam_FeeStatusActivate(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                objParamList.Add(new SqlParameter("@paperId", objLIBExam.paperId));
                //objParamList.Add(new SqlParameter("@stid", objLIBExam.stid));
                //objParamList.Add(new SqlParameter("@activate", objLIBExam.Activate));

                LIBExamListing objExamListing = new LIBExamListing();
                ds = objDbConnection.ExecuteSPDataSet("SP_ReportDeactivateStudentInfoFeeStatus_Supply", objParamList);

                //ds = objDbConnection.ExecuteSPDataSet("SP_ReportActvateStudentInfo_FeeStatusActivate", objParamList);
                //ds = objDbConnection.ExecuteSPDataSet("SP_ReportDeactivateStudentInfoFeeStatus", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int UpdateActivateStudentExamSet_FeeStatus(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@examid", objExam.ExamId));
                objParamList.Add(new SqlParameter("@batchid", objExam.BatchId));
                objParamList.Add(new SqlParameter("@userid", objExam.UserId));
                objParamList.Add(new SqlParameter("@stid", objExam.stid));
                objParamList.Add(new SqlParameter("@courseId", objExam.CourseId));
                objParamList.Add(new SqlParameter("@PaperId", objExam.paperId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateStudentSupplExamDeactivate_Feestatus", objParamList);
                //addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateStudentExamActivate_Feestatus", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        //''''''''''''08-02-2014 Begin'''''''''''''''''''''''''''''
        public int UpdateActivateStudentFeeSubmitForSupply(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@examid", objLibExam.ExamId));
                objParamList.Add(new SqlParameter("@batchid", objLibExam.BatchId));
                objParamList.Add(new SqlParameter("@userid", objLibExam.UserId));
                objParamList.Add(new SqlParameter("@stid", objLibExam.stid));
                objParamList.Add(new SqlParameter("@courseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@PaperId", objLibExam.paperId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateStudentSupplExamActivate_Feestatus", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddStudentSupplExam(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@examid", objExam.ExamId));
                objParamList.Add(new SqlParameter("@batchid", objExam.BatchId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddStudentSupplExam", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public DataSet GetPaperIdForSupply(TransportationPacket tp)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                //LIBExam objExam = new LIBExam();
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@examid", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                //objParamList.Add(new SqlParameter("@examid", objExam.ExamId));
                //objParamList.Add(new SqlParameter("@bid", objExam.BatchId));
                ds = objDbConnection.ExecuteSPDataSet("GetPaperIdForSupply", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return ds;
        }
        //''''''''''''08-02-2014 End'''''''''''''''''''''''''''''''
        public TransportationPacket GetStudentExamSetList_StdActive(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                ////objParamList.Add(new SqlParameter("@UserName", objLIBExam.UserId));
                objParamList.Add(new SqlParameter("@StId", objLIBExam.stid));
                objParamList.Add(new SqlParameter("@BID", objLIBExam.bid));
                objParamList.Add(new SqlParameter("@Paperid", objLIBExam.paperid));

                LIBExamListing objExamListing = new LIBExamListing();

                //ds = objDbConnection.ExecuteSPDataSet("testExamSetSample1234Last", objParamList);
                ///////////////////BeforeUsed ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentExamSet_New", objParamList);
                //ds = objDbConnection.ExecuteSPDataSet("testExamSetSample1234Last_Modify", objParamList);
                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentExamSet_NewFinal", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());
                                objExamListing[i].examcode = ds.Tables[0].Rows[i]["ExamCode"].ToString();
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objExamListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetActiveExamForSupply(TransportationPacket tp)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                //LIBExam objExam = new LIBExam();
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@examid", objLIBExam.ExamId));
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                ds = objDbConnection.ExecuteSPDataSet("GetActiveExamForSupply", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return ds;
        }

        public TransportationPacket GetCourseById(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();
                objParamList.Add(new SqlParameter("@StudentEmail", objLIBExam.StudentEmail));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetCourseByUsername", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetStudentByBatch(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentByBatch", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }



        public DataSet GetExamDetailsById(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBAssignment = new LIBExam();
                objLIBAssignment = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLIBAssignment.ExamId));

                LIBExamListing objAssignmentListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetExamDetails", objParamList);

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
                packet.MessageResultset = (LIBExamListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddUpdateExamToFaculty(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibAssignment = new LIBExam();
                objLibAssignment = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Bid", objLibAssignment.bid));
                objParamList.Add(new SqlParameter("@Examid", objLibAssignment.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddExamToFaculty", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetAssignedExamtoFaculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBAssignment = new LIBExam();
                objLIBAssignment = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLIBAssignment.ExamId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignedExamtoFaculty", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBAssignmentListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }


        public DataSet GetExamListToFaculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBAssignment = new LIBExam();
                objLIBAssignment = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Username", objLIBAssignment.UserId));
                objParamList.Add(new SqlParameter("@bid", objLIBAssignment.BatchId));

                LIBExamListing objAssignmentListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetListOfExamToFaculty", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetListOfExamandAssignmentToFaculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBAssignment = new LIBExam();
                objLIBAssignment = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Username", objLIBAssignment.UserId));
                objParamList.Add(new SqlParameter("@bid", objLIBAssignment.BatchId));

                LIBExamListing objAssignmentListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetListOfExamandAssignmentToFaculty", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetProgressReports(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBAssignment = new LIBExam();
                objLIBAssignment = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@BID", objLIBAssignment.BatchId));
                
                LIBExamListing objAssignmentListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ProgressReports", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBAssignmentInner = new LIBExam();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());
                                objAssignmentListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetUserListBySubmiitedExam(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBAssignment = new LIBExam();
                objLIBAssignment = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@ExamId", objLIBAssignment.ExamId));
                
               // objParamList.Add(new SqlParameter("@Assignmenttype", objLIBAssignment.AssignmentType));
                LIBExamListing objAssignmentListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetUserListSubmittedExam", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBAssignmentInner = new LIBExam();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());
                                objAssignmentListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddUpdateExamFinalMarks(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibAssignment = new LIBExam();
                objLibAssignment = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ExamId", objLibAssignment.ExamId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@Fid", objLibAssignment.FacultyId));
                objParamList.Add(new SqlParameter("@TotalMarks", objLibAssignment.TotalMarks));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateExamFinalMarks", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetSemesterofStudent(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));
                objParamList.Add(new SqlParameter("@stid", objLIBExam.stid));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSemesterofStudent", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLIBExamInner = new LIBExam();
                                objExamListing.Add(objLIBExamInner);
                                objExamListing[i].SemesterId = Convert.ToInt32(ds.Tables[0].Rows[i]["SemId"].ToString());
                                objExamListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public int AddBatchGroup(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;

                objParamList.Add(new SqlParameter("@GroupId", objExam.GroupId));
                objParamList.Add(new SqlParameter("@Bid", objExam.bid));
                objParamList.Add(new SqlParameter("@GroupName", objExam.GroupName));
                objParamList.Add(new SqlParameter("@Userid", objExam.userid));
              
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateBatchGroup", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int DeleteBatchGroup(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@GroupId", objLibExam.GroupId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteBatchGroup", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

     
        public DataSet BatchGroupList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBExam.CourseId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_BatchGroupList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetStudentByGroup(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLIBExam = new LIBExam();
                objLIBExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@bid", objLIBExam.BatchId));
                objParamList.Add(new SqlParameter("@GroupId", objLIBExam.GroupId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentByGroup", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddStudentInGroup(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;

                objParamList.Add(new SqlParameter("@GroupId", objExam.GroupId));
                objParamList.Add(new SqlParameter("@Bid", objExam.bid));
                objParamList.Add(new SqlParameter("@Stid", objExam.stid));
                objParamList.Add(new SqlParameter("@userid", objExam.userid));
                objParamList.Add(new SqlParameter("@Check", objExam.Check));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateStudentRegGroup", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetEventManagement(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBEvent objLibExam = new LIBEvent();
                objLibExam = (LIBEvent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@eventID", objLibExam.eventID));
                LIBEventListing objExamListing = new LIBEventListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_EventManagement", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBEvent objLibExamInner = new LIBEvent();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].eventID = Convert.ToInt32(ds.Tables[0].Rows[i]["eventID"].ToString());
                                objExamListing[i].title = ds.Tables[0].Rows[i]["title"].ToString();
                                objExamListing[i].description = ds.Tables[0].Rows[i]["description"].ToString();
                                objExamListing[i].ThemeColor = ds.Tables[0].Rows[i]["ThemeColor"].ToString();
                                objExamListing[i].IsFullDay =Convert.ToBoolean(ds.Tables[0].Rows[i]["IsFullDay"].ToString());
                                objExamListing[i].start_date =Convert.ToDateTime(ds.Tables[0].Rows[i]["start_date"].ToString());
                                objExamListing[i].end_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["end_date"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBEventListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetEventManagementForCalendar(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBEvent objLibExam = new LIBEvent();
                objLibExam = (LIBEvent)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseID", objLibExam.CourseID));
                LIBEventListing objExamListing = new LIBEventListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_EventManagementforCalendar", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBEvent objLibExamInner = new LIBEvent();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].eventID = Convert.ToInt32(ds.Tables[0].Rows[i]["eventID"].ToString());
                                objExamListing[i].title = ds.Tables[0].Rows[i]["title"].ToString();
                                objExamListing[i].description = ds.Tables[0].Rows[i]["description"].ToString();
                                objExamListing[i].ThemeColor = ds.Tables[0].Rows[i]["ThemeColor"].ToString();
                                objExamListing[i].IsFullDay = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsFullDay"].ToString());
                                objExamListing[i].start_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["start_date"].ToString());
                                objExamListing[i].end_date = Convert.ToDateTime(ds.Tables[0].Rows[i]["end_date"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBEventListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int AddUpadteEventManagement(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBEvent objExam = new LIBEvent();
                objExam = (LIBEvent)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@eventID", objExam.eventID));
                objParamList.Add(new SqlParameter("@CourseID", objExam.CourseID));
                objParamList.Add(new SqlParameter("@title", objExam.title));
                objParamList.Add(new SqlParameter("@description", objExam.description));
                objParamList.Add(new SqlParameter("@start_date", objExam.start_date));
                objParamList.Add(new SqlParameter("@end_date", objExam.end_date));
                objParamList.Add(new SqlParameter("@ThemeColor", objExam.ThemeColor));
                objParamList.Add(new SqlParameter("@Status", objExam.Check));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateEventManagement", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int DeleteEventManagement(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBEvent objLibExam = new LIBEvent();
                objLibExam = (LIBEvent)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@eventID", objLibExam.eventID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteEventManagement", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int GetBatchofStudforGraph(TransportationPacket packet)
        {
            int addResult = 0;

            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Stid", objLibExam.Stid));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetBatchofStudforGraph", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public DataSet GetProgressGraph(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objLibExam.stid));
                objParamList.Add(new SqlParameter("@bid", objLibExam.bid));
                objParamList.Add(new SqlParameter("@PaperId", objLibExam.paperId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ProgressGraph", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].Exam = ds.Tables[0].Rows[i]["Exam"].ToString();
                                objExamListing[i].Project = ds.Tables[0].Rows[i]["Project"].ToString();
                                objExamListing[i].Assignment = ds.Tables[0].Rows[i]["Assignment"].ToString();
                                objExamListing[i].CaseStudy = ds.Tables[0].Rows[i]["CaseStudy"].ToString();
                                objExamListing[i].Forum = ds.Tables[0].Rows[i]["Forum"].ToString();
                                
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet PaperList4ProgressGraph(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@stid", objLibExam.stid));
                objParamList.Add(new SqlParameter("@bid", objLibExam.bid));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_PaperList4ProgressGraph", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].paperId =Convert.ToInt32(ds.Tables[0].Rows[i]["paperid"].ToString());
                                objExamListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public List<LIBExam> GetPaperList(TransportationPacket packet)
        {
            LIBExam tp = null;
            LIBExam objLib = new LIBExam();
            List<LIBExam> tplist = new List<LIBExam>();
            try
            {
                SqlConnection CON = new SqlConnection(WebConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString());
                CON.Open();
                objLib = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
               // objParamList.Add(new SqlParameter("@bid", Convert.ToInt32(objLib.bid)));
                //objParamList.Add(new SqlParameter("@stid", Convert.ToInt32(objLib.stid)));

                SqlCommand m_cmdStoredProcedure = new SqlCommand("SP_PaperList4ProgressGraph", CON);
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                m_cmdStoredProcedure.Parameters.Add(new SqlParameter("@bid", Convert.ToInt32(objLib.bid)));
                m_cmdStoredProcedure.Parameters.Add(new SqlParameter("@stid", Convert.ToInt32(objLib.stid)));

                SqlDataReader dr = m_cmdStoredProcedure.ExecuteReader();
                while (dr.Read())
                {
                    tp = new LIBExam();
                    tp.paperId = Convert.ToInt32(dr["paperId"].ToString());
                    tp.PaperTitle = dr["PaperTitle"].ToString();
                    tplist.Add(tp);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
            return tplist;
        }

        public List<LIBExam> GetCourseListBySTD(TransportationPacket packet)
        {
            LIBExam tp = null;
            LIBExam objLib = new LIBExam();
            List<LIBExam> tplist = new List<LIBExam>();
            try
            {
                SqlConnection CON = new SqlConnection(WebConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString());
                CON.Open();
                objLib = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                
                SqlCommand m_cmdStoredProcedure = new SqlCommand("SP_GetCoursebyStudentid", CON);
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                m_cmdStoredProcedure.Parameters.Add(new SqlParameter("@stid", Convert.ToInt32(objLib.stid)));

                SqlDataReader dr = m_cmdStoredProcedure.ExecuteReader();
                while (dr.Read())
                {
                    tp = new LIBExam();
                    tp.CourseId = Convert.ToInt32(dr["CourseId"].ToString());
                    tp.CourseTitle = dr["CourseTitle"].ToString();
                    tplist.Add(tp);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
            return tplist;
        }

        public int ActiveCourse(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBExam objExam = new LIBExam();
                objExam = (LIBExam)tp.MessagePacket;

                objParamList.Add(new SqlParameter("@CourseId", objExam.CourseId));
                objParamList.Add(new SqlParameter("@Check", objExam.Check));
              //  objParamList.Add(new SqlParameter("@seq", objExam.OrderNumber));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateActiveCourse", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetCourseAllList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAllCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBExam objLibExamInner = new LIBExam();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objExamListing[i].CourseCode = ds.Tables[0].Rows[i]["CourseCode"].ToString();
                                objExamListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objExamListing[i].Check =Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                               // objExamListing[i].OrderNumber = Convert.ToInt32(ds.Tables[0].Rows[i]["seq"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBExamListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public int UpdateCourseDetailsOrder(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CourseId", objLibExam.CourseId));
                objParamList.Add(new SqlParameter("@OrderNumber", objLibExam.OrderNumber));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_UpdatedCourseDetailsOrder", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        //-------------------------------End Activate Student List Page-------------------------------
        //-------------------------------Ankit Function End--------------------------------------------
    }


}
