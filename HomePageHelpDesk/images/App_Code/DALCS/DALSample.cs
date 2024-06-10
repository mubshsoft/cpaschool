using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;
namespace fmsf.DAL
{
    public class DALSample
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
       
     
    
       
        public int DeleteSampleCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddSampleCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CategoryName", objLibSample.CategoryName));
                
                 objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSampleCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetSampleInstruction(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleInstruction", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].CourseTitle = (ds.Tables[0].Rows[i]["CourseTitle"].ToString());
                                objSampleListing[i].CourseCode = ds.Tables[0].Rows[i]["CourseCode"].ToString();
                                objSampleListing[i].Samplecode = ds.Tables[0].Rows[i]["Samplecode"].ToString();
                                //objSampleListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int DeleteSampleQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
         public int DeleteSampleQuestionanswer(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleQuestionanswers", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteSampleSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleSubQuestion", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibSample.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleQuestionOption", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibSample.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleSubQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteSample(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleset", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateSampleQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibSample.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibSample.Answer));
                objParamList.Add(new SqlParameter("@MaxQueMarks", objLibSample.MaxQueMarks));
                objParamList.Add(new SqlParameter("@Descriptive", objLibSample.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibSample.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibSample.QUESTYPE));
                //objParamList.Add(new SqlParameter("@QuesNo ", objLibSample.QuesNo));
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@CategoryId", objLibSample.CategoryID));
                objParamList.Add(new SqlParameter("@UploadQuestionImagePath", objLibSample.UploadQuestionImagePath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateSampleQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateSampleSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibSample.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibSample.Answer));
                objParamList.Add(new SqlParameter("@Type", objLibSample.Type));
                objParamList.Add(new SqlParameter("@Descriptive", objLibSample.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibSample.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibSample.QUESTYPE));
                objParamList.Add(new SqlParameter("@QuesNo ", objLibSample.QuesNo));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));
                //objParamList.Add(new SqlParameter("@Type", objLibSample.Type));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateSampleSubQuestion", objParamList);

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
                LIBSample objSample = new LIBSample();
                objSample = (LIBSample)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@SamId", objSample.SamId));
                objParamList.Add(new SqlParameter("@CategoryId", objSample.CategoryID));
                objParamList.Add(new SqlParameter("@MaxNoQue", objSample.MaxQueInSection));
                objParamList.Add(new SqlParameter("@AttemptQue", objSample.MaxAttemptQue));



                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertSampleQuextInSection", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateMaualSampleAnswers(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibSample.UploadAnsPath));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSampleManualAnswer", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@categoryId", objLibSample.CategoryID));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetSampleNoSectionQuestion", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objSampleListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());
                                
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibSample.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibSample.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibSample.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibSample.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateSampleQuestionOption", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibSample.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibSample.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibSample.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@SubQuestionId ", objLibSample.SubQuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateSampleSubQuestionOption", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                 objSampleListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                 objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleSubQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objSampleListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objSampleListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objSampleListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objSampleListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objSampleListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestion", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objSampleListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objSampleListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objSampleListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objSampleListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@CategoryID", objLibSample.CategoryID));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestionbyCategoryId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objSampleListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objSampleListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objSampleListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objSampleListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                                objSampleListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                objSampleListing[i].UploadQuestionImagePath = ds.Tables[0].Rows[i]["UploadQuestionImagePath"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleRandomlyBalanceQuestion", objParamList);

               
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleMarkedQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objSampleListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objSampleListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objSampleListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objSampleListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleSubQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].SubQuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubQuestionId"].ToString());
                                objSampleListing[i].QuesNo = ds.Tables[0].Rows[i]["QuesNo"].ToString();
                                objSampleListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objSampleListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objSampleListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objSampleListing[i].Type = ds.Tables[0].Rows[i]["Type"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestion_List", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                
                                objSampleListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                               
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {


                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                //objSampleListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objSampleListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleSubQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                //objSampleListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objSampleListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int GetMaxCtmSampleNo(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
               
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetCtmSampleNo", objParamList);


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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
              
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));

                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleAnsText", objParamList);
                LIBSampleListing objSampleListing = new LIBSampleListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBSample objLibSample1 = new LIBSample();
                    objSampleListing.Add(objLibSample1);
                    objSampleListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                   string review= (ds.Tables[0].Rows[i]["Review"].ToString());
                   if (review == "0")
                   {
                       objSampleListing[i].Review = false;
                   }
                   else
                   {
                       objSampleListing[i].Review = true;
                   }
                    
                }

                tp.MessageResultset = (LIBSampleListing)objSampleListing;

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));

                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleSubAnsText", objParamList);
                LIBSampleListing objSampleListing = new LIBSampleListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBSample objLibSample1 = new LIBSample();
                    objSampleListing.Add(objLibSample1);
                    objSampleListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                    //string review = (ds.Tables[0].Rows[i]["Review"].ToString());
                    //if (review == "0")
                    //{
                    //    objSampleListing[i].Review = false;
                    //}
                    //else
                    //{
                    //    objSampleListing[i].Review = true;
                    //}

                }

                tp.MessageResultset = (LIBSampleListing)objSampleListing;

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));

                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleReviewMark", objParamList);
                LIBSampleListing objSampleListing = new LIBSampleListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBSample objLibSample1 = new LIBSample();
                    objSampleListing.Add(objLibSample1);
                   
                     review = Convert.ToBoolean(ds.Tables[0].Rows[i]["Review"].ToString());
                    

                }

                tp.MessageResultset = (LIBSampleListing)objSampleListing;

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));

                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleSubquestionAnsText", objParamList);
                LIBSampleListing objSampleListing = new LIBSampleListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBSample objLibSample1 = new LIBSample();
                    objSampleListing.Add(objLibSample1);
                    objSampleListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());

                }

                tp.MessageResultset = (LIBSampleListing)objSampleListing;

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objSampleListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleSubQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objSampleListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objSampleListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetQuestionListBySamId(string SamId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", SamId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQues_Ans_", objParamList);                
            }
            catch (Exception ex)
            {               
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetSubQuestionListBySamId(int QuestionId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", QuestionId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleSubQues_Ans_", objParamList);
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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objSampleListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetSampleCourse(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objSampleListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBSample.CourseId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSem", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].SemesterId = Convert.ToInt32(ds.Tables[0].Rows[i]["SemId"].ToString());
                                objSampleListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SemId", objLIBSample.SemesterId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetModule", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].ModuleId = Convert.ToInt32(ds.Tables[0].Rows[i]["ModuleId"].ToString());
                                objSampleListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ModuleId", objLIBSample.ModuleId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetPaper", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].paperId = Convert.ToInt32(ds.Tables[0].Rows[i]["PaperId"].ToString());
                                objSampleListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int AddSampleSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBSample objSample = new LIBSample();
                objSample = (LIBSample)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@SampleCode", objSample.Samplecode));
                objParamList.Add(new SqlParameter("@CourseId", objSample.CourseId));
                //objParamList.Add(new SqlParameter("@SemId", objSample.SemesterId));
                //objParamList.Add(new SqlParameter("@ModuleId", objSample.ModuleId));
                //objParamList.Add(new SqlParameter("@PaperId", objSample.paperId));
                objParamList.Add(new SqlParameter("@TimeAllowted", objSample.TimeAllowted));
                objParamList.Add(new SqlParameter("@SampleType", objSample.SampleType));
                objParamList.Add(new SqlParameter("@SamplePath", objSample.SamplePath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertSampleSet", objParamList);

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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBSample.CourseId));

                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalarString("[SP_GetCourseCodeByID]", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public string GetSampleTypeBySamId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));

                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetSampleType", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public string GetSamplePathBySamId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));

                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetSamplePath", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int UpdateSampleSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBSample objSample = new LIBSample();
                objSample = (LIBSample)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@SamId", objSample.SamId));

                objParamList.Add(new SqlParameter("@TimeAllowted", objSample.TimeAllowted));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateSampleSet", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }




        public TransportationPacket GetSampleSetList_(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBSample.CourseId));

                objParamList.Add(new SqlParameter("@Year", objLIBSample.Year));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetSampleSetList_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].SamId = Convert.ToInt32(ds.Tables[0].Rows[i]["SamId"].ToString());
                                objSampleListing[i].Samplecode = ds.Tables[0].Rows[i]["SamCode"].ToString();
                                objSampleListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                //objSampleListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                //objSampleListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objSampleListing[i].CreateDate = ds.Tables[0].Rows[i]["CreateDate"].ToString();
                                objSampleListing[i].SampleType = ds.Tables[0].Rows[i]["SampleType"].ToString();
                                objSampleListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public TransportationPacket GetSampleSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
               

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetSampleSetList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].SamId = Convert.ToInt32(ds.Tables[0].Rows[i]["SamId"].ToString());
                                objSampleListing[i].Samplecode = ds.Tables[0].Rows[i]["SamCode"].ToString();
                                objSampleListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                //objSampleListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                //objSampleListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                //objSampleListing[i].CreateDate = ds.Tables[0].Rows[i]["CreateDate"].ToString();
                                objSampleListing[i].SampleType = ds.Tables[0].Rows[i]["SampleType"].ToString();
                                objSampleListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }


        public int SubmitSampleAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@bid", objLibSample.BatchId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                objParamList.Add(new SqlParameter("@Review", objLibSample.Review));
                objParamList.Add(new SqlParameter("@CategoryId", objLibSample.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibSample.AnsText));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibSample.UploadAnsPath));
                objParamList.Add(new SqlParameter("@Option", objLibSample.Option));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSampleQuestionAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int SubmitSubSampleAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));
                
                objParamList.Add(new SqlParameter("@CategoryId", objLibSample.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibSample.AnsText));
                objParamList.Add(new SqlParameter("@bid", objLibSample.BatchId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSampleSubQuestionAnswer", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@categoryid", objLibSample.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                //objParamList.Add(new SqlParameter("@qustionId", objLibSample.QuestionId));
                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_CheckSampleMaxLimit", objParamList);


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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@categoryid", objLibSample.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
              
                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetSampleMaxAttempQues", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int DeleteSampleAnswer(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteSampleAnswer", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@categoryId", objLibSample.CategoryID));
                LIBSampleListing objSampleListing = new LIBSampleListing();


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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
               
                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("getSamplemaxquestionNo", objParamList);


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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

             
                objParamList.Add(new SqlParameter("@oldQuestionId ", objLibSample.OldQuestionId));
                objParamList.Add(new SqlParameter("@newQuestionId ", objLibSample.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSampleOldQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetSampleQuestionBySubQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibSample.SubQuestionId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestionBySubQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objSampleListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetSampleQuestionByQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleQuestionByQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objSampleListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public int AddCopySectionQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newSamId ", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@oldSamId ", objLibSample.OldSamId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSampleOldSectionQues", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddCopySampleSection(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newSamId ", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@oldSamId ", objLibSample.OldSamId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddOldSampleSection", objParamList);

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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Studentid", objLibSample.StudentEmail));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].StudentName = (ds.Tables[0].Rows[i]["stuname"].ToString());
                                objSampleListing[i].Stid = Convert.ToInt32(ds.Tables[0].Rows[i]["stid"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@userid", objLibSample.StudentEmail));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSampleInstructionTotalSummary_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());
                                objSampleListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objSampleListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                //objSampleListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
               
                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));
                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_SampleTotalAttemptQue", objParamList);


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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatch", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objSampleListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int AddActivateSampleSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBSample objSample = new LIBSample();
                objSample = (LIBSample)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@SamId", objSample.SamId));
                objParamList.Add(new SqlParameter("@BatchId", objSample.BatchId));
                objParamList.Add(new SqlParameter("@activatedate", objSample.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objSample.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddSampleActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetStudentSampleSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                //objParamList.Add(new SqlParameter("@UserId", objLIBSample.UserId));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentSampleSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].SamId = Convert.ToInt32(ds.Tables[0].Rows[i]["SamId"].ToString());
                                objSampleListing[i].Samplecode = ds.Tables[0].Rows[i]["SamCode"].ToString();
                                objSampleListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                               // objSampleListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                //objSampleListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                //objSampleListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                              // objSampleListing[i].SamplePath = ds.Tables[0].Rows[i]["SamplePath"].ToString();
                                objSampleListing[i].SampleType = ds.Tables[0].Rows[i]["SampleType"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetSubmitedSampleBatchList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBSample.CourseId));

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedSampleBatchList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLibSampleInner = new LIBSample();
                                objSampleListing.Add(objLibSampleInner);
                                objSampleListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["BID"].ToString());
                                objSampleListing[i].BatchTitle = ds.Tables[0].Rows[i]["BatchCode"].ToString();
                                objSampleListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objSampleListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                              
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public DataSet GetSubmitedSampleByBatchId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBSample.CourseId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedSampleList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].SamId = Convert.ToInt32(ds.Tables[0].Rows[i]["SamId"].ToString());
                                objSampleListing[i].Samplecode = ds.Tables[0].Rows[i]["ScrCode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetSampleActivateDateBySamId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Courseid", objLIBSample.CourseId));
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedSampleActiveteDate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].activateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ActivateDate"].ToString());
                                objSampleListing[i].DeactivateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["DeactivateDate"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetUserListBySubmiitedSample(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBSample.CourseId));
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));
                objParamList.Add(new SqlParameter("@activateDate", objLIBSample.activateDate));
                objParamList.Add(new SqlParameter("@deactivateDate", objLIBSample.DeactivateDate));
                objParamList.Add(new SqlParameter("@Sampletype", objLIBSample.SampleType));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetUserListSubmittedSample", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].SamId = Convert.ToInt32(ds.Tables[0].Rows[i]["SamId"].ToString());
                                objSampleListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetSubmiitedSampleByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
            
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));
               objParamList.Add(new SqlParameter("@UserId", objLIBSample.UserId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmitedSampleByUserId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objSampleListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objSampleListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objSampleListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objSampleListing[i].AnsText = ds.Tables[0].Rows[i]["AnsText"].ToString();
                                objSampleListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objSampleListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                objSampleListing[i].UploadAnsPath = ds.Tables[0].Rows[i]["uploadpath"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@email", objLIBSample.UserName));
                objParamList.Add(new SqlParameter("@password", objLIBSample.Password));
                LIBSampleListing objSampleListing = new LIBSampleListing();

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
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Stid", objLibSample.Stid));

                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_SampleGetBid", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int DeleteCheckboxSampleAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibSample.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@SamId", objLibSample.SamId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));

                objParamList.Add(new SqlParameter("@CategoryId", objLibSample.CategoryID));

                objParamList.Add(new SqlParameter("@bid", objLibSample.BatchId));

                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_SampleDeleteChechboxanswer", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }


        public DataSet GetBatchBySamId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchBySampleSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objSampleListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public DataSet GetActivateSampleSetData(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetActiveSampleData", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int UpdateActivateSampleSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBSample objSample = new LIBSample();
                objSample = (LIBSample)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@SamId", objSample.SamId));
                objParamList.Add(new SqlParameter("@courseid", objSample.CourseId));
                objParamList.Add(new SqlParameter("@activatedate", objSample.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objSample.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateActivateSample", objParamList);

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
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));
                objParamList.Add(new SqlParameter("@categoryId", objLIBSample.CategoryID));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_SampleGetSectionSummary", objParamList);

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
                LIBSample objSample = new LIBSample();
                objSample = (LIBSample)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@SamId", objSample.SamId));
                objParamList.Add(new SqlParameter("@CategoryID", objSample.CategoryID));
                objParamList.Add(new SqlParameter("@InstructionText", objSample.InstructionText));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_SampleAddUpdateStudentInstruction", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.QuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibSample.AnsText));
                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_SampleCheckOptionByQuestionId", objParamList);


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
                LIBSample objLibSample = new LIBSample();
                objLibSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibSample.SubQuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibSample.AnsText));
                LIBSampleListing objSampleListing = new LIBSampleListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_SampleCheckSubOptionByQuestionId", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public DataSet GetBatchBySampleId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBSample objLIBSample = new LIBSample();
                objLIBSample = (LIBSample)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLIBSample.SamId));
                LIBSampleListing objSampleListing = new LIBSampleListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchBySampleSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBSample objLIBSampleInner = new LIBSample();
                                objSampleListing.Add(objLIBSampleInner);
                                objSampleListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objSampleListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBSampleListing)objSampleListing;
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
