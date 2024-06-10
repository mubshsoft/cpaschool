using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using fmsf.lib;

namespace fmsf.DAL
{
  public class DALCategory
    {
        DbConnection objDbConnection = new DbConnection();
        public TransportationPacket GetCategoryList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCategory", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCategory objLibCategoryInner = new LIBCategory();
                                objCategoryListing.Add(objLibCategoryInner);
                                objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetCategoryByExamId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibCategory.ExamId));
                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCategoryByExamCode", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCategory objLibCategoryInner = new LIBCategory();
                                objCategoryListing.Add(objLibCategoryInner);
                                objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objCategoryListing[i].ExamId = Convert.ToInt32(ds.Tables[0].Rows[i]["ExamId"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetCategoryByAssignmentId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@AsgnId", objLibCategory.AsgnId));
                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCategoryByAssignmentCode", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCategory objLibCategoryInner = new LIBCategory();
                                objCategoryListing.Add(objLibCategoryInner);
                                objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objCategoryListing[i].AsgnId = Convert.ToInt32(ds.Tables[0].Rows[i]["AsgnId"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetCategoryByScreeningId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ScrId", objLibCategory.ScrId));
                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCategoryByScreeningCode", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCategory objLibCategoryInner = new LIBCategory();
                                objCategoryListing.Add(objLibCategoryInner);
                                objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objCategoryListing[i].ScrId = Convert.ToInt32(ds.Tables[0].Rows[i]["ScrId"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }
        public TransportationPacket GetAssignedCategoryList(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@ExamId", objLibCategory.ExamId));
                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetAssignedCategory", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCategory objLibCategoryInner = new LIBCategory();
                                objCategoryListing.Add(objLibCategoryInner);
                                objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return packet;
        }

        public int GetTotalNoOfAnswerbyCategory(TransportationPacket packet)
        {
            int addResult = 0;
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@CategoryID", objLibCategory.CategoryID));
                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                addResult = objDbConnection.ExecuteSPScalar("SP_GetTotalNoOfAnswer", objParamList);


            }
            catch (Exception ex)
            {
                packet.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return addResult;
        }
        //public int GetSurveyCategory(TransportationPacket packet)
        //{
        //    int addResult = 0;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        LIBCategory objLibCategory = new LIBCategory();
        //        objLibCategory = (LIBCategory)packet.MessagePacket;
        //        List<SqlParameter> objParamList = new List<SqlParameter>();
        //        objParamList.Add(new SqlParameter("@SurveyId", objLibCategory.SurveyId));
        //        LIBCategoryListing objCategoryListing = new LIBCategoryListing();

        //        addResult = objDbConnection.ExecuteSPScalar("SP_GetSurveyCategory", objParamList);


        //    }
        //    catch (Exception ex)
        //    {
        //        packet.MessageResultset = EStatus.Exception;
        //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        //    }
        //    return addResult;
        //}
        //public TransportationPacket GetSurveyCategoryByServeyId(TransportationPacket packet)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        LIBCategory objLibCategory = new LIBCategory();
        //        objLibCategory = (LIBCategory)packet.MessagePacket;
        //        List<SqlParameter> objParamList = new List<SqlParameter>();
        //        objParamList.Add(new SqlParameter("@SurveyId", objLibCategory.SurveyId));
        //        LIBCategoryListing objCategoryListing = new LIBCategoryListing();

        //        ds = objDbConnection.ExecuteSPDataSet("SP_GetSurveyCategory", objParamList);

        //        if (ds != null)
        //        {
        //            if (ds.Tables != null)
        //            {
        //                if (ds.Tables[0].Rows != null)
        //                {
        //                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //                    {
        //                        LIBCategory objLibCategoryInner = new LIBCategory();
        //                        objCategoryListing.Add(objLibCategoryInner);
        //                        objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
        //                        objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
        //                        objCategoryListing[i].SurveyId = Convert.ToInt32(ds.Tables[0].Rows[i]["SurveyId"].ToString());

        //                    }

        //                }
        //            }
        //        }
        //        packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
        //    }
        //    catch (Exception ex)
        //    {
        //        packet.MessageResultset = EStatus.Exception;
        //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        //    }
        //    return packet;
        //}
        //public TransportationPacket GetCategoryByServeyId(TransportationPacket packet)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        LIBCategory objLibCategory = new LIBCategory();
        //        objLibCategory = (LIBCategory)packet.MessagePacket;
        //        List<SqlParameter> objParamList = new List<SqlParameter>();
        //        objParamList.Add(new SqlParameter("@SurveyId", objLibCategory.SurveyId));
        //        LIBCategoryListing objCategoryListing = new LIBCategoryListing();

        //        ds = objDbConnection.ExecuteSPDataSet("SP_GetCategoryByServeyId", objParamList);

        //        if (ds != null)
        //        {
        //            if (ds.Tables != null)
        //            {
        //                if (ds.Tables[0].Rows != null)
        //                {
        //                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //                    {
        //                        LIBCategory objLibCategoryInner = new LIBCategory();
        //                        objCategoryListing.Add(objLibCategoryInner);
        //                        objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
        //                        objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();

        //                    }

        //                }
        //            }
        //        }
        //        packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
        //    }
        //    catch (Exception ex)
        //    {
        //        packet.MessageResultset = EStatus.Exception;
        //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        //    }
        //    return packet;
        //}
     

        public int AddUpdateCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CategoryID", objLibCategory.CategoryID));
                objParamList.Add(new SqlParameter("@CategoryName", objLibCategory.CategoryName));
                addResult = objDbConnection.ExecuteNonQueryReturnValueWithoutAdd("SP_AddUpdateCategory", objParamList);

            }
            catch (Exception ex)
            {
                tp.MessageResultset = EStatus.Exception;
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }

            return addResult;
        }

    



        public DataSet GetCategoryDataSet(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCategory", objParamList);

            }
            catch (Exception ex)
            {

                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            return ds;
        }
       
        public int DeleteCategory(TransportationPacket tp)
        {
            int addResult = 0;
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)tp.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();

                objParamList.Add(new SqlParameter("@CategoryID", objLibCategory.CategoryID));

                addResult = objDbConnection.ExecuteSPNonQueryReturnValue("SP_DeleteCategory", objParamList);

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

        public TransportationPacket GetCategoryBySampleId(TransportationPacket packet)
        {
            DataSet ds = new DataSet();
            try
            {
                LIBCategory objLibCategory = new LIBCategory();
                objLibCategory = (LIBCategory)packet.MessagePacket;
                List<SqlParameter> objParamList = new List<SqlParameter>();
                objParamList.Add(new SqlParameter("@SamId", objLibCategory.SamId));
                LIBCategoryListing objCategoryListing = new LIBCategoryListing();

                ds = objDbConnection.ExecuteSPDataSet("SP_GetCategoryBySampleCode", objParamList);

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                LIBCategory objLibCategoryInner = new LIBCategory();
                                objCategoryListing.Add(objLibCategoryInner);
                                objCategoryListing[i].CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                                objCategoryListing[i].CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                                objCategoryListing[i].SamId = Convert.ToInt32(ds.Tables[0].Rows[i]["SamId"].ToString());

                            }

                        }
                    }
                }
                packet.MessageResultset = (LIBCategoryListing)objCategoryListing;
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
