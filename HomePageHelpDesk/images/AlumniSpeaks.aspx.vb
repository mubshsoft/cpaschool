Imports System.Data.SqlClient
Partial Class AlumniSpeaks
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            BindAlumni()
        End If
    End Sub

    Sub BindAlumni()
        Try
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSP("Sp_GetAlumniDetails")
            rptrAlumni.DataSource = ds
            rptrAlumni.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class
