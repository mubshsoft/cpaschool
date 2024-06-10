Imports System.Collections
Imports MyCLS
Partial Class Faculty_ListFacContent
    Inherits System.Web.UI.Page
    Dim cid As Integer
    Dim strcourse As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                cid = Request.QueryString("id")
                'cid = 1
                FillSemester()

                'Dim dsCourseCode As DataSet
                'Dim strCourseCode As String = "select * from course where courseid=" & cid
                'dsCourseCode = CLS.fnQuerySelectDs(strCourseCode)
                'If dsCourseCode IsNot Nothing Then
                '    If dsCourseCode.Tables IsNot Nothing Then
                '        If dsCourseCode.Tables(0).Rows IsNot Nothing Then
                '            If dsCourseCode.Tables(0).Rows.Count > 0 Then
                '                strcourse = dsCourseCode.Tables(0).Rows(0)("CourseCode").ToString

                '            End If
                '        End If
                '    End If
                'End If
                binddata()
            End If
        Catch ex As Exception
        End Try


    End Sub
    Private Sub FillSemester()
        Try
            Dim dsSemTitle As DataSet
            Dim strSemQ As String = "select semesterTitle,semID from semester where courseid=" & cid & " order by semid"
            dsSemTitle = CLS.fnQuerySelectDs(strSemQ)
            If dsSemTitle IsNot Nothing Then
                If dsSemTitle.Tables IsNot Nothing Then
                    If dsSemTitle.Tables(0).Rows IsNot Nothing Then
                        If dsSemTitle.Tables(0).Rows.Count > 0 Then
                            dllSem.DataTextField = "SemesterTitle"
                            dllSem.DataValueField = "semid"
                            dllSem.DataSource = dsSemTitle
                            dllSem.DataBind()
                            dllSem.Items.Insert(0, "--SELECT--")
                            If dsSemTitle.Tables.Count > 1 Then
                                lblSem.Text = dsSemTitle.Tables(0).Rows(0)("semestertitle").ToString
                            Else
                                lblSem.Text = ""
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub binddata()

        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@courseid", cid))
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSPDataSet("SP_GetModulesByCourseID", objParamList)
            dlModules.DataSource = ds
            dlModules.DataBind()
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub dlModules_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlModules.ItemDataBound

        Try
            Dim dlPap As New DataList
            dlPap = DirectCast(e.Item.FindControl("dlPaper"), DataList)

            Dim lblMod As New Label
            lblMod = DirectCast(e.Item.FindControl("lblModuleid"), Label)
            Dim i As Integer
            i = Convert.ToInt32(lblMod.Text)
            Dim objParamList As New List(Of OleDbParameter)()

            objParamList.Add(New OleDbParameter("@moduleid", i))
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSPDataSet("SP_GetPapersByModuleID", objParamList)
            dlPap.DataSource = ds
            dlPap.DataBind()
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub dlPaper_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        Try
            Dim dlun As New DataList
            dlun = DirectCast(e.Item.FindControl("dlunit"), DataList)

            Dim lblpap As New Label
            lblpap = DirectCast(e.Item.FindControl("lblPaperid"), Label)
            Dim i As Integer
            i = Convert.ToInt32(lblpap.Text)
            Dim objParamList As New List(Of OleDbParameter)()

            objParamList.Add(New OleDbParameter("@paperid", i))
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSPDataSet("SP_GetUnitByPaperID", objParamList)
            dlun.DataSource = ds
            dlun.DataBind()
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub dllSem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllSem.SelectedIndexChanged
        'Dim dsCourseCode As DataSet
        'Dim strCourseCode As String = "select semesterTitle,semID from semester where semid=" & dllSem.SelectedValue
        'dsCourseCode = CLS.fnQuerySelectDs(strCourseCode)
        'If dsCourseCode IsNot Nothing Then
        '    If dsCourseCode.Tables IsNot Nothing Then
        '        If dsCourseCode.Tables(0).Rows IsNot Nothing Then
        '            If dsCourseCode.Tables(0).Rows.Count > 0 Then
        '                dllSem.da()

        '            End If
        '        End If
        '    End If
        'End If
        lblSem.Text = dllSem.SelectedItem.ToString
        binddataSem()
    End Sub

    Sub binddataSem()
        Dim objParamList As New List(Of OleDbParameter)()
        Try
            objParamList.Add(New OleDbParameter("@semid", dllSem.SelectedValue))
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSPDataSet("SP_GetModulesBySemCourseID", objParamList)
            dlModules.DataSource = ds
            dlModules.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class
