Imports System
Imports System.IO
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf
Imports fmsf.DAL
Imports fmsf.lib
Partial Class Aboutus
    Inherits System.Web.UI.Page





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getInstructionSummary()


    End Sub
    Protected Sub getInstructionSummary()
        Try
            Dim objLIBExam As New LIBExam()
            Dim objDalExam As New DALExam()
            Dim objLibExamListing As New LIBExamListing()

            Dim st As String
            st = objDalExam.GetAboutus()
            lbltext.Text = st
        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)


        End Try
    End Sub
End Class
