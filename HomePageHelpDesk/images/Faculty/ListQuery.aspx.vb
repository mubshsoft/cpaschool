
Partial Class Faculty_ListQuery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        If Not IsPostBack Then
            FillDDl()
            ViewState("chk") = 1
            BindGridAdmn()
        End If
    End Sub

    Private Sub FillDDl()
        Dim dsCourseTopic As New DataSet
        Dim dsDDl As New DataSet
        'dsDDl = CLS.fnQuerySelectDs("select c.courseid as courseid,c.coursetitle as coursetitle from studentRegcourse rg inner join course c on rg.courseid=c.courseid where stid=" & Session("stid"))
        dsDDl = CLS.fnQuerySelectDs("select distinct(c.courseid),q.stid,c.coursetitle from querysubmission q INNER JOIN studentregcourse sr on sr.stid=q.stid INNER JOIN course c on c.courseid=sr.courseid")
        If dsDDl IsNot Nothing Then
            If dsDDl.Tables IsNot Nothing Then
                If dsDDl.Tables(0).Rows IsNot Nothing Then
                    If dsDDl.Tables(0).Rows.Count > 0 Then
                        ddlCourse.DataSource = dsDDl
                        ddlCourse.DataValueField = "courseid"
                        ddlCourse.DataTextField = "coursetitle"
                        ddlCourse.DataBind()
                        ddlCourse.Items.Insert(0, "Select Course")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FillDDlBatch()
        Try
            Dim batch As New DataSet
            batch = CLS.fnQuerySelectDs("select distinct(br.bid),bt.batchcode from batch bt INNER JOIN studentregbatch br on br.bid=bt.bid where br.courseid=" & ddlCourse.SelectedValue)
            If batch IsNot Nothing Then
                If batch.Tables IsNot Nothing Then
                    If batch.Tables(0).Rows IsNot Nothing Then
                        If batch.Tables(0).Rows.Count > 0 Then
                            ddlBatch.DataSource = batch
                            ddlBatch.DataValueField = "bid"
                            ddlBatch.DataTextField = "BatchCode"
                            ddlBatch.DataBind()
                            ddlBatch.Items.Insert(0, "Select Batch")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    'Sub BindGrid()
    '    Dim queryval As Integer
    '    If Request.QueryString("admn") IsNot Nothing Then
    '        queryval = Request.QueryString("admn")
    '    End If
    '    Try
    '        Dim strq As String = "select q.QueryId,q.stid,st.email,st.firstName,q.Subject,q.Query,q.Status from QuerySubmission q INNER JOIN student st on q.stid=st.stid INNER JOIN facultyRegistration fr on q.Fid=fr.Fid where fr.email='" & Session("username") & "' order by q.QueryId desc"
    '        Dim dsQuery As New DataSet()
    '        dsQuery = CLS.fnQuerySelectDs(strq)
    '        If dsQuery IsNot Nothing Then
    '            If dsQuery.Tables IsNot Nothing Then
    '                If dsQuery.Tables(0).Rows IsNot Nothing Then
    '                    If dsQuery.Tables(0).Rows.Count > 0 Then
    '                        GrdQuery.DataSource = dsQuery
    '                        GrdQuery.DataBind()
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try

    'End Sub


    'Sub BindGridAdmn()

    '    Try
    '        'Dim strq As String = "select q.QueryId,q.stid,st.firstName,fr.firstName as FacultyName,q.Subject,q.Query,q.Status from QuerySubmission q INNER JOIN student st on q.stid=st.stid INNER JOIN facultyRegistration fr on q.Fid=fr.Fid order by q.QueryId desc"
    '        Dim strq As String = "select q.QueryId,q.stid,st.firstName,fr.firstName as FacultyName,q.Subject,q.Query,q.Status  from QuerySubmission q left outer JOIN facultyRegistration fr on q.Fid=fr.Fid INNER JOIN student st on q.stid=st.stid order by q.QueryId desc"

    '        Dim dsQuery1 As New DataSet()
    '        dsQuery1 = CLS.fnQuerySelectDs(strq)
    '        If dsQuery1 IsNot Nothing Then
    '            If dsQuery1.Tables IsNot Nothing Then
    '                If dsQuery1.Tables(0).Rows IsNot Nothing Then
    '                    If dsQuery1.Tables(0).Rows.Count > 0 Then
    '                        GrdQuery.DataSource = dsQuery1
    '                        GrdQuery.DataBind()
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try

    'End Sub



    Sub BindGridAdmn()

        Try
            Dim strq As String = "select b.batchcode,c.coursecode,q.QueryId,q.querydate,q.stid,st.email,st.firstName+ ' ' + st.lastname as studentname,fr.firstName+ ' ' + fr.lastname as FacultyName,q.Subject,q.Query,q.Status from QuerySubmission q INNER JOIN student st on q.stid=st.stid INNER JOIN facultyRegistration fr on q.Fid=fr.Fid INNER JOIN StudentRegBatch bt on bt.stid=q.stid INNER JOIN course c on c.courseid=bt.courseid INNER JOIN batch b on bt.bid=b.bid where fr.email='" & Session("username") & "' order by q.QueryId desc"
            Dim dsQuery1 As New DataSet()
            dsQuery1 = CLS.fnQuerySelectDs(strq)
            If dsQuery1 IsNot Nothing Then
                If dsQuery1.Tables IsNot Nothing Then
                    If dsQuery1.Tables(0).Rows IsNot Nothing Then
                        If dsQuery1.Tables(0).Rows.Count > 0 Then
                            GrdQuery.DataSource = dsQuery1
                            GrdQuery.DataBind()
                        Else
                            GrdQuery.DataSource = dsQuery1
                            GrdQuery.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub BindGridByBatch()

        Try
            'Dim strq As String = "select st.email,q.QueryId,q.stid,st.firstName,fr.firstName as FacultyName,q.Subject,q.Query,q.Status,CONVERT(varchar, q.QueryDate, 101) as QueryDate,CONVERT(varchar, q.ReplyDate, 101) as ReplyDate from QuerySubmission q left outer JOIN facultyRegistration fr on q.Fid=fr.Fid INNER JOIN student st on q.stid=st.stid INNER JOIN studentregcourse sr on sr.stid=q.stid INNER JOIN StudentRegBatch bt on bt.courseid=sr.courseid where bt.bid=" & ddlBatch.SelectedValue & " order by q.QueryId desc"

            Dim strq As String = "select  b.batchcode,c.coursecode,st1.email,q.QueryId,q.querydate,q.stid,st1.firstName + ' ' + st1.lastname as studentname,fr.firstName+ ' ' + fr.lastname as FacultyName,q.Subject,q.Query,q.Status," & _
                                "CONVERT(varchar, q.QueryDate, 101) as QueryDate,CONVERT(varchar, q.ReplyDate, 101) as ReplyDate " & _
                                "from querysubmission q " & _
                                "INNER JOIN StudentRegBatch bt on bt.stid=q.stid " & _
                                "inner join student st1 on st1.stid=q.stid " & _
                                "INNER JOIN course c on c.courseid=bt.courseid " & _
                                 "INNER JOIN batch b on bt.bid=b.bid " & _
                                "left outer join facultyRegistration fr on q.Fid=fr.Fid where bt.bid=" & Trim(ddlBatch.SelectedValue) & " and q.fid=" & Session("fid") & " order by q.QueryId desc"

            Dim dsQ As New DataSet()
            dsQ = CLS.fnQuerySelectDs(strq)
            If dsQ IsNot Nothing Then
                If dsQ.Tables IsNot Nothing Then
                    If dsQ.Tables(0).Rows IsNot Nothing Then
                        If dsQ.Tables(0).Rows.Count > 0 Then
                            GrdQuery.DataSource = dsQ
                            GrdQuery.DataBind()
                        Else
                            GrdQuery.DataSource = dsQ
                            GrdQuery.DataBind()
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

    Protected Sub GrdQuery_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdQuery.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        If row.DataItem Is Nothing Then
            Exit Sub
        End If
        Dim lblQueryId As Label
        Dim linkBtn As LinkButton
        lblQueryId = CType(row.FindControl("lblQueryId"), Label)
        linkBtn = CType(row.FindControl("lblStatus"), LinkButton)
        If linkBtn.Text = "Pending" Then
            linkBtn.ForeColor = Drawing.Color.Red
        Else
            linkBtn.ForeColor = Drawing.Color.Green
        End If
        linkBtn.Attributes.Add("onclick", "javascript:return openPopup('" + lblQueryId.Text + "');")

    End Sub
    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillDDlBatch()
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        ViewState("chk") = 2
        BindGridByBatch()
    End Sub

    Protected Sub GrdQuery_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdQuery.PageIndexChanging
        GrdQuery.PageIndex = e.NewPageIndex
        If ViewState("chk") = 1 Then
            BindGridAdmn()
        Else
            BindGridByBatch()
        End If

    End Sub
End Class
