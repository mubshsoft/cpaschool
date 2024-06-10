Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Web

Namespace Emoticons



    ''' <summary> 
    ''' A single emoticon. 
    ''' </summary> 
    Public Class Emoticon
#Region "Static members."
        ' ------------------------------------------------------------------ 

        ''' <summary> 
        ''' Returns a collection of all available emoticons. 
        ''' </summary> 
        Public Shared ReadOnly Property All() As Emoticon()
            Get
                Dim result As New ArrayList()

                ' -- 
                ' Actually add the emoticons. 

                ' MSN Messenger 4.5. 
                result.Add(New Emoticon("thumbs_up.gif", "(Y)", "Thumbs up"))
                result.Add(New Emoticon("thumbs_down.gif", "(N)", "Thumbs down"))
                result.Add(New Emoticon("beer_yum.gif", "(B)", "Beer"))
                result.Add(New Emoticon("martini_shaken.gif", "(D)", "Martini Glass"))
                result.Add(New Emoticon("girl_handsacrossamerica.gif", "(X)", "Girl"))
                result.Add(New Emoticon("guy_handsacrossamerica.gif", "(Z)", "Boy"))
                result.Add(New Emoticon("bat.gif", ":-[", "Bat"))
                result.Add(New Emoticon("girl_hug.gif", "(})", "Hug right"))
                result.Add(New Emoticon("dude_hug.gif", "({)", "Hug left"))
                result.Add(New Emoticon("regular_smile.gif", ":-)", "smiley"))
                result.Add(New Emoticon("teeth_smile.gif", ":-D", "Theeth smiley"))
                result.Add(New Emoticon("omg_smile.gif", ":-O", "OMG smiley"))
                result.Add(New Emoticon("tounge_smile.gif", ":-P", "Tounge smiley"))
                result.Add(New Emoticon("wink_smile.gif", ";-)", "Wink smiley"))
                result.Add(New Emoticon("sad_smile.gif", ":-)", "Sad smiley"))
                result.Add(New Emoticon("confused_smile.gif", ":-S", "Confused smiley"))
                result.Add(New Emoticon("whatchutalkingabout_smile.gif", ":-|", "Serious smiley"))
                result.Add(New Emoticon("cry_smile.gif", ":'(", "Crying smiley"))
                result.Add(New Emoticon("cry_smile.gif", ":-(", "Crying smiley"))
                result.Add(New Emoticon("embaressed_smile.gif", ":$", "Embaressed smiley"))
                result.Add(New Emoticon("shades_smile.gif", "(H)", "smiley with shades"))
                result.Add(New Emoticon("angry_smile.gif", ":-@", "Angry smiley"))
                result.Add(New Emoticon("angel_smile.gif", "(A)", "Angel smiley"))
                result.Add(New Emoticon("devil_smile.gif", "(6)", "Devil smiley"))
                result.Add(New Emoticon("heart.gif", "(L)", "Red heart"))
                result.Add(New Emoticon("broken_heart.gif", "(U)", "Broken heart"))
                result.Add(New Emoticon("kiss.gif", "(K)", "Red lips"))
                result.Add(New Emoticon("present.gif", "(G)", "Present"))
                result.Add(New Emoticon("rose.gif", "(F)", "Red rose"))
                result.Add(New Emoticon("wilted_rose.gif", "(W)", "Wilted rose"))
                result.Add(New Emoticon("camera.gif", "(P)", "Camera"))
                result.Add(New Emoticon("film.gif", "(~)", "Film"))
                result.Add(New Emoticon("phone.gif", "(T)", "Phone"))
                result.Add(New Emoticon("kittykay.gif", "(@)", "Cat"))
                result.Add(New Emoticon("bowwow.gif", "(&)", "Dog"))
                result.Add(New Emoticon("coffee.gif", "(C)", "Coffee"))
                result.Add(New Emoticon("lightbulb.gif", "(I)", "Light bulb"))
                result.Add(New Emoticon("moon.gif", "(S)", "Moon"))
                result.Add(New Emoticon("musical_note.gif", "(8)", "Musical note"))
                result.Add(New Emoticon("envelope_open.gif", "(OE)", "Open envelope"))
                result.Add(New Emoticon("cake.gif", "(^)", "Cake"))
                result.Add(New Emoticon("clock.gif", "(O)", "Clock"))
                result.Add(New Emoticon("rainbow.gif", "(R)", "Rainbow"))
                result.Add(New Emoticon("sun.gif", "(#)", "Sun"))
                result.Add(New Emoticon("questionmark.gif", "(?)", "Questionmark"))
                result.Add(New Emoticon("hs.gif", "(%)", "Handcuff"))

                ' Some of MSN Messenger 6. 
                result.Add(New Emoticon("envelope.gif", "(E)", "Envelope"))
                result.Add(New Emoticon("pizza.gif", "(PI)", "Pizza"))
                result.Add(New Emoticon("soccer_ball.gif", "(SO)", "Soccer ball"))
                result.Add(New Emoticon("money.gif", "(MO)", "Money"))
                result.Add(New Emoticon("island.gif", "(IP)", "Island"))
                result.Add(New Emoticon("plane.gif", "(AP)", "Plane"))
                result.Add(New Emoticon("auto.gif", "(AU)", "Car"))
                result.Add(New Emoticon("mobile_phone.gif", "(MP)", "Mobile phone"))
                result.Add(New Emoticon("sheep.gif", "(BAH)", "Sheep"))
                result.Add(New Emoticon("snail.gif", "(SN)", "Snail"))

                ' Some of my own. 

                result.Add(New Emoticon("uwe.gif", "(Uwe)", "The Uwe (<--clever!)", "http://www.magerquark.de"))
                result.Add(New Emoticon("harald.gif", "(Harald)", "The Harald (www.geisselhart.de)", "http://www.geisselhart.de"))
                result.Add(New Emoticon("johanna.gif", "(Johanna)", "The Johanna (www.kuhnijunior.de)", "http://www.kuhnijunior.de"))
                result.Add(New Emoticon("andreas.gif", "(Andreas)", "The Andreas (www.kuhni.de)", "http://www.kuhni.de"))
                result.Add(New Emoticon("klettern.gif", "(Climbing)", "Climbing"))
                result.Add(New Emoticon("geburtstag.gif", "(Birthday cake)", "Birthday cake"))
                result.Add(New Emoticon("t19.gif", "(:)", ""))
                result.Add(New Emoticon("zeta-producer.gif", "(ZP)", "zeta producer", "http://www.zeta-producer.de"))
                result.Add(New Emoticon("m3u.gif", "(WinAmp)", "Winamp"))
                result.Add(New Emoticon("new.gif", "(New)", "New"))

                ' -- 
                result.Add(New Emoticon("biggrin.gif", "(biggrin)", "biggrin"))
                result.Add(New Emoticon("cool.gif", "(cool)", "cool"))
                result.Add(New Emoticon("frown.gif", "(frown)", "frown"))
                result.Add(New Emoticon("laugh.gif", "(laugh)", "laugh"))
                result.Add(New Emoticon("mad.gif", "(mad)", "mad"))
                result.Add(New Emoticon("smile.gif", "(smile)", "smile"))
                result.Add(New Emoticon("tears.gif", "(tears)", "tears"))
                If result.Count = 0 Then
                    Return Nothing
                Else
                    Return DirectCast(result.ToArray(GetType(Emoticon)), Emoticon())
                End If
            End Get
        End Property

        ''' <summary> 
        ''' Returns a string with all emoticons replaced by their images. 
        ''' </summary> 
        Public Shared Function Format(ByVal input As String) As String
            If input Is Nothing OrElse input.Length = 0 Then
                Return input
            Else
                Dim result As String = input

                Dim all__1 As Emoticon() = All
                For Each emoticon As Emoticon In all__1
                    Dim a As String
                    Dim a_ As String
                    Dim border As Integer

                    ' Decide whether a link is required. 
                    If emoticon.Url IsNot Nothing AndAlso emoticon.Url.Length > 0 Then
                        a = String.Format("<a href=""{0}"">", emoticon.Url)
                        a_ = "</a>"
                        border = 1
                    Else
                        a = ""
                        a_ = ""
                        border = 0
                    End If

                    ' Replace this emoticon. 
                    Dim replacement As String = String.Format("{0}<img src=""{1}"" alt=""{2}"" align=""AbsMiddle"" border=""{3}"" />{4}", a, emoticon.VirtualPath, HttpUtility.HtmlEncode(emoticon.Title), border, a_)

                    result = result.Replace(emoticon.Shortcut, replacement)
                Next

                Return result
            End If
        End Function

        ' ------------------------------------------------------------------ 
#End Region

#Region "Constructors."
        ' ------------------------------------------------------------------ 

        Public Sub New(ByVal src As Emoticon)
            Shortcut = src.Shortcut
            Filename = src.Filename
            Title = src.Title
            Url = src.Url

            Check()
        End Sub

        Public Sub New(ByVal filename__1 As String, ByVal shortcut__2 As String)
            Shortcut = shortcut__2
            Filename = filename__1

            Check()
        End Sub

        Public Sub New(ByVal filename__1 As String, ByVal shortcut__2 As String, ByVal title__3 As String)
            Shortcut = shortcut__2
            Filename = filename__1
            Title = title__3

            Check()
        End Sub

        Public Sub New(ByVal filename__1 As String, ByVal shortcut__2 As String, ByVal title__3 As String, ByVal url__4 As String)
            Shortcut = shortcut__2
            Filename = filename__1
            Title = title__3
            Url = url__4

            Check()
        End Sub

        ' ------------------------------------------------------------------ 
#End Region

#Region "Properties."
        ' ------------------------------------------------------------------ 

        ''' <summary> 
        ''' The (case-sensitive!) string to be replaced with the emoticon. 
        ''' </summary> 
        Public Shortcut As String = ""

        ''' <summary> 
        ''' The filename (no path) of the emoticon. 
        ''' </summary> 
        Public Filename As String = ""

        ''' <summary> 
        ''' The optional tooltip of the emoticon. 
        ''' </summary> 
        Public Title As String = ""

        ''' <summary> 
        ''' The optional URL of the emoticon. If specified, the emoticon 
        ''' can be clicked. 
        ''' </summary> 
        Public Url As String = ""

        ' ------------------------------------------------------------------ 
