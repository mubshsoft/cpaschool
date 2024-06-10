Imports Microsoft.VisualBasic

Namespace fmsf.lib
    Public Class LibAddCourse
        Private _CourseID As Int16
        Public Property CourseID() As Int16
            Get
                Return _CourseID
            End Get
            Set(ByVal value As Int16)
                _CourseID = value
            End Set
        End Property

        Private _CourseCode As String
        Public Property CourseCode() As String
            Get
                Return _CourseCode
            End Get
            Set(ByVal value As String)
                _CourseCode = value
            End Set
        End Property

        Private _CourseTitle As String
        Public Property CourseTitle() As String
            Get
                Return _CourseTitle
            End Get
            Set(ByVal value As String)
                _CourseTitle = value
            End Set
        End Property
        Private _NoOfSem As String
        Public Property NoofSem() As String
            Get
                Return _NoOfSem
            End Get
            Set(ByVal value As String)
                _NoOfSem = value
            End Set
        End Property

        Private _CourseStartDate As Date
        Public Property CourseStartDate() As Date
            Get
                Return _CourseStartDate
            End Get
            Set(ByVal value As Date)
                _CourseStartDate = value
            End Set
        End Property
        Private _CourseEndDate As Date
        Public Property CourseEndDate() As Date
            Get
                If Len(_CourseEndDate) = 0 Then
                    Return ""
                Else
                    Return _CourseEndDate
                End If

            End Get
            Set(ByVal value As Date)
                _CourseEndDate = value
            End Set
        End Property
        Private _screeningExam As Boolean
        Public Property screeningExam() As Boolean
            Get
                Return _screeningExam
            End Get
            Set(ByVal value As Boolean)
                _screeningExam = value
            End Set
        End Property
    End Class

End Namespace


