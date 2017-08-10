Public Class ModelDebug
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load



        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")


        SqlDataSource2.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")
        SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")

        If IsNothing(Session("carrierid")) Then Response.Redirect("login.aspx")
        If Session("carrierid") = 0 Then Response.Redirect("login.aspx")

        If IsNothing(Session("carrierid")) Then Response.Redirect("Login.aspx", True)

    End Sub

    Protected Sub cmdModelReview_Click(sender As Object, e As EventArgs) Handles cmdModelReview.Click


        Dim rs As New ADODB.Recordset


        Dim cnsetting As New ADODB.Connection


        If cnsetting.State = 0 Then
            cnsetting.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnsetting.Open()
        End If



        If rs.State = 1 Then rs.Close()


        Try


            Dim req As String
            req = "select  count(*) as cnt FROM [OptimizerWest].[dbo].[sys_log] where CustomRunNumber = 3716  And message Like '%timeout%'  "


            req = Replace(req, "3716", Me.txtModelNumber.Text)


            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then

                Dim cw As Integer = CInt(rs.Fields("cnt").Value)
                RadRadialGauge1.Pointer.Value = CInt(rs.Fields("cnt").Value)

            End If



            If rs.State = 1 Then rs.Close()




            req = "Select  count(*) As cnt  FROM [OptimizerWest].[dbo].[OptimizerLog] where customrunnumber = 3716"
            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

            req = Replace(req, "3716", Me.txtModelNumber.Text)

            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                Dim ca As Integer = CInt(rs.Fields("cnt").Value)
                RadRadialGauge2.Pointer.Value = CInt(rs.Fields("cnt").Value)
            End If



            SqlDataSource2.SelectCommand = "Select * FROM [OptimizerWest].[dbo].[sys_log] where CustomRunNumber = " & Me.txtModelNumber.Text



            If rs.State = 1 Then rs.Close()


            req = "Select  count(*) As cnt  FROM [OptimizerWest].[dbo].[sys_log] where CustomRunNumber = 3716"
            req = Replace(req, "3716", Me.txtModelNumber.Text)


            '20100222 - pab - use global shared connection
            'rs.Open(req, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            rs.Open(req, cnsetting, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                Dim ca As Integer = CInt(rs.Fields("cnt").Value)
                RadRadialGauge3.Pointer.Value = ca

            End If


            If rs.State = 1 Then rs.Close()






        Catch ex As Exception

            Dim msg As String
            msg = ex.Message


        End Try




    End Sub
End Class