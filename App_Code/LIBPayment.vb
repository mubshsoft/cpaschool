Namespace fmsf.lib

    Public Class LIBPayment

        Private _DDNo As String
        Public Property DDNo() As String
            Get
                Return _DDNo
            End Get
            Set(ByVal value As String)
                _DDNo = value
            End Set
        End Property

        Private _Amount As Int16
        Public Property Amount() As Int16
            Get
                Return _Amount
            End Get
            Set(ByVal value As Int16)
                _Amount = value
            End Set
        End Property

        Private _DDdate As String
        Public Property DDdate() As String
            Get
                Return _DDdate
            End Get
            Set(ByVal value As String)
                _DDdate = value
            End Set
        End Property

        Private _DateOfPayment As String
        Public Property DateOfPayment() As String
            Get
                Return _DateOfPayment
            End Get
            Set(ByVal value As String)
                _DateOfPayment = value
            End Set
        End Property
        Private _stid As Int16
        Public Property stid() As Int16
            Get
                Return _stid
            End Get
            Set(ByVal value As Int16)
                _stid = value
            End Set
        End Property

        Private _CourseId As Int16
        Public Property CourseId() As Int16
            Get
                Return _CourseId
            End Get
            Set(ByVal value As Int16)
                _CourseId = value
            End Set
        End Property

        Private _SemId As Int16
        Public Property SemId() As Int16
            Get
                Return _SemId
            End Get
            Set(ByVal value As Int16)
                _SemId = value
            End Set
        End Property
    End Class

    
End Namespace

