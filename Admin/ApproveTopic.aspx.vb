
Partial Class Admin_ApproveTopic
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

        If Not IsPostBack Then
            ID = Request.QueryString("id")
            ViewState("id") = ID
            bindgrid()

        End If
    End Sub

    Sub bindgrid()
        Try
            Dim strq As String = "select  subsubjectid,subjectid,subjecttext,CONVERT(varchar, dateofposting, 101) as dateofposting,email,approve from subSubject where subjectID=" & Request.QueryString("id") & " order by subsubjectid desc"
            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            GrdTopic.DataSource = dsTopic
                            GrdTopic.DataBind()
                            grdTopic.Visible = True
                            lblNoTopic.Visible = False
                        Else
                            'lblMessage.Text = "No topic exist"
                            grdTopic.Visible = False
                            lblNoTopic.Visible = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Try
            ' Dim strUpdateQOld As String
            'strUpdateQOld = "update SubSubject set approve=0 where Subjectid=" & ViewState("id")
            'CLS.fnExecuteQuery(strUpdateQOld)
            Dim chkBox As Boolean
            chkBox = False
            Dim strUpdateQ As String
            For Each gv As GridViewRow In grdTopic.Rows
                Dim deleteChkBxItem As CheckBox = DirectCast(gv.FindControl("deleteRec"), CheckBox)
                If deleteChkBxItem.Checked Then
                    chkBox = True
                    Dim lblSubjectId As Label = DirectCast(gv.FindControl("lblSubSubjectID"), Label)
                    strUpdateQ = "update SubSubject set approve=1 where subSubjectid=" & lblSubjectId.Text
                    CLS.fnExecuteQuery(strUpdateQ)
                Else
                    Dim lblSubjectId As Label = DirectCast(gv.FindControl("lblSubSubjectID"), Label)
                    strUpdateQ = "update SubSubject set approve=0 where subSubjectid=" & lblSubjectId.Text
                    CLS.fnExecuteQuery(strUpdateQ)
                End If
            Next
            Response.Redirect("ListTopic.aspx")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdTopic_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTopic.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        ' Make sure we aren't in header/footer rows 
        If row.DataItem Is Nothing Then
            Exit Sub
        End If

        Dim deleteChkBxItem As CheckBox
        deleteChkBxItem = DirectCast(row.FindControl("deleteRec"), CheckBox)


        Dim gv As New HiddenField
        gv = DirectCast(row.FindControl("hdnApStatus"), HiddenField)
        If (gv.Value = True) Then
            deleteChkBxItem.Checked = True
        Else
            deleteChkBxItem.Checked = False
        End If


        'Dim lblDatePost As New Label
        'lblDatePost = DirectCast(row.FindControl("lblDateOfPosting"), Label)


    End Sub

    Protected Sub grdTopic_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdTopic.PageIndex = e.NewPageIndex
        'If (ViewState("chk") = 1) Then
        ' bindgrid1()
        'Else
        bindgrid()
        'End If
    End Sub
End Class
