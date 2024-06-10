
Partial Class Admin_EditStudentBatch
    Inherits System.Web.UI.Page
    Dim bid As Integer
    Dim cid As Integer
    Dim stid As Integer
    Dim email As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        Try
            bid = Request.QueryString("bid")
            cid = Request.QueryString("cid")
            stid = Request.QueryString("stid")
            email = Request.QueryString("email")
            If Not IsPostBack Then
                MyCLS.ConOpen()
                bindgrid()
                FillDDlBatch()
                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try



    End Sub
    Private Sub FillDDlBatch()
        Try
            Dim batch As New DataSet
            batch = CLS.fnQuerySelectDs("select distinct(bid),batchcode from batch where courseid=" & cid & " and bid<>" & bid)
            If batch IsNot Nothing Then
                If batch.Tables IsNot Nothing Then
                    If batch.Tables(0).Rows IsNot Nothing Then
                        If batch.Tables(0).Rows.Count > 0 Then
                            ddlBatch.DataSource = batch
                            ddlBatch.DataValueField = "bid"
                            ddlBatch.DataTextField = "BatchCode"
                            ddlBatch.DataBind()

                            ddlBatch.Items.Insert(0, "SELECT")
                        Else
                            lblMessage.Text = "This course have only single batch. Student is already assigned."
                            ddlBatch.Enabled = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub bindgrid()
        Try

            Dim strq As String = "select b.Id,b.bid as bid,bt.batchcode,b.courseid as courseid,course.CourseTitle,st.stid,st.firstName,st.lastname,st.email,bt.BatchCode,b.Approve from student st INNER JOIN StudentRegbatch b on st.stid=b.stid INNER JOIN batch bt on bt.bid=b.bid inner join Course on Course.courseID=b.courseid where b.bid=" & bid & " and st.stid=" & stid
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then
                        If dsbatch.Tables(0).Rows.Count > 0 Then
                            lblCourse.Text = dsbatch.Tables(0).Rows(0)("CourseTitle")
                            lblBatch.Text = dsbatch.Tables(0).Rows(0)("batchcode")
                            lblStudent.Text = dsbatch.Tables(0).Rows(0)("firstName") & " " & dsbatch.Tables(0).Rows(0)("lastname")
                            lblemail.Text = dsbatch.Tables(0).Rows(0)("email")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("ManageBatchByAdmin.aspx?batchid=" & bid)
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (ddlBatch.SelectedItem.Text = "SELECT") Then
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Batch is not selected!');", True)
            Exit Sub
        End If

        Dim dsChkstudentExam As DataSet
        dsChkstudentExam = CLS.fnQuerySelectDs("select *from StudentActiveExam where userid='" & lblemail.Text & "' and  bid=" & Trim(bid) & " and Activate=1")
        If dsChkstudentExam IsNot Nothing Then
            If dsChkstudentExam.Tables IsNot Nothing Then
                If dsChkstudentExam.Tables(0).Rows IsNot Nothing Then
                    If dsChkstudentExam.Tables(0).Rows.Count > 0 Then
                        lblMessage.Text = "Student is already appeared in the exam. You can not move in another batch "
                        Return
                    Else

                        Dim str1 As String = "delete from StudentActiveExam where UserId='" & Trim(lblemail.Text) & "' and  bid=" & Trim(bid) & " and Activate=0"
                        CLS.fnExecuteQuery(str1)

                        Dim str As String = "update StudentRegbatch set bid=" & ddlBatch.SelectedValue & " where courseId=" & cid & " and bid=" & bid & " and stid=" & stid
                        CLS.fnExecuteQuery(str)

                        'Dim str As String = "insert into StudentRegBatch(bid,stid,Approve,courseid)values( " & ddlBatch.SelectedValue.ToString() & " , " & lblstid.Text & ",1," & lblcourseid.Text & ")"
                        'CLS.fnExecuteQuery(str)
                        'lblMessage.Text = "Student added successfully in this batch "
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Student Re-assigned in Batch!');", True)
                        Exit Sub
                    End If
                End If

            End If
        End If


    End Sub
End Class
