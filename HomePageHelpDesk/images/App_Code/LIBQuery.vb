Imports Microsoft.VisualBasic
Namespace fmsf.lib
    Public Class LIBQuery
        Private _QueryId As Int16
        Public Property QueryId() As Int16
            Get
                Return _QueryId
            End Get
            Set(ByVal value As Int16)
                _QueryId = value
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

        Private _Fid As Int16
        Public Property Fid() As Int16
            Get
                Return _Fid
            End Get
            Set(ByVal value As Int16)
                _Fid = value
            End Set
        End Property

        Private _Subject As String
        Public Property Subject() As String
            Get
                Return _Subject
            End Get
            Set(ByVal value As String)
                _Subject = value
            End Set
        End Property

        Private _Query As String
        Public Property Query() As String
            Get
                Return _Query
            End Get
            Set(ByVal value As String)
                _Query = value
            End Set
        End Property

        Private _Reply As String
        Public Property Reply() As String
            Get
                Return _Reply
            End Get
            Set(ByVal value As String)
                _Reply = value
            End Set
        End Property

        Private _Status As Boolean
        Public Property Status() As Boolean
            Get
                Return _Status
            End Get
            Set(ByVal value As Boolean)
                _Status = value
            End Set
        End Property

        Private _QueryDate As DateTime
        Public Property QueryDate() As DateTime
            Get
                Return _QueryDate
            End Get
            Set(ByVal value As DateTime)
                _QueryDate = value
            End Set
        End Property
    End Class
End Namespace
