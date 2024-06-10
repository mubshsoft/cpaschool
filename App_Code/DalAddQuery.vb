Imports Microsoft.VisualBasic

Imports fmsf.lib
Namespace fmsf.DAL
    Public Class DalAddQuery
        Public Function InsertQuery(ByVal objLibQuery As LIBQuery) As Int16
            Dim retVal As New Int16
            Dim objParamList As New List(Of OleDbParameter)()
            Try
                objParamList.Add(New OleDbParameter("@stid", objLibQuery.stid))
                objParamList.Add(New OleDbParameter("@Fid", objLibQuery.Fid))
                objParamList.Add(New OleDbParameter("@Subject", objLibQuery.Subject))
                objParamList.Add(New OleDbParameter("@Query", objLibQuery.Query))
                objParamList.Add(New OleDbParameter("@Status", objLibQuery.Status))

                MyCLS.ConOpen()
                retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_InsertUpdateQuery", objParamList)
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
