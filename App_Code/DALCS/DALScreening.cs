using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;
namespace fmsf.DAL
{
    public class DALScreening
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();



        public TransportationPacket GetScreeningSetList_(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Year", objLIBScreening.Year));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetScreeningSetList_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].ScrId = Convert.ToInt32(ds.Tables[0].Rows[i]["ScrId"].ToString());
                                objScreeningListing[i].Screeningcode = ds.Tables[0].Rows[i]["ScrCode"].ToString();
                                objScreeningListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                //objScreeningListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                //objScreeningListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objScreeningListing[i].CreateDate = ds.Tables[0].Rows[i]["CreateDate"].ToString();
                                objScreeningListing[i].ScreeningType = ds.Tables[0].Rows[i]["ScreeningType"].ToString();
                                objScreeningListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public DataSet GetSubmiitedCaseStudyScreeningByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLIBScreening.ScrId));
                objParamList.Add(new SqlParameter("@UserId", objLIBScreening.UserId));
                objParamList.Add(new SqlParameter("@QuesId", objLIBScreening.QuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("[SP_GetSubmitedCaseStudyScreeningByUserId]", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objScreeningListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objScreeningListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objScreeningListing[i].AnsText = ds.Tables[0].Rows[i]["AnsText"].ToString();
                                objScreeningListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objScreeningListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int DeleteScreeningCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddScreeningCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CategoryName", objLibScreening.CategoryName));
                
                 objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddScreeningCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetScreeningInstruction(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningInstruction", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].CourseTitle = (ds.Tables[0].Rows[i]["CourseTitle"].ToString());
                                objScreeningListing[i].CourseCode = ds.Tables[0].Rows[i]["CourseCode"].ToString();
                                objScreeningListing[i].Screeningcode = ds.Tables[0].Rows[i]["Screeningcode"].ToString();
                                //objScreeningListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int DeleteScreeningQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
         public int DeleteScreeningQuestionanswer(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningQuestionanswers", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteScreeningSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SubQuestionId", objLibScreening.SubQuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningSubQuestion", objParamList);

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibScreening.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningQuestionOption", objParamList);

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibScreening.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningSubQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteScreening(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningset", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateScreeningQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibScreening.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibScreening.Answer));
                objParamList.Add(new SqlParameter("@MaxQueMarks", objLibScreening.MaxQueMarks));
                objParamList.Add(new SqlParameter("@Descriptive", objLibScreening.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibScreening.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibScreening.QUESTYPE));
                //objParamList.Add(new SqlParameter("@QuesNo ", objLibScreening.QuesNo));
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@CategoryId", objLibScreening.CategoryID));
                objParamList.Add(new SqlParameter("@UploadQuestionImagePath", objLibScreening.UploadQuestionImagePath));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateScreeningQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateScreeningSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibScreening.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibScreening.Answer));
                objParamList.Add(new SqlParameter("@Type", objLibScreening.Type));
                objParamList.Add(new SqlParameter("@Descriptive", objLibScreening.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibScreening.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibScreening.QUESTYPE));
                objParamList.Add(new SqlParameter("@QuesNo ", objLibScreening.QuesNo));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibScreening.SubQuestionId));
                //objParamList.Add(new SqlParameter("@Type", objLibScreening.Type));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateScreeningSubQuestion", objParamList);

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
                LIBScreening objScreening = new LIBScreening();
                objScreening = (LIBScreening)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ScrId", objScreening.ScrId));
                objParamList.Add(new SqlParameter("@CategoryId", objScreening.CategoryID));
                objParamList.Add(new SqlParameter("@MaxNoQue", objScreening.MaxQueInSection));
                objParamList.Add(new SqlParameter("@AttemptQue", objScreening.MaxAttemptQue));



                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertScreeningQuextInSection", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateMaualScreeningAnswers(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibScreening.UploadAnsPath));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddScreeningManualAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetNoQuestionInSection(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@categoryId", objLibScreening.CategoryID));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetScreeningNoSectionQuestion", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objScreeningListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());
                                
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibScreening.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibScreening.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibScreening.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibScreening.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateScreeningQuestionOption", objParamList);

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibScreening.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibScreening.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibScreening.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@SubQuestionId ", objLibScreening.SubQuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateScreeningSubQuestionOption", objParamList);

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                 objScreeningListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                 objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibScreening.SubQuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningSubQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objScreeningListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objScreeningListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objScreeningListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objScreeningListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetQuestionList_(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestion", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objScreeningListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objScreeningListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objScreeningListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@CategoryID", objLibScreening.CategoryID));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionbyCategoryId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objScreeningListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objScreeningListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objScreeningListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                                objScreeningListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                objScreeningListing[i].UploadQuestionImagePath = ds.Tables[0].Rows[i]["UploadQuestionImagePath"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningRandomlyBalanceQuestion", objParamList);

               
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningMarkedQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objScreeningListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objScreeningListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objScreeningListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningSubQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].SubQuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubQuestionId"].ToString());
                                objScreeningListing[i].QuesNo = ds.Tables[0].Rows[i]["QuesNo"].ToString();
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objScreeningListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objScreeningListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objScreeningListing[i].Type = ds.Tables[0].Rows[i]["Type"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestion_List", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                               
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                //objScreeningListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objScreeningListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibScreening.SubQuestionId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningSubQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                //objScreeningListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objScreeningListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int GetMaxCtmScreeningNo(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
               
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetCtmScreeningNo", objParamList);


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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
              
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));

                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningAnsText", objParamList);
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBScreening objLibScreening1 = new LIBScreening();
                    objScreeningListing.Add(objLibScreening1);
                    objScreeningListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                   string review= (ds.Tables[0].Rows[i]["Review"].ToString());
                   if (review == "0")
                   {
                       objScreeningListing[i].Review = false;
                   }
                   else
                   {
                       objScreeningListing[i].Review = true;
                   }
                    
                }

                tp.MessageResultset = (LIBScreeningListing)objScreeningListing;

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));

                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningSubAnsText", objParamList);
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBScreening objLibScreening1 = new LIBScreening();
                    objScreeningListing.Add(objLibScreening1);
                    objScreeningListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                    //string review = (ds.Tables[0].Rows[i]["Review"].ToString());
                    //if (review == "0")
                    //{
                    //    objScreeningListing[i].Review = false;
                    //}
                    //else
                    //{
                    //    objScreeningListing[i].Review = true;
                    //}

                }

                tp.MessageResultset = (LIBScreeningListing)objScreeningListing;

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));

                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningReviewMark", objParamList);
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBScreening objLibScreening1 = new LIBScreening();
                    objScreeningListing.Add(objLibScreening1);
                   
                     review = Convert.ToBoolean(ds.Tables[0].Rows[i]["Review"].ToString());
                    

                }

                tp.MessageResultset = (LIBScreeningListing)objScreeningListing;

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));

                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibScreening.SubQuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningSubquestionAnsText", objParamList);
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBScreening objLibScreening1 = new LIBScreening();
                    objScreeningListing.Add(objLibScreening1);
                    objScreeningListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());

                }

                tp.MessageResultset = (LIBScreeningListing)objScreeningListing;

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objScreeningListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibScreening.SubQuestionId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningSubQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objScreeningListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objScreeningListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetQuestionListByScrId(string ScrId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", ScrId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQues_Ans_", objParamList);                
            }
            catch (Exception ex)
            {               
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetSubQuestionListByScrId(int QuestionId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", QuestionId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningSubQues_Ans_", objParamList);
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
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objScreeningListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetScreeningCourse(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objScreeningListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBScreening.CourseId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSem", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].SemesterId = Convert.ToInt32(ds.Tables[0].Rows[i]["SemId"].ToString());
                                objScreeningListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SemId", objLIBScreening.SemesterId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetModule", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].ModuleId = Convert.ToInt32(ds.Tables[0].Rows[i]["ModuleId"].ToString());
                                objScreeningListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ModuleId", objLIBScreening.ModuleId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetPaper", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].paperId = Convert.ToInt32(ds.Tables[0].Rows[i]["PaperId"].ToString());
                                objScreeningListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int AddScreeningSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBScreening objScreening = new LIBScreening();
                objScreening = (LIBScreening)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ScreeningCode", objScreening.Screeningcode));
                objParamList.Add(new SqlParameter("@CourseId", objScreening.CourseId));
                //objParamList.Add(new SqlParameter("@SemId", objScreening.SemesterId));
                //objParamList.Add(new SqlParameter("@ModuleId", objScreening.ModuleId));
                //objParamList.Add(new SqlParameter("@PaperId", objScreening.paperId));
                objParamList.Add(new SqlParameter("@TimeAllowted", objScreening.TimeAllowted));
                objParamList.Add(new SqlParameter("@ScreeningType", objScreening.ScreeningType));
                objParamList.Add(new SqlParameter("@ScreeningPath", objScreening.ScreeningPath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertScreeningSet", objParamList);

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
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBScreening.CourseId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalarString("[SP_GetCourseCodeByID]", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public string GetScreeningTypeByScrId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLIBScreening.ScrId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetScreeningType", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public string GetScreeningPathByScrId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLIBScreening.ScrId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetScreeningPath", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public TransportationPacket GetScreeningSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetScreeningSetList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].ScrId = Convert.ToInt32(ds.Tables[0].Rows[i]["ScrId"].ToString());
                                objScreeningListing[i].Screeningcode = ds.Tables[0].Rows[i]["ScrCode"].ToString();
                                objScreeningListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                //objScreeningListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                //objScreeningListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                //objScreeningListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objScreeningListing[i].ScreeningType = ds.Tables[0].Rows[i]["ScreeningType"].ToString();
                                objScreeningListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }




        public int UpdateScreeningSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBScreening objScreening = new LIBScreening();
                objScreening = (LIBScreening)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ScrId", objScreening.ScrId));

                objParamList.Add(new SqlParameter("@TimeAllowted", objScreening.TimeAllowted));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateScreeningSet", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }




        public int SubmitScreeningAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@bid", objLibScreening.BatchId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                objParamList.Add(new SqlParameter("@Review", objLibScreening.Review));
                objParamList.Add(new SqlParameter("@CategoryId", objLibScreening.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibScreening.AnsText));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibScreening.UploadAnsPath));
                objParamList.Add(new SqlParameter("@Option", objLibScreening.Option));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddScreeningQuestionAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int SubmitSubScreeningAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibScreening.SubQuestionId));
                
                objParamList.Add(new SqlParameter("@CategoryId", objLibScreening.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibScreening.AnsText));
                objParamList.Add(new SqlParameter("@bid", objLibScreening.BatchId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddScreeningSubQuestionAnswer", objParamList);

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@categoryid", objLibScreening.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                //objParamList.Add(new SqlParameter("@qustionId", objLibScreening.QuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_CheckScreeningMaxLimit", objParamList);


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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@categoryid", objLibScreening.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
              
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetScreeningMaxAttempQues", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int DeleteScreeningAnswer(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteScreeningAnswer", objParamList);

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@categoryId", objLibScreening.CategoryID));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
               
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("getScreeningmaxquestionNo", objParamList);


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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

             
                objParamList.Add(new SqlParameter("@oldQuestionId ", objLibScreening.OldQuestionId));
                objParamList.Add(new SqlParameter("@newQuestionId ", objLibScreening.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddScreeningOldQuestionOption", objParamList);

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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newScrId ", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@oldScrId ", objLibScreening.OldScrId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddScreeningOldSectionQues", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddCopyScreeningSection(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newScrId ", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@oldScrId ", objLibScreening.OldScrId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddOldScreeningSection", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
      
        public TransportationPacket GetStudenInfo(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Studentid", objLibScreening.StudentEmail));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentAppInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].StudentName = (ds.Tables[0].Rows[i]["stuname"].ToString());
                                objScreeningListing[i].Stid = Convert.ToInt32(ds.Tables[0].Rows[i]["aid"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@userid", objLibScreening.StudentEmail));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningInstructionTotalSummary_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());
                                objScreeningListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objScreeningListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                //objScreeningListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
               
                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_ScreeningTotalAttemptQue", objParamList);


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
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatch", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objScreeningListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int AddActivateScreeningSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBScreening objScreening = new LIBScreening();
                objScreening = (LIBScreening)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ScrId", objScreening.ScrId));
                //objParamList.Add(new SqlParameter("@courseid", objScreening.CourseId));
                objParamList.Add(new SqlParameter("@activatedate", objScreening.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objScreening.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddScreeningActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetStudentScreeningSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UserId", objLIBScreening.UserId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentScreeningSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].ScrId = Convert.ToInt32(ds.Tables[0].Rows[i]["ScrId"].ToString());
                                objScreeningListing[i].Screeningcode = ds.Tables[0].Rows[i]["ScrCode"].ToString();
                                objScreeningListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                               // objScreeningListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                //objScreeningListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                //objScreeningListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                               objScreeningListing[i].ScreeningPath = ds.Tables[0].Rows[i]["ScreeningPath"].ToString();
                                objScreeningListing[i].ScreeningType = ds.Tables[0].Rows[i]["ScreeningType"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetSubmitedScreeningBatchList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBScreening.CourseId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedScreeningBatchList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["BID"].ToString());
                                objScreeningListing[i].BatchTitle = ds.Tables[0].Rows[i]["BatchCode"].ToString();
                                objScreeningListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objScreeningListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                              
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetSubmitedScreeningByBatchId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBScreening.CourseId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedScreeningList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].ScrId = Convert.ToInt32(ds.Tables[0].Rows[i]["ScrId"].ToString());
                                objScreeningListing[i].Screeningcode = ds.Tables[0].Rows[i]["ScrCode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetScreeningActivateDateByScrId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Courseid", objLIBScreening.CourseId));
                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedScreeningActiveteDate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].activateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ActivateDate"].ToString());
                                objScreeningListing[i].DeactivateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["DeactivateDate"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetUserListBySubmiitedScreening(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBScreening.CourseId));
                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
                //objParamList.Add(new SqlParameter("@activateDate", objLIBScreening.activateDate));
                //objParamList.Add(new SqlParameter("@deactivateDate", objLIBScreening.DeactivateDate));
                objParamList.Add(new SqlParameter("@Screeningtype", objLIBScreening.ScreeningType));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetUserListSubmittedScreening", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].ScrId = Convert.ToInt32(ds.Tables[0].Rows[i]["ScrId"].ToString());
                                objScreeningListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetSubmiitedScreeningByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
            
                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
               objParamList.Add(new SqlParameter("@UserId", objLIBScreening.UserId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmitedScreeningByUserId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objScreeningListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objScreeningListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objScreeningListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objScreeningListing[i].AnsText = ds.Tables[0].Rows[i]["AnsText"].ToString();
                                objScreeningListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objScreeningListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                objScreeningListing[i].UploadAnsPath = ds.Tables[0].Rows[i]["uploadpath"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet UserAurhnticate(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@email", objLIBScreening.UserName));
                objParamList.Add(new SqlParameter("@password", objLIBScreening.Password));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_UserAuthnticate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
        public int GetBid(TransportationPacket packet)
        {
            int addResult = 0;

            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Stid", objLibScreening.Stid));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_ScreeningGetBid", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int DeleteCheckboxScreeningAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibScreening.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@ScrId", objLibScreening.ScrId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));

                objParamList.Add(new SqlParameter("@CategoryId", objLibScreening.CategoryID));

                objParamList.Add(new SqlParameter("@bid", objLibScreening.BatchId));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_ScreeningDeleteChechboxanswer", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }


        public DataSet GetBatchByScrId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLIBScreening.ScrId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchByScreeningSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objScreeningListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetActivateScreeningSetData(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetActiveScreeningData", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int UpdateActivateScreeningSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBScreening objScreening = new LIBScreening();
                objScreening = (LIBScreening)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ScrId", objScreening.ScrId));
                objParamList.Add(new SqlParameter("@courseid", objScreening.CourseId));
                objParamList.Add(new SqlParameter("@activatedate", objScreening.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objScreening.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateActivateScreening", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public string GetInstruction(TransportationPacket tp)
        {
            DataSet ds = new DataSet();
            string strInstruction = "";
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLIBScreening.ScrId));
                objParamList.Add(new SqlParameter("@categoryId", objLIBScreening.CategoryID));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_ScreeningGetSectionSummary", objParamList);

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

        public int AddUserInstruction(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBScreening objScreening = new LIBScreening();
                objScreening = (LIBScreening)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ScrId", objScreening.ScrId));
                objParamList.Add(new SqlParameter("@CategoryID", objScreening.CategoryID));
                objParamList.Add(new SqlParameter("@InstructionText", objScreening.InstructionText));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_ScreeningAddUpdateStudentInstruction", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public DataSet GetUserListBySubmiitedScreening_HaveDescriptive(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBScreening.CourseId));
                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
                //objParamList.Add(new SqlParameter("@activateDate", objLIBScreening.activateDate));
                //objParamList.Add(new SqlParameter("@deactivateDate", objLIBScreening.DeactivateDate));
                //objParamList.Add(new SqlParameter("@Screeningtype", objLIBScreening.ScreeningType));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("[SP_GetUserListSubmittedScreening_HaveDescriptive]", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLIBScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLIBScreeningInner);
                                objScreeningListing[i].ScrId = Convert.ToInt32(ds.Tables[0].Rows[i]["ScrId"].ToString());
                                objScreeningListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int CheckQuestionOptionAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibScreening.AnsText));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_ScreeningCheckOptionByQuestionId", objParamList);


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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.SubQuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibScreening.AnsText));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_ScreeningCheckSubOptionByQuestionId", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public TransportationPacket GetQuestionByQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.QuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionByQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objScreeningListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());


                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
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
                LIBScreening objLibScreening = new LIBScreening();
                objLibScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibScreening.SubQuestionId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetScreeningQuestionBySubQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBScreening objLibScreeningInner = new LIBScreening();
                                objScreeningListing.Add(objLibScreeningInner);
                                objScreeningListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objScreeningListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetSubmitedDescriptiveScreeningByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
                objParamList.Add(new SqlParameter("@UserId", objLIBScreening.UserId));
                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("[SP_GetSubmitedDescriptiveScreeningByUserId]", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {

                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet ReportStudentActivateScreening(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
                objParamList.Add(new SqlParameter("@courseid", objLIBScreening.CourseId));
                objParamList.Add(new SqlParameter("@activate", objLIBScreening.Activate));
               

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ReportScreeningActvateStudentInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
    
        public int AddActivateStudentScreeningSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBScreening objScreening = new LIBScreening();
                objScreening = (LIBScreening)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@ScrId", objScreening.ScrId));
                objParamList.Add(new SqlParameter("@courseid", objScreening.CourseId));
                objParamList.Add(new SqlParameter("@userid", objScreening.UserId));



                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddStudentScreeningInActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }


        public DataSet StudentInActivateScreening(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
                objParamList.Add(new SqlParameter("@courseid", objLIBScreening.CourseId));
                objParamList.Add(new SqlParameter("@years", objLIBScreening.years));

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentListForActivateScreening", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        

        public DataSet StudentYears(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_studentYears", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet StudentInActivateScreeningSearch(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBScreening objLIBScreening = new LIBScreening();
                objLIBScreening = (LIBScreening)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Scrid", objLIBScreening.ScrId));
                objParamList.Add(new SqlParameter("@courseid", objLIBScreening.CourseId));
                objParamList.Add(new SqlParameter("@searchtxt", objLIBScreening.searchtxt));


                LIBScreeningListing objScreeningListing = new LIBScreeningListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentListForActivateScreeningSearch", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBScreeningListing)objScreeningListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
  }




}
