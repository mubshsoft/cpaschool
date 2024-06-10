Imports Microsoft.VisualBasic
Imports fmsf.lib
Namespace fmsf.DAL
    Public Class DalAddTopic

        Public Function InsertTopic(ByVal objLIBTopic As LibAddTopic) As Int16
            Dim retVal As New Int16
            Dim objParamList As New List(Of OleDbParameter)()
            Try
                objParamList.Add(New OleDbParameter("@Title", objLIBTopic.title))
                objParamList.Add(New OleDbParameter("@CreatedBy", objLIBTopic.CreatedBy))
                objParamList.Add(New OleDbParameter("@Active", objLIBTopic.Active))
                objParamList.Add(New OleDbParameter("@SubjectID", objLIBTopic.SubjectID))
                objParamList.Add(New OleDbParameter("@CourseID", objLIBTopic.CourseID))
                objParamList.Add(New OleDbParameter("@SemID", objLIBTopic.Semid))
                objParamList.Add(New OleDbParameter("@BatchID", objLIBTopic.Batchid))
                objParamList.Add(New OleDbParameter("@FileName", objLIBTopic.FileName))
                objParamList.Add(New OleDbParameter("@FilePath", objLIBTopic.FilePath))
                MyCLS.ConOpen()
                retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_InsertUpdateTopic", objParamList)
                MyCLS.ConClose()

            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
                'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
            End Try
            Return retVal
        End Function


        Public Function InsertTopicWithGroup(ByVal objLIBTopic As LibAddTopic) As Int16
            Dim retVal As New Int16
            Dim objParamList As New List(Of OleDbParameter)()
            Try
                objParamList.Add(New OleDbParameter("@Title", objLIBTopic.title))
                objParamList.Add(New OleDbParameter("@CreatedBy", objLIBTopic.CreatedBy))
                objParamList.Add(New OleDbParameter("@Active", objLIBTopic.Active))
                objParamList.Add(New OleDbParameter("@SubjectID", objLIBTopic.SubjectID))
                objParamList.Add(New OleDbParameter("@CourseID", objLIBTopic.CourseID))
                objParamList.Add(New OleDbParameter("@SemID", objLIBTopic.Semid))
                objParamList.Add(New OleDbParameter("@BatchID", objLIBTopic.Batchid))
                objParamList.Add(New OleDbParameter("@FileName", objLIBTopic.FileName))
                objParamList.Add(New OleDbParameter("@FilePath", objLIBTopic.FilePath))
                objParamList.Add(New OleDbParameter("@GroupId", objLIBTopic.GroupId)) 'Segeration as per group dated on 30 nov 20
                MyCLS.ConOpen()
                retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_InsertUpdateTopicWithGroup", objParamList)
                MyCLS.ConClose()

            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
                'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
            End Try
            Return retVal
        End Function
    End Class
End Namespace
