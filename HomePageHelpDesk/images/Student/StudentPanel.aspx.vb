
Partial Class studentPanel
    Inherits System.Web.UI.Page
    Protected sNewDesc As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If

        StudentForDownloadmeterial()

        If Not IsPostBack Then
            bindNotifications()
            bindDemoVideo()
            ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDiv'); </script>")
        End If


    End Sub

    Private Sub StudentForDownloadmeterial()
        Try
            Dim strq As String = "select stid from student where email='" & Session("username") & "'"
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strq)
            Dim studentid As String = ds.Tables(0).Rows(0)("stid").ToString()
       
            Dim strq1 As String = "select stid from student where stid in(select stid from StudentRegBatch where stid='" & studentid & "')"
            Dim ds1 As New DataSet()
            ds1 = CLS.fnQuerySelectDs(strq1)
            If ds1.Tables(0).Rows.Count > 0 Then
            Else
                lnkCourseMeterial.Attributes.Add("href", "StudentListCourse.aspx")

                lnkCourseMeterial.Attributes.Remove("href")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Try
            Dim strq1 As String = "select stid from Student where email='" & Session("username") & "'"
            Dim dsStid1 As New DataSet()
            dsStid1 = CLS.fnQuerySelectDs(strq1)
            Dim stid1 As Integer = CInt(dsStid1.Tables(0).Rows(0)("stid").ToString())
            Dim strq As String = "select max(StuLogId) as StuLogId from StudentLoginHistory where stid=" & stid1 & ""
            Dim dsStid As New DataSet()
            dsStid = CLS.fnQuerySelectDs(strq)
            Dim LogId As Integer = CInt(dsStid.Tables(0).Rows(0)("StuLogId").ToString())
            Dim strLogin As String = "update StudentLoginHistory set LoginOut='" & System.DateTime.Now & "', Status=0 where StuLogId=" & LogId
            CLS.fnExecuteQuery(strLogin)
            Response.Redirect("../logout.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub news()

    End Sub
    Protected Sub btnExamset_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExamset.Click
        Try
            Dim sessVal As String = Session("username").ToString()
            Dim str_StID As String = "select stid from Student where email='" & sessVal & "'"
            Dim dsStID As New DataSet()
            dsStID = CLS.fnQuerySelectDsGrv(str_StID)
            Dim StID As Integer = 0
            Dim StID_Suppl As Integer = 0
            Dim BID As Integer = 0
            Dim Paperid_Suppl As String = ""
            Dim Paperid As String = ""
            Dim Str_Examid As String = ""
            Dim Examid As Integer = 0
            ''''''''''''''''''''''''''''''''''''''''''''**************New Code 14/01/2014 Start*******************''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''StudentPaperMarks if Begin'''''''''
            If dsStID.Tables(0) IsNot Nothing Then
                If dsStID.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To dsStID.Tables(0).Rows.Count - 1
                        'StID = StID + Convert.ToInt32(dsStID.Tables(0).Rows(i)("stid").ToString())
                        StID = Convert.ToInt32(dsStID.Tables(0).Rows(i)("stid").ToString())
                    Next
                    'Dim str_BID As String = "select distinct bid from StudentPaperMarks where stid=" & StID
                    Dim str_BID As String = "select distinct bid from StudentRegBatch where stid=" & StID
                    Dim dsBID As New DataSet()
                    dsBID = CLS.fnQuerySelectDsGrv(str_BID)
                    '''''Batch if Begin'''''''''
                    If dsBID.Tables(0) IsNot Nothing Then
                        If dsBID.Tables(0).Rows.Count > 0 Then
                            For j As Integer = 0 To dsBID.Tables(0).Rows.Count - 1
                                BID = Convert.ToInt32(dsBID.Tables(0).Rows(j)("bid").ToString())
                            Next
                            
                            'Dim str_StID_Suppl As String = "select distinct stid from studentpapermarks where bid=" & BID & ""
                            Dim str_StID_Suppl As String = "select distinct stid from studentpapermarks where stid=" & StID & ""
                            Dim dsStID_Suppl As New DataSet()
                            dsStID_Suppl = CLS.fnQuerySelectDsGrv(str_StID_Suppl)
                            If dsStID_Suppl.Tables(0) IsNot Nothing Then
                                If dsStID_Suppl.Tables(0).Rows.Count > 0 Then
                                    For i As Integer = 0 To dsStID_Suppl.Tables(0).Rows.Count - 1
                                        'StID_Suppl = StID_Suppl + Convert.ToInt32(dsStID_Suppl.Tables(0).Rows(i)("stid").ToString())
                                        StID_Suppl = Convert.ToInt32(dsStID_Suppl.Tables(0).Rows(i)("stid").ToString())
                                    Next
                                    If dsStID_Suppl.Tables(0) IsNot Nothing AndAlso dsStID.Tables(0) IsNot Nothing Then
                                        'Dim str_paperID_Suppl As String = "Select distinct paperId from StudentPaperMarks where stid=" & StID & " and bid=" & BID & " and Examstatus=0"
                                        Dim str_examID_Suppl As String = "Select distinct ExamId from StudentSupplyExamAssign where stid=" & StID & " and bid=" & BID & ""
                                        'Dim dsPaperid_Suppl As New DataSet()
                                        Dim dsExamId_Suppl As New DataSet()
                                        dsExamId_Suppl = CLS.fnQuerySelectDsGrv(str_examID_Suppl)
                                        '''''Paper if Begin (26-02-2014) Begin'''''''''
                                        'Dim str_examID_Suppl_1 As String = "select distinct ExamId from examset where examid not in (select distinct ExamId from StudentPaperMarks inner join examset on examset.paperid=StudentPaperMarks.paperid where examset.examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "') and StudentPaperMarks.stid=" & StID & " and StudentPaperMarks.examstatus=0) and examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "')"
                                        Dim str_examID_Suppl_1 As String = "select distinct ExamId from examset where examid not in (select distinct ExamId from StudentPaperMarks inner join examset on examset.paperid=StudentPaperMarks.paperid where examset.examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "') and StudentPaperMarks.stid=" & StID & ") and examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "')"
                                        Dim dsExamId_Suppl_1 As New DataSet()
                                        dsExamId_Suppl_1 = CLS.fnQuerySelectDsGrv(str_examID_Suppl_1)
                                        '''''Paper if Begin (26-02-2014) End'''''''''
                                        If dsExamId_Suppl_1.Tables(0) IsNot Nothing Then
                                            If dsExamId_Suppl_1.Tables(0).Rows.Count > 0 Then
                                                For k As Integer = 0 To dsExamId_Suppl_1.Tables(0).Rows.Count - 1
                                                    Paperid_Suppl = Paperid_Suppl + dsExamId_Suppl_1.Tables(0).Rows(k)("ExamId").ToString() + ","
                                                Next
                                            End If
                                            If dsExamId_Suppl.Tables(0).Rows.Count > 0 Then
                                                For k As Integer = 0 To dsExamId_Suppl.Tables(0).Rows.Count - 1
                                                    'Paperid_Suppl = Paperid_Suppl + dsPaperid_Suppl.Tables(0).Rows(k)("paperId").ToString() + ","
                                                    Paperid_Suppl = Paperid_Suppl + dsExamId_Suppl.Tables(0).Rows(k)("ExamId").ToString() + ","
                                                Next
                                            End If
                                        Else
                                            Paperid_Suppl = "0"
                                        End If

                                        '''''Paper if End'''''''''
                                        Response.Redirect("ExamSet.aspx?STID=" + StID_Suppl.ToString() + "&Bid=" + BID.ToString() + "&pid=" & Paperid_Suppl.ToString())
                                    Else
                                        Response.Redirect("ExamSet.aspx")
                                    End If
                                End If
                            End If
                            ''''''''''''''''New Something
                            'If dsStID_Suppl.Tables(0) Is Nothing AndAlso dsStID.Tables(0) IsNot Nothing Then
                            If dsStID.Tables(0) IsNot Nothing AndAlso StID_Suppl = 0 Then
                                'Dim str_paperID As String = "select distinct PaperId from examset where examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "') order by PaperId"
                                Dim str_ExamID1 As String = "select distinct ExamId from examset where examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "') order by ExamId"
                                Dim dsExamId As New DataSet()
                                'dsPaperid = CLS.fnQuerySelectDsGrv(str_paperID)
                                dsExamId = CLS.fnQuerySelectDsGrv(str_ExamID1)

                                '''''Paper if Begin'''''''''
                                If dsExamId.Tables(0) IsNot Nothing Then
                                    If dsExamId.Tables(0).Rows.Count > 0 Then
                                        For x As Integer = 0 To dsExamId.Tables(0).Rows.Count - 1
                                            Paperid = Paperid + dsExamId.Tables(0).Rows(x)("ExamId").ToString() + ","
                                        Next
                                    Else
                                        Paperid = "0,"
                                    End If
                                End If
                                '''''Paper if End'''''''''

                                Response.Redirect("ExamSet.aspx?STID=" + StID.ToString() + "&Bid=" + BID.ToString() + "&pid=" & Paperid.ToString())
                            Else
                                Response.Redirect("ExamSet.aspx")
                            End If


                            'If a IsNot Nothing AndAlso c Is Nothing Then

                            'ElseIf b = c Then
                            'Else
                            'End If
                        End If
                    End If
                    '''''Batch if End'''''''''
                End If
            End If
            '''''StudentPaperMarks if End'''''''''




            'If a IsNot Nothing AndAlso c Is Nothing Then

            'ElseIf b = c Then
            'Else
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''**************New Code 14/01/2014 End*******************''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''22'''''''''''''''''''''''''''''**************Important Start*******************''''''''''''''''''''''''''''''''''''''''''''''''''
            'If dsStID.Tables(0) IsNot Nothing Then
            '    If dsStID.Tables(0).Rows.Count > 0 Then
            '        For i As Integer = 0 To dsStID.Tables(0).Rows.Count - 1
            '            StID = StID + Convert.ToInt32(dsStID.Tables(0).Rows(i)("stid").ToString())
            '        Next
            'Dim str_BID As String = "select distinct bid from StudentPaperMarks where stid=" & StID
            ''Dim str_BID As String = "select distinct bid from StudentRegBatch where stid=" & StID
            'Dim dsBID As New DataSet()
            'dsBID = CLS.fnQuerySelectDsGrv(str_BID)
            'If dsBID.Tables(0) IsNot Nothing Then
            '    If dsBID.Tables(0).Rows.Count > 0 Then
            'For j As Integer = 0 To dsBID.Tables(0).Rows.Count - 1
            '    BID = BID + Convert.ToInt32(dsBID.Tables(0).Rows(j)("bid").ToString())
            'Next
            'Dim str_paperID As String = "Select distinct paperId from StudentPaperMarks where stid=" & StID & " and bid=" & BID & " and Examstatus=0"
            'Dim dsPaperid As New DataSet()
            'dsPaperid = CLS.fnQuerySelectDsGrv(str_paperID)
            'If dsPaperid.Tables(0) IsNot Nothing Then
            '    If dsPaperid.Tables(0).Rows.Count > 0 Then
            '        For k As Integer = 0 To dsPaperid.Tables(0).Rows.Count - 1
            '            Paperid = Paperid + dsPaperid.Tables(0).Rows(k)("paperId").ToString() + ","
            '        Next


            'ElseIf
            'Else
            'Paperid = "0"
            'End If
            'End If
            ''Else
            '    End If
            'Response.Redirect("ExamSet.aspx?STID=" + StID.ToString() + "&Bid=" + BID.ToString() + "&pid=" & Paperid.ToString())
            'End If
            '    Else
            'Response.Redirect("ExamSet.aspx")
            '    End If
            'End If
            'End If
        Catch ex As Exception
        End Try
        ''''''''''''''''''22''''''''''''''''''''''''''**************Important End*******************''''''''''''''''''''''''''''''''''''''''''''''''''





        'Dim str_examID As String = "Select distinct examid from ActivateExam where bid=" & BID & ""
        'Dim dsExamId As New DataSet()
        'dsExamId = CLS.fnQuerySelectDsGrv(str_examID)
        'If dsExamId.Tables(0) IsNot Nothing Then
        '    If dsExamId.Tables(0).Rows.Count > 0 Then
        '        For a As Integer = 0 To dsExamId.Tables(0).Rows.Count - 1
        '            Examid = Examid + dsExamId.Tables(0).Rows(a)("examid").ToString() + ","
        '        Next
        '        Examid = Examid.Remove(Examid.Length - 1)
        '        Dim str_PaperId_examID As String = "Select distinct paperid from examset where examid in (" & Examid & ")"
        '        Dim ds_PaperId_ExamId As New DataSet()
        '        ds_PaperId_ExamId = CLS.fnQuerySelectDsGrv(str_PaperId_examID)
        '        If ds_PaperId_ExamId.Tables(0) IsNot Nothing Then
        '            If ds_PaperId_ExamId.Tables(0).Rows.Count > 0 Then
        '                For b As Integer = 0 To ds_PaperId_ExamId.Tables(0).Rows.Count - 1
        '                    Paperid = Paperid + ds_PaperId_ExamId.Tables(0).Rows(b)("paperId").ToString() + ","
        '                Next
        '            Else
        '                Paperid = "0"
        '            End If
        '        End If
        '    End If

        'Response.Redirect("ExamSet.aspx")
    End Sub

    'Protected Sub btnExamset_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExamset.Click
    '    Try
    '        Dim sessVal As String = Session("username").ToString()
    '        Dim str_StID As String = "select stid from Student where email='" & sessVal & "'"
    '        Dim dsStID As New DataSet()
    '        dsStID = CLS.fnQuerySelectDsGrv(str_StID)
    '        Dim StID As Integer = 0
    '        Dim BID As Integer = 0
    '        If dsStID.Tables(0) IsNot Nothing Then
    '            If dsStID.Tables(0).Rows.Count > 0 Then
    '                For i As Integer = 0 To dsStID.Tables(0).Rows.Count - 1
    '                    StID = StID + Convert.ToInt32(dsStID.Tables(0).Rows(i)("stid").ToString())
    '                Next
    '                Dim str_BID As String = "select distinct bid from StudentPaperMarks where stid=" & StID
    '                Dim dsBID As New DataSet()
    '                dsBID = CLS.fnQuerySelectDsGrv(str_BID)
    '                If dsBID.Tables(0) IsNot Nothing Then
    '                    If dsBID.Tables(0).Rows.Count > 0 Then
    '                        For j As Integer = 0 To dsBID.Tables(0).Rows.Count - 1
    '                            BID = BID + Convert.ToInt32(dsBID.Tables(0).Rows(j)("bid").ToString())
    '                        Next
    '                    End If
    '                End If
    '                Response.Redirect("ExamSet.aspx?STID=" + StID.ToString() + "&Bid=" + BID.ToString())
    '            End If
    '        Else
    '            Response.Redirect("ExamSet.aspx")
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    'Response.Redirect("ExamSet.aspx")
    'End Sub

    Protected Sub btnIDCard_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIDCard.Click
        Try
            Dim sessVal As String = Session("username").ToString()
            Dim str_StID As String = "select stid from Student where email='" & sessVal & "'"
            Dim dsStID As New DataSet()
            dsStID = CLS.fnQuerySelectDsGrv(str_StID)
            Dim StID As Integer = 0
            Dim StID_Suppl As Integer = 0
            Dim BID As Integer = 0
            Dim Paperid_Suppl As String = ""
            Dim Paperid As String = ""
            Dim Str_Examid As String = ""
            Dim Examid As Integer = 0

            If dsStID.Tables(0) IsNot Nothing Then
                If dsStID.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To dsStID.Tables(0).Rows.Count - 1
                        StID = Convert.ToInt32(dsStID.Tables(0).Rows(i)("stid").ToString())
                    Next
                    Dim str_BID As String = "select distinct bid from StudentRegBatch where stid=" & StID
                    Dim dsBID As New DataSet()
                    dsBID = CLS.fnQuerySelectDsGrv(str_BID)
                    '''''Batch if Begin'''''''''
                    If dsBID.Tables(0) IsNot Nothing Then
                        If dsBID.Tables(0).Rows.Count > 0 Then
                            For j As Integer = 0 To dsBID.Tables(0).Rows.Count - 1
                                BID = Convert.ToInt32(dsBID.Tables(0).Rows(j)("bid").ToString())
                            Next

                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "window.openPopup('StudentIDCard.aspx?stid=" & StID & "&bid=" & BID & "');", True)

                        End If
                        '''''Batch if End'''''''''
                    End If
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub


    Sub bindNotifications()

        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@stid", Session("stid")))
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSPDataSet("SP_NotificationList", objParamList)
            If ds IsNot Nothing Then
                If ds.Tables IsNot Nothing Then
                    If ds.Tables(0).Rows IsNot Nothing Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            rptNotification.DataSource = ds
                            rptNotification.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub bindDemoVideo()

        Dim objParamList As New List(Of OleDbParameter)()
        Try

            Dim strq As String = "select TOP 1 * from DemoManual where type='Video' and checked=1"
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strq)

            If ds.Tables(0).Rows.Count > 0 Then

                lnkDemoVideo.Visible = True
                lblCaption.Text = ds.Tables(0).Rows(0)("Caption").ToString()
                Dim strPath As String = ds.Tables(0).Rows(0)("filepath").ToString()
                ViewState("Play") = "../" & strPath

            Else
                lnkDemoVideo.Visible = False

            End If

        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnShowMsg_Click(sender As Object, e As EventArgs) Handles btnShowMsg.Click
    '    dvMsg.Visible = True
    '    lblMsg.Text = "This is notification message demo"
    'End Sub
    Protected Sub lnkDemoVideo_Click(sender As Object, e As EventArgs)
        ifrm.Attributes.Add("src", ViewState("Play"))
        ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayVideo'); </script>")
    End Sub
End Class
