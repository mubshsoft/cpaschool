Imports Microsoft.VisualBasic
Namespace fmsf.lib
    Public Class LibAddStudent
        Private _CourseID As Int16
        Public Property CourseID() As Int16
            Get
                Return _CourseID
            End Get
            Set(ByVal value As Int16)
                _CourseID = value
            End Set
        End Property

        Private _emailAddress As String
        Public Property emailAddress() As String
            Get
                Return _emailAddress
            End Get
            Set(ByVal value As String)
                _emailAddress = value
            End Set
        End Property
        Private _SecondaryEmailAddress As String
        Public Property SecondaryEmailAddress() As String
            Get
                Return _SecondaryEmailAddress
            End Get
            Set(ByVal value As String)
                _SecondaryEmailAddress = value
            End Set
        End Property

        Private _password As String
        Public Property Password() As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                _password = value
            End Set
        End Property
        Private _FirstName As String
        Public Property FirstName() As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property
        Private _LastName As String
        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property
        Private _MiddleName As String
        Public Property MiddleName() As String
            Get
                Return _MiddleName
            End Get
            Set(ByVal value As String)
                _MiddleName = value
            End Set
        End Property

        Private _Address1 As String
        Public Property Address1() As String
            Get
                Return _Address1
            End Get
            Set(ByVal value As String)
                _Address1 = value
            End Set
        End Property

        Private _Address2 As String
        Public Property Address2() As String
            Get
                Return _Address2
            End Get
            Set(ByVal value As String)
                _Address2 = value
            End Set
        End Property

        Private _ContactNumber1 As String
        Public Property ContactNumber1() As String
            Get
                Return _ContactNumber1
            End Get
            Set(ByVal value As String)
                _ContactNumber1 = value
            End Set
        End Property


        Private _ContactNumber2 As String
        Public Property ContactNumber2() As String
            Get
                Return _ContactNumber2
            End Get
            Set(ByVal value As String)
                _ContactNumber2 = value
            End Set
        End Property


        Private _Degree As String
        Public Property Degree() As String
            Get
                Return _Degree
            End Get
            Set(ByVal value As String)
                _Degree = value
            End Set
        End Property

        Private _Discipline As String
        Public Property Discipline() As String
            Get
                Return _Discipline
            End Get
            Set(ByVal value As String)
                _Discipline = value
            End Set
        End Property

        Private _DOB As Date
        Public Property DOB() As Date
            Get
                If Len(_DOB) = 0 Then
                    Return ""
                Else
                    Return _DOB
                End If

            End Get
            Set(ByVal value As Date)
                _DOB = value
            End Set

        End Property
        Private _DOBFac As String
        Public Property DOBFac() As String
            Get
                Return _DOBFac
            End Get
            Set(ByVal value As String)
                _DOBFac = value
            End Set

        End Property
        'Property is made by wahid
        Private _Gender As String
        Public Property Gender() As String
            Get
                Return _Gender
            End Get
            Set(ByVal value As String)
                _Gender = value
            End Set
        End Property

        Private _CurProfession As String
        Public Property CurProfession() As String
            Get
                Return _CurProfession
            End Get
            Set(ByVal value As String)
                _CurProfession = value
            End Set
        End Property

        Private _Nationality As String
        Public Property Nationality() As String
            Get
                Return _Nationality
            End Get
            Set(ByVal value As String)
                _Nationality = value
            End Set
        End Property

        Private _Category As String
        Public Property Category() As String
            Get
                Return _Category
            End Get
            Set(ByVal value As String)
                _Category = value
            End Set
        End Property

        Private _Date As Date
        Public Property Date1() As Date
            Get
                If Len(_Date) = 0 Then

                Else
                    Return _Date
                End If
            End Get
            Set(ByVal value As Date)
                If Len(_Date) = 0 Then

                Else
                    _Date = value
                End If

            End Set
        End Property

        Private _Place As String
        Public Property Place() As String
            Get
                Return _Place
            End Get
            Set(ByVal value As String)
                _Place = value
            End Set
        End Property

        Private _edboard1 As String
        Public Property edboard1() As String
            Get
                Return _edboard1
            End Get
            Set(ByVal value As String)
                _edboard1 = value
            End Set
        End Property

        Private _edstream1 As String
        Public Property edstream1() As String
            Get
                Return _edstream1
            End Get
            Set(ByVal value As String)
                _edstream1 = value
            End Set
        End Property

        Private _edmarks1 As Decimal
        Public Property edmarks1() As Decimal
            Get
                Return _edmarks1
            End Get
            Set(ByVal value As Decimal)
                _edmarks1 = value
            End Set
        End Property

        Private _edyrs1 As String
        Public Property edyrs1() As String
            Get
                Return _edyrs1
            End Get
            Set(ByVal value As String)
                _edyrs1 = value
            End Set
        End Property

        Private _edboard2 As String
        Public Property edboard2() As String
            Get
                Return _edboard2
            End Get
            Set(ByVal value As String)
                _edboard2 = value
            End Set
        End Property

        Private _edstream2 As String
        Public Property edstream2() As String
            Get
                Return _edstream2
            End Get
            Set(ByVal value As String)
                _edstream2 = value
            End Set
        End Property

        Private _edmarks2 As Decimal
        Public Property edmarks2() As Decimal
            Get
                Return _edmarks2
            End Get
            Set(ByVal value As Decimal)
                _edmarks2 = value
            End Set
        End Property

        Private _edyrs2 As String
        Public Property edyrs2() As String
            Get
                Return _edyrs2
            End Get
            Set(ByVal value As String)
                _edyrs2 = value
            End Set
        End Property


        Private _edboard3 As String
        Public Property edboard3() As String
            Get
                Return _edboard3
            End Get
            Set(ByVal value As String)
                _edboard3 = value
            End Set
        End Property

        Private _edstream3 As String
        Public Property edstream3() As String
            Get
                Return _edstream3
            End Get
            Set(ByVal value As String)
                _edstream3 = value
            End Set
        End Property

        Private _edmarks3 As Decimal
        Public Property edmarks3() As Decimal
            Get
                Return _edmarks3
            End Get
            Set(ByVal value As Decimal)
                _edmarks3 = value
            End Set
        End Property

        Private _edyrs3 As String
        Public Property edyrs3() As String
            Get
                Return _edyrs3
            End Get
            Set(ByVal value As String)
                _edyrs3 = value
            End Set
        End Property


        Private _edboard4 As String
        Public Property edboard4() As String
            Get
                Return _edboard4
            End Get
            Set(ByVal value As String)
                _edboard4 = value
            End Set
        End Property

        Private _edstream4 As String
        Public Property edstream4() As String
            Get
                Return _edstream4
            End Get
            Set(ByVal value As String)
                _edstream4 = value
            End Set
        End Property

        Private _edmarks4 As Decimal
        Public Property edmarks4() As Decimal
            Get
                Return _edmarks4
            End Get
            Set(ByVal value As Decimal)
                _edmarks4 = value
            End Set
        End Property

        Private _edyrs4 As String
        Public Property edyrs4() As String
            Get
                Return _edyrs4
            End Get
            Set(ByVal value As String)
                _edyrs4 = value
            End Set
        End Property


        Private _ExOrg1 As String
        Public Property ExOrg1() As String
            Get
                Return _ExOrg1
            End Get
            Set(ByVal value As String)
                _ExOrg1 = value
            End Set
        End Property

        Private _ExPh1 As String
        Public Property ExPh1() As String
            Get
                Return _ExPh1
            End Get
            Set(ByVal value As String)
                _ExPh1 = value
            End Set
        End Property

        Private _ExDesignation1 As String
        Public Property ExDesignation1() As String
            Get
                Return _ExDesignation1
            End Get
            Set(ByVal value As String)
                _ExDesignation1 = value
            End Set
        End Property

        Private _ExService1 As String
        Public Property ExService1() As String
            Get
                Return _ExService1
            End Get
            Set(ByVal value As String)
                _ExService1 = value
            End Set
        End Property

        Private _ExOrg2 As String
        Public Property ExOrg2() As String
            Get
                Return _ExOrg2
            End Get
            Set(ByVal value As String)
                _ExOrg2 = value
            End Set
        End Property

        Private _ExPh2 As String
        Public Property ExPh2() As String
            Get
                Return _ExPh2
            End Get
            Set(ByVal value As String)
                _ExPh2 = value
            End Set
        End Property

        Private _ExDesignation2 As String
        Public Property ExDesignation2() As String
            Get
                Return _ExDesignation2
            End Get
            Set(ByVal value As String)
                _ExDesignation2 = value
            End Set
        End Property

        Private _ExService2 As String
        Public Property ExService2() As String
            Get
                Return _ExService2
            End Get
            Set(ByVal value As String)
                _ExService2 = value
            End Set
        End Property

        Private _ExOrg3 As String
        Public Property ExOrg3() As String
            Get
                Return _ExOrg3
            End Get
            Set(ByVal value As String)
                _ExOrg3 = value
            End Set
        End Property

        Private _ExPh3 As String
        Public Property ExPh3() As String
            Get
                Return _ExPh3
            End Get
            Set(ByVal value As String)
                _ExPh3 = value
            End Set
        End Property

        Private _ExDesignation3 As String
        Public Property ExDesignation3() As String
            Get
                Return _ExDesignation3
            End Get
            Set(ByVal value As String)
                _ExDesignation3 = value
            End Set
        End Property

        Private _ExService3 As String
        Public Property ExService3() As String
            Get
                Return _ExService3
            End Get
            Set(ByVal value As String)
                _ExService3 = value
            End Set
        End Property

        Private _totExp As Decimal
        Public Property totexp() As Decimal
            Get
                Return _totExp
            End Get
            Set(ByVal value As Decimal)
                _totExp = value
            End Set
        End Property

        Private _aid As Int16
        Public Property aid() As Int16
            Get
                Return _aid
            End Get
            Set(ByVal value As Int16)
                _aid = value
            End Set
        End Property


        Private _stAid As Int16
        Public Property stAid() As Int16
            Get
                Return _stAid
            End Get
            Set(ByVal value As Int16)
                _stAid = value
            End Set
        End Property

        Private _Profile As String
        Public Property Profile() As String
            Get
                Return _Profile
            End Get
            Set(ByVal value As String)
                _Profile = value
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

        Private _feeStatus As Boolean
        Public Property feestatus() As Boolean
            Get
                Return _feeStatus
            End Get
            Set(ByVal value As Boolean)
                _feeStatus = value
            End Set
        End Property

        Private _ApplicantCategory As String
        Public Property ApplicantCategory() As String
            Get
                Return _ApplicantCategory
            End Get
            Set(ByVal value As String)
                _ApplicantCategory = value
            End Set
        End Property
        Private _feeremark As String
        Public Property feeremark() As String
            Get
                Return _feeremark
            End Get
            Set(ByVal value As String)
                _feeremark = value
            End Set
        End Property

        Private _ProfileImage As String
        Public Property ProfileImage() As String
            Get
                Return _ProfileImage
            End Get
            Set(ByVal value As String)
                _ProfileImage = value
            End Set
        End Property

    End Class
End Namespace
