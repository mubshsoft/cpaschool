Imports Microsoft.VisualBasic
Namespace fmsf.lib

    Public Class LibSuppExam
        Private _BatchID As Int16
        Public Property Batchid() As Int16
            Get
                Return _BatchID
            End Get
            Set(ByVal value As Int16)
                _BatchID = value
            End Set
        End Property
        Private _stID As Int16
        Public Property stid() As Int16
            Get
                Return _stID
            End Get
            Set(ByVal value As Int16)
                _stID = value
            End Set
        End Property
        Private _PaperID As Int16
        Public Property Paperid() As Int16
            Get
                Return _PaperID
            End Get
            Set(ByVal value As Int16)
                _PaperID = value
            End Set
        End Property
    End Class
End Namespace
