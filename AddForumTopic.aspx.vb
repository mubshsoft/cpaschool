Imports fmsf.DAL
Imports fmsf.lib
Imports System.IO
Imports Emoticons
Imports System.Collections
Imports System.Collections.Generic

Partial Class AddForumTopic
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddTopic
    Dim objDalSt As New DalAddTopic
    Dim objLibErr As New libErrorMsg
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Len(Session("username")) <= 0 Then
                Response.Redirect("login.aspx")
            End If
            If Len(Request.QueryString("id")) > 0 Then
                ViewState("s") = Request.QueryString("id")
                FillDDl()
                bindData()

                '  fillData()
            Else
                txtcreatedby.Text = Session("username")
                FillDDl()
            End If
            ' BindTempUploadFiles()
        End If
    End Sub

    Private Sub FillDDl()
        Dim dsCourseTopic As New DataSet
        Dim dsDDl As New DataSet
        dsDDl = CLS.fnQuerySelectDs("select distinct(c.courseid) as courseid,c.coursetitle as coursetitle from facultyassign fa inner join course c on fa.courseid=c.courseid where fid=" & Session("fid"))
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
    'Private Sub FillDDlSem()
    '    MyCLS.ConOpen()
    '    MyCLS.prcFillDDL(ddlSem, "Semester", "SemID", "SemesterTitle", "courseid", ddlCourse.SelectedValue)
    '    MyCLS.ConClose()
    'End Sub
    Private Sub FillDDlSem1()
        Dim dsSemTopic As New DataSet
        dsSemTopic = CLS.fnQuerySelectDs("select  distinct(fa.semid) as semid,s.semestertitle as semestertitle from facultyassign fa inner join semester s on fa.semid=s.semid where fa.courseID=" & ddlCourse.SelectedValue & " and  fid=" & Session("fid"))
        If dsSemTopic IsNot Nothing Then
            If dsSemTopic.Tables IsNot Nothing Then
                If dsSemTopic.Tables(0).Rows IsNot Nothing Then
                    If dsSemTopic.Tables(0).Rows.Count > 0 Then
                        ddlSem.DataSource = dsSemTopic
                        ddlSem.DataValueField = "semid"
                        ddlSem.DataTextField = "Semestertitle"
                        ddlSem.DataBind()
                    End If
                End If
            End If
        End If
    End Sub

    Sub bindData()
        Try
            Dim strq As String

            strq = "select  top 1 * from maintopic m inner join subsubject s on s.SubjectID=m.subjectId where m.subjectid=" & Request.QueryString("id") & " and email='" & Session("username") & "' order by subsubjectid"

            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then



                            txtTopic.Text = dsTopic.Tables(0).Rows(0)("Title").ToString()
                            txtcreatedby.Text = dsTopic.Tables(0).Rows(0)("CreatedBy").ToString()
                            txtreply.Text = dsTopic.Tables(0).Rows(0)("SubjectText").ToString()
                            hdnFilename.Value = dsTopic.Tables(0).Rows(0)("FileName").ToString()
                            hdnFiles.Value = dsTopic.Tables(0).Rows(0)("FilePath").ToString()
                            ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(dsTopic.Tables(0).Rows(0)("courseid").ToString()))

                            FillDDlSem1()

                            ddlSem.SelectedIndex = ddlSem.Items.IndexOf(ddlSem.Items.FindByValue(dsTopic.Tables(0).Rows(0)("SemId").ToString()))

                            FillBatch()

                            ddlbatch.SelectedIndex = ddlbatch.Items.IndexOf(ddlbatch.Items.FindByValue(dsTopic.Tables(0).Rows(0)("BatchId").ToString()))
                            bindGroup()
                            ddlGroup.SelectedIndex = ddlGroup.Items.IndexOf(ddlGroup.Items.FindByValue(dsTopic.Tables(0).Rows(0)("GroupId").ToString()))
                            btnSave.Text = "Update"
                            If (Request.QueryString("EditTopic") <> "") Then
                                dvReply.Visible = False
                                dvReply1.Visible = False
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
        Dim uploadFolder As String = ""
        If FileUpload1.HasFile Then
            Dim fileinfo As Boolean = False
            Dim FileNumber As Integer = 0
            Dim sb As StringBuilder = New StringBuilder()
            sb.Append("You are not permited to upload this type of file(s)")
            Dim i As Integer
            For i = 0 To Request.Files.Count - 1 Step i + 1

                Dim Up_Files1 As System.Web.HttpPostedFile = Request.Files(i)
                Dim type As String = ""
                Dim ext As String = Path.GetExtension(Up_Files1.FileName)

                If Not ext Is Nothing Then
                    type = CommonUtility.GetMimeType(ext)
                End If
                If Up_Files1.ContentLength > 0 Then

                    Try
                        If ext.ToLower().ToString() = ".zip" Or ext.ToLower().ToString() = ".rar" Or ext.ToLower().ToString() = ".xml" Then
                            fileinfo = True
                            FileNumber = FileNumber + 1
                            sb.Append(System.Environment.NewLine)
                            sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName)

                        ElseIf type.ToString().Contains("video") And Up_Files1.ContentLength > 10485760 Then
                            fileinfo = True
                            sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName + " Video File Size is greater than 10 MB")
                        ElseIf type.ToString().Contains("image") And Up_Files1.ContentLength > 3145728 Then
                            fileinfo = True
                            sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName + " File Size is greater than 3 MB")
                        ElseIf Up_Files1.ContentLength > 5242880 Then
                            fileinfo = True
                            sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName + " File Size is greater than 5 MB")
                        Else

                            Dim strNewfilename As String = ""
                            Dim subjectid As String = 1
                            uploadFolder = Request.PhysicalApplicationPath + "DisscussionForumFiles\\" + subjectid
                            strNewfilename = uploadFolder + "\\" + Up_Files1.FileName.ToString()

                            If System.IO.Directory.Exists(uploadFolder) Then

                            Else
                                Directory.CreateDirectory(uploadFolder)
                            End If


                            Up_Files1.SaveAs(strNewfilename)

                        End If

                    Catch ex As Exception

                    End Try

                End If
            Next

            If (fileinfo) Then
                lblMessage.Text = sb.ToString()
            Else
                lblMessage.Text = "File Added Successfully."
            End If


            BindTempUploadFiles()
        End If
    End Sub
    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim lnk As LinkButton = CType(sender, LinkButton)

            Dim filePath As String = lnk.CommandArgument
            File.Delete(filePath)

            lblMessage.Text = "File Deleted Successfully!"


            BindTempUploadFiles()

        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
    End Sub
    Private Sub BindTempUploadFiles()
        Try

            Dim subjectid As String = "1"
            Dim uploadFolder As String = ""
            uploadFolder = Request.PhysicalApplicationPath + "DisscussionForumFiles\" + subjectid
            Dim filePaths() As String = Directory.GetFiles(uploadFolder)

            Dim dirInfo As New IO.DirectoryInfo(HttpContext.Current.Server.MapPath("~/DisscussionForumFiles/" + subjectid))
            '  Dim dirInfo As DirectoryInfo = New DirectoryInfo(@"" + HttpContext.Current.Server.MapPath("~/DisscussionForumFiles/" + 1)) 
            Dim wordFiles() As FileInfo = dirInfo.GetFiles("*.*")

            'List<ListItem> files = new List<ListItem>();
            ' Dim files As List<System.Web.UI.WebControls.ListItem>=  New List<System.Web.UI.WebControls.ListItem>() 

            Dim dt As DataTable = New DataTable()

            Dim dc As DataColumn = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Filename"

            Dim dc1 As DataColumn = New DataColumn()
            dc1.DataType = System.Type.GetType("System.String")
            dc1.ColumnName = "Filepath"

            Dim dc2 As DataColumn = New DataColumn()
            dc2.DataType = System.Type.GetType("System.String")
            dc2.ColumnName = "Filesize"

            dt.Columns.Add(dc)
            dt.Columns.Add(dc1)
            dt.Columns.Add(dc2)

            Dim file As FileInfo
            For Each file In wordFiles

                Dim dr As DataRow = dt.NewRow()
                dr("Filename") = file ' Path.GetFileName(file);
                dr("Filepath") = file.FullName

                dr("Filesize") = file.Length
                dt.Rows.Add(dr)
            Next
            If filePaths.Length > 0 Then

                dlstFileUpload.DataSource = dt
                dlstFileUpload.DataBind()
                dlstFileUpload.Visible = True

            Else
                dlstFileUpload.Visible = False

            End If
        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnValidate()
            If objLibErr.ChkReturn = True Then
                objLibST.title = Trim(txtTopic.Text)
                objLibST.CreatedBy = Trim(txtcreatedby.Text)
                objLibST.Active = True
                objLibST.CourseID = ddlCourse.SelectedValue
                objLibST.Semid = ddlSem.SelectedValue
                objLibST.Batchid = ddlbatch.SelectedValue


                'Dim strPath As String = ""
                Dim filename As String = ""
                Dim Filepath As String = ""
                'Dim strPathOld1 As String
                'Dim fileToDelete As String
                'If Not FileUpload1.PostedFile Is Nothing And FileUpload1.PostedFile.ContentLength > 0 Then
                '    If Not String.IsNullOrEmpty(hdnFiles.Value) Then
                '        fileToDelete = Server.MapPath("~\") & hdnFiles.Value
                '        Try
                '            If (File.Exists(fileToDelete)) Then
                '                File.Delete(fileToDelete)
                '            End If
                '        Catch ex As Exception

                '        End Try
                '    End If
                '    filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
                '    Dim extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

                '    Filepath = "DisscussionForumFiles\" & DateTime.Now.ToString("ddMMyyHHmmss") + "-" + ddlbatch.SelectedValue + extension
                '    strPath = Server.MapPath("~\") & Filepath

                '    If FileUpload1.PostedFile.FileName = strPath Then
                '    Else

                '        FileUpload1.PostedFile.SaveAs(strPath)
                '    End If

                'Else
                '    If Not String.IsNullOrEmpty(hdnFiles.Value) Then
                '        Filepath = hdnFiles.Value
                '        filename = hdnFilename.Value
                '    End If

                'End If

                objLibST.FileName = filename.ToString()
                objLibST.FilePath = Filepath.ToString()

                If Len(ViewState("s")) > 0 Then
                    objLibST.SubjectID = ViewState("s")
                    hdnSubjectid.Value = ViewState("s")
                Else
                    objLibST.SubjectID = 0
                End If

                Dim retVal As Int16

                If ddlGroup.SelectedIndex = -1 Then
                    retVal = objDalSt.InsertTopic(objLibST)
                Else
                    If ddlGroup.SelectedIndex <> 0 Then

                        objLibST.GroupId = ddlGroup.SelectedValue 'Segeration as per group dated on 30 nov 20
                        retVal = objDalSt.InsertTopicWithGroup(objLibST)
                    Else
                        retVal = objDalSt.InsertTopic(objLibST)
                    End If
                End If

                ' Dim retVal As Int16 = objDalSt.InsertTopic(objLibST)

                If retVal = -11 Then
                    lblMessage.Text = "Topic already  exist"
                    Exit Sub
                ElseIf retVal = 1 Then

                    Dim strLastQ As String = "SELECT IDENT_CURRENT('maintopic')"
                    Dim dslast As New DataSet
                    dslast = CLS.fnQuerySelectDs(strLastQ)

                    hdnSubjectid.Value = dslast.Tables(0).Rows(0)(0).ToString
                    Dim strInsQ As String
                    strInsQ = "INSERT INTO Subsubject(subjectid,SubjectText,dateofposting,email,Approve) VALUES (" & dslast.Tables(0).Rows(0)(0).ToString & ",'" & CLS.fnReplaceSpCH1(Trim(txtreply.Text)) & "','" & Date.Today.Date & "','" & Session("username") & "',0)"
                    CLS.fnExecuteQuery(strInsQ)


                    Dim dsPost As New DataSet
                    Dim tpost As Integer
                    Dim strQ As String
                    strQ = "select tpost from Maintopic where subjectid=" & dslast.Tables(0).Rows(0)(0).ToString
                    dsPost = CLS.fnQuerySelectDs(strQ)

                    If dsPost IsNot Nothing Then
                        If dsPost.Tables IsNot Nothing Then
                            If dsPost.Tables(0).Rows IsNot Nothing Then
                                If dsPost.Tables(0).Rows.Count > 0 Then
                                    tpost = dsPost.Tables(0).Rows(0)(0).ToString
                                    Dim strUpQ As String
                                    strUpQ = "Update maintopic set tpost=" & tpost + 1 & ",LastPost='" & CStr(Date.Now.Date) & "' where subjectid=" & dslast.Tables(0).Rows(0)(0).ToString
                                    CLS.fnExecuteQuery(strUpQ)
                                    '  Response.Redirect("../alltopic.aspx?id=" & dslast.Tables(0).Rows(0)(0).ToString & "&o=1")
                                End If
                            End If
                        End If
                    End If

                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "window.openPopup('UploadMultipleFiles.aspx?Subjectid=" + hdnSubjectid.Value + "');", True)
                    'Response.Redirect("MainForumPage1.aspx")
                ElseIf retVal = 2 Or retVal = 3 Then

                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "window.openPopup('UploadMultipleFiles.aspx?Subjectid=" + hdnSubjectid.Value + "');", True)
                    ' Response.Redirect("MainForumPage1.aspx")

                ElseIf retVal = MyCLS.EStatus.Err Then
                    MyCLS.fnMSG("Error Occured!")
                End If
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try
    End Sub



    Public Function fnValidate() As Object
        Dim ObjErrDal As New libErrorMsg
        If Len(Trim(txtTopic.Text)) <= 0 Then
            ObjErrDal.errMessage = "Topic cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If ddlCourse.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select course"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If ddlSem.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select semester"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        'Dim dsChkEmail As New DataSet
        ''dsChkEmail = CLS.fnQuerySelectDs("select * from application where email='" & Trim(txtEmailAddress.Text) & "' and courseid=" & ddlCourse.SelectedValue)
        'dsChkEmail = CLS.fnQuerySelectDs("select * from application where email='" & Trim(txtEmailAddress.Text) & "'")
        'If dsChkEmail IsNot Nothing Then
        '    If dsChkEmail.Tables IsNot Nothing Then
        '        If dsChkEmail.Tables(0).Rows IsNot Nothing Then
        '            If dsChkEmail.Tables(0).Rows.Count > 0 Then
        '                ObjErrDal.errMessage = "Student already registered"
        '                ObjErrDal.ChkReturn = False
        '                Return ObjErrDal
        '            End If
        '        End If
        '    End If
        'End If
        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillDDlSem1()
        FillBatch()
    End Sub

    Private Sub FillBatch()
        Try
            Dim strBatch As String = "select BatchCode,bid  from batch where courseid=" & ddlCourse.SelectedValue
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strBatch)
            ddlbatch.Items.Insert(0, "--Select--")
            ddlbatch.DataSource = dsbatch
            ddlbatch.DataTextField = "BatchCode"
            ddlbatch.DataValueField = "bid"
            ddlbatch.DataBind()
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("MainForumPage1.aspx")
    End Sub
    Protected Sub img9_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img9.Click
        Dim text As String
        text = Emoticon.Format(":'(")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img10_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img10.Click
        Dim text As String
        text = Emoticon.Format("(6)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img12_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img12.Click
        Dim text As String
        text = Emoticon.Format(":$")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img17_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img17.Click
        Dim text As String
        text = Emoticon.Format(":-)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img19_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img19.Click
        Dim text As String
        text = Emoticon.Format(":-)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img20_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img20.Click
        Dim text As String
        text = Emoticon.Format("(H)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img23_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img23.Click
        Dim text As String
        text = Emoticon.Format(":-D")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img25_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img25.Click
        Dim text As String
        text = Emoticon.Format(":-P")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img26_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img26.Click
        Dim text As String
        text = Emoticon.Format(":-|")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img28_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img28.Click
        Dim text As String
        text = Emoticon.Format(";-)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub


    Protected Sub img1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img1.Click
        Dim text As String
        text = Emoticon.Format("(A)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot


    End Sub

    Protected Sub img2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img2.Click
        Dim text As String
        text = Emoticon.Format(":-@")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img3.Click
        Dim text As String
        text = Emoticon.Format("(biggrin)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Protected Sub img4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img4.Click
        Dim text As String
        text = Emoticon.Format("(&)")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot

    End Sub



    Protected Sub img7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img7.Click
        Dim text As String
        text = Emoticon.Format(":-S")
        Dim strEmot As String
        strEmot = txtreply.Text + text
        txtreply.Text = strEmot
    End Sub

    Sub bindGroup()

        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@CourseId", Convert.ToInt32(ddlCourse.SelectedValue)))
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSPDataSet("SP_BatchGroupList", objParamList)
            If ds IsNot Nothing Then
                If ds.Tables IsNot Nothing Then
                    If ds.Tables(0).Rows IsNot Nothing Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            ds.Tables(0).DefaultView.RowFilter = "bid = " + ddlbatch.SelectedValue
                            Dim dt As DataTable = (ds.Tables(0).DefaultView).ToTable()


                            ddlGroup.DataSource = dt
                            ddlGroup.DataTextField = "GroupName"
                            ddlGroup.DataValueField = "GroupId"
                            ddlGroup.DataBind()

                            ddlGroup.Items.Insert(0, "--Select Group--")

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(sender As Object, e As EventArgs)
        bindGroup()
    End Sub
End Class





