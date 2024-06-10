
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Script.Serialization
Imports System.Data
Imports System.Web.Query.Dynamic


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
<System.Web.Script.Services.ScriptService()> _
<WebService([Namespace]:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
Public Class WebService
    Inherits System.Web.Services.WebService


    'Uncomment the following line if using designed components 
    'InitializeComponent(); 
    Public Sub New()
    End Sub

    '<WebMethod()> _
    'Public Sub registerUser(userName As String, userPassword As String, userContact As String, userEmail As String, userCompany As String)
    '    Dim con As SqlConnection
    '    Dim constring As String
    '    constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
    '    con = New SqlConnection(constring)

    '    Try
    '        Using cmd As New SqlCommand("VCSP_RegisterUser", con)
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.Parameters.AddWithValue("@userName", userName)
    '            cmd.Parameters.AddWithValue("@userPassword", userPassword)
    '            cmd.Parameters.AddWithValue("@userContact", userContact)
    '            cmd.Parameters.AddWithValue("@userEmail", userEmail)
    '            cmd.Parameters.AddWithValue("@userCompany", userCompany)

    'Dim returnParam = New SqlParameter() With { _
    '	Key.ParameterName = "@outputMSG", _
    '	Key.Direction = ParameterDirection.Output, _
    '	Key.Size = 200 _
    '}
    '            cmd.Parameters.Add(returnParam)

    '            con.Close()
    '            con.Open()

    '            cmd.ExecuteNonQuery()
    '            Dim retunvalue As String = DirectCast(cmd.Parameters("@outputMSG").Value, String)
    '            con.Close()
    '            Dim js As New JavaScriptSerializer()
    '            Context.Response.Write(js.Serialize(retunvalue))
    '        End Using
    '    Catch ex As Exception
    '    End Try
    'End Sub

    '<WebMethod()> _
    'Public Sub verifyUser(userEmail As String, userPassword As String)
    '    Dim con As SqlConnection
    '    Dim constring As String
    '    constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
    '    con = New SqlConnection(constring)

    '    Try
    '        Using cmd As New SqlCommand("VCSP_VerifyUser", con)
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.Parameters.AddWithValue("@userEmail", userEmail)
    '            cmd.Parameters.AddWithValue("@userPassword", userPassword)

    'Dim returnParam = New SqlParameter() With { _
    '	Key.ParameterName = "@outputMSG", _
    '	Key.Direction = ParameterDirection.Output, _
    '	Key.Size = 200 _
    '}
    '            cmd.Parameters.Add(returnParam)

    '            con.Close()
    '            con.Open()

    '            cmd.ExecuteNonQuery()
    '            Dim retunvalue As String = DirectCast(cmd.Parameters("@outputMSG").Value, String)
    '            con.Close()
    '            Dim js As New JavaScriptSerializer()
    '            Context.Response.Write(js.Serialize(retunvalue))
    '        End Using
    '    Catch ex As Exception
    '    End Try
    'End Sub

    <WebMethod()> _
    Public Sub CreateRoom(RoomName As String, RoomDate As String, RoomCreator As String, RoomTopic As String, RoomId As String, RoomUsers As String, _
  RoomStatus As String, RoomType As String, RoomSize As Integer)
        Dim con As SqlConnection
        Dim constring As String
        constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
        con = New SqlConnection(constring)
        Try
            Using cmd As New SqlCommand("VCSP_CreateRoom", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@RoomName", RoomName)
                cmd.Parameters.AddWithValue("@RoomCreator", RoomCreator)
                cmd.Parameters.AddWithValue("@RoomTopic", RoomTopic)
                cmd.Parameters.AddWithValue("@RoomId", RoomId)
                cmd.Parameters.AddWithValue("@RoomUsers", RoomUsers)
                cmd.Parameters.AddWithValue("@RoomStatus", RoomStatus)
                cmd.Parameters.AddWithValue("@RoomType", RoomType)
                cmd.Parameters.AddWithValue("@RoomSize", RoomSize)

                con.Close()
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Dim js As New JavaScriptSerializer()
                Context.Response.Write(js.Serialize("Success"))
            End Using
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub updateRoomMember(userEmail As String, MemberId As String)
        Dim con As SqlConnection
        Dim constring As String
        constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
        con = New SqlConnection(constring)

        Try
            Using cmd As New SqlCommand("VCSP_UpdateRoomMember", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@userEmail", userEmail)
                cmd.Parameters.AddWithValue("@MemberId", MemberId)
                con.Close()
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Dim js As New JavaScriptSerializer()
                Context.Response.Write(js.Serialize("Success"))
            End Using
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub getRoomDetails(RoomId As String)
        Dim con As SqlConnection
        Dim constring As String
        constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
        con = New SqlConnection(constring)
        Dim RoomObj As New Dictionary(Of String, String)()
        Try
            Using cmd As New SqlCommand("VCSP_roomDetail", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@RoomId", RoomId)
                con.Close()
                con.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)

                ' Dim namesArray As String() = ds.Tables(0).Rows(0)("RoomUsers").ToString().Split(","c)
                RoomObj.Add("RoomId", RoomId)
                RoomObj.Add("RoomUsers", ds.Tables(0).Rows(0)("RoomUsers").ToString())
                RoomObj.Add("RoomOrganiser", ds.Tables(0).Rows(0)("OrganiserEmail").ToString())
                RoomObj.Add("RoomTopic", ds.Tables(0).Rows(0)("RoomTopic").ToString())

                con.Close()
                Dim js As New JavaScriptSerializer()
                Context.Response.Write(js.Serialize(RoomObj))
            End Using
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub getActiveMembers(RoomId As String)
        Dim con As SqlConnection
        Dim constring As String
        Dim members As New List(Of String)()
        constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
        con = New SqlConnection(constring)
        Try
            Using cmd As New SqlCommand("VCSP_getActiveMembers", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@RoomId", RoomId)
                con.Close()
                con.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    members.Add(ds.Tables(0).Rows(i)("userEmail").ToString())
                Next
                con.Close()
                Dim js As New JavaScriptSerializer()
                Context.Response.Write(js.Serialize(members))
            End Using
        Catch ex As Exception
        End Try
    End Sub
    <WebMethod()> _
    Public Sub deleteRoomMember(userEmail As String, RoomId As String)
        Dim con As SqlConnection
        Dim constring As String
        constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
        con = New SqlConnection(constring)

        Try
            Using cmd As New SqlCommand("VCSP_DeleteRoomMember", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@userEmail", userEmail)
                cmd.Parameters.AddWithValue("@RoomId", RoomId)
                con.Close()
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Dim js As New JavaScriptSerializer()
                Context.Response.Write(js.Serialize("Success"))
            End Using
        Catch ex As Exception
        End Try
    End Sub

    <WebMethod()> _
    Public Sub getEmailfromMemberId(MemberId As String)
        Dim con As SqlConnection
        Dim constring As String
        constring = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
        con = New SqlConnection(constring)
        Dim memberEmail As String
        Try
            Using cmd As New SqlCommand("getEmailfromMemberId", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@MemberId", MemberId)
                con.Close()
                con.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                memberEmail = ds.Tables(0).Rows(0)("userEmail").ToString()
                con.Close()
                Dim js As New JavaScriptSerializer()
                Context.Response.Write(js.Serialize(memberEmail))
            End Using
        Catch ex As Exception
        End Try
    End Sub

End Class
