Imports Microsoft.VisualBasic
Namespace fmsf.lib

    Public Class LibStudentAPP
        Private _DocVerified As Boolean
        Public Property DocVerified() As Boolean
            Get
                Return _DocVerified
            End Get
            Set(ByVal value As Boolean)
                _DocVerified = value
            End Set
        End Property

        Private _Approve As Boolean
        Public Property Approve() As Boolean
            Get
                Return _Approve
            End Get
            Set(ByVal value As Boolean)
                _Approve = value
            End Set
        End Property

        Private _stid As Int16
        Public Property stID() As Int16
            Get
                Return _stid
            End Get
            Set(ByVal value As Int16)
                _stid = value
            End Set
        End Property
    End Class
End Namespace
