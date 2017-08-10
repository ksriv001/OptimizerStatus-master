Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")


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



        If rs.State = 1 Then rs.Close()


        Try


            Dim req As String
            req = "select  count(*) as cnt from [OptimizerWest].[dbo].[OptimizerStatus] where   DATEDIFF(mi, optimizertime,  GETDATE() )  < 10 and   [OptimizerStatus] = 'W'"
            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then

                Dim cw As Integer = CInt(rs.Fields("cnt").Value)
                RadRadialGauge1.Pointer.Value = CInt(rs.Fields("cnt").Value)

            End If



            If rs.State = 1 Then rs.Close()


            req = "select  count(*) as cnt from [OptimizerWest].[dbo].[OptimizerStatus] where  DATEDIFF(mi, optimizertime,  GETDATE() )  < 10"
            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                Dim ca As Integer = CInt(rs.Fields("cnt").Value)
                RadRadialGauge2.Pointer.Value = CInt(rs.Fields("cnt").Value)
            End If



            If rs.State = 1 Then rs.Close()


            req = "select  top 1 * from [OptimizerWest].[dbo].[OptimizerRequest] order by id desc"
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





        Catch ex As Exception

            Dim msg As String
            msg = ex.Message


        End Try


    End Sub


End Class