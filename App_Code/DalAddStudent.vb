Imports Microsoft.VisualBasic
Imports fmsf.lib
Public Class DalAddStudent
  
    Public Function InsertStudent(ByVal objLIBStudent As LibAddStudent) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
            objParamList.Add(New OleDbParameter("@Password", objLIBStudent.Password))
            objParamList.Add(New OleDbParameter("@FirstName", objLIBStudent.FirstName))
            objParamList.Add(New OleDbParameter("@MiddleName", objLIBStudent.MiddleName))
            objParamList.Add(New OleDbParameter("@LastName", objLIBStudent.LastName))
            objParamList.Add(New OleDbParameter("@DOB", objLIBStudent.DOB))
            objParamList.Add(New OleDbParameter("@Address1", objLIBStudent.Address1))
            objParamList.Add(New OleDbParameter("@Address2", objLIBStudent.Address2))
            objParamList.Add(New OleDbParameter("@ContactNumber1", objLIBStudent.ContactNumber1))
            objParamList.Add(New OleDbParameter("@ContactNumber2", objLIBStudent.ContactNumber2))
            objParamList.Add(New OleDbParameter("@Gender", objLIBStudent.Gender))
            objParamList.Add(New OleDbParameter("@CurProfession", objLIBStudent.CurProfession))
            objParamList.Add(New OleDbParameter("@Nationality", objLIBStudent.Nationality))
            objParamList.Add(New OleDbParameter("@Category ", objLIBStudent.Category))
            'objParamList.Add(New OleDbParameter("@Date", objLIBStudent.Date1))
            objParamList.Add(New OleDbParameter("@Place", objLIBStudent.Place))

            objParamList.Add(New OleDbParameter("@edboard1", objLIBStudent.edboard1))
            objParamList.Add(New OleDbParameter("@edstream1", objLIBStudent.edstream1))
            objParamList.Add(New OleDbParameter("@edmarks1", objLIBStudent.edmarks1))
            objParamList.Add(New OleDbParameter("@edyrs1", objLIBStudent.edyrs1))

            objParamList.Add(New OleDbParameter("@edboard2", objLIBStudent.edboard2))
            objParamList.Add(New OleDbParameter("@edstream2", objLIBStudent.edstream2))
            objParamList.Add(New OleDbParameter("@edmarks2", objLIBStudent.edmarks2))
            objParamList.Add(New OleDbParameter("@edyrs2", objLIBStudent.edyrs2))

            objParamList.Add(New OleDbParameter("@edboard3", objLIBStudent.edboard3))
            objParamList.Add(New OleDbParameter("@edstream3", objLIBStudent.edstream3))
            objParamList.Add(New OleDbParameter("@edmarks3", objLIBStudent.edmarks3))
            objParamList.Add(New OleDbParameter("@edyrs3", objLIBStudent.edyrs3))


            objParamList.Add(New OleDbParameter("@edboard4", objLIBStudent.edboard4))
            objParamList.Add(New OleDbParameter("@edstream4", objLIBStudent.edstream4))
            objParamList.Add(New OleDbParameter("@edmarks4", objLIBStudent.edmarks4))
            objParamList.Add(New OleDbParameter("@edyrs4", objLIBStudent.edyrs4))

            objParamList.Add(New OleDbParameter("@ExOrg1", objLIBStudent.ExOrg1))
            objParamList.Add(New OleDbParameter("@ExPh1", objLIBStudent.ExPh1))
            objParamList.Add(New OleDbParameter("@ExDesignation1", objLIBStudent.ExDesignation1))
            objParamList.Add(New OleDbParameter("@ExService1", objLIBStudent.ExService1))

            objParamList.Add(New OleDbParameter("@ExOrg2", objLIBStudent.ExOrg2))
            objParamList.Add(New OleDbParameter("@ExPh2", objLIBStudent.ExPh2))
            objParamList.Add(New OleDbParameter("@ExDesignation2", objLIBStudent.ExDesignation2))
            objParamList.Add(New OleDbParameter("@ExService2", objLIBStudent.ExService2))

            objParamList.Add(New OleDbParameter("@ExOrg3", objLIBStudent.ExOrg3))
            objParamList.Add(New OleDbParameter("@ExPh3", objLIBStudent.ExPh3))
            objParamList.Add(New OleDbParameter("@ExDesignation3", objLIBStudent.ExDesignation3))
            objParamList.Add(New OleDbParameter("@ExService3", objLIBStudent.ExService3))

            objParamList.Add(New OleDbParameter("@CourseId", objLIBStudent.CourseID))
            objParamList.Add(New OleDbParameter("@applicantCategory", objLIBStudent.ApplicantCategory))
            objParamList.Add(New OleDbParameter("@totexp", objLIBStudent.totexp))
            MyCLS.ConOpen()
            '  retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQueryReturnValue("SP_AddUpdateRegistration", objParamList)
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_AddUpdateRegistration", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function

    'Public Function UpdateStudent(ByVal objLIBStudent As LibAddStudent) As Int16
    '    Dim retVal As New Int16
    '    Dim objParamList As New List(Of OleDbParameter)()
    '    Try
    '        objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
    '        objParamList.Add(New OleDbParameter("@Password", objLIBStudent.Password))
    '        objParamList.Add(New OleDbParameter("@FirstName", objLIBStudent.FirstName))
    '        objParamList.Add(New OleDbParameter("@MiddleName", objLIBStudent.MiddleName))
    '        objParamList.Add(New OleDbParameter("@LastName", objLIBStudent.LastName))
    '        objParamList.Add(New OleDbParameter("@DOB", objLIBStudent.DOB))
    '        objParamList.Add(New OleDbParameter("@Address1", objLIBStudent.Address1))
    '        objParamList.Add(New OleDbParameter("@Address2", objLIBStudent.Address2))
    '        objParamList.Add(New OleDbParameter("@ContactNumber1", objLIBStudent.ContactNumber1))
    '        objParamList.Add(New OleDbParameter("@ContactNumber2", objLIBStudent.ContactNumber2))
    '        objParamList.Add(New OleDbParameter("@Degree", objLIBStudent.Degree))
    '        objParamList.Add(New OleDbParameter("@Discipline", objLIBStudent.Discipline))
    '        objParamList.Add(New OleDbParameter("@CourseId", objLIBStudent.CourseID))
    '        MyCLS.ConOpen()
    '        retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_InsertStudent", objParamList)
    '        MyCLS.ConClose()

    '    Catch ex As Exception
    '        MyCLS.clsHandleException.HandleEx(ex)
    '        'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
    '    End Try
    '    Return retVal
    'End Function

    Public Function InsertStudentRegis(ByVal objLIBStudent As LibAddStudent, ByVal objlibStApp As LibStudentAPP) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
            objParamList.Add(New OleDbParameter("@Password", objLIBStudent.Password))
            objParamList.Add(New OleDbParameter("@FirstName", objLIBStudent.FirstName))
            objParamList.Add(New OleDbParameter("@MiddleName", objLIBStudent.MiddleName))
            objParamList.Add(New OleDbParameter("@LastName", objLIBStudent.LastName))
            objParamList.Add(New OleDbParameter("@DOB", objLIBStudent.DOB))
            objParamList.Add(New OleDbParameter("@Address1", objLIBStudent.Address1))
            objParamList.Add(New OleDbParameter("@Address2", objLIBStudent.Address2))
            objParamList.Add(New OleDbParameter("@ContactNumber1", objLIBStudent.ContactNumber1))
            objParamList.Add(New OleDbParameter("@ContactNumber2", objLIBStudent.ContactNumber2))
            'objParamList.Add(New OleDbParameter("@Degree", objLIBStudent.Degree))
            'objParamList.Add(New OleDbParameter("@Discipline", objLIBStudent.Discipline))
            objParamList.Add(New OleDbParameter("@CourseId", objLIBStudent.CourseID))

            objParamList.Add(New OleDbParameter("@approved", objlibStApp.Approve))
            objParamList.Add(New OleDbParameter("@DocVerified", objlibStApp.DocVerified))
            objParamList.Add(New OleDbParameter("@stid", objlibStApp.stID))

            objParamList.Add(New OleDbParameter("@Gender", objLIBStudent.Gender))
            objParamList.Add(New OleDbParameter("@CurProfession", objLIBStudent.CurProfession))
            objParamList.Add(New OleDbParameter("@Nationality", objLIBStudent.Nationality))
            objParamList.Add(New OleDbParameter("@Category", objLIBStudent.Category))
            'objParamList.Add(New OleDbParameter("@Date", objLIBStudent.Date1))
            objParamList.Add(New OleDbParameter("@Place", objLIBStudent.Place))

            objParamList.Add(New OleDbParameter("@edboard1", objLIBStudent.edboard1))
            objParamList.Add(New OleDbParameter("@edstream1", objLIBStudent.edstream1))
            objParamList.Add(New OleDbParameter("@edmarks1", objLIBStudent.edmarks1))
            objParamList.Add(New OleDbParameter("@edyrs1", objLIBStudent.edyrs1))

            objParamList.Add(New OleDbParameter("@edboard2", objLIBStudent.edboard2))
            objParamList.Add(New OleDbParameter("@edstream2", objLIBStudent.edstream2))
            objParamList.Add(New OleDbParameter("@edmarks2", objLIBStudent.edmarks2))
            objParamList.Add(New OleDbParameter("@edyrs2", objLIBStudent.edyrs2))

            objParamList.Add(New OleDbParameter("@edboard3", objLIBStudent.edboard3))
            objParamList.Add(New OleDbParameter("@edstream3", objLIBStudent.edstream3))
            objParamList.Add(New OleDbParameter("@edmarks3", objLIBStudent.edmarks3))
            objParamList.Add(New OleDbParameter("@edyrs3", objLIBStudent.edyrs3))

            objParamList.Add(New OleDbParameter("@edboard4", objLIBStudent.edboard4))
            objParamList.Add(New OleDbParameter("@edstream4", objLIBStudent.edstream4))
            objParamList.Add(New OleDbParameter("@edmarks4", objLIBStudent.edmarks4))
            objParamList.Add(New OleDbParameter("@edyrs4", objLIBStudent.edyrs4))


            objParamList.Add(New OleDbParameter("@ExOrg1", objLIBStudent.ExOrg1))
            objParamList.Add(New OleDbParameter("@ExPh1", objLIBStudent.ExPh1))
            objParamList.Add(New OleDbParameter("@ExDesignation1", objLIBStudent.ExDesignation1))
            objParamList.Add(New OleDbParameter("@ExService1", objLIBStudent.ExService1))

            objParamList.Add(New OleDbParameter("@ExOrg2", objLIBStudent.ExOrg2))
            objParamList.Add(New OleDbParameter("@ExPh2", objLIBStudent.ExPh2))
            objParamList.Add(New OleDbParameter("@ExDesignation2", objLIBStudent.ExDesignation2))
            objParamList.Add(New OleDbParameter("@ExService2", objLIBStudent.ExService2))

            objParamList.Add(New OleDbParameter("@ExOrg3", objLIBStudent.ExOrg3))
            objParamList.Add(New OleDbParameter("@ExPh3", objLIBStudent.ExPh3))
            objParamList.Add(New OleDbParameter("@ExDesignation3", objLIBStudent.ExDesignation3))
            objParamList.Add(New OleDbParameter("@ExService3", objLIBStudent.ExService3))
            objParamList.Add(New OleDbParameter("@totexp", objLIBStudent.totexp))
            objParamList.Add(New OleDbParameter("@aid", objLIBStudent.aid))
            objParamList.Add(New OleDbParameter("@stAid", objLIBStudent.stAid))
            objParamList.Add(New OleDbParameter("@screeningExam", objLIBStudent.screeningExam))
            objParamList.Add(New OleDbParameter("@feestatus", objLIBStudent.feestatus))
            objParamList.Add(New OleDbParameter("@feeremark", objLIBStudent.feeremark))
            objParamList.Add(New OleDbParameter("@applicantcategory", objLIBStudent.ApplicantCategory))
            MyCLS.ConOpen()
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_InsertStudentReg", objParamList)
            'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_UpdateApproveStatus", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function


    Public Function UpdateStudentProfile(ByVal objLIBStudent As LibAddStudent) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
            objParamList.Add(New OleDbParameter("@FirstName", objLIBStudent.FirstName))
            objParamList.Add(New OleDbParameter("@MiddleName", objLIBStudent.MiddleName))
            objParamList.Add(New OleDbParameter("@LastName", objLIBStudent.LastName))
            objParamList.Add(New OleDbParameter("@DOB", objLIBStudent.DOB))
            objParamList.Add(New OleDbParameter("@Address1", objLIBStudent.Address1))
            objParamList.Add(New OleDbParameter("@Address2", objLIBStudent.Address2))
            objParamList.Add(New OleDbParameter("@ContactNumber1", objLIBStudent.ContactNumber1))
            objParamList.Add(New OleDbParameter("@ContactNumber2", objLIBStudent.ContactNumber2))
            objParamList.Add(New OleDbParameter("@CourseId", objLIBStudent.CourseID))

            'objParamList.Add(New OleDbParameter("@approved", objlibStApp.Approve))
            'objParamList.Add(New OleDbParameter("@DocVerified", objlibStApp.DocVerified))
            'objParamList.Add(New OleDbParameter("@stid", objlibStApp.stID))

            objParamList.Add(New OleDbParameter("@Gender", objLIBStudent.Gender))
            objParamList.Add(New OleDbParameter("@CurProfession", objLIBStudent.CurProfession))
            objParamList.Add(New OleDbParameter("@Nationality", objLIBStudent.Nationality))
            objParamList.Add(New OleDbParameter("@Category", objLIBStudent.Category))
            objParamList.Add(New OleDbParameter("@Place", objLIBStudent.Place))

            objParamList.Add(New OleDbParameter("@edboard1", objLIBStudent.edboard1))
            objParamList.Add(New OleDbParameter("@edstream1", objLIBStudent.edstream1))
            objParamList.Add(New OleDbParameter("@edmarks1", objLIBStudent.edmarks1))
            objParamList.Add(New OleDbParameter("@edyrs1", objLIBStudent.edyrs1))

            objParamList.Add(New OleDbParameter("@edboard2", objLIBStudent.edboard2))
            objParamList.Add(New OleDbParameter("@edstream2", objLIBStudent.edstream2))
            objParamList.Add(New OleDbParameter("@edmarks2", objLIBStudent.edmarks2))
            objParamList.Add(New OleDbParameter("@edyrs2", objLIBStudent.edyrs2))

            objParamList.Add(New OleDbParameter("@edboard3", objLIBStudent.edboard3))
            objParamList.Add(New OleDbParameter("@edstream3", objLIBStudent.edstream3))
            objParamList.Add(New OleDbParameter("@edmarks3", objLIBStudent.edmarks3))
            objParamList.Add(New OleDbParameter("@edyrs3", objLIBStudent.edyrs3))

            objParamList.Add(New OleDbParameter("@edboard4", objLIBStudent.edboard4))
            objParamList.Add(New OleDbParameter("@edstream4", objLIBStudent.edstream4))
            objParamList.Add(New OleDbParameter("@edmarks4", objLIBStudent.edmarks4))
            objParamList.Add(New OleDbParameter("@edyrs4", objLIBStudent.edyrs4))


            objParamList.Add(New OleDbParameter("@ExOrg1", objLIBStudent.ExOrg1))
            objParamList.Add(New OleDbParameter("@ExPh1", objLIBStudent.ExPh1))
            objParamList.Add(New OleDbParameter("@ExDesignation1", objLIBStudent.ExDesignation1))
            objParamList.Add(New OleDbParameter("@ExService1", objLIBStudent.ExService1))

            objParamList.Add(New OleDbParameter("@ExOrg2", objLIBStudent.ExOrg2))
            objParamList.Add(New OleDbParameter("@ExPh2", objLIBStudent.ExPh2))
            objParamList.Add(New OleDbParameter("@ExDesignation2", objLIBStudent.ExDesignation2))
            objParamList.Add(New OleDbParameter("@ExService2", objLIBStudent.ExService2))

            objParamList.Add(New OleDbParameter("@ExOrg3", objLIBStudent.ExOrg3))
            objParamList.Add(New OleDbParameter("@ExPh3", objLIBStudent.ExPh3))
            objParamList.Add(New OleDbParameter("@ExDesignation3", objLIBStudent.ExDesignation3))
            objParamList.Add(New OleDbParameter("@ExService3", objLIBStudent.ExService3))
            objParamList.Add(New OleDbParameter("@SecondaryEmail", objLIBStudent.SecondaryEmailAddress))
            objParamList.Add(New OleDbParameter("@totexp", objLIBStudent.totexp))
            objParamList.Add(New OleDbParameter("@Profileimage ", objLIBStudent.ProfileImage))
            MyCLS.ConOpen()
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_UpdateStudentProfile", objParamList)
            'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_UpdateApproveStatus", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function

    Public Function UpdateStudentProfileAdmin(ByVal objLIBStudent As LibAddStudent) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
            objParamList.Add(New OleDbParameter("@FirstName", objLIBStudent.FirstName))
            objParamList.Add(New OleDbParameter("@MiddleName", objLIBStudent.MiddleName))
            objParamList.Add(New OleDbParameter("@LastName", objLIBStudent.LastName))
            objParamList.Add(New OleDbParameter("@DOB", objLIBStudent.DOB))
            objParamList.Add(New OleDbParameter("@Address1", objLIBStudent.Address1))
            objParamList.Add(New OleDbParameter("@Address2", objLIBStudent.Address2))
            objParamList.Add(New OleDbParameter("@ContactNumber1", objLIBStudent.ContactNumber1))
            objParamList.Add(New OleDbParameter("@ContactNumber2", objLIBStudent.ContactNumber2))
            objParamList.Add(New OleDbParameter("@CourseId", objLIBStudent.CourseID))

            'objParamList.Add(New OleDbParameter("@approved", objlibStApp.Approve))
            'objParamList.Add(New OleDbParameter("@DocVerified", objlibStApp.DocVerified))
            'objParamList.Add(New OleDbParameter("@stid", objlibStApp.stID))

            objParamList.Add(New OleDbParameter("@Gender", objLIBStudent.Gender))
            objParamList.Add(New OleDbParameter("@CurProfession", objLIBStudent.CurProfession))
            objParamList.Add(New OleDbParameter("@Nationality", objLIBStudent.Nationality))
            objParamList.Add(New OleDbParameter("@Category", objLIBStudent.Category))
            objParamList.Add(New OleDbParameter("@Place", objLIBStudent.Place))

            objParamList.Add(New OleDbParameter("@edboard1", objLIBStudent.edboard1))
            objParamList.Add(New OleDbParameter("@edstream1", objLIBStudent.edstream1))
            objParamList.Add(New OleDbParameter("@edmarks1", objLIBStudent.edmarks1))
            objParamList.Add(New OleDbParameter("@edyrs1", objLIBStudent.edyrs1))

            objParamList.Add(New OleDbParameter("@edboard2", objLIBStudent.edboard2))
            objParamList.Add(New OleDbParameter("@edstream2", objLIBStudent.edstream2))
            objParamList.Add(New OleDbParameter("@edmarks2", objLIBStudent.edmarks2))
            objParamList.Add(New OleDbParameter("@edyrs2", objLIBStudent.edyrs2))

            objParamList.Add(New OleDbParameter("@edboard3", objLIBStudent.edboard3))
            objParamList.Add(New OleDbParameter("@edstream3", objLIBStudent.edstream3))
            objParamList.Add(New OleDbParameter("@edmarks3", objLIBStudent.edmarks3))
            objParamList.Add(New OleDbParameter("@edyrs3", objLIBStudent.edyrs3))

            objParamList.Add(New OleDbParameter("@edboard4", objLIBStudent.edboard4))
            objParamList.Add(New OleDbParameter("@edstream4", objLIBStudent.edstream4))
            objParamList.Add(New OleDbParameter("@edmarks4", objLIBStudent.edmarks4))
            objParamList.Add(New OleDbParameter("@edyrs4", objLIBStudent.edyrs4))


            objParamList.Add(New OleDbParameter("@ExOrg1", objLIBStudent.ExOrg1))
            objParamList.Add(New OleDbParameter("@ExPh1", objLIBStudent.ExPh1))
            objParamList.Add(New OleDbParameter("@ExDesignation1", objLIBStudent.ExDesignation1))
            objParamList.Add(New OleDbParameter("@ExService1", objLIBStudent.ExService1))

            objParamList.Add(New OleDbParameter("@ExOrg2", objLIBStudent.ExOrg2))
            objParamList.Add(New OleDbParameter("@ExPh2", objLIBStudent.ExPh2))
            objParamList.Add(New OleDbParameter("@ExDesignation2", objLIBStudent.ExDesignation2))
            objParamList.Add(New OleDbParameter("@ExService2", objLIBStudent.ExService2))

            objParamList.Add(New OleDbParameter("@ExOrg3", objLIBStudent.ExOrg3))
            objParamList.Add(New OleDbParameter("@ExPh3", objLIBStudent.ExPh3))
            objParamList.Add(New OleDbParameter("@ExDesignation3", objLIBStudent.ExDesignation3))
            objParamList.Add(New OleDbParameter("@ExService3", objLIBStudent.ExService3))
            objParamList.Add(New OleDbParameter("@SecondaryEmail", objLIBStudent.SecondaryEmailAddress))
            objParamList.Add(New OleDbParameter("@totexp", objLIBStudent.totexp))
            objParamList.Add(New OleDbParameter("@applicantcategory", objLIBStudent.ApplicantCategory))
            objParamList.Add(New OleDbParameter("@password", objLIBStudent.Password))
            MyCLS.ConOpen()
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_UpdateStudentProfileAdmin", objParamList)
            'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_UpdateApproveStatus", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function
    Public Function InsertStudentScreeningActivate(ByVal objLIBStudent As LibAddStudent, ByVal objlibStApp As LibStudentAPP) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            'objParamList.Add(New OleDbParameter("@aid", objLIBStudent.aid))
            ' objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
            objParamList.Add(New OleDbParameter("@courseId", objLIBStudent.CourseID))

            MyCLS.ConOpen()
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_AddStudentScreeningActivate", objParamList)
            'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_UpdateApproveStatus", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function

    Public Function InsertAnotherRegis(ByVal objLIBStudent As LibAddStudent, ByVal objlibStApp As LibStudentAPP) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@aid", objLIBStudent.aid))
            objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
            objParamList.Add(New OleDbParameter("@courseId", objLIBStudent.CourseID))

            MyCLS.ConOpen()
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_AddAnotherRegistration", objParamList)
            'retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_UpdateApproveStatus", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function
    Public Function Insertfaculty(ByVal objLIBStudent As LibAddStudent) As Int16
        Dim retVal As New Int16
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@Email", objLIBStudent.emailAddress))
            objParamList.Add(New OleDbParameter("@Password", objLIBStudent.Password))
            objParamList.Add(New OleDbParameter("@FirstName", objLIBStudent.FirstName))
            objParamList.Add(New OleDbParameter("@MiddleName", objLIBStudent.MiddleName))
            objParamList.Add(New OleDbParameter("@LastName", objLIBStudent.LastName))
            objParamList.Add(New OleDbParameter("@DOB", objLIBStudent.DOBFac))
            objParamList.Add(New OleDbParameter("@Address1", objLIBStudent.Address1))
            objParamList.Add(New OleDbParameter("@Address2", objLIBStudent.Address2))
            objParamList.Add(New OleDbParameter("@ContactNumber1", objLIBStudent.ContactNumber1))
            objParamList.Add(New OleDbParameter("@ContactNumber2", objLIBStudent.ContactNumber2))
            objParamList.Add(New OleDbParameter("@Gender", objLIBStudent.Gender))
            'objParamList.Add(New OleDbParameter("@CurProfession", objLIBStudent.CurProfession))
            objParamList.Add(New OleDbParameter("@Nationality", objLIBStudent.Nationality))
            objParamList.Add(New OleDbParameter("@Category ", objLIBStudent.Category))
            objParamList.Add(New OleDbParameter("@Profile ", objLIBStudent.Profile))
            objParamList.Add(New OleDbParameter("@Profileimage ", objLIBStudent.ProfileImage))

            MyCLS.ConOpen()
            retVal = MyCLS.clsExecuteStoredProc.ExecuteSPNonQuery("SP_AddUpdateFacultyRegistration", objParamList)
            MyCLS.ConClose()

        Catch ex As Exception
            MyCLS.clsHandleException.HandleEx(ex)
            'HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
        Return retVal
    End Function
End Class
