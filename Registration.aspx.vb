﻿Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Configuration

Partial Class Admin_Registration
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddStudent
    Dim objDalSt As New DalAddStudent
    Dim objLibErr As New libErrorMsg

    Dim objLibStApp As New LibStudentAPP
    'Protected Sub lnkAtach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAtach.Click
    '    Try
    '        If Fupd.HasFile = True Then
    '            Dim arrStr() As String = Fupd.PostedFile.FileName.Split("\")
    '            Dim OldFileName As String
    '            Dim l As Integer = arrStr.Length
    '            OldFileName = arrStr(l - 1)
    '            'lst.Items.Add(OldFileName)
    '            'lst.Items.Add(Fupd.PostedFile.FileName)
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Len(Session("username")) <= 0 Then
            'anc1.Visible = False
            'anc2.Visible = False
        End If
        If Not IsPostBack Then
            MyCLS.ConOpen()
            FillDDl()
            ViewState("s") = Request.QueryString("s")
            If Len(Request.QueryString("s")) > 0 Then
                'anc1.Visible = False
                'anc2.Visible = False
            End If
            MyCLS.ConClose()
        End If

    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
    End Sub
    Protected Sub txtPassword_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.PreRender
        txtPassword.Attributes("value") = txtPassword.Text
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            objLibErr = fnValidate()
            If objLibErr.ChkReturn = True Then
                objLibST.CourseID = Trim(ddlCourse.SelectedValue)
                objLibST.emailAddress = Trim(txtEmailAddress.Text)
                Session("email") = Trim(txtEmailAddress.Text)
                objLibST.Password = Trim(txtPassword.Text)
                objLibST.FirstName = Trim(txtFirstName.Text)
                objLibST.LastName = Trim(txtLastName.Text)
                objLibST.MiddleName = Trim(txtMiddleName.Text)
                objLibST.DOB = Trim(txtDOB.Text)
                objLibST.Address1 = txtPermanentAddress.Text
                objLibST.Address2 = txtCorrespondenceAddress.Text
                objLibST.ContactNumber1 = txtContactNumber.Text
                objLibST.ContactNumber2 = txtMobileNumber.Text

                'change made by wahid 
                objLibST.Gender = dllGender.SelectedItem.Text
                objLibST.CurProfession = dllProfession.SelectedItem.Text
                objLibST.Nationality = dllCountry.SelectedItem.Text
                objLibST.Category = dllCategory.SelectedItem.Text
                objLibST.Place = txtPlace.Text
                objLibST.edboard1 = txtBoard1.Text
                objLibST.edstream1 = txtStream1.Text
                objLibST.ApplicantCategory = ddlapplicantCategory.SelectedItem.Text
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
                If dllCategory.SelectedIndex = 0 Then
                    objLibST.Category = "Not Given"
                End If


                If Len(txtTotExp.Text) <= 0 Then
                    objLibST.totexp = 0
                Else
                    objLibST.totexp = txtTotExp.Text
                End If



                Directory.CreateDirectory(Server.MapPath("") & "\studentDoc\" & objLibST.emailAddress)
                Dim retVal As Int16 = objDalSt.InsertStudent(objLibST)
                If retVal = 2 Then
                    ' change made by wahid on 19th, October

                    Dim strq As String = "select CourseTitle,screeningExam from course where CourseID=" & Trim(ddlCourse.SelectedValue)
                    Dim dsStCourse As DataSet = CLS.fnQuerySelectDs(strq)
                    If dsStCourse.Tables(0).Rows(0)("screeningExam").ToString() = True Then
                        Dim strq1 As String = "select CourseID from ActivateScreening where CourseID=" & Trim(ddlCourse.SelectedValue)
                        Dim dsStScreening As DataSet = CLS.fnQuerySelectDs(strq1)
                        If dsStScreening.Tables(0).Rows.Count > 0 Then
                            Dim retVal1 As Int16 = objDalSt.InsertStudentScreeningActivate(objLibST, objLibStApp)
                        End If

                    End If

                    ' change made by wahid on 19th, October

                    If Not Fupd.PostedFile Is Nothing And Fupd.PostedFile.ContentLength > 0 Then
                        Dim fn As String
                        fn = System.IO.Path.GetFileName(Fupd.PostedFile.FileName)
                        Try
                            Dim strpath As String
                            strpath = Server.MapPath("") & "/studentdoc/" & objLibST.emailAddress & "/" & fn
                            If File.Exists(strpath) Then
                                lblMessage.Text = "File already exists."
                                lblMessage.ForeColor = Drawing.Color.Red
                                Exit Sub
                            Else
                                Fupd.PostedFile.SaveAs(strpath)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                    btnSave.Enabled = False
                    btnPrint.Enabled = True
                    MyCLS.fnMSG("Student Added!")

                    'Response.Write("<script>alert('You have been registered successfully!')</script>")
                    'Response.Redirect("Default.aspx")
                    'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You have been registered successfully!'); location.href='Default.aspx' ;</script>")
                    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You have been registered successfully!'); </script>")
                    Try
                        Dim Reg_Mail As String
                        Dim Courseemailid As String
                        Dim strSend As String = "select * from courseemail where Courseid=" & ddlCourse.SelectedValue
                        Dim dsSendMail As New DataSet

                        dsSendMail = CLS.fnQuerySelectDs(strSend)
                        If dsSendMail IsNot Nothing Then
                            If dsSendMail.Tables IsNot Nothing Then
                                If dsSendMail.Tables(0).Rows IsNot Nothing Then
                                    If dsSendMail.Tables(0).Rows.Count > 0 Then
                                        Reg_Mail = dsSendMail.Tables(0).Rows(0)("Reg_Email").ToString
                                        Courseemailid = dsSendMail.Tables(0).Rows(0)("courseidmail").ToString
                                    End If
                                End If
                            End If
                        End If
                        Dim AdminmailBody As String = ""
                        Dim StudentMailBody As String = ""


                        AdminmailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'>" + ddlCourse.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtEmailAddress.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtFirstName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtMiddleName.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtLastName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtDOB.Text + "</td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPermanentAddress.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtCorrespondenceAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Contact Number:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtContactNumber.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Mobile Number:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtMobileNumber.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Personal Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Gender:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllGender.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Current Profession :</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + dllProfession.SelectedItem.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Nationality :</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllCountry.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Category:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + dllCategory.SelectedItem.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Applicant Category:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + ddlapplicantCategory.SelectedItem.Text + "</td><td width='15%'  bgcolor='#FFFFFF'>&nbsp;</td><td width='15%'  bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Educational Details:</td></tr><tr><td colspan='4' valign='top' bgcolor='#FFFFFF'><table width='100%' cellpadding='0' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td align='center' width='20%' bgcolor='#FFFFFF'>&nbsp;</td><td align='center' width='20%' bgcolor='#FFFFFF'>Name of the Univ./Board</td><td align='center' width='20%' bgcolor='#FFFFFF'>Stream</td><td align='center' width='20%' bgcolor='#FFFFFF'>Marks Obtained (%)</td><td align='center' width='20%' bgcolor='#FFFFFF'>Year of Completion</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>10<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears1.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>12<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears2.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Graduation:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears3.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Any Other:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears4.Text + "</td></tr></table></td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Total Years of Experience:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtTotExp.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name and Address of Organisation:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>Phone Number:</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Designation:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>Years of Service:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg1.Text + "</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh1.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation1.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear1.Text + "</td></tr> <tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg2.Text + "</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh2.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation2.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear2.Text + "</td> </tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg3.Text + "</td> <td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh3.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation3.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear3.Text + "</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Place:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtPlace.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy; Copyright 2007, FMSF</div></td></tr></table></body></html>"
                        StudentMailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr ><td colspan='4' bgcolor='#FFFFFF' valign='top'>" + Reg_Mail + "</td></tr><tr><td colspan='4' bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'>" + ddlCourse.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtEmailAddress.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtFirstName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtMiddleName.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtLastName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtDOB.Text + "</td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPermanentAddress.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtCorrespondenceAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Contact Number:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtContactNumber.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Mobile Number:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtMobileNumber.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Personal Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Gender:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllGender.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Current Profession :</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + dllProfession.SelectedItem.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Nationality :</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllCountry.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Category:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + dllCategory.SelectedItem.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Applicant Category:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + ddlapplicantCategory.SelectedItem.Text + "</td><td width='15%'  bgcolor='#FFFFFF'>&nbsp;</td><td width='15%'  bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Educational Details:</td></tr><tr><td colspan='4' valign='top' bgcolor='#FFFFFF'><table width='100%' cellpadding='0' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td align='center' width='20%' bgcolor='#FFFFFF'>&nbsp;</td><td align='center' width='20%' bgcolor='#FFFFFF'>Name of the Univ./Board</td><td align='center' width='20%' bgcolor='#FFFFFF'>Stream</td><td align='center' width='20%' bgcolor='#FFFFFF'>Marks Obtained (%)</td><td align='center' width='20%' bgcolor='#FFFFFF'>Year of Completion</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>10<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears1.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>12<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears2.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Graduation:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears3.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Any Other:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears4.Text + "</td></tr></table></td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Total Years of Experience:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtTotExp.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name and Address of Organisation:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>Phone Number:</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Designation:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>Years of Service:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg1.Text + "</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh1.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation1.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear1.Text + "</td></tr> <tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg2.Text + "</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh2.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation2.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear2.Text + "</td> </tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg3.Text + "</td> <td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh3.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation3.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear3.Text + "</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Place:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtPlace.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy; Copyright 2007,  FMSF</div></td></tr></table></body></html>"


                        Dim m_strFromEmail As String
                        Dim m_strFromName As String = ""
                        Dim m_strToMail As String
                        Dim m_strToCC As String

                        m_strFromEmail = txtEmailAddress.Text


                        'SendMailMessage("mohammed.mubashir221@gmail.com", "coordinator@fmsflearningsystems.org", "", "Registration Form", AdminmailBody)
                        'SendMailMessage("coordinator@fmsflearningsystems.org", m_strFromEmail, "", "Regarding submission of documents", StudentMailBody)
                        SendMailMessage("fmsf@fmsflearningsystems.org", m_strFromEmail, "chhaya.netsoft@gmail.com", "Regarding submission of documents", StudentMailBody)
                        SendMailMessage("mohammed.mubashir221@gmail.com", "chaya.pandey@gmail.com", "chhaya.netsoft@gmail.com", "Registration Form", AdminmailBody)







                    Catch ex As Exception

                    End Try


                    If ViewState("s") = "3" Then

                    Else
                        Response.Redirect("admin/Adminlogin.aspx")
                    End If
                ElseIf retVal = MyCLS.EStatus.Err Then
                    MyCLS.fnMSG("Error Occured!")
                End If
                'Response.Write("<script>alert('You have been registered successfully!')</script>")
                'Response.Redirect("Default.aspx")
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try







    End Sub

    Public Function SendMailGodady(ByVal m_strFromName As String, ByVal m_strFromEmail As String, ByVal m_strToName As String, ByVal m_strToEmail As String, ByVal m_strCCEmail As String, ByVal m_strBCCEmail As String, _
ByVal m_strAttachment As String, ByVal m_strSubject As String, ByVal m_strMessage As String) As [Boolean]

        Try

            Dim SERVER As String = ConfigurationSettings.AppSettings("SMTPHost").ToString()

            Dim re As New Regex("^([\w-'\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")

            Dim oMail As New MailMessage()

            oMail.From = New MailAddress(m_strFromEmail, m_strFromName)

            If m_strToEmail <> "" Then
                Dim arr As String() = m_strToEmail.Split(","c)
                For i As Integer = 0 To arr.Length - 1
                    If arr(i).ToString() <> "" Then
                        Dim match As Match = re.Match(arr(i))
                        If Not match.Success Then
                            Return False
                        Else
                            'oMail.To.Add(m_strToEmail); 


                            oMail.[To].Add(arr(i).ToString())
                        End If
                    End If

                Next
            End If

            If m_strCCEmail <> "" Then
                Dim arr As String() = m_strCCEmail.Split(","c)
                For i As Integer = 0 To arr.Length - 1
                    If arr(i).ToString() <> "" Then
                        Dim match As Match = re.Match(arr(i))
                        If Not match.Success Then
                            Return False
                        Else
                            'oMail.To.Add(m_strToEmail); 


                            oMail.CC.Add(arr(i).ToString())
                        End If
                    End If

                Next
            End If

            If m_strBCCEmail <> "" Then
                Dim arr As String() = m_strBCCEmail.Split(","c)
                For i As Integer = 0 To arr.Length - 1
                    If arr(i).ToString() <> "" Then
                        Dim match As Match = re.Match(arr(i))
                        If Not match.Success Then
                            Return False
                        Else
                            'oMail.To.Add(m_strToEmail); 


                            oMail.Bcc.Add(arr(i).ToString())
                        End If
                    End If

                Next
            End If

            oMail.CC.Add(m_strCCEmail)

            'oMail.Bcc.Add(m_strBCCEmail); 

            oMail.Subject = m_strSubject

            oMail.IsBodyHtml = True
            ' enumeration 
            oMail.Priority = MailPriority.High
            ' enumeration 
            oMail.Body = m_strMessage

            '"<html><boby>Test email subject</body></html>"; 

            Dim Client As New SmtpClient(SERVER)
            'System.Net.NetworkCredential cr = new System.Net.NetworkCredential("contactus@anukconsulting.com", "nitindheer"); 
            'Client.Credentials = cr; 

            Client.Send(oMail)



            Return True
        Catch ex As Exception

            Return False
        Finally

        End Try
    End Function

    Public Function fnValidate() As Object
        Dim ObjErrDal As New libErrorMsg

        If ddlCourse.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select course"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(Trim(txtEmailAddress.Text)) <= 0 Then
            ObjErrDal.errMessage = "EmailID cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

      
        'If Len(txtPassword.Text) <= 0 Then
        '    ObjErrDal.errMessage = "Password  cannot be left blank"
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If


        'If Len(txtFirstName.Text) <= 0 Then
        '    ObjErrDal.errMessage = "First name cannot be left blank"
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If

        'If Len(txtLastName.Text) <= 0 Then
        '    ObjErrDal.errMessage = "Last name cannot be left blank"
        '    ObjErrDal.ChkReturn = False
        '    Return ObjErrDal
        'End If


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

        If ddlapplicantCategory.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select applicant Category"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If dllCountry.SelectedItem.Text = "SELECT" Then
            ObjErrDal.errMessage = "Please select country"
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
            lblMessage2.Text = "Marks cannot be left blank in Class 10th"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If


        If CLS.checkNumeric1(txtMarks1.Text) = -2 Then
            lblMessage2.Text = "Please enter numeric or decimal  value in Marks."
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

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
            If CLS.checkNumeric1(txtMarks4.Text) = -1 Then
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



        Dim dsChkEmail As New DataSet
        'dsChkEmail = CLS.fnQuerySelectDs("select * from application where email='" & Trim(txtEmailAddress.Text) & "' and courseid=" & ddlCourse.SelectedValue)
        dsChkEmail = CLS.fnQuerySelectDs("select * from application where email='" & Trim(txtEmailAddress.Text) & "'")
        If dsChkEmail IsNot Nothing Then
            If dsChkEmail.Tables IsNot Nothing Then
                If dsChkEmail.Tables(0).Rows IsNot Nothing Then
                    If dsChkEmail.Tables(0).Rows.Count > 0 Then
                        ObjErrDal.errMessage = "Student already registered"
                        ObjErrDal.ChkReturn = False
                        Return ObjErrDal
                    End If
                End If
            End If
        End If
        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Protected Sub txtConfirmPassword_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConfirmPassword.PreRender
        txtConfirmPassword.Attributes("value") = txtConfirmPassword.Text
    End Sub

    'Protected Sub lnkDetach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDetach.Click
    '    lst.Items.Remove(lst.SelectedValue.ToString)
    'End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ViewState("s") = "3" Then
            Response.Redirect("Default-new.aspx")
        Else
            Response.Redirect("admin/Adminlogin.aspx")
        End If
    End Sub

    
    Protected Sub btnPrint1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint1.Click
        'Dim myreport As New ReportDocument()
        'Dim dsReport As New DataSet
        'dsReport = CLS.fnQuerySelectDs("select st.aid,st.email,st.password,st.firstName,st.middleName,st.lastname,CONVERT(varchar, st.DOB, 101) as DOB,st.Address1,st.Address2,st.ContactNumber1 ,st.ContactNumber2,st.Gender,st.CurProfession,st.Nationality,st.Category,st.edboard1,st.edstream1,st.edmarks1,st.edyrs1,st.edboard2,st.edstream2,st.edmarks2,st.edyrs2,st.edboard3,st.edstream3,st.edmarks3,st.edyrs3,st.edboard4,st.edstream4,st.edmarks4,st.edyrs4,st.ExOrg1,st.ExPh1,st.ExDesignation1,CONVERT(varchar, st.ExService1, 101) as ExService1,st.ExOrg2,st.ExPh2,st.ExDesignation2,CONVERT(varchar, st.ExService2, 101) as ExService2,st.ExOrg3,st.ExPh3,st.ExDesignation3,CONVERT(varchar, st.ExService3, 101) as ExService3,st.totexp from application st INNER JOIN StudentAppCourse sr on st.aid=sr.aid where st.email='" & Trim(txtEmailAddress.Text) & "'")

        'Dim reportPath As String = Server.MapPath("StudentRegistrationreport.rpt")
        'myreport.Load(reportPath)
        'myreport.SetDataSource(dsReport)
        'CrystalReportViewer1.ReportSource = myreport
        'CrystalReportViewer1.DisplayGroupTree = False
        ''myreport.PrintToPrinter(1, False, 0, 0)

        Response.Redirect("Reports.aspx?email=" & Trim(txtEmailAddress.Text))

    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        'Response.Redirect("student/PrintRegistration.aspx?id=" & txtEmailAddress.Text)
        'btnPrint.Attributes.Add("OnClick", "return javascript:openPopup('student/PrintRegistration.aspx?id='& txtEmailAddress.Text);")
    End Sub
    Public Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal mailCC As String, ByVal subject As String, ByVal body As String)
        Try
            Dim smtp As SmtpClient = New SmtpClient("sg2nlvphout-v01.shr.prod.sin2.secureserver.net")

            Dim myfromAddress As String = from
            Dim appSpecificPassword As String = "fmsf@123"

            'smtp.EnableSsl = true;
            smtp.Port = 25
            smtp.Credentials = New NetworkCredential(myfromAddress, appSpecificPassword)

            Dim message As MailMessage = New MailMessage()
            message.Sender = New MailAddress(myfromAddress, "")
            message.From = New MailAddress(myfromAddress, "")

            message.To.Add(New MailAddress(recepient, ""))


            message.Subject = subject
            message.Body = body

            message.IsBodyHtml = True
            smtp.Send(message)
            Response.Write("Email Sent")
        Catch ex As Exception
            Response.Write("Error: " + ex.Message.ToString())
            'lblmsg.Text = ex.Message.ToString()
        End Try

    End Sub
    
End Class
