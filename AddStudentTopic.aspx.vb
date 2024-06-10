Imports fmsf.DAL
Imports fmsf.lib
Imports Emoticons

Partial Class AddStudentTopic
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddTopic
    Dim objDalSt As New DalAddTopic
    Dim objLibErr As New libErrorMsg
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Len(Session("username")) <= 0 Then
                Response.Redirect("login.aspx")
            End If
            If Len(Request.QueryString("id")) > 0 Then
                ViewState("s") = Request.QueryString("id")
                FillDDl()
                bindData()

                '  fillData()
            Else
                txtcreatedby.Text = Session("username")
                FillDDl()
            End If

        End If
    End Sub

    Sub bindData()
        Try
            Dim strq As String

            strq = "select  top 1 * from maintopic m inner join subsubject s on s.SubjectID=m.subjectId where m.subjectid=" & Request.QueryString("id") & " and email='" & Session("username") & "' order by subsubjectid"

            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then



                            txtTopic.Text = dsTopic.Tables(0).Rows(0)("Title").ToString()
                            txtcreatedby.Text = dsTopic.Tables(0).Rows(0)("CreatedBy").ToString()
                            txtreply.Text = dsTopic.Tables(0).Rows(0)("SubjectText").ToString()
                            ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(dsTopic.Tables(0).Rows(0)("courseid").ToString()))

                            FillDDlSem1()

                            ddlSem.SelectedIndex = ddlSem.Items.IndexOf(ddlSem.Items.FindByValue(dsTopic.Tables(0).Rows(0)("SemId").ToString()))
                            btnSave.Text = "Update"
                            If (Request.QueryString("EditTopic") <> "") Then
                                dvReply.Visible = False
                                dvReply1.Visible = False
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillDDl()
        Dim dsCourseTopic As New DataSet
        Dim dsDDl As New DataSet
        'dsDDl = CLS.fnQuerySelectDs("select c.courseid as courseid,c.coursetitle as coursetitle from studentRegcourse rg inner join course c on rg.courseid=c.courseid where stid=" & Session("stid"))
        dsDDl = CLS.fnQuerySelectDs("select distinct(c.coursetitle) as coursetitle,c.courseid as courseid,ss.feestatus from studentRegcourse rg inner join course c on rg.courseid=c.courseid INNER JOIN studentSemester ss on ss.courseid=rg.courseid  where ss.stid=" & Session("stid") & "  and ss.currentStatus=2 and ss.feestatus=1")
        If dsDDl IsNot Nothing Then
            If dsDDl.Tables IsNot Nothing Then
                If dsDDl.Tables(0).Rows IsNot Nothing Then
                    If dsDDl.Tables(0).Rows.Count > 0 Then
                        ddlCourse.DataSource = dsDDl
                        ddlCourse.DataValueField = "courseid"
                        ddlCourse.DataTextField = "coursetitle"
                        ddlCourse.DataBind()
                        ddlCourse.Items.Insert(0, "SELECT")
                    End If
                End If
            End If
        End If
    End Sub
    'Private Sub FillDDlSem()
    '    MyCLS.ConOpen()
    '    MyCLS.prcFillDDL(ddlSem, "Semester", "SemID", "SemesterTitle", "courseid", ddlCourse.SelectedValue)
    '    MyCLS.ConClose()
    'End Sub
    Private Sub FillDDlSem1()
        Try
            Dim dsSemTopic As New DataSet
            dsSemTopic = CLS.fnQuerySelectDs("select ss.semid as semid,s.semestertitle as semestertitle from studentsemester ss inner join semester s on ss.semid=s.semid where ss.courseID=" & ddlCourse.SelectedValue & " and ss.currentstatus=2 and stid=" & Session("stid"))
            If dsSemTopic IsNot Nothing Then
                If dsSemTopic.Tables IsNot Nothing Then
                    If dsSemTopic.Tables(0).Rows IsNot Nothing Then
                        If dsSemTopic.Tables(0).Rows.Count > 0 Then
                            ddlSem.DataSource = dsSemTopic
                            ddlSem.DataValueField = "semid"
                            ddlSem.DataTextField = "Semestertitle"
                            ddlSem.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnValidate()
            If objLibErr.ChkReturn = True Then
                If btnSave.Text = "Save" Then


                    objLibST.title = Trim(txtTopic.Text)
                    objLibST.CreatedBy = Trim(txtcreatedby.Text)
                    objLibST.Active = True
                    objLibST.CourseID = ddlCourse.SelectedValue
                    objLibST.Semid = ddlSem.SelectedValue
                    objLibST.Batchid = Fillbatch()
                    objLibST.FileName = ""
                    objLibST.FilePath = ""

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



                        Response.Redirect("MainForumPage.aspx")
                    ElseIf retVal = MyCLS.EStatus.Err Then
                        MyCLS.fnMSG("Error Occured!")
                    End If
                Else

                    Dim strUpQ As String

                    strUpQ = "Update maintopic set title='" & txtTopic.Text & "' where subjectid=" & Request.QueryString("id")
                    CLS.fnExecuteQuery(strUpQ)
                    Response.Redirect("MainForumPage.aspx")
                    lblMessage.Text = objLibErr.errMessage
                End If
            Else

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
        FillDDlSem1()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("MainForumPage.aspx")
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

    Function Fillbatch() As Integer
        Try
            Dim dsBatch As New DataSet
            dsBatch = CLS.fnQuerySelectDs("select bid from studentregbatch where courseID=" & ddlCourse.SelectedValue & " and stid=" & Session("stid"))
            If dsBatch IsNot Nothing Then
                If dsBatch.Tables IsNot Nothing Then
                    If dsBatch.Tables(0).Rows IsNot Nothing Then
                        If dsBatch.Tables(0).Rows.Count > 0 Then
                            Fillbatch = dsBatch.Tables(0).Rows(0)("bid")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Function
End Class



