Namespace fmsf.lib
    Public Class LIBNews


        Private _NewsID As Int16
        Public Property NewsId() As Int16
            Get
                Return _NewsID
            End Get
            Set(ByVal value As Int16)
                _NewsID = value
            End Set
        End Property


        Private _NewsType As String
        Public Property NewsType() As String
            Get
                Return _NewsType
            End Get
            Set(ByVal value As String)
                _NewsType = value
            End Set
        End Property

        Private _NewsDesc As String
        Public Property NewsDesc() As String
            Get
                Return _NewsDesc
            End Get
            Set(ByVal value As String)
                _NewsDesc = value
            End Set
        End Property

        Private _EventID As Int16
        Public Property EventId() As Int16
            Get
                Return _EventID
            End Get
            Set(ByVal value As Int16)
                _EventID = value
            End Set
        End Property


        Private _EventTitle As String
        Public Property EventTitle() As String
            Get
                Return _EventTitle
            End Get
            Set(ByVal value As String)
                _EventTitle = value
            End Set
        End Property

        Private _EventDesc As String
        Public Property EventDesc() As String
            Get
                Return _EventDesc
            End Get
            Set(ByVal value As String)
                _EventDesc = value
            End Set
        End Property

        Private _EventDate As String
        Public Property EventDate() As String
            Get
                Return _EventDate
            End Get
            Set(ByVal value As String)
                _EventDate = value
            End Set
        End Property

        Private _batchId As Int16
        Public Property batchid() As Int16
            Get
                Return _batchId
            End Get
            Set(ByVal value As Int16)
                _batchId = value
            End Set
        End Property


        Private _CourseId As Int16
        Public Property courseid() As Int16
            Get
                Return _CourseId
            End Get
            Set(ByVal value As Int16)
                _CourseId = value
            End Set
        End Property
    End Class


    <Serializable()> _
    Public Class LIBNewsListing
        Inherits List(Of LIBNews)

    End Class
End Namespace
