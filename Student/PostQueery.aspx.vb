Imports fmsf.DAL
Imports fmsf.lib
Imports System.Net.Mail
Imports System.Net
Partial Class Student_PostQueery
    Inherits System.Web.UI.Page
    Dim objLibQuery As New LIBQuery
    Dim objDalQuery As New DalAddQuery
    Dim objLibErr As New libErrorMsg

    Dim stid As Integer
    Dim FacultyEmail As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If Not IsPostBack Then
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        If dllList.SelectedItem.Text = "SELECT" Then
            dllFaculty.Enabled = False
        End If

        BindGrid()

        'End If
        Linkjs()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnvalidate()
            Dim chktomail As String
            If dllList.SelectedItem.Text = "Admin" Then
                chktomail = dllList.SelectedItem.Text
            ElseIf dllList.SelectedItem.Text = "Course Coordinator" Then
                chktomail = dllList.SelectedItem.Text
            Else
                chktomail = dllFaculty.SelectedItem.Text

            End If


            Dim mailBody As String = ""


            Dim m_strFromEmail As String = Session("username")
            Dim m_strFromName As String = ""
            Dim m_strToMail As String


            If objLibErr.ChkReturn = True Then
                GetStudentId()
                objLibQuery.stid = stid

                If dllList.SelectedItem.Text = "Admin" Then
                    objLibQuery.Fid = 0
                ElseIf dllList.SelectedItem.Text = "Course Coordinator" Then
                    objLibQuery.Fid = -1
                Else
                    objLibQuery.Fid = Trim(dllFaculty.SelectedValue.ToString)
                End If

                objLibQuery.Subject = Trim(txtSubject.Text)
                objLibQuery.Query = Trim(txtQuery.Text)
                objLibQuery.Status = 0

                Dim retVal As Int16 = objDalQuery.InsertQuery(objLibQuery)
                If retVal > 0 Then
                    Dim m_strToCC As String = ""
                    If dllList.SelectedItem.Text = "Admin" Or dllList.SelectedItem.Text = "Course Coordinator" Then
                        mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'> <tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Query From:</td><td valign='top'  bgcolor='#FFFFFF'  colspan='3'> " + Session("username") + " </td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Query For:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllList.SelectedItem.Text + " </td><td valign='top' bgcolor='#FFFFFF' width='15%'>Date: </td><td valign='top'  bgcolor='#FFFFFF' width='30%'> " + System.DateTime.Now.Date + " <br></td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Faculty: </td> <td valign='top'  width='30%' bgcolor='#FFFFFF'>&nbsp;</td> <td  valign='top' bgcolor='#FFFFFF' width='15%'>Subject: </td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtSubject.Text + "</td></tr><tr><td valign='top'  bgcolor='#FFFFFF'>Your Query <br></td><td valign='top'  bgcolor='#FFFFFF' colspan='3' style='height:150px;'>" + txtQuery.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy;  Copyright 2007, FMSF</div></td></tr></table></body></html>"

                        m_strToMail = "coordinator@fmsflearningsystems.org"
                        'SendMailMessage(m_strFromEmail, m_strToMail, m_strToCC, txtSubject.Text, mailBody)
                        SendMailMessage("fmsf@fmsflearningsystems.org", m_strToMail, m_strToCC, txtSubject.Text, mailBody)
                    Else
                        mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'> <tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Query From:</td><td valign='top'  bgcolor='#FFFFFF'  colspan='3'> " + Session("username") + " </td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Query For:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllList.SelectedItem.Text + " </td><td valign='top' bgcolor='#FFFFFF' width='15%'>Date: </td><td valign='top'  bgcolor='#FFFFFF' width='30%'> " + System.DateTime.Now.Date + " <br></td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Faculty: </td> <td valign='top'  width='30%' bgcolor='#FFFFFF'>" + chktomail + "</td> <td  valign='top' bgcolor='#FFFFFF' width='15%'>Subject: </td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtSubject.Text + "</td></tr><tr><td valign='top'  bgcolor='#FFFFFF'>Your Query <br></td><td valign='top'  bgcolor='#FFFFFF' colspan='3' style='height:150px;'>" + txtQuery.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy;  Copyright 2007, FMSF</div></td></tr></table></body></html>"

                        m_strToCC = "coordinator@fmsflearningsystems.org"
                        m_strToMail = ViewState("FacultyEmail")
                        SendMailMessage("fmsf@fmsflearningsystems.org", m_strToMail, m_strToCC, txtSubject.Text, mailBody)
                    End If

                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Query submitted successfully!');", True)


                End If

                BindGrid()
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try


        txtQuery.Text = ""
        txtSubject.Text = ""
        BindGrid()
    End Sub
    Private Sub FillDDl()
        'MyCLS.ConOpen()
        'MyCLS.prcFillDDL(dllFaculty, "FacultyRegistration", "Fid", "firstName")
        'MyCLS.ConClose()
        Dim strBatch As String = " select * from FacultyRegistration where  status=0"
        Dim dsbatch As New DataSet()
        dsbatch = CLS.fnQuerySelectDs(strBatch)
        dllFaculty.DataSource = dsbatch
        dllFaculty.DataTextField = "firstName"
        dllFaculty.DataValueField = "Fid"
        dllFaculty.DataBind()
        dllFaculty.Items.Insert(0, "--Select--")
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
    Sub BindGrid()

        Try
            'Dim strq As String = "select q.QueryId,q.stid,f.firstName,q.Subject,q.Query,q.Status from QuerySubmission q INNER JOIN FacultyRegistration f on q.Fid=f.Fid INNER JOIN student st on st.stid=q.stid where st.email='" & Session("username") & "' order by q.QueryId desc"
            Dim strq As String = "select q.Fid,q.QueryId,q.stid,f.email,f.firstName + ' ' + f.lastname as firstname,q.Subject,q.Query,q.Status from QuerySubmission q left outer JOIN FacultyRegistration f on q.Fid=f.Fid INNER JOIN student st on st.stid=q.stid where st.email='" & Session("username") & "' order by q.QueryId desc"






            Dim dsQuery As New DataSet()
            dsQuery = CLS.fnQuerySelectDs(strq)
            If dsQuery IsNot Nothing Then
                If dsQuery.Tables IsNot Nothing Then
                    If dsQuery.Tables(0).Rows IsNot Nothing Then
                        If dsQuery.Tables(0).Rows.Count > 0 Then
                            GrdQuery.DataSource = dsQuery
                            GrdQuery.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Function fnvalidate() As Object
        Dim ObjErrDal As New libErrorMsg
        If Len(Trim(txtSubject.Text)) <= 0 Then
            ObjErrDal.errMessage = "Subject cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(Trim(txtQuery.Text)) <= 0 Then
            ObjErrDal.errMessage = "Query cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If dllList.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select either admin or faculty"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If dllList.SelectedItem.Text = "Admin" Or dllList.SelectedItem.Text = "Course Coordinator" Then

        Else

            If dllFaculty.SelectedItem.Text = "SELECT" Then
                ObjErrDal.errMessage = "Please select faculty"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If
        End If



        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Private Sub GetStudentId()
        Dim strq As String = "select stid from student where email='" & Session("username") & "'"
        Dim dsStudent As New DataSet()
        dsStudent = CLS.fnQuerySelectDs(strq)
        stid = dsStudent.Tables(0).Rows(0)("stid").ToString()
    End Sub

    Protected Sub dllList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllList.SelectedIndexChanged


        If dllList.SelectedItem.Text = "Admin" Or dllList.SelectedItem.Text = "SELECT" Or dllList.SelectedItem.Text = "Course Coordinator" Then
            dllFaculty.Enabled = False
        Else
            dllFaculty.Enabled = True
            FillDDl()
        End If
    End Sub

    Sub Linkjs()
        If IsPostBack Then
            Dim lblQueryId As Label
            Dim linkBtn As LinkButton
            For Each cc1 As GridViewRow In GrdQuery.Rows
                lblQueryId = CType(cc1.FindControl("lblQueryId"), Label)
                linkBtn = CType(cc1.FindControl("lblStatus"), LinkButton)
                If linkBtn.Text = "Pending" Then
                    linkBtn.ForeColor = Drawing.Color.Red
                Else
                    linkBtn.ForeColor = Drawing.Color.Green
                End If
                linkBtn.Attributes.Add("onclick", "javascript:return openPopup('" + lblQueryId.Text + "');")

            Next
        End If
    End Sub



    Protected Sub GrdQuery_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdQuery.RowDataBound
        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            Dim lblQueryId As Label
            Dim lblFacId As Label
            Dim linkBtn As LinkButton
            Dim lblFid As Label
            lblQueryId = CType(row.FindControl("lblQueryId"), Label)
            lblFacId = CType(row.FindControl("lblFacID"), Label)
            lblFid = CType(row.FindControl("lblFid"), Label)
            linkBtn = CType(row.FindControl("lblStatus"), LinkButton)

            If lblFid.Text = "" Then
                If lblFacId.Text = "0" Then
                    lblFid.Text = "Admin"
                ElseIf lblFacId.Text = "-1" Then
                    lblFid.Text = "Course Coordinator"
                End If

            End If
                If linkBtn.Text = "Pending" Then
                    linkBtn.ForeColor = Drawing.Color.Red
                Else
                    linkBtn.ForeColor = Drawing.Color.Green
                End If
                linkBtn.Attributes.Add("onclick", "javascript:return openPopup('" + lblQueryId.Text + "');")


        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("StudentDashboard.aspx")
    End Sub

    Protected Sub GrdQuery_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdQuery.PageIndexChanging
        GrdQuery.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
  

    Protected Sub dllFaculty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllFaculty.SelectedIndexChanged
        Try
            Dim strq As String = "select *from facultyregistration where Fid=" & dllFaculty.SelectedValue & ""

            Dim dsName As New DataSet()
            dsName = CLS.fnQuerySelectDs(strq)
            If dsName IsNot Nothing Then
                If dsName.Tables IsNot Nothing Then
                    If dsName.Tables(0).Rows IsNot Nothing Then
                        If dsName.Tables(0).Rows.Count > 0 Then
                            ViewState("FacultyEmail") = dsName.Tables(0).Rows(0)("email").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal mailCC As String, ByVal subject As String, ByVal body As String)
        Try


            Dim mMailMessage As New MailMessage()
            mMailMessage.From = New MailAddress(from)
            mMailMessage.To.Add(New MailAddress(recepient))
            If (mailCC IsNot Nothing) AndAlso (mailCC <> String.Empty) Then

                mMailMessage.CC.Add(New MailAddress(mailCC))
            End If
            mMailMessage.Subject = subject
            mMailMessage.Body = body
            mMailMessage.IsBodyHtml = True
            mMailMessage.Priority = MailPriority.Normal
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            'Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net", 0)
            Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(from, "fmsf@123")
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception

        End Try
    End Sub

End Class
