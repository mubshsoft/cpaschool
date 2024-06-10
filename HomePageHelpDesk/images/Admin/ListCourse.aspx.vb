Imports System.IO
Imports System.Web

Partial Class ListCourse
    Inherits System.Web.UI.Page    
    Dim semid As Integer
    Dim mid As Integer
    Dim pid As Integer
    Dim Ccode As String
    Dim Stitle As String
    Dim Mtitle As String
    Dim Ptitle As String
    Dim uid As String
    Dim strPathOld As String
    Dim PFile As String
    Dim cid As Integer
    Dim gvUniqueID As String = String.Empty
    Dim gvHidenID As String = String.Empty

    Dim gvCourseID As String = String.Empty
    Dim gvSemID As String = String.Empty
    Dim gvModuleID As String = String.Empty
    Dim gvPaperID As String = String.Empty
    ' Public Shared d As Integer = -1


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            'If (d = 1) Then
            '    Session("username") = "admin"
            '    Session("role") = "Admin"
            'End If
            If Request.Cookies("un") IsNot Nothing Then
                If Request.Cookies("un").Value <> "" Then
                    Session("username") = Request.Cookies("un").Value
                End If
            End If
            If Request.Cookies("r") IsNot Nothing Then
                If Request.Cookies("r").Value <> "" Then
                    Session("role") = Request.Cookies("r").Value
                End If
            End If

            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            Else                
                If Session("role") = "Admin" Then

                Else
                    Response.Redirect("../login.aspx")
                End If
                End If
                cid = Request.QueryString("cid")
                If Not IsPostBack Then
                    'If Len(Session("mid")) > 0 Then
                    '    bindgrid()
                    '    GrandChildGridBind(Request.QueryString("sid"), Request.QueryString("cid"))
                    '    Response.Write("<script>javascript:expandcollapse('divParent1', 'one');</script>")
                    '    '    'Response.Write("<script>javascript:disp();</script>")
                    '    Exit Sub
                    'End If
                    bindgrid()
                End If
        Catch ex As Exception

        End Try
    End Sub

    Sub bindgrid()
        Try
            Dim strq As String = "select * from course"
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strq)
            GrdCourse.DataSource = ds
            GrdCourse.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdSemester_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                'For Each c In e.Row.Cells
                Try
                    'Dim lnkAddSemester As New LinkButton
                    'lnkAddSemester.Text = "Add Semester"
                    'lnkAddSemester.ID = "lnk1"
                    'AddHandler lnkAddSemester.Click, AddressOf onSelectSemester
                    Dim dsCourseTitle As New DataSet
                    dsCourseTitle = CLS.fnQuerySelectDs("select * from course where courseid=" & cid)
                    e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Left
                    e.Row.Cells(3).Text = "Course Code:" & dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString
                    'e.Row.Cells(4).Controls.Add(lnkAddSemester)
                Catch ex As Exception
                End Try
                ' Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Protected Sub onSelectSemester(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        MsgBox(cid)
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub grdSemester_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            ' Make sure we aren't in header/footer rows 


            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            Dim gv1 As New GridView()
            gv1 = DirectCast(row.FindControl("grdModule"), GridView)
            Dim lblSemID As Label = DirectCast(e.Row.FindControl("lblSemID"), Label)
            ViewState("lblSemID") = lblSemID.Text

            Dim lblCourseID As Label = DirectCast(e.Row.FindControl("lblCourseID"), Label)
            ViewState("lblCourseID") = lblCourseID.Text

            Dim ds1 As New DataSet()

            ds1 = GrandChildGridBind(DirectCast(e.Row.DataItem, DataRowView)("SemID").ToString(), ViewState("lblCourseID").ToString())
            gv1.DataSource = ds1
            gv1.DataBind()

            If lblSemID.Text = gvSemID Then
                Try
                    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');</script>")

                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception
        End Try


    End Sub


    Private Function GrandChildGridBind(ByVal SemID As String, ByVal CourseID As String) As DataSet
        'Dim str As String = "select ModuleID,ModuleTitle from Module where SemID=" & Integer.Parse(SemID) & " and CourseID=" & Integer.Parse(CourseID) & ""
        Try
            Dim str As String = "select module.semid,ModuleID,ModuleTitle,semester.CourseID from Module inner join semester on Module.SemID=semester.SemID where semester.SemID=" & Integer.Parse(SemID) & " and semester.CourseID=" & Integer.Parse(CourseID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(str)
            Return ds
        Catch ex As Exception
        End Try
    End Function


    Private Function GridBind_paper(ByVal ModuleId As String, ByVal SemID As String) As DataSet
        'SqlConnection con = new SqlConnection("Data Source=TSI_08;Initial Catalog=fmsf;uid=sa;pwd=sa123"); 
        'Dim str As String = "select * from paper where ModuleId=" & Integer.Parse(ModuleId) & " and SemID=" + Integer.Parse(SemID) & " "
        Dim dsPaper As New DataSet
        Try
            'Dim strQ As String = "select paper.paperID,paper.PaperTitle,Module.SemID,Module.ModuleId from paper inner join Module on paper.ModuleId=Module.ModuleId where paper.ModuleId=" & Integer.Parse(ModuleId) & " and Module.SemID=" & Integer.Parse(SemID) & ""
            Dim strQ As String = "select Courseid=(select CourseId from Semester where Semid=Module.SemID),paper.paperID,paper.PaperTitle,Module.SemID,Module.ModuleId from paper inner join Module on paper.ModuleId=Module.ModuleId where paper.ModuleId=" & Integer.Parse(ModuleId) & " and Module.SemID=" & Integer.Parse(SemID) & ""

            dsPaper = CLS.fnQuerySelectDs(strQ)
        Catch ex As Exception
        End Try
        Return dsPaper
    End Function
    Protected Sub GrdModule_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            ' Make sure we aren't in header/footer rows 
            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            Dim gv3 As New GridView()
            gv3 = DirectCast(row.FindControl("GrdPaper"), GridView)
            Dim lblModuleID As Label = DirectCast(e.Row.FindControl("lblModuleID"), Label)
            ViewState("lblModuleID") = lblModuleID.Text
            Dim ds3 As New DataSet()
            'ds1 = GrandChildGridBind(((DataRowView)e.Row.DataItem)["SemID"].ToString()); 
            ds3 = GridBind_paper(DirectCast(e.Row.DataItem, DataRowView)("ModuleId").ToString(), ViewState("lblSemID").ToString())
            gv3.DataSource = ds3
            gv3.DataBind()

            If lblModuleID.Text = gvModuleID Then
                Try
                    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');expandcollapse('divChild" + gvModuleID + "');</script>")

                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdPaper_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            ' Make sure we aren't in header/footer rows 
            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            Dim gv4 As New GridView()
            gv4 = DirectCast(row.FindControl("grdUnit"), GridView)

            Dim ds4 As New DataSet()
            'ds1 = GrandChildGridBind(((DataRowView)e.Row.DataItem)["SemID"].ToString()); 
            ds4 = GridBind_Unit(DirectCast(e.Row.DataItem, DataRowView)("PaperID").ToString(), ViewState("lblModuleID").ToString(), ViewState("lblSemID").ToString())
            gv4.DataSource = ds4
            gv4.DataBind()
            'Dim gv As GridView = DirectCast(sender, GridView)
            'Dim hdnParentId As HiddenField = DirectCast(gv.Rows(0).FindControl("hdnParentId"), HiddenField)
            'Dim hdnModuleID As HiddenField = DirectCast(gv.Rows(0).FindControl("hdnModuleID"), HiddenField)
            'Dim hdnSemID As HiddenField = DirectCast(gv.Rows(0).FindControl("hdnSemID"), HiddenField)

            'Try
            '    'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');expandcollapse('divChild" + gvModuleID + "');expandcollapse('divGrandChild" + gvPaperID + "');expandcollapse('div" + gvPaperID + gvModuleID + gvSemID + "');</script>")
            '    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');expandcollapse('divChild" + gvModuleID + "');expandcollapse('divGrandChild" + gvPaperID + "');</script>")
            'Catch ex As Exception

            'End Try



            'If DirectCast(e.Row.DataItem, DataRowView)("PaperID").ToString() = gvPaperID Then
            '    Try
            '        ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');expandcollapse('divChild" + gvModuleID + "');expandcollapse('divGrandChild" + gvPaperID + "');</script>")

            '    Catch ex As Exception

            '    End Try

            'End If


        Catch ex As Exception
        End Try
    End Sub
    Private Function GridBind_Unit(ByVal PaperID As String, ByVal ModuleId As String, ByVal SemID As String) As DataSet
        'Dim str As String = (("select * from Unit where PaperID=" & Integer.Parse(PaperID) & " and ModuleId=") + Integer.Parse(ModuleId) & " and SemID=") + Integer.Parse(SemID) & " "
        Try
            Dim strq As String = "select module.moduleid,unit.paperid,Unit.UnitId,Unit.UnitTitle,Semester.SemID,Semester.CourseID,UploadFilePath from Unit inner join paper on Unit.PaperID=paper.PaperID inner join Module on paper.ModuleId=Module.ModuleId inner join Semester on Module.SemID=Semester.SemID where paper.PaperID=" & Integer.Parse(PaperID) & " and Module.ModuleId=" & Integer.Parse(ModuleId) & " and Semester.SemID=" & Integer.Parse(SemID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strq)
            Return ds
        Catch ex As Exception
        End Try
    End Function

    Protected Sub GrdCourse_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdCourse.PageIndexChanging
        GrdCourse.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Protected Sub GrdCourse_RowCommand1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdCourse.RowCommand
        Try
            If e.CommandName = "Delete" Then
                Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim strq As String = "select * from Semester where courseID in (select  courseID from course where CourseID=" & id & ")"
                Dim ds As New DataSet()
                ds = CLS.fnQuerySelectDs(strq)
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblMessage.Text = "Cannot be deleted"
                Else

                    ''''''''''''''' 4 july,2009 ''''''''''''''

                    Dim sqlDeletesemesterfolder As String = "select coursecode from course where courseID=" & id
                    Dim dsDeletsemesterfolder As New DataSet()
                    dsDeletsemesterfolder = CLS.fnQuerySelectDs(sqlDeletesemesterfolder)
                    If (dsDeletsemesterfolder.Tables(0).Rows.Count > 0) Then
                        Ccode = dsDeletsemesterfolder.Tables(0).Rows(0)("CourseCode").ToString()

                    End If


                    Dim strPath As String = Server.MapPath("..\") & "upload\" & Ccode
                    If Directory.Exists(strPath) Then
                        ' for delete folder solution 
                        Response.Cookies("un").Value = Session("username").ToString()
                        Response.Cookies("un").Expires.AddDays(1)
                        Response.Cookies("r").Value = Session("role").ToString()
                        Response.Cookies("r").Expires.AddDays(1)

                        Directory.Delete(Server.MapPath("..\") & "upload\" & Ccode)
                        Dim str As String = "delete from course where CourseId=" & id
                        ExeNQcomsp(str)
                        bindgrid()
                        lblMessage.Text = "Record deleted successfully"
                        lblMessage.ForeColor = Drawing.Color.DarkGreen
                    End If
                    ''''''''''''''' 4 july,2009 ''''''''''''''

                    'Dim str As String = "delete from course where CourseId=" & id
                    'ExeNQcomsp(str)

                    'bindgrid()
                    'lblMessage.Text = "Record deleted successfully"
                    'lblMessage.ForeColor = Drawing.Color.DarkGreen
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdCourse_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles GrdCourse.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If DirectCast(e.Row.DataItem, DataRowView)("courseID").ToString() = [String].Empty Then
                    e.Row.Visible = False
                End If
            End If
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            ' Make sure we aren't in header/footer rows 
            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            'Find Child GridView control 
            Dim gv As New GridView()


            '' ClientScript.RegisterStartupScript([GetType](), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" & DirectCast(e.Row.DataItem, DataRowView)("courseID").ToString() & "','one');</script>")



            gv = DirectCast(row.FindControl("grdSemester"), GridView)
            Dim lblCourseid As Label = DirectCast(e.Row.FindControl("lblCourseid"), Label)
            ViewState("lblCourseid") = lblCourseid.Text
            Dim dss As New DataSet()
            'dss = ChildGridBind(((DataRowView)e.Row.DataItem)["CourseID"].ToString()); 
            dss = ChildGridBind(DirectCast(e.Row.DataItem, DataRowView)("CourseID").ToString())
            gv.DataSource = dss
            gv.DataBind()
            ' added by chhaya 19 dec 2009
            'If DirectCast(e.Row.DataItem, DataRowView)("courseID").ToString() = gvCourseID Then
            '    Try
            '        ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + DirectCast(e.Row.DataItem, DataRowView)("CourseID").ToString() + "');</script>")

            '    Catch ex As Exception

            '    End Try

            'End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ChildGridBind(ByVal cid As String) As DataSet
        'SqlConnection con = new SqlConnection("Data Source=TSI_08;Initial Catalog=fmsf;uid=sa;pwd=sa123"); 
        Try
            Dim strq As String = "select courseid,SemId,SemesterTitle from semester where CourseID=" & Integer.Parse(cid)
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strq)
            Return ds
        Catch ex As Exception
        End Try
    End Function

    Public Shared Sub ExeNQcomsp(ByVal strQ As String)
        'Dim con As New OleDbConnection("Data Source=TSI_DEV_04;Initial Catalog=fmsf;User ID=sa;Password=sa123;Provider=SQLOLEDB.1")
        'Dim Strconn As String = ConfigurationManager.ConnectionStrings("fmsfConnectionString").ToString
        'Dim ObjSqlCommand As OleDbCommand = Nothing
        'Dim intReturnValue As Integer = 0
        Try
            '    con.Open()
            '   ObjSqlCommand = New OleDbCommand(strQ, con)
            '  intReturnValue = ObjSqlCommand.ExecuteNonQuery()
            ' ObjSqlCommand.Connection.Close()

            CLS.ConOpen()
            CLS.fnExecuteQuery(strQ)
            CLS.ConClose()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Protected Sub GrdCourse_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Dim gv As GridView = DirectCast(sender, GridView)
        gvUniqueID = gv.UniqueID
       
        Try
            If e.CommandName = "Edit" Then
                Dim CourseID As Integer = Convert.ToInt32(e.CommandArgument)
                Response.Redirect("AddCourse.aspx?CourseId=" & CourseID)
            End If
            If e.CommandName = "FileSave" Then

                Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim hdnCourseId As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnCourseId"), HiddenField)
                Dim txtSemesterName As TextBox = DirectCast(gv.Rows(id - 1).FindControl("txtSemesterName"), TextBox)

                Dim nFromSemester As Integer
                Dim nToSemester As Integer
                Dim arrSemestertitle() As String
                Dim StrSemestertitle As String

                Dim StrCourseCode As String
                Dim LastSemid As Integer
                Dim Stuid As Integer
                Dim i As Integer

                nToSemester = txtSemesterName.Text
                Dim DsChkSemester As New DataSet
                DsChkSemester = CLS.fnQuerySelectDs("select SemesterTitle from semester where SemID=(select max(SemID) from  semester where CourseId=" & hdnCourseId.Value & ")")
                If DsChkSemester IsNot Nothing Then
                    If DsChkSemester.Tables(0).Rows IsNot Nothing Then
                        If DsChkSemester.Tables(0).Rows.Count > 0 Then
                            StrSemestertitle = DsChkSemester.Tables(0).Rows(0)(0).ToString()
                            arrSemestertitle = StrSemestertitle.Split(" ")
                            nFromSemester = arrSemestertitle(1)

                            Dim dsCourseTitle As New DataSet
                            dsCourseTitle = CLS.fnQuerySelectDs("select * from Course where CourseId=" & hdnCourseId.Value)

                            If dsCourseTitle IsNot Nothing Then
                                If dsCourseTitle.Tables IsNot Nothing Then
                                    If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                        If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                            StrCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString

                                            For i = (nFromSemester + 1) To (nFromSemester + nToSemester)
                                                Try

                                                    Dim strPath As String
                                                    strPath = Server.MapPath("../") & "upload/" & Trim(StrCourseCode) & "/" & "/Semester " & i
                                                    Directory.CreateDirectory(strPath)
                                                    Dim strQ As String = "insert into Semester(CourseId,SemesterTitle) values(" & hdnCourseId.Value & ",'Semester " & i & "')"
                                                    CLS.fnExecuteQuery(strQ)

                                                    ' change on 30 Nov

                                                    Dim LastSem As String

                                                    Dim dsSem As New DataSet
                                                    LastSem = "select max(SemId) as semid from semester where courseid=" & hdnCourseId.Value & ""
                                                    dsSem = CLS.fnQuerySelectDs(LastSem)
                                                    LastSemid = dsSem.Tables(0).Rows(0)("semid").ToString()


                                                    ''''''''''''''''''''''
                                                    Dim j As Integer
                                                    Dim Studentid As String
                                                    Dim strQ1 As String

                                                    Dim dsStd As New DataSet
                                                    Studentid = "select distinct(stid) as stid from studentsemester where courseid=" & hdnCourseId.Value & ""
                                                    dsStd = CLS.fnQuerySelectDs(Studentid)
                                                    If dsStd IsNot Nothing Then
                                                        If dsStd.Tables IsNot Nothing Then
                                                            If dsStd.Tables(0).Rows IsNot Nothing Then
                                                                If dsStd.Tables(0).Rows.Count > 0 Then
                                                                    For j = 0 To dsStd.Tables(0).Rows.Count - 1
                                                                        Stuid = dsStd.Tables(0).Rows(j)("stid").ToString
                                                                        strQ1 = "insert into studentsemester(stid,CourseId,semid,currentStatus,passStatus,feestatus,promoteStatus) values(" & Stuid & "," & hdnCourseId.Value & "," & LastSemid & ",0,0,0,0)"
                                                                        CLS.fnExecuteQuery(strQ1)
                                                                    Next
                                                                End If
                                                            End If
                                                        End If
                                                    End If


                                                    'change on 30 Nov
                                                Catch ex As Exception

                                                End Try
                                            Next
                                        End If
                                    End If
                                End If
                            End If
                            'change on 30 Nov

                            Dim dsSemCount As New DataSet
                            Dim StrSemcount As Integer

                            Dim StrCourseUpd As String

                            dsSemCount = CLS.fnQuerySelectDs("select count(Semid) as count  from semester where courseid=" & hdnCourseId.Value & "")
                            StrSemcount = dsSemCount.Tables(0).Rows(0)("count").ToString

                            StrCourseUpd = "update course set noOfSem=" & StrSemcount & " where courseid=" & hdnCourseId.Value & ""
                            CLS.fnExecuteQuery(StrCourseUpd)

                            'change on 30 Nov
                        Else
                            Dim dsCourseTitle As New DataSet
                            dsCourseTitle = CLS.fnQuerySelectDs("select * from Course where CourseId=" & hdnCourseId.Value)

                            If dsCourseTitle IsNot Nothing Then
                                If dsCourseTitle.Tables IsNot Nothing Then
                                    If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                        If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                            StrCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString

                                            For i = 1 To nToSemester
                                                Try

                                                    Dim strPath As String
                                                    strPath = Server.MapPath("../") & "upload/" & Trim(StrCourseCode) & "/" & "/Semester " & i
                                                    Directory.CreateDirectory(strPath)
                                                    Dim strQ As String = "insert into Semester(CourseId,SemesterTitle) values(" & hdnCourseId.Value & ",'Semester " & i & "')"
                                                    CLS.fnExecuteQuery(strQ)
                                                Catch ex As Exception

                                                End Try
                                            Next
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If


                gvCourseID = hdnCourseId.Value
                bindgrid()
            End If



        Catch ex As Exception
        End Try
    End Sub


    Protected Sub grdSemester_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Dim gv As GridView = DirectCast(sender, GridView)
        gvUniqueID = gv.UniqueID
        Dim id As Integer = Convert.ToInt32(e.CommandArgument)
        Dim hdnCourseId As HiddenField = DirectCast(gv.Rows(ID - 1).FindControl("hdnCourseId"), HiddenField)
        Dim hdnSemID As HiddenField = DirectCast(gv.Rows(ID - 1).FindControl("hdnSemID"), HiddenField)
        Try
            If e.CommandName = "Delete" Then

                Dim strq As String = "select ModuleID,SemID from Module where SemID in ( select  SemID from semester where SemID=" & hdnSemID.Value & " )"
                Dim ds As New DataSet()
                ds = CLS.fnQuerySelectDs(strq)
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblMessage.Text = "Cannot be deleted"
                Else
                    ''''''''''''''' 4 july,2009 ''''''''''''''
                    Dim courseid As Integer
                    Dim noOfSem As Integer
                    Dim sqlDeletesemesterfolder As String = "select course.courseid,coursecode,semestertitle from course inner join semester on course.courseid = semester.courseid  where semester.SemID=" & hdnSemID.Value
                    Dim dsDeletsemesterfolder As New DataSet()
                    dsDeletsemesterfolder = CLS.fnQuerySelectDs(sqlDeletesemesterfolder)
                    If (dsDeletsemesterfolder.Tables(0).Rows.Count > 0) Then
                        courseid = dsDeletsemesterfolder.Tables(0).Rows(0)("courseid").ToString()
                        Ccode = dsDeletsemesterfolder.Tables(0).Rows(0)("CourseCode").ToString()
                        Stitle = dsDeletsemesterfolder.Tables(0).Rows(0)("semestertitle").ToString()


                    End If
                    Dim sqlStd As String
                    Dim dsStd As New DataSet()
                    sqlStd = "select *from studentsemester where semid=" & hdnSemID.Value

                    dsStd = CLS.fnQuerySelectDs(sqlStd)
                    If (dsStd.Tables(0).Rows.Count > 0) Then
                        lblMessage.Text = "Student allready associated with this semster"
                    Else
                        Dim strPath As String = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle
                        If Directory.Exists(strPath) Then
                            ' for delete folder solution 
                            Response.Cookies("un").Value = Session("username").ToString()
                            Response.Cookies("un").Expires.AddDays(1)
                            Response.Cookies("r").Value = Session("role").ToString()
                            Response.Cookies("r").Expires.AddDays(1)
                            Directory.Delete(Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle)
                            'd = 1

                            sqlStd = "select Type from feedetails where courseid=" & courseid
                            dsStd = CLS.fnQuerySelectDs(sqlStd)
                            Dim type As String = dsStd.Tables(0).Rows(0)("Type").ToString()
                            If type = "One Time Fee" Then
                            Else
                                Dim str1 As String = "delete from feedetails where SemId=" & hdnSemID.Value
                                ExeNQcomsp(str1)
                            End If


                            Dim str As String = "delete from semester where SemId=" & hdnSemID.Value
                            ExeNQcomsp(str)

                            Dim str2 As String = "update Course set noOfSem=noOfSem -1 where courseid=" & courseid
                            ExeNQcomsp(str2)
                            ' bindgrid()
                            lblMessage.Text = "Record deleted successfully"
                            lblMessage.ForeColor = Drawing.Color.DarkGreen
                        End If
                    End If


                    'Dim strPath As String = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle
                    'If Directory.Exists(strPath) Then
                    '    Directory.Delete(Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle)
                    '    Dim str As String = "delete from semester where SemId=" & id
                    '    ExeNQcomsp(str)
                    '    bindgrid()
                    '    lblMessage.Text = "Record deleted successfully"
                    '    lblMessage.ForeColor = Drawing.Color.DarkGreen
                    'End If

                End If
            End If
            If e.CommandName = "FileSave" Then
                'Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim txtModuleName As TextBox = DirectCast(gv.Rows(id - 1).FindControl("txtModuleName"), TextBox)



                Dim i As Integer
                Dim strModuleTitle As String
                Dim arrModuletitle() As String
                Dim nToModule As Integer
                Dim nfromModule As Integer
                Dim strQ As String
                Dim strCourseCode As String
                Dim strSemestertitle As String
                Try
                    nToModule = txtModuleName.Text
                    Dim dschkModule As New DataSet
                    'fetch last module title and increment into 1
                    'dschkModule = CLS.fnQuerySelectDs("select ModuleTitle from module where moduleid=(select max(moduleid) from module where semid=" & hdnSemID.Value & ")")
                    dschkModule = CLS.fnQuerySelectDs("select ModuleTitle from module where moduleid=(select max(moduleid) from module INNER JOIN semester ss on ss.semid=module.semid where courseid=" & hdnCourseId.Value & ")")
                    If dschkModule IsNot Nothing Then
                        If dschkModule.Tables IsNot Nothing Then
                            If dschkModule.Tables(0).Rows IsNot Nothing Then
                                If dschkModule.Tables(0).Rows.Count > 0 Then
                                    strModuleTitle = dschkModule.Tables(0).Rows(0)(0).ToString()
                                    arrModuletitle = strModuleTitle.Split(" ")
                                    nfromModule = arrModuletitle(1)


                                    Dim dsCourseTitle As New DataSet

                                    dsCourseTitle = CLS.fnQuerySelectDs("select coursecode,semestertitle from course" & _
                                                                          " inner join semester on " & _
                                                                          " course.courseid=semester.courseid" & _
                                                                          " where semester.courseid=" & hdnCourseId.Value & " and semester.semid=" & hdnSemID.Value)

                                    strCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString
                                    strSemestertitle = dsCourseTitle.Tables(0).Rows(0)("semestertitle").ToString

                                    For i = (nfromModule + 1) To (nfromModule + nToModule)

                                        Try
                                            Dim strPath As String
                                            strPath = Server.MapPath("../") & "upload/" & Trim(strCourseCode) & "/" & Trim(strSemestertitle) & "/Module " & i
                                            Directory.CreateDirectory(strPath)

                                            strQ = "insert into module(semid,ModuleTitle) values(" & hdnSemID.Value & ",'Module " & i & "')"
                                            CLS.fnExecuteQuery(strQ)
                                        Catch ex As Exception

                                        End Try



                                    Next
                                Else
                                    Dim dsCourseTitle As New DataSet
                                    dsCourseTitle = CLS.fnQuerySelectDs("select coursecode,semestertitle from course" & _
                                                                          " inner join semester on " & _
                                                                          " course.courseid=semester.courseid" & _
                                                                          " where semester.courseid=" & hdnCourseId.Value & " and semester.semid=" & hdnSemID.Value)


                                    If dsCourseTitle IsNot Nothing Then
                                        If dsCourseTitle.Tables IsNot Nothing Then
                                            If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                                If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                                    strCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString
                                                    strSemestertitle = dsCourseTitle.Tables(0).Rows(0)("semestertitle").ToString
                                                    For i = 1 To nToModule
                                                        Try
                                                            Dim strPath As String
                                                            strPath = Server.MapPath("../") & "upload/" & Trim(strCourseCode) & "/" & Trim(strSemestertitle) & "/Module " & i
                                                            Directory.CreateDirectory(strPath)
                                                            strQ = "insert into module(semid,ModuleTitle) values(" & hdnSemID.Value & ",'Module " & i & "')"
                                                            CLS.fnExecuteQuery(strQ)
                                                        Catch ex As Exception

                                                        End Try
                                                    Next
                                                End If
                                            End If
                                        End If
                                    End If


                                End If
                            End If
                        End If
                    Else

                    End If

                Catch ex As Exception
                End Try

             


                'Try
                '    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');expandcollapse('divChild" + gvModuleID + "');expandcollapse('divGrandChild" + gvPaperID + "');expandcollapse('div" + gvPaperID + gvModuleID + gvSemID + "');</script>")

                'Catch ex As Exception

                'End Try


            End If
            gvCourseID = hdnCourseId.Value
            gvSemID = hdnSemID.Value

            bindgrid()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdSemester_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub GrdModule_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Dim gv As GridView = DirectCast(sender, GridView)
        gvUniqueID = gv.UniqueID
        Dim id As Integer = Convert.ToInt32(e.CommandArgument)
        Dim hdnCourseId As HiddenField = DirectCast(gv.Rows(ID - 1).FindControl("hdnCourseId"), HiddenField)
        Dim hdnModuleID As HiddenField = DirectCast(gv.Rows(ID - 1).FindControl("hdnModuleID"), HiddenField)
        Dim hdnSemID As HiddenField = DirectCast(gv.Rows(ID - 1).FindControl("hdnSemID"), HiddenField)

        Try
            If e.CommandName = "Delete" Then

                Dim strq As String = "select paperID,moduleID from paper where moduleID in ( select  moduleID from module where moduleID=" & hdnModuleID.Value & " )"
                Dim ds As New DataSet()
                ds = CLS.fnQuerySelectDs(strq)
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblMessage.Text = "Cannot be deleted"
                Else

                    ''''''''''''''' 4 july,2009 ''''''''''''''

                    Dim sqlDeletemodulefolder As String = "select coursecode,semestertitle,moduletitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid where module.ModuleID=" & hdnModuleID.Value
                    Dim dsDeletmodulefolder As New DataSet()
                    dsDeletmodulefolder = CLS.fnQuerySelectDs(sqlDeletemodulefolder)
                    If (dsDeletmodulefolder.Tables(0).Rows.Count > 0) Then
                        Ccode = dsDeletmodulefolder.Tables(0).Rows(0)("CourseCode").ToString()
                        Stitle = dsDeletmodulefolder.Tables(0).Rows(0)("semestertitle").ToString()
                        Mtitle = dsDeletmodulefolder.Tables(0).Rows(0)("moduletitle").ToString()

                    End If

                    Dim strPath As String = Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle)
                    If Directory.Exists(strPath) Then
                        ' for delete folder solution 
                        Response.Cookies("un").Value = Session("username").ToString()
                        Response.Cookies("un").Expires.AddDays(1)
                        Response.Cookies("r").Value = Session("role").ToString()
                        Response.Cookies("r").Expires.AddDays(1)

                        Directory.Delete(Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle))
                        Dim str As String = "delete from module where ModuleID=" & hdnModuleID.Value
                        ExeNQcomsp(str)
                        'bindgrid()
                        lblMessage.Text = "Record deleted successfully"
                        lblMessage.ForeColor = Drawing.Color.DarkGreen
                    End If
                    '''''''''''''''''''''''''''''''''''''''

                    'Dim str As String = "delete from module where ModuleID=" & id
                    'ExeNQcomsp(str)
                    'bindgrid()
                    'lblMessage.Text = "Record deleted successfully"
                    'lblMessage.ForeColor = Drawing.Color.DarkGreen
                End If

            End If
            If e.CommandName = "FileSave" Then
                'Dim id As Integer = Convert.ToInt32(e.CommandArgument)
               
                Dim txtPaperName As TextBox = DirectCast(gv.Rows(id - 1).FindControl("txtPaperName"), TextBox)


               

                If fnValidatePaper(txtPaperName) = True Then
                    Dim strSemesterTitle As String
                    Dim StrCourseCode As String
                    Dim strModuleTitle As String
                    Try
                        Dim dsCourseTitle As New DataSet
                        dsCourseTitle = CLS.fnQuerySelectDs("select coursecode,semestertitle,moduletitle from course inner join semester on " & _
                                                                " course.courseid = semester.courseid " & _
                                                                " inner join module on semester.semid=module.semid " & _
                                                                " where semester.semid =" & hdnSemID.Value & " And moduleid =" & hdnModuleID.Value)

                        If dsCourseTitle IsNot Nothing Then
                            If dsCourseTitle.Tables IsNot Nothing Then
                                If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                    If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                        StrCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString
                                        strSemesterTitle = dsCourseTitle.Tables(0).Rows(0)("semestertitle").ToString
                                        strModuleTitle = dsCourseTitle.Tables(0).Rows(0)("Moduletitle").ToString

                                        Try

                                            Dim strPath As String
                                            Dim strQ As String
                                            strPath = Server.MapPath("..\") & "upload\" & Trim(StrCourseCode) & "\" & Trim(strSemesterTitle) & "\" & Trim(strModuleTitle) & "\" & Trim(txtPaperName.Text)
                                            Directory.CreateDirectory(strPath)
                                            strQ = "insert into paper(ModuleId,PaperTitle) values(" & hdnModuleID.Value & ",'" & Trim(txtPaperName.Text) & "')"
                                            CLS.fnExecuteQuery(strQ)
                                            lblMessage.Text = "Paper Added successfully"
                                            lblMessage.ForeColor = Drawing.Color.DarkGreen
                                            Response.Redirect(Request.Url.ToString)


                                        Catch ex As Exception

                                        End Try

                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                End If
              


                'Try
                '    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');expandcollapse('divChild" + gvModuleID + "');expandcollapse('divGrandChild" + gvPaperID + "');expandcollapse('div" + gvPaperID + gvModuleID + gvSemID + "');</script>")

                'Catch ex As Exception

                'End Try


            End If
            gvCourseID = hdnCourseId.Value
            gvModuleID = hdnModuleID.Value
            gvSemID = hdnSemID.Value
            'gvPaperID=
            bindgrid()
        Catch ex As Exception
        End Try
    End Sub
    Function fnValidatePaper(ByVal txtPaperTitle As TextBox) As Boolean
        Try
            If Len(txtPaperTitle.Text) <= 0 Then
                lblMessage.Text = "Paper title cannot be left blank"
                Return False
            End If

            Dim dscheck As New DataSet
            Dim strq As String
            strq = "select * from paper where papertitle='" & Trim(txtPaperTitle.Text) & "' and moduleid=" & mid
            dscheck = CLS.fnQuerySelectDs(strq)
            If dscheck IsNot Nothing Then
                If dscheck.Tables IsNot Nothing Then
                    If dscheck.Tables(0).Rows IsNot Nothing Then
                        If dscheck.Tables(0).Rows.Count > 0 Then
                            lblMessage.Text = "Paper title already exist"
                            lblMessage.ForeColor = Drawing.Color.Red
                            Return False
                        End If
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
        End Try
    End Function
    Protected Sub GrdModule_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub GrdPaper_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        Dim gv As GridView = DirectCast(sender, GridView)
        gvUniqueID = gv.UniqueID

        Dim id As Integer = Convert.ToInt32(e.CommandArgument)
        Dim hdnCourseId As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnCourseId"), HiddenField)
        Dim hdnParentId As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnParentId"), HiddenField)
        Dim hdnModuleID As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnModuleID"), HiddenField)
        Dim hdnSemID As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnSemID"), HiddenField)
       



        Try
            If e.CommandName = "Delete" Then
                ' Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim strq As String = "select PaperID,UnitId from unit where paperId in ( select  paperID from paper where paperID=" & hdnParentId.Value & " )"

                Dim ds As New DataSet()
                ds = CLS.fnQuerySelectDs(strq)
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblMessage.Text = "Cannot be deleted"
                    'Response.Write("You Can't delete.! Beacuase record exist in leaf lavel")
                Else

                    ''''''''''''''' 4 july,2009 ''''''''''''''
                    Dim sqlDeletepaperfolder As String = "select coursecode,semestertitle,moduletitle,PaperTitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId where paper.paperid=" & hdnParentId.Value
                    Dim dsDeletpaperfolder As New DataSet()
                    dsDeletpaperfolder = CLS.fnQuerySelectDs(sqlDeletepaperfolder)
                    If (dsDeletpaperfolder.Tables(0).Rows.Count > 0) Then
                        Ccode = dsDeletpaperfolder.Tables(0).Rows(0)("CourseCode").ToString()
                        Stitle = dsDeletpaperfolder.Tables(0).Rows(0)("semestertitle").ToString()
                        Mtitle = dsDeletpaperfolder.Tables(0).Rows(0)("moduletitle").ToString()
                        Ptitle = dsDeletpaperfolder.Tables(0).Rows(0)("PaperTitle").ToString()
                    End If
                    Dim sqlExamPaper As String = "select *from examset where paperid=" & hdnParentId.Value
                    Dim dsExam As New DataSet()
                    dsExam = CLS.fnQuerySelectDs(sqlExamPaper)
                    If (dsExam.Tables(0).Rows.Count > 0) Then
                        lblMessage.Text = "Exam allready created with this paper"
                    Else
                        Dim strPath As String = Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle) & "\" & Trim(Ptitle)
                        If Directory.Exists(strPath) Then
                            ' for delete folder solution 
                            Response.Cookies("un").Value = Session("username").ToString()
                            Response.Cookies("un").Expires.AddDays(1)
                            Response.Cookies("r").Value = Session("role").ToString()
                            Response.Cookies("r").Expires.AddDays(1)

                            Directory.Delete(Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle) & "\" & Trim(Ptitle))
                            Dim str As String = "delete from paper where PaperID=" & hdnParentId.Value
                            ExeNQcomsp(str)
                            'bindgrid()
                            lblMessage.Text = "Record deleted successfully"
                            lblMessage.ForeColor = Drawing.Color.DarkGreen
                        End If
                    End If

                 

                End If
            End If
            If e.CommandName = "AddUnit" Then

                Dim strPath As String
                Dim fn As String
                Dim strUpdate As String
                'Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim txtUnitName As TextBox = DirectCast(gv.Rows(id - 1).FindControl("txtUnitName"), TextBox)
                Dim FileUpload1 As FileUpload = DirectCast(gv.Rows(id - 1).FindControl("FileUpload1"), FileUpload)
                Dim ddlViewMode As DropDownList = DirectCast(gv.Rows(id - 1).FindControl("ddlViewMode"), DropDownList)

                Try
                    If ddlViewMode.SelectedIndex = 0 Then
                        lblMessage.Text = "Please select Access Mode"
                        Exit Sub
                    End If

                    If fnValidate(txtUnitName, FileUpload1) = True Then
                        If Not FileUpload1.PostedFile Is Nothing And FileUpload1.PostedFile.ContentLength > 0 Then
                            fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
                            Dim strQ As String
                            Try
                                GetData(hdnModuleID.Value, hdnParentId.Value)
                                strPath = Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle) & "\" & Trim(Ptitle) & "\" & fn
                                ViewState("FilePath") = strPath
                                If File.Exists(strPath) Then
                                    lblMessage.Text = "File already exists."
                                    lblMessage.ForeColor = Drawing.Color.Red
                                    Exit Sub
                                Else
                                    Dim rAffected As Integer
                                    FileUpload1.PostedFile.SaveAs(strPath)
                                    strQ = "insert into unit(Paperid,UnitTitle,UploadFilepath,mode) values(" & hdnParentId.Value & ",'" & Trim(txtUnitName.Text) & "','" & System.IO.Path.GetFileName(strPath) & "', '" & ddlViewMode.SelectedItem.Text & "')"
                                    CLS.fnExecuteQuery(strQ)

                                    '** Add Notification by wahid on 12-10-2020
                                    Dim strGetCourse As String = "select course.courseid,coursecode,semestertitle,moduletitle,PaperTitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId where paper.paperid=" & hdnParentId.Value
                                    Dim dsGetCourse As New DataSet()
                                    Dim strcourse As Integer

                                    dsGetCourse = CLS.fnQuerySelectDs(strGetCourse)
                                    If (dsGetCourse.Tables(0).Rows.Count > 0) Then
                                        strcourse = dsGetCourse.Tables(0).Rows(0)("courseid").ToString()
                                    End If

                                    Dim Notifications As String = "insert into Notifications(Subject,Body,SendFrom,CourseId)values('Course Material is uploaded','Course Material','Admin'," & strcourse & ")"
                                    ExeNQcomsp(Notifications)
                                    '** Add Notification by wahid on 12-10-2020

                                    ' Response.Write("<script>window.opener.location.reload(); self.close();</script>")
                                    lblMessage.Text = "File uploaded."
                                End If
                                ' Response.Write("The file has been uploaded.")
                                'Dim filename As String = fn.ToString()
                            Catch Exc As Exception
                                Response.Write("Error: " & Exc.Message)
                            End Try
                        Else
                            lblMessage.Text = "Please select a file to upload."
                            lblMessage.ForeColor = Drawing.Color.Red
                        End If
                    End If
                Catch ex As Exception
                End Try




            End If
            If e.CommandName = "EditPaper" Then

                Try
                    'Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                    Dim txtEditPaperName As TextBox = DirectCast(gv.Rows(ID - 1).FindControl("txtEditPaperName"), TextBox)

                    'Dim dspaperTitle As New DataSet
                    'dspaperTitle = CLS.fnQuerySelectDs("select * from paper where papertitle='" & Trim(txtEditPaperName.Text) & "'")

                    'If dspaperTitle IsNot Nothing Then
                    '    If dspaperTitle.Tables IsNot Nothing Then
                    '        If dspaperTitle.Tables(0).Rows IsNot Nothing Then
                    '            If dspaperTitle.Tables(0).Rows.Count > 0 Then
                    '                lblMessage.Text = "Paper title already exist"
                    '                Exit Sub
                    '            End If
                    '        End If
                    '    End If
                    'End If

                    GetPaaperData(hdnModuleID.Value, hdnParentId.Value)
                    Dim strPath As String = Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle) & "\" & Trim(Ptitle)
                    Dim strPath1 As String
                    strPath1 = Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle) & "\" & Trim(txtEditPaperName.Text)
                    'If Directory.Exists(strPath1) = False Then
                    '    Directory.CreateDirectory(strPath1)
                    'End If


                    If strPath <> strPath1 Then
                        ' for update folder solution 
                        Response.Cookies("un").Value = Session("username").ToString()
                        Response.Cookies("un").Expires.AddDays(1)
                        Response.Cookies("r").Value = Session("role").ToString()
                        Response.Cookies("r").Expires.AddDays(1)

                        Directory.Move(strPath, strPath1)
                        'MyCLS.RecursiveCopyFiles(strPath, strPath1, True)
                        ' Directory.Delete(strPath, True)
                    End If


                    Dim strUpdate As String = "update paper set PaperTitle='" & txtEditPaperName.Text & "' where PaperID=" & hdnParentId.Value & " and ModuleId=" & hdnModuleID.Value
                    CLS.fnExecuteQuery(strUpdate)
                    ' Response.Write("<script>window.opener.location.reload(); self.close();</script>")
                    'Else
                    'lblMessage.Text = "Paper title already exist"
                    'Exit Sub
                    'End If
                Catch ex As Exception

                End Try



            End If

            gvCourseID = hdnCourseId.Value
            gvModuleID = hdnModuleID.Value
            gvPaperID = hdnParentId.Value
            gvSemID = hdnSemID.Value
            bindgrid()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetPaaperData(ByVal ModuleId As String, ByVal paperID As String)
        Try
            Dim strGetData As String = "select coursecode,semestertitle,moduletitle,PaperTitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId where Module.moduleid=" & Integer.Parse(ModuleId) & " and paper.paperID=" & Integer.Parse(paperID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                Ccode = ds.Tables(0).Rows(0)("CourseCode").ToString()
                Stitle = ds.Tables(0).Rows(0)("semestertitle").ToString()
                Mtitle = ds.Tables(0).Rows(0)("moduletitle").ToString()
                Ptitle = ds.Tables(0).Rows(0)("PaperTitle").ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetData(ByVal ModuleId As String, ByVal paperID As String)
        Try
            Dim strGetData As String = "select coursecode,semestertitle,moduletitle,PaperTitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId where Module.moduleid=" & Integer.Parse(ModuleId) & " and paper.paperID=" & Integer.Parse(paperID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                Ccode = ds.Tables(0).Rows(0)("CourseCode").ToString()
                Stitle = ds.Tables(0).Rows(0)("semestertitle").ToString()
                Mtitle = ds.Tables(0).Rows(0)("moduletitle").ToString()
                Ptitle = ds.Tables(0).Rows(0)("PaperTitle").ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function fnValidate(ByVal txtUnitName As TextBox, ByVal FileUpload1 As FileUpload) As Boolean
        Try
            If Len(txtUnitName.Text) <= 0 Then
                lblMessage.Text = "Unit name cannot be left blank"
                Return False
            End If

            If FileUpload1.HasFile = False Then
                lblMessage.Text = "Please select filename"
                Return False
            End If

            Dim dscheck As New DataSet
            Dim strq As String
            strq = "select * from unit where Unittitle='" & Trim(txtUnitName.Text) & "' and Paperid=" & pid
            dscheck = CLS.fnQuerySelectDs(strq)
            If dscheck IsNot Nothing Then
                If dscheck.Tables IsNot Nothing Then
                    If dscheck.Tables(0).Rows IsNot Nothing Then
                        If dscheck.Tables(0).Rows.Count > 0 Then
                            lblMessage.Text = "Unit Name already exist"
                            lblMessage.ForeColor = Drawing.Color.Red
                            Return False
                        End If
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
        End Try
    End Function
    Protected Sub GrdPaper_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub grdUnit_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        Dim gv As GridView = DirectCast(sender, GridView)
        gvUniqueID = gv.UniqueID

        Dim id As Integer = Convert.ToInt32(e.CommandArgument)


        Dim hdnUnitId As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnUnitId"), HiddenField)
        Dim hdnCourseId As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnCourseId"), HiddenField)
        Dim hdnParentId As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnParentId"), HiddenField)
        Dim hdnModuleID As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnModuleID"), HiddenField)
        Dim hdnSemID As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnSemID"), HiddenField)
      
        Try
            If e.CommandName = "Delete" Then


                ''''''''''''''' 4 july,2009 ''''''''''''''
                DeleteUnitData(hdnUnitId.Value)
                strPathOld = ViewState("path")
                If File.Exists(strPathOld) Then
                    File.Delete(strPathOld)
                End If
                Dim str As String = "delete from unit where UnitId=" & hdnUnitId.Value
                ExeNQcomsp(str)
                'bindgrid()
                lblMessage.Text = "Record deleted successfully"
                lblMessage.ForeColor = Drawing.Color.DarkGreen

                ''''''''''''''' 4 july,2009 ''''''''''''''

                'Dim str As String = "delete from unit where UnitId=" & id
                'ExeNQcomsp(str)
                'bindgrid()
                'lblMessage.Text = "Record deleted successfully"
                'lblMessage.ForeColor = Drawing.Color.DarkGreen
            End If

            If e.CommandName = "FileSave" Then
                Dim strPathOld1 As String
                Dim strPath As String
                Dim fn As String
                Dim strUpdate As String

                'Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim txtUnitName As TextBox = DirectCast(gv.Rows(id - 1).FindControl("txtEditUnitName"), TextBox)
                Dim FileUpload1 As FileUpload = DirectCast(gv.Rows(id - 1).FindControl("FileEditUpload1"), FileUpload)
                Dim hdnUploadFilePath As HiddenField = DirectCast(gv.Rows(id - 1).FindControl("hdnUploadFilePath"), HiddenField)
                Dim ddlViewMode As DropDownList = DirectCast(gv.Rows(id - 1).FindControl("ddlViewMode"), DropDownList)

                If ddlViewMode.SelectedIndex = 0 Then
                    lblMessage.Text = "Please select Access Mode"
                    Exit Sub
                End If

                If FileUpload1.HasFile Then
                    GetData(hdnModuleID.Value, hdnParentId.Value)
                    strPathOld1 = Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle) & "\" & Trim(Ptitle) & "\" & hdnUploadFilePath.Value
                    If File.Exists(strPathOld1) Then
                        File.Delete(strPathOld1)
                    End If
                    fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)

                    strPath = Server.MapPath("..\") & "upload\" & Trim(Ccode) & "\" & Trim(Stitle) & "\" & Trim(Mtitle) & "\" & Trim(Ptitle) & "\" & fn
                    FileUpload1.PostedFile.SaveAs(strPath)
                    Dim str As String = "update unit set UnitTitle='" & txtUnitName.Text & "',UploadFilePath='" & System.IO.Path.GetFileName(strPath) & "',Mode='" & ddlViewMode.SelectedItem.Text & "' where UnitId=" & hdnUnitId.Value
                    ExeNQcomsp(str)
                Else
                    Dim str As String = "update unit set UnitTitle='" & txtUnitName.Text & "',Mode='" & ddlViewMode.SelectedItem.Text & "' where UnitId=" & hdnUnitId.Value
                    ExeNQcomsp(str)
                End If
               

               


                'Try
                '    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>expandcollapse('divMainParent" + gvCourseID + "');expandcollapse('divParent" + gvSemID + "');expandcollapse('divChild" + gvModuleID + "');expandcollapse('divGrandChild" + gvPaperID + "');expandcollapse('div" + gvPaperID + gvModuleID + gvSemID + "');</script>")

                'Catch ex As Exception

                'End Try


            End If
            gvCourseID = hdnCourseId.Value
            gvModuleID = hdnModuleID.Value
            gvPaperID = hdnParentId.Value
            gvSemID = hdnSemID.Value

            bindgrid()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub DeleteUnitData(ByVal UnitID As String)
        Try
            Dim strGetData As String = "select coursecode,semestertitle,moduletitle,PaperTitle,UnitId,UnitTitle,UploadFilePath from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId inner join unit on unit.paperid=paper.paperid where unit.UnitId=" & Integer.Parse(UnitID)
            'Dim strGetData As String = "select * from Unit where UnitId=" & Integer.Parse(UnitID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                Ccode = ds.Tables(0).Rows(0)("CourseCode").ToString()
                Stitle = ds.Tables(0).Rows(0)("semestertitle").ToString()
                Mtitle = ds.Tables(0).Rows(0)("moduletitle").ToString()
                Ptitle = ds.Tables(0).Rows(0)("PaperTitle").ToString()
                Dim arrFilename As String = ds.Tables(0).Rows(0)("UploadFilepath").ToString()
                strPathOld = ds.Tables(0).Rows(0)("UploadFilepath").ToString()
                ViewState("path") = Server.MapPath("..") & "\upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle & "\" & strPathOld
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdUnit_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub GrdCourse_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdCourse.RowDeleting

    End Sub

    Protected Sub GrdCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdCourse.SelectedIndexChanged

    End Sub
End Class

