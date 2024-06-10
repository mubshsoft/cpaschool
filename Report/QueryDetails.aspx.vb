Imports fmsf.DAL
Imports fmsf.lib
Partial Class Report_QueryDetails
    Inherits System.Web.UI.Page
    Dim objLibQuery As New LIBQuery
    Dim objDalQuery As New DalAddQuery
    Dim objLibErr As New libErrorMsg
    Dim iFid As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")

        End If
        If Request.QueryString("lstquerydetails") IsNot Nothing Then
            If Not IsPostBack Then
                lblReplyDate.Enabled = True
                lblQueryReply.Enabled = False

               

                'btnSave visible only when relydate is not present
                Dim queryval1 As Integer
                If Request.QueryString("lstquerydetails") IsNot Nothing Then
                    queryval1 = Request.QueryString("lstquerydetails")

                Else
                    If Request.QueryString("fid") IsNot Nothing Then
                        queryval1 = Request.QueryString("fid")
                    End If

                End If



                Dim strq As String = "select ReplyDate,fid from QuerySubmission where QueryId=" & queryval1 & ""
                Dim dsQuery As New DataSet()
                dsQuery = CLS.fnQuerySelectDs(strq)
                If dsQuery IsNot Nothing Then
                    If dsQuery.Tables IsNot Nothing Then
                        If dsQuery.Tables(0).Rows IsNot Nothing Then
                            If dsQuery.Tables(0).Rows.Count > 0 Then
                                If dsQuery.Tables(0).Rows(0)("replydate").ToString = "" Then

                                Else

                                End If
                            End If
                        End If
                    End If
                End If

                'If admin display data
                If dsQuery IsNot Nothing Then
                    If dsQuery.Tables IsNot Nothing Then
                        If dsQuery.Tables(0).Rows IsNot Nothing Then
                            If dsQuery.Tables(0).Rows.Count > 0 Then
                                iFid = dsQuery.Tables(0).Rows(0)("Fid").ToString
                            End If
                        End If
                    End If
                End If

            End If



        End If

        If Not IsPostBack Then
            BindGrid()
            If Len(Trim(lblQueryReply.Text)) > 0 Then
                ' lblQueryReply.Enabled = True
            End If
            If Len(lblReplyDate.Text) > 0 Then
                lblReplyDate.Enabled = False
            End If
        End If
        'If Request.QueryString("lstquerydetails") IsNot Nothing Then
        '    If lblQueryReply.Text = "" Then
        '        btnSave.Visible = True
        '    Else
        '        btnSave.Visible = False
        '    End If
        'End If
        If lblQueryStatus.Text = "Pending" Then
            lblQueryStatus.ForeColor = Drawing.Color.Red
        Else
            lblQueryStatus.ForeColor = Drawing.Color.Green
        End If

    End Sub

    Sub BindGrid()
        Dim queryval As Integer
        If Request.QueryString("lstquerydetails") IsNot Nothing Then
            queryval = Request.QueryString("lstquerydetails")

        Else
            If Request.QueryString("fid") IsNot Nothing Then
                queryval = Request.QueryString("fid")
            End If

        End If


        Try
            Dim status As Boolean
            Dim strq As String
            If iFid <> 0 Then
                strq = "select q.QueryId,q.stid,f.firstName,q.Subject,q.Query,q.Status,q.QueryDate,q.ReplyDate,q.Reply from QuerySubmission q INNER JOIN FacultyRegistration f on q.Fid=f.Fid where q.QueryId=" & queryval & ""
            Else
                strq = "select QueryId,stid,Subject,Query,Status,QueryDate,ReplyDate,Reply from QuerySubmission where QueryId=" & queryval & ""
            End If

            Dim dsQuery As New DataSet()
            dsQuery = CLS.fnQuerySelectDs(strq)
            If dsQuery IsNot Nothing Then
                If dsQuery.Tables IsNot Nothing Then
                    If dsQuery.Tables(0).Rows IsNot Nothing Then
                        If dsQuery.Tables(0).Rows.Count > 0 Then
                            lblQueryDate.Text = dsQuery.Tables(0).Rows(0)("QueryDate").ToString()

                            If iFid <> 0 Then
                                lblQueryFor.Text = dsQuery.Tables(0).Rows(0)("firstName").ToString()
                            Else
                                lblQueryFor.Text = "Admin"
                            End If

                            lblQuerySubject.Text = dsQuery.Tables(0).Rows(0)("Subject").ToString()
                            lblYourQuery.Text = dsQuery.Tables(0).Rows(0)("Query").ToString()
                            'lblReplyDate.Text = dsQuery.Tables(0).Rows(0)("ReplyDate").ToString()
                            lblReplyDate.Text = System.DateTime.Now.Date
                            lblQueryReply.Text = dsQuery.Tables(0).Rows(0)("Reply").ToString()
                            status = Convert.ToBoolean(dsQuery.Tables(0).Rows(0)("Status").ToString())

                            Dim a As String = ReplaceStatus(status)
                            lblQueryStatus.Text = a
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub


    Function ReplaceStatus(ByVal val As Boolean) As String
        Dim value As String
        If val = False Then
            value = "Pending"
        Else
            value = "Replied"
        End If
        ReplaceStatus = value
    End Function

    Public Function fnvalidate() As Object
        Dim ObjErrDal As New libErrorMsg
        If Len(Trim(lblQueryReply.Text)) <= 0 Then
            ObjErrDal.errMessage = "Reply cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(lblReplyDate.Text) > 0 Then
            Dim d As DateTime
            Try
                d = DateTime.Parse(lblReplyDate.Text)
            Catch ex As Exception
                ObjErrDal.errMessage = "Invalid date!format should be mm/dd/yyyy"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End Try
        Else
            ObjErrDal.errMessage = "Reply date cannot be left blank"
        End If


        If Len(lblReplyDate.Text) > 0 Then
            Dim d As Date
            Try
                d = lblReplyDate.Text
                If d <> Date.Now.Date Then
                    ObjErrDal.errMessage = "Reply Date should be current date."
                    lblMessage.ForeColor = Drawing.Color.DarkRed
                    ObjErrDal.ChkReturn = False
                    Return ObjErrDal
                End If
            Catch ex As Exception
            End Try
        End If

        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
    '    Try
    '        objLibErr = fnvalidate()
    '        If objLibErr.ChkReturn = True Then
    '            If Request.QueryString("lstquerydetails") IsNot Nothing Then

    '                Dim strUpdate As String = "update QuerySubmission set Reply='" & lblQueryReply.Text & "',ReplyDate='" & System.DateTime.Now.Date & "',Status=1  where QueryId=" & Request.QueryString("lstquerydetails")
    '                CLS.fnExecuteQuery(strUpdate)
    '                Response.Write("<script>self.close();</script>")

    '            End If
    '        Else
    '            lblMessage.Text = objLibErr.errMessage
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Write("<script>self.close();</script>")
    End Sub

End Class
