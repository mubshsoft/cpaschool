Imports fmsf.DAL
Imports fmsf.lib
Imports Emoticons
Partial Class Admin_AddTopic
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddTopic
    Dim objDalSt As New DalAddTopic
    Dim objLibErr As New libErrorMsg
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            Else
                If Session("role") = "Admin" Then
                Else
                    Response.Redirect("../login.aspx")
                End If
            End If
            If Len(Request.QueryString("id")) > 0 Then
                ViewState("s") = Request.QueryString("id")
                FillDDl()
                fillData()
            Else
                txtcreatedby.Text = Session("username")
                chkActive.Checked = True
                FillDDl()
            End If


            If Len(Request.QueryString("e")) > 0 Then
                UpdatePanel1.Visible = False
                lblReply.Visible = False
            Else
                UpdatePanel1.Visible = True
                lblReply.Visible = True
            End If
        End If
    End Sub

    Private Sub FillDDl()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
        MyCLS.ConClose()
    End Sub
    Private Sub FillDDlSem()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlSem, "Semester", "SemID", "SemesterTitle", "courseid", ddlCourse.SelectedValue)
        MyCLS.ConClose()
    End Sub
    Private Sub FillBatch()
        Try
            Dim strBatch As String = "select distinct(b.BatchCode),b.bid from batch b INNER JOIN StudentRegBatch bt on b.bid=bt.bid where bt.courseid=" & ddlCourse.SelectedValue
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strBatch)
            ddlBatch.Items.Insert(0, "--Select--")
            ddlBatch.DataSource = dsbatch
            ddlBatch.DataTextField = "BatchCode"
            ddlBatch.DataValueField = "bid"
            ddlBatch.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillDDlSem1()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlSem, "Semester", "SemID", "SemesterTitle")
        MyCLS.ConClose()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnValidate()
            If objLibErr.ChkReturn = True Then
                objLibST.title = Trim(txtTopic.Text)
                objLibST.CreatedBy = Trim(txtcreatedby.Text)
                objLibST.Active = chkActive.Checked
                objLibST.CourseID = ddlCourse.SelectedValue
                objLibST.Semid = ddlSem.SelectedValue
                objLibST.Batchid = ddlBatch.SelectedValue
                If Len(ViewState("s")) > 0 Then
                    objLibST.SubjectID = ViewState("s")
                Else
                    objLibST.SubjectID = 0
                End If

                Dim retVal As Int16 = objDalSt.InsertTopic(objLibST)

                If retVal = -11 Then
                    lblMessage.Text = "Topic already  exist"
                    Exit Sub
                ElseIf retVal = 1 Then

                    If Request.QueryString("e") IsNot Nothing Then
                        Dim strInsQ As String
                        strInsQ = "Update Subsubject set SubjectText='" & CLS.fnReplaceSpCH1(Trim(txtreply.Text)) & "' where subsubjectid=" & ViewState("subSubjectid")
                        CLS.fnExecuteQuery(strInsQ)
                        Response.Redirect("listTopic.aspx")
                    Else

                        Dim strLastQ As String = "SELECT IDENT_CURRENT('maintopic')"
                        Dim dslast As New DataSet
                        dslast = CLS.fnQuerySelectDs(strLastQ)


                        Dim strInsQ As String
                        strInsQ = "INSERT INTO Subsubject(subjectid,SubjectText,dateofposting,email,Approve) VALUES (" & dslast.Tables(0).Rows(0)(0).ToString & ",'" & CLS.fnReplaceSpCH1(Trim(txtreply.Text)) & "','" & Date.Today.Date & "','" & Session("username") & "',0)"
                        CLS.fnExecuteQuery(strInsQ)


                        Dim dsPost As New DataSet
                        Dim tpost As Integer
                        Dim strQ As String
                        strQ = "select tpost from Maintopic where subjectid=" & dslast.Tables(0).Rows(0)(0).ToString
                        dsPost = CLS.fnQuerySelectDs(strQ)

                        If dsPost IsNot Nothing Then
                            If dsPost.Tables IsNot Nothing Then
                                If dsPost.Tables(0).Rows IsNot Nothing Then
                                    If dsPost.Tables(0).Rows.Count > 0 Then
                                        tpost = dsPost.Tables(0).Rows(0)(0).ToString
                                        Dim strUpQ As String
                                        strUpQ = "Update maintopic set tpost=" & tpost + 1 & ",LastPost='" & CStr(Date.Now.Date) & "' where subjectid=" & dslast.Tables(0).Rows(0)(0).ToString
                                        CLS.fnExecuteQuery(strUpQ)
                                        '  Response.Redirect("../alltopic.aspx?id=" & dslast.Tables(0).Rows(0)(0).ToString & "&o=1")
                                    End If
                                End If
                            End If
                        End If

                        Response.Redirect("listTopic.aspx")
                    End If


                ElseIf retVal = MyCLS.EStatus.Err Then
                    MyCLS.fnMSG("Error Occured!")
                End If
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try
    End Sub



    Public Function fnValidate() As Object
        Dim ObjErrDal As New libErrorMsg
        If Len(Trim(txtTopic.Text)) <= 0 Then
            ObjErrDal.errMessage = "Topic cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If ddlCourse.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select course"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If ddlSem.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select semester"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        'Dim dsChkEmail As New DataSet
        ''dsChkEmail = CLS.fnQuerySelectDs("select * from application where email='" & Trim(txtEmailAddress.Text) & "' and courseid=" & ddlCourse.SelectedValue)
        'dsChkEmail = CLS.fnQuerySelectDs("select * from application where email='" & Trim(txtEmailAddress.Text) & "'")
        'If dsChkEmail IsNot Nothing Then
        '    If dsChkEmail.Tables IsNot Nothing Then
        '        If dsChkEmail.Tables(0).Rows IsNot Nothing Then
        '            If dsChkEmail.Tables(0).Rows.Count > 0 Then
        '                ObjErrDal.errMessage = "Student already registered"
        '                ObjErrDal.ChkReturn = False
        '                Return ObjErrDal
        '            End If
        '        End If
        '    End If
        'End If
        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function


    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillDDlSem()
        FillBatch()
    End Sub

    Sub fillData()
        Try
            Dim dsTopic As New DataSet
            Dim strQ As String
            strQ = "select c.batchid,c.title,c.createdby,a.courseTitle as CourseTitle,b.semesterTitle as semesterTitle,c.Active,c.courseid as courseid,c.semid as semid from maintopic c " & _
                    " inner join course a on " & _
                    " c.courseid = a.courseid " & _
                    " inner join semester b on " & _
                    " c.semid = b.semid" & _
                    " where c.subjectid =" & ViewState("s")
            dsTopic = CLS.fnQuerySelectDs(strQ)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            txtTopic.Text = dsTopic.Tables(0).Rows(0)("title").ToString
                            txtcreatedby.Text = dsTopic.Tables(0).Rows(0)("createdBy").ToString
                            If dsTopic.Tables(0).Rows(0)("Active").ToString = "False" Then
                                chkActive.Checked = False
                            Else
                                chkActive.Checked = True
                            End If

                            ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(dsTopic.Tables(0).Rows(0)("Courseid").ToString))

                            FillBatch()
                            FillDDlSem()
                            ddlSem.SelectedIndex = ddlSem.Items.IndexOf(ddlSem.Items.FindByValue(dsTopic.Tables(0).Rows(0)("semid").ToString))
                            ddlBatch.SelectedIndex = ddlBatch.Items.IndexOf(ddlBatch.Items.FindByValue(dsTopic.Tables(0).Rows(0)("batchid").ToString))
                        End If
                    End If
                End If
            End If
            Dim strTopSubQ As String
            Dim dsTopTopic As New DataSet

            strTopSubQ = "select top 1 subsubjectid,subjecttext from subsubject where subjectid=" & ViewState("s")
            dsTopTopic = CLS.fnQuerySelectDs(strTopSubQ)
            If dsTopTopic IsNot Nothing Then
                If dsTopTopic.Tables IsNot Nothing Then
                    If dsTopTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopTopic.Tables(0).Rows.Count > 0 Then
                            txtreply.Text = CLS.fnGetDataFromSpCH1(dsTopTopic.Tables(0).Rows(0)("subjecttext").ToString)
                            ViewState("subSubjectid") = dsTopTopic.Tables(0).Rows(0)("subSubjectid").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("listtopic.aspx")
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
End Class
