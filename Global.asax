<%@ Application Language="VB" %>
<%@ Import Namespace="System.Reflection" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        
        'Dim p As PropertyInfo = GetType(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic Or BindingFlags.[Public] Or BindingFlags.[Static]) 
        'Dim o As Object = p.GetValue(Nothing, Nothing) 
        'Dim f As FieldInfo = o.[GetType]().GetField("_dirMonSubdirs", BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.IgnoreCase) 
        'Dim monitor As Object = f.GetValue(o) 
        'Dim m As MethodInfo = monitor.[GetType]().GetMethod("StopMonitoring", BindingFlags.Instance Or BindingFlags.NonPublic)  
        'm.Invoke(monitor, New Object() {}) 

    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
        
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
      
        Dim constr As String = ConfigurationManager.ConnectionStrings("fmsfConnectionString").ToString()
        Dim con As New OleDbConnection(constr)
        Try

            Dim objErr As Exception = Server.GetLastError().GetBaseException()
            Dim ErrorUrl As String = Request.Url.ToString()
            Dim ErrorMessage As String = objErr.Message.ToString()
            Dim ERRORSTACK As String = objErr.StackTrace.ToString()
            Dim retnumb As Integer = 0
           

         
           
    
            Dim sqlCommand As New OleDbCommand()
            sqlCommand.CommandText = "SP_AddErrorLog"
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Parameters.Add(New OleDbParameter("@ErrorUrl", SqlDbType.VarChar)).Value = ErrorUrl
            sqlCommand.Parameters.Add(New OleDbParameter("@ErrorMessage", SqlDbType.VarChar)).Value = ErrorMessage
            sqlCommand.Parameters.Add(New OleDbParameter("@ERRORSTACK", SqlDbType.VarChar)).Value = ERRORSTACK
    
            sqlCommand.Connection = con
            con.Open()
    
            retnumb = sqlCommand.ExecuteNonQuery()
    
        Catch ex As Exception
    
    
        Finally
            con.Close()
    
        End Try
   
        Server.ClearError()
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Try
            Dim strLogin As String
            If Session("role") = "Faculty" Then
                strLogin = "update FacultyLoginHistory set logout='" & System.DateTime.Now & "' where fid=" & Session("fid") & "and loginfrom='" & Session("IPADD") & "' and logindate='" & Session("datetim") & "'"
            ElseIf Session("role") = "Student" Then
                strLogin = "update studentLoginHistory set logout='" & System.DateTime.Now & "' where stid=" & Session("stid") & "and loginfrom='" & Session("IPADD") & "' and logindate='" & Session("datetim") & "'"
            End If
        
        
            CLS.fnExecuteQuery(strLogin)
        
        
            Session.Abandon()
        Catch ex As Exception
        End Try
    End Sub
       
</script>