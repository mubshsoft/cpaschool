Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Imports System.Net.Mail
Imports System.Net
Partial Class Student_ApplyCourse
    Inherits System.Web.UI.Page

    Dim objLibST As New LibAddStudent
    Dim objDalSt As New DalAddStudent
    Dim objLibErr As New libErrorMsg
    Dim objLibStApp As New LibStudentAPP
    Public strEmailId As String
    Dim mailid As String
    Dim CID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If


        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                'FillDDl()
                filldata()
                CID = Request.QueryString("Cid")
                MyCLS.ConClose()
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Private Sub FillDDl()
    '    MyCLS.prcFillDDL(dllCourse, "Course", "CourseID", "CourseCode")
    'End Sub

    Sub filldata()
        Try
            mailid = Session("username")
            Dim dsStudent As New DataSet
            dsStudent = CLS.fnQuerySelectDs("select st.aid,st.stid from student st INNER JOIN login lo on st.email=lo.username where st.email = '" & mailid & "'")
            ViewState("StudentID") = dsStudent.Tables(0).Rows(0)("stid")

            Dim dsAppSt As New DataSet
            'dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,firstName,middleName,lastname,CONVERT(varchar, DOB, 103) as DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,Gender,CurProfession,Nationality,Category,Place,edboard1,edstream1,edmarks1, edyrs1,edboard2,edstream2,edmarks2, edyrs2,edboard3,edstream3,edmarks3, edyrs3,ExOrg1,ExPh1,ExDesignation1,CONVERT(varchar, ExService1, 101) as ExService1,ExOrg2,ExPh2,ExDesignation2,CONVERT(varchar, ExService2, 101) as ExService2,ExOrg3,ExPh3,ExDesignation3,CONVERT(varchar, ExService3, 101) as ExService3,totexp from student where stid =" & ViewState("StudentID"))
            dsAppSt = CLS.fnQuerySelectDs("SELECT stid,email,firstName,middleName,lastname,DOB,Address1,Address2,ContactNumber1 ,ContactNumber2,Gender,CurProfession,Nationality,Category,Place,edboard1,edstream1,edmarks1, edyrs1,edboard2,edstream2,edmarks2, edyrs2,edboard3,edstream3,edmarks3, edyrs3,ExOrg1,ExPh1,ExDesignation1,CONVERT(varchar, ExService1, 101) as ExService1,ExOrg2,ExPh2,ExDesignation2,CONVERT(varchar, ExService2, 101) as ExService2,ExOrg3,ExPh3,ExDesignation3,CONVERT(varchar, ExService3, 101) as ExService3,totexp from student where stid =" & ViewState("StudentID"))
            If dsAppSt.Tables IsNot Nothing Then
                If dsAppSt.Tables(0).Rows IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows.Count > 0 Then
                        Dim dsStCourseTitle As New DataSet
                        Dim strq1 As String
                        strq1 = "select CourseTitle from course where CourseID=" & Request.QueryString("Cid")
                        dsStCourseTitle = CLS.fnQuerySelectDs(strq1)
                        txtCourseTitle.Text = dsStCourseTitle.Tables(0).Rows(0)("CourseTitle").ToString
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

                        'If dsAppSt.Tables(0).Rows(0)("DocVerified").ToString = False Then
                        '    chkDocumentVerified.Checked = False
                        '    chkApprove.Checked = False
                        '    chkApprove.Enabled = False
                        'Else
                        '    chkDocumentVerified.Checked = True
                        'End If

                        'If dsAppSt.Tables(0).Rows(0)("Approved").ToString = False Then
                        '    chkApprove.Checked = False
                        'Else
                        '    chkApprove.Checked = True
                        'End If

                        'change made by wahid
                        dllGender.SelectedItem.Text = dsAppSt.Tables(0).Rows(0)("Gender").ToString
                        txtProfession.Text = dsAppSt.Tables(0).Rows(0)("CurProfession").ToString
                        txtNationality.Text = dsAppSt.Tables(0).Rows(0)("Nationality").ToString
                        txtCategory.Text = dsAppSt.Tables(0).Rows(0)("Category").ToString
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
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dsAppSt As New DataSet
        dsAppSt = CLS.fnQuerySelectDs("SELECT aid,email from student where stid =" & ViewState("StudentID"))
        If dsAppSt.Tables IsNot Nothing Then
            If dsAppSt.Tables(0).Rows IsNot Nothing Then
                If dsAppSt.Tables(0).Rows.Count > 0 Then
                    objLibST.aid = dsAppSt.Tables(0).Rows(0)("aid").ToString
                    ViewState("aid") = dsAppSt.Tables(0).Rows(0)("aid").ToString
                    objLibST.emailAddress = dsAppSt.Tables(0).Rows(0)("email").ToString
                    objLibST.CourseID = Request.QueryString("Cid")
                    ViewState("cid") = Request.QueryString("Cid")
                End If

            End If

        End If

        Dim dsAnotherCourse As New DataSet
        dsAnotherCourse = CLS.fnQuerySelectDs("select top 1 1 from StudentAppCourse where aid =" & ViewState("aid") & " and courseid=" & ViewState("cid") & "")

        If dsAnotherCourse.Tables IsNot Nothing Then
            If dsAnotherCourse.Tables(0).Rows IsNot Nothing Then
                If dsAnotherCourse.Tables(0).Rows.Count > 0 Then
                    'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('you had already applied for this course!') ; location.href='ApplyAnotherCourse.aspx' ; </script>")
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('you had already applied for this course!');", True)
                Else
                    Dim retVal As Int16 = objDalSt.InsertAnotherRegis(objLibST, objLibStApp)
                    If retVal > 0 Then

                        Dim Reg_Mail As String
                        Dim strSend As String = "select *from courseemail where Courseid=" & Request.QueryString("Cid")
                        Dim dsSendMail As New DataSet

                        dsSendMail = CLS.fnQuerySelectDs(strSend)
                        If dsSendMail IsNot Nothing Then
                            If dsSendMail.Tables IsNot Nothing Then
                                If dsSendMail.Tables(0).Rows IsNot Nothing Then
                                    If dsSendMail.Tables(0).Rows.Count > 0 Then
                                        Reg_Mail = dsSendMail.Tables(0).Rows(0)("Reg_Email").ToString
                                    End If
                                End If
                            End If
                        End If

                        Dim mailBody As String = ""
                        Dim AdminmailBody As String = ""
                        Dim StudentMailBody As String = ""

                        mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'>" + txtCourseTitle.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtEmailAddress.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtFirstName.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtMiddleName.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtLastName.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtDOB.Text + "</td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPermanentAddress.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtCorrespondenceAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Contact Number:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtContactNumber.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Mobile Number:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtMobileNumber.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Personal Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Gender:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + dllGender.SelectedItem.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Current Profession :</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtProfession.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Nationality :</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtNationality.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Category:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtCategory.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Educational Details:</td></tr><tr><td colspan='4' valign='top' bgcolor='#FFFFFF'><table width='100%' cellpadding='0' cellspacing='1'  bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td align='center' width='20%' bgcolor='#FFFFFF'>&nbsp;</td><td align='center' width='20%' bgcolor='#FFFFFF'>Name of the Univ./Board</td><td align='center' width='20%' bgcolor='#FFFFFF'>Stream</td><td align='center' width='20%' bgcolor='#FFFFFF'>Marks Obtained (%)</td><td align='center' width='20%' bgcolor='#FFFFFF'>Year of Completion</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>10<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears1.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>12<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears2.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Graduation:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears3.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Any Other:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears4.Text + "</td></tr></table></td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Total Years of Experience:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtTotExp.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name and Address of Organisation:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>Phone Number:</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Designation:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>Years of Service:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg1.Text + "</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh1.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation1.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear1.Text + "</td></tr>	<tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg2.Text + "</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh2.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation2.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear2.Text + "</td>	</tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg3.Text + "</td> <td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh3.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation3.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear3.Text + "</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Place:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtPlace.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy;  Copyright 2007, TISS AND FMSF</div></td></tr></table></body></html>"

                        StudentMailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td colspan='4'  bgcolor='#FFFFFF' valign='top'>" + Reg_Mail + "</td></tr><tr><td colspan='4' bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'>" + txtCourseTitle.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtEmailAddress.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtFirstName.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtMiddleName.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtLastName.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtDOB.Text + "</td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPermanentAddress.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtCorrespondenceAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Contact Number:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtContactNumber.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Mobile Number:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtMobileNumber.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Personal Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Gender:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + dllGender.SelectedItem.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Current Profession :</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtProfession.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Nationality :</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtNationality.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Category:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtCategory.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Educational Details:</td></tr><tr><td colspan='4' valign='top' bgcolor='#FFFFFF'><table width='100%' cellpadding='0' cellspacing='1'  bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td align='center' width='20%' bgcolor='#FFFFFF'>&nbsp;</td><td align='center' width='20%' bgcolor='#FFFFFF'>Name of the Univ./Board</td><td align='center' width='20%' bgcolor='#FFFFFF'>Stream</td><td align='center' width='20%' bgcolor='#FFFFFF'>Marks Obtained (%)</td><td align='center' width='20%' bgcolor='#FFFFFF'>Year of Completion</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>10<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears1.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>12<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears2.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Graduation:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears3.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Any Other:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears4.Text + "</td></tr></table></td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Total Years of Experience:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtTotExp.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name and Address of Organisation:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>Phone Number:</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Designation:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>Years of Service:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg1.Text + "</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh1.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation1.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear1.Text + "</td></tr>	<tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg2.Text + "</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh2.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation2.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear2.Text + "</td>	</tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg3.Text + "</td> <td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtPh3.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation3.Text + "</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtYear3.Text + "</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Place:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtPlace.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy;  Copyright 2007, TISS AND FMSF</div></td></tr></table></body></html>"


                        Dim m_strFromEmail As String = Session("username")
                        Dim m_strToMail As String
                        Dim m_strToCC As String
                        m_strToMail = "coordinator@fmsflearningsystems.org"
                        m_strToCC = txtEmailAddress.Text

                        SendMailMessage("fmsf@fmsflearningsystems.org", m_strToMail, "", "Registration", mailBody)

                        SendMailMessage("coordinator@fmsflearningsystems.org", m_strFromEmail, "", "Registration", StudentMailBody)


                        Dim strq As String = "select CourseTitle,screeningExam from course where CourseID=" & Request.QueryString("Cid")
                        Dim dsStCourse As DataSet = CLS.fnQuerySelectDs(strq)
                        If dsStCourse.Tables(0).Rows(0)("screeningExam").ToString() = True Then


                            Dim retVal1 As Int16 = objDalSt.InsertStudentScreeningActivate(objLibST, objLibStApp)

                            btnSave.Enabled = False
                            btnPrint.Enabled = True
                            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Course applied successfully !'); location.href='ApplyAnotherCourse.aspx' ;</script>")
                            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Course applied successfully !'); location.href='ApplyAnotherCourse.aspx' ; </script>")
                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Course applied successfully !');", True)
                        Else
                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Course applied successfully !');; location.href='StudentPanel.aspx' ;", True)
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ApplyAnotherCourse.aspx")
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
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            'Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net", 0)
            Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(from, "fmsf@123")
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception

        End Try
    End Sub
End Class
