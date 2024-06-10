'*******************************************************************************'
'               Name        :       MyCLS.vb                                    '
'               Created on  :       5th Mar, 2008                               '
'               Description :       Contains some specific fuctions to use      '
'                                   Database opration & emailing & Uploading    '
'               Created By  :       Narender Sharma (Netsoft)                   '
'               Modified On :       13-Jun-2008                                 '
'*******************************************************************************'

'TO MAKE DEFAULT FOR ENTER KEY
'Page.RegisterHiddenField("__EVENTTARGET", "CmdOK")

'============================================
'**********ACTUAL CODE TO OPEN PDF FILE******
'Dim client As New System.Net.WebClient
'Dim buffer(10) As Byte
'   buffer = client.DownloadData(strFilePath)''
'
'   If buffer.ToString <> "" Then
'       Response.ContentType = "application/pdf"
'       Response.AddHeader("content-length", buffer.Length.ToString())
'       Response.BinaryWrite(buffer)
'   End If
'============================================                    

'===================================================
'**********CODE TO USE AFTER ALL FUNCTION CALL******

'   If Len(strGlobalErrorInfo) > 0 Then
'       Response.Write(strGlobalErrorInfo)                
'       Exit Sub
'   End If

'==========PLEASE COPY THESE LINE====================                    


Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
'Imports System.Runtime.InteropServices




Public Class MyCLS
    Public Shared strGlobalErrorInfo As String
    Public Shared strDBErrorInfo As String
    Public Shared strGlobalErrorDB As String = "if @@error <> 0 begin select -1 end else begin select @@Identity end"

    Shared strConnStringOLEDB As String = "UID=sa;Password=sa123;Data Source=127.0.0.1;Initial Catalog=ndhhs_rms;Provider=SQLOLEDB.1;"
    Shared strConnStringSQLCLIENT As String = "Initial Catalog=ndhhs_rms;Data Source=127.0.0.1;UID=sa;PWD=sa123;"

    Shared MyCon As OleDbConnection
    Shared MyStr As String
    Shared MyCmd As OleDbCommand
    Shared MyRs As OleDbDataReader
    Shared MyDa As OleDbDataAdapter

    Shared MyTrans As OleDbTransaction

    '**************START - TO STORE SP ERROR FLAGS*****************************************************
#Region "SPStatus of the Action Perform on SP"
    Public Enum SPStatus As Integer
        Err_Updating = -2
        Err_Inserting = -1
        Failure = -1
        Success_Inserting = 1
        Success_Updating = 2
        RecordNotFound = 3
        Duplicate = 4
        Exception = 5
    End Enum
    'end SPStatus
#End Region
    '**************END - TO STORE SP ERROR FLAGS*****************************************************

    '**************START - TO STORE ERROR FLAGS*****************************************************
#Region "EStatus of the Action Perform"
    Public Enum EStatus As Integer
        Err = -1
        Failure
        Success
        DatabaseNotFound
        Exception
        RecordNotFound
        Duplicate
    End Enum
    'end EStatus
#End Region
    '**************END - TO STORE ERROR FLAGS*****************************************************



    '**************START - TO EXECUTE STORED PROCEDURES*****************************************************
    Public Class clsExecuteStoredProc

        Shared m_OleDbConnection As OleDbConnection

#Region "Open And Close Database Connection"
        ''' <summary>
        ''' This function Opens Connection to be used within this class
        ''' And Closes after operation is completed
        ''' </summary>
        ''' <returns></returns>
        Shared Function OpenDatabase() As OleDbConnection
            Try
                strGlobalErrorInfo = ""
                'MyCLS.ConOpen()
                MyCLS.GetCon(m_OleDbConnection)
            Catch ex As Exception
                clsHandleException.HandleEx(ex)
            End Try
            Return m_OleDbConnection
        End Function

        Shared Sub CloseDatabase()
            Try
                strGlobalErrorInfo = ""
                If m_OleDbConnection.State Then
                    m_OleDbConnection.Close()
                End If
                'MyCLS.ConClose()
            Catch ex As Exception
                clsHandleException.HandleEx(ex)
            End Try
        End Sub
#End Region

#Region "My Function for Stored Procedure"
        '' ''Public Shared Sub ExecuteStoredProc(ByRef ds As DataSet, ByVal CMD As OleDbCommand, ByVal CommandText As String)
        '' ''    Try
        '' ''        strGlobalErrorInfo = ""
        '' ''        CMD.CommandText = CommandText
        '' ''        CMD.CommandType = CommandType.StoredProcedure
        '' ''        CMD.Connection = MyCon

        '' ''        MyDa = New OleDbDataAdapter
        '' ''        MyDa.SelectCommand = CMD

        '' ''        MyDa.Fill(ds)
        '' ''    Catch ex As Exception
        '' ''        strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
        '' ''        strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
        '' ''        strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        '' ''    End Try
        '' ''End Sub
#End Region

#Region "ExecuteNonQuery"
        ''' <summary>
        ''' This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteNonQuery
        ''' This shall reduce lot of Development time in invoking the database properties.
        ''' Input Parameters: String SPName -> Name of the Stored Procedures
        ''' ParameterList -> List of Type SQLParameter
        ''' The function is responsible for database connectivity and shall open and close the connection on it's own.
        ''' </summary>
        ''' <param name="SPName"></param>
        ''' <param name="ParameterList"></param>
        ''' <returns></returns>
        Public Shared Function ExecuteSPNonQuery(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter)) As Integer
            Dim m_intReturnValue As Integer = 0
            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    For intLoop As Integer = 0 To ParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                    Next
                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery()
                    CloseDatabase()
                End If
            Catch exObj As Exception
                m_intReturnValue = -1
                'HandleException.ExceptionLogging(exObj.Source, exObj.Message, True)
                clsHandleException.HandleEx(exObj)
            End Try
            Return m_intReturnValue
        End Function
#End Region

#Region "ExecuteSPDataSet"
        ''' <summary>
        ''' This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteReader 
        ''' or the method of filling up the DataSet.
        ''' This shall reduce lot of Development time in invoking the database properties.
        ''' Input Parameters: String SPName -> Name of the Stored Procedures
        ''' ParameterList -> List of Type SQLParameter
        ''' The function is responsible for database connectivity and shall open and close the connection on it's own.
        ''' </summary>
        ''' <param name="SPName"></param>
        ''' <param name="ParameterList"></param>
        ''' <returns></returns>
        Public Shared Function ExecuteSPDataSet(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter)) As DataSet
            Dim m_dsReturnValue As New DataSet()
            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    For intLoop As Integer = 0 To ParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                    Next
                    Dim daAdapater As New OleDbDataAdapter(m_cmdStoredProcedure)
                    daAdapater.Fill(m_dsReturnValue)
                    CloseDatabase()
                End If
            Catch exObj As Exception
                m_dsReturnValue = Nothing
                'HandleException.ExceptionLogging(exObj.Source, exObj.Message, True)
                clsHandleException.HandleEx(exObj)
            End Try
            Return m_dsReturnValue
        End Function

        Public Shared Function ExecuteSPDataSet(ByVal SPName As String) As DataSet
            Dim m_dsReturnValue As New DataSet()
            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    Dim daAdapater As New OleDbDataAdapter(m_cmdStoredProcedure)
                    daAdapater.Fill(m_dsReturnValue)
                    CloseDatabase()
                End If
            Catch exObj As Exception
                m_dsReturnValue = Nothing
                'HandleException.ExceptionLogging(exObj.Source, exObj.Message, True)
                clsHandleException.HandleEx(exObj)
            End Try
            Return m_dsReturnValue
        End Function
#End Region

#Region "ExecuteSPScalar"
        Public Shared Function ExecuteSPScalar(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter)) As Integer
            Dim m_intReturnValue As Integer = 0
            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    For intLoop As Integer = 0 To ParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                    Next
                    m_intReturnValue = Convert.ToInt32(m_cmdStoredProcedure.ExecuteScalar())
                    CloseDatabase()
                End If
            Catch exObj As Exception
                m_intReturnValue = -1
                'HandleException.ExceptionLogging(exObj.Source, exObj.Message, True)
                clsHandleException.HandleEx(exObj)
            End Try
            Return m_intReturnValue
        End Function
#End Region

#Region "ExecuteNonQuery OutPut"
        ''' <summary> 
        ''' This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteNonQuery 
        ''' This shall reduce lot of Development time in invoking the database properties. 
        ''' Input Parameters: String SPName -> Name of the Stored Procedures 
        ''' ParameterList -> List of Type SQLParameter 
        ''' The function is responsible for database connectivity and shall open and close the connection on it's own. 
        ''' </summary> 
        ''' <param name="SPName"></param> 
        ''' <param name="ParameterList"></param> 
        ''' <returns></returns> 
        Public Shared Function ExecuteSPNonQueryOutPut(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter), ByVal OutParameterList As List(Of OleDbParameter), ByRef m_intReturnValue As Int16) As String()
            m_intReturnValue = 0
            Dim OutParameterArray As String() = New String(OutParameterList.Count - 1) {}
            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    For intLoop As Integer = 0 To ParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                    Next

                    For intLoop As Integer = 0 To OutParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(OutParameterList(intLoop))
                        OutParameterList(intLoop).Direction = ParameterDirection.Output
                    Next

                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery()

                    CloseDatabase()

                    For intLoop As Integer = 0 To OutParameterList.Count - 1
                        OutParameterArray(intLoop) = m_cmdStoredProcedure.Parameters(OutParameterList(intLoop).ParameterName).Value.ToString()
                    Next
                End If
            Catch exObj As Exception
                m_intReturnValue = -1
                clsHandleException.HandleEx(exObj)
            End Try
            Return OutParameterArray
        End Function

        Public Shared Function ExecuteSPNonQueryReturnValue(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter)) As Integer
            Dim m_intReturnValue As Integer = 0
            Dim intReturnValues As Integer = 0

            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    For intLoop As Integer = 0 To ParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                    Next
                    Dim objReturnParameter As New OleDbParameter("RETURNVALUE", OleDbType.Integer)
                    objReturnParameter.Direction = ParameterDirection.ReturnValue

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter)


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery()
                    intReturnValues = Convert.ToInt32(m_cmdStoredProcedure.Parameters("RETURNVALUE").Value)

                    CloseDatabase()
                End If
            Catch exObj As Exception
                intReturnValues = -1
                clsHandleException.HandleEx(exObj)
            End Try
            Return intReturnValues
        End Function

        Public Shared Function ExecuteNonQueryReturnValueWithoutAdd(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter)) As Integer
            Dim m_intReturnValue As Integer = 0
            Dim intReturnValues As Integer = 0

            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    For intLoop As Integer = 0 To ParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                    Next
                    Dim objReturnParameter As New OleDbParameter("RETURNVALUE", OleDbType.Integer)
                    objReturnParameter.Direction = ParameterDirection.ReturnValue

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter)


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery()
                    intReturnValues = Convert.ToInt32(m_cmdStoredProcedure.Parameters("RETURNVALUE").Value)

                    CloseDatabase()
                End If
            Catch exObj As Exception
                intReturnValues = -1
                clsHandleException.HandleEx(exObj)
            End Try
            Return intReturnValues
        End Function


        Public Shared Function ExecuteNonQueryDecimal(ByVal SPName As String, ByVal ParameterList As List(Of OleDbParameter)) As Decimal
            Dim m_intReturnValue As Integer = 0
            Dim intReturnValues As Decimal = 0

            Try
                Dim m_cmdStoredProcedure As New OleDbCommand()
                m_cmdStoredProcedure.CommandText = SPName
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure
                If m_OleDbConnection Is Nothing Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection.State <> ConnectionState.Open Then
                    m_OleDbConnection = OpenDatabase()
                End If
                If m_OleDbConnection IsNot Nothing Then
                    m_cmdStoredProcedure.Connection = m_OleDbConnection
                    For intLoop As Integer = 0 To ParameterList.Count - 1
                        m_cmdStoredProcedure.Parameters.Add(ParameterList(intLoop))
                    Next
                    Dim objReturnParameter As New OleDbParameter("RETURNVALUE", OleDbType.[Decimal])
                    objReturnParameter.Direction = ParameterDirection.ReturnValue

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter)


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery()
                    intReturnValues = Convert.ToDecimal(m_cmdStoredProcedure.Parameters("RETURNVALUE").Value)

                    CloseDatabase()
                End If
            Catch exObj As Exception
                intReturnValues = -1
                clsHandleException.HandleEx(exObj)
            End Try
            Return intReturnValues
        End Function
