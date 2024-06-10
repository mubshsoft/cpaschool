Imports fmsf.DAL
Imports fmsf.lib
Partial Class Admin_AddNews
    Inherits System.Web.UI.Page
    Dim objLibNews As New LIBNews
    Dim objDalNews As New DalAddNews
    Dim objLibErr As New libErrorMsg
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnvalidate()
            If objLibErr.ChkReturn = True Then
                objLibNews.NewsType = Trim(ddlNewsType.SelectedValue.ToString)
                objLibNews.NewsDesc = Trim(txtNews.Text)
                Try
                    objLibNews.batchid = Trim(DdlBatch.SelectedValue)
                Catch ex As Exception
                    objLibNews.batchid = 0
                End Try
                Try
                    objLibNews.courseid = Trim(DdlCourse.SelectedValue)
                Catch ex As Exception
                    objLibNews.courseid = 0
                End Try
                If Request.QueryString("id") IsNot Nothing Then
                    ViewState("s") = Request.QueryString("id")
                End If
                If Len(ViewState("s")) > 0 Then
                    objLibNews.NewsId = ViewState("s")
                Else
                    objLibNews.NewsId = 0
                End If
                Dim retVal As Int16 = objDalNews.InsertNews(objLibNews)

                If retVal = -11 Then
                    lblMessage.Text = "News already  exist"
                    Exit Sub
                ElseIf retVal = -3 Then
                    lblMessage.Text = "News already  exist"
                    Exit Sub
                ElseIf retVal = 1 Then
                    Response.Redirect("listNews.aspx")
                ElseIf retVal = 2 Then
                    Response.Redirect("listNews.aspx")
                ElseIf retVal = MyCLS.EStatus.Err Then
                    MyCLS.fnMSG("Error Occured!")
                End If
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function fnvalidate() As Object
        Dim ObjErrDal As New libErrorMsg
        If Len(Trim(txtNews.Text)) <= 0 Then
            ObjErrDal.errMessage = "News description cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If
        If ddlNewsType.SelectedValue = "Select" Then
            ObjErrDal.errMessage = "Please select news type"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If
        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Sub FillData()
        Try
            Dim strq As String = "select * from news where NewsId=" & Request.QueryString("id")
            Dim dsNews As New DataSet()
            dsNews = CLS.fnQuerySelectDs(strq)
            ddlNewsType.SelectedIndex = ddlNewsType.Items.IndexOf(ddlNewsType.Items.FindByValue(dsNews.Tables(0).Rows(0)("NewsType").ToString))
            'ddlNewsType.SelectedItem.Text = dsNews.Tables(0).Rows(0)("NewsType").ToString()
            txtNews.Text = dsNews.Tables(0).Rows(0)("NewsDesc").ToString()
            FillDDl()
            DdlCourse.SelectedIndex = DdlCourse.Items.IndexOf(DdlCourse.Items.FindByValue(dsNews.Tables(0).Rows(0)("course").ToString))
            FillBatch1()
            DdlBatch.SelectedIndex = DdlBatch.Items.IndexOf(DdlBatch.Items.FindByValue(dsNews.Tables(0).Rows(0)("batch").ToString))
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        If Not IsPostBack Then
            If Request.QueryString("id") IsNot Nothing Then
                FillData()
            End If
        End If
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("ListNews.aspx")
    End Sub
    Private Sub FillDDl()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
        MyCLS.ConClose()
    End Sub
    Private Sub FillBatch()
        Try
            Dim strBatch As String = "select distinct(b.BatchCode),bt.bid from batch b INNER JOIN StudentRegBatch bt on b.bid=bt.bid where bt.courseid=" & DdlCourse.SelectedValue
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

    Protected Sub ddlNewsType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlNewsType.SelectedIndexChanged
        If ddlNewsType.SelectedItem.Text = "General" Then
            DdlBatch.Enabled = False
            DdlCourse.Enabled = False
        ElseIf ddlNewsType.SelectedItem.Text = "Course" Then
            DdlBatch.Enabled = False
            DdlCourse.Enabled = True
            FillDDl()
        ElseIf ddlNewsType.SelectedItem.Text = "Batch" Then
            DdlBatch.Enabled = True
            FillDDl()
            DdlCourse.SelectedIndex = 0
            DdlCourse.Enabled = False
            FillBatch1()
        End If
    End Sub

    Protected Sub DdlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCourse.SelectedIndexChanged
        FillBatch()
    End Sub
    Private Sub FillBatch1()
        Try
            Dim strBatch As String = "select BatchCode,bid from batch"
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strBatch)
            DdlBatch.DataSource = dsbatch
            DdlBatch.DataTextField = "BatchCode"
            DdlBatch.DataValueField = "bid"
            DdlBatch.DataBind()
            DdlBatch.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

   
End Class
