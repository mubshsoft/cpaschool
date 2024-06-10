Imports Microsoft.VisualBasic
Imports fmsf.lib
Namespace fmsf.DAL
    Public Class DalAddNews
        Public Function InsertNews(ByVal objLibNews As LIBNews) As Int16
            Dim retVal As New Int16
            Dim objParamList As New List(Of OleDbParameter)()
            Try
                objParamList.Add(New OleDbParameter("@NewsID", objLibNews.NewsId))
                objParamList.Add(New OleDbParameter("@NewsType", objLibNews.NewsType))
                objParamList.Add(New OleDbParameter("@NewsDesc", objLibNews.NewsDesc))
                objParamList.Add(New OleDbParameter("batchId", objLibNews.batchid))
                objParamList.Add(New OleDbParameter("@courseId", objLibNews.courseid))
                MyCLS.ConOpen()
                retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_InsertUpdateNews", objParamList)
                'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_UpdateNews", objParamList)
                MyCLS.ConClose()

            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
                'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
            End Try
            Return retVal
        End Function

        Public Function InsertEvent(ByVal objLibNews As LIBNews) As Int16
            Dim retVal As New Int16
            Dim objParamList As New List(Of OleDbParameter)()
            Try
                objParamList.Add(New OleDbParameter("@EventID", objLibNews.EventId))
                objParamList.Add(New OleDbParameter("@EventTitle", objLibNews.EventTitle))
                objParamList.Add(New OleDbParameter("@EventDesc", objLibNews.EventDesc))
                objParamList.Add(New OleDbParameter("@EventDate", objLibNews.EventDate))
                MyCLS.ConOpen()
                retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_InsertUpdateEvent", objParamList)
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