
Partial Class CourseDetailsInfo
    Inherits System.Web.UI.Page
    Dim cid As Integer
    Dim dsDetails As New DataSet
    Protected dsBroucherandFaq As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                cid = Request.QueryString("cid")
                BindData()
                BroucherGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindData()
        Try

            Dim strQ As String
            strQ = "select *from coursedetails where CourseId=" & Request.QueryString("cid")
            dsDetails = CLS.fnQuerySelectDs(strQ)
            If dsDetails IsNot Nothing Then
                If dsDetails.Tables IsNot Nothing Then
                    If dsDetails.Tables(0).Rows IsNot Nothing Then
                        If dsDetails.Tables(0).Rows.Count > 0 Then
                            lblHeading.Text = dsDetails.Tables(0).Rows(0)("CourseName").ToString
                            lblText1.Text = dsDetails.Tables(0).Rows(0)("Text1").ToString
                            'lblText2.Text = dsDetails.Tables(0).Rows(0)("Text2").ToString
                            'lblText3.Text = dsDetails.Tables(0).Rows(0)("Text3").ToString
                            'lblText4.Text = dsDetails.Tables(0).Rows(0)("Text4").ToString
                        End If
                    End If
                End If
            End If
          

        Catch ex As Exception
        End Try
    End Sub
    Sub BroucherGrid()

        Try
            Dim courseid As Integer
            courseid = Request.QueryString("cid")

            Dim strq As String = "select cs.*,br.HelpDeskFilepath,br.BroucherFilepath,br.CalendarFilepath from coursedetails cs INNER JOIN HelpDeskBroucher br on br.courseid=cs.courseid where cs.courseid =" + Request.QueryString("cid")

            Dim sb As New StringBuilder()
            dsBroucherandFaq = CLS.fnQuerySelectDs(strq)
            If dsBroucherandFaq IsNot Nothing Then
                If dsBroucherandFaq.Tables IsNot Nothing Then
                    If dsBroucherandFaq.Tables(0).Rows IsNot Nothing Then
                        If dsBroucherandFaq.Tables(0).Rows.Count > 0 Then
                            For a = 0 To dsBroucherandFaq.Tables(0).Rows.Count - 1

                                sb.Append("<div class='well' >")
                                sb.Append("<div class='row' >")
                                sb.Append("<div class='col-lg-3 col-md-3 col-sm-12 col-xs-12' style='text-align: center; padding: 2em; border-top-left-radius: 10px; border-bottom-left-radius: 10px; background: #eea236; color: #ffffff;'>")
                                sb.Append("<i class='icon-book' style='font-size: 3em;'></i>")
                                sb.Append("<h4 style='padding-top: 5px;'><a href='DownloadPDF.aspx?HelpDesk=2&cid=" + courseid.ToString() + "' style='color: #fff;'>Brochure</a></h4>")
                                sb.Append("<div class='btn btn-success'><a href='DownloadPDF.aspx?HelpDesk=2&cid=" + courseid.ToString() + "' style='color: #fff;'><i class='icon-download-alt'></i> Download</a></div>")
                                sb.Append("</div>")
                                sb.Append("<div class='col-lg-3 col-md-3 col-sm-12 col-xs-12' style='text-align: center; padding: 2em; background: #5bb4de; color: #ffffff;'>")
                                sb.Append("<i class='icon-question-sign' style='font-size: 3em;'></i>")
                                sb.Append("<h4 style='padding-top: 5px;'><a href='DownloadPDF.aspx?HelpDesk=1&cid=" + courseid.ToString() + "' style='color: #fff;'>FAQ's</a></h4>")
                                sb.Append("<div class='btn btn-success'><a href='DownloadPDF.aspx?HelpDesk=1&cid=" + courseid.ToString() + "' style='color: #fff;'><i class='icon-download-alt'></i> Download</a></div>")
                                sb.Append("</div>")
                                sb.Append("<div class='col-lg-3 col-md-3 col-sm-12 col-xs-12' style='text-align: center; padding: 2em; background: #1b9c03; color: #ffffff;'>")
                                sb.Append("<i class='icon-calendar' style='font-size: 3em;'></i>")
                                sb.Append("<h4 style='padding-top: 5px;'><a href='DownloadPDF.aspx?HelpDesk=3&cid=" + courseid.ToString() + "' style='color: #fff;'>Calendar</a></h4>")
                                sb.Append("<div class='btn btn-success'><a href='DownloadPDF.aspx?HelpDesk=3&cid=" + courseid.ToString() + "' style='color: #fff;'><i class='icon-download-alt'></i> Download</a></div>")
                                sb.Append("</div>")

                                sb.Append("<div class='col-lg-3 col-md-3 col-sm-12 col-xs-12' style='text-align: center; padding: 2em; border-top-right-radius: 10px; border-bottom-right-radius: 10px; background: #3367d6; color: #ffffff;'>")
                                sb.Append("<i class='icon-user' style='font-size: 3em;'></i>")
                                sb.Append("<h4 style='padding-top: 5px;'><a href='FacultiesDetail.aspx?cid=" + courseid.ToString() + "' style='color: #fff;'>Course</a></h4>")
                                sb.Append("<div class='btn btn-success'><a href='FacultiesDetail.aspx?cid=0' style='color: #fff;'><i class='icon-persons'></i> Faculty</a></div>")
                                sb.Append("</div>")

                                sb.Append("</div>")
                                sb.Append("</div>")

                            Next
                            'GrdStudent.DataSource = dsNews
                            'GrdStudent.DataBind()

                        End If
                        Dim li As New Literal
                        li.Text = sb.ToString()
                        PlaceHolder1.Controls.Add(li)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
End Class
