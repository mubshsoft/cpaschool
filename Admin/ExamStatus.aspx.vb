
Partial Class Admin_ExamStatus
    Inherits System.Web.UI.Page
    Dim batchcode As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                ViewState("chk") = 1
                FillDDl()
                If Len(Request.QueryString("exid")) > 0 Then
                    bindUserList()
                End If
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
            strq = "select distinct(sa.Userid),sa.ExamId,FirstName +' ' +middlename+' '+lastname as stuname from studentactiveexam sa join student s on sa.userid=s.email where sa.ExamId=" & ddlListExamSet.SelectedValue & " and sa.BID=" & Request.QueryString("batchid") & " and sa.activatedate is not null"
            Dim dsUser As New DataSet()
            dsUser = CLS.fnQuerySelectDs(strq)
            If dsUser IsNot Nothing Then
                If dsUser.Tables IsNot Nothing Then
                    If dsUser.Tables(0).Rows IsNot Nothing Then
                        If dsUser.Tables(0).Rows.Count > 0 Then
                            GrdUserList.DataSource = dsUser
                            GrdUserList.DataBind()
                        Else
                            GrdUserList.EmptyDataText = "no record found"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

     
    End Sub
    Sub bindUserList1()
        Try
            Dim strq1 As String
            strq1 = "select distinct(sa.Userid),sa.ExamId,FirstName +' ' +middlename+' '+lastname as stuname from studentactiveexam sa join student s on sa.userid=s.email where sa.ExamId=" & ddlListExamSet.SelectedValue & " and sa.BID=" & Request.QueryString("batchid") & " and sa.activatedate is null"
            Dim dsUser1 As New DataSet()
            dsUser1 = CLS.fnQuerySelectDs(strq1)
            If dsUser1 IsNot Nothing Then
                If dsUser1.Tables IsNot Nothing Then
                    If dsUser1.Tables(0).Rows IsNot Nothing Then
                        If dsUser1.Tables(0).Rows.Count > 0 Then
                            GrdUserList1.DataSource = dsUser1
                            GrdUserList1.DataBind()
                        Else
                            GrdUserList1.EmptyDataText = "no record found"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddlListExamSet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlListExamSet.SelectedIndexChanged
        bindUserList()
        bindUserList1()
    End Sub



    Protected Sub GrdUserList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdUserList.PageIndexChanging
        GrdUserList.PageIndex = e.NewPageIndex
        bindUserList()
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete

    End Sub

    Protected Sub GrdUserList1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdUserList1.PageIndexChanging
        GrdUserList1.PageIndex = e.NewPageIndex
        bindUserList1()
    End Sub
End Class
