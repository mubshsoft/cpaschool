Imports Microsoft.VisualBasic
Namespace fmsf.lib
    Public Class libErrorMsg
        Private _errMessage As String
        Public Property errMessage() As String
            Get
                Return _errMessage
            End Get
            Set(ByVal value As String)
                _errMessage = value
            End Set
        End Property

        Private _chkReturn As Boolean
        Public Property ChkReturn() As Boolean
            Get
                Return _chkReturn
            End Get
            Set(ByVal value As Boolean)
                _chkReturn = value
            End Set
        End Property

    End Class
End Namespace
