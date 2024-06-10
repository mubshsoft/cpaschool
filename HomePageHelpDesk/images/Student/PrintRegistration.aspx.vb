
Partial Class PrintRegistration
    Inherits System.Web.UI.Page
    Public strEmailId As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                filldata()
                Response.Write("<script>window.print();</script>")
                'Response.Write("<script>window.close();</script>")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub filldata()
        Try
            Dim dsAppSt As New DataSet
            'Dim mailid As String = Request.QueryString("id")

            Dim mailid As String = Session("email")
            Dim strMax As String
            Dim dsMax As New DataSet
            strMax = "SELECT max(staid) as staid FROM studentappcourse WHERE aid IN (SELECT aid FROM application WHERE email='" & mailid & "')"
            'strMax = "SELECT max(staid) as staid FROM studentappcourse WHERE aid IN (SELECT aid FROM application WHERE email= '" & Session("email") & "')"
            dsMax = CLS.fnQuerySelectDs(strMax)
            If dsMax IsNot Nothing Then
                If dsMax.Tables IsNot Nothing Then
                    If dsMax.Tables(0).Rows IsNot Nothing Then
                        If dsMax.Tables(0).Rows.Count > 0 Then
                            lblApp.Text = CInt(dsMax.Tables(0).Rows(0)("staid").ToString)
                        End If
                    End If
                End If
            End If


            Dim strCourse As String
            Dim dsCourse As New DataSet
            strCourse = "select stap.courseid,cr.coursetitle as coursetitle from studentappcourse stap inner join course cr on stap.courseid=cr.courseid where stap.staid=" & CInt(lblApp.Text)
            dsCourse = CLS.fnQuerySelectDs(strCourse)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            lblCourseID.Text = dsCourse.Tables(0).Rows(0)("coursetitle").ToString
                        End If
                    End If
                End If
            End If


            dsAppSt = CLS.fnQuerySelectDs("select * from application where email = '" & mailid & "'")

            If dsAppSt IsNot Nothing Then
                If dsAppSt.Tables IsNot Nothing Then
                    If dsAppSt.Tables(0).Rows IsNot Nothing Then
                        If dsAppSt.Tables(0).Rows.Count > 0 Then
                            Dim dsStCourseTitle As New DataSet



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

                            txtGendor.Text = dsAppSt.Tables(0).Rows(0)("Gender").ToString
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
                            txtApplicantCategory.Text = dsAppSt.Tables(0).Rows(0)("applicantcategory").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
