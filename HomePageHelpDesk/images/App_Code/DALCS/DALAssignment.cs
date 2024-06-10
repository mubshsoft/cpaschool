using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;
namespace fmsf.DAL
{
  public class DALAssignment
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
       
     
    
       
        public int DeleteAssignmentCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddAssignmentCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CategoryName", objLibAssignment.CategoryName));
                
                 objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetAssignmentInstruction(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentInstruction", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].CourseTitle = (ds.Tables[0].Rows[i]["CourseTitle"].ToString());
                                objAssignmentListing[i].CourseCode = ds.Tables[0].Rows[i]["CourseCode"].ToString();
                                objAssignmentListing[i].Assignmentcode = ds.Tables[0].Rows[i]["Assignmentcode"].ToString();
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

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
            return packet;
        }
        public int DeleteAssignmentQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteAssignmentSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.SubQuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentSubQuestion", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibAssignment.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentQuestionOption", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibAssignment.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentSubQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteAssignment(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentset", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddUpdateAssignmentQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibAssignment.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibAssignment.Answer));
                objParamList.Add(new SqlParameter("@MaxQueMarks", objLibAssignment.MaxQueMarks));
                objParamList.Add(new SqlParameter("@Descriptive", objLibAssignment.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibAssignment.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibAssignment.QUESTYPE));
                //objParamList.Add(new SqlParameter("@QuesNo ", objLibAssignment.QuesNo));
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@CategoryId", objLibAssignment.CategoryID));
                objParamList.Add(new SqlParameter("@UploadQuestionImagePath", objLibAssignment.UploadQuestionImagePath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateAssignmentQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateAssignmentSubQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionText", objLibAssignment.QuestionText));
                objParamList.Add(new SqlParameter("@Answer", objLibAssignment.Answer));
                objParamList.Add(new SqlParameter("@Type", objLibAssignment.Type));
                objParamList.Add(new SqlParameter("@Descriptive", objLibAssignment.Descriptive));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibAssignment.QuestionId));
                objParamList.Add(new SqlParameter("@QUESTYPE ", objLibAssignment.QUESTYPE));
                objParamList.Add(new SqlParameter("@QuesNo ", objLibAssignment.QuesNo));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.SubQuestionId));
                //objParamList.Add(new SqlParameter("@CategoryId", objLibAssignment.CategoryID));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateAssignmentSubQuestion", objParamList);

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
                LIBAssignment objAssignment = new LIBAssignment();
                objAssignment = (LIBAssignment)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@AsgnId", objAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@CategoryId", objAssignment.CategoryID));
                objParamList.Add(new SqlParameter("@MaxNoQue", objAssignment.MaxQueInSection));
                objParamList.Add(new SqlParameter("@AttemptQue", objAssignment.MaxAttemptQue));



                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertAssignmentQuextInSection", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateMaualAssignmentAnswers(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibAssignment.UploadAnsPath));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentManualAnswer", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@categoryId", objLibAssignment.CategoryID));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_GetAssignmentNoSectionQuestion", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objAssignmentListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());
                                
                            }

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
            return packet;
        }

        public int AddUpdateQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibAssignment.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibAssignment.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibAssignment.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@QuestionId ", objLibAssignment.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateAssignmentQuestionOption", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibAssignment.OPTID));
                objParamList.Add(new SqlParameter("@OPTIONS", objLibAssignment.OPTIONS));
                objParamList.Add(new SqlParameter("@OPTIONTYPE", objLibAssignment.OPTIONTYPE));
                objParamList.Add(new SqlParameter("@SubQuestionId ", objLibAssignment.SubQuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateAssignmentSubQuestionOption", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                 objAssignmentListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                 objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

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
            return packet;
        }
        public TransportationPacket GetSubQuestionOptionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.SubQuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubQuestionOption", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objAssignmentListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

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
            return packet;
        }


        public TransportationPacket GetQuestionByQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestionByQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString());
                                objAssignmentListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());
                                
                            }

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
            return packet;
        }


        public TransportationPacket GetSubQuestionByQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.QuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubQuestionByQuestionId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].Question = (ds.Tables[0].Rows[i]["QuestionText"].ToString()); 
                                objAssignmentListing[i].AnsText = (ds.Tables[0].Rows[i]["Answer"].ToString());


                            }

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
            return packet;
        }
        public DataSet GetQuestionList_(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestion", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objAssignmentListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objAssignmentListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objAssignmentListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

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

        public DataSet GetQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objAssignmentListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objAssignmentListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objAssignmentListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

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

        public TransportationPacket GetQuestionListbyCategory(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@CategoryID", objLibAssignment.CategoryID));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestionbyCategoryId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objAssignmentListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objAssignmentListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objAssignmentListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                                objAssignmentListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                objAssignmentListing[i].UploadQuestionImagePath = ds.Tables[0].Rows[i]["UploadQuestionImagePath"].ToString();
                            }

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
            return packet;
        }
        public DataSet GetBalQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentRandomlyBalanceQuestion", objParamList);

               
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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentMarkedQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                //objAssignmentListing[i].QuesNo = Convert.ToInt32(ds.Tables[0].Rows[i]["QuesNo"].ToString());
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objAssignmentListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objAssignmentListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                            }

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
        public TransportationPacket GetSubQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubQuestion_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].SubQuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubQuestionId"].ToString());
                                objAssignmentListing[i].QuesNo = ds.Tables[0].Rows[i]["QuesNo"].ToString();
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objAssignmentListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objAssignmentListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objAssignmentListing[i].Type = ds.Tables[0].Rows[i]["Type"].ToString();

                            }

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
            return packet;
        }
        public TransportationPacket GetQuestion(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestion_List", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].QuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                               
                            }

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
            return packet;
        }
        public DataSet GetQuestionOptionList2(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestionOption", objParamList);

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

        public TransportationPacket GetQuestionOptionListByOptionType(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                //objAssignmentListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objAssignmentListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

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
            return packet;
        }
        public TransportationPacket GetSubQuestionOptionListByOptionType(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.SubQuestionId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubQuestionOptionByOptionType", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                //objAssignmentListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                //objAssignmentListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

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
            return packet;
        }
        public int GetMaxCtmAssignmentNo(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
               
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetCtmAssignmentNo", objParamList);


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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
              
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));

                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentAnsText", objParamList);
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBAssignment objLibAssignment1 = new LIBAssignment();
                    objAssignmentListing.Add(objLibAssignment1);
                    objAssignmentListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                   string review= (ds.Tables[0].Rows[i]["Review"].ToString());
                   if (review == "0")
                   {
                       objAssignmentListing[i].Review = false;
                   }
                   else
                   {
                       objAssignmentListing[i].Review = true;
                   }
                    
                }

                tp.MessageResultset = (LIBAssignmentListing)objAssignmentListing;

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));

                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubAnsText", objParamList);
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBAssignment objLibAssignment1 = new LIBAssignment();
                    objAssignmentListing.Add(objLibAssignment1);
                    objAssignmentListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());
                    //string review = (ds.Tables[0].Rows[i]["Review"].ToString());
                    //if (review == "0")
                    //{
                    //    objAssignmentListing[i].Review = false;
                    //}
                    //else
                    //{
                    //    objAssignmentListing[i].Review = true;
                    //}

                }

                tp.MessageResultset = (LIBAssignmentListing)objAssignmentListing;

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));

                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentReviewMark", objParamList);
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBAssignment objLibAssignment1 = new LIBAssignment();
                    objAssignmentListing.Add(objLibAssignment1);
                   
                     review = Convert.ToBoolean(ds.Tables[0].Rows[i]["Review"].ToString());
                    

                }

                tp.MessageResultset = (LIBAssignmentListing)objAssignmentListing;

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));

                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.SubQuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubquestionAnsText", objParamList);
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBAssignment objLibAssignment1 = new LIBAssignment();
                    objAssignmentListing.Add(objLibAssignment1);
                    objAssignmentListing[i].AnsText = (ds.Tables[0].Rows[i]["AnsText"].ToString());

                }

                tp.MessageResultset = (LIBAssignmentListing)objAssignmentListing;

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objAssignmentListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

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
            return packet;
        }
        public TransportationPacket GetSubQuestionOptionListByOptionTypeAll(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.SubQuestionId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubQuestionOptionByOptionType_All", objParamList);


                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].OPTID = Convert.ToInt32(ds.Tables[0].Rows[i]["OPTID"].ToString());
                                objAssignmentListing[i].OPTIONS = ds.Tables[0].Rows[i]["OPTIONS"].ToString();
                                objAssignmentListing[i].OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();

                            }

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
            return packet;
        }
        public DataSet GetQuestionListByAsgnId(string AsgnId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", AsgnId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentQues_Ans_", objParamList);                
            }
            catch (Exception ex)
            {               
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public DataSet GetSubQuestionListByAsgnId(int QuestionId)
        {
            DataSet ds = new DataSet();
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", QuestionId));

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentSubQues_Ans_", objParamList);
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
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCourse", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();

                            }

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
            return packet;
        }

        public TransportationPacket GetSemester(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBAssignment.CourseId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSem", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].SemesterId = Convert.ToInt32(ds.Tables[0].Rows[i]["SemId"].ToString());
                                objAssignmentListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();

                            }

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
            return packet;
        }

        public TransportationPacket GetModule(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SemId", objLIBAssignment.SemesterId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetModule", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].ModuleId = Convert.ToInt32(ds.Tables[0].Rows[i]["ModuleId"].ToString());
                                objAssignmentListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();

                            }

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
            return packet;
        }

        public TransportationPacket GetPaper(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ModuleId", objLIBAssignment.ModuleId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetPaper", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].paperId = Convert.ToInt32(ds.Tables[0].Rows[i]["PaperId"].ToString());
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();

                            }

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
            return packet;
        }
        public int AddAssignmentSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBAssignment objAssignment = new LIBAssignment();
                objAssignment = (LIBAssignment)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@AssignmentCode", objAssignment.Assignmentcode));
                objParamList.Add(new SqlParameter("@CourseId", objAssignment.CourseId));
                objParamList.Add(new SqlParameter("@SemId", objAssignment.SemesterId));
                objParamList.Add(new SqlParameter("@ModuleId", objAssignment.ModuleId));
                objParamList.Add(new SqlParameter("@PaperId", objAssignment.paperId));
                objParamList.Add(new SqlParameter("@TimeAllowted", objAssignment.TimeAllowted));
                objParamList.Add(new SqlParameter("@AssignmentType", objAssignment.AssignmentType));
                objParamList.Add(new SqlParameter("@AssignmentPath", objAssignment.AssignmentPath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_InsertAssignmentSet", objParamList);

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
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBAssignment.CourseId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalarString("[SP_GetCourseCodeByID]", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public string GetAssignmentTypeByAsgnId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetAssignmentType", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public string GetAssignmentPathByAsgnId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetAssignmentPath", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public TransportationPacket GetAssignmentSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

              
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetAssignmentSetList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].AsgnId = Convert.ToInt32(ds.Tables[0].Rows[i]["AsgnId"].ToString());
                                objAssignmentListing[i].Assignmentcode = ds.Tables[0].Rows[i]["AsgnCode"].ToString();
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objAssignmentListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objAssignmentListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                //objAssignmentListing[i].CreateDate = ds.Tables[0].Rows[i]["createdate"].ToString();
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objAssignmentListing[i].AssignmentType = ds.Tables[0].Rows[i]["AssignmentType"].ToString();
                                objAssignmentListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

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
            return packet;
        }


        public TransportationPacket GetAssignmentSetList_(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CourseId", objLIBAssignment.CourseId));

                objParamList.Add(new SqlParameter("@Year", objLIBAssignment.Year));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetAssignmentSetList_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].AsgnId = Convert.ToInt32(ds.Tables[0].Rows[i]["AsgnId"].ToString());
                                objAssignmentListing[i].Assignmentcode = ds.Tables[0].Rows[i]["AsgnCode"].ToString();
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objAssignmentListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objAssignmentListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objAssignmentListing[i].CreateDate = ds.Tables[0].Rows[i]["createdate"].ToString();
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objAssignmentListing[i].AssignmentType = ds.Tables[0].Rows[i]["AssignmentType"].ToString();
                                objAssignmentListing[i].AssignmentPath = ds.Tables[0].Rows[i]["AssignmentPath"].ToString();
                                objAssignmentListing[i].TimeAllowted = Convert.ToInt32(ds.Tables[0].Rows[i]["TimeAllowted"].ToString());
                            }

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
            return packet;
        }


        public int UpdateAssignmentSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBAssignment objAssignment = new LIBAssignment();
                objAssignment = (LIBAssignment)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@AsgnId", objAssignment.AsgnId));

                objParamList.Add(new SqlParameter("@TimeAllowted", objAssignment.TimeAllowted));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateAssignmentSet", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int SubmitAssignmentAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@bid", objLibAssignment.BatchId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                objParamList.Add(new SqlParameter("@Review", objLibAssignment.Review));
                objParamList.Add(new SqlParameter("@CategoryId", objLibAssignment.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibAssignment.AnsText));
                objParamList.Add(new SqlParameter("@UploadAnsPath", objLibAssignment.UploadAnsPath));
                objParamList.Add(new SqlParameter("@Option", objLibAssignment.Option));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentQuestionAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int SubmitSubAssignmentAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@SubQuestionId", objLibAssignment.SubQuestionId));
                objParamList.Add(new SqlParameter("@CategoryId", objLibAssignment.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibAssignment.AnsText));
                objParamList.Add(new SqlParameter("@bid", objLibAssignment.BatchId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentSubQuestionAnswer", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@categoryid", objLibAssignment.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                //objParamList.Add(new SqlParameter("@qustionId", objLibAssignment.QuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_CheckAssignmentMaxLimit", objParamList);


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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@categoryid", objLibAssignment.CategoryID));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
              
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_GetAssignmentMaxAttempQues", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int DeleteAssignmentAnswer(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssignmentAnswer", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@categoryId", objLibAssignment.CategoryID));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
               
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("getAssignmentmaxquestionNo", objParamList);


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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

             
                objParamList.Add(new SqlParameter("@oldQuestionId ", objLibAssignment.OldQuestionId));
                objParamList.Add(new SqlParameter("@newQuestionId ", objLibAssignment.QuestionId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentOldQuestionOption", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newAsgnId ", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@oldAsgnId ", objLibAssignment.OldAsgnId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentOldSectionQues", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int AddCopyAssignmentSection(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();


                objParamList.Add(new SqlParameter("@newAsgnId ", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@oldAsgnId ", objLibAssignment.OldAsgnId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddOldAssignmentSection", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Studentid", objLibAssignment.StudentEmail));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentInfo", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].StudentName = (ds.Tables[0].Rows[i]["stuname"].ToString());
                                objAssignmentListing[i].Stid = Convert.ToInt32(ds.Tables[0].Rows[i]["stid"].ToString());

                            }

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
            return packet;
        }

        public DataSet GetInstructionSummary(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@userid", objLibAssignment.StudentEmail));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignmentInstructionTotalSummary_", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].MaxAttemptQue = Convert.ToInt32(ds.Tables[0].Rows[i]["AttemptQue"].ToString());
                                objAssignmentListing[i].MaxQueInSection = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxNoQue"].ToString());
                                objAssignmentListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                //objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                            }

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
        public int GetToatalAttemptQue(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
               
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_AssignmentTotalAttemptQue", objParamList);


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
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatch", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objAssignmentListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

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
        public int AddActivateAssignmentSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBAssignment objAssignment = new LIBAssignment();
                objAssignment = (LIBAssignment)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@AsgnId", objAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@batchid", objAssignment.BatchId));
                objParamList.Add(new SqlParameter("@activatedate", objAssignment.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objAssignment.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetStudentAssignmentSetList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UserId", objLIBAssignment.UserId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentAssignmentSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].AsgnId = Convert.ToInt32(ds.Tables[0].Rows[i]["AsgnId"].ToString());
                                objAssignmentListing[i].Assignmentcode = ds.Tables[0].Rows[i]["AsgnCode"].ToString();
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objAssignmentListing[i].SemesterTitle = ds.Tables[0].Rows[i]["SemesterTitle"].ToString();
                                objAssignmentListing[i].ModuleTitle = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                                objAssignmentListing[i].PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                                objAssignmentListing[i].AssignmentPath = ds.Tables[0].Rows[i]["AssignmentPath"].ToString();
                                objAssignmentListing[i].AssignmentType = ds.Tables[0].Rows[i]["AssignmentType"].ToString();

                            }

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
            return packet;
        }
        public TransportationPacket GetSubmitedAssignmentBatchList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@courseid", objLIBAssignment.CourseId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedAssignmentBatchList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLibAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLibAssignmentInner);
                                objAssignmentListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["BID"].ToString());
                                objAssignmentListing[i].BatchTitle = ds.Tables[0].Rows[i]["BatchCode"].ToString();
                                objAssignmentListing[i].CourseTitle = ds.Tables[0].Rows[i]["CourseTitle"].ToString();
                                objAssignmentListing[i].CourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseId"].ToString());
                              
                            }

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
            return packet;
        }
        public DataSet GetSubmitedAssignmentByBatchId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedAssignmentList", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].AsgnId = Convert.ToInt32(ds.Tables[0].Rows[i]["AsgnId"].ToString());
                                objAssignmentListing[i].Assignmentcode = ds.Tables[0].Rows[i]["AsgnCode"].ToString();

                            }

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

        public DataSet GetSubmiitedCaseStudyAssignmentByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLIBAssignment.UserId));
                objParamList.Add(new SqlParameter("@QuesId", objLIBAssignment.QuestionId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("[SP_GetSubmitedCaseStudyAssigmentByUserId_new]", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objAssignmentListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objAssignmentListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objAssignmentListing[i].AnsText = ds.Tables[0].Rows[i]["AnsText"].ToString();
                                objAssignmentListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objAssignmentListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                            }

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
        public DataSet GetAssignmentActivateDateByAsgnId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@asgnid", objLIBAssignment.AsgnId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmittedAssignmentActiveteDate", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].activateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ActivateDate"].ToString());
                                objAssignmentListing[i].DeactivateDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["DeactivateDate"].ToString());

                            }

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
        public DataSet GetUserListBySubmiitedAssignment(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@asgnid", objLIBAssignment.AsgnId));
                //objParamList.Add(new SqlParameter("@activateDate", objLIBAssignment.activateDate));
                //objParamList.Add(new SqlParameter("@deactivateDate", objLIBAssignment.DeactivateDate));
                objParamList.Add(new SqlParameter("@Assignmenttype", objLIBAssignment.AssignmentType));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetUserListSubmittedAssignment", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].AsgnId = Convert.ToInt32(ds.Tables[0].Rows[i]["AsgnId"].ToString());
                                objAssignmentListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

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
        public DataSet GetSubmiitedAssignmentByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
            
                objParamList.Add(new SqlParameter("@asgnid", objLIBAssignment.AsgnId));
               objParamList.Add(new SqlParameter("@UserId", objLIBAssignment.UserId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetSubmitedAssignmentByUserId", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objAssignmentListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objAssignmentListing[i].QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                objAssignmentListing[i].QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                objAssignmentListing[i].AnsText = ds.Tables[0].Rows[i]["AnsText"].ToString();
                                objAssignmentListing[i].Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                objAssignmentListing[i].MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                objAssignmentListing[i].UploadAnsPath = ds.Tables[0].Rows[i]["uploadpath"].ToString();
                            }

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
        public DataSet GetUserListBySubmiitedAssignment_HaveDescriptive(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@asgnid", objLIBAssignment.AsgnId));
                //objParamList.Add(new SqlParameter("@activateDate", objLIBAssignment.activateDate));
                //objParamList.Add(new SqlParameter("@deactivateDate", objLIBAssignment.DeactivateDate));
                //objParamList.Add(new SqlParameter("@Assignmenttype", objLIBAssignment.AssignmentType));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("[SP_GetUserListSubmittedAssignment_HaveDescriptive]", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].AsgnId = Convert.ToInt32(ds.Tables[0].Rows[i]["AsgnId"].ToString());
                                objAssignmentListing[i].UserId = ds.Tables[0].Rows[i]["UserId"].ToString();

                            }

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

        public DataSet GetSubmitedDescriptiveAssignmentByUserId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@asgnid", objLIBAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLIBAssignment.UserId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("[SP_GetSubmitedDescriptiveAssignmentByUserId]", objParamList);

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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@Stid", objLibAssignment.Stid));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_AssignmentGetBid", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int DeleteCheckboxAssignmentAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));

                objParamList.Add(new SqlParameter("@CategoryId", objLibAssignment.CategoryID));

                objParamList.Add(new SqlParameter("@bid", objLibAssignment.BatchId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_AssignmentDeleteChechboxanswer", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }


        public DataSet GetBatchByAsgnId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchByAssignmentSet", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objAssignmentListing[i].BatchTitle = ds.Tables[0].Rows[i]["batchcode"].ToString();

                            }

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
        public DataSet GetActivateAssignmentSetData(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetActiveAssignmentData", objParamList);

            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public int UpdateActivateAssignmentSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBAssignment objAssignment = new LIBAssignment();
                objAssignment = (LIBAssignment)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@AsgnId", objAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@batchid", objAssignment.BatchId));
                objParamList.Add(new SqlParameter("@activatedate", objAssignment.activateDate));
                objParamList.Add(new SqlParameter("@deactivatedate", objAssignment.DeactivateDate));


                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_UpdateActivateAssignment", objParamList);

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
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@categoryId", objLIBAssignment.CategoryID));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("Sp_AssignmentGetSectionSummary", objParamList);

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
        public int CheckQuestionOptionAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.QuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibAssignment.AnsText));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_AssignmentCheckOptionByQuestionId", objParamList);


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
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibAssignment.SubQuestionId));
                objParamList.Add(new SqlParameter("@Anstext", objLibAssignment.AnsText));
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_AssignmentCheckSubOptionByQuestionId", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int AddUserInstruction(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBAssignment objAssignment = new LIBAssignment();
                objAssignment = (LIBAssignment)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@AsgnId", objAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@CategoryID", objAssignment.CategoryID));
                objParamList.Add(new SqlParameter("@InstructionText", objAssignment.InstructionText));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AssignmentAddUpdateStudentInstruction", objParamList);

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
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CourseId", objLIBAssignment.CourseId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetBatchById", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBAssignment objLIBAssignmentInner = new LIBAssignment();
                                objAssignmentListing.Add(objLIBAssignmentInner);
                                objAssignmentListing[i].BatchId = Convert.ToInt32(ds.Tables[0].Rows[i]["bid"].ToString());
                                objAssignmentListing[i].BatchTitle = ds.Tables[0].Rows[i]["BatchCode"].ToString();


                            }

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
            return packet;
        }
        public DataSet ReportStudentActivateAssignment(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@bid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@activate", objLIBAssignment.Activate));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ReportAssignmentActvateStudentInfo", objParamList);

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
        public DataSet ReportActivateAssignment(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {


                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CourseId", objLIBAssignment.CourseId));
                objParamList.Add(new SqlParameter("@bid", objLIBAssignment.BatchId));
                objParamList.Add(new SqlParameter("@frmdt", objLIBAssignment.FromDate));
                objParamList.Add(new SqlParameter("@todt", objLIBAssignment.ToDate));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_ReportActvateAssignment", objParamList);

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
        public int AddActivateStudentAssignmentSet(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBAssignment objAssignment = new LIBAssignment();
                objAssignment = (LIBAssignment)tp.MessagePacket;
                objParamList.Add(new SqlParameter("@AsgnId", objAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@batchid", objAssignment.BatchId));
                objParamList.Add(new SqlParameter("@userid", objAssignment.UserId));



                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddStudentAssignmentActivate", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }


        public DataSet StudentInActivateAssignment(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@batchid", objLIBAssignment.BatchId));


                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetStudentListForActivateAssignment", objParamList);

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

        public string GetAssignmentAnswerByAsgnId(TransportationPacket packet)
        {
            string addResult = "";
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLIBAssignment.UserId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();


                addResult = objDbConnection.ExecuteSPScalarString("SP_GetAssignmentAnswerOfflineandManual", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public DataSet GetAssignmentDetailsById(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@asgnid", objLIBAssignment.AsgnId));
                
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("sp_GetAssignmentDetails", objParamList);

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
                packet.MessageResultset = (LIBAssignmentListing)objAssignmentListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }

        public int AddUpdateAssignmentToFaculty(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssignmentToFaculty", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetAssignedAssignmenttoFaculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLIBAssignment.AsgnId));
               
                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignedAssignmenttoFaculty", objParamList);

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
        public DataSet GetAssignmentListToFaculty(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBAssignment objLIBAssignment = new LIBAssignment();
                objLIBAssignment = (LIBAssignment)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@Username", objLIBAssignment.UserId));
                objParamList.Add(new SqlParameter("@bid", objLIBAssignment.BatchId));

                LIBAssignmentListing objAssignmentListing = new LIBAssignmentListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetListOfAssignmentToFaculty", objParamList);

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

        public int AddUpdateAssignmentFinalMarks(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@Fid", objLibAssignment.FacultyId));
                objParamList.Add(new SqlParameter("@TotalMarks", objLibAssignment.TotalMarks));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateAssignmentFinalMarks", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int AddUpdateManualAssignmentFinalMarks(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBAssignment objLibAssignment = new LIBAssignment();
                objLibAssignment = (LIBAssignment)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@AsgnId", objLibAssignment.AsgnId));
                objParamList.Add(new SqlParameter("@UserId", objLibAssignment.UserId));
                objParamList.Add(new SqlParameter("@Feedback", objLibAssignment.Feedback));
                objParamList.Add(new SqlParameter("@Fid", objLibAssignment.FacultyId));
                objParamList.Add(new SqlParameter("@TotalMarks", objLibAssignment.TotalMarks));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateManualAssignmentFinalMarks", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
    }




}
