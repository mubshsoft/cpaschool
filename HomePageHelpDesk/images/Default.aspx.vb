Imports System.Data.SqlClient
Partial Class Index
    Inherits System.Web.UI.Page
    Protected dsNews As New DataSet
    Public rowCount As Integer = 1
    Public rowNumber As Integer = 2
    Public rowCount2 As Integer = 1
    Public rowNumber2 As Integer = 3
    Public dsAllumni As New DataSet
    Public dsTestimonials As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            BindCourseDetails()
            bindNews()
            BindFaculties()
            BindAlumni()
            BindBannerDetails()
            BindTestimonial()
        End If
    End Sub

    Sub BindBannerDetails()
        Try
            Dim dsDetails As New DataSet
            Dim strQ As String

            strQ = "select courseid,coursename,left(convert(varchar(350),textdetails),350) +  '...' as textdetails ,text1,text2,text3,text4,imagepath,checked,chkcourseoffered,BannerHeading,BannerDesc,images,dataorientation,dataslice1rotation,dataslice2rotation,dataslice1scale,dataslice2scale from coursedetails where Checked=1"
            dsDetails = CLS.fnQuerySelectDs(strQ)
            Repeater1.DataSource = dsDetails
            Repeater1.DataBind()



        Catch ex As Exception

        End Try
    End Sub
    Sub bindNews()
        Try
            Dim strq As String = "select NewsDesc as descr,newsdate as ndate from News where NewsType='General' union select eventtitle as descr,eventdate as ndate from event"
            Dim dsNews As New DataSet()
            dsNews = CLS.fnQuerySelectDs(strq)
            If dsNews IsNot Nothing Then
                If dsNews.Tables IsNot Nothing Then
                    If dsNews.Tables(0).Rows IsNot Nothing Then
                        If dsNews.Tables(0).Rows.Count > 0 Then
                            dlnews.DataSource = dsNews
                            dlnews.DataBind()
                        End If
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
            '   strQ = "select * from coursedetails where Checked=1"
            strQ = "select courseid,coursename,left(convert(varchar(350),textdetails),350) +  '...' as textdetails ,text1,text2,text3,text4,imagepath,checked,chkcourseoffered from coursedetails where Checked=1"
            dsDetails = CLS.fnQuerySelectDs(strQ)
            DlsDetails.DataSource = dsDetails
            DlsDetails.DataBind()



        Catch ex As Exception

        End Try
    End Sub



    Sub BindFaculties()
        Try
            Dim ds As New DataSet
            Dim strQ As String
            strQ = "select * from FacultyRegistration"
            ds = CLS.fnQuerySelectDs(strQ)
            rptrFaculties.DataSource = ds
            rptrFaculties.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Sub BindAlumni()
        Try

            dsAllumni = CLS.ExecuteCLSSP("Sp_GetAlumniDetails")
            'rptrAlumni.DataSource = dsAllumni
            'rptrAlumni.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Sub BindTestimonial()
        Try
            Dim ds As New DataSet()

            Dim objParamList As New List(Of OleDbParameter)()
            objParamList.Add(New OleDbParameter("@stid", 0))
            ds = CLS.ExecuteCLSSPDataSet("SP_GettestimonialsListByID", objParamList)
            Dim dt As New DataTable()

            dt = ds.Tables(0)
            Dim dv As DataView = dt.DefaultView
            dv.RowFilter = "status=1"
            If (dv.Count > 0) Then
                If (dv.Count > 3) Then
                    sttestimonial.Visible = True
                End If
                dsTestimonials.Tables.Add(dv.ToTable())
            End If

        Catch ex As Exception

        End Try
    End Sub

    ' Protected Sub DlsDetails_RowDataBound(ByVal sender As Object, ByVal e As DataListItemEventArgs) Handles DlsDetails.ItemDataBound
    'Try
    '    Dim lstItem As DataListItem = e.Item
    '    Dim imghide As Image = DirectCast(e.Item.FindControl("imghide"), Image)
    '    Dim Image1 As Image = DirectCast(e.Item.FindControl("Image1"), Image)
    '    If rowCount = rowNumber Then
    '        imghide.Visible = False
    '        rowNumber += rowNumber
    '    Else
    '        imghide.Visible = True
    '    End If

    '    rowCount += 1


    '    If rowCount2 = rowNumber2 Or rowCount2 = rowNumber2 + 1 Then
    '        Image1.Visible = False
    '        '-- rowNumber2 += rowNumber2
    '    End If


    '    rowCount2 += 1

    'Catch ex As Exception

    'End Try

    '    Try
    'Dim lstItem As DataListItem = e.Item
    'Dim Image1 As Image = DirectCast(e.Item.FindControl("Image1"), Image)


    '        If rowCount = 2 Then
    '            Image1.Visible = False
    '        End If
    '        rowCount += 1
    '    Catch ex As Exception

    '    End Try
    'End Sub



    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick

    'End Sub
End Class
