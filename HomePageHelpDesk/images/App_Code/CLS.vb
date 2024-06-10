Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class CLS
    Shared MyCon As OleDbConnection
    Shared strGlobalerrorinfo As String
    Shared mycmd As OleDbCommand
    Shared strSqlConn As String
    Public Shared Sub ConOpen()
        Try
            strGlobalerrorinfo = ""
            'Dim Strconn As String = ConfigurationSettings.AppSettings("strconn1")
            Dim Strconn As String = ConfigurationManager.ConnectionStrings("fmsfConnectionString").ToString
            MyCon = New OleDbConnection(Strconn)
            If MyCon.State = ConnectionState.Closed Then
                If MyCon.State = ConnectionState.Connecting Then
                    'MyCon.Close()
                Else
                    MyCon.Open()
                End If
            End If
           
        Catch ex As Exception
            strGlobalerrorinfo = strGlobalerrorinfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalerrorinfo = String.Concat(strGlobalerrorinfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalerrorinfo = String.Concat(strGlobalerrorinfo & vbCrLf, ex.Data)
        End Try
    End Sub
    Public Shared Sub ConClose()
        Try
            strGlobalErrorInfo = ""
            'Dim strconn As String = ConfigurationSettings.AppSettings("strconn1") & path & ConfigurationSettings.AppSettings("strconn3")
            If MyCon.State = ConnectionState.Open Then
                MyCon.Close()
            End If
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
            'fnWrite2LOG(strGlobalErrorInfo, System.Reflection.MethodBase.GetCurrentMethod().ToString())
        End Try
    End Sub
    Public Shared Function fnExecuteQuery(ByVal UpdateQ As String) As Long
        Try
            If MyCon.State = ConnectionState.Closed Then
                MyCon.Open()
            End If
            strGlobalerrorinfo = ""
            mycmd = New OleDbCommand(UpdateQ, MyCon)
            fnExecuteQuery = mycmd.ExecuteNonQuery
        Catch ex As Exception
            strGlobalerrorinfo = "Qurery is : " & UpdateQ
            strGlobalerrorinfo = strGlobalerrorinfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalerrorinfo = String.Concat(strGlobalerrorinfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalerrorinfo = String.Concat(strGlobalerrorinfo & vbCrLf, ex.Data)
        Finally
            MyCon.Close()
        End Try
    End Function
    Public Shared Function fnQuerySelectDs(ByVal SelectQ As String) As DataSet
        ConOpen()
        Dim ds As New DataSet()
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = SelectQ
            'sqlCommand.CommandType = CommandType.StoredProcedure; 
            cmd.Connection = MyCon
            'sqlCommand.Parameters.Add(new SqlParameter("@VENDNMBR", SqlDbType.Int)).Value = VendorId; 
            Dim adp As New OleDbDataAdapter()
            adp.SelectCommand = cmd
            adp.Fill(ds)
        Catch ex As Exception
        Finally
            ConClose()
        End Try
        Return ds
    End Function
    '-------------------------------Ankit Function Begin--------------------------------------------
    Public Shared Function fnQuerySelectDsGrv(ByVal SelectQ As String) As DataSet
        ConOpen()
        Dim ds As New DataSet()
        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = SelectQ
            cmd.Connection = MyCon
            Dim adp As New OleDbDataAdapter()
            adp.SelectCommand = cmd
            adp.Fill(ds)
        Catch ex As Exception
        Finally
            ConClose()
        End Try
        Return ds
    End Function
    '-------------------------------Ankit Function End--------------------------------------------
    Public Shared Function fnReplaceSpCH(ByVal str As String) As String
        Try
            str = str.Replace("""", "dq$")
            str = str.Replace(",", "com$")
            str = str.Replace("'", "q$")
            str = str.Replace("&", "amp$")
            Return str
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function fnGetDataFromSpCH(ByVal str As String) As String
        Try
            str = str.Replace("dq$", """")
            str = str.Replace("com$", ",")
            str = str.Replace("q$", "'")
            str = str.Replace("amp$", "&")
            Return str
        Catch ex As Exception
        End Try
    End Function
    Public Shared Function fnReplaceSpCH1(ByVal str As String) As String
        Try
            str = str.Replace("""", "dq$")
            str = str.Replace(",", "com$")
            str = str.Replace("'", "qu$")
            str = str.Replace("&", "amp$")
            Return str
        Catch ex As Exception
        End Try
    End Function


    Public Shared Function fnGetDataFromSpCH1(ByVal str As String) As String
        Try
            str = str.Replace("dq$", """")
            str = str.Replace("com$", ",")
            str = str.Replace("qu$", "'")
            str = str.Replace("amp$", "&")
            Return str
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function checkNumeric(ByVal str As String) As Integer
        If Len(str) > 0 Then
            Dim leng As Integer
            leng = Len(str)
            For Var_Loop = 1 To leng
                If Mid(str, Var_Loop, 1) < Chr(48) Or Mid(str, Var_Loop, 1) > Chr(57) Then
                    Return -2
                End If
            Next
            Return 1
        Else
            Return -1
        End If
        Return True
    End Function
    'Public Shared Function fnQuerySelect1Value(ByVal SelectQ As String) As String
    '    Try
    '        strGlobalErrorInfo = ""
    '        MyCmd = New OleDbCommand(SelectQ, MyCon)
    '        MyRs = MyCmd.ExecuteReader
    '        MyRs.Read()
    '        If MyRs.HasRows Then
    '            fnQuerySelect1Value = MyRs(0).ToString
    '        Else
    '            fnQuerySelect1Value = ""
    '        End If
    '    Catch ex As Exception
    '        strGlobalErrorInfo = "Qurery is : " & SelectQ
    '        strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
    '        strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
    '        strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
    '    End Try
    'End Function

    Public Shared Function GetRecordsbyID(ByVal pProcedureName As String, ByVal Parameter As String, ByVal pID As String) As DataSet
        Dim ObjSqlDAdapter As SqlDataAdapter
        Dim ObjDataSet As DataSet
        Try
            ObjSqlDAdapter = New SqlDataAdapter(pProcedureName, OpenConnection())
            ObjDataSet = New DataSet()

            ObjSqlDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            ObjSqlDAdapter.SelectCommand.Parameters.Add(Parameter, SqlDbType.NVarChar)
            ObjSqlDAdapter.SelectCommand.Parameters(Parameter).Value = pID
            ObjSqlDAdapter.Fill(ObjDataSet)
            ObjSqlDAdapter.Dispose()
            Return ObjDataSet
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Sub UpdateStudentExam(ByVal pProcedureName As String, ByVal examId As Integer, ByVal batchId As Integer, ByVal activateDate As DateTime, ByVal deactivatedate As DateTime)

        Dim ObjSqlDAdapter As SqlDataAdapter
        Dim ObjDataTable As DataTable

        Try
            ObjSqlDAdapter = New SqlDataAdapter(pProcedureName, GetConnection())
            ObjDataTable = New DataTable()

            ObjSqlDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            ObjSqlDAdapter.SelectCommand.Parameters.Add("@examid", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@examid").Value = examId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@batchid", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@batchid").Value = batchId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@activatedate", SqlDbType.DateTime)
            ObjSqlDAdapter.SelectCommand.Parameters("@activatedate").Value = activateDate
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@deactivatedate", SqlDbType.DateTime)
            ObjSqlDAdapter.SelectCommand.Parameters("@deactivatedate").Value = deactivatedate
            ObjSqlDAdapter.Fill(ObjDataTable)
            ObjSqlDAdapter.Dispose()
            '  Return ObjDataTable

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Shared Sub UpdateStudentAssignment(ByVal pProcedureName As String, ByVal AsgnId As Integer, ByVal batchId As Integer, ByVal activateDate As DateTime, ByVal deactivatedate As DateTime)

        Dim ObjSqlDAdapter As SqlDataAdapter
        Dim ObjDataTable As DataTable

        Try
            ObjSqlDAdapter = New SqlDataAdapter(pProcedureName, GetConnection())
            ObjDataTable = New DataTable()

            ObjSqlDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            ObjSqlDAdapter.SelectCommand.Parameters.Add("@Asgnid", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@Asgnid").Value = AsgnId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@batchid", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@batchid").Value = batchId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@activatedate", SqlDbType.DateTime)
            ObjSqlDAdapter.SelectCommand.Parameters("@activatedate").Value = activateDate
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@deactivatedate", SqlDbType.DateTime)
            ObjSqlDAdapter.SelectCommand.Parameters("@deactivatedate").Value = deactivatedate
            ObjSqlDAdapter.Fill(ObjDataTable)
            ObjSqlDAdapter.Dispose()
            '  Return ObjDataTable

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Shared Sub UpdateStudentFeeStatusSemester(ByVal pProcedureName As String, ByVal courseId As Integer, ByVal SemID As Integer, ByVal stId As Integer, ByVal status As Integer)

        Dim ObjSqlDAdapter As SqlDataAdapter
        Dim ObjDataTable As DataTable

        Try
            ObjSqlDAdapter = New SqlDataAdapter(pProcedureName, GetConnection())
            ObjDataTable = New DataTable()

            ObjSqlDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            ObjSqlDAdapter.SelectCommand.Parameters.Add("@courseId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@courseId").Value = courseId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@semId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@semId").Value = SemID
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@stId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@stId").Value = stId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@status", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@status").Value = status
            ObjSqlDAdapter.Fill(ObjDataTable)
            ObjSqlDAdapter.Dispose()
            '  Return ObjDataTable

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub UpdateStudentFeeStatusComplete(ByVal pProcedureName As String, ByVal courseId As Integer, ByVal stId As Integer, ByVal status As Integer)

        Dim ObjSqlDAdapter As SqlDataAdapter
        Dim ObjDataTable As DataTable

        Try
            ObjSqlDAdapter = New SqlDataAdapter(pProcedureName, GetConnection())
            ObjDataTable = New DataTable()

            ObjSqlDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            ObjSqlDAdapter.SelectCommand.Parameters.Add("@courseId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@courseId").Value = courseId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@stId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@stId").Value = stId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@status", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@status").Value = status
            ObjSqlDAdapter.Fill(ObjDataTable)
            ObjSqlDAdapter.Dispose()
            '  Return ObjDataTable

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub UpdateStudentMarksStatus(ByVal pProcedureName As String, ByVal courseId As Integer, ByVal SemID As Integer, ByVal stId As Integer, ByVal status As Integer)

        Dim ObjSqlDAdapter As SqlDataAdapter
        Dim ObjDataTable As DataTable

        Try
            ObjSqlDAdapter = New SqlDataAdapter(pProcedureName, GetConnection())
            ObjDataTable = New DataTable()

            ObjSqlDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            ObjSqlDAdapter.SelectCommand.Parameters.Add("@courseId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@courseId").Value = courseId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@semId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@semId").Value = SemID
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@stId", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@stId").Value = stId
            ObjSqlDAdapter.SelectCommand.Parameters.Add("@status", SqlDbType.Int)
            ObjSqlDAdapter.SelectCommand.Parameters("@status").Value = status
            ObjSqlDAdapter.Fill(ObjDataTable)
            ObjSqlDAdapter.Dispose()
            '  Return ObjDataTable

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function GetConnection() As SqlConnection
        strSqlConn = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString
        Try
            Return New SqlConnection(strSqlConn)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Shared Function OpenConnection() As SqlConnection
        Dim ObjSqlConnection As SqlConnection
        Try
            ObjSqlConnection = GetConnection()
            ObjSqlConnection.Open()
            Return ObjSqlConnection
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CloseConnection() As SqlConnection
        Dim ObjSqlConnection As SqlConnection
        Try
            ObjSqlConnection = GetConnection()
            ObjSqlConnection.Close()
            Return ObjSqlConnection
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ExecuteCLSSPDataSet(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter)) As DataSet
        Dim m_dsReturnValue As New DataSet()
        Try
            Dim m_cmdStoredProcedure As New OleDbCommand()
            m_cmdStoredProcedure.CommandText = SPName
            m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
            If MyCon Is Nothing Then
                CLS.ConOpen()
            End If
            If MyCon.State <> ConnectionState.Open Then
                CLS.ConOpen()
            End If
            If MyCon IsNot Nothing Then
                m_cmdStoredProcedure.Connection = MyCon
                For intLoop As Integer = 0 To ParameterList.Count - 1
                    m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                Next
                Dim daAdapater As New OleDbDataAdapter(m_cmdStoredProcedure)
                daAdapater.Fill(m_dsReturnValue)
                CLS.ConClose()
            End If
        Catch exObj As Exception
            m_dsReturnValue = Nothing
            'HandleException.ExceptionLogging(exObj.Source, exObj.Message, True)
        End Try
        Return m_dsReturnValue
    End Function

    Public Shared Function ExecuteCLSSP(ByVal SPName As String) As DataSet
        Dim m_dsReturnValue As New DataSet()
        Try
            Dim m_cmdStoredProcedure As New OleDbCommand()
            m_cmdStoredProcedure.CommandText = SPName
            m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
            If MyCon Is Nothing Then
                CLS.ConOpen()
            End If
            If MyCon.State <> ConnectionState.Open Then
                CLS.ConOpen()
            End If
            If MyCon IsNot Nothing Then
                m_cmdStoredProcedure.Connection = MyCon
                Dim daAdapater As New OleDbDataAdapter(m_cmdStoredProcedure)
                daAdapater.Fill(m_dsReturnValue)
                CLS.ConClose()
            End If
        Catch exObj As Exception
            m_dsReturnValue = Nothing
            'HandleException.ExceptionLogging(exObj.Source, exObj.Message, True)
        End Try
        Return m_dsReturnValue
    End Function

    Public Shared Function checkNumeric1(ByVal str As String) As Integer
        If Len(str) > 0 Then
            Dim leng As Integer
            leng = Len(str)
            For Var_Loop = 1 To leng
                If Mid(str, Var_Loop, 1) < Chr(46) Or Mid(str, Var_Loop, 1) > Chr(57) Or Mid(str, Var_Loop, 1) = Chr(47) Then
                    Return -2
                End If
            Next
            Return 1
        Else
            Return -1
        End If
        Return True
    End Function
End Class
