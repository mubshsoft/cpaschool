Imports fmsf.lib
Imports fmsf.DAL
Partial Class Admin_SelectStudentPerformance
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        If Len(Request.QueryString("bid")) > 0 Then
            ' ddlBatch.SelectedIndex = ddlBatch.Items.IndexOf(ddlBatch.Items.FindByValue(89))
            'FillCourse()
            bindgrid1()
        End If
        If Not IsPostBack Then
            MyCLS.ConOpen()
            FillCourse()
            If Len(Request.QueryString("Cid")) > 0 And Len(Request.QueryString("bid")) > 0 Then
                ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(Request.QueryString("Cid")))
                FillBatch()
                ' ddlBatch.SelectedIndex = ddlBatch.Items.IndexOf(ddlBatch.Items.FindByValue(Request.QueryString("bid")))
                ddlBatch.SelectedIndex = ddlBatch.Items.IndexOf(ddlBatch.Items.FindByText(MyCLS.fnQuerySelect1Value("batch", "batchcode", "bid", Request.QueryString("bid"))))
                bindgrid()
            End If

            MyCLS.ConClose()
        End If

    End Sub


    Private Sub FillCourse()
        Try


            Dim strBatch As String = "select distinct(ss.courseid),c.coursetitle from studentsemester ss INNER JOIN course c on ss.courseid=c.courseid"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strBatch)
            ddlCourse.DataSource = dsCourse
            ddlCourse.DataTextField = "coursetitle"
            ddlCourse.DataValueField = "Courseid"
            ddlCourse.DataBind()
            ddlCourse.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillBatch()
        Try


            Dim strBatch As String = "select distinct(batchcode),studentRegbatch.bid,studentRegbatch.Courseid from studentRegbatch Inner join batch on studentRegbatch.bid=batch.bid where studentRegbatch.courseid=" & ddlCourse.SelectedValue
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strBatch)
            ddlBatch.DataSource = dsbatch
            ddlBatch.DataTextField = "BatchCode"
            ddlBatch.DataValueField = "bid"
            ddlBatch.DataBind()
            ddlBatch.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub FillSem()
    '    Try


    '        Dim strSem As String = "select distinct(ss.semid), ss.courseid,se.SemesterTitle from studentsemester ss INNER JOIN studentregbatch sr on ss.stid=sr.stid and ss.courseid=sr.courseid INNER JOIN Semester se on se.semid=ss.semid where sr.bid=" & ddlBatch.SelectedValue
    '        Dim dsSem As New DataSet()
    '        dsSem = CLS.fnQuerySelectDs(strSem)
    '        ddlsem.DataSource = dsSem
    '        ddlsem.DataTextField = "SemesterTitle"
    '        ddlsem.DataValueField = "semid"
    '        ddlsem.DataBind()
    '        ddlsem.Items.Insert(0, "--Select--")
    '    Catch ex As Exception

    '    End Try
    'End Sub

   

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillBatch()
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        Dim strq2 As String = "SELECT batchclose from batch where  bid =" & ddlBatch.SelectedValue
        Dim dsbatchclose As New DataSet()
        dsbatchclose = CLS.fnQuerySelectDs(strq2)
        If dsbatchclose IsNot Nothing Then
            If dsbatchclose.Tables IsNot Nothing Then
                If dsbatchclose.Tables(0).Rows IsNot Nothing Then
                    If dsbatchclose.Tables(0).Rows.Count > 0 Then

                        If dsbatchclose.Tables(0).Rows(0)("batchclose").ToString() = "True" Then
                            imgBatchClose.Visible = False
                            lblBatch.Text = "Batch Closed"
                        Else
                            imgBatchClose.Visible = True
                            lblBatch.Text = "Not Closed"
                        End If


                    End If
                End If
            End If
        End If
        bindgrid()
    End Sub

    
    Protected Sub bindgrid()
        Try


            'Dim strq As String = "SELECT studentRegBatch.bid,studentRegBatch.courseid,(student.firstName + ' '+student.lastname) as fullname,student.email as Email ,student.stid as stid,Batch.BatchCode from student 	join StudentRegBatch on StudentRegBatch.stid= student.stid	join Batch on Batch.bid=StudentRegBatch.bid where StudentRegBatch.bid =" & ddlBatch.SelectedValue
            Dim strq As String = "SELECT studentRegBatch.bid,studentRegBatch.courseid,(student.firstName + ' '+student.lastname) as fullname,student.email as Email ,student.stid as stid,Batch.BatchCode,convert(varchar(11),cStartDate,113) as cStartDate,convert(varchar(11),cEndDate,113) as cEndDate,DATEDIFF(mm,cStartDate,cEndDate) as cmonth,Coursetype from student join StudentRegBatch on StudentRegBatch.stid= student.stid	inner join Batch on Batch.bid=StudentRegBatch.bid inner join course c on c.courseID= studentRegBatch.courseid where StudentRegBatch.bid =" & ddlBatch.SelectedValue
            Dim dsStudent As New DataSet()
            dsStudent = CLS.fnQuerySelectDs(strq)
            If dsStudent IsNot Nothing Then
                If dsStudent.Tables IsNot Nothing Then
                    If dsStudent.Tables(0).Rows IsNot Nothing Then
                        If dsStudent.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsStudent
                            GrdStudent.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

   
    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ManageStudentInfo.aspx")
    End Sub
    Sub bindgrid1()
        Try

            '            Dim strq As String = "select mrk.paperid,mrk.stid,mrk.bid,ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,ss.courseid from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid INNER JOIN studentsemmarks sm on sm.stid=mrk.stid and sm.bid=mrk.bid where ss.feestatus = 1 And m.semid = " & ddlsem.SelectedValue & ""
            'Dim strq As String = "SELECT studentRegBatch.bid,studentRegBatch.courseid,(student.firstName + ' '+student.lastname) as fullname,student.email as Email ,student.stid as stid from student 	join StudentRegBatch on StudentRegBatch.stid= student.stid	join Batch on Batch.bid=StudentRegBatch.bid where StudentRegBatch.bid =" & Request.QueryString("bid")
            Dim strq As String = "SELECT studentRegBatch.bid,studentRegBatch.courseid,(student.firstName + ' '+student.lastname) as fullname,student.email as Email ,student.stid as stid,Batch.BatchCode from student 	join StudentRegBatch on StudentRegBatch.stid= student.stid	join Batch on Batch.bid=StudentRegBatch.bid where StudentRegBatch.bid =" & Request.QueryString("bid")
            Dim dsStudent As New DataSet()
            dsStudent = CLS.fnQuerySelectDs(strq)
            If dsStudent IsNot Nothing Then
                If dsStudent.Tables IsNot Nothing Then
                    If dsStudent.Tables(0).Rows IsNot Nothing Then
                        If dsStudent.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsStudent
                            GrdStudent.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdExamSet_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Try
            'If e.CommandName = "HotelID" Then
            '    Response.Redirect("Gridview_1.aspx?HotelId=" + e..CommandArgument)
            'End If
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim valu As HiddenField = DirectCast(e.Row.FindControl("hdnUserId"), HiddenField)
                Dim chkMarks As CheckBox = DirectCast(e.Row.FindControl("chkMarks"), CheckBox)
                Dim chkTestimonials As CheckBox = DirectCast(e.Row.FindControl("chkTestimonials"), CheckBox)
                Dim chkCertificate As CheckBox = DirectCast(e.Row.FindControl("chkCertificate"), CheckBox)
                Dim btnCloserLetter As LinkButton = DirectCast(e.Row.FindControl("btnCloserLetter"), LinkButton)
                Dim btnGenerateCertificate As LinkButton = DirectCast(e.Row.FindControl("btnGenerateCertificate"), LinkButton)

                Try

                    '            Dim strq As String = "select mrk.paperid,mrk.stid,mrk.bid,ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,ss.courseid from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid INNER JOIN studentsemmarks sm on sm.stid=mrk.stid and sm.bid=mrk.bid where ss.feestatus = 1 And m.semid = " & ddlsem.SelectedValue & ""
                    Dim strq As String = "SELECT id from BatchClosure where UserId=" & valu.Value + " and bid=" & ddlBatch.SelectedValue
                    Dim dsStudent As New DataSet()
                    dsStudent = CLS.fnQuerySelectDs(strq)
                    If dsStudent IsNot Nothing Then
                        If dsStudent.Tables IsNot Nothing Then
                            If dsStudent.Tables(0).Rows IsNot Nothing Then
                                If dsStudent.Tables(0).Rows.Count > 0 Then
                                    chkMarks.Checked = True
                                    chkCertificate.Checked = True
                                    chkTestimonials.Checked = True
                                    If chkCertificate.Checked = True AndAlso chkTestimonials.Checked = True Then
                                        btnCloserLetter.Visible = True
                                        btnGenerateCertificate.Visible = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try


                Try

                    '            Dim strq As String = "select mrk.paperid,mrk.stid,mrk.bid,ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,ss.courseid from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid INNER JOIN studentsemmarks sm on sm.stid=mrk.stid and sm.bid=mrk.bid where ss.feestatus = 1 And m.semid = " & ddlsem.SelectedValue & ""
                    Dim strq As String = "SELECT ExamStatus from StudentPaperMarks where stid=" & valu.Value + " and bid=" & ddlBatch.SelectedValue
                    Dim dsStudent As New DataSet()

                    dsStudent = CLS.fnQuerySelectDs(strq)
                    If dsStudent IsNot Nothing Then
                        If dsStudent.Tables IsNot Nothing Then
                            If dsStudent.Tables(0).Rows IsNot Nothing Then
                                If dsStudent.Tables(0).Rows.Count > 0 Then

                                    For value As Integer = 0 To dsStudent.Tables(0).Rows.Count - 1


                                        If dsStudent.Tables(0).Rows(value)("ExamStatus") = 0 Then
                                            chkMarks.Checked = False
                                            Return
                                        Else

                                            chkMarks.Checked = True
                                        End If

                                    Next

                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try


            End If
        Catch ex As Exception

        End Try
    End Sub

    

    Protected Sub imgBatchClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgBatchClose.Click
        Try

            Dim addResult As Integer = 0

            Dim objLIBExam As New LIBExam()
            Dim objDalExam As New DALExam()
            Dim tp As New TransportationPacket()

            objLIBExam.BatchId = Convert.ToInt16(ddlBatch.SelectedItem.Value)

            tp.MessagePacket = DirectCast(objLIBExam, Object)
            addResult = objDalExam.CloseBatch(tp)

            If addResult > 0 Then

                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Closed successfully');", True)
                imgBatchClose.Visible = False
                lblBatch.Text = "Closed"

            ElseIf addResult = -11 Then
                'Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Set'); </script>");

                lblMessage.Text = "Already Closed"
            Else

                'Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");

                lblMessage.Text = "Failed to Save "
            End If
        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
    End Sub

    Protected Sub GrdStudent_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "BatchID" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim id As Integer = GrdStudent.DataKeys(row.RowIndex).Value
            Dim lblfullname As Label = DirectCast(GrdStudent.Rows(row.RowIndex).FindControl("lblfullname"), Label)
            'Response.Redirect("closureletter.aspx?stid=" & lblfullname.Text & "&bt=" & e.CommandArgument)
            ' Response.Redirect("closureletter.aspx?stid=" & lblfullname.Text & "&bt=" & e.CommandArgument)
            'Response.Write("<script type='text/javascript'>window.open('closureletter.aspx?stid=" & lblfullname.Text & "&bt=" & e.CommandArgument & "', '_blank')</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "window.open('closureletter.aspx?stid=" & lblfullname.Text & "&coursecode=" & ddlCourse.SelectedItem.Text & "&bt=" & e.CommandArgument & "');", True)
        End If
        If e.CommandName = "Certificate" Then
            Dim strBody As String = ""
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim lblfullname As Label = DirectCast(GrdStudent.Rows(row.RowIndex).FindControl("lblfullname"), Label)
            Dim hdncStartDate As HiddenField = DirectCast(GrdStudent.Rows(row.RowIndex).FindControl("hdncStartDate"), HiddenField)
            Dim hdncEndDate As HiddenField = DirectCast(GrdStudent.Rows(row.RowIndex).FindControl("hdncEndDate"), HiddenField)
            Dim hdnDuration As HiddenField = DirectCast(GrdStudent.Rows(row.RowIndex).FindControl("hdnDuration"), HiddenField)
            Dim hdnCoursetype As HiddenField = DirectCast(GrdStudent.Rows(row.RowIndex).FindControl("hdnCoursetype"), HiddenField)

            strBody = CommonUtility.prcFindInFile(HttpContext.Current.Server.MapPath("MailFormats/") + "Certificate.htm", "#Name#", lblfullname.Text)
            strBody = CommonUtility.prcFindInString(strBody, "#Course#", ddlCourse.SelectedItem.Text)
            strBody = CommonUtility.prcFindInString(strBody, "#Startdate#", hdncStartDate.Value)
            strBody = CommonUtility.prcFindInString(strBody, "#Enddate#", hdncEndDate.Value)
            strBody = CommonUtility.prcFindInString(strBody, "#Duration#", hdnDuration.Value)
            strBody = CommonUtility.prcFindInString(strBody, "#Coursetype#", hdnCoursetype.Value)


            'ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>javascript:openPopUp1('CertificateForm');</script>", True)

            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "window.openPopup('Certificate.aspx?name=" & lblfullname.Text & "&coursecode=" & ddlCourse.SelectedItem.Text & "&cStartDate=" & hdncStartDate.Value & "&cEndDate=" & hdncEndDate.Value & "&duration=" & hdnDuration.Value & "');", True)

        End If
    End Sub
End Class
