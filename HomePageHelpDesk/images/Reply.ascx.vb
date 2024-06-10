Imports Emoticons
Partial Class Reply
    Inherits System.Web.UI.UserControl
    Dim id As Integer
    Dim sid As Integer


    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdd.Click
    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click

        ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('hi wahid');</script>", True)


        Dim chkBool As Boolean

        Dim text As String = txtreply.Text
        text = Emoticon.Format(text)
        txtreply.Text = text

        chkBool = fnvaildate()
        If chkBool = True Then
            'Dim text As String = txtreply.Text
            'text = Emoticon.Format(text)
            'txtreply.Text = text
            id = Request.QueryString("id")
            If (Request.QueryString("sid") <> "") Then
                If (Request.QueryString("sid").Count > 0) Then
                    Dim strUpQ As String
                    strUpQ = "Update Subsubject set SubjectText='" & CLS.fnReplaceSpCH1(Trim(txtreply.Text)) & "' where subjectid=" & Request.QueryString("id") & " and SubSubjectid=" & Request.QueryString("sid")
                    CLS.fnExecuteQuery(strUpQ)
                    Response.Redirect("alltopic.aspx?id=" & Request.QueryString("id"))
                End If
            Else
                Dim strInsQ As String
                strInsQ = "INSERT INTO Subsubject(subjectid, SubjectText, dateofposting, email, Approve) VALUES (" & Request.QueryString("id") & ",'" & CLS.fnReplaceSpCH1(Trim(txtreply.Text)) & "','" & Date.Today.Date & "','" & Session("username") & "',0)"
                CLS.fnExecuteQuery(strInsQ)

                'Dim strInsQ As String
                'strInsQ = "INSERT INTO Subsubject(subjectid,SubjectText,dateofposting,email,Approve) VALUES (" & Request.QueryString("id") & ",'" & CLS.fnReplaceSpCH1(Trim(txtreply.Text)) & "','" & Date.Today.Date & "','" & Session("username") & "',0)"
                'CLS.fnExecuteQuery(strInsQ)


                Dim dsPost As New DataSet
                Dim tpost As Integer
                Dim strQ As String
                strQ = "select tpost from Maintopic where subjectid=" & id
                dsPost = CLS.fnQuerySelectDs(strQ)

                If dsPost IsNot Nothing Then
                    If dsPost.Tables IsNot Nothing Then
                        If dsPost.Tables(0).Rows IsNot Nothing Then
                            If dsPost.Tables(0).Rows.Count > 0 Then
                                tpost = dsPost.Tables(0).Rows(0)(0).ToString
                                Dim strUpQ As String
                                strUpQ = "Update maintopic set tpost=" & tpost + 1 & ",LastPost='" & CStr(Date.Now.Date) & "' where subjectid=" & id
                                CLS.fnExecuteQuery(strUpQ)
                                Response.Redirect("alltopic.aspx?id=" & id & "&o=1")
                            End If
                        End If
                    End If
                End If
            End If

        End If
    End Sub

    Function fnvaildate() As Boolean
        If Len(txtreply.Text) <= 0 Then
            lblMessage.Text = "Reply cannot be left blank"
            Return False
        End If

        Dim strsubject As String
        Dim dsSubject As New DataSet
        strsubject = "select * from subsubject where subjectid=" & Request.QueryString("id") & " and subjecttext like '" & CLS.fnReplaceSpCH(Trim(txtreply.Text)) & "' and email='" & Session("username") & "' and  dateofposting='" & Date.Today.Date & "'"
        dsSubject = CLS.fnQuerySelectDs(strsubject)
        If dsSubject.Tables(0).Rows.Count = 0 Then
        Else
            lblMessage.Text = "Reply already Exist"
            lblMessage.CssClass = "redcss"
            Return False
        End If
        Return True
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            id = Request.QueryString("id")
            sid = Request.QueryString("sid")
            fillHeading()
            If (Request.QueryString("sid") <> "") Then
                If (Request.QueryString("sid").Count > 0) Then
                    BindPostReplyByID()
                End If
            End If
        End If

    End Sub
    Sub fillHeading()
        Try
            Dim strq As String = "select  Title from maintopic where subjectID=" & Request.QueryString("id")
            Dim dsSubjectHeading As New DataSet()
            dsSubjectHeading = CLS.fnQuerySelectDs(strq)
            If dsSubjectHeading IsNot Nothing Then
                If dsSubjectHeading.Tables IsNot Nothing Then
                    If dsSubjectHeading.Tables(0).Rows IsNot Nothing Then
                        If dsSubjectHeading.Tables(0).Rows.Count > 0 Then
                            lblmainTopic.Text = dsSubjectHeading.Tables(0).Rows(0)("title").ToString
                        End If
                    End If
                End If
            End If




        Catch ex As Exception
        End Try
    End Sub

    Sub BindPostReplyByID()
        Try
            Dim strq As String = "select  SubjectText from subsubject where subjectID=" & Request.QueryString("id") & " and subsubjectid=" & Request.QueryString("sid")
            Dim dsSubject As New DataSet()
            dsSubject = CLS.fnQuerySelectDs(strq)
            If dsSubject IsNot Nothing Then
                If dsSubject.Tables IsNot Nothing Then
                    If dsSubject.Tables(0).Rows IsNot Nothing Then
                        If dsSubject.Tables(0).Rows.Count > 0 Then
                            txtreply.Text = dsSubject.Tables(0).Rows(0)("SubjectText").ToString
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
        End Try
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
