Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Imports System.Net.Mail
Imports System.Net
Partial Class Admin_ApproveStudent
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddStudent
    Dim objDalSt As New DalAddStudent
    Dim objLibErr As New libErrorMsg
    Dim objLibStApp As New LibStudentAPP
    Public strEmailId As String
    Dim CID As Integer
    Dim staid As Integer
    ' Public di As New System.IO.DirectoryInfo("")
    'Public fiarr() As System.IO.FileInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            Else
                If Session("role") = "Admin" Then
                Else
                    Response.Redirect("../login.aspx")
                End If
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                Session("Appid") = Request.QueryString("id")
                CID = Request.QueryString("Cid")
                staid = Request.QueryString("staid")
                filldata()
            End If
            lnkUpload.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Sub filldata()
        Try
            Dim dsAppSt As New DataSet
            'dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,Degree,Discipline,courseId,approved,DocVerified from application where stid=" & Request.QueryString("id"))
            'dsAppSt = CLS.fnQuerySelectDs("SELECT aid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,approved,DocVerified,Gender,CurProfession,Nationality,Category,CONVERT(varchar, Date, 101) as Date,Place,edboard1,edstream1,edmarks1, edyrs1,edboard2,edstream2,edmarks2, edyrs2,edboard3,edstream3,edmarks3, edyrs3,ExOrg1,ExPh1,ExDesignation1,CONVERT(varchar, ExService1, 101) as ExService1,ExOrg2,ExPh2,ExDesignation2,CONVERT(varchar, ExService2, 101) as ExService2,ExOrg3,ExPh3,ExDesignation3,CONVERT(varchar, ExService3, 101) as ExService3,totexp from application where aid=" & Request.QueryString("id"))
            dsAppSt = CLS.fnQuerySelectDs("SELECT st.stAid,ap.aid,ap.email,ap.password,ap.firstName,ap.middleName,ap.lastname,CONVERT(varchar, ap.DOB, 101) as DOB,ap.Address1,ap.Address2,ap.ContactNumber1 ,ap.ContactNumber2,st.approve,ap.DocVerified,ap.Gender,ap.CurProfession,ap.Nationality,ap.Category,CONVERT(varchar, ap.applydate, 101) as Date,ap.Place,ap.edboard1,ap.edstream1,ap.edmarks1, ap.edyrs1,ap.edboard2,ap.edstream2,ap.edmarks2, ap.edyrs2,ap.edboard3,ap.edstream3,ap.edmarks3, ap.edyrs3,ap.edboard4,ap.edstream4,ap.edmarks4, ap.edyrs4,ap.ExOrg1,ap.ExPh1,ap.ExDesignation1,CONVERT(varchar, ap.ExService1, 101) as ExService1,ap.ExOrg2,ExPh2,ExDesignation2,CONVERT(varchar, ap.ExService2, 101) as ExService2,ap.ExOrg3,ap.ExPh3,ap.ExDesignation3,CONVERT(varchar, ap.ExService3, 101) as ExService3,ap.totexp,st.screeningExam,st.feeremark as feeremark,ap.applicantcategory from application ap INNER JOIN StudentAppCourse st on ap.aid=st.aid where st.courseid=" & CID & " and ap.aid=" & Session("Appid") & " and st.stAid=" & staid & "")
            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            Dim dsStCourseTitle As New DataSet
                            Dim strq As String
                            'strq = "select CourseTitle from course where CourseID=" & dsAppSt.Tables(0).Rows(0)("CourseID")
                            'ViewState("CourseID") = dsAppSt.Tables(0).Rows(0)("CourseID")
                            'dsStCourseTitle = CLS.fnQuerySelectDs(strq)
                            'txtCourseTitle.Text = dsStCourseTitle.Tables(0).Rows(0)("CourseTitle").ToString

                            strq = "select CourseTitle,screeningExam,CourseCode from course where CourseID=" & CID
                            ViewState("CourseID") = CID

                            dsStCourseTitle = CLS.fnQuerySelectDs(strq)
                            ViewState("CourseCode") = dsStCourseTitle.Tables(0).Rows(0)("CourseCode").ToString
                            txtCourseTitle.Text = dsStCourseTitle.Tables(0).Rows(0)("CourseTitle").ToString


                            txtEmailAddress.Text = dsAppSt.Tables(0).Rows(0)("email").ToString
                            Session("PrintUser") = txtEmailAddress.Text
                            Session("cid") = CID
                            txtFirstName.Text = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            txtLastName.Text = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            txtMiddleName.Text = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString
                            'Dim d As New Date
                            'd = CDate(dsAppSt.Tables(0).Rows(0)("DOB").ToString)
                            txtDOB.Text = dsAppSt.Tables(0).Rows(0)("DOB").ToString
                            txtPermanentAddress.Text = dsAppSt.Tables(0).Rows(0)("Address1").ToString
                            txtCorrespondenceAddress.Text = dsAppSt.Tables(0).Rows(0)("Address2").ToString
                            txtContactNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber1").ToString
                            txtMobileNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber2").ToString
                            strEmailId = dsAppSt.Tables(0).Rows(0)("email").ToString
                            Session("email") = strEmailId

                           
                            
                            If dsAppSt.Tables(0).Rows(0)("Approve").ToString = False Then
                                chkApprove.Checked = False
                            Else
                                chkApprove.Checked = True
                            End If

                            Try
                                If dsStCourseTitle.Tables(0).Rows(0)("screeningExam").ToString() = False Then
                                    chkScreningExam.Visible = False
                                Else
                                    chkScreningExam.Visible = True
                                End If

                            Catch ex As Exception
                                chkScreningExam.Visible = False
                            End Try

                            Try
                                If dsAppSt.Tables(0).Rows(0)("DocVerified").ToString = False Then
                                    chkDocumentVerified.Checked = False
                                    chkApprove.Checked = False
                                    chkApprove.Enabled = False
                                Else
                                    chkDocumentVerified.Checked = True
                                End If


                                If dsAppSt.Tables(0).Rows(0)("screeningExam").ToString = False Then
                                    chkScreningExam.Checked = False
                                Else
                                    chkScreningExam.Checked = True
                                End If
                            Catch ex As Exception
                            End Try


                            dllGender.SelectedItem.Text = dsAppSt.Tables(0).Rows(0)("Gender").ToString
                            txtProfession.Text = dsAppSt.Tables(0).Rows(0)("CurProfession").ToString
                            txtNationality.Text = dsAppSt.Tables(0).Rows(0)("Nationality").ToString
                            txtCategory.Text = dsAppSt.Tables(0).Rows(0)("Category").ToString

                            txtDate.Text = dsAppSt.Tables(0).Rows(0)("Date").ToString
                            'Dim d1 As New Date
                            'd1 = CDate(dsAppSt.Tables(0).Rows(0)("date").ToString)
                            ' txtDate.Text = d1


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
                            txtfeeremark.Text = dsAppSt.Tables(0).Rows(0)("feeremark").ToString
                            txtApplicantCategory.Text = dsAppSt.Tables(0).Rows(0)("applicantcategory").ToString
                        End If
                    End If
                End If
            End If

            Dim strLoginQ As String
            Dim strLogin As String
            Dim dsLogin As New DataSet

            strLoginQ = "select stid from student where aid='" & Session("Appid") & "'"
            Dim stId As Integer
            dsLogin = CLS.fnQuerySelectDs(strLoginQ)
            If dsLogin IsNot Nothing Then
                If dsLogin.Tables IsNot Nothing Then
                    If dsLogin.Tables(0).Rows IsNot Nothing Then
                        If dsLogin.Tables(0).Rows.Count > 0 Then
                            stId = dsLogin.Tables(0).Rows(0)("stid").ToString()
                        End If
                    End If
                End If
            End If


            Dim dsFees As New DataSet
            dsFees = CLS.fnQuerySelectDs("SELECT feestatus from feestatus where courseid=" & ViewState("CourseID") & "and  stid=" & stId)
            If dsFees IsNot Nothing Then
                If dsFees.Tables IsNot Nothing Then
                    If dsFees.Tables(0).Rows IsNot Nothing Then
                        If dsFees.Tables(0).Rows.Count > 0 Then
                            Dim dsStCourseTitle As New DataSet
                            Try
                                If dsFees.Tables(0).Rows(0)("feestatus").ToString = False Then
                                    chkFeePay.Checked = False
                                Else
                                    chkFeePay.Checked = True
                                End If



                            Catch ex As Exception
                            End Try

                        End If
                    End If
                End If
            End If


        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            objLibStApp.DocVerified = chkDocumentVerified.Checked
            objLibStApp.Approve = chkApprove.Checked
            objLibStApp.stID = Session("Appid")

            Dim dsStCourse As New DataSet
            Dim strq1 As String = "select CourseTitle,screeningExam from course where CourseID=" & Request.QueryString("Cid")
            dsStCourse = CLS.fnQuerySelectDs(strq1)
            If dsStCourse.Tables(0).Rows(0)("screeningExam").ToString() = False Then

            Else
                objLibST.screeningExam = chkScreningExam.Checked
            End If


            Dim dsAppSt As New DataSet
            'dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,courseId,approved,DocVerified,Gender,CurProfession,Nationality,Category,Place,edboard1,edstream1,edmarks1,edyrs1,edboard2,edstream2,edmarks2,edyrs2,edboard3,edstream3,edmarks3, edyrs3,edboard4,edstream4,edmarks4,edyrs4,ExOrg1,ExPh1,ExDesignation1,CONVERT(varchar, ExService1, 101) as ExService1,ExOrg2,ExPh2,ExDesignation2,CONVERT(varchar, ExService2, 101) as ExService2,ExOrg3,ExPh3,ExDesignation3,CONVERT(varchar, ExService3, 101) as ExService3,totexp from student where stid=" & Request.QueryString("id"))
            'dsAppSt = CLS.fnQuerySelectDs("SELECT st.aid,st.stid,sr.courseid,st.email,st.password,st.firstName,st.middleName,st.lastname,CONVERT(varchar, st.DOB, 101) as DOB,st.Address1,st.Address2,st.ContactNumber1 ,st.ContactNumber2,ap.approve,st.Gender,st.CurProfession,st.Nationality,st.Category,st.Place,st.edboard1,st.edstream1,st.edmarks1,st.edyrs1,st.edboard2,st.edstream2,st.edmarks2,st.edyrs2,st.edboard3,st.edstream3,st.edmarks3,st.edyrs3,st.edboard4,st.edstream4,st.edmarks4,st.edyrs4,st.ExOrg1,st.ExPh1,st.ExDesignation1,CONVERT(varchar, st.ExService1, 101) as ExService1,st.ExOrg2,st.ExPh2,st.ExDesignation2,CONVERT(varchar, st.ExService2, 101) as ExService2,st.ExOrg3,st.ExPh3,st.ExDesignation3,CONVERT(varchar, st.ExService3, 101) as ExService3,st.totexp from student st INNER JOIN StudentAppCourse ap on st.aid=ap.aid INNER JOIN StudentRegCourse sr on st.stid=sr.stid where st.stid=" & Request.QueryString("id"))
            'dsAppSt = CLS.fnQuerySelectDs("SELECT aid,email,password,firstName,middleName,lastname,CONVERT(varchar, DOB, 101) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,approved,DocVerified,Gender,CurProfession,Nationality,Category,CONVERT(varchar, Date, 101) as Date,Place,edboard1,edstream1,edmarks1, edyrs1,edboard2,edstream2,edmarks2, edyrs2,edboard3,edstream3,edmarks3, edyrs3,edboard4,edstream4,edmarks4,edyrs4,ExOrg1,ExPh1,ExDesignation1,CONVERT(varchar, ExService1, 101) as ExService1,ExOrg2,ExPh2,ExDesignation2,CONVERT(varchar, ExService2, 101) as ExService2,ExOrg3,ExPh3,ExDesignation3,CONVERT(varchar, ExService3, 101) as ExService3,totexp from application where aid=" & Request.QueryString("id"))
            dsAppSt = CLS.fnQuerySelectDs("SELECT st.stAid,ap.aid,ap.email,ap.password,ap.firstName,ap.middleName,ap.lastname,CONVERT(varchar, ap.DOB, 101) as DOB,ap.Address1,ap.Address2,ap.ContactNumber1 ,ap.ContactNumber2,st.approve,ap.DocVerified,ap.Gender,ap.CurProfession,ap.Nationality,ap.Category,CONVERT(varchar, ap.Date, 101) as Date,ap.Place,ap.edboard1,ap.edstream1,ap.edmarks1, ap.edyrs1,ap.edboard2,ap.edstream2,ap.edmarks2, ap.edyrs2,ap.edboard3,ap.edstream3,ap.edmarks3, ap.edyrs3,ap.edboard4,ap.edstream4,ap.edmarks4, ap.edyrs4,ap.ExOrg1,ap.ExPh1,ap.ExDesignation1,CONVERT(varchar, ap.ExService1, 101) as ExService1,ap.ExOrg2,ExPh2,ExDesignation2,CONVERT(varchar, ap.ExService2, 101) as ExService2,ap.ExOrg3,ap.ExPh3,ap.ExDesignation3,CONVERT(varchar, ap.ExService3, 101) as ExService3,ap.totexp,st.feeremark,ap.applicantcategory from application ap INNER JOIN StudentAppCourse st on ap.aid=st.aid where st.courseid=" & Request.QueryString("Cid") & " and ap.aid=" & Session("Appid") & " and st.stAid=" & Request.QueryString("staid") & "")
            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            Dim dsStCourseTitle As New DataSet
                            Dim strq As String
                            'wahid change this
                            'strq = "select CourseTitle from course where CourseID=" & dsAppSt.Tables(0).Rows(0)("courseid")
                            strq = "select CourseTitle from course where CourseID=" & ViewState("CourseID")
                            dsStCourseTitle = CLS.fnQuerySelectDs(strq)
                            txtCourseTitle.Text = dsStCourseTitle.Tables(0).Rows(0)("CourseTitle").ToString
                            txtEmailAddress.Text = dsAppSt.Tables(0).Rows(0)("email").ToString
                            txtFirstName.Text = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            txtLastName.Text = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            txtMiddleName.Text = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString
                            'txtDOB.Text = dsAppSt.Tables(0).Rows(0)("DOB").ToString
                            'Dim d As New Date
                            'd = CDate(dsAppSt.Tables(0).Rows(0)("DOB").ToString)
                            txtDOB.Text = dsAppSt.Tables(0).Rows(0)("DOB").ToString
                            txtPermanentAddress.Text = dsAppSt.Tables(0).Rows(0)("Address1").ToString
                            txtCorrespondenceAddress.Text = dsAppSt.Tables(0).Rows(0)("Address2").ToString
                            txtContactNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber1").ToString
                            txtMobileNumber.Text = dsAppSt.Tables(0).Rows(0)("ContactNumber2").ToString
                            'txtDegree.Text = dsAppSt.Tables(0).Rows(0)("degree").ToString
                            'txtDiscipline.Text = dsAppSt.Tables(0).Rows(0)("Discipline").ToString


                            'change made by wahid
                            dllGender.SelectedItem.Text = dsAppSt.Tables(0).Rows(0)("Gender").ToString
                            txtProfession.Text = dsAppSt.Tables(0).Rows(0)("CurProfession").ToString
                            txtNationality.Text = dsAppSt.Tables(0).Rows(0)("Nationality").ToString
                            txtCategory.Text = dsAppSt.Tables(0).Rows(0)("Category").ToString
                            'txtDate.Text = dsAppSt.Tables(0).Rows(0)("Date").ToString
                            txtPlace.Text = dsAppSt.Tables(0).Rows(0)("Place").ToString
                            txtBoard1.Text = dsAppSt.Tables(0).Rows(0)("edboard1").ToString
                            txtStream1.Text = dsAppSt.Tables(0).Rows(0)("edstream1").ToString
                            txtMarks1.Text = dsAppSt.Tables(0).Rows(0)("edmarks1").ToString
                            txtYear1.Text = dsAppSt.Tables(0).Rows(0)("edyrs1").ToString
                            txtBoard2.Text = dsAppSt.Tables(0).Rows(0)("edboard2").ToString
                            txtStream2.Text = dsAppSt.Tables(0).Rows(0)("edstream2").ToString
                            txtMarks2.Text = dsAppSt.Tables(0).Rows(0)("edmarks2").ToString
                            txtYear2.Text = dsAppSt.Tables(0).Rows(0)("edyrs2").ToString
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
                            strEmailId = dsAppSt.Tables(0).Rows(0)("email").ToString
                            Session("email") = strEmailId

                            ViewState("aid") = dsAppSt.Tables(0).Rows(0)("aid").ToString
                            'fill property 

                            'objLibST.CourseID = dsAppSt.Tables(0).Rows(0)("CourseID")
                            objLibST.CourseID = ViewState("CourseID")
                            objLibST.emailAddress = dsAppSt.Tables(0).Rows(0)("email").ToString
                            objLibST.Password = dsAppSt.Tables(0).Rows(0)("password").ToString
                            objLibST.FirstName = dsAppSt.Tables(0).Rows(0)("FirstName").ToString
                            objLibST.LastName = dsAppSt.Tables(0).Rows(0)("LastNAme").ToString
                            objLibST.MiddleName = dsAppSt.Tables(0).Rows(0)("MiddleName").ToString

                            'Dim d As New Date
                            'd = CDate(dsAppSt.Tables(0).Rows(0)("DOB").ToString)

                            'objLibST.DOB = dsAppSt.Tables(0).Rows(0)("DOB").ToString
                            objLibST.DOB = txtDOB.Text
                            objLibST.Address1 = dsAppSt.Tables(0).Rows(0)("Address1").ToString
                            objLibST.Address2 = dsAppSt.Tables(0).Rows(0)("Address2").ToString
                            objLibST.ContactNumber1 = dsAppSt.Tables(0).Rows(0)("ContactNumber1").ToString
                            objLibST.ContactNumber2 = dsAppSt.Tables(0).Rows(0)("ContactNumber2").ToString
                            'objLibST.Degree = dsAppSt.Tables(0).Rows(0)("degree").ToString
                            'objLibST.Discipline = dsAppSt.Tables(0).Rows(0)("Discipline").ToString

                            objLibST.Gender = dsAppSt.Tables(0).Rows(0)("Gender").ToString
                            objLibST.CurProfession = dsAppSt.Tables(0).Rows(0)("CurProfession").ToString
                            objLibST.Nationality = dsAppSt.Tables(0).Rows(0)("Nationality").ToString
                            objLibST.Category = dsAppSt.Tables(0).Rows(0)("Category").ToString
                            'objLibST.Date1 = dsAppSt.Tables(0).Rows(0)("Date").ToString
                            objLibST.Place = dsAppSt.Tables(0).Rows(0)("Place").ToString
                            objLibST.edboard1 = dsAppSt.Tables(0).Rows(0)("edboard1").ToString
                            objLibST.edstream1 = dsAppSt.Tables(0).Rows(0)("edstream1").ToString
                            objLibST.edmarks1 = dsAppSt.Tables(0).Rows(0)("edmarks1").ToString
                            objLibST.edyrs1 = dsAppSt.Tables(0).Rows(0)("edyrs1").ToString
                            objLibST.edboard2 = dsAppSt.Tables(0).Rows(0)("edboard2").ToString
                            objLibST.edstream2 = dsAppSt.Tables(0).Rows(0)("edstream2").ToString
                            objLibST.edmarks2 = dsAppSt.Tables(0).Rows(0)("edmarks2").ToString
                            objLibST.edyrs2 = dsAppSt.Tables(0).Rows(0)("edyrs2").ToString
                            objLibST.edboard3 = dsAppSt.Tables(0).Rows(0)("edboard3").ToString
                            objLibST.edstream3 = dsAppSt.Tables(0).Rows(0)("edstream3").ToString
                            objLibST.edmarks3 = dsAppSt.Tables(0).Rows(0)("edmarks3").ToString
                            objLibST.edyrs3 = dsAppSt.Tables(0).Rows(0)("edyrs3").ToString

                            objLibST.edboard4 = dsAppSt.Tables(0).Rows(0)("edboard4").ToString
                            objLibST.edstream4 = dsAppSt.Tables(0).Rows(0)("edstream4").ToString
                            objLibST.edmarks4 = dsAppSt.Tables(0).Rows(0)("edmarks4").ToString
                            objLibST.edyrs4 = dsAppSt.Tables(0).Rows(0)("edyrs4").ToString

                            objLibST.ExOrg1 = dsAppSt.Tables(0).Rows(0)("ExOrg1").ToString
                            objLibST.ExPh1 = dsAppSt.Tables(0).Rows(0)("ExPh1").ToString
                            objLibST.ExDesignation1 = dsAppSt.Tables(0).Rows(0)("ExDesignation1").ToString
                            objLibST.ExService1 = dsAppSt.Tables(0).Rows(0)("ExService1").ToString
                            objLibST.ExOrg2 = dsAppSt.Tables(0).Rows(0)("ExOrg2").ToString
                            objLibST.ExPh2 = dsAppSt.Tables(0).Rows(0)("ExPh2").ToString
                            objLibST.ExDesignation2 = dsAppSt.Tables(0).Rows(0)("ExDesignation2").ToString
                            objLibST.ExService2 = dsAppSt.Tables(0).Rows(0)("ExService2").ToString
                            objLibST.ExOrg3 = dsAppSt.Tables(0).Rows(0)("ExOrg3").ToString
                            objLibST.ExPh3 = dsAppSt.Tables(0).Rows(0)("ExPh3").ToString
                            objLibST.ExDesignation3 = dsAppSt.Tables(0).Rows(0)("ExDesignation3").ToString
                            objLibST.ExService3 = dsAppSt.Tables(0).Rows(0)("ExService3").ToString
                            objLibST.totexp = dsAppSt.Tables(0).Rows(0)("totexp").ToString

                            objLibST.aid = ViewState("aid")
                            objLibST.screeningExam = chkScreningExam.Checked
                            objLibST.feestatus = chkFeePay.Checked
                            objLibST.feeremark = txtfeeremark.Text
                            objLibST.ApplicantCategory = txtApplicantCategory.Text
                            ''''''' add on 29th june

                            objLibST.stAid = dsAppSt.Tables(0).Rows(0)("stAid").ToString

                        End If

                    End If
                End If
            End If
            objLibErr = fnValidate()
            If objLibErr.ChkReturn = True Then

                ' Directory.CreateDirectory(Server.MapPath("") & "/studentDoc/" & objLibST.emailAddress)
                Dim retVal As Int16 = objDalSt.InsertStudentRegis(objLibST, objLibStApp)

                If retVal > 0 Then
                    MyCLS.fnMSG("Student Updated!")
                    'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Student Updated!'); location.href='index.html' ;</script>")

                    'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Student approved successfully!'); location.href='ListStudent.aspx' ;</script>")
                    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Student saved successfully!');</script>")
                    Response.Redirect("listStudent.aspx")
                    ' Response.Redirect("ListStudent.aspx?cid=" & ViewState("CourseID"))
                Else
                End If
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try
    End Sub



    Public Function fnValidate() As Object
        Dim ObjErrDal As New libErrorMsg

    

        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Protected Sub chkDocumentVerified_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDocumentVerified.CheckedChanged
        If chkScreningExam.Visible = True Then
            If chkScreningExam.Checked = False Then
                chkApprove.Enabled = False
            Else
                chkApprove.Enabled = True
            End If
        Else
            If chkDocumentVerified.Checked = False Then
                chkApprove.Enabled = False
                chkApprove.Checked=False
            Else
                chkApprove.Enabled = True
            End If
        End If
        
    End Sub

    Protected Sub lnkUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkUpload.Click
        Try
            Dim strPath As String
            Dim fn As String
            fn = System.IO.Path.GetFileName(Fupd.PostedFile.FileName)
            strPath = Server.MapPath("..\") & "studentDoc\" & Session("email") & "\" & fn
            Fupd.PostedFile.SaveAs(strPath)
            Response.Redirect("Approvestudent.aspx?id=" & Request.QueryString("id"))
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ListStudent.aspx")
    End Sub

    Protected Sub chkScreningExam_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkScreningExam.CheckedChanged
        If chkDocumentVerified.Checked = False Then
            chkApprove.Enabled = False
            chkApprove.Checked=false
        Else
            chkApprove.Enabled = True
        End If
    End Sub

    Protected Sub chkFeePay_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFeePay.CheckedChanged

    End Sub

    Protected Sub SendMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SendMail.Click
        Dim refId As String
        Dim stid As String
        Dim strid As String = "select * from student where email='" & Session("email") & "'"
        Dim dsSid As New DataSet

        dsSid = CLS.fnQuerySelectDs(strid)
        If dsSid IsNot Nothing Then
            If dsSid.Tables IsNot Nothing Then
                If dsSid.Tables(0).Rows IsNot Nothing Then
                    If dsSid.Tables(0).Rows.Count > 0 Then
                        stid = dsSid.Tables(0).Rows(0)("stid").ToString
                    End If
                End If
            End If
        End If

        Dim stRefid As String = "select * from studentregcourse where Courseid=" & Request.QueryString("Cid") & " and stid=" & stid
        Dim dsRefid As New DataSet

        dsRefid = CLS.fnQuerySelectDs(stRefid)
        If dsRefid IsNot Nothing Then
            If dsRefid.Tables IsNot Nothing Then
                If dsRefid.Tables(0).Rows IsNot Nothing Then
                    If dsRefid.Tables(0).Rows.Count > 0 Then
                        refId = dsRefid.Tables(0).Rows(0)("refrenceid").ToString
                    End If
                End If
            End If
        End If

        Dim Reg_Mail As String
        Dim strSend As String = "select *from courseemail where Courseid=" & Request.QueryString("Cid")
        Dim dsSendMail As New DataSet

        dsSendMail = CLS.fnQuerySelectDs(strSend)
        If dsSendMail IsNot Nothing Then
            If dsSendMail.Tables IsNot Nothing Then
                If dsSendMail.Tables(0).Rows IsNot Nothing Then
                    If dsSendMail.Tables(0).Rows.Count > 0 Then
                        Reg_Mail = dsSendMail.Tables(0).Rows(0)("Approv_Email").ToString
                    End If
                End If
            End If
        End If
        Dim mailBody As String = ""
        Dim m_strFromEmail As String = Session("username")
        Dim m_strToMail As String
        mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr ><td colspan='4' bgcolor='#FFFFFF' valign='top'>" + Reg_Mail + "</td></tr><tr ><td valign='top' width='30%' bgcolor='#FFFFFF'>Reference Id</td><td colspan='3' valign='top' width='30%' bgcolor='#FFFFFF'>" + refId + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'>" + txtCourseTitle.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtEmailAddress.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtFirstName.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtMiddleName.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtLastName.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtDOB.Text + "</td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPermanentAddress.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtCorrespondenceAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Contact Number:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtContactNumber.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Mobile Number:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtMobileNumber.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Personal Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Gender:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + dllGender.SelectedItem.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Current Profession :</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtProfession.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Nationality :</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtNationality.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Category:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtCategory.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Educational Details:</td></tr><tr><td colspan='4' valign='top' bgcolor='#FFFFFF'><table width='100%' cellpadding='0' cellspacing='1'  bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td align='center' width='20%' bgcolor='#FFFFFF'>&nbsp;</td><td align='center' width='20%' bgcolor='#FFFFFF'>Name of the Univ./Board</td><td align='center' width='20%' bgcolor='#FFFFFF'>Stream</td><td align='center' width='20%' bgcolor='#FFFFFF'>Marks Obtained (%)</td><td align='center' width='20%' bgcolor='#FFFFFF'>Year of Completion</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>10<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears1.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>12<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears2.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Graduation:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears3.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Any Other:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears4.Text + "</td></tr></table></td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Total Years of Experience:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtTotExp.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name and Address of Organisation:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>Phone Number:</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Designation:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>Years of Service:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg1.Text + "</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh1.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation1.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear1.Text + "</td></tr>	<tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg2.Text + "</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh2.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation2.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear2.Text + "</td>	</tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg3.Text + "</td> <td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh3.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation3.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear3.Text + "</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Place:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtPlace.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy;  Copyright 2007, TISS AND FMSF</div></td></tr></table></body></html>"
        'mailBody = Reg_Mail
        m_strToMail = txtEmailAddress.Text
        SendMailMessage("coordinator@cpaschooloflearning.org", m_strToMail, "", "Admission Confirmation", mailBody)
    End Sub
    Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal mailCC As String, ByVal subject As String, ByVal body As String)
        Try
            Dim mMailMessage As New MailMessage()
            mMailMessage.From = New MailAddress(from)
            mMailMessage.To.Add(New MailAddress(recepient))
            If (mailCC IsNot Nothing) AndAlso (mailCC <> String.Empty) Then
                mMailMessage.CC.Add(New MailAddress(mailCC))
            End If
            mMailMessage.Subject = subject
            mMailMessage.Body = body
            mMailMessage.IsBodyHtml = True
            mMailMessage.Priority = MailPriority.Normal
            'Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net", 0)
            Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(from, "fmsf@123")
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception
        End Try
    End Sub

End Class
