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
using fmsf.lib;

/// <summary>
/// Summary description for DALChapter
/// </summary>

namespace fmsf.DAL
{
    public class DALChapter
    {
        DbConnection objDbConnection = new DbConnection();
        SqlConnection con;
        SqlCommand com = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
       
        public int AddUpdateChapter(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                Chapter objLibExam = new Chapter();
                objLibExam = (Chapter)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@ID", objLibExam.ID));
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterText", objLibExam.ChapterText));
                objParamList.Add(new SqlParameter("@FileName", objLibExam.FileName));
                objParamList.Add(new SqlParameter("@FilePath ", objLibExam.FilePath));
                objParamList.Add(new SqlParameter("@Type", objLibExam.Type));
                objParamList.Add(new SqlParameter("@Keypoints", objLibExam.KeyLearning));
                objParamList.Add(new SqlParameter("@Check", objLibExam.Status));

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateChapter", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public TransportationPacket GetChapterListbyUnit(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                Chapter objLibExam = new Chapter();
                objLibExam = (Chapter)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                ChapterListing objExamListing = new ChapterListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetChapterListByunitid", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                Chapter objLibExamInner = new Chapter();
                                objExamListing.Add(objLibExamInner);
                                objExamListing[i].ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                                objExamListing[i].UnitID = Convert.ToInt32(ds.Tables[0].Rows[i]["UnitID"].ToString());
                                objExamListing[i].ChapterID = ds.Tables[0].Rows[i]["ChapterID"].ToString();
                                objExamListing[i].ChapterText = ds.Tables[0].Rows[i]["ChapterText"].ToString();
                                objExamListing[i].FileName = ds.Tables[0].Rows[i]["FileName"].ToString();
                                objExamListing[i].FilePath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                                objExamListing[i].Type = ds.Tables[0].Rows[i]["Type"].ToString();
                                objExamListing[i].AssessmentsURL = ds.Tables[0].Rows[i]["URL"].ToString();
                                objExamListing[i].KeyLearning = ds.Tables[0].Rows[i]["KeyPoints"].ToString();
                            }

                        }
                    }
                }
                packet.MessageResultset = (ChapterListing)objExamListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetQuestionListbyUnit(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetQuestionbyUnit", objParamList);

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
                               // objExamListing[i].UploadQuestionImagePath = ds.Tables[0].Rows[i]["UploadQuestionImagePath"].ToString();
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

        public int AddUpdateUnitQuestion(TransportationPacket tp)
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
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                //objParamList.Add(new SqlParameter("@CategoryId", objLibExam.CategoryID));
                
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateUnitQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteAssessmentsQuestion(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssessmentsQuestion", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public TransportationPacket GetAssessmentsQuestionByQuestionId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssessmentsQuestionByQuestionId", objParamList);

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
        public TransportationPacket GetAssessmentsQuestionOptionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssessmentsQuestionOption", objParamList);

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

        public int CheckAssessmentsQuestionOptionAns(TransportationPacket packet)
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


                addResult = objDbConnection.ExecuteSPScalar("SP_CheckAssessmentsOptionByQuestionId", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        public int AddUpdateAssessmentsQuestionOption(TransportationPacket tp)
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

                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateAssessmentsQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }
        public int DeleteAssessmentsQuestionOption(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@OPTID", objLibExam.OPTID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteAssessmentsQuestionOption", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetRandomlyAssessmentsQuestionList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                Chapter objLibExam = new Chapter();
                objLibExam = (Chapter)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetRandomlyAssessmentsQuestion", objParamList);

               
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
        public TransportationPacket GetAssesmentsQuestionOptionListByOptionType(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssesmentsQuestionOptionByOptionType", objParamList);


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
        public TransportationPacket GetAssesmentsQuestionOptionListByOptionTypeAll(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));

                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssesmentsQuestionOptionByOptionType_All", objParamList);


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
        public TransportationPacket GetAnsText(TransportationPacket tp)
        {

            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssessmentsAnsText", objParamList);
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

        public TransportationPacket CheckAssessmentsQuestionAnswer(TransportationPacket tp)
        {

            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                ds = objDbConnection.ExecuteSPDataSet("SP_CheckAssessmentsQuestionAnswer", objParamList);
                LIBExamListing objExamListing = new LIBExamListing();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    LIBExam objLibExam1 = new LIBExam();
                    objExamListing.Add(objLibExam1);
                    objExamListing[i].Answer = (ds.Tables[0].Rows[i]["Answer"].ToString());
                    objExamListing[i].QUESTYPE = (ds.Tables[0].Rows[i]["QUESTYPE"].ToString());
                    objExamListing[i].MaxQueMarks =Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                    
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
        public int SubmitAssessmentsAns(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@Review", objLibExam.Review));
                //objParamList.Add(new SqlParameter("@CategoryId", objLibExam.CategoryID));
                objParamList.Add(new SqlParameter("@AnsText", objLibExam.AnsText));
                objParamList.Add(new SqlParameter("@option", objLibExam.Option));
                objParamList.Add(new SqlParameter("@bid", objLibExam.BatchId));
                //objParamList.Add(new SqlParameter("@UploadAnsPath", objLibExam.UploadAnsPath));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddAssessmentQuestionAnswer", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int DeleteAssessmentsCheckboxExamAns(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBExam objLibExam = new LIBExam();
                objLibExam = (LIBExam)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UserId", objLibExam.UserId));//have to change with user id
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@QuestionId", objLibExam.QuestionId));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                objParamList.Add(new SqlParameter("@bid", objLibExam.BatchId));

                LIBExamListing objExamListing = new LIBExamListing();


                addResult = objDbConnection.ExecuteSPScalar("SP_DeleteAssessmentsChechboxanswer", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }

        public int AddUpdateChapterReading(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                Chapter objLibExam = new Chapter();
                objLibExam = (Chapter)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                objParamList.Add(new SqlParameter("@UserID", objLibExam.UserId));
              
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateChapterReading", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public int DeleteAssessmentChapter(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                Chapter objLibExam = new Chapter();
                objLibExam = (Chapter)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ID", objLibExam.ID));
                
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_DeleteAssessmentChapter", objParamList);
                
            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

        public DataSet GetChapterbyId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                Chapter objLibExam = new Chapter();
                objLibExam = (Chapter)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@UnitID", objLibExam.UnitID));
                objParamList.Add(new SqlParameter("@ChapterID", objLibExam.ChapterID));
                LIBExamListing objExamListing = new LIBExamListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetChapterByChapterId", objParamList);


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