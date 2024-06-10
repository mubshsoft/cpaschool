Imports Microsoft.VisualBasic

Namespace fmsf.lib
    Public Class LibLogin
        Private _UserID As Int16
        Public Property UserID() As Int16
            Get
                Return _UserID
            End Get
            Set(ByVal value As Int16)
                _UserID = value
            End Set
        End Property

        Private _UserName As String
        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property

        Private _Password As String
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
        Private _Type As String
        Public Property type() As String
            Get
                Return _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property
    End Class

End Namespace