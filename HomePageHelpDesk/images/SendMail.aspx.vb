Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Configuration
Partial Class SendMail
    Inherits System.Web.UI.Page


    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim AdminmailBody As String = ""
        Dim StudentMailBody As String = ""


        ' AdminmailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'>" + ddlCourse.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtEmailAddress.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtFirstName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtMiddleName.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtLastName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtDOB.Text + "</td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPermanentAddress.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtCorrespondenceAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Contact Number:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtContactNumber.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Mobile Number:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtMobileNumber.Text + "</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Personal Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Gender:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllGender.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Current Profession :</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + dllProfession.SelectedItem.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Nationality :</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + dllCountry.SelectedItem.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Category:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + dllCategory.SelectedItem.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Applicant Category:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + ddlapplicantCategory.SelectedItem.Text + "</td><td width='15%'  bgcolor='#FFFFFF'>&nbsp;</td><td width='15%'  bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Educational Details:</td></tr><tr><td colspan='4' valign='top' bgcolor='#FFFFFF'><table width='100%' cellpadding='0' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td align='center' width='20%' bgcolor='#FFFFFF'>&nbsp;</td><td align='center' width='20%' bgcolor='#FFFFFF'>Name of the Univ./Board</td><td align='center' width='20%' bgcolor='#FFFFFF'>Stream</td><td align='center' width='20%' bgcolor='#FFFFFF'>Marks Obtained (%)</td><td align='center' width='20%' bgcolor='#FFFFFF'>Year of Completion</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>10<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks1.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears1.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>12<sup>th</sup>:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks2.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears2.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Graduation:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks3.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears3.Text + "</td></tr><tr><td align='center' width='20%' bgcolor='#FFFFFF'>Any Other:</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtBoard4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtStream4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtMarks4.Text + "</td><td align='center' width='20%' bgcolor='#FFFFFF'>" + txtYears4.Text + "</td></tr></table></td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Total Years of Experience:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtTotExp.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name and Address of Organisation:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>Phone Number:</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Designation:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>Years of Service:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg1.Text + "</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh1.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation1.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear1.Text + "</td></tr> <tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg2.Text + "</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh2.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation2.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear2.Text + "</td> </tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtOrg3.Text + "</td> <td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtPh3.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>" + txtDesignation3.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='30%'>" + txtYear3.Text + "</td></tr><tr><td colspan='2' valign='top' bgcolor='#FFFFFF'>Place:</td><td colspan='2' valign='top' bgcolor='#FFFFFF'>" + txtPlace.Text + "</td></tr><tr><td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>&copy; Copyright 2007, FMSF</div></td></tr></table></body></html>"
        ' StudentMailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr ><td colspan='4' bgcolor='#FFFFFF' valign='top'></td></tr><tr><td colspan='4' bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'></td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top' bgcolor='#FFFFFF' width='30%'> chaya.pandey@gmail.com</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>Chhaya</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>pandey</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'></td><td valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top' bgcolor='#FFFFFF' width='30%'></td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>abc</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>xxx</td></tr></table></body></html>"
        StudentMailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Select Course:</td><td valign='top'' width='30%' bgcolor='#FFFFFF'>ff</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Email Address:<br></td><td valign='top' bgcolor='#FFFFFF' width='30%'>ffffff</td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Contact Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>First Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>fffff</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Middle Name:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>ffffff</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Last Name:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>dddddddddddd</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Date of Birth:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>ffffffffffffff</td></tr><tr> <td valign='top' width='30%' bgcolor='#FFFFFF'>Permanent Address:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>fdgdhhhhhhhhhhhhhhhhhhhhhh</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Correspondence Address:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>gggggggg</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Contact Number:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>ggggggggggggggggggggggggg</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Mobile Number:</td><td valign='top' bgcolor='#FFFFFF' width='30%'></td></tr><tr><td colspan='4' valign='top' bgcolor='#CCCCCC'>Personal Details:</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Gender:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>gggggg</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Current Profession :</td><td valign='top' bgcolor='#FFFFFF' width='30%'>ggggggggg</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Nationality :</td><td valign='top' width='30%' bgcolor='#FFFFFF'>fffffff</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Category:</td><td valign='top' bgcolor='#FFFFFF' width='30%'>dfgfdhfdhfdh</td></tr></table></body></html>"

        SendMailMessage("fmsf@fmsflearningsystems.org", "chaya.pandey@gmail.com", "", "Regarding submission of documents", StudentMailBody)
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
            lblmsg.Text = ex.Message.ToString()
        End Try

    End Sub
    'Public Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal mailCC As String, ByVal subject As String, ByVal body As String)

    '    Try
    '        Dim smtp As SmtpClient = New SmtpClient("sg2nlvphout-v01.shr.prod.sin2.secureserver.net")

    '        Dim myGmailAddress As String = "chaya.pandey@gmail.com"
    '        Dim appSpecificPassword As String = "fmsf@123"

    '        'smtp.EnableSsl = true;
    '        smtp.Port = 25
    '        smtp.Credentials = New NetworkCredential(myGmailAddress, appSpecificPassword)

    '        Dim message As MailMessage = New MailMessage()
    '        message.Sender = New MailAddress(myGmailAddress, "chhaya")
    '        message.From = New MailAddress(myGmailAddress, "chhaya")

    '        message.To.Add(New MailAddress("chhaya.netsoft@gmail.com", "chhaya"))


    '        message.Subject = "My HTML Formatted Email"
    '        message.Body = "<h1>HTML Formatted EMail</h1><p>DO you like this <strong>EMail</strong>with HTML formatting contained in its body.</p>"

    '        message.IsBodyHtml = True
    '        smtp.Send(message)
    '        Response.Write("Email Sent")
    '    Catch ex As Exception
    '        Response.Write("Error: " + ex.Message.ToString())
    '        lblmsg.Text = ex.Message.ToString()
    '    End Try




    'End Sub
End Class
