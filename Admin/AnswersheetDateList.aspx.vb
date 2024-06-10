Imports fmsf.lib
Imports fmsf.DAL


Partial Class Admin_AnswersheetDateList
    Inherits System.Web.UI.Page
    Dim batchcode As Integer
    Dim dsdate As New DataSet()
    Dim Deac As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                ViewState("chk") = 1
                FillDDl()
               
                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try
        batchcode = Request.QueryString("batchid")
    End Sub
    Private Sub FillDDl()
       
        Try

            Dim strq As String = "select Examcode, Activateexam.Examid from Activateexam join examset on Activateexam.examid=examset.examid  where bid=" & Request.QueryString("batchid")
            Dim dsBatch As New DataSet()
            dsBatch = CLS.fnQuerySelectDs(strq)
            If dsBatch IsNot Nothing Then
                If dsBatch.Tables IsNot Nothing Then
                    If dsBatch.Tables(0).Rows IsNot Nothing Then
                        If dsBatch.Tables(0).Rows.Count > 0 Then
                            ddlListExamSet.DataTextField = "ExamCode"
                            ddlListExamSet.DataValueField = "examid"
                            ddlListExamSet.DataSource = dsBatch
                            ddlListExamSet.DataBind()
                            ddlListExamSet.Items.Insert(0, "--Select--")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
  

    Sub bindUserList()
        Try
            Dim strq As String

            'strq = "select distinct(q.Userid),FirstName +' ' +middlename+' '+lastname as stuname,convert(varchar,SentDate,103) as SentDate,convert(varchar,ReceiveDate,103) as ReceiveDate from  ANSWERS_Sheet q join student s on q.userid=s.email  where q.ExamId=" & ddlListExamSet.SelectedItem.Value & "  and q.bid=" & Request.QueryString("batchid") & ""
            'strq = "select distinct(q.Userid),FirstName +' ' +middlename+' '+lastname as stuname from  QUES_ANSWERS q join student s on q.userid=s.email where q.ExamId=" & ddlListExamSet.SelectedItem.Value & "  and q.bid=" & Request.QueryString("batchid") & ""
            strq = "select distinct(q.Userid),FirstName +' ' +middlename+' '+lastname as stuname from  QUES_ANSWERS q join student s on q.userid=s.email where q.ExamId=" & ddlListExamSet.SelectedItem.Value & ""



            Dim dsUser As New DataSet()
            dsUser = CLS.fnQuerySelectDs(strq)
            If dsUser IsNot Nothing Then
                If dsUser.Tables IsNot Nothing Then
                    If dsUser.Tables(0).Rows IsNot Nothing Then
                        If dsUser.Tables(0).Rows.Count > 0 Then
                            GrdUserList.DataSource = dsUser
                            GrdUserList.DataBind()
                            GrdUserList.Visible = True

                        Else
                            lblMessage.Text = "No Student for this Exam "
                            GrdUserList.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlListExamSet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlListExamSet.SelectedIndexChanged

        bindUserList()
    End Sub



    Protected Sub GrdUserList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdUserList.PageIndexChanging
        GrdUserList.PageIndex = e.NewPageIndex
        bindUserList()
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete

    End Sub
    Protected Sub GrdUserList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdUserList.RowDataBound

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then


                Dim lblsentdt As Label = DirectCast(e.Row.FindControl("lblsentdt"), Label)
                Dim lbluserid As Label = DirectCast(e.Row.FindControl("lbluserid"), Label)
                Dim lblreceivedt As Label = DirectCast(e.Row.FindControl("lblreceivedt"), Label)
                Dim strq As String


                strq = "select case when SentDate='1900-01-01 00:00:00.000' then '' else CONVERT( varchar, SentDate, 101) end as  SentDate, case when ReceiveDate='1900-01-01 00:00:00.000' then '' else CONVERT( varchar, ReceiveDate, 101) end  as ReceiveDate   from ANSWERS_Sheet where ExamId=" & ddlListExamSet.SelectedItem.Value & "  and bid=" & Request.QueryString("batchid") & "  and UserId=" + "'" & lbluserid.Text + "'" & ""



                Dim dsUser As New DataSet()
                dsUser = CLS.fnQuerySelectDs(strq)
                If dsUser IsNot Nothing Then
                    If dsUser.Tables IsNot Nothing Then
                        If dsUser.Tables(0).Rows IsNot Nothing Then
                            If dsUser.Tables(0).Rows.Count > 0 Then

                                lblsentdt.Text = dsUser.Tables(0).Rows(0)("SentDate").ToString
                                lblreceivedt.Text = dsUser.Tables(0).Rows(0)("ReceiveDate").ToString
                            Else
                                lblsentdt.Text = "Pending"
                                lblreceivedt.Text = "Pending"
                            End If
                        End If
                    End If
                End If
               

            End If

        Catch ex As Exception
            ' HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try

    End Sub
  
    
End Class


