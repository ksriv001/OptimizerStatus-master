Public Class About
    Inherits Page


    Function getlatesttimestamp(fordate As Date) As String
        Dim req As String
        Dim tom As Date = DateAdd(DateInterval.Day, 1, fordate)


        Dim cnazureAutoBatch As New ADODB.Connection

        If cnazureAutoBatch.State = 1 Then cnazureAutoBatch.Close()
        If cnazureAutoBatch.State = 0 Then
            cnazureAutoBatch.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnazureAutoBatch.Open()
        End If

        Dim rs As New ADODB.Recordset

        Dim timestamp As String

        req = "SELECT TOP 1 * FROM [FOSLOG] where carrierid = 65 and  foslastupdate < '10/9/2012'  order by id desc"
        req = Replace(req, "10/9/2012", tom.Month & "/" & tom.Day & "/" & tom.Year)
        req = Replace(req, "65", DrpCarrier.SelectedValue)

        rs.Open(req, cnazureAutoBatch, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
       

        If Not rs.EOF Then
            timestamp = rs.Fields("FOSLastUpdate").Value
            If rs.State = 1 Then rs.Close()
        End If

        If rs.State = 1 Then rs.Close()

        getlatesttimestamp = timestamp

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' DrpCarrier.Items.Clear()



        'If Not (IsNothing(Session("C"))) Then
        '    If Session("C") = "TMC" Then


        '        Dim i As New ListItem
        '        i.Text = "TMC"
        '        i.Value = 65
        '        i.Selected = False

        '        DrpCarrier.Items.Add(i)



        '    End If
        'Else

        '    Dim i As New ListItem
        '    i.Selected = False
        '    i.Text = "XO"
        '    i.Value = 49
        '    DrpCarrier.Items.Add(i)

        '    i.Selected = False
        '    i.Text = "WU"
        '    i.Value = 100
        '    DrpCarrier.Items.Add(i)

        '    i.Selected = False
        '    i.Text = "JLX"
        '    i.Value = 104
        '    DrpCarrier.Items.Add(i)

        '    i.Selected = False
        '    i.Text = "TMC"
        '    i.Value = 65
        '    DrpCarrier.Items.Add(i)

        'End If


        'For i = 0 To DrpCarrier.Items.Count - 1
        '    DrpCarrier.Items(i).Selected = False

        'Next



        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then
            Response.Redirect("login.aspx")
        End If

        If IsNothing(Session("carrierid")) Then Response.Redirect("login.aspx")
        If Session("carrierid") = 0 Then Response.Redirect("login.aspx")

        If Not (Page.IsPostBack) Then
            '20151103 - pab - fix error - Conversion from string "defaultemail" to type 'Integer' is not valid 
            'Dim session As String = getlatesttimestamp(Now)
            Dim sessiondate As String = getlatesttimestamp(Now)



            Dim req As String


            '20151103 - pab - restrict carrier data if not coastal login
            req = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairporticao, arrivalairporticao, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where departuredategmt = '10/8/2012' "
            Dim email As String = session("defaultemail")
            If InStr(email, "coastalaviationsoftware") > 0 Or email = "rk" Then
                req &= " and carrierid = 104 "
            Else
                req &= " and carrierid = " & session("carrierid")

                DrpCarrier.Items.Clear()
                Dim li As New ListItem
                li.Value = session("carrierid")
                Select Case session("carrierid").ToString
                    Case "49"
                        li.Text = "XO"
                    Case "65"
                        li.Text = "TMC"
                    Case "100"
                        li.Text = "WU"
                    Case "104"
                        li.Text = "JLX"
                    Case "107"
                        li.Text = "ASI"
                    Case "108"
                        li.Text = "DELTA"
                    Case Else
                        li.Text = "???"
                End Select
                DrpCarrier.Items.Add(li)
            End If


            ' req = Replace(req, "2012-10-08 14:20:40.000", session)

            req = Replace(req, "10/8/2012", Now.Month & "/" & Now.Day & "/" & Now.Year)

            SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")

            SqlDataSource1.SelectCommand = req
            SqlDataSource1.DataBind()

        End If



    End Sub

    Private Sub ExportToExcel(ByVal strFileName As String, ByVal dg As GridView)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
        Response.ContentType = "application/vnd.ms-excel"
        Response.Charset = ""
        Me.EnableViewState = False
        Dim oStringWriter As New System.IO.StringWriter
        Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)

        GridView1.RenderControl(oHtmlTextWriter)

        Response.Write(oStringWriter.ToString())
        Response.[End]()




    End Sub



    'Protected Sub ImagebttnExcel_Click1(sender As Object, e As EventArgs) Handles ImagebttnExcel.Click
    '    ExportToExcel("Report.xls", GridView1)
    'End Sub

    Protected Sub RadDatePicker1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePicker1.SelectedDateChanged

        updategrid()


    End Sub

    Protected Sub DrpCarrier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrpCarrier.SelectedIndexChanged
        updategrid()
    End Sub


    Function updategrid()
        '20151103 - pab - fix error - Conversion from string "defaultemail" to type 'Integer' is not valid 
        'Dim session As String = "2012-10-08 14:20:40.000"
        Dim sessiondate As String = "2012-10-08 14:20:40.000"
        If Not (IsNothing(RadDatePicker1.SelectedDate)) Then
            sessiondate = getlatesttimestamp(RadDatePicker1.SelectedDate)
        End If


        Dim req As String




        req = "SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairporticao, arrivalairporticao, departuredategmt, " &
            "departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] " &
            " where  carrierid = abc123 And  CONVERT(date, departuredategmtkey	, 1) >= '10/8/2012'  And  CONVERT(date, departuredategmtkey	, 1) <= '10/9/2012'   "

        If chkHistorical.Checked Then
            req = Replace(req, "[FOSFlights]", "[FOSFlightHistory]")

        End If


        '20160109 - pab - select distinct for asi to remove duplicates
        If DrpCarrier.SelectedValue = 107 Then
            req = Replace(req, "select ", "select distinct ")
        End If

        If txtAC.Text <> "" Then req = req & " and aircraftid = '" & txtAC.Text.ToString.Trim & "'"
        If txtTrip.Text <> "" Then req = req & " and tripnumber = '" & txtTrip.Text.ToString.Trim & "'"

        '  req = Replace(req, "2012-10-08 14:20:40.000", session)
        If Not (IsNothing(RadDatePicker1.SelectedDate)) Then
            req = Replace(req, "10/8/2012", RadDatePicker1.SelectedDate)
        End If

        If Not (IsNothing(RadDatePicker2.SelectedDate)) Then
            req = Replace(req, "10/9/2012", RadDatePicker2.SelectedDate)
        Else
            '20151103 - pab - fix error if RadDatePicker1.SelectedDate is nothing
            If Not (IsNothing(RadDatePicker1.SelectedDate)) Then
                req = Replace(req, "10/9/2012", RadDatePicker1.SelectedDate)
            Else
                req = Replace(req, "10/9/2012", DateAdd(DateInterval.Day, 90, Now).ToString("d"))
            End If
        End If


        req = Replace(req, "abc123", DrpCarrier.SelectedValue)


        req = req & " order by departuredategmtkey"


        SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        SqlDataSource1.SelectCommand = req
        SqlDataSource1.DataBind()

    End Function

    Protected Sub RadDatePicker2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePicker2.SelectedDateChanged
        updategrid()
    End Sub

    Protected Sub txtAC_TextChanged(sender As Object, e As EventArgs) Handles txtAC.TextChanged
        updategrid()
    End Sub

    Protected Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        updategrid()
    End Sub

    Protected Sub txtTrip_TextChanged(sender As Object, e As EventArgs) Handles txtTrip.TextChanged
        updategrid()
    End Sub
End Class