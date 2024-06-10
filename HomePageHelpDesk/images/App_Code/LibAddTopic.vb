Imports Microsoft.VisualBasic
Namespace fmsf.lib
    Public Class LibAddTopic
        Private _Title As String
        Public Property title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Private _CreatedBy As String
        Public Property CreatedBy() As String
            Get
                Return _CreatedBy
            End Get
            Set(ByVal value As String)
                _CreatedBy = value
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

        Private _Active As Boolean
        Public Property Active() As Boolean
            Get
                Return _Active
            End Get
            Set(ByVal value As Boolean)
                _Active = value
            End Set
        End Property
        Private _SubjectID As Int16
        Public Property SubjectID() As Int16
            Get
                Return _SubjectID
            End Get
            Set(ByVal value As Int16)
                _SubjectID = value
            End Set
        End Property

        Private _CourseID As Int16
        Public Property CourseID() As Int16
            Get
                Return _CourseID
            End Get
            Set(ByVal value As Int16)
                _CourseID = value
            End Set
        End Property

        Private _SemID As Int16
        Public Property Semid() As Int16
            Get
                Return _SemID
            End Get
            Set(ByVal value As Int16)
                _SemID = value
            End Set
        End Property
        Private _BatchID As Int16
        Public Property Batchid() As Int16
            Get
                Return _BatchID
            End Get
            Set(ByVal value As Int16)
                _BatchID = value
            End Set
        End Property

        Private _FileName As String
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
            End Set
        End Property

        Private _FilePath As String
        Public Property FilePath() As String
            Get
                Return _FilePath
            End Get
            Set(ByVal value As String)
                _FilePath = value
            End Set
        End Property


        Private _GroupId As Int16
        Public Property GroupId() As Int16
            Get
                Return _GroupId
            End Get
            Set(ByVal value As Int16)
                _GroupId = value
            End Set
        End Property
    End Class
End Namespace
