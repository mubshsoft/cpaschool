Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Partial Class Admin_AssignFaculty
    Inherits System.Web.UI.Page
    Dim objLibErr As New libErrorMsg

    Dim facultyid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            Else
                If Session("role") = "Admin" Then
                Else
                    Response.Redirect("../login.aspx")
                End If
            End If
            If Not IsPostBack Then
                MyCLS.ConOpen()
                FucultyName()
                FillCourse()
                FillSubjectGrid()
                If Request.QueryString("facultyid") IsNot Nothing Then
                    facultyid = Request.QueryString("facultyid")
                End If
                MyCLS.ConClose()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillCourse()
        MyCLS.prcFillDDL(dllCourse, "Course", "CourseID", "CourseCode")
    End Sub

    Private Sub FillSemester()
        Dim strq As String = "select SemID,SemesterTitle from semester where courseid=" & dllCourse.SelectedValue
        Dim dsSemester As New DataSet()
        dsSemester = CLS.fnQuerySelectDs(strq)
        If (dsSemester.Tables(0).Rows.Count > 0) Then

            dllSemester.DataTextField = "SemesterTitle"
            dllSemester.DataValueField = "SemID"

            dllSemester.DataSource = dsSemester
            dllSemester.Items.Add("SELECT")
            dllSemester.DataBind()
        Else
            lblMessage.Text = "No Record found"
        End If
        
    End Sub
    Private Sub FillModule()
        Dim strq As String = "select ModuleID,ModuleTitle from Module where SemID=" & dllSemester.SelectedValue
        Dim dsModule As New DataSet()
        dsModule = CLS.fnQuerySelectDs(strq)
        If (dsModule.Tables(0).Rows.Count > 0) Then
            dllModule.DataTextField = "ModuleTitle"
            dllModule.DataValueField = "ModuleID"
            dllModule.DataSource = dsModule
            dllModule.DataBind()
        Else
            lblMessage.Text = "No Record found"
        End If

    End Sub
    Private Sub FillPaper()
        Dim strq As String = "select PaperID,PaperTitle from Paper where ModuleID=" & dllModule.SelectedValue
        Dim dsPaper As New DataSet()
        dsPaper = CLS.fnQuerySelectDs(strq)
        If (dsPaper.Tables(0).Rows.Count > 0) Then
            dllPaper.DataTextField = "PaperTitle"
            dllPaper.DataValueField = "PaperID"
            dllPaper.DataSource = dsPaper
            dllPaper.DataBind()
        Else
            lblMessage.Text = "No Record found"
        End If

    End Sub
    Private Sub FillDDlSem()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(dllSemester, "Semester", "SemID", "SemesterTitle", "courseid", dllCourse.SelectedValue)
        MyCLS.ConClose()
    End Sub
    Private Sub FillDDlModule()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(dllModule, "Module", "ModuleID", "ModuleTitle", "SemID", dllSemester.SelectedValue)
        MyCLS.ConClose()
    End Sub
    Private Sub FillDDlPaper()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(dllPaper, "paper", "PaperID", "PaperTitle", "ModuleID", dllModule.SelectedValue)
        MyCLS.ConClose()
    End Sub

    Protected Sub dllCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllCourse.SelectedIndexChanged
        'FillSemester()
        FillDDlSem()
    End Sub

    Protected Sub dllSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllSemester.SelectedIndexChanged
        'FillModule()
        FillDDlModule()
    End Sub

    Protected Sub dllModule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllModule.SelectedIndexChanged
        'FillPaper()
        FillDDlPaper()
    End Sub
    Sub FucultyName()
        Dim strq As String = "select * from FacultyRegistration where Fid=" & Request.QueryString("facultyid") & " "
        Dim dsFac As New DataSet()
        dsFac = CLS.fnQuerySelectDs(strq)
        txtName.Text = dsFac.Tables(0).Rows(0)("firstName").ToString() & " " & dsFac.Tables(0).Rows(0)("middleName").ToString()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnValidate()
            If objLibErr.ChkReturn = True Then

                If Request.QueryString("facultyid") IsNot Nothing Then
                    Dim strq As String = "select * from facultyassign where FID=" & Request.QueryString("facultyid") & " and courseid=" & dllCourse.SelectedValue & " and  SemID=" & dllSemester.SelectedValue.ToString() & " and ModuleID=" & dllModule.SelectedValue.ToString() & " and paperID=" & dllPaper.SelectedValue.ToString() & ""
                    Dim ds As New DataSet()
                    ds = CLS.fnQuerySelectDs(strq)
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblMessage.Text = "Faculty already assigned to this paper."
                    Else
                        Dim str As String = "insert into FacultyAssign(Fid,CourseID,SemID,ModuleID,paperID)values(" & Request.QueryString("facultyid") & ", " & dllCourse.SelectedValue.ToString() & " , " & dllSemester.SelectedValue.ToString() & " , " & dllModule.SelectedValue.ToString() & " ," & dllPaper.SelectedValue.ToString() & ")"
                        CLS.fnExecuteQuery(str)

                        ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Faculty Assign successfully!');", True)
                        'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Faculty Assign successfully!'); location.href='FacultySelect.aspx' ;</script>")

                        txtName.Text = ""
                        dllCourse.SelectedIndex = 0
                        dllModule.SelectedIndex = 0
                        dllPaper.SelectedIndex = 0
                        dllSemester.SelectedIndex = 0
                        FillSubjectGrid()
                    End If

                Else
                    lblMessage.Text = "Faculty Id not found"
                End If
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function fnValidate() As Object
        Dim ObjErrDal As New libErrorMsg

        If Trim(dllCourse.SelectedItem.Text) = "SELECT" Then
            ObjErrDal.errMessage = "Select Course"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Trim(dllSemester.SelectedItem.Text) = "SELECT" Then
            ObjErrDal.errMessage = "Select Semester"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Trim(dllModule.SelectedItem.Text) = "SELECT" Then
            ObjErrDal.errMessage = "Select Module"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Trim(dllPaper.SelectedItem.Text) = "SELECT" Then
            ObjErrDal.errMessage = "Select Paper"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

       
       
        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ListFaculty.aspx")
    End Sub

    Sub FillSubjectGrid()
        Dim StrFacSub As String
        StrFacSub = "select f.FacId,c.CourseTitle,p.papertitle,f.fid from facultyassign f inner join  paper p " & _
                    "on f.paperid=p.paperid  inner join  course c on f.courseid=c.courseid" & _
                    " where fid=" & Request.QueryString("facultyid")
        Dim dsSub As New DataSet
        dsSub = CLS.fnQuerySelectDs(StrFacSub)
        If dsSub IsNot Nothing Then
            If dsSub.Tables IsNot Nothing Then
                If dsSub.Tables(0).Rows IsNot Nothing Then
                    If dsSub.Tables(0).Rows.Count > 0 Then
                        GrdFacultySub.DataSource = dsSub
                        GrdFacultySub.DataBind()
                    End If
                End If
            End If
        End If


    End Sub

    Protected Sub GrdFacultySub_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdFacultySub.RowCommand
        Try
            If e.CommandName = "Delete" Then
                Dim id As Integer = Convert.ToInt32(e.CommandArgument)

                Dim str As String = "delete from facultyassign where FacId=" & id
                ExeNQcomsp(str)
                FillSubjectGrid()
                lblMessage.Text = "Record deleted successfully"
                lblMessage.ForeColor = Drawing.Color.DarkGreen

               
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdFacultySub_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdFacultySub.RowDeleting

    End Sub
    Public Shared Sub ExeNQcomsp(ByVal strQ As String)
      
        Try
            CLS.ConOpen()
            CLS.fnExecuteQuery(strQ)
            CLS.ConClose()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