#End Region

#Region "Internal helper."
        ' ------------------------------------------------------------------ 

        ''' <summary> 
        ''' Returns the complete virtual path. 
        ''' </summary> 
        Public ReadOnly Property VirtualPath() As String
            Get
                Dim path As String = "~/Emoticons/" & Filename
                Return ReplaceTilde(path)
            End Get
        End Property

        ''' <summary> 
        ''' Get the root of the current web application. 
        ''' Expands a "~" character by the real path. 
        ''' </summary> 
        Private Shared Function ReplaceTilde(ByVal path As String) As String
            If HttpContext.Current.Request.ApplicationPath = "/" Then
                Return path.Replace("~", "")
            Else
                Return path.Replace("~", HttpContext.Current.Request.ApplicationPath)
            End If
        End Function

        ''' <summary> 
        ''' Do member-checking, whether it is valid. 
        ''' </summary> 
        Private Sub Check()
            If Shortcut Is Nothing OrElse Shortcut.Length = 0 Then
                Throw New ArgumentException("Emoticon.Shortcut must be non-empty", "Emoticon.Shortcut")
            End If
            If Filename Is Nothing OrElse Filename.Length = 0 Then
                Throw New ArgumentException("Emoticon.Filename must be non-empty", "Emoticon.Filename")
            End If
        End Sub

        ' ------------------------------------------------------------------ 
#End Region
    End Class


End Namespace
