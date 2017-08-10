Imports System.Data
Imports System.Drawing
Imports Telerik.Web.UI

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")

        SqlDataSource3.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        SqlDataSource2.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")

        If IsNothing(Session("carrierid")) Then Response.Redirect("login.aspx")
        If Session("carrierid") = 0 Then Response.Redirect("login.aspx")

        If IsNothing(Session("carrierid")) Then Response.Redirect("Login.aspx", True)

        Dim rs As New ADODB.Recordset


        Dim cnsetting As New ADODB.Connection


        If cnsetting.State = 0 Then
            cnsetting.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnsetting.Open()
        End If


        '20170217 - pab - call admin calendar
        If Not IsPostBack Then
            Session("carrierid") = 100
            hlSchedule.NavigateUrl = "http://personiflyadminuat.com/FlightPlanningOpt.aspx?i=" & Session("carrierid").ToString & "&c=" & Session("cypher").ToString
            'hlSchedule.NavigateUrl = "http://localhost:2626/FlightPlanningOpt.aspx?i=100&c=" & Session("cypher").ToString
        End If

        If rs.State = 1 Then rs.Close()


        Try


            Dim req As String
            req = "SELECT count(*) as cnt FROM [OptimizerWest].[dbo].[OptimizerStatus] where [OptimizerStatus] = 'Q' and DATEDIFF ( S , [OptimizerTime] , GETUTCDATE()   )   < 90"
            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then

                Dim cw As Integer = CInt(rs.Fields("cnt").Value)
                RadRadialGauge1.Pointer.Value = CInt(rs.Fields("cnt").Value)

            End If



            If rs.State = 1 Then rs.Close()


            req = "select  count(*) as cnt from [OptimizerWest].[dbo].[OptimizerStatus]  WITH (NOLOCK)  where  DATEDIFF(mi, optimizertime,  GETDATE() )  < 10"
            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                Dim ca As Integer = CInt(rs.Fields("cnt").Value)
                RadRadialGauge2.Pointer.Value = CInt(rs.Fields("cnt").Value)
            End If



            If rs.State = 1 Then rs.Close()


            req = "select  top 1 * from [OptimizerWest].[dbo].[OptimizerRequest] WITH (NOLOCK)  order by id desc"
            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                Dim ca As Integer = DateDiff(DateInterval.Minute, rs.Fields("RequestDate").Value, Now.ToUniversalTime)
                RadRadialGauge3.Pointer.Value = ca
                Me.Label1.Text = rs.Fields("Description").Value & " by " & rs.Fields("email").Value
            End If


            If rs.State = 1 Then rs.Close()

            Dim corecount As Integer
            Dim coretime As Date
            req = "select top 1 * from CoreCounts order by updatetime desc"
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

            If Not rs.EOF Then
                corecount = rs.Fields("corecount").Value
                coretime = rs.Fields("updatetime").Value
                lbllastcommand.Text = "Last commanded " & corecount & " + 5 cores at UTC " & coretime
            End If

            If rs.State = 1 Then rs.Close()


            req = "select  count(Host_name) as [#Sessions] from  sys.dm_exec_sessions  "
            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                Dim ca As Integer = CInt(rs.Fields("#Sessions").Value)
                RadRadialGauge4.Pointer.Value = CInt(rs.Fields("#Sessions").Value)
            End If







        Catch ex As Exception

            Dim msg As String
            msg = ex.Message


        End Try


    End Sub


    'Add Session count And color code it
    'Protected Sub RadGrid3_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid3.ItemDataBound
    '    If TypeOf e.Item Is GridDataItem Then
    '        Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

    '        Dim cell As TableCell = dataItem("#Sessions")
    '        Dim itemValue As String = dataItem("#Sessions").Text
    '        Select Case CType(itemvalue, Integer)
    '            Case 0 To 3000
    '                e.Item.BackColor = Drawing.Color.LightGreen
    '            Case 3001 To 6000
    '                e.Item.BackColor = Drawing.Color.Yellow
    '            Case 60001 To 9000
    '                e.Item.BackColor = Drawing.Color.Orange
    '            Case 9001 To 20000
    '                e.Item.BackColor = Drawing.Color.Red
    '            Case Is > 20000
    '                e.Item.BackColor = Drawing.Color.Violet
    '        End Select
    '    End If
    'End Sub





End Class