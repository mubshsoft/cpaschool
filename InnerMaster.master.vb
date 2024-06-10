Imports System.Data.SqlClient
Partial Class InnerMaster
    Inherits System.Web.UI.MasterPage
    Protected dsNews As New DataSet
    Public rowCount As Integer = 1
    Public rowNumber As Integer = 2
    Public rowCount2 As Integer = 1
    Public rowNumber2 As Integer = 3

    Dim strConnectionString As String = ""
    Dim ObjCon As New SqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            strConnectionString = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
            ObjCon = New SqlConnection(strConnectionString)
            ObjCon.Open()
            BindCategories()
            BindKD()
            BindSocial()
        End If
    End Sub
    Public Sub BindSocial()


        Try

            Dim cmd As New SqlCommand("SELECT * from tblmstSocialMedia", ObjCon)
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                rptSocial.DataSource = ds
                rptSocial.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub BindCategories()


        Try

            Dim cmd As New SqlCommand("SELECT CourseId, CourseName from coursedetails where chkcourseoffered = 1 order by ordernumber", ObjCon)
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                rptrSubMeu.DataSource = ds
                rptrSubMeu.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindKD()
        Try

            Dim cmd As New SqlCommand("SELECT distinct subjecttype from knowledgecenter where checked = 1", ObjCon)
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                rptKd.DataSource = ds
                rptKd.DataBind()
            Else
                aKd.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class

