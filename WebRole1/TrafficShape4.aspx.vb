Imports System.IO
Imports Microsoft.Security.Application

Partial Class TrafficShape4
    Inherits System.Web.UI.Page

    Public myJS As String = String.Empty
    Private _mapData As String = String.Empty
    Private _arrCount As Integer = 0
    Public _carrierid As Integer = 65
    Public cnsetting As New ADODB.Connection

    'use domestic data only
    'Private _ws As New CoastalAviationLocal.Service
    '20110929 - pab - fix web reference
    'Private _ws As New WebRole1.net.cloudapp.aviationwebservice.WebService1
    Private _ws As New WebRole1.net.cloudapp.casaviationwebserviceimport.WebService1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")


        '20101105 - pab - add code for aliases
        Dim url As String = Request.Url.ToString
        Dim host As String = Request.Url.Host
        'If _urlalias Is Nothing Or _urlalias = "" Then

        '    '20101129 - pab - force last connection to close when starting new session
        '    If cnsetting.State = 1 Then cnsetting.Close()

        '    geturlaliasandconnections(host)
        '    Session("urlalias") = _urlalias

        'End If

        'If Session("username") Is Nothing Then
        '    FormsAuthentication.RedirectToLoginPage()
        'End If

    End Sub

    'chg3614 - 20100915 - rlk - fix mapping error
    'Shared Function polyline(ByVal v As Long, ByVal h As Long, ByVal v1 As Long, ByVal h1 As Long, ByVal color As String, ByVal title As String, ByVal description As String, ByVal shapename As String) As String
    Shared Function polyline(ByVal v As Double, ByVal h As Double, ByVal v1 As Double, ByVal h1 As Double, ByVal color As String, ByVal title As String, ByVal description As String, ByVal shapename As String) As String

        'Revenue: 198,239,206 #C6EFCE
        'Dead Leg: #FFEB9C
        'Maintenance: #99CCFF
        'On Ground: #FFC7CE


        Dim colors As String
        colors = "198,239,206,1.0" '#C6EFCE
        'colors = "255,235,156,1.0" '#FFEB9C
        'colors = "153,204,255,1.0" '#99CCFF
        'colors = "255,199,206,1.0" '#FFC7CE

        'colors = "0,100,150,1.0" 'blue
        If UCase(color) = "GREEN" Then colors = "0,150,100,1.0"


        'chg3620 - 20100920 - bd - fix javascript error
        'polyline = "var shape2= new VEShape(VEShapeType.Polyline, [ new VELatLong(" & v & ", " & h & "), new VELatLong(" & v1 & ", " & h1 & ") ]);" & _
        '"shape2.SetTitle('" & title & "');" & _
        '"shape2.SetDescription('" & description & "');" & _
        ' "shape2.SetLineColor(new VEColor(" & colors & "));" & _
        ' "var icon = ""<img src='Images/starting_point_red.gif' alt='' title=''/>"";" & _
        '"var spec = new VECustomIconSpecification();" & _
        '"spec.CustomHTML = icon;" & _
        '"shape2.SetCustomIcon(spec);" & _
        ' "map.AddShape(shape2);"
        polyline = "var shape2= new VEShape(VEShapeType.Polyline, [ new VELatLong(" & v & ", " & h & "), new VELatLong(" & v1 & ", " & h1 & ") ]);" & _
        "shape2.SetTitle(" & AntiXss.JavaScriptEncode(title) & ");" & _
        "shape2.SetDescription(" & AntiXss.JavaScriptEncode(description) & ");" & _
         "shape2.SetLineColor(new VEColor(" & colors & "));" & _
         "var icon = ""<img src='Images/starting_point_red.gif' alt='' title=''/>"";" & _
        "var spec = new VECustomIconSpecification();" & _
        "spec.CustomHTML = icon;" & _
        "shape2.SetCustomIcon(spec);" & _
         "map.AddShape(shape2);"



        polyline = Replace(polyline, "shape2", shapename)






    End Function


    'chg3614 - 20100915 - rlk - fix mapping error
    'Shared Function pushpin(ByVal v As Long, ByVal h As Long, ByVal color As String, ByVal title As String, ByVal description As String, ByVal shapename As String) As String
    Shared Function pushpin(ByVal v As Double, ByVal h As Double, ByVal color As String, ByVal title As String, ByVal description As String, ByVal shapename As String) As String


        Dim colors As String
        colors = "198,239,206,1.0" 'blue
        If UCase(color) = "GREEN" Then colors = "0,150,100,1.0"

        Dim myHtml As String = "</br></br>Click <a href=\'http://www.airnav.com/airport/KHTS\' target=\'_blank\'>here</a> for more info"


        'chg3620 - 20100920 - bd - fix javascript error
        'pushpin = "var shape2= new VEShape(VEShapeType.Pushpin, new VELatLong(" & v & ", " & h & "));" & _
        '"shape2.SetTitle('" & title & "');" & _
        '"shape2.SetDescription('" & description & myHtml & "');" & _
        '"shape2.SetLineColor(new VEColor(" & colors & "));" & _
        '"var icon = ""<table border='0' cellpadding='0' cellspacing='0'><tr><td><img src='Images/airport_blue.gif' alt='' title=''/></td><td><span style='font-size:x-small;font-weight:bold;text-decoration:none;font-family:tahoma;color:Black;border:solid 0px Black;background-color:White;padding:1px;' onmouseover='this.style.cursor=&quot;pointer&quot;;' onmouseout='this.style.cursor=&quot;default&quot;;'>" & title & "</span></td></tr></table>"";" & _
        '"var spec = new VECustomIconSpecification();" & _
        '"spec.CustomHTML = icon;" & _
        '"shape2.SetCustomIcon(spec);" & _
        '"map.AddShape(shape2);"
        pushpin = "var shape2= new VEShape(VEShapeType.Pushpin, new VELatLong(" & v & ", " & h & "));" & _
        "shape2.SetTitle(" & AntiXss.JavaScriptEncode(title) & ");" & _
        "shape2.SetDescription(" & AntiXss.JavaScriptEncode(description & myHtml) & ");" & _
        "shape2.SetLineColor(new VEColor(" & colors & "));" & _
        "var icon = ""<table border='0' cellpadding='0' cellspacing='0'><tr><td><img src='Images/airport_blue.gif' alt='' title=''/></td><td><span style='font-size:x-small;font-weight:bold;text-decoration:none;font-family:tahoma;color:Black;border:solid 0px Black;background-color:White;padding:1px;' onmouseover='this.style.cursor=&quot;pointer&quot;;' onmouseout='this.style.cursor=&quot;default&quot;;'>" & AntiXss.JavaScriptEncode(title) & "</span></td></tr></table>"";" & _
        "var spec = new VECustomIconSpecification();" & _
        "spec.CustomHTML = icon;" & _
        "shape2.SetCustomIcon(spec);" & _
        "map.AddShape(shape2);"


        pushpin = Replace(pushpin, "KHTS", title)
        pushpin = Replace(pushpin, "shape2", shapename)

        '"var icon = ""<div style='font-size:12px;font-weight:bold;border:solid 2px Black;background-color:Aqua;width:50px;'>Custom</div>"";" & _
        '        "var spec = new VECustomIconSpecification();" & _
        '        "spec.CustomHTML = icon;" & _
        '        "spec.Image = 'http://www.geocities.com/cmpoet/Airplane1.png'" & _
        '        "shape2.SetCustomIcon(spec);" & _


    End Function

    Private Function pushpinairport(ByVal airport As String, ByVal color As String, ByVal title As String, ByVal description As String, ByVal shapename As String) As String


        'Dim ws As New AviationWebService1_10.WebService1 'connect_it_coastal.Service

        Dim fromairport As String
        fromairport = _ws.AirportLongLat("pbaumgart@ctgi.com", 123, _carrierid, airport)


        Dim v, h As String
        v = InBetween(1, fromairport, "lat<", ">")
        h = InBetween(1, fromairport, "long<", ">")


        Dim colors As String
        colors = "0,100,150,1.0" 'blue
        If UCase(color) = "GREEN" Then colors = "0,150,100,1.0"


        'chg3620 - 20100920 - bd - fix javascript error
        'pushpinairport = "var shape2= new VEShape(VEShapeType.Pushpin, new VELatLong(" & v & ", " & h & "));" & _
        '"shape2.SetTitle('" & title & "');" & _
        '"shape2.SetDescription('" & description & "');" & _
        ' "shape2.SetLineColor(new VEColor(" & colors & "));" & _
        ' "map.AddShape(shape2);"
        pushpinairport = "var shape2= new VEShape(VEShapeType.Pushpin, new VELatLong(" & v & ", " & h & "));" & _
        "shape2.SetTitle(" & AntiXss.JavaScriptEncode(title) & ");" & _
        "shape2.SetDescription(" & AntiXss.JavaScriptEncode(description) & ");" & _
         "shape2.SetLineColor(new VEColor(" & colors & "));" & _
         "map.AddShape(shape2);"



        pushpinairport = Replace(pushpinairport, "shape2", shapename)




    End Function


    Private Function InBetween(ByVal Start As Integer, ByVal work As String, ByVal target As String, ByVal target2 As String) As String

        Dim pos As Integer
        Dim pos2 As Integer
        Dim work1 As String


        If Start = 0 Then
            InBetween = ""
            Exit Function
        End If

        pos = InStr(Start, work, target, vbTextCompare)

        pos = pos + Len(target)
        pos2 = InStr(pos, work, target2, vbTextCompare)

        If pos = 0 + Len(target) Or pos2 = 0 Then
            InBetween = ""
            Exit Function
        End If


        work1 = Mid(work, pos, pos2 - pos)

        InBetween = work1

    End Function


    Private Function graphpath(ByVal fromapt As String, ByVal toapt As String, ByVal color As String, ByVal type As String, ByVal tailNumber As String) As String


        'Dim ws As New AviationWebService1_10.WebService1 'connect_it_coastal.Service


        Dim fromairport As String
        ' fromairport = _ws.AirportLongLat(fromapt)
        Dim toairport As String
        'toairport = _ws.AirportLongLat(toapt)


        '20110929 - pab - fix web referencen
        Dim ws As New net.cloudapp.casaviationwebserviceimport.WebService1


        '  Dim fromairport As String
        fromairport = ws.AirportLongLat("pbaumgart@ctgi.com", 123, _carrierid, Right(fromapt, 3))
        ' Dim toairport As String
        toairport = ws.AirportLongLat("pbaumgart@ctgi.com", 123, _carrierid, Right(toapt, 3))





        Dim distance As String
        'distance = _ws.getdistance(fromapt, toapt)


        Dim d As Integer
        ' d = CInt(getdistance(_origAirportCode, _destAirportCode))
        '  Dim oMapping As New Mapping
        d = ws.GetRoundEarthDistanceBetweenLocations("pbaumgart@ctgi.com", "123", _carrierid, fromapt, toapt)
        distance = CStr(d)


        Dim title As String
        title = (fromapt & "-" & toapt)
        '20110214 - pab - flight type changes
        If type = "D" Then title = "Empty Leg " & title
        If type = "R" Then title = "Revenue Leg " & title
        If type = "M" Then title = "Maint. Leg " & title
        If type = "O" Then title = "Ops Leg " & title
        'If type = "CF" Then title = "Empty Leg " & title
        'If type = "CL" Then title = "Revenue Leg " & title
        'If type = "MX" Then title = "Maint. Leg " & title
        'If type = "OT" Then title = "Ops Leg " & title

        'for leg descriptions, add aircraft
        Dim description As String = distance & " miles<br/><br/>" & tailNumber


        graphpath = ""



        If fromairport <> "X" And toairport <> "X" Then
            graphpath = graphpath & polyline(InBetween(1, fromairport, "<Latitude>", "</Latitude>"), InBetween(1, fromairport, "<Longitude>", "</Longitude>"), InBetween(1, toairport, "<Latitude>", "</Latitude>"), InBetween(1, toairport, "<Longitude>", "</Longitude>"), color, title, description, "line1") & vbCr & vbLf
        End If

        ' jscriptcode = jscriptcode & polyline(46.5, -122.5, 50.5, -112.3, "blue", "Line2", "Line1Test", "line2")


        If fromairport <> "X" Then graphpath = graphpath & pushpin(InBetween(1, fromairport, "<Latitude>", "</Latitude>"), InBetween(1, fromairport, "<Longitude>", "</Longitude>"), color, fromapt, (fromapt), "point1") & vbCr & vbLf

        If toairport <> "X" Then graphpath = graphpath & pushpin(InBetween(1, toairport, "<Latitude>", "</Latitude>"), InBetween(1, toairport, "<Longitude>", "</Longitude>"), color, toapt, (toapt), "point2") & vbCr & vbLf

        Dim lat As String = InBetween(1, fromairport, "<Latitude>", "</Latitude>")
        Dim lon As String = InBetween(1, fromairport, "<Longitude>", "</Longitude>")

        If lat.Trim.Length > 0 And lon.Trim.Length > 0 Then

            '_mapData &= "vll = new VELatLong(" & InBetween(1, toairport, "lat<", ">") & ", " & InBetween(1, toairport, "long<", ">") & ");" & ControlChars.CrLf

            _mapData &= "vll = new VELatLong(" & lat & ", " & lon & ");" & ControlChars.CrLf

            _mapData &= "latLongArr[" & _arrCount.ToString & "] = vll;" & ControlChars.CrLf

            _arrCount += 1
        End If

        lat = InBetween(1, toairport, "<Latitude>", "</Latitude>")
        lon = InBetween(1, toairport, "<Longitude>", "</Longitude>")

        If lat.Trim.Length > 0 And lon.Trim.Length > 0 Then

            '_mapData &= "vll = new VELatLong(" & InBetween(1, toairport, "lat<", ">") & ", " & InBetween(1, toairport, "long<", ">") & ");" & ControlChars.CrLf

            _mapData &= "vll = new VELatLong(" & lat & ", " & lon & ");" & ControlChars.CrLf

            _mapData &= "latLongArr[" & _arrCount.ToString & "] = vll;" & ControlChars.CrLf

            _arrCount += 1
        End If
    End Function

    Protected Sub cmdFlightstable_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cmdFlightstable.Click

        '    '  Dim selectedDate As DateTime = CDate(Me.Calendar1.SelectedDate.ToString("MM/dd/yyyy 00:00:00"))

        '    'If CDate(selectedDate.ToString("MM/dd/yyyy 00:00:00")) <> CDate(Now.ToString("MM/dd/yyyy 00:00:00")) Then
        '    '    Me.lbPreviousDay.Enabled = True
        '    'Else : Me.lbPreviousDay.Enabled = False
        '    'End If

        _mapData = "var latLongArr = new Array();" '(" & dt.Rows.Count.ToString & ");" & ControlChars.CrLf

        '20100222 - pab - use global shared connection
        'Dim cn As New ADODB.Connection

        Dim rs As New ADODB.Recordset

        '20100222 - pab - use global shared connection
        'If cn.State = 1 Then cn.Close()
        'If cn.State = 0 Then
        '    cn.ConnectionString = "PROVIDER=MSDASQL;driver={SQL Server};server=(local);uid=sa;password=CoastalPass1;database=" & xonfigurationmanager.AppSettings("optimizerDatabase")
        '    ' cn.ConnectionString = "server=(local);uid=cmp;password=coastal;database=airtaxi"""
        '    cn.Open()
        'End If
        If cnsetting.State = 0 Then
            cnsetting.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnsetting.Open()
        End If



        If rs.State = 1 Then rs.Close()





        Dim req As String
        req = "select top 5 %departure icao% , %arrival icao%, %departure icao% +  %arrival icao%, count(*) as count from casfostriplegs where %aircraft type id% = 'BJ40' and %departure icao% <> %arrival icao% group by %departure icao% + %arrival icao%, %departure icao% , %arrival icao% order by count desc"
        req = Replace(req, "%", Chr(34))
        '20100222 - pab - use global shared connection
        'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
        rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)





        Dim Registration As String

        Dim DepartureAirport As String

        Dim ArrivalAirport As String

        Dim DepartureTime As String

        Dim ArrivalTime As String

        Dim FlightType As String

        Dim Status As String

        Dim FlightDetail As String

        Dim ModelRun As String

        Dim dist As String



        Dim jscriptcode As String = ""

        lblmsg.Visible = True
        If rs.EOF Then Me.lblmsg.Text = "No data " 'for " & selectedDate.ToString("d")


        While Not rs.EOF



            On Error Resume Next





            'table flights

            '[AircraftID] [int] NULL,

            '[DepartureAirport] [varchar](10) NULL,

            '[ArrivalAirport] [varchar](10) NULL,

            '[DepartureTime] [datetime] NULL,

            '[ArrivalTime] [datetime] NULL,

            '[FlightType] [varchar](1) NULL,

            '[Status] [varchar](10) NULL,

            '[FlightDetail] [int] NOT NULL,

            '[ModelRun] [varchar](50) NULL,

            '[Distance] [int] NULL,

            '[AircraftFailed] [bit] NOT NULL CONSTRAINT [DF_Flights_AircraftFailed]  DEFAULT ((0)),

            '[AircraftFailedBy] [int] NULL,

            '[AircraftFailedOnUTC] [datetime] NULL,







            'If Not (IsDBNull(rs.Fields("Registration"))) Then Registration = rs.Fields("Registration").Value

            If Not (IsDBNull(rs.Fields("Departure ICAO"))) Then DepartureAirport = rs.Fields("Departure ICAO").Value

            If Not (IsDBNull(rs.Fields("Arrival ICAO"))) Then ArrivalAirport = rs.Fields("Arrival ICAO").Value

            '  If Not (IsDBNull(rs.Fields("DepartureTime"))) Then DepartureTime = rs.Fields("DepartureTime").Value

            ' If Not (IsDBNull(rs.Fields("ArrivalTime"))) Then ArrivalTime = rs.Fields("ArrivalTime").Value

            '  If Not (IsDBNull(rs.Fields("FlightType"))) Then FlightType = rs.Fields("FlightType").Value

            '  If Not (IsDBNull(rs.Fields("Status"))) Then Status = rs.Fields("Status").Value

            ' If Not (IsDBNull(rs.Fields("FlightDetail"))) Then FlightDetail = rs.Fields("FlightDetail").Value

            '  If Not (IsDBNull(rs.Fields("ModelRun"))) Then ModelRun = rs.Fields("ModelRun").Value

            ' If Not (IsDBNull(rs.Fields("distance"))) Then dist = rs.Fields("distance").Value



            On Error GoTo 0



            Dim color As String


            color = "GREEN"
            FlightType = "R"
            '20110214 - pab - flight type changes
            If Trim(FlightType) = "D" Then color = "RED"
            If Trim(FlightType) = "R" Then color = "GREEN"
            'If Trim(FlightType) = "CF" Then color = "RED"
            'If Trim(FlightType) = "CL" Then color = "GREEN"



            jscriptcode = jscriptcode & graphpath(DepartureAirport, ArrivalAirport, color, Trim(FlightType), Registration)





            rs.MoveNext()

        End While






        If jscriptcode <> "" Then


            _mapData &= "map.SetMapView(latLongArr);" & ControlChars.CrLf

        End If


        myJS = jscriptcode + " " + _mapData

        rs.Close()


    End Sub

    'Protected Sub lbPreviousDay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPreviousDay.Click
    '    Me.Calendar1.SelectedDate = DateAdd(DateInterval.Day, -1, Me.Calendar1.SelectedDate)
    '    cmdFlightstable_Click(Nothing, Nothing)
    'End Sub

    'Protected Sub lbNextDay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbNextDay.Click
    '    Me.Calendar1.SelectedDate = DateAdd(DateInterval.Day, 1, Me.Calendar1.SelectedDate)
    '    cmdFlightstable_Click(Nothing, Nothing)
    'End Sub

    Protected Sub bttnGoToDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttnGoToDate.Click
        _mapData = ""
        Me.myJS = ""


        cmdFlightstable_Click(Nothing, Nothing)
    End Sub

End Class
