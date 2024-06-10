Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Partial Class Admin_ListvideoConfrence
    Inherits System.Web.UI.Page
    Dim stid As String = ""
    Dim stid1 As String = ""
    Dim st As String = ""
    Dim st1 As String = ""
    Dim strEmail As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")

            End If
            If Not IsPostBack Then

                MyCLS.ConOpen()
                FillDDl()

                MyCLS.ConClose()

                bindgrid1()
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FillDDl()
        Try
            MyCLS.ConOpen()
            MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
            MyCLS.ConClose()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub FillBatch()
        Try


            Dim strBatch As String = "select distinct(b.BatchCode),bt.bid from batch b INNER JOIN StudentRegBatch bt on b.bid=bt.bid where bt.courseid=" & ddlCourse.SelectedValue
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
   

    Sub bindgrid1()
        Try
            Dim CID As String = "0"
            Dim BID As String = "0"
            Dim SID As String = "0"
            Dim fromdt As String = ""
            Dim todt As String = ""
            If (ddlCourse.SelectedIndex > 0) Then
                CID = ddlCourse.SelectedValue

            End If
            If (ddlBatch.SelectedIndex > 0) Then
                BID = ddlBatch.SelectedValue.Trim()

            End If
         
            If (txtto.Text <> "") Then
                todt = txtto.Text


            End If
            If (txtfrom.Text <> "") Then
                fromdt = txtfrom.Text

            End If
            Dim strq As String = "SP_GetVideoconfrencedetails " & CID & "," & BID & "," & SID & ",'" & txtfrom.Text & "','" & txtto.Text & "'"



            'Dim strq As String = "select * from batch"

            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            GrdList.DataSource = dsbatch
            GrdList.DataBind()
            'If dsbatch IsNot Nothing Then
            '    If dsbatch.Tables IsNot Nothing Then
            '        If dsbatch.Tables(0).Rows IsNot Nothing Then
            '            If dsbatch.Tables(0).Rows.Count > 0 Then
            '                GrdList.DataSource = dsbatch
            '                GrdList.DataBind()
            '                GrdList.Visible = True
            '            Else
            '                ' lblMessage.Text = "No batch is created for this course"
            '                'GrdBatch.Visible = False
            '            End If
            '        End If
            '    End If
            'End If
        Catch ex As Exception
        End Try
    End Sub

    



    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        Try
          
            bindgrid1()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        Try
            FillBatch()

            If ddlCourse.SelectedItem.Text = "--Select--" Then
                ddlBatch.SelectedIndex = 0
            End If

            If ddlBatch.Items.Count > 0 Then
                ddlBatch.SelectedIndex = 0
            End If
         
            bindgrid1()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdList_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdList.PageIndex = e.NewPageIndex

        bindgrid1()

    End Sub

    Public Shared Sub ExeNQcomsp(ByVal strQ As String)

        Try

            CLS.ConOpen()
            CLS.fnExecuteQuery(strQ)
            CLS.ConClose()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("ConferencePanel.aspx", False)
    End Sub
    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        bindgrid1()
    End Sub

End Class
