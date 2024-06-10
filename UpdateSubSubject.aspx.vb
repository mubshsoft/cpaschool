Imports Emoticons
Partial Class UpdateSubSubject
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("login.aspx")
        End If
        If Not IsPostBack Then
            FillControl()
        End If

    End Sub

    Sub FillControl()
        Try

            Dim strq As String = "select  SubjectText from subSubject where subjectID=" & Request.QueryString("tid") & " and SubsubjectID=" & Request.QueryString("sid") & " and email='" & Request.QueryString("email") & "'"

            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then


                            txtreply.Text = CLS.fnGetDataFromSpCH1(Trim(dsTopic.Tables(0).Rows(0)(0).ToString))

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, e As System.EventArgs) Handles btnAdd.Click
        'If Len(txtreply.Text) <= 0 Then
        '    lblMessage.Text = "Reply cannot be left blank"
        '    Exit Sub

        Dim strupdQ As String
        strupdQ = "update Subsubject set SubjectText='" & CLS.fnReplaceSpCH1(Trim(txtreply.Text)) & "' where subjectID=" & Request.QueryString("tid") & " and SubsubjectID=" & Request.QueryString("sid") & " and email='" & Request.QueryString("email") & "' "
        'strupdQ = "update Subsubject set SubjectText='" & Trim(txtreply.Text) & "' where subjectID=" & Request.QueryString("tid") & " and SubsubjectID=" & Request.QueryString("sid") & " and email='" & Session("username") & "' "
        CLS.fnExecuteQuery(strupdQ)
        'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Update successfully!'); location.href='StudentPanel.aspx.aspx' ;</script>")
        Response.Redirect("EditReplies.aspx?id=" & Request.QueryString("tid"))
        'End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("EditReplies.aspx?id=" & Request.QueryString("tid"))

    End Sub

    Protected Sub img1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img1.Click
        Dim text As String
        text = Emoticon.Format("(A)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot


    End Sub

    Protected Sub img2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img2.Click
        Dim text As String
        text = Emoticon.Format(":-@")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img3.Click
        Dim text As String
        text = Emoticon.Format("(biggrin)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img4.Click
        Dim text As String
        text = Emoticon.Format("(&)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot

    End Sub



    Protected Sub img7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img7.Click
        Dim text As String
        text = Emoticon.Format(":-S")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub



    Protected Sub img9_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img9.Click
        Dim text As String
        text = Emoticon.Format(":'(")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img10_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img10.Click
        Dim text As String
        text = Emoticon.Format("(6)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img12_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img12.Click
        Dim text As String
        text = Emoticon.Format(":$")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img17_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img17.Click
        Dim text As String
        text = Emoticon.Format(":-)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img19_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img19.Click
        Dim text As String
        text = Emoticon.Format(":-)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img20_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img20.Click
        Dim text As String
        text = Emoticon.Format("(H)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img23_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img23.Click
        Dim text As String
        text = Emoticon.Format(":-D")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img25_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img25.Click
        Dim text As String
        text = Emoticon.Format(":-P")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img26_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img26.Click
        Dim text As String
        text = Emoticon.Format(":-|")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img28_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img28.Click
        Dim text As String
        text = Emoticon.Format(";-)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub
End Class
