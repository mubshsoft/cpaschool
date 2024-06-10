Imports System.Data.SqlClient
Partial Class HomeMaster
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
        End If
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
    Public Sub BindCategories()


        Try
            'Dim strConnectionString As String = ""
            'strConnectionString = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
            'Dim ObjCon As New SqlConnection(strConnectionString)
            'ObjCon.Open()


            Dim cmd As New SqlCommand("SELECT CourseId, CourseName from coursedetails where chkcourseoffered = 1", ObjCon)
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                rptrSubMeu.DataSource = ds
                rptrSubMeu.DataBind()
            End If


            'Dim dt As New DataTable()
            'Dim Objdacat As New SqlDataAdapter("select categoryid,categoryname,url from category", ObjCon)
            'Dim Objdasubcat As New SqlDataAdapter("select subcategoryid,subcategoryname,categoryid,CourseId from subcategory", ObjCon)

            'Dim dss As New DataSet()
            'Objdacat.Fill(dss, "category")
            'Objdasubcat.Fill(dss, "subcategory")
            'dss.Relations.Add("Children", dss.Tables("category").Columns("CategoryID"), dss.Tables("subcategory").Columns("CategoryID"))

            'For Each masterRow As DataRow In dss.Tables("category").Rows


            '    Dim masterItem As New MenuItem(DirectCast(masterRow("CategoryName"), String), "", "", ("~/" + masterRow("url") + ".aspx"))

            '    Menu1.Items.Add(masterItem)

            '    For Each childRow As DataRow In masterRow.GetChildRows("Children")
            '        Dim childItem As New MenuItem(DirectCast(childRow("subcategoryname"), String), "", "", ("~/CourseDetailsInfo.aspx?CID=" & Convert.ToInt32(childRow("CourseId"))))

            '        masterItem.ChildItems.Add(childItem)
            '    Next




            'Next
        Catch ex As Exception

        End Try
    End Sub

End Class

