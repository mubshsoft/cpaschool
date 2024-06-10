
Partial Class Admin_ListFaculty
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        bindgrid()
    End Sub
    Sub bindgrid()
        Try
            Dim strq As String = "select ROW_NUMBER() OVER(ORDER BY fid asc) AS ROWID,Fid,email,firstName,lastname,(firstName + ' ' + lastname) as FullName from FacultyRegistration"
            Dim dsFaculty As New DataSet()
            dsFaculty = CLS.fnQuerySelectDs(strq)
            If dsFaculty IsNot Nothing Then
                If dsFaculty.Tables IsNot Nothing Then
                    If dsFaculty.Tables(0).Rows IsNot Nothing Then
                        If dsFaculty.Tables(0).Rows.Count > 0 Then
                            GrdFaculty.DataSource = dsFaculty
                            GrdFaculty.DataBind()
                            GrdFaculty.Visible = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

  
    Protected Sub GrdFaculty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdFaculty.PageIndexChanging
        GrdFaculty.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Sub FillSubjectGrid(ByVal fid As Integer)
        Dim StrFacSub As String
        StrFacSub = "select fr.firstname +  ' ' + fr.lastname as fullname,f.FacId,c.CourseTitle,p.papertitle,f.fid from facultyassign f inner join  paper p " & _
                    "on f.paperid=p.paperid  inner join  course c on f.courseid=c.courseid" & _
                    "  inner join  FacultyRegistration fr on f.fid=fr.fid" & _
                    " where f.fid=" & fid
        Dim dsSub As New DataSet
        dsSub = CLS.fnQuerySelectDs(StrFacSub)
        If dsSub IsNot Nothing Then
            If dsSub.Tables IsNot Nothing Then
                If dsSub.Tables(0).Rows IsNot Nothing Then
                    If dsSub.Tables(0).Rows.Count > 0 Then
                        GrdFacultySub.DataSource = dsSub
                        GrdFacultySub.DataBind()
                        GrdFacultySub.Visible = True
                        lblCap.Text = "List of assigned course" & "-" & dsSub.Tables(0).Rows(0)("Fullname").ToString
                        lblCap.Visible = True
                    Else
                        lblCap.Text = "No Course Assigned"
                        lblCap.Visible = True
                        GrdFacultySub.Visible = False
                    End If
                End If
            End If
        End If


    End Sub

    Protected Sub GrdFaculty_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdFaculty.RowCommand
        If e.CommandName = "List" Then
            Dim iFid As Integer
            iFid = CInt(e.CommandArgument)
            FillSubjectGrid(iFid)

        End If
    End Sub

    Protected Sub btnAddFaculty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddFaculty.Click
        Response.Redirect("FacultyRegistration.aspx")
    End Sub
End Class
