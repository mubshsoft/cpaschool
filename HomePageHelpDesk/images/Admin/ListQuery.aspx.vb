Imports System.Data
Partial Class Admin_ListQuery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  If Not IsPostBack Then
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        If Not IsPostBack Then
            FillDDl()
            BindGridAdmn()
        End If


        'End If
    End Sub
    Private Sub FillDDl()
        Dim dsCourseTopic As New DataSet
        Dim dsDDl As New DataSet
        'dsDDl = CLS.fnQuerySelectDs("select c.courseid as courseid,c.coursetitle as coursetitle from studentRegcourse rg inner join course c on rg.courseid=c.courseid where stid=" & Session("stid"))
        dsDDl = CLS.fnQuerySelectDs("select courseid,coursetitle from course")
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
                            ddlBatch.Items.Insert(0, "SELECT")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub BindGridAdmn()

        Try
            'Dim strq As String = "select q.QueryId,q.stid,st.firstName,fr.firstName as FacultyName,q.Subject,q.Query,q.Status from QuerySubmission q INNER JOIN student st on q.stid=st.stid INNER JOIN facultyRegistration fr on q.Fid=fr.Fid order by q.QueryId desc"
            Dim strq As String = "select q.fid,st.email,q.QueryId,q.stid,st.firstName+ '' + st.lastname as studentname,fr.firstName+ ' ' + fr.lastname as FacultyName,q.Subject,q.Query,q.Status,CONVERT(varchar, q.QueryDate, 101) as QueryDate,CONVERT(varchar, q.ReplyDate, 101) as ReplyDate from QuerySubmission q left outer JOIN facultyRegistration fr on q.Fid=fr.Fid INNER JOIN student st on q.stid=st.stid order by q.QueryId desc"


            Dim dsQuery1 As New DataSet()
            dsQuery1 = CLS.fnQuerySelectDs(strq)
            If dsQuery1 IsNot Nothing Then
                If dsQuery1.Tables IsNot Nothing Then
                    If dsQuery1.Tables(0).Rows IsNot Nothing Then
                        If dsQuery1.Tables(0).Rows.Count > 0 Then
                            GrdQuery.DataSource = dsQuery1
                            GrdQuery.DataBind()
                            GrdQuery.Visible = True
                        Else
                            lblMessage.Text = "No record found"
                            GrdQuery.Visible = False
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

            Dim strq As String = "select q.fid,st1.email,q.QueryId,q.stid,st1.firstName + st1.lastname as studentname,fr.firstName+ ' ' + fr.lastname as FacultyName,q.Subject,q.Query,q.Status," & _
                                "CONVERT(varchar, q.QueryDate, 101) as QueryDate,CONVERT(varchar, q.ReplyDate, 101) as ReplyDate " & _
                                "from querysubmission q " & _
                                "INNER JOIN StudentRegBatch bt on bt.stid=q.stid " & _
                                "inner join student st1 on st1.stid=q.stid " & _
                                "left outer join facultyRegistration fr on q.Fid=fr.Fid where bid=" & ddlBatch.SelectedValue & " order by q.QueryId desc"

            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strq)
            If ds IsNot Nothing Then
                If ds.Tables IsNot Nothing Then
                    If ds.Tables(0).Rows IsNot Nothing Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            GrdQuery.DataSource = ds
                            GrdQuery.DataBind()
                            GrdQuery.Visible = True
                        Else
                            lblMessage.Text = "No record found"
                            GrdQuery.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub


    Protected Sub GrdQuery_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdQuery.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        If row.DataItem Is Nothing Then
            Exit Sub
        End If
        Dim lblQueryId As Label
        Dim lblFacultyName As Label
        Dim lblFid As Label
        Dim linkBtn As Label
        Dim linkBtn1 As LinkButton
        Dim lblSubject As LinkButton
        lblQueryId = CType(row.FindControl("lblQueryId"), Label)
        lblFacultyName = CType(row.FindControl("lblFacultyName"), Label)
        linkBtn = CType(row.FindControl("lblStatus"), Label)
        linkBtn1 = CType(row.FindControl("lblStatus1"), LinkButton)
        lblSubject = CType(row.FindControl("lblSubject"), LinkButton)
        lblFid = CType(row.FindControl("lblFid"), Label)

        If lblFacultyName.Text = "" Then
            'lblFacultyName.Text = "Admin"
            If lblFid.Text = "0" Then
                lblFacultyName.Text = "Admin"
            ElseIf lblFid.Text = "-1" Then
                lblFacultyName.Text = "Course Coordinator"
            End If
        End If
        If linkBtn.Text = "Pending" Then
            linkBtn.ForeColor = Drawing.Color.Black
            linkBtn1.Text = "Reply"
            linkBtn1.ForeColor = Drawing.Color.Red
            lblSubject.Enabled = False

        Else
            linkBtn.ForeColor = Drawing.Color.Black
            linkBtn1.Text = ""
            lblSubject.ForeColor = Drawing.Color.Green
            lblSubject.Attributes.Add("onclick", "javascript:return openPopup('" + lblQueryId.Text + "');")
        End If
        'linkBtn.Attributes.Add("onclick", "javascript:return openPopup('" + lblQueryId.Text + "');")
        linkBtn1.Attributes.Add("onclick", "javascript:return openPopup('" + lblQueryId.Text + "');")


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

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillDDlBatch()
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        BindGridByBatch()
    End Sub
End Class
