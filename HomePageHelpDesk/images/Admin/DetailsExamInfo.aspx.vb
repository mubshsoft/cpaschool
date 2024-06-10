Imports System.IO
Partial Class Admin_DetailsExamInfo
    Inherits System.Web.UI.Page
    Dim dsUser As New DataSet()
    Dim dtTemp As New DataTable()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If

        bindUserList()

    End Sub
    Sub bindUserList()
        Try
           

            Dim strq As String = "select q.QuestionText,a.AnsText,q.Answer,q.QUESTYPE from questions q INNER JOIN QUES_ANSWERS a on q.QuestionId=a.QuestionId where a.UserId='" & Request.QueryString("uid") & "' and a.ExamId=" & Request.QueryString("Exid") & ""


            dsUser = CLS.fnQuerySelectDs(strq)
            If dsUser IsNot Nothing Then
                If dsUser.Tables IsNot Nothing Then
                    If dsUser.Tables(0).Rows IsNot Nothing Then
                        If dsUser.Tables(0).Rows.Count > 0 Then
                            LstUserExaminfo.DataSource = dsUser
                            LstUserExaminfo.DataBind()
                            LstUserExaminfo.Visible = True
                        Else
                            lblMessage.Text = "No Student for this Exam "
                            LstUserExaminfo.Visible = False
                        End If
                    End If
                End If
            End If



            'Creating Header Row 
            dtTemp.Columns.Add("<b>QuestionText</b>")
            dtTemp.Columns.Add("<b>AnsText</b>")
            dtTemp.Columns.Add("<b>Answer</b>")
           
           
            Dim drAddItem As DataRow
            For i As Integer = 0 To dsUser.Tables(0).Rows.Count - 1
                drAddItem = dtTemp.NewRow()
                drAddItem(0) = dsUser.Tables(0).Rows(i)(0).ToString()
                drAddItem(1) = dsUser.Tables(0).Rows(i)(1).ToString()
                drAddItem(2) = dsUser.Tables(0).Rows(i)(2).ToString()
               


                dtTemp.Rows.Add(drAddItem)
            Next

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnExportToWord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportToWord.Click
        Response.Clear()

        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc")

        Response.Charset = ""

        Response.ContentType = "application/vnd.ms-word "

        Dim sw As New StringWriter()

        Dim hw As New HtmlTextWriter(sw)

        LstUserExaminfo.DataBind()

        LstUserExaminfo.RenderControl(hw)

        Response.Output.Write(sw.ToString())

        Response.Flush()

        Response.End()


    End Sub

    Private Sub ExportToExcel(ByVal dg As DataList)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "inline;filename=Clientes.xls")
        Response.Charset = ""
        Me.EnableViewState = False
        Dim oStringWriter As New System.IO.StringWriter()
        Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)
        dg.RenderControl(oHtmlTextWriter)
        Response.Write(oStringWriter.ToString())
        Response.End()

    End Sub

   
End Class
