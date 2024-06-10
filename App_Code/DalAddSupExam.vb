Imports Microsoft.VisualBasic
Imports fmsf.lib


Public Class DalAddSupExam
    Public Function InsertSuppExam(ByVal objLibSupExam As LibSuppExam) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@bid", objLibSupExam.Batchid))
            objParamList.Add(New OleDbParameter("@stid", objLibSupExam.stid))
            objParamList.Add(New OleDbParameter("@paperid", objLibSupExam.Paperid))
            MyCLS.ConOpen()
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_InsertSuppExamRegistration", objParamList)
            'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_UpdateNews", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function
End Class
