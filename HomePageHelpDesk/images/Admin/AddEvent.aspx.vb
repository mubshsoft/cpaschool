Imports fmsf.DAL
Imports fmsf.lib
Partial Class Admin_AddEvent
    Inherits System.Web.UI.Page
    Dim objLibNews As New LIBNews
    Dim objDalNews As New DalAddNews
    Dim objLibErr As New libErrorMsg

   
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
            If Request.QueryString("eid") IsNot Nothing Then
                FillData()
            End If
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnvalidate()
            If objLibErr.ChkReturn = True Then
                objLibNews.EventTitle = Trim(txtTitle.Text)
                objLibNews.EventDesc = Trim(txtDesc.Text)
                objLibNews.EventDate = Trim(txtDate.Text)
                If Request.QueryString("eid") IsNot Nothing Then
                    ViewState("s") = Request.QueryString("eid")
                End If
                If Len(ViewState("s")) > 0 Then
                    objLibNews.EventId = ViewState("s")
                Else
                    objLibNews.EventId = 0
                End If
                Dim retVal As Int16 = objDalNews.InsertEvent(objLibNews)

                If retVal = -11 Then
                    lblMessage.Text = "Event already  exist"
                    Exit Sub
                ElseIf retVal = -3 Then
                    lblMessage.Text = "Event already  exist"
                    Exit Sub
                ElseIf retVal = 1 Then
                    Response.Redirect("ListEvent.aspx")
                ElseIf retVal = 2 Then
                    Response.Redirect("ListEvent.aspx")
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
        If Len(Trim(txtTitle.Text)) <= 0 Then
            ObjErrDal.errMessage = "Event Title cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If
        If Len(Trim(txtDesc.Text)) <= 0 Then
            ObjErrDal.errMessage = "Event Description cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(txtDate.Text) > 0 Then
            Dim d As DateTime
            Try
                d = DateTime.Parse(txtDate.Text)
            Catch ex As Exception
                ObjErrDal.errMessage = "Invalid date!format should be mm/dd/yyyy"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End Try
        Else
            ObjErrDal.errMessage = "Date cannot be left blank"
        End If


        If Len(txtDate.Text) > 0 Then
            Dim d As Date
            Try
                d = txtDate.Text
                If d < Date.Now.Date Then
                    ObjErrDal.errMessage = "Event Date should be greater than current date."
                    ObjErrDal.ChkReturn = False
                    Return ObjErrDal
                End If
            Catch ex As Exception

            End Try
        End If

        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Sub FillData()
        Dim strq As String = "select eventid,eventtitle,eventdesc ,CONVERT(varchar, EventDate, 101) as EventDate from event where EventId=" & Request.QueryString("eid")
        Dim dsNews As New DataSet()
        dsNews = CLS.fnQuerySelectDs(strq)
        txtTitle.Text = dsNews.Tables(0).Rows(0)("EventTitle").ToString()
        txtDesc.Text = dsNews.Tables(0).Rows(0)("EventDesc").ToString()
        txtDate.Text = dsNews.Tables(0).Rows(0)("EventDate").ToString()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("listevent.aspx")
    End Sub
End Class
