Imports Microsoft.VisualBasic
Imports fmsf.lib
Namespace fmsf.DAL
    Public Class DalAddCourse
        'Public Function fnValidateCourseID(ByVal o_LibCourse As LibAddCourse) As DataSet
        '    Dim ds As New DataSet
        '    Try
        '        Dim strQ As String
        '        strQ = "select * from course where coursecode='" & Trim(o_LibCourse.CourseCode) & "')"
        '        CLS.ConOpen()
        '        ds = CLS.fnQuerySelectDs(strQ)
        '        CLS.ConClose()
        '    Catch ex As Exception

        '    End Try
        '    Return ds
        'End Function

     

        Public Function fnQuery(ByVal o_LibCourse As LibAddCourse, ByVal chkViewState As Boolean) As String
            Try
                'Code for fetching dynamic control data


                'code for insert and update and check existing record

                Dim strq As String
                If chkViewState = False Then
                    If o_LibCourse.CourseEndDate <> "#12:00:00 AM#" Then
                        strq = "DECLARE @RETVAL INT " & _
                                      "IF (EXISTS(SELECT TOP 1 1 FROM Course" & _
                                        " WHERE UPPER(REPLACE(CourseCode,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseCode) & "',' ',''))))" & _
                                           " BEGIN" & _
                                            " SET @RETVAL= 2" & _
                                           " End" & _
                                       " Else" & _
                                           " BEGIN" & _
                                                " INSERT INTO [Course]([CourseCode],[CourseTitle],[noOfSem],[cStartDate],[CEndDate],[screeningExam])" & _
                                                " SELECT '" & o_LibCourse.CourseCode & "','" & o_LibCourse.CourseTitle & "'," & o_LibCourse.NoofSem & _
                                                " ,'" & o_LibCourse.CourseStartDate & "','" & o_LibCourse.CourseEndDate & "','" & o_LibCourse.screeningExam & "'" & _
                                                " SET @RETVAL= 3" & _
                                            " END " & _
                                            " SELECT @RETVAL "
                    Else
                        strq = "DECLARE @RETVAL INT " & _
                                      "IF (EXISTS(SELECT TOP 1 1 FROM Course" & _
                                        " WHERE UPPER(REPLACE(CourseCode,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseCode) & "',' ',''))))" & _
                                           " BEGIN" & _
                                            " SET @RETVAL= 2" & _
                                           " End" & _
                                       " Else" & _
                                           " BEGIN" & _
                                                " INSERT INTO [Course]([CourseCode],[CourseTitle],[noOfSem],[cStartDate],[cEndDate],[screeningExam])" & _
                                                " SELECT '" & o_LibCourse.CourseCode & "','" & o_LibCourse.CourseTitle & "'," & o_LibCourse.NoofSem & _
                                                " ,'" & o_LibCourse.CourseStartDate & "',null,'" & o_LibCourse.screeningExam & "'" & _
                                                " SET @RETVAL= 3" & _
                                            " END " & _
                                            " SELECT @RETVAL "
                    End If
                Else
                    If Len(o_LibCourse.CourseEndDate) > 0 Then
                        strq = "DECLARE @RETVAL INT " & _
                                 "IF (EXISTS(SELECT TOP 1 1 FROM Course" & _
                                    " WHERE UPPER(REPLACE(CourseID,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseID) & "',' ',''))))" & _
                                    " BEGIN" & _
                                        " IF (EXISTS(SELECT TOP 1 1 FROM Course" & _
                                           " WHERE UPPER(REPLACE(CourseID,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseID) & "',' ',''))))" & _
                                           " BEGIN" & _
                                            " UPDATE [Course] SET [CourseCode] = '" & o_LibCourse.CourseCode & "',[CourseTitle] = '" & o_LibCourse.CourseTitle & "',[noOfSem] = " & o_LibCourse.NoofSem & _
                                            " ,[CStartDate]='" & o_LibCourse.CourseStartDate & "',[CEndDate]='" & o_LibCourse.CourseEndDate & "'" & _
                                            " WHERE UPPER(REPLACE(CourseID,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseID) & "',' ',''))'" & _
                                            " SET @RETVAL= 4" & _
                                           " END" & _
                                      " END " & _
                                     "SELECT @RETVAL "
                    Else
                        strq = "DECLARE @RETVAL INT " & _
                                "IF (EXISTS(SELECT TOP 1 1 FROM Course" & _
                                   " WHERE UPPER(REPLACE(CourseID,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseID) & "',' ',''))))" & _
                                   " BEGIN" & _
                                       " IF (EXISTS(SELECT TOP 1 1 FROM Course" & _
                                          " WHERE UPPER(REPLACE(CourseID,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseID) & "',' ',''))))" & _
                                          " BEGIN" & _
                                           " UPDATE [Course] SET [CourseCode] = '" & o_LibCourse.CourseCode & "',[CourseTitle] = '" & o_LibCourse.CourseTitle & "',[noOfSem] = " & o_LibCourse.NoofSem & _
                                           " ,[CStartDate]=" & o_LibCourse.CourseStartDate & _
                                           " WHERE UPPER(REPLACE(CourseID,' ',''))=UPPER(REPLACE('" & Trim(o_LibCourse.CourseID) & "',' ',''))'" & _
                                           " SET @RETVAL= 4" & _
                                          " END" & _
                                     " END " & _
                                    "SELECT @RETVAL "
                    End If

                End If
                '*/**/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*

                CLS.ConOpen()
                Dim dsResult As New DataSet
                Dim strMessage As String
                Dim intResult As Integer
                dsResult = CLS.fnQuerySelectDs(strq)
                If dsResult IsNot Nothing Then
                    If dsResult.Tables IsNot Nothing Then
                        If dsResult.Tables(0).Rows IsNot Nothing Then
                            If dsResult.Tables(0).Rows.Count > 0 Then
                                intResult = CInt(dsResult.Tables(0).Rows(0)(0).ToString)
                                If intResult = 2 Then
                                    strMessage = "Course Code already exist!"
                                ElseIf intResult = 3 Then
                                    strMessage = "Course added successfully!"
                                ElseIf intResult = 4 Then
                                    strMessage = "Course updated successfully!"
                                End If
                            End If
                        End If
                    End If
                End If
                CLS.ConClose()
                Return strMessage
            Catch ex As Exception
            End Try
        End Function
    End Class


End Namespace

