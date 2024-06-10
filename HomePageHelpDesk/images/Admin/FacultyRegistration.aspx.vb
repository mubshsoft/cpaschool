Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_FacultyRegistration
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddStudent
    Dim objDalSt As New DalAddStudent
    Dim objLibErr As New libErrorMsg

    Dim objLibStApp As New LibStudentAPP

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            End If
            If Not IsPostBack Then
                If Request.QueryString("fid") IsNot Nothing Then
                    txtEmailAddress.Enabled = False
                    filldata()
                    btnEdit.Visible = True
                    EnableRecords()
                End If
                If Request.QueryString("facultyid") IsNot Nothing Then
                    txtEmailAddress.Enabled = False
                    filldata1()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function fnValidate() As Object
        Dim ObjErrDal As New libErrorMsg

        If Len(Trim(txtEmailAddress.Text)) <= 0 Then
            ObjErrDal.errMessage = "EmailID cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If


        'If Len(txtDOB.Text) > 0 Then
        '    Dim d As DateTime
        '    Try
        '        d = DateTime.Parse(txtDOB.Text)
        '    Catch ex As Exception
        '        ObjErrDal.errMessage = "Invalid date!format should be mm/dd/yyyy"
        '        ObjErrDal.ChkReturn = False
        '        Return ObjErrDal
        '    End Try
        'Else
        '    ObjErrDal.errMessage = "DOB cannot be left blank"
        'End If


        If Len(txtDOB.Text) > 0 Then
            Dim d As Date
            Try
                d = txtDOB.Text
                If d > Date.Now.Date Then
                    'Response.Write("<script>alert('Date Of event should be equal to and greater than current date.')</script>")
                    ObjErrDal.errMessage = "DOB date should be less than current date."
                    ObjErrDal.ChkReturn = False
                    Return ObjErrDal
                End If
            Catch ex As Exception

            End Try
        End If

        If CLS.checkNumeric(txtContactNumber.Text) = -1 Then
            lblMessage4.Text = "Contact Number cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If


        If CLS.checkNumeric(txtContactNumber.Text) = -2 Then
            lblMessage4.Text = "Contact number should be numeric"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If



        If CLS.checkNumeric(txtMobileNumber.Text) = -2 Then
            lblMessage5.Text = "Mobile number should be numeric"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Request.QueryString("fid") IsNot Nothing Or Request.QueryString("facultyid") IsNot Nothing Then
        Else

            Dim dsChkEmail As New DataSet
            dsChkEmail = CLS.fnQuerySelectDs("select * from login where username='" & Trim(txtEmailAddress.Text) & "'")
            If dsChkEmail IsNot Nothing Then
                If dsChkEmail.Tables IsNot Nothing Then
                    If dsChkEmail.Tables(0).Rows IsNot Nothing Then
                        If dsChkEmail.Tables(0).Rows.Count > 0 Then
                            ObjErrDal.errMessage = "Faculty already registered"
                            ObjErrDal.ChkReturn = False
                            Return ObjErrDal
                        End If
                    End If
                End If
            End If
        End If
        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim Path As String = ""
            Dim uploadFolder As String
            uploadFolder = Request.PhysicalApplicationPath

            objLibErr = fnValidate()
            If objLibErr.ChkReturn = True Then

                Dim fileToDelete As String = ""
                If (FileUpload1.HasFile) Then
                    If (hdnimage.Value <> "") Then
                        fileToDelete = uploadFolder + hdnimage.Value
                        If (File.Exists(fileToDelete)) Then
                            File.Delete(fileToDelete)
                        End If
                        'Dim extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

                    End If
                    Dim fi As New IO.FileInfo(FileUpload1.PostedFile.FileName)

                    Dim extension As String = fi.Extension
                    Dim fname = FileUpload1.PostedFile.FileName
                    FileUpload1.SaveAs(uploadFolder + "Images\\Faculty\\" + fname)

                    Path = "Images/Faculty/" + fname

                Else
                    If (hdnimage.Value <> "") Then
                        Path = hdnimage.Value
                    End If
                End If

                objLibST.emailAddress = Trim(txtEmailAddress.Text)
                objLibST.Password = Trim(txtPassword.Text)
                objLibST.FirstName = Trim(txtFirstName.Text)
                objLibST.LastName = Trim(txtLastName.Text)
                objLibST.MiddleName = Trim(txtMiddleName.Text)
                objLibST.DOBFac = Trim(txtDOB.Text)
                objLibST.Address1 = txtPermanentAddress.Text
                objLibST.Address2 = txtCorrespondenceAddress.Text
                objLibST.ContactNumber1 = txtContactNumber.Text
                objLibST.ContactNumber2 = txtMobileNumber.Text
                objLibST.Gender = dllGender.SelectedItem.Text
                objLibST.Nationality = txtNationality.Text
                objLibST.Category = dllCategory.SelectedItem.Text
                objLibST.Profile = txtprofile.Text
                objLibST.ProfileImage = Utility.CheckNullString(Path)

                Dim retVal As Int16 = objDalSt.Insertfaculty(objLibST)
                If retVal > 0 Then
                    MyCLS.fnMSG("Faculty registered successfully!")
                    message()
                    'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Faculty Addded successfully!'); location.href='Adminlogin.aspx' ;</script>")
                End If
            Else
                lblMessage.Text = objLibErr.errMessage
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub message()
        If Request.QueryString("facultyid") IsNot Nothing Then

            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Faculty updated successfully!'); location.href='ListFaculty.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Faculty updated successfully!'); location.href='ListFaculty.aspx' ;", True)
        ElseIf Request.QueryString("fid") IsNot Nothing Then
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Faculty updated successfully!'); location.href='../faculty/Facultypanel.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Faculty updated successfully!'); location.href='../faculty/Facultypanel.aspx' ;", True)
        Else
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Faculty Addded successfully!'); location.href='ListFaculty.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Faculty Addded successfully!'); location.href='ListFaculty.aspx' ;", True)
        End If
    End Sub
    Sub filldata()
        Try
            Dim dsAppSt As New DataSet
            'dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,Degree,Discipline,courseId,approved,DocVerified from application where stid=" & Request.QueryString("id"))
            dsAppSt = CLS.fnQuerySelectDs("select DOB1=(CASE WHEN f.DOB='1900-01-01 00:00:00.000' THEN ''  ELSE CONVERT(VARCHAR(10),f.DOB,101) END ),    f.email,f.FirstName,f.LastNAme,f.MiddleName,l.password,f.DOB,f.Address1,f.Address2,f.ContactNumber1,f.ContactNumber2,f.Gender,f.Nationality,f.Category,f.Profile,f.Images as Profileimage from FacultyRegistration f INNER JOIN login l on f.email=l.username where f.email='" & Session("username") & "'")
            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            txtEmailAddress.Text = dsAppSt.Tables(0).Rows(0)("email").ToString
                            txtFirstName.Text = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            txtLastName.Text = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            txtMiddleName.Text = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString
                            txtPassword.Text = dsAppSt.Tables(0).Rows(0)("password").ToString
                            txtConfirmPassword.Text = dsAppSt.Tables(0).Rows(0)("password").ToString
                            '   Dim d As New Date
                            ' d = CDate(dsAppSt.Tables(0).Rows(0)("DOB").ToString)
                            txtDOB.Text = dsAppSt.Tables(0).Rows(0)("DOB1").ToString
                            txtPermanentAddress.Text = dsAppSt.Tables(0).Rows(0)("Address1").ToString
                            txtCorrespondenceAddress.Text = dsAppSt.Tables(0).Rows(0)("Address2").ToString
                            txtContactNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber1").ToString
                            txtMobileNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber2").ToString
                            dllGender.SelectedItem.Text = dsAppSt.Tables(0).Rows(0)("Gender").ToString
                            txtNationality.Text = dsAppSt.Tables(0).Rows(0)("Nationality").ToString
                            dllCategory.Text = dsAppSt.Tables(0).Rows(0)("Category").ToString
                            txtprofile.Text = dsAppSt.Tables(0).Rows(0)("Profile").ToString
                            hdnimage.Value = dsAppSt.Tables(0).Rows(0)("Profileimage").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub filldata1()
        Try
            Dim dsAppSt As New DataSet
            'dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,Degree,Discipline,courseId,approved,DocVerified from application where stid=" & Request.QueryString("id"))
            dsAppSt = CLS.fnQuerySelectDs("select *,DOB1=(CASE WHEN DOB='1900-01-01 00:00:00.000' THEN ''  ELSE CONVERT(VARCHAR(10),DOB,101) END ),Images as Profileimage from FacultyRegistration where Fid='" & Request.QueryString("facultyid") & "'")
            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            txtEmailAddress.Text = dsAppSt.Tables(0).Rows(0)("email").ToString
                            txtFirstName.Text = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            txtLastName.Text = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            txtMiddleName.Text = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString
                            txtPassword.Text = dsAppSt.Tables(0).Rows(0)("password").ToString
                            txtConfirmPassword.Text = dsAppSt.Tables(0).Rows(0)("password").ToString
                            txtDOB.Text = dsAppSt.Tables(0).Rows(0)("dob1").ToString
                            txtPermanentAddress.Text = dsAppSt.Tables(0).Rows(0)("Address1").ToString
                            txtCorrespondenceAddress.Text = dsAppSt.Tables(0).Rows(0)("Address2").ToString
                            txtContactNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber1").ToString
                            txtMobileNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber2").ToString
                            dllGender.SelectedItem.Text = dsAppSt.Tables(0).Rows(0)("Gender").ToString
                            txtNationality.Text = dsAppSt.Tables(0).Rows(0)("Nationality").ToString
                            dllCategory.Text = dsAppSt.Tables(0).Rows(0)("Category").ToString
                            txtprofile.Text = dsAppSt.Tables(0).Rows(0)("Profile").ToString
                            hdnimage.Value = dsAppSt.Tables(0).Rows(0)("Profileimage").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Request.QueryString("facultyid") IsNot Nothing Then

            Response.Redirect("ListFaculty.aspx")
        ElseIf Request.QueryString("fid") IsNot Nothing Then

            Response.Redirect("../faculty/Facultypanel.aspx")

        Else
            Response.Redirect("ListFaculty.aspx")
        End If

    End Sub

    Sub EnableRecords()
        txtEmailAddress.Enabled = False
        txtPassword.Enabled = False
        txtConfirmPassword.Enabled = False
        txtFirstName.Enabled = False
        txtLastName.Enabled = False
        txtMiddleName.Enabled = False
        txtPassword.Enabled = False
        txtConfirmPassword.Enabled = False
        txtDOB.Enabled = False
        txtPermanentAddress.Enabled = False
        txtCorrespondenceAddress.Enabled = False
        txtContactNumber.Enabled = False
        txtMobileNumber.Enabled = False
        dllGender.SelectedItem.Enabled = False
        txtNationality.Enabled = False
        dllCategory.Enabled = False
        txtprofile.Enabled = False
    End Sub
    Sub DisableRecords()
        txtEmailAddress.Enabled = False

        txtPassword.Enabled = True
        txtConfirmPassword.Enabled = True
        txtFirstName.Enabled = True
        txtLastName.Enabled = True
        txtMiddleName.Enabled = True
        txtPassword.Enabled = True
        txtConfirmPassword.Enabled = True
        txtDOB.Enabled = True
        txtPermanentAddress.Enabled = True
        txtCorrespondenceAddress.Enabled = True
        txtContactNumber.Enabled = True
        txtMobileNumber.Enabled = True
        dllGender.SelectedItem.Enabled = True
        txtNationality.Enabled = True
        dllCategory.Enabled = True
        txtprofile.Enabled = True
    End Sub
  

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ViewState("chk") = 1
        DisableRecords()
    End Sub
End Class
