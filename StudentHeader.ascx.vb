Imports System.Data.SqlClient

Partial Class StudentHeader
    Inherits System.Web.UI.UserControl
    Public fid As String = ""
    Public sid As String = ""
    Public loginfrom As String = ""
    Public loginDate As String = ""
    Public Role As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCategories()
            hdnFid.Value = Session("fid")
            hdnSid.Value = Session("stid")
            hdnLoginFrom.Value = Session("IPADD")
            hdnLoginDate.Value = Session("datetim")
            hdnRole.Value = Session("role")
        End If
    End Sub
    Public Sub BindCategories()


        Try
            Dim strConnectionString As String = ""
            strConnectionString = ConfigurationManager.ConnectionStrings("fmsfConnectionString2").ToString()
            Dim ObjCon As New SqlConnection(strConnectionString)
            ObjCon.Open()
            Dim dt As New DataTable()
            Dim Objdacat As New SqlDataAdapter("select categoryid,categoryname,url from category", ObjCon)
            'Dim Objdasubcat As New SqlDataAdapter("select subcategoryid,subcategoryname,categoryid,CourseId from subcategory", ObjCon)
            Dim Objdasubcat As New SqlDataAdapter("select cs.Courseid,sb.SubCategoryID,sb.SubCategoryName,sb.CategoryID,cs.CourseName from coursedetails cs INNER JOIN subcategory sb on sb.Courseid=cs.Courseid where cs.ChkCourseOffered=1", ObjCon)
            Dim dss As New DataSet()
            Objdacat.Fill(dss, "category")
            Objdasubcat.Fill(dss, "subcategory")
            dss.Relations.Add("Children", dss.Tables("category").Columns("CategoryID"), dss.Tables("subcategory").Columns("CategoryID"))

            For Each masterRow As DataRow In dss.Tables("category").Rows


                Dim masterItem As New MenuItem(DirectCast(masterRow("CategoryName"), String), "", "", ("~/" + masterRow("url") + ".aspx"))

                Menu1.Items.Add(masterItem)

                For Each childRow As DataRow In masterRow.GetChildRows("Children")
                    Dim childItem As New MenuItem(DirectCast(childRow("subcategoryname"), String), "", "", ("~/CourseDetailsInfo.aspx?CID=" & Convert.ToInt32(childRow("CourseId"))))

                    masterItem.ChildItems.Add(childItem)
                Next




            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        Try
            Dim strLogin As String
            If hdnRole.Value = "Faculty" Then
                strLogin = "update FacultyLoginHistory set loginout='" & System.DateTime.Now & "' where fid=" & hdnFid.Value & " and loginfrom='" & hdnLoginFrom.Value & "' and logindate='" & hdnLoginDate.Value & "'"
            ElseIf hdnRole.Value = "Student" Then
                strLogin = "update studentLoginHistory set loginout='" & System.DateTime.Now & "' where stid=" & hdnSid.Value & " and loginfrom='" & hdnLoginFrom.Value & "' and logindate='" & hdnLoginDate.Value & "'"
            End If
            CLS.fnExecuteQuery(strLogin)
        Catch ex As Exception
        End Try
    End Sub
End Class
