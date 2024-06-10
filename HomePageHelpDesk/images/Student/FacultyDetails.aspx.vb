Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Imports System.Data
Imports System.Data.SqlClient
Partial Class FacultyDetails
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddStudent
    Dim objDalSt As New DalAddStudent
    Dim objLibErr As New libErrorMsg

    Dim objLibStApp As New LibStudentAPP

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            End If
            If Not IsPostBack Then
                If Request.QueryString("fid") IsNot Nothing Then

                    filldata()
                End If
                If Request.QueryString("facultyid") IsNot Nothing Then

                    filldata1()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
   

  
  
    Sub filldata()
        Try
            Dim dsAppSt As New DataSet
            'dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,Degree,Discipline,courseId,approved,DocVerified from application where stid=" & Request.QueryString("id"))
            dsAppSt = CLS.fnQuerySelectDs("select f.email,f.FirstName,f.LastNAme,f.MiddleName,l.password,f.DOB,f.Address1,f.Address2,f.ContactNumber1,f.ContactNumber2,f.Gender,f.Nationality,f.Category,f.Profile from FacultyRegistration f INNER JOIN login l on f.email=l.username where f.email='" & Session("username") & "'")
            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            lblmail.Text = dsAppSt.Tables(0).Rows(0)("email").ToString
                            lblname.Text = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            'txtLastName.Text = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            'txtMiddleName.Text = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString
                            lblPaper.Text = Request.QueryString("PaperTitle")
                            lblProfile.Text = dsAppSt.Tables(0).Rows(0)("Profile").ToString
                            lblcourse.Text = Convert.ToString(Session("Course"))

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub filldata1()
        Try
            Dim dsAppSt As New DataSet
            'dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,Degree,Discipline,courseId,approved,DocVerified from application where stid=" & Request.QueryString("id"))
            dsAppSt = CLS.fnQuerySelectDs("select * from FacultyRegistration where Fid='" & Request.QueryString("facultyid") & "'")
            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            lblmail.Text = dsAppSt.Tables(0).Rows(0)("email").ToString
                            lblname.Text = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            'txtLastName.Text = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            'txtMiddleName.Text = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString
                            lblPaper.Text = Request.QueryString("PaperTitle")
                            lblProfile.Text = dsAppSt.Tables(0).Rows(0)("Profile").ToString
                            lblcourse.Text = Convert.ToString(Session("Course"))

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

  
    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        '  Response.Write("<script></script>")
        ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "self.close();", True)
    End Sub


End Class
