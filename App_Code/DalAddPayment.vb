Imports Microsoft.VisualBasic
Imports fmsf.lib
Namespace fmsf.DAL


    Public Class DalAddPayment
        Public Function InsertPayment(ByVal objLibPayment As LIBPayment) As Int16
            Dim retVal As New Int16
            Dim objParamList As New List(Of OleDbParameter)()
            Try
                objParamList.Add(New OleDbParameter("@DDNo", objLibPayment.DDNo))
                objParamList.Add(New OleDbParameter("@Amount", objLibPayment.Amount))

                objParamList.Add(New OleDbParameter("@stid", objLibPayment.stid))
                objParamList.Add(New OleDbParameter("@CourseId", objLibPayment.CourseId))

                objParamList.Add(New OleDbParameter("@SemId", objLibPayment.SemId))
                objParamList.Add(New OleDbParameter("@DDdate", objLibPayment.DDdate))
                MyCLS.ConOpen()
                retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_InsertUpdatepayment1", objParamList)
                'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_UpdateNews", objParamList)
                MyCLS.ConClose()

            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
                'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
            End Try
            Return retVal
        End Function
    End Class
End Namespace
