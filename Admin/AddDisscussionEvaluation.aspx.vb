
Partial Class Admin_AddDisscussionEvaluation
    Inherits System.Web.UI.Page
    Dim dsStudent As New DataSet()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If



        If Not IsPostBack Then
            bindgrid()
            chkEnableDiasable()
        End If

    End Sub
    Sub bindgrid()
        Try

            'Dim strq As String = "select bt.stid,st.firstname +' '+ st.lastname as fullname ,st.email,bt.bid,ss.semid from studentregbatch bt INNER JOIN student st on bt.stid=st.stid INNER JOIN studentsemester ss on ss.stid=bt.stid and ss.courseid=bt.courseid  where ss.currentstatus=2  and bt.bid=" & Request.QueryString("bt").ToString & " and ss.semid=" & Request.QueryString("sid").ToString & ""

            Dim strq As String = "select distinct bt.stid,st.firstname +' '+ st.lastname as fullname ,st.email,bt.bid,mrk.Project,mrk.marks1,mrk.marks2 from studentregbatch bt INNER JOIN student st on bt.stid=st.stid INNER JOIN studentsemester ss on ss.stid=bt.stid and ss.courseid=bt.courseid LEFT OUTER JOIN StudentSemMarks mrk on mrk.bid=bt.bid and mrk.stid=bt.stid where ss.currentstatus=2  and bt.bid=" & Request.QueryString("bt").ToString

            dsStudent = CLS.fnQuerySelectDs(strq)
            If dsStudent IsNot Nothing Then
                If dsStudent.Tables IsNot Nothing Then
                    If dsStudent.Tables(0).Rows IsNot Nothing Then
                        If dsStudent.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsStudent
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub chkEnableDiasable()

        Dim txtProject As TextBox
        Dim txtMar1 As TextBox
        Dim txtMar2 As TextBox

        For Each cc1 As GridViewRow In GrdStudent.Rows

            txtProject = DirectCast(cc1.FindControl("txtProMarks"), TextBox)
            txtMar1 = DirectCast(cc1.FindControl("txtMarks1"), TextBox)
            txtMar2 = DirectCast(cc1.FindControl("txtMarks2"), TextBox)

           

            If Request.QueryString("pro") = 2 Then
                lblHeading.Text = "Project Marks"
                GrdStudent.Columns(5).Visible = False
                GrdStudent.Columns(6).Visible = False

            ElseIf Request.QueryString("mrk1") = 1 Then
                lblHeading.Text = "Marks 1"
                GrdStudent.Columns(4).Visible = False
                GrdStudent.Columns(6).Visible = False


            ElseIf Request.QueryString("mrk2") = 2 Then
                lblHeading.Text = "Marks 2"
                GrdStudent.Columns(4).Visible = False
                GrdStudent.Columns(5).Visible = False


            End If
        Next
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '   Dim sid As Integer = Request.QueryString("sid")
        Dim str As String

        Dim txtDisscussion As TextBox
        Dim txtProject As TextBox
        Dim txtMarks1 As TextBox
        Dim txtMarks2 As TextBox

        Dim lblstid As Label
        Dim lblbid As Label
        Dim lblcourseid As Label


        For Each cc1 As GridViewRow In GrdStudent.Rows

            txtProject = DirectCast(cc1.FindControl("txtProMarks"), TextBox)
            txtMarks1 = DirectCast(cc1.FindControl("txtMarks1"), TextBox)
            txtMarks2 = DirectCast(cc1.FindControl("txtMarks2"), TextBox)

            lblstid = DirectCast(cc1.FindControl("lblstid"), Label)
            lblbid = DirectCast(cc1.FindControl("lblbid"), Label)
            lblcourseid = DirectCast(cc1.FindControl("lblcourseid"), Label)

            Dim strq As String = "select *from StudentSemMarks where stid=" & lblstid.Text & "  and  bid=" & lblbid.Text & ""
            Dim dsmarks As New DataSet()
            dsmarks = CLS.fnQuerySelectDs(strq)





            If Request.QueryString("pro") = 2 Then
                If Len(txtProject.Text) > 0 Then
                    If dsmarks IsNot Nothing Then
                        If dsmarks.Tables IsNot Nothing Then

                            If dsmarks.Tables(0).Rows IsNot Nothing Then
                                If dsmarks.Tables(0).Rows.Count > 0 Then
                                    str = "update StudentSemMarks set stid=" & lblstid.Text & ",bid=" & lblbid.Text & ",project='" & txtProject.Text & "' where stid=" & lblstid.Text & "  and  bid=" & lblbid.Text & " "
                                Else
                                    str = "insert into StudentSemMarks(stid,bid,project)values( " & lblstid.Text & " ," & lblbid.Text & ",'" & txtProject.Text & "')"
                                End If
                                CLS.fnExecuteQuery(str)
                                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Project Marks  Saved Successfully!');  location.href='SelectExamSet.aspx' ;", True)
                            End If
                        End If
                    End If
                End If

            ElseIf Request.QueryString("mrk1") = 1 Then
                If Len(txtMarks1.Text) > 0 Then
                    If dsmarks IsNot Nothing Then
                        If dsmarks.Tables IsNot Nothing Then

                            If dsmarks.Tables(0).Rows IsNot Nothing Then
                                If dsmarks.Tables(0).Rows.Count > 0 Then
                                    str = "update StudentSemMarks set stid=" & lblstid.Text & ",bid=" & lblbid.Text & ",marks1='" & txtMarks1.Text & "' where stid=" & lblstid.Text & " and  bid=" & lblbid.Text & " "
                                Else
                                    str = "insert into StudentSemMarks(stid,bid,marks1)values( " & lblstid.Text & " , " & lblbid.Text & ",'" & txtMarks1.Text & "')"
                                End If
                                CLS.fnExecuteQuery(str)
                                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Marks 1  Saved Successfully!');  location.href='SelectExamSet.aspx' ;", True)
                            End If
                        End If
                    End If
                End If

            ElseIf Request.QueryString("mrk2") = 2 Then
                If Len(txtMarks2.Text) > 0 Then
                    If dsmarks IsNot Nothing Then
                        If dsmarks.Tables IsNot Nothing Then

                            If dsmarks.Tables(0).Rows IsNot Nothing Then
                                If dsmarks.Tables(0).Rows.Count > 0 Then
                                    str = "update StudentSemMarks set stid=" & lblstid.Text & ",bid=" & lblbid.Text & ",marks2='" & txtMarks2.Text & "' where stid=" & lblstid.Text & " and bid=" & lblbid.Text & " "
                                Else
                                    str = "insert into StudentSemMarks(stid,bid,marks2)values( " & lblstid.Text & "," & lblbid.Text & ",'" & txtMarks2.Text & "')"
                                End If
                                CLS.fnExecuteQuery(str)
                                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Marks 2  Saved Successfully!');  location.href='SelectExamSet.aspx' ;", True)
                            End If
                        End If
                    End If
                End If
            End If

        Next
        Response.Redirect("SelectExamSet.aspx?cid=" + Request.QueryString("cid") + "&bt=" + Request.QueryString("bt") + "&sid=" + Request.QueryString("sid") + "&pid=" + Request.QueryString("pid") + "&mid=" + Request.QueryString("mid") + "&back=2")
    End Sub

    Protected Sub GrdStudent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdStudent.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        If row.DataItem Is Nothing Then
            Exit Sub
        End If

        Dim txtProject As TextBox
        Dim txtMarks1 As TextBox
        Dim txtMarks2 As TextBox


        txtProject = DirectCast(row.FindControl("txtProMarks"), TextBox)
        txtMarks1 = DirectCast(row.FindControl("txtMarks1"), TextBox)
        txtMarks2 = DirectCast(row.FindControl("txtMarks2"), TextBox)
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim Redirecturl As String = "SelectExamSet.aspx?cid=" + Request.QueryString("cid") + "&bt=" + Request.QueryString("bt") + "&sid=" + Request.QueryString("sid") + "&pid=" + Request.QueryString("pid") + "&mid=" + Request.QueryString("mid") + "&back=2"
        Response.Redirect(Redirecturl)
        'Response.Redirect("SelectExamSet.aspx")
    End Sub

    Protected Sub GrdStudent_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdStudent.PageIndexChanging
        GrdStudent.PageIndex = e.NewPageIndex
        bindgrid()
        chkEnableDiasable()
    End Sub
End Class
