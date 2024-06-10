Imports Microsoft.VisualBasic
Imports fmsf.lib
Namespace fmsf.DAL
    Public Class DalLogin
        Public Function fnValidateLogin(ByVal o_LibLogin As LibLogin) As DataSet
            Dim ds As New DataSet
            Try
                Dim strQ As String
                strQ = "select * from login where username='" & Trim(o_LibLogin.UserName) & "' and convert(varbinary,password)=convert(varbinary,'" & Trim(o_LibLogin.Password) & "')"
                CLS.ConOpen()
                ds = CLS.fnQuerySelectDs(strQ)
                CLS.ConClose()
            Catch ex As Exception

            End Try
            Return ds
        End Function
        Public Function fnValidateScreeningLogin(ByVal o_LibLogin As LibLogin) As DataSet
            Dim ds As New DataSet
            Try
                Dim strQ As String
                strQ = "select email,password from application where email='" & Trim(o_LibLogin.UserName) & "' and convert(varbinary,password)=convert(varbinary,'" & Trim(o_LibLogin.Password) & "')"
                CLS.ConOpen()
                ds = CLS.fnQuerySelectDs(strQ)
                CLS.ConClose()
            Catch ex As Exception

            End Try
            Return ds
        End Function
    End Class
End Namespace