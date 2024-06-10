Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Partial Class Student_EditStudentProfile
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddStudent
    Dim objDalSt As New DalAddStudent
    Dim objLibErr As New libErrorMsg
    Dim objLibStApp As New LibStudentAPP
    Public strEmailId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If


        Try

            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then

                filldata()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub filldata()
        Try
            Dim dsAppSt As New DataSet
            Dim mailid As String = Session("username")

            dsAppSt = CLS.fnQuerySelectDs("select * from student where email = '" & mailid & "'")

            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            Dim dsStCourseTitle As New DataSet


                            ' txtStudentID.Text = dsAppSt.Tables(0).Rows(0)("stid").ToString
                            txtEmailAddress.Text = dsAppSt.Tables(0).Rows(0)("email").ToString
                            txtFirstName.Text = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            txtLastName.Text = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            txtMiddleName.Text = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString
                            Dim d As New Date
                            d = CDate(dsAppSt.Tables(0).Rows(0)("DOB").ToString)
                            txtDOB.Text = d
                            txtPermanentAddress.Text = dsAppSt.Tables(0).Rows(0)("Address1").ToString
                            txtCorrespondenceAddress.Text = dsAppSt.Tables(0).Rows(0)("Address2").ToString
                            txtContactNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber1").ToString
                            txtMobileNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber2").ToString
                            'txtDegree.Text = dsAppSt.Tables(0).Rows(0)("degree").ToString
                            'txtDiscipline.Text = dsAppSt.Tables(0).Rows(0)("Discipline").ToString
                            strEmailId = dsAppSt.Tables(0).Rows(0)("email").ToString
                            Session("email") = strEmailId

                            dllGender.SelectedItem.Text = dsAppSt.Tables(0).Rows(0)("Gender").ToString
                            dllProfession.Text = dsAppSt.Tables(0).Rows(0)("CurProfession").ToString
                            txtNationality.Text = dsAppSt.Tables(0).Rows(0)("Nationality").ToString
                            dllCategory.Text = dsAppSt.Tables(0).Rows(0)("Category").ToString
                            txtPlace.Text = dsAppSt.Tables(0).Rows(0)("Place").ToString
                            txtBoard1.Text = dsAppSt.Tables(0).Rows(0)("edboard1").ToString
                            txtStream1.Text = dsAppSt.Tables(0).Rows(0)("edstream1").ToString
                            txtMarks1.Text = dsAppSt.Tables(0).Rows(0)("edmarks1").ToString
                            txtYears1.Text = dsAppSt.Tables(0).Rows(0)("edyrs1").ToString
                            txtBoard2.Text = dsAppSt.Tables(0).Rows(0)("edboard2").ToString
                            txtStream2.Text = dsAppSt.Tables(0).Rows(0)("edstream2").ToString
                            txtMarks2.Text = dsAppSt.Tables(0).Rows(0)("edmarks2").ToString
                            txtYears2.Text = dsAppSt.Tables(0).Rows(0)("edyrs2").ToString
                            txtBoard3.Text = dsAppSt.Tables(0).Rows(0)("edboard3").ToString
                            txtStream3.Text = dsAppSt.Tables(0).Rows(0)("edstream3").ToString
                            txtMarks3.Text = dsAppSt.Tables(0).Rows(0)("edmarks3").ToString
                            txtYears3.Text = dsAppSt.Tables(0).Rows(0)("edyrs3").ToString
                            txtBoard4.Text = dsAppSt.Tables(0).Rows(0)("edboard4").ToString
                            txtStream4.Text = dsAppSt.Tables(0).Rows(0)("edstream4").ToString
                            txtMarks4.Text = dsAppSt.Tables(0).Rows(0)("edmarks4").ToString
                            txtYears4.Text = dsAppSt.Tables(0).Rows(0)("edyrs4").ToString

                            txtOrg1.Text = dsAppSt.Tables(0).Rows(0)("ExOrg1").ToString
                            txtPh1.Text = dsAppSt.Tables(0).Rows(0)("ExPh1").ToString
                            txtDesignation1.Text = dsAppSt.Tables(0).Rows(0)("ExDesignation1").ToString
                            txtYear1.Text = dsAppSt.Tables(0).Rows(0)("ExService1").ToString
                            txtOrg2.Text = dsAppSt.Tables(0).Rows(0)("ExOrg2").ToString
                            txtPh2.Text = dsAppSt.Tables(0).Rows(0)("ExPh2").ToString
                            txtDesignation2.Text = dsAppSt.Tables(0).Rows(0)("ExDesignation2").ToString
                            txtYear2.Text = dsAppSt.Tables(0).Rows(0)("ExService2").ToString
                            txtOrg3.Text = dsAppSt.Tables(0).Rows(0)("ExOrg3").ToString
                            txtPh3.Text = dsAppSt.Tables(0).Rows(0)("ExPh3").ToString
                            txtDesignation3.Text = dsAppSt.Tables(0).Rows(0)("ExDesignation3").ToString
                            txtYear3.Text = dsAppSt.Tables(0).Rows(0)("ExService3").ToString
                            txtTotExp.Text = dsAppSt.Tables(0).Rows(0)("totexp").ToString
                            txtSecondaryEmail.Text = dsAppSt.Tables(0).Rows(0)("SecondaryEmail").ToString
                            hdnimage.Value = dsAppSt.Tables(0).Rows(0)("Profileimage").ToString

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

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


                    End If
                    Dim fi As New IO.FileInfo(FileUpload1.PostedFile.FileName)

                    Dim extension As String = fi.Extension
                    Dim fname = FileUpload1.PostedFile.FileName
                    FileUpload1.SaveAs(uploadFolder + "Images\\Student\\" + fname)

                    Path = "~/Images/Student/" + fname

                Else
                    If (hdnimage.Value <> "") Then
                        Path = hdnimage.Value
                    End If
                End If

                objLibST.emailAddress = Trim(txtEmailAddress.Text)
                objLibST.SecondaryEmailAddress = Trim(txtSecondaryEmail.Text)
                objLibST.FirstName = Trim(txtFirstName.Text)
                objLibST.LastName = Trim(txtLastName.Text)
                objLibST.MiddleName = Trim(txtMiddleName.Text)
                objLibST.DOB = Trim(txtDOB.Text)
                objLibST.Address1 = txtPermanentAddress.Text
                objLibST.Address2 = txtCorrespondenceAddress.Text
                objLibST.ContactNumber1 = txtContactNumber.Text
                objLibST.ContactNumber2 = txtMobileNumber.Text

                objLibST.Gender = dllGender.SelectedItem.Text
                objLibST.CurProfession = dllProfession.SelectedItem.Text
                objLibST.Nationality = txtNationality.Text
                objLibST.Category = dllCategory.SelectedItem.Text
                objLibST.Place = txtPlace.Text
                objLibST.edboard1 = txtBoard1.Text
                objLibST.edstream1 = txtStream1.Text

                If Len(txtMarks1.Text) <= 0 Then
                    objLibST.edmarks1 = 0
                Else
                    objLibST.edmarks1 = txtMarks1.Text
                End If


                objLibST.edyrs1 = txtYears1.Text


                objLibST.edboard2 = txtBoard2.Text
                objLibST.edstream2 = txtStream2.Text

                If Len(txtMarks2.Text) <= 0 Then
                    objLibST.edmarks2 = 0
                Else
                    objLibST.edmarks2 = txtMarks2.Text
                End If

                objLibST.edyrs2 = txtYears2.Text

                objLibST.edboard3 = txtBoard3.Text
                objLibST.edstream3 = txtStream3.Text

                If Len(txtMarks3.Text) <= 0 Then
                    objLibST.edmarks3 = 0
                Else
                    objLibST.edmarks3 = txtMarks3.Text
                End If

                objLibST.edyrs3 = txtYears3.Text

                objLibST.edboard4 = txtBoard4.Text
                objLibST.edstream4 = txtStream4.Text
                If Len(txtMarks4.Text) <= 0 Then
                    objLibST.edmarks4 = 0
                Else
                    objLibST.edmarks4 = txtMarks4.Text
                End If

                objLibST.edyrs4 = txtYears4.Text

                objLibST.ExOrg1 = txtOrg1.Text
                objLibST.ExPh1 = txtPh1.Text
                objLibST.ExDesignation1 = txtDesignation1.Text
                objLibST.ExService1 = Trim(txtYear1.Text)

                objLibST.ExOrg2 = txtOrg2.Text
                objLibST.ExPh2 = txtPh2.Text
                objLibST.ExDesignation2 = txtDesignation2.Text
                objLibST.ExService2 = Trim(txtYear2.Text)

                objLibST.ExOrg3 = txtOrg3.Text
                objLibST.ExPh3 = txtPh3.Text
                objLibST.ExDesignation3 = txtDesignation3.Text
                objLibST.ExService3 = Trim(txtYear3.Text)
                objLibST.ProfileImage = Utility.CheckNullString(Path)


                If Len(txtTotExp.Text) <= 0 Then
                    objLibST.totexp = 0
                Else
                    objLibST.totexp = txtTotExp.Text
                End If

                Dim retVal As Int16 = objDalSt.UpdateStudentProfile(objLibST)
                If retVal = 1 Then

                    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Profile Updated Successfully!') ; location.href='StudentDashboard.aspx' ; </script>")
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

        If Len(Trim(txtEmailAddress.Text)) <= 0 Then
            ObjErrDal.errMessage = "EmailID cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If


        If Len(txtDOB.Text) > 0 Then
            Dim d As DateTime
            Try
                d = DateTime.Parse(txtDOB.Text)
            Catch ex As Exception
                ObjErrDal.errMessage = "Invalid date!format should be mm/dd/yyyy"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End Try
        Else
            ObjErrDal.errMessage = "DOB cannot be left blank"
        End If


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

        If Len(txtBoard1.Text) = 0 Then
            lblMessage2.Text = "Name of board can't be left Blank class 10th"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(txtStream1.Text) = 0 Then
            lblMessage2.Text = "stream can't be left Blank in class 10th"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        ''''''''''''''''''For enter Numeric data in marks fields in 10th class''''''''''''''''''''''''''''''''''
        If CLS.checkNumeric(txtMarks1.Text) = -1 Then
            lblMessage4.Text = "Marks cannot be left blank in Class 10th"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If


        'If CLS.checkNumeric(txtMarks1.Text) = -2 Then
        '    lblMessage2.Text = "Please enter numeric value in Marks of class 10th."
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If

        '''''''''''''''''''''''''''''


        If Len(txtYears1.Text) = 0 Then
            lblMessage2.Text = "Year cannot be left blank in Class 10th "
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        'If Len(txtBoard2.Text) = 0 Then
        '    lblMessage2.Text = "Board cannot be left blank in Class 12th "
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If

        'If Len(txtStream2.Text) = 0 Then
        '    lblMessage2.Text = "Stream cannot be left blank in Class 12th "
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If
        ''''''''''''''''''For enter Numeric data in marks fields in 12th class''''''''''''''''''''''''''''''''''

        'If CLS.checkNumeric(txtMarks2.Text) = -1 Then
        '    lblMessage2.Text = "Marks cannot be left blank in Class 12th"
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If


        'If CLS.checkNumeric(txtMarks2.Text) = -2 Then
        '    lblMessage2.Text = "Please enter numeric value in Marks of class 12th."
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If


        'If CLS.checkNumeric(txtMarks3.Text) = -2 Then
        '    lblMessage2.Text = "Please enter numeric value in Marks of class 12th."
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If


        'If CLS.checkNumeric(txtMarks4.Text) = -2 Then
        '    lblMessage2.Text = "Please enter numeric value in Marks of class 12th."
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If


        'If Len(txtYears2.Text) = 0 Then
        '    lblMessage2.Text = "Year cannot be left blank in Class 12th "
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If

        If CLS.checkNumeric(txtMarks1.Text) = -2 Then
            lblMessage4.Text = "Please enter numeric or decimal  value in Marks."
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(txtMarks2.Text) > 0 Then
            If CLS.checkNumeric1(txtMarks2.Text) = -2 Then
                lblMessage2.Text = "Please enter numeric or decimal  value in Marks."
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If
        End If

        If Len(txtMarks3.Text) > 0 Then
            If CLS.checkNumeric1(txtMarks3.Text) = -2 Then
                lblMessage2.Text = "Please enter numeric or decimal  value in Marks."
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If
        End If

        If Len(txtMarks4.Text) > 0 Then
            If CLS.checkNumeric1(txtMarks4.Text) = -2 Then
                lblMessage2.Text = "Please enter numeric or decimal  value in Marks."
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If
        End If

        If (dllProfession.SelectedItem.Text = "Working") Then

            If Len(Trim(txtTotExp.Text)) = 0 Then
                lblMessage3.Text = "Total experience cannot be left blank"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If

            If Len(txtOrg1.Text) = 0 Then
                lblMessage3.Text = "Organisation name cannot be left blank "
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If

            If Len(txtPh1.Text) = 0 Then
                lblMessage3.Text = "Phone number cannot be left blank  "
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If

            If Len(txtDesignation1.Text) = 0 Then
                lblMessage3.Text = "Designation cannot be left blank"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If

            If CLS.checkNumeric(txtYear1.Text) = -1 Then
                lblMessage3.Text = "Year of service cannot be left blank"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End If


            'If CLS.checkNumeric(txtYear1.Text) = -2 Then
            '    lblMessage3.Text = "Year of service should be numeric"
            '    ObjErrDal.ChkReturn = False
            '    Return ObjErrDal
            'End If

        End If




        'If CLS.checkNumeric(txtYear2.Text) = -2 Then
        '    lblMessage3.Text = "Year of service should be numeric"
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If




        'If CLS.checkNumeric(txtYear3.Text) = -2 Then
        '    lblMessage3.Text = "Year of service should be numeric"
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If


        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

   
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("StudentDashboard.aspx")
    End Sub
End Class
