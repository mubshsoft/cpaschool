Imports System
Imports System.IO
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf

Partial Class ElearningFMSF
    Inherits System.Web.UI.Page





    'Dim strISBN As String
    'Dim strSES As String
    'Dim rsBook As OleDbDataReader


    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Try

    '        If Request.QueryString("confirm") = "YES" Then
    '            MyCLS.prcEMail("narender.sharma@netsoftit.com", Session("Login"), "PDF Missing - " & strISBN, "Please upload this PDF!")
    '            Response.Write("<b>We have recieved your Query!<BR>You will be confirmed shorlty.</b><BR><BR><BR><a href='MyAccount.aspx'><< BACK</a>")
    '            Exit Sub
    '        End If
    '        strISBN = Request.QueryString("ISBN")
    '        'strSES = Session("sessionID")
    '        MyCLS.ConOpen()


    '        Dim rsChk As OleDbDataReader
    '        rsChk = MyCLS.fnQuerySelectRS("select * from cart where username='" & Session("login") & "' and PID='" & strISBN & "'")
    '        If rsChk.HasRows = True Then

    '        Else
    '            Response.Redirect("Default.aspx")
    '        End If


    '        rsBook = MyCLS.fnQuerySelectRS("select * from downloadtracking where username='" & Session("Login") & "' and isbn='" & strISBN & "' and  downloadtrack=0 AND pdfName='" & Request.QueryString("fname") & "'")
    '        If rsBook.HasRows = True Then
    '            '***NEW CODE START*****************************
    '            Dim strpath As String
    '            'MsgBox(Request.QueryString("fname"))
    '            If Request.QueryString("fname") <> "CB.pdf" Then
    '                strpath = Server.MapPath("") & "/BOOKS/" & strISBN & "/Chapter wise Pdf/" & Request.QueryString("fname")
    '            Else
    '                strpath = Server.MapPath("") & "/BOOKS/" & strISBN & "/Combined Books/" & Request.QueryString("fname")
    '            End If
    '            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(strpath) = True Then

    '                Dim strSISBNFIlename As String
    '                strSISBNFIlename = strISBN & "--" & Request.QueryString("fname")
    '                'Dim m As New MemoryStream()
    '                'Dim document As New Document()

    '                'Try
    '                '    Response.ContentType = "application/pdf"
    '                '    Dim writer As PdfWriter = PdfWriter.GetInstance(document, m)
    '                '    Dim Reader As PdfReader = PdfReader.GetPdfObject(strpath)
    '                '    'writer.CloseStream = False
    '                '    Reader.ToString()
    '                '    'document.Open()
    '                '    'document.Add(New Paragraph("Hello World"))
    '                'Catch ex As DocumentException
    '                '    MsgBox(ex.Message)
    '                'End Try
    '                'document.Close()
    '                'Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length)
    '                'Response.OutputStream.Flush()
    '                'Response.OutputStream.Close()
    '                'm.Close()
    '                '***NEW CODE END*****************************

    '                ' ''Dim client As New System.Net.WebClient
    '                ' ''Dim buffer(10) As Byte
    '                '' ''Dim strpath As String = Server.MapPath("") & "/downloads/" & strISBN & ".pdf"
    '                '' ''Dim strpath As String = Server.MapPath("") & "/BOOKS/" & strISBN & "/Chapter wise Pdf/" & Request.QueryString("fname")
    '                '' ''If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(strpath) = True Then
    '                ' ''buffer = client.DownloadData(strpath)

    '                ' ''If buffer.ToString <> "" Then
    '                ' ''    Response.ContentType = "application/pdf"
    '                ' ''    Response.AddHeader("content-length", buffer.Length.ToString())
    '                ' ''    Response.BinaryWrite(buffer)
    '                ' ''End If


    '                Response.ContentType = "application/pdf"
    '                'Response.AppendHeader("Content-Disposition", "attachment; filename=SailBig.jpg")
    '                Response.AppendHeader("Content-Disposition", "attachment; filename=;")
    '                Response.TransmitFile(strpath)



    '                ' Response.End()
    '                MyCLS.fnQueryUpdate("update downloadTracking set downloadtrack=1 where username='" & Session("Login") & "' and isbn='" & strISBN & "' and  downloadtrack=0 AND pdfName='" & Request.QueryString("fname") & "'")
    '                MyCLS.fnQueryInsert("insert into UserTracking(username,ipAddress,subscription_ID,typ_value,AccessType,readdate_timeStart) values('" & Session("Login") & "','" & Request.ServerVariables("REMOTE_ADDR") & "'," & IIf(Len(Session("SubscriptionID")) > 0, Session("SubscriptionID"), 0) & ",'" & strSISBNFIlename & "','Download','" & Date.Now & "')")



    '            Else
    '                MyCLS.prcEMail("rahul.dss@gmail.com", Session("Login"), "PDF Missing - " & strISBN, "Please upload this PDF!")
    '                Response.Write("<b>Oops! Sorry This File Does not Exists!</b><BR>Please Try after some time.<BR><BR><BR><a href='MyAccount.aspx'><< BACK</a>")
    '            End If
    '        Else
    '            Response.Write("<b>Oops! You have already downloaded this File!</b><BR>Please <a href='DownloadDetail.aspx?Confirm=YES'>Let us know</a> If you want to download it again.<BR><BR><BR><a href='MyAccount.aspx'><< BACK</a>")
    '        End If

    '    Catch ex As Exception
    '        Response.Write(MyCLS.fnShowException(ex))
    '        Response.End()
    '    End Try
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim Path As String
        'Path = Server.MapPath("") & "\studentDoc\" & Session("email") & "\" & Request.QueryString("fnm")
        'Dim file As System.IO.FileInfo = New System.IO.FileInfo(Path) '-- if the file exists on the server  
        'If file.Exists Then 'set appropriate headers  
        '    Response.Clear()
        '    Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
        '    Response.AddHeader("Content-Length", file.Length.ToString())
        '    Response.ContentType = "application/octet-stream"
        '    Response.WriteFile(file.FullName)
        '    Response.End() 'if file does not exist  
        'Else
        '    Response.Write("This file does not exist.")
        'End If 'nothing in the URL as HTTP GET  


    End Sub
End Class
