
Partial Class Admin_AdminListFeesstudent
    Inherits System.Web.UI.Page
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
            If Not IsPostBack Then
                MyCLS.ConOpen()
                bindgrid()
                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Sub bindgrid()
        Try
            'Dim strq As String = "select ROW_NUMBER() OVER(ORDER BY st.stid asc) AS ROWID, c.coursetitle,b.bid,b.stID,st.email,b.courseid,st.firstname + ' '+ st.lastname as name from studentregbatch b INNER JOIN student st on st.stid=b.stid INNER JOIN course c on c.courseid=b.courseid where b.bID=" & Request.QueryString("batchid").ToString & " order by b.bid desc"

            Dim strq As String = "select ROW_NUMBER() OVER(ORDER BY st.stid asc) AS ROWID, c.coursetitle,c.CourseType,b.bid,b.stID,st.email,b.courseid,st.firstname + ' '+ st.lastname as name from studentregbatch b INNER JOIN student st on st.stid=b.stid INNER JOIN course c on c.courseid=b.courseid where b.bID=" & Request.QueryString("batchid").ToString & " order by b.bid desc"
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then
                        If dsbatch.Tables(0).Rows.Count > 0 Then
                            If dsbatch.Tables(0).Rows(0)("CourseType").ToString() = "ShortTerm" Then
                                lblMsg.Visible = True
                            Else
                                lblMsg.Visible = False
                                GrdBatch.DataSource = dsbatch
                                GrdBatch.DataBind()
                            End If
                        End If
                        End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub GrdBatch_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdBatch.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("AdminListCourse.aspx")
    End Sub
End Class

