Imports System.Data.SqlClient
Imports fmsf.DAL
Imports fmsf.lib
Partial Class Default_new
    Inherits System.Web.UI.Page
    Protected dsNews As New DataSet
    Public rowCount As Integer = 1
    Public rowNumber As Integer = 2
    Public rowCount2 As Integer = 1
    Public rowNumber2 As Integer = 3
    Public dsAllumni As New DataSet
    Public dsTestimonials As New DataSet
    Public dsFigures As New DataSet
    Protected stdCourseCount As New Integer
    Protected stdPassedCount As New Integer
    Protected stdAdmissionCount As New Integer

    Protected VideoDemo As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
  
            BindCourseDetails()
            bindNews()
            BindFaculties()
            BindAlumni()
          BindBannerDetails()
            BindTestimonial()
            BindFigures()
            bindDemoVideo()
            GetListOfFaculty()
            getAboutUs()
            'stdCourseCount = 4
            'stdAdmissionCount = 500
            'stdPassedCount = 600
        End If
    End Sub

    Sub bindNews()
        Try
            'Dim strq As String = "select NewsId,NewsDesc as descr,newsdate as ndate from News where NewsType='General' union select EventId, eventtitle as descr,eventdate as ndate from event"
            'Dim dsNews As New DataSet()
            'dsNews = CLS.fnQuerySelectDs(strq)
            Dim DSNews As New DataSet()
            DSNews = CLS.ExecuteCLSSP("SP_GetNewsandEvent")

            Dim dt As DataTable = DSNews.Tables(0).AsEnumerable().Take(3).CopyToDataTable()

            If dt IsNot Nothing Then

                If dt.Rows IsNot Nothing Then
                    If dt.Rows.Count > 0 Then
                        dlnews.DataSource = dt
                        dlnews.DataBind()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
    Sub BindCourseDetails()
        Try
            Dim dsDetails As New DataSet
            Dim strQ As String

            strQ = "select courseid,coursename,left(convert(varchar(250),textdetails),250) +  '...' as textdetails ,text1,text2,text3,text4,imagepath,checked,chkcourseoffered,CourseOfferedIcon from coursedetails where Checked=1 order by ordernumber"
            dsDetails = CLS.fnQuerySelectDs(strQ)
            DlsDetails.DataSource = dsDetails
            DlsDetails.DataBind() ' comment made on 18 dec 20



        Catch ex As Exception

        End Try
    End Sub
    Sub BindBannerDetails()
        Try
            Dim dsDetails As New DataSet
            Dim strQ As String

            strQ = "select courseid,coursename,left(convert(varchar(350),textdetails),350) +  '...' as textdetails ,text1,text2,text3,text4,imagepath,checked,chkcourseoffered,BannerHeading,BannerDesc,images,dataorientation,dataslice1rotation,dataslice2rotation,dataslice1scale,dataslice2scale from coursedetails where Checked=1 and images<>''"
            dsDetails = CLS.fnQuerySelectDs(strQ)
            Repeater1.DataSource = dsDetails
            Repeater1.DataBind()



        Catch ex As Exception

        End Try
    End Sub



    Sub BindFaculties()
        Try
            Dim ds As New DataSet
            Dim strQ As String
            strQ = "select *,CASE WHEN len(convert(varchar(200),profile))>200 then left(convert(varchar(200),profile),200) + '..' ELSE profile END as ProfileData from FacultyRegistration where status=0  order by seq"
            ds = CLS.fnQuerySelectDs(strQ)
            'rptrFaculties.DataSource = ds
            'rptrFaculties.DataBind()
            'comment made on 18 dec 20

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetListOfFaculty()


        Dim ds As New DataSet
        Dim strQ As String
        strQ = "select CASE WHEN datalength(Profile) >= 400 THEN left(cast(Profile as varchar(max)),400) +' <a>Read More...</a> ' ELSE Profile END  As profiledata,* from FacultyRegistration where status=0 order by seq"
        ds = CLS.fnQuerySelectDs(strQ)
        Dim arr As ArrayList = New ArrayList()
        Dim sb As StringBuilder = New StringBuilder()
        Dim sbul As StringBuilder = New StringBuilder()

        Dim k As Integer
        Dim countRec As Integer = ds.Tables(0).Rows.Count - 1
        For k = 0 To ds.Tables(0).Rows.Count - 1 Step k + 1
            If (k = 0) Then
                sbul.Append("<ul id = 'testim-dots' Class='dots'>")
                sbul.Append("<li Class='dot active'")
                sbul.Append("</li><!--")
            Else
                If (k <> countRec) Then
                    sbul.Append("--><li class='dot'></li><!--")
                Else
                    sbul.Append("--><li class='dot'></li>")
                    sbul.Append("</ul>")
                End If
            End If
        Next

        Dim liDots As New Literal
        liDots.Text = sbul.ToString()
        PlcDotsCount.Controls.Add(liDots)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1 Step i + 1


                Dim id As String = Convert.ToInt32(ds.Tables(0).Rows(i)("fid").ToString())

                Dim Images As String = ""
                Images = ds.Tables(0).Rows(i)("Images").ToString()
                If (String.IsNullOrEmpty(Images)) Then
                    Images = "Images/noimage.png"
                End If
                Dim firstName As String = ds.Tables(0).Rows(i)("firstName").ToString()
                Dim lastname As String = ds.Tables(0).Rows(i)("lastname").ToString()
                Dim Profile As String = ds.Tables(0).Rows(i)("profiledata").ToString()





                If (id = 1) Then
                    sb.Append("<div class='active' id='" + id + "'>")
                    sb.Append("<div class='img'>")
                    'sb.Append("<img src='https://image.ibb.co/hgy1M7/5a6f718346a28820008b4611_750_562.jpg' alt=''>")
                    sb.Append("<img src='" + Images + "' alt=''>")
                    sb.Append("</div>")
                    sb.Append("<h2>")
                    sb.Append(firstName + " " + lastname)
                    sb.Append("</h2>")
                    sb.Append("<p style='pointer-events: none;'>")
                    sb.Append(Profile)
                    sb.Append("</p>")
                    sb.Append("</div>")
                Else
                    sb.Append("<div id='" + id + "'>")
                    sb.Append("<div class='img'>")
                    'sb.Append("<img src='https://image.ibb.co/kL6AES/Top_SA_Nicky_Oppenheimer.jpg' alt=''>")
                    sb.Append("<img src='" + Images + "' alt=''>")
                    sb.Append("</div>")
                    sb.Append("<h2>")
                    sb.Append(firstName + " " + lastname)
                    sb.Append("</h2>")
		    sb.Append("<a style='color:black;font-weight:normal;' title='click anywhere to read more' href='FacultiesDetail.aspx?cid=0'>")
                    sb.Append("<p>")
                    sb.Append(Profile)
	            sb.Append("</p>")
		    sb.Append("</a>")
		    sb.Append("</div>")
                End If


            Next


            Dim li As New Literal
            li.Text = sb.ToString()
            PlaceHolder1.Controls.Add(li)



        End If
    End Sub
    Sub BindAlumni()
        Try

            dsAllumni = CLS.ExecuteCLSSP("Sp_GetAlumniDetails")

        Catch ex As Exception

        End Try
    End Sub

    Sub BindTestimonial()
        Try
            Dim ds As New DataSet()

            Dim objParamList As New List(Of OleDbParameter)()
            objParamList.Add(New OleDbParameter("@stid", 0))
            ds = CLS.ExecuteCLSSPDataSet("SP_GettestimonialsListByID4homepage", objParamList)
            Dim dt As New DataTable()

            dt = ds.Tables(0)
            Dim dv As DataView = dt.DefaultView
            'dv.RowFilter = "status=1"
            If (dv.Count > 0) Then
                If (dv.Count > 3) Then
                    'sttestimonial.Visible = True
                    ' comment made on 18 dec 20
                End If
                dsTestimonials.Tables.Add(dv.ToTable())
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub BindFigures()
        Try

            dsFigures = CLS.ExecuteCLSSP("SP_FigureAndfact")
            If dsFigures IsNot Nothing Then
                If dsFigures.Tables IsNot Nothing Then
                    If dsFigures.Tables(0).Rows IsNot Nothing Then
                        If dsFigures.Tables(0).Rows.Count > 0 Then
                            stdCourseCount = dsFigures.Tables(0).Rows(0)("Rcount").ToString()
                            stdAdmissionCount = dsFigures.Tables(0).Rows(1)("Rcount").ToString()
                            stdPassedCount = dsFigures.Tables(0).Rows(2)("Rcount").ToString()
                        End If
                    End If

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub bindDemoVideo()

        Dim objParamList As New List(Of OleDbParameter)()
        Try

            Dim strq As String = "select TOP 1 * from DemoManual where type='Video' and checked=1 order by id desc"
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strq)

            If ds.Tables(0).Rows.Count > 0 Then
                Dim strPath As String = ds.Tables(0).Rows(0)("filepath").ToString()
                Dim fullPath As String = "../" & strPath
                VideoDemo = fullPath
                ' ifrm.Attributes.Add("src", fullPath)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub getAboutUs()
        Try
            Dim objLIBExam As New LIBExam()
            Dim objDalExam As New DALExam()
            Dim objLibExamListing As New LIBExamListing()

            Dim st As String
            st = objDalExam.GetAboutus()
            lbltext.Text = st.Substring(0, 2400)
        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)


        End Try
    End Sub
End Class