#End Region
    End Class
    '**************END - TO EXECUTE STORED PROCEDURES*****************************************************

    '**************START - TO HANDLE EXCEPTION*****************************************************
    Public Class clsHandleException
        Public Shared Sub HandleEx(ByVal ex As Exception)
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Sub
    End Class
    '**************END - TO HANDLE EXCEPTION*****************************************************


    '***********DATABASE CREDENTIALS FOR CRYSTAL REPORT***********************************
    Public Class DataBaseCredentials
        Public Shared ServerName As String
        Public Shared DatabaseName As String
        Public Shared UserName As String
        Public Shared Password As String
    End Class
    '***********END DATABASE CREDENTIALS FOR CRYSTAL REPORT*******************************

    '*********Validation Patterns*************************************************************************
    Public Class Patterns
        Public Const MAILPattern As String = "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        Public Const USPHONEPattern As String = "^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"
        Public Const USFAXPattern As String = "^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"
        Public Const USZIPPattern As String = "^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$"
    End Class

    Public Class PatternTypes
        Public Const EMAILType As String = "EMAIL"
        Public Const FAXType As String = "FAX"
        Public Const PHONEType As String = "PHONE"
        Public Const ZIPType As String = "ZIP"
    End Class
    '*********End Validation Patterns**********************************************************************





    '**************TO STORE QUERIES TO BE PROCESSED LATER*****************************************************
    Public Class clsProcessQueries
        Private Shared strQueries() As String
        Private Shared intNoofQueries As Int16 = 0
        Private Shared Trans As OleDbTransaction

        Public Shared Sub AddNewQuery(ByVal NewQuery As String)
            Try
                If Not strQueries Is Nothing Then
                    Dim Found As Boolean
                    'For Each Item As String In strQueries
                    For i As Int16 = 0 To strQueries.GetUpperBound(0)
                        If Mid(strQueries(i), 1, 25) = Mid(NewQuery, 1, 25) Then
                            strQueries(i) = NewQuery
                            Found = True
                            Exit For
                        End If
                    Next

                    If Not Found Then
                        intNoofQueries += 1
                        ReDim Preserve strQueries(intNoofQueries)
                        strQueries(intNoofQueries) = NewQuery
                    End If
                Else
                    intNoofQueries += 1
                    ReDim Preserve strQueries(intNoofQueries)
                    strQueries(intNoofQueries) = NewQuery
                End If
            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)                
            End Try
        End Sub
        Public Shared Function AddNewQuery(ByVal NewQuery As String, ByVal isMatchedFully As Boolean) As Boolean
            Try
                If Not strQueries Is Nothing Then
                    If NewQuery.Length = 0 Then Exit Function
                    Dim Found As Boolean
                    'For Each Item As String In strQueries
                    For i As Int16 = 0 To strQueries.GetUpperBound(0)
                        If isMatchedFully = False Then
                            If Mid(strQueries(i), 1, 25) = Mid(NewQuery, 1, 25) Then
                                strQueries(i) = NewQuery
                                Found = True
                                AddNewQuery = False
                                Exit For
                            End If
                        Else
                            If strQueries(i) = NewQuery Then
                                strQueries(i) = NewQuery
                                Found = True
                                AddNewQuery = False
                                Exit For
                            End If
                        End If
                    Next

                    If Not Found Then
                        intNoofQueries += 1
                        ReDim Preserve strQueries(intNoofQueries)
                        strQueries(intNoofQueries) = NewQuery
                        AddNewQuery = True
                    End If
                Else
                    intNoofQueries += 1
                    ReDim Preserve strQueries(intNoofQueries)
                    strQueries(intNoofQueries) = NewQuery
                    AddNewQuery = True
                End If
            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
            End Try
        End Function

        Public Shared Sub AddNewQueryAtLast(ByVal NewQuery As String)
            Try
                If strQueries Is Nothing Then
                    ReDim Preserve strQueries(0)
                End If
                strQueries(0) = NewQuery
            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
            End Try
        End Sub

        Public Shared Function ProcessAllQueries() As Boolean
            Try
                If strQueries Is Nothing Then
                    Exit Function
                End If
                Dim i As Int16
                Trans = MyCon.BeginTransaction(IsolationLevel.Chaos)
                'Trans.Begin()
                For i = intNoofQueries To 0 Step -1
                    If Len(strQueries(i)) > 0 Then
                        If MyCLS.fnQueryExecuter(strQueries(i), Trans) = 0 Then
                            Trans.Rollback()
                            Return False
                        End If
                        'Else
                        '    Trans.Commit()
                        'MyCLS.fnQueryExecuter(strQueries(i), Trans)
                    End If
                Next
                intNoofQueries = 0
                Trans.Commit()
                Return True
            Catch ex As Exception
                Trans.Rollback()
                MyCLS.clsHandleException.HandleEx(ex)
            End Try
        End Function

        Public Shared Sub ClearAllQueries()
            Try
                If strQueries Is Nothing Then
                    Exit Sub
                End If
                For i As Int16 = 0 To strQueries.GetUpperBound(0)
                    strQueries(i) = ""
                Next
                ReDim strQueries(0)
                intNoofQueries = 0
            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
            End Try
        End Sub

        Public Shared Function GetAllQueries() As String()
            GetAllQueries = strQueries
        End Function
    End Class
    '**************END - TO STORE QUERIES TO BE PROCESSED LATER*****************************************************


    '**************TO UPDATE DATABASE USIGN DATASET*****************************************************
    ' TO BE USED IN DESKTOP APPLICATION

    '' ''Public Class clsUpdateWithAdapter
    '' ''    Shared oCon As New SqlConnection(strConnStringSQLCLIENT)

    '' ''    Public Shared Sub ConOpen()
    '' ''        If oCon.State <> ConnectionState.Open Then
    '' ''            oCon.Open()
    '' ''        End If
    '' ''    End Sub
    '' ''    Public Shared Sub ConClose()
    '' ''        If oCon.State <> ConnectionState.Closed Then
    '' ''            oCon.Close()
    '' ''        End If
    '' ''    End Sub

    '' ''    Public Shared Function InitDataset(ByRef oAdapter As SqlDataAdapter, ByRef oDataset As DataSet, ByRef oDataGridView As DataGridView, ByVal oQry As String, ByVal oTableName As String) As Boolean
    '' ''        If oCon.State <> ConnectionState.Open Then
    '' ''            oCon.Open()
    '' ''        End If
    '' ''        Try
    '' ''            oAdapter = New SqlDataAdapter(oQry, oCon)
    '' ''            Dim myDataRowsCommandBuilder As New SqlCommandBuilder(oAdapter)

    '' ''            'oAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
    '' ''            oDataset.Clear()
    '' ''            oAdapter.Fill(oDataset, oTableName)
    '' ''            oDataGridView.DataSource = oDataset
    '' ''            oDataGridView.DataMember = oTableName
    '' ''            'oDataGridView.Columns(0).Visible = False
    '' ''            If oCon.State <> ConnectionState.Closed Then
    '' ''                oCon.Close()
    '' ''            End If
    '' ''            Return True
    '' ''        Catch ex As Exception
    '' ''            MsgBox(ex.Message)
    '' ''            'MyCLS.strGlobalErrorInfo = MyCLS.strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
    '' ''            'MyCLS.strGlobalErrorInfo = String.Concat(MyCLS.strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
    '' ''            'MyCLS.strGlobalErrorInfo = String.Concat(MyCLS.strGlobalErrorInfo & vbCrLf, ex.Data)
    '' ''            'MyCLS.fnWrite2LOG(MyCLS.strGlobalErrorInfo, System.Reflection.MethodBase.GetCurrentMethod().ToString())
    '' ''            If oCon.State <> ConnectionState.Closed Then
    '' ''                oCon.Close()
    '' ''            End If
    '' ''            Return False
    '' ''        End Try
    '' ''    End Function

    '' ''    Public Shared Function CheckDuplicateInDataset(ByRef oDataset As DataSet, ByVal oColNumber As Int16, ByVal oValue As String) As Boolean
    '' ''        Dim hasValue As Boolean
    '' ''        For Each r As DataRow In oDataset.Tables(0).Rows
    '' ''            For Each item As String In r(oColNumber).ToString
    '' ''                If item = oValue Then
    '' ''                    hasValue = True
    '' ''                    Exit For
    '' ''                End If
    '' ''            Next
    '' ''            If hasValue Then
    '' ''                Exit For
    '' ''            End If
    '' ''        Next
    '' ''        Return hasValue
    '' ''    End Function

    '' ''    Public Shared Function UpdateDataset(ByRef oAdapter As SqlDataAdapter, ByRef oDataset As DataSet, ByVal oTableName As String) As Boolean
    '' ''        'If oCon.State <> ConnectionState.Open Then
    '' ''        '    oCon.Open()
    '' ''        'End If
    '' ''        Try
    '' ''            MyCLS.ConClose()
    '' ''        Catch ex As Exception
    '' ''            MsgBox("Connection Could not Close")
    '' ''        End Try
    '' ''        'Try                
    '' ''        '    oCon.Close()
    '' ''        'Catch ex As Exception
    '' ''        '    MsgBox("Connection Could not Close")
    '' ''        'End Try

    '' ''        'Try
    '' ''        '    oCon.Open()
    '' ''        'Catch ex As Exception
    '' ''        '    MsgBox("Connection Could not Open")
    '' ''        'End Try

    '' ''        '--------------'Dim myDataRowsCommandBuilder As New SqlCommandBuilder(oAdapter)
    '' ''        '--------------'oAdapter.InsertCommand = myDataRowsCommandBuilder.GetUpdateCommand()

    '' ''        oAdapter.Update(oDataset, oTableName)


    '' ''        Try
    '' ''            MyCLS.ConOpen()
    '' ''        Catch ex As Exception
    '' ''            MsgBox("Connection Could not Open")
    '' ''        End Try

    '' ''        'If oCon.State <> ConnectionState.Closed Then
    '' ''        '    oCon.Close()
    '' ''        'End If
    '' ''    End Function
    '' ''End Class      
    '**************END - TO UPDATE DATABASE USIGN DATASET*****************************************************

    '**************START - TO MAIL*****************************************************
    Public Class clsMail
        Public Shared strFrom As String
        Public Shared strPassword As String
        Public Shared strSMTPClient As String
        Public Shared intPort As Int16
        Public Shared isBodyHTML As Boolean

        Public Shared Sub prcEMail(ByVal strTo As String, ByVal strSub As String, ByVal strBody As String, Optional ByVal strCC As String = "", Optional ByVal strBCC As String = "", Optional ByVal isRequireSSL As Boolean = False)
            Try
                '************SEND MAIL USING GMAIL******************************       
                'intPort=587    -   IF GMAIL
                'intPort=0      -   IF LOCALHOST

                Dim Mail As New MailMessage()

                Mail.To.Add(strTo)
                Mail.From = New MailAddress(strFrom)
                If strCC.Length > 0 Then Mail.CC.Add(strCC)
                If strBCC.Length > 0 Then Mail.Bcc.Add(strBCC)
                Mail.Subject = strSub
                Mail.Body = strBody
                Mail.IsBodyHtml = isBodyHTML

                'SMTP CLIENT IS LOCALHOST OR NOT
                Dim Smtp As SmtpClient
                If intPort = 0 Then
                    Smtp = New SmtpClient(strSMTPClient)
                Else
                    Smtp = New SmtpClient(strSMTPClient, intPort)
                End If

                'USER CREDENTIALS REQUIRED OR NOT
                If Len(strFrom) > 0 And Len(strPassword) > 0 Then
                    Smtp.Credentials = New Net.NetworkCredential(strFrom, strPassword)
                Else
                    Smtp.UseDefaultCredentials = True
                End If

                'ENABLE SSL OR NOT
                'If isRequireSSL = False Then
                Smtp.EnableSsl = isRequireSSL
                'Else
                'Smtp.EnableSsl = True
                'End If                

                'SEND MAIL
                '*System.Windows.Forms.Application.DoEvents()
                Smtp.Send(Mail)
                '*System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
                'MsgBox(ex.Message)
                MyCLS.clsHandleException.HandleEx(ex)
            End Try


            '************START - SEND MAIL USING MICROSOFT OUTLOOK******************************
            '---'ByVal AppOL As Outlook.Application, ByVal OLNameSpace As Outlook.NameSpace
            '' ''Dim msg As Outlook.MailItem
            ' '' ''dim SM as Outlook.
            ' '' ''creating newblan mail message 
            '' ''msg = AppOL.CreateItem(Outlook.OlItemType.olMailItem)
            ' '' ''msg.Permission = Outlook.OlPermission.olUnrestricted

            ' '' ''AppOL.COMAddIns
            ' '' ''Adding recipeints to the mail message 
            '' ''msg.Recipients.Add("rahul.dss@gmail.com")
            ' '' ''adding subject information to the mail message 
            '' ''msg.Subject = strSub
            ' '' ''adding body message information to the mail message 
            '' ''msg.Body = strBody
            ' '' ''sending message 
            '' ''msg.Send()
            '************END - SEND MAIL USING MICROSOFT OUTLOOK******************************
        End Sub

        '***** FOR DESKTOP *****
        '' ''Public Shared Sub prcEMailOL(ByVal strTo As String, ByVal strSub As String, ByVal strBody As String, Optional ByVal strCC As String = "", Optional ByVal strBCC As String = "")
        '' ''    Dim AppOL As New Outlook.Application
        '' ''    'creating new blank mail message
        '' ''    Dim Msg As Outlook.MailItem
        '' ''    Msg = AppOL.CreateItem(Outlook.OlItemType.olMailItem)
        '' ''    Try
        '' ''        '************START - SEND MAIL USING MICROSOFT OUTLOOK******************************                
        '' ''        Dim OLNameSpace As Outlook.NameSpace
        '' ''        'dim SM as Outlook.

        '' ''        'msg.Permission = Outlook.OlPermission.olUnrestricted

        '' ''        'AppOL.COMAddIns
        '' ''        'Adding recipeints to the mail message 
        '' ''        Msg.To = strTo
        '' ''        Msg.CC = strCC
        '' ''        Msg.BCC = strBCC
        '' ''        'Msg.Recipients.Add(strTo)

        '' ''        'adding subject information to the mail message 
        '' ''        Msg.Subject = strSub
        '' ''        'adding body message information to the mail message 
        '' ''        'Msg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
        '' ''        Msg.HTMLBody = strBody
        '' ''        'Msg.Body = strBody
        '' ''        System.Windows.Forms.Application.DoEvents()
        '' ''        'Show message 
        '' ''        Msg.Display(1)
        '' ''        System.Windows.Forms.Application.DoEvents()
        '' ''        'sending message 
        '' ''        'Msg.Send()
        '' ''        AppOL = Nothing
        '' ''        'AppOL.Quit()
        '' ''        '************END - SEND MAIL USING MICROSOFT OUTLOOK******************************
        '' ''    Catch ex As Exception
        '' ''        MsgBox(ex.Message)
        '' ''        Msg.Save()
        '' ''        'AppOL.Quit()
        '' ''        AppOL = Nothing
        '' ''    End Try
        '' ''End Sub

        Public Shared Function prcFindInFile(ByVal strFilePath As String, ByVal strFind As String, ByVal strReplace As String) As String
            Dim strFile As String = ""
            Try
                Dim FR As IO.StreamReader
                FR = File.OpenText(strFilePath)

                While Not FR.EndOfStream
                    strFile = FR.ReadToEnd()
                End While
                'MsgBox(Len(strFile) & vbCrLf & strFile)
                'MsgBox("<a href=""#"">")            
                strFile = strFile.Replace(strFind, strReplace)
                'MsgBox(Len(strFile) & vbCrLf & strFile)
                FR.Close()
                Return strFile
            Catch ex As Exception
                'MsgBox(ex.Message)
                MyCLS.clsHandleException.HandleEx(ex)
                Return strFile
            End Try
        End Function

        Public Shared Function prcFindInString(ByVal strString As String, ByVal strFind As String, ByVal strReplace As String) As String
            Dim strModified As String = ""
            Try
                Dim FR As New StringReader(strString)

                While FR.Peek() <> -1
                    'MsgBox(FR.Peek & vbCrLf & strModified)
                    strModified = strModified & FR.ReadLine()
                End While
                'MsgBox(Len(strModified) & vbCrLf & strModified)
                'MsgBox("<a href=""#"">")            

                strModified = strModified.Replace(strFind, strReplace)
                'MsgBox(Len(strModified) & vbCrLf & strModified)
                FR.Close()
                Return strModified
            Catch ex As Exception
                MyCLS.clsHandleException.HandleEx(ex)
                'MsgBox(ex.Message)
                Return strModified
            End Try
        End Function
    End Class
    '**************END - TO MAIL*****************************************************

    Public Shared Sub ConOpen()
        Try
            strGlobalErrorInfo = ""
            'Dim Strconn As String = ConfigurationSettings.AppSettings("strconn1")
            'Dim strconn As String = ConfigurationSettings.AppSettings("strconn1") & path & ConfigurationSettings.AppSettings("strconn3")
            Dim Strconn As String = ConfigurationManager.ConnectionStrings("fmsfConnectionString").ToString
            MyCon = New OleDbConnection(Strconn)
            If Not MyCon.State Then
                MyCon.Open()
            End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Sub

    Public Shared Sub ConClose()
        Try
            strGlobalErrorInfo = ""
            If MyCon.State Then
                MyCon.Close()
            End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Sub

    Public Shared Sub GetCon(ByRef NewCon As OleDbConnection)
        NewCon = MyCon
    End Sub

    Public Shared Function fnMSG(ByVal strMSG As String) As String
        Try
            fnMSG = "<Script>alert('" & strMSG & "');</Script>"
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnIsDuplicate(ByVal TblName As String, ByVal WhereCol1 As String, ByVal Col1Value As String, Optional ByVal strLogicalOperator As String = "AND", Optional ByRef Col1Type As String = "String", Optional ByVal WhereCol2 As String = "", Optional ByVal Col2Value As String = "", Optional ByVal Col2Type As String = "String") As Boolean
        Try
            strGlobalErrorInfo = ""
            Dim QChr1 As Char
            Dim QChr2 As Char

            If Col1Type = "String" Then
                QChr1 = "'"
            ElseIf Col1Type = "Date" Then
                QChr1 = "#"
            Else
                QChr1 = " "
            End If
            If Col2Type = "String" Then
                QChr2 = "'"
            ElseIf Col2Type = "Date" Then
                QChr2 = "#"
            Else
                QChr2 = " "
            End If

            If WhereCol2.Length > 0 Then
                'If Col2Value.Length > 0 Then
                MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2
                'End If
            Else
                MyStr = "Select * From " & TblName & " Where " & WhereCol1 & " = " & QChr1 & Col1Value & QChr1
            End If
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader
            MyRs.Read()
            If MyRs.HasRows Then
                fnIsDuplicate = True
            Else
                fnIsDuplicate = False
            End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function
    Public Shared Function fnIsDuplicateW(ByVal TblName As String, ByVal WhereCol1 As String, ByVal Col1Value As String, Optional ByVal strLogicalOperator As String = "AND", Optional ByRef Col1Type As String = "String", Optional ByVal WhereCol2 As String = "", Optional ByVal Col2Value As String = "", Optional ByVal Col2Type As String = "String", Optional ByVal WhereCol3 As String = "", Optional ByVal Col3Value As String = "", Optional ByVal Col3Type As String = "String", Optional ByVal WhereCol4 As String = "", Optional ByVal Col4Value As String = "", Optional ByVal Col4Type As String = "String", Optional ByVal WhereCol5 As String = "", Optional ByVal Col5Value As String = "", Optional ByVal Col5Type As String = "String", Optional ByVal WhereCol6 As String = "", Optional ByVal Col6Value As String = "", Optional ByVal Col6Type As String = "String", Optional ByVal WhereCol7 As String = "", Optional ByVal Col7Value As String = "", Optional ByVal Col7Type As String = "String", Optional ByVal WhereCol8 As String = "", Optional ByVal Col8Value As String = "", Optional ByVal Col8Type As String = "String", Optional ByVal WhereCol9 As String = "", Optional ByVal Col9Value As String = "", Optional ByVal Col9Type As String = "String", Optional ByVal WhereCol0 As String = "", Optional ByVal Col0Value As String = "", Optional ByVal Col0Type As String = "String") As Boolean
        Try
            strGlobalErrorInfo = ""
            Dim QChr1 As Char
            Dim QChr2 As Char
            Dim QChr3 As Char
            Dim QChr4 As Char
            Dim QChr5 As Char
            Dim QChr6 As Char
            Dim QChr7 As Char
            Dim QChr8 As Char
            Dim QChr9 As Char
            Dim QChr0 As Char

            If Col1Type = "String" Then
                QChr1 = "'"
            ElseIf Col1Type = "Date" Then
                QChr1 = "#"
            Else
                QChr1 = " "
            End If
            If Col2Type = "String" Then
                QChr2 = "'"
            ElseIf Col2Type = "Date" Then
                QChr2 = "#"
            Else
                QChr2 = " "
            End If
            'If Col1Type = "String" Then
            '    QChr1 = "'"
            'ElseIf Col1Type = "Date" Then
            '    QChr1 = "#"
            'Else
            '    QChr1 = " "
            'End If
            If Col3Type = "String" Then
                QChr3 = "'"
            ElseIf Col3Type = "Date" Then
                QChr3 = "#"
            Else
                QChr3 = " "
            End If
            If Col4Type = "String" Then
                QChr4 = "'"
            ElseIf Col4Type = "Date" Then
                QChr4 = "#"
            Else
                QChr4 = " "
            End If
            If Col5Type = "String" Then
                QChr5 = "'"
            ElseIf Col5Type = "Date" Then
                QChr5 = "#"
            Else
                QChr5 = " "
            End If
            If Col6Type = "String" Then
                QChr6 = "'"
            ElseIf Col6Type = "Date" Then
                QChr6 = "#"
            Else
                QChr6 = " "
            End If
            If Col7Type = "String" Then
                QChr7 = "'"
            ElseIf Col7Type = "Date" Then
                QChr7 = "#"
            Else
                QChr7 = " "
            End If
            If Col8Type = "String" Then
                QChr8 = "'"
            ElseIf Col8Type = "Date" Then
                QChr8 = "#"
            Else
                QChr8 = " "
            End If
            If Col9Type = "String" Then
                QChr9 = "'"
            ElseIf Col9Type = "Date" Then
                QChr9 = "#"
            Else
                QChr9 = " "
            End If
            If Col0Type = "String" Then
                QChr0 = "'"
            ElseIf Col0Type = "Date" Then
                QChr0 = "#"
            Else
                QChr0 = " "
            End If
            If WhereCol1.Length > 0 Then
                MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1
                If WhereCol2.Length > 0 Then
                    MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2
                    If WhereCol3.Length > 0 Then
                        MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3
                        If WhereCol4.Length > 0 Then
                            MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3 & " " & strLogicalOperator & " " & WhereCol4 & "=" & QChr4 & Col4Value & QChr4
                            If WhereCol5.Length > 0 Then
                                MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3 & " " & strLogicalOperator & " " & WhereCol4 & "=" & QChr4 & Col4Value & QChr4 & " " & strLogicalOperator & " " & WhereCol5 & "=" & QChr5 & Col5Value & QChr5
                                If WhereCol6.Length > 0 Then
                                    MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3 & " " & strLogicalOperator & " " & WhereCol4 & "=" & QChr4 & Col4Value & QChr4 & " " & strLogicalOperator & " " & WhereCol5 & "=" & QChr5 & Col5Value & QChr5 & " " & strLogicalOperator & " " & WhereCol6 & "=" & QChr6 & Col6Value & QChr6
                                    If WhereCol7.Length > 0 Then
                                        MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3 & " " & strLogicalOperator & " " & WhereCol4 & "=" & QChr4 & Col4Value & QChr4 & " " & strLogicalOperator & " " & WhereCol5 & "=" & QChr5 & Col5Value & QChr5 & " " & strLogicalOperator & " " & WhereCol6 & "=" & QChr6 & Col6Value & QChr6 & " " & strLogicalOperator & " " & WhereCol7 & "=" & QChr7 & Col7Value & QChr7
                                        If WhereCol8.Length > 0 Then
                                            MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3 & " " & strLogicalOperator & " " & WhereCol4 & "=" & QChr4 & Col4Value & QChr4 & " " & strLogicalOperator & " " & WhereCol5 & "=" & QChr5 & Col5Value & QChr5 & " " & strLogicalOperator & " " & WhereCol6 & "=" & QChr6 & Col6Value & QChr6 & " " & strLogicalOperator & " " & WhereCol7 & "=" & QChr7 & Col7Value & QChr7 & " " & strLogicalOperator & " " & WhereCol8 & "=" & QChr8 & Col8Value & QChr8
                                            If WhereCol9.Length > 0 Then
                                                MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3 & " " & strLogicalOperator & " " & WhereCol4 & "=" & QChr4 & Col4Value & QChr4 & " " & strLogicalOperator & " " & WhereCol5 & "=" & QChr5 & Col5Value & QChr5 & " " & strLogicalOperator & " " & WhereCol6 & "=" & QChr6 & Col6Value & QChr6 & " " & strLogicalOperator & " " & WhereCol7 & "=" & QChr7 & Col7Value & QChr7 & " " & strLogicalOperator & " " & WhereCol8 & "=" & QChr8 & Col8Value & QChr8 & " " & strLogicalOperator & " " & WhereCol9 & "=" & QChr9 & Col9Value & QChr9
                                                If WhereCol0.Length > 0 Then
                                                    MyStr = "Select * From " & TblName & " Where " & WhereCol1 & "=" & QChr1 & Col1Value & QChr1 & " " & strLogicalOperator & " " & WhereCol2 & "=" & QChr2 & Col2Value & QChr2 & " " & strLogicalOperator & " " & WhereCol3 & "=" & QChr3 & Col3Value & QChr3 & " " & strLogicalOperator & " " & WhereCol4 & "=" & QChr4 & Col4Value & QChr4 & " " & strLogicalOperator & " " & WhereCol5 & "=" & QChr5 & Col5Value & QChr5 & " " & strLogicalOperator & " " & WhereCol6 & "=" & QChr6 & Col6Value & QChr6 & " " & strLogicalOperator & " " & WhereCol7 & "=" & QChr7 & Col7Value & QChr7 & " " & strLogicalOperator & " " & WhereCol8 & "=" & QChr8 & Col8Value & QChr8 & " " & strLogicalOperator & " " & WhereCol9 & "=" & QChr9 & Col9Value & QChr9 & " " & strLogicalOperator & " " & WhereCol0 & "=" & QChr0 & Col0Value & QChr0
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'msgbox(MyStr)
            'Exit Function

            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader
            MyRs.Read()
            If MyRs.HasRows Then
                fnIsDuplicateW = True
            Else
                fnIsDuplicateW = False
            End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnValidateEmail(ByVal Obj As Object, ByRef LblObj2ShowError As Object) As Boolean
        Try
            strGlobalErrorInfo = ""
            If Obj.Text = "" Then
                LblObj2ShowError.text = "Enter Value for E-MAIL!"
                Obj.Focus()
                fnValidateEmail = False
                Exit Function
            ElseIf InStr(1, Obj.Text, "@") = 0 Then
                LblObj2ShowError.text = "Enter Valid E-MAIL!"
                Obj.Focus()
                fnValidateEmail = False
                Exit Function
            ElseIf InStr(1, Obj.Text, ".") = 0 Then
                LblObj2ShowError.text = "Enter Valid E-MAIL!"
                Obj.Focus()
                fnValidateEmail = False
                Exit Function
            ElseIf InStr(1, Obj.Text, "@") = 1 Then
                LblObj2ShowError.text = "Enter Valid E-MAIL!"
                Obj.Focus()
                fnValidateEmail = False
                Exit Function
            ElseIf InStr(1, Obj.Text, ".") = Len(Obj.Text) Or InStr(1, Obj.Text, ".") + 1 = Len(Obj.Text) Then
                LblObj2ShowError.text = "Enter Valid E-MAIL!"
                Obj.Focus()
                fnValidateEmail = False
                Exit Function
            ElseIf InStr(1, Obj.Text, "@") + 1 = InStr(1, Obj.Text, ".") Or InStr(1, Obj.Text, ".") + 1 = InStr(1, Obj.Text, "@") Then
                LblObj2ShowError.text = "Enter Valid E-MAIL!"
                Obj.Focus()
                fnValidateEmail = False
                Exit Function
            ElseIf IsNumeric(Mid(Obj.Text, 1, 1)) Then
                LblObj2ShowError.text = "Enter Valid E-MAIL!"
                Obj.Focus()
                fnValidateEmail = False
                Exit Function
            End If
            LblObj2ShowError.text = ""
            fnValidateEmail = True
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnGetIncSNO(ByVal TblName As String, ByVal ColName As String) As Long
        Try
            strGlobalErrorInfo = ""

            'FOR MSSQL
            'MyStr = "Select isNull(Max(SNO),1) From AddBook"
            'FOR MSACCESS
            'MyStr = "SELECT iif(isnull(max(sno)),1,max(sno)+1) FROM Book"
            MyStr = "SELECT ISNULL(MAX(" & ColName & ") + 1, 1) FROM " & TblName
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader
            MyRs.Read()

            fnGetIncSNO = MyRs.Item(0)
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnQuerySelect1Value(ByVal TblName As String, ByVal ColName As String) As String
        Dim SelectQ As String
        Try
            strGlobalErrorInfo = ""
            SelectQ = "Select " & ColName & " from " & TblName
            MyCmd = New OleDbCommand(SelectQ, MyCon)
            MyRs = MyCmd.ExecuteReader
            MyRs.Read()
            If MyRs.HasRows Then
                fnQuerySelect1Value = MyRs(ColName).ToString
            Else
                fnQuerySelect1Value = ""
            End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function
    Public Shared Function fnQuerySelect1Value(ByVal TblName As String, ByVal ColName As String, ByVal WhereCol As String, ByVal ColValue As String) As String
        Dim SelectQ As String
        Try
            strGlobalErrorInfo = ""
            SelectQ = "Select " & ColName & " from " & TblName & " Where " & WhereCol & "='" & ColValue & "'"
            MyCmd = New OleDbCommand(SelectQ, MyCon)
            MyRs = MyCmd.ExecuteReader
            MyRs.Read()
            If MyRs.HasRows Then
                fnQuerySelect1Value = MyRs(ColName).ToString
            Else
                fnQuerySelect1Value = ""
            End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function
    Public Shared Function fnQuerySelect1Value(ByVal SelectQ As String) As String
        Try
            strGlobalErrorInfo = ""
            MyCmd = New OleDbCommand(SelectQ, MyCon)
            MyRs = MyCmd.ExecuteReader
            MyRs.Read()
            If MyRs.HasRows Then
                fnQuerySelect1Value = MyRs(0).ToString
            Else
                fnQuerySelect1Value = ""
            End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnQuerySelectRS(ByVal SelectQ As String) As OleDbDataReader
        Try
            strGlobalErrorInfo = ""

            MyCmd = New OleDbCommand(SelectQ, MyCon)
            MyRs = MyCmd.ExecuteReader
            'If MyRs.HasRows = True Then
            fnQuerySelectRS = MyRs
            'End If
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function
    Public Shared Function fnQuerySelectDA(ByVal SelectQ As String) As OleDbDataAdapter
        Try
            strGlobalErrorInfo = ""

            'MyCmd = New OleDbCommand(SelectQ, MyCon)
            MyDa = New OleDbDataAdapter(SelectQ, MyCon)
            'MyDa = MyCmd.ExecuteReader
            fnQuerySelectDA = MyDa
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function
    Public Shared Sub prcQuerySelectDS(ByRef MyDataset As DataSet, ByVal SelectQ As String)
        Try
            strGlobalErrorInfo = ""

            MyDa = New OleDbDataAdapter(SelectQ, MyCon)
            MyDa.Fill(MyDataset)
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Sub

    Public Shared Function fnQueryExecuter(ByVal InsertQ As String, ByVal Trans As OleDbTransaction) As Long
        Try
            If Not MyCon.State = ConnectionState.Open Then
                MyCon.Open()
            End If
            strGlobalErrorInfo = ""
            strDBErrorInfo = ""

            MyCmd = New OleDbCommand(InsertQ, MyCon, Trans)
            MyRs = MyCmd.ExecuteReader
            fnQueryExecuter = MyRs.RecordsAffected
            Return 1
        Catch ex As Exception
            strDBErrorInfo = ex.Message
            MyCLS.clsHandleException.HandleEx(ex)
            Return 0
        End Try
    End Function
    Public Shared Function fnQueryExecuter(ByVal InsertQ As String) As Long
        Try
            If Not MyCon.State = ConnectionState.Open Then
                MyCon.Open()
            End If
            strGlobalErrorInfo = ""
            strDBErrorInfo = ""

            MyTrans = MyCon.BeginTransaction(IsolationLevel.ReadUncommitted)

            MyCmd = New OleDbCommand(InsertQ, MyCon, MyTrans)
            MyRs = MyCmd.ExecuteReader
            fnQueryExecuter = MyRs.RecordsAffected
            MyTrans.Commit()
        Catch ex As Exception
            MyTrans.Rollback()
            strDBErrorInfo = ex.Message
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnQueryInsert(ByVal InsertQ As String) As Long
        Try
            strGlobalErrorInfo = ""

            MyCmd = New OleDbCommand(InsertQ, MyCon)
            MyRs = MyCmd.ExecuteReader
            fnQueryInsert = MyRs.RecordsAffected
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnQueryUpdate(ByVal UpdateQ As String) As Long
        Try
            strGlobalErrorInfo = ""

            MyCmd = New OleDbCommand(UpdateQ, MyCon)
            MyRs = MyCmd.ExecuteReader
            fnQueryUpdate = MyRs.RecordsAffected
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Function fnQueryDelete(ByVal DeleteQ As String) As Long
        Try
            strGlobalErrorInfo = ""

            MyCmd = New OleDbCommand(DeleteQ, MyCon)
            MyRs = MyCmd.ExecuteReader
            fnQueryDelete = MyRs.RecordsAffected
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Function

    Public Shared Sub prcFillDDL(ByVal DDLObj As Object, ByVal TblName As String, ByVal IDCol As String, ByVal ValueCol As String)
        Try
            strGlobalErrorInfo = ""
            MyStr = "SELECT " & IDCol & " ," & ValueCol & " FROM " & TblName & " ORDER BY " & IDCol
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader

            DDLObj.Items.Clear()
            DDLObj.Items.Add("SELECT")
            While MyRs.Read
                'DDLObj.Items.Add(New ListItem(MyRs(ValueCol), MyRs(IDCol)))
                DDLObj.Items.Add(New ListItem(MyRs(1).ToString, MyRs(0).ToString))
            End While
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Sub
    Public Shared Sub prcFillDDL(ByVal DDLObj As Object, ByVal TblName As String, ByVal ValueCol As String, ByVal OrderBy As Boolean)
        Try
            strGlobalErrorInfo = ""
            If OrderBy Then
                MyStr = "SELECT " & ValueCol & " FROM " & TblName & " ORDER BY " & ValueCol
            Else
                MyStr = "SELECT " & ValueCol & " FROM " & TblName
            End If
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader

            DDLObj.Items.Clear()
            DDLObj.Items.Add("SELECT")
            While MyRs.Read
                'DDLObj.Items.Add(MyRs(ValueCol))
                DDLObj.Items.Add(MyRs(0).ToString)
            End While
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Sub
    Public Shared Sub prcFillDDL(ByVal DDLObj As Object, ByVal TblName As String, ByVal IDCol As String, ByVal ValueCol As String, ByVal WhereCol As String, ByVal WhereValue As String)
        Try
            strGlobalErrorInfo = ""
            MyStr = "SELECT " & IDCol & " ," & ValueCol & " FROM " & TblName & " Where " & WhereCol & "='" & WhereValue & "' ORDER BY " & IDCol
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader

            DDLObj.Items.Clear()
            DDLObj.Items.Add("SELECT")
            While MyRs.Read
                'DDLObj.Items.Add(New ListItem(MyRs(ValueCol), MyRs(IDCol)))
                DDLObj.Items.Add(New ListItem(MyRs(1).ToString, MyRs(0).ToString))
            End While
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Sub

    Public Shared Sub prcFillList(ByRef LstObj As Object, ByVal TblName As String, ByVal IDCol As String, ByVal ValueCol As String, ByVal OrderBy As Boolean)
        Try
            strGlobalErrorInfo = ""
            If OrderBy Then
                MyStr = "SELECT " & IDCol & " ," & ValueCol & " FROM " & TblName & " ORDER BY " & ValueCol
            Else
                MyStr = "SELECT " & IDCol & " ," & ValueCol & " FROM " & TblName
            End If
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader

            LstObj.Items.Clear()
            While MyRs.Read
                'LstObj.Items.Add(New ListItem(MyRs(ValueCol), MyRs(IDCol)))
                LstObj.Items.Add(New ListItem(MyRs(1).ToString, MyRs(0).ToString))
            End While
        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
        End Try
    End Sub
    Public Shared Sub prcFillList(ByRef LstObj As Object, ByVal TblName As String, ByVal IDCol As String, ByVal ValueCol As String, ByVal WhCol As String, ByVal WhColVal As String, ByVal OrderBy As Boolean)
        Try
            strGlobalErrorInfo = ""
            If OrderBy Then
                MyStr = "SELECT " & IDCol & " ," & ValueCol & " FROM " & TblName & " WHERE " & ValueCol & " LIKE '%" & WhColVal & "%' ORDER BY " & ValueCol
            Else
                MyStr = "SELECT " & IDCol & " ," & ValueCol & " FROM " & TblName & " WHERE " & ValueCol & " LIKE '%" & WhColVal & "%'"
            End If
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader

            LstObj.Items.Clear()
            While MyRs.Read
                'LstObj.Items.Add(New ListItem(MyRs(ValueCol), MyRs(IDCol)))
                LstObj.Items.Add(New ListItem(MyRs(1).ToString, MyRs(0).ToString))
            End While
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub
    Public Shared Sub prcFillList(ByRef LstObj As Object, ByVal TblName As String, ByVal ValueCol As String, ByVal OrderBy As Boolean)
        Try
            strGlobalErrorInfo = ""
            If OrderBy Then
                MyStr = "SELECT " & ValueCol & " FROM " & TblName & " ORDER BY " & ValueCol
            Else
                MyStr = "SELECT " & ValueCol & " FROM " & TblName
            End If
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader

            LstObj.Items.Clear()
            While MyRs.Read
                LstObj.Items.Add(MyRs(0).ToString)
            End While
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub
    Public Shared Sub prcFillListWithDates(ByRef LstObj As Object, ByVal TblName As String, ByVal ValueCol As String, ByVal DateFormatString As String, ByVal OrderBy As Boolean)
        Try
            strGlobalErrorInfo = ""
            If OrderBy Then
                MyStr = "SELECT " & ValueCol & " FROM " & TblName & " ORDER BY " & ValueCol
            Else
                MyStr = "SELECT " & ValueCol & " FROM " & TblName
            End If
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader

            LstObj.Items.Clear()
            While MyRs.Read
                LstObj.Items.Add(Format(CDate(MyRs(0).ToString), DateFormatString))
            End While
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub

    Public Shared Sub prcFillGrid(ByRef GridObj As Object, ByVal SelectQ As String)
        Try
            strGlobalErrorInfo = ""
            MyCmd = New OleDbCommand(SelectQ, MyCon)
            MyRs = MyCmd.ExecuteReader

            GridObj.DataSource = MyRs
            GridObj.DataBind()
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub

    Public Shared Sub prcEMail(ByVal strTo As String, ByVal strFrom As String, ByVal strSubject As String, ByVal strBody As String, Optional ByVal strCC As String = "", Optional ByVal strBCC As String = "")
        Try
            '*********2.0********
            strGlobalErrorInfo = ""
            Dim Mail As New MailMessage()
            Mail.To.Add(strTo)         'User Email ID
            If strCC.Length > 0 Then Mail.CC.Add(strCC)
            If strBCC.Length > 0 Then Mail.Bcc.Add(strBCC)
            Mail.From = New MailAddress(strFrom)
            Mail.Subject = strSubject
            Mail.Body = strBody
            'SmtpMail.SmtpServer.Insert(0, "smtp.jaypeebrothers.com")
            Dim smtp As New SmtpClient("mail.jaypeebrothers.com")
            smtp.Send(Mail)
            strGlobalErrorInfo = "MAIL SENT SUCCESSFULLY!"



            '*********1.0********
            'strGlobalErrorInfo = ""
            'Dim Mail As New MailMessage()
            'Mail.To = strTo         'User Email ID
            'If strCC.Length > 0 Then Mail.Cc = strCC
            'If strBCC.Length > 0 Then Mail.Cc = strBCC
            'Mail.From = strFrom
            'Mail.Subject = strSubject
            'Mail.Body = strBody
            'SmtpMail.SmtpServer = "localhost"   'your real server goes here

            'Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2) 'basic authentication
            ''Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "202.71.148.84") 'set your username here
            'Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "202.71.129.68") 'set your username here
            'Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)


            'Dim SmtpMail As New SmtpClient("mail.jaypeebrothers.com")
            'SmtpMail.Send(Mail)
            'strGlobalErrorInfo = "MAIL SENT SUCCESSFULLY!"
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub
    Public Shared Sub prcEMailCDO(ByVal strTo As String, ByVal strFrom As String, ByVal strSubject As String, ByVal strBody As String, Optional ByVal strCC As String = "", Optional ByVal strBCC As String = "")
        Dim mailMessage As New System.Net.Mail.MailMessage(strFrom, strTo, strSubject, strBody)
        Dim mailClient As New System.Net.Mail.SmtpClient("209.44.115.202", 25)
        mailClient.UseDefaultCredentials = True
        'mailClient.Credentials = New System.Net.NetworkCredential("10.90.2.143\in.itsupport", "123456")
        mailClient.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

        Try
            If strCC.Length > 0 Then mailMessage.CC.Add(strCC)
            If strBCC.Length > 0 Then mailMessage.Bcc.Add(strBCC)
            mailClient.Send(mailMessage)
        Catch ex As Exception
            strGlobalErrorInfo = ex.ToString
            Exit Sub
        End Try
    End Sub

    Public Shared Sub prcUploadFile(ByVal FUObj As Object, ByVal strPath As String, ByVal strFileName As String)
        Try
            strGlobalErrorInfo = ""
            If Not FUObj.PostedFile Is Nothing And FUObj.PostedFile.ContentLength > 0 Then
                Dim fn As String = System.IO.Path.GetFileName(FUObj.PostedFile.FileName)
                Dim SaveLocation As String
                'If InStr(1, FUObj.PostedFile.ContentType, "jpeg") Or InStr(1, FUObj.PostedFile.ContentType, "jpg") Then
                '    SaveLocation = strPath & "\" & strFileName & ".jpg"
                'ElseIf InStr(1, FUObj.PostedFile.ContentType, "gif") Then
                '    SaveLocation = strPath & "\" & strFileName & ".gif"
                'Else
                SaveLocation = strPath & "\" & strFileName
                'End If
                FUObj.PostedFile.SaveAs(SaveLocation)
                strGlobalErrorInfo = "The file has been uploaded."
            Else
                strGlobalErrorInfo = "Please select a file to upload."
            End If
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub

    Public Shared Function fnListIsChecked(ByRef ListObj As Object) As Boolean
        Try
            strGlobalErrorInfo = ""
            Dim intCounter As Integer
            For intCounter = 0 To ListObj.Items.Count - 1
                If ListObj.Items(intCounter).Selected = True Then
                    fnListIsChecked = True
                    Exit Function
                End If
            Next
            fnListIsChecked = False
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function
    Public Shared Sub prcListCheckAll(ByRef ListObj As Object)
        Try
            strGlobalErrorInfo = ""
            Dim intCounter As Integer
            For intCounter = 0 To ListObj.Items.Count - 1
                ListObj.Items(intCounter).Selected = True
            Next
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub
    Public Shared Sub prcListUnCheckAll(ByRef ListObj As Object)
        Try
            strGlobalErrorInfo = ""
            Dim intCounter As Integer
            For intCounter = 0 To ListObj.Items.Count - 1
                ListObj.Items(intCounter).Selected = False
            Next
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub

    Public Shared Function fnQuoteRemove(ByVal StrV As Object) As String
        Try
            strGlobalErrorInfo = ""
            fnQuoteRemove = Replace(StrV, "'", "+ 39 +")
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function
    Public Shared Function fnQuoteRetrieve(ByVal StrV As Object) As String
        Try
            strGlobalErrorInfo = ""
            fnQuoteRetrieve = Replace(StrV, "+ 39 +", "'")
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function
    Public Shared Function fnQuoteConvert4Query(ByVal StrV As Object) As String
        Try
            strGlobalErrorInfo = ""
            fnQuoteConvert4Query = Replace(StrV, "'", "''")
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function

    Public Shared Function fnGeneratePassword() As String
        Try
            strGlobalErrorInfo = ""
            Dim rndValue As New Random
            fnGeneratePassword = Chr(rndValue.Next(65, 90)) & Chr(rndValue.Next(65, 90)) & Chr(rndValue.Next(97, 122)) & Chr(rndValue.Next(97, 122)) & Chr(rndValue.Next(65, 90)) & Chr(rndValue.Next(97, 122)) & Chr(rndValue.Next(97, 122)) & Chr(rndValue.Next(97, 122))
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function

    Public Shared Sub prcClearTextBoxes(ByVal Pg As Page, ByVal FormName As String)
        Try
            strGlobalErrorInfo = ""
            Dim myForm As Control
            Dim Ctrl As Control
            myForm = Pg.FindControl(FormName)
            For Each Ctrl In myForm.Controls
                If (Ctrl.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox")) Then
                    CType(Ctrl, TextBox).Text = ""
                End If
            Next
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub
    Public Shared Sub prcFillTextBoxesWith0(ByVal Pg As Page, ByVal FormName As String)
        Try
            strGlobalErrorInfo = ""
            Dim myForm As Control
            Dim Ctrl As Control
            myForm = Pg.FindControl(FormName)
            For Each Ctrl In myForm.Controls
                If (Ctrl.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox")) Then
                    If CType(Ctrl, TextBox).Text = "" Then
                        CType(Ctrl, TextBox).Text = "0"
                    End If
                End If
            Next
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub

    Public Shared Sub prcFillASPTable(ByVal SelectQ As String, ByVal ASPTable As Object, ByVal TblName As String)
        Try
            strGlobalErrorInfo = ""
            Dim DS As DataSet
            MyDa = New OleDbDataAdapter(SelectQ, MyCon)
            DS = New DataSet()
            MyDa.Fill(DS, TblName)
            Dim DC As DataColumn
            Dim DR As DataRow
            For Each DR In DS.Tables(0).Rows
                Dim TRow As New TableRow()
                For Each DC In DS.Tables(0).Columns
                    Dim TCell As New TableCell()
                    TCell.Controls.Add(New LiteralControl(DR(DC.ColumnName).ToString))
                    TRow.Cells.Add(TCell)
                Next
                ASPTable.Rows.Add(TRow)
            Next
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub

    Public Shared Function fnCountRows(ByVal StrQ As String) As Long
        Try
            strGlobalErrorInfo = ""
            Dim TRows As Long

            MyCmd = New OleDbCommand(StrQ, MyCon)
            MyRs = MyCmd.ExecuteReader()
            TRows = 0

            While MyRs.Read
                TRows = TRows + 1
            End While
            fnCountRows = TRows
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function

    Public Shared Function fnGetExtension(ByVal FileName As String) As String
        Try
            strGlobalErrorInfo = ""
            Dim intLoc As Integer
            Dim strExt As String

            intLoc = InStr(FileName, ".") + 1
            strExt = Mid(FileName, intLoc)
            fnGetExtension = strExt
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function

    Public Shared Function fnShowException(ByVal ex As Exception) As String
        strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
        strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
        strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)

        fnShowException = strGlobalErrorInfo
    End Function

    Public Shared Sub prcFillDates2DDL(ByRef DDLObj As Object)
        DDLObj.Items.Add(New ListItem("Everyday", 0))
        DDLObj.Items.Add(New ListItem("Monday", 1))
        DDLObj.Items.Add(New ListItem("Tuesday", 2))
        DDLObj.Items.Add(New ListItem("Wednesday", 3))
        DDLObj.Items.Add(New ListItem("Thursday", 4))
        DDLObj.Items.Add(New ListItem("Friday", 5))
        DDLObj.Items.Add(New ListItem("Saturday", 6))
        DDLObj.Items.Add(New ListItem("Sunday", 7))
    End Sub

    Public Shared Function fnConvertedString(ByVal strOldPath As String) As String
        Try
            Dim str12s() As String = strOldPath.Split("\")
            Dim i As Integer
            Dim strNewPath As String
            For i = 0 To str12s.Length - 1
                '   'msgbox(str12s(i))
                If str12s(i).Contains(" ") = True Then
                    str12s(i).Replace(" ", "")
                    If (str12s(i).Length > 6) Then
                        str12s(i) = str12s(i).Substring(0, 6) & "~1"
                        '            'msgbox(str12s(i))
                    Else
                        str12s(i) = str12s(i) & "~1"
                        'msgbox(str12s(i))
                    End If
                    strNewPath = strNewPath & str12s(i) & "\"
                Else
                    If (str12s(i).Length > 8) Then
                        str12s(i) = str12s(i).Substring(0, 6) & "~1"
                        'msgbox(str12s(i))
                    End If
                    strNewPath = strNewPath & str12s(i) & "\"
                End If
            Next
            fnConvertedString = strNewPath
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function

    Public Shared Sub RecursiveCopyFiles(ByVal sourceDir As String, ByVal destDir As String, ByVal fRecursive As Boolean)
        Dim i As Integer
        Dim posSep As Integer
        Dim sDir As String
        Dim aDirs() As String
        Dim sFile As String
        Dim aFiles() As String

        'cmdNext.Enabled = False
        'cmdBack.Enabled = False

        ' Add trailing separators to the supplied paths if they don't exist.
        If Not sourceDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
            sourceDir &= System.IO.Path.DirectorySeparatorChar
        End If

        If Not destDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
            destDir &= System.IO.Path.DirectorySeparatorChar
        End If

        ' Recursive switch to continue drilling down into dir structure.
        If fRecursive Then
            ' Get a list of directories from the current parent.
            aDirs = System.IO.Directory.GetDirectories(sourceDir)

            '//PBExtract.Maximum = IIf(aDirs.GetUpperBound(0) > 0, aDirs.GetUpperBound(0), 100)

            For i = 0 To aDirs.GetUpperBound(0)
                ' Get the position of the last separator in the current path.
                posSep = aDirs(i).LastIndexOf("\")
                ' Get the path of the source directory.
                sDir = aDirs(i).Substring((posSep + 1), aDirs(i).Length - (posSep + 1))
                ' Create the new directory in the destination directory.
                System.IO.Directory.CreateDirectory(destDir + sDir)

                ' //PBExtract.Value = i

                ' Since we are in recursive mode, copy the children also
                RecursiveCopyFiles(aDirs(i), (destDir + sDir), fRecursive)
            Next
        End If
        ' Get the files from the current parent.
        aFiles = System.IO.Directory.GetFiles(sourceDir)
        'PBExtract.Maximum = IIf(aFiles.GetUpperBound(0) > 0, aFiles.GetUpperBound(0), 100)
        ' Copy all files.
        For i = 0 To aFiles.GetUpperBound(0)
            ' Get the position of the trailing separator.
            posSep = aFiles(i).LastIndexOf("\")
            ' Get the full path of the source file.

            sFile = aFiles(i).Substring((posSep + 1), aFiles(i).Length - (posSep + 1))
            ' Copy the file.            
            System.IO.File.Copy(aFiles(i), destDir + sFile)

            'lstExtractFiles.Items.Add("Extract :" & sFile & "......")
            'lstExtractFiles.SelectedIndex = lstExtractFiles.Items.Count - 1
            'lstExtractFiles.EndUpdate()
            'System.Windows.Forms.Application.DoEvents()
            'PBExtract.Value = i
        Next i
        'PBExtract.Value = 0
    End Sub

    Public Shared Function fnDeleteVirtualDirectory(ByVal VirtualDirName As String) As String
        Dim IIsWebVDirRootObj As Object
        Dim IIsWebVDirObj As Object
        ' Create an instance of the virtual directory object 
        ' that represents the default Web site.
        IIsWebVDirRootObj = GetObject("IIS://localhost/W3SVC/1/Root")
        ' Use the Windows ADSI container object "Create" method to create 
        ' a new virtual directory.
        Try
            IIsWebVDirObj = IIsWebVDirRootObj.Delete("IIsWebVirtualDir", VirtualDirName)
            fnDeleteVirtualDirectory = "Deleted!"
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Function

    Public Shared Sub prcDeleteFolder(ByVal Path As String)
        Try
            Directory.Delete(Path, True)
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub

    Public Shared Sub ModifyWebConfig(ByVal VirtualDirPath As String, ByVal strIPAddress As String, ByVal strSqlUserName As String, ByVal strSqlPassword As String)
        Try
            Dim FILENAME As String = VirtualDirPath & "\web1.config"
            Dim filename1 As String = VirtualDirPath & "\web.config"
            Dim objStreamReader As StreamReader
            objStreamReader = File.OpenText(FILENAME)
            Dim objStreamWriter As StreamWriter

            Dim contents As String

            objStreamWriter = File.CreateText(filename1)
            While objStreamReader.Peek() > -1
                contents = objStreamReader.ReadLine()
                contents = Replace(contents, "IPADD", strIPAddress)
                contents = Replace(contents, "USERNAME", strSqlUserName)
                contents = Replace(contents, "PASSWORD", strSqlPassword)
                objStreamWriter.WriteLine(contents)
            End While
            objStreamReader.Close()
            objStreamWriter.Close()
            'File.Delete(VirtualDirPath & "\PublishedData\web1.config")
            '========================================================
            'msgbox(strWebConfig)
            'msgbox(FileSystem.ReadAllText(strWebConfig))
            'msgbox(strIPAddress)
            'msgbox(strSqlUserName)
            'msgbox(strSqlPassword)

            'FileSystem.ReadAllText(strWebConfig).Replace("IPADD", strIPAddress)
            'FileSystem.ReadAllText(strWebConfig).Replace("USERNAME", strSqlUserName)
            'FileSystem.ReadAllText(strWebConfig).Replace("PASSWORD", strSqlPassword)

            'msgbox(FileSystem.ReadAllText(strWebConfig))
            '========================================================

        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
        End Try
    End Sub




    '******TRYING TO ASSIGN MULTIPLE VALUES TO A PARAMETER IN FUNCTION DEFINITION******
    ''Dim PArray() As String
    'Private Shared Sub FillArray(ByRef PArray())
    '    PArray(0) = "a"
    '    PArray(1) = "b"
    '    PArray(2) = "c"
    'End Sub
    'Public Shared Sub Abc(ByVal PArray() As String)
    '    Call FillArray(PArray)
    '    Dim i
    '    For i = LBound(PArray) To UBound(PArray)
    '        'msgbox(PArray(i))
    '    Next
    'End Sub
    'Public Sub AbcCall()
    '    Abc("ffgdf")
    'End Sub

    Public Shared Function fnGetLastSNO(ByVal TblName As String, ByVal ColName As String) As Long
        Try
            If Not MyCon.State = ConnectionState.Open Then
                MyCon.Open()
            End If
            strGlobalErrorInfo = ""

            'FOR MSSQL
            'MyStr = "Select isNull(Max(SNO),1) From AddBook"
            'FOR MSACCESS
            'MyStr = "SELECT iif(isnull(max(sno)),1,max(sno)+1) FROM Book"
            MyStr = "SELECT MAX(" & ColName & ") FROM " & TblName
            MyCmd = New OleDbCommand(MyStr, MyCon)
            MyRs = MyCmd.ExecuteReader
            MyRs.Read()

            fnGetLastSNO = MyRs.Item(0)
        Catch ex As Exception
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
            'fnWrite2LOG(strGlobalErrorInfo, System.Reflection.MethodBase.GetCurrentMethod().ToString())
        End Try
    End Function

    Public Shared Function fnQueryTruncate(ByVal TruncateTable As String) As Long
        Try
            If Not MyCon.State = ConnectionState.Open Then
                MyCon.Open()
            End If
            strGlobalErrorInfo = ""
            Dim trCmd As String = "Truncate table " & TruncateTable
            MyCmd = New OleDbCommand(trCmd, MyCon)
            MyRs = MyCmd.ExecuteReader
            fnQueryTruncate = MyRs.RecordsAffected
        Catch ex As Exception
            strGlobalErrorInfo = "Query is : " & TruncateTable
            strGlobalErrorInfo = strGlobalErrorInfo & vbCrLf & vbCrLf & String.Concat(ex.Message & vbCrLf, ex.Source & vbCrLf, ex.StackTrace & vbCrLf)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.TargetSite, ex.InnerException)
            strGlobalErrorInfo = String.Concat(strGlobalErrorInfo & vbCrLf, ex.Data)
            'fnWrite2LOG(strGlobalErrorInfo, System.Reflection.MethodBase.GetCurrentMethod().ToString())
        End Try
    End Function

    Public Shared Function Encrypt(ByVal Value As String) As String
        Try
            If Len(Value) > 0 Then
                Dim i As Integer
                Dim NValue As String
                For i = 1 To Value.Length
                    NValue = NValue & Chr(Asc(Mid(Value, i, 1)) + 1)
                Next
                Encrypt = NValue
            End If
        Catch ex As Exception
            'fnWrite2LOG(strGlobalErrorInfo, System.Reflection.MethodBase.GetCurrentMethod().ToString())
        End Try
    End Function

    Public Shared Function Decrypt(ByVal Value As String) As String
        Try
            If Len(Value) > 0 Then
                Dim i As Integer
                Dim NValue As String
                For i = 1 To Value.Length
                    NValue = NValue & Chr(Asc(Mid(Value, i, 1)) - 1)
                Next
                Decrypt = NValue
            End If
        Catch ex As Exception
            'fnWrite2LOG(strGlobalErrorInfo, System.Reflection.MethodBase.GetCurrentMethod().ToString())
        End Try
    End Function

    '***** FOR DESKTOP *****

    '' ''Public Shared Function fnGetDBString() As String
    '' ''    Try
    '' ''        Dim oFile As System.IO.File
    '' ''        Dim oRead As System.IO.StreamReader

    '' ''        oRead = oFile.OpenText(My.Application.Info.DirectoryPath() & "\db.dat")
    '' ''        fnGetDBString = Decrypt(oRead.ReadLine())


    '' ''        oFile = Nothing
    '' ''    Catch ex As Exception
    '' ''        fnWrite2LOG(strGlobalErrorInfo, System.Reflection.MethodBase.GetCurrentMethod().ToString())
    '' ''        MsgBox(ex.Message, MsgBoxStyle.Critical, "Database error")
    '' ''    End Try
    '' ''End Function


    '' ''Public Shared Sub fnWrite2LOG(ByVal ErrMSG As String, ByVal MethodName As String)
    '' ''    Try
    '' ''        Dim oFile As System.IO.File
    '' ''        Dim oWrite As System.IO.StreamWriter

    '' ''        oWrite = oFile.AppendText(My.Application.Info.DirectoryPath() & "\Err.dat")

    '' ''        oWrite.WriteLine(vbCrLf & "***" & Format(Now(), "MM/dd/yyyy hh:mm:ss tt") & "********************" & vbCrLf & MethodName & vbCrLf & ErrMSG)

    '' ''        oWrite.Close()
    '' ''        oFile = Nothing
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message, MsgBoxStyle.Information)
    '' ''    End Try
    '' ''End Sub

    '' ''Public Shared Sub fnWrite2LOG4Import(ByVal strMSG As String)
    '' ''    Try
    '' ''        Dim oFile As System.IO.File
    '' ''        Dim oWrite As System.IO.StreamWriter

    '' ''        oWrite = oFile.AppendText(My.Application.Info.DirectoryPath() & "\Import_" & Format(Now(), "yyyyMMdd") & ".log")

    '' ''        oWrite.WriteLine(strMSG)

    '' ''        oWrite.Close()
    '' ''        oFile = Nothing
    '' ''    Catch ex As Exception
    '' ''        MsgBox(ex.Message, MsgBoxStyle.Information)
    '' ''    End Try
    '' ''End Sub



    '' ''Public Shared Sub prcAlignObjects(ByRef Frm As Form, ByRef Ctrl As GroupBox)
    '' ''    'Dim Ctrl As Control
    '' ''    'For Each Ctrl In Frm.Controls
    '' ''    'If TypeOf Ctrl Is GroupBox Then        
    '' ''    Ctrl.Left = (Frm.Width - Ctrl.Width) / 2
    '' ''    Ctrl.Top = (Frm.Height - Ctrl.Height - 40) / 2
    '' ''    'End If
    '' ''    'Next
    '' ''End Sub

    '' ''Public Shared Sub prcInitialize(ByRef Obj As Object)
    '' ''    Dim Ctrl As Control
    '' ''    For Each Ctrl In Obj.Controls
    '' ''        If TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is TabControl Then
    '' ''            prcInitialize(Ctrl)
    '' ''        Else
    '' ''            If UCase(Ctrl.Name) <> "CMDADD" And UCase(Ctrl.Name) <> "CMDCLOSE" And UCase(Ctrl.Name) <> "CMDFIND" Then
    '' ''                Ctrl.Enabled = False
    '' ''            Else
    '' ''                Ctrl.Enabled = True
    '' ''            End If
    '' ''        End If
    '' ''    Next

    '' ''    'Me.cmdAdd.Parent.Parent.Enabled = True
    '' ''    'Me.cmdAdd.Parent.Enabled = True
    '' ''    'Me.cmdAdd.Enabled = True
    '' ''    'Me.cmdFind.Enabled = True
    '' ''    'Me.CmdClose.Enabled = True
    '' ''End Sub
    '' ''Public Shared Sub prcInitAdd(ByRef Obj As Object)
    '' ''    Dim Ctrl As Control
    '' ''    For Each Ctrl In Obj.Controls
    '' ''        If TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is TabControl Then
    '' ''            prcInitAdd(Ctrl)
    '' ''        Else
    '' ''            If UCase(Ctrl.Name) <> "CMDMODIFY" And UCase(Ctrl.Name) <> "CMDDELETE" Then
    '' ''                Ctrl.Enabled = True
    '' ''            Else
    '' ''                Ctrl.Enabled = False
    '' ''            End If
    '' ''        End If
    '' ''    Next
    '' ''End Sub
    '' ''Public Shared Sub prcInitFind(ByRef Obj As Object)
    '' ''    Dim Ctrl As Control
    '' ''    For Each Ctrl In Obj.Controls
    '' ''        If TypeOf Ctrl Is GroupBox Or TypeOf Ctrl Is TabControl Then
    '' ''            prcInitFind(Ctrl)
    '' ''        Else
    '' ''            If UCase(Ctrl.Name) = "CMDMODIFY" Or UCase(Ctrl.Name) = "CMDDELETE" Then
    '' ''                Ctrl.Enabled = True
    '' ''            End If
    '' ''            If UCase(Ctrl.Name) = "CMDSAVE" Then
    '' ''                Ctrl.Enabled = False
    '' ''            End If
    '' ''        End If
    '' ''    Next
    '' ''End Sub
    '' ''Public Shared Sub prcClear(ByRef Obj As Object, Optional ByVal Obj2Leave As String = "")
    '' ''    Dim Ctrl As Control
    '' ''    For Each Ctrl In Obj.Controls
    '' ''        'If InStr(Ctrl.Name, "txt") Then
    '' ''        'MsgBox(Ctrl.Name)
    '' ''        'End If
    '' ''        If TypeOf Ctrl Is GroupBox Then
    '' ''            prcClear(Ctrl, Obj2Leave)
    '' ''        ElseIf TypeOf Ctrl Is TabControl Then
    '' ''            prcClear(Ctrl, Obj2Leave)
    '' ''        ElseIf TypeOf Ctrl Is TabPage Then
    '' ''            prcClear(Ctrl, Obj2Leave)
    '' ''        ElseIf Ctrl.Name = Obj2Leave Then
    '' ''            Continue For
    '' ''        ElseIf TypeOf Ctrl Is TextBox Then
    '' ''            Ctrl.Text = ""
    '' ''        ElseIf TypeOf Ctrl Is ComboBox Then
    '' ''            Ctrl.Text = ""
    '' ''        ElseIf TypeOf Ctrl Is CheckBox Then
    '' ''            CType(Ctrl, CheckBox).Checked = False
    '' ''        ElseIf TypeOf Ctrl Is DataGridView Then
    '' ''            CType(Ctrl, DataGridView).DataSource = Nothing
    '' ''        End If
    '' ''    Next
    '' ''End Sub

    Public Shared Function fnValidateDATA(ByRef txt As TextBox, ByVal strPattern As String, ByVal Type As String) As Boolean
        'Dim pattern As New Regex(Validation)
        Dim pattern As New Regex(strPattern)
        Dim patternMatch As Match = pattern.Match(txt.Text)

        If Len(txt.Text) = 0 Then
            Return True
        End If
        If Not patternMatch.Success Then
            If UCase(Type) = "FAX" Then
                MsgBox("Invalid Fax Number!")
            ElseIf UCase(Type) = "EMAIL" Then
                MsgBox("Invalid Email ID!")
            ElseIf UCase(Type) = "ZIP" Then
                MsgBox("Invalid Zipcode!")
            ElseIf UCase(Type) = "PHONE" Then
                MsgBox("Invalid Phone Number!")
            End If
            txt.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Sub prcUpdateWithOleDbDataAdapter(ByRef ADP As OleDbDataAdapter, ByRef DS As DataSet, ByVal strAllQueries() As String, ByVal TableName As String)
        For i As Int16 = 1 To strAllQueries.GetUpperBound(0)
            MsgBox(strAllQueries(i))
            ADP.InsertCommand = New OleDb.OleDbCommand
            ADP.InsertCommand.CommandText = strAllQueries(i)
            ADP.InsertCommand.Connection = MyCon
            ADP.Update(DS, TableName)
            DS.AcceptChanges()
        Next
    End Sub


    Public Shared Function fnRemoveHTML(ByVal strText)
        Dim TAGLIST
        TAGLIST = ";!--;!DOCTYPE;A;ACRONYM;ADDRESS;APPLET;AREA;B;BASE;BASEFONT;" & _
                  "BGSOUND;BIG;BLOCKQUOTE;BODY;BR;BUTTON;CAPTION;CENTER;CITE;CODE;" & _
                  "COL;COLGROUP;COMMENT;DD;DEL;DFN;DIR;DIV;DL;DT;EM;EMBED;FIELDSET;" & _
                  "FONT;FORM;FRAME;FRAMESET;HEAD;H1;H2;H3;H4;H5;H6;HR;HTML;I;IFRAME;IMG;" & _
                  "INPUT;INS;ISINDEX;KBD;LABEL;LAYER;LAGEND;LI;LINK;LISTING;MAP;MARQUEE;" & _
                  "MENU;META;NOBR;NOFRAMES;NOSCRIPT;OBJECT;OL;OPTION;P;PARAM;PLAINTEXT;" & _
                  "PRE;Q;S;SAMP;SCRIPT;SELECT;SMALL;SPAN;STRIKE;STRONG;STYLE;SUB;SUP;" & _
                  "TABLE;TBODY;TD;TEXTAREA;TFOOT;TH;THEAD;TITLE;TR;TT;U;UL;VAR;WBR;XMP;"

        Const BLOCKTAGLIST = ";APPLET;EMBED;FRAMESET;HEAD;NOFRAMES;NOSCRIPT;OBJECT;SCRIPT;STYLE;"

        Dim nPos1
        Dim nPos2
        Dim nPos3
        Dim strResult
        Dim strTagName
        Dim bRemove
        Dim bSearchForBlock

        nPos1 = InStr(strText, "<")
        Do While nPos1 > 0
            nPos2 = InStr(nPos1 + 1, strText, ">")
            If nPos2 > 0 Then
                strTagName = Mid(strText, nPos1 + 1, nPos2 - nPos1 - 1)
                strTagName = Replace(Replace(strTagName, vbCr, " "), vbLf, " ")

                nPos3 = InStr(strTagName, " ")
                If nPos3 > 0 Then
                    strTagName = Left(strTagName, nPos3 - 1)
                End If

                If Left(strTagName, 1) = "/" Then
                    strTagName = Mid(strTagName, 2)
                    bSearchForBlock = False
                Else
                    bSearchForBlock = True
                End If

                If InStr(1, TAGLIST, ";" & strTagName & ";", vbTextCompare) > 0 Then
                    bRemove = True
                    If bSearchForBlock Then
                        If InStr(1, BLOCKTAGLIST, ";" & strTagName & ";", vbTextCompare) > 0 Then
                            nPos2 = Len(strText)
                            nPos3 = InStr(nPos1 + 1, strText, "</" & strTagName, vbTextCompare)
                            If nPos3 > 0 Then
                                nPos3 = InStr(nPos3 + 1, strText, ">")
                            End If

                            If nPos3 > 0 Then
                                nPos2 = nPos3
                            End If
                        End If
                    End If
                Else
                    bRemove = False
                End If

                If bRemove Then
                    strResult = strResult & Left(strText, nPos1 - 1)
                    strText = Mid(strText, nPos2 + 1)
                Else
                    strResult = strResult & Left(strText, nPos1)
                    strText = Mid(strText, nPos1 + 1)
                End If
            Else
                strResult = strResult & strText
                strText = ""
            End If

            nPos1 = InStr(strText, "<")
        Loop
        strResult = strResult & strText

        fnRemoveHTML = strResult
    End Function
End Class