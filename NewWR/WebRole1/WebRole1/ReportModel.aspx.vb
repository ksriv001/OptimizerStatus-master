Imports System.Data.SqlClient


Public Class ReportModel


    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        If IsNothing(Session("carrierid")) Then Response.Redirect("login.aspx")
        If Session("carrierid") = 0 Then Response.Redirect("login.aspx")
    End Sub

    Shared Function InBetween(ByVal Start As Integer, ByVal work As String, ByVal target As String, ByVal target2 As String) As String

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


    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "update optimizerlog set modelrunid = 'xyz' where modelrunid = 'abc'"
     
        req = Replace(req, "abc", txtmodel.Text)
        req = Replace(req, "xyz", "x" & txtmodel.Text)


        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)



        If rs.State = 1 Then rs.Close()

        txtStatus.Text = "model " & txtmodel.Text & " reported"


    End Sub

    Function findactual(a As String, b As String, actype As String) As Double

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString =  ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "select top 1 * from CASFOSTripLegs where %Depart Airport ID% = 'abc' and %Arrival Airport ID% = 'def' and %Aircraft Type ID% = 'ghi' order by id desc"
        req = Replace(req, "%", Chr(34))

        req = Replace(req, "abc", a)
        req = Replace(req, "def", b)
        req = Replace(req, "ghi", actype)


        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)


        findactual = -1
        If Not rs.EOF Then

            If rs.Fields("Flight Time Actual").Value <> 0 Then findactual = (rs.Fields("Flight Time Actual").Value)
            If rs.Fields("Flight Time Actual").Value = 0 Then findactual = (rs.Fields("ete").Value)


        End If


    End Function

    Function findactualAVG(a As String, b As String, actype As String) As Double

        Dim cnoptimizerdataset As New ADODB.Connection

        If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
        If cnoptimizerdataset.State = 0 Then
            cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
            cnoptimizerdataset.Open()
        End If

        Dim rs As New ADODB.Recordset


        Dim req As String
        req = "select AVG(%FLIGHT TIME ACTUAL%) as %FLIGHT TIME AVG% , AVG(ETE) as ETEAVG from CASFOSTripLegs where %Depart Airport ID% = 'abc' and %Arrival Airport ID% = 'def' and %Aircraft Type ID% = 'ghi' AND %FLIGHT TIME ACTUAL% <> 0"
        req = Replace(req, "%", Chr(34))

        req = Replace(req, "abc", a)
        req = Replace(req, "def", b)
        req = Replace(req, "ghi", actype)


        rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)


        findactualAVG = -1
        If Not rs.EOF Then

            If Not (IsDBNull(rs.Fields("Flight Time avg").Value)) Then
                If rs.Fields("Flight Time avg").Value <> 0 Then findactualAVG = (rs.Fields("Flight Time avg").Value)
                If rs.Fields("Flight Time avg").Value = 0 Then findactualAVG = (rs.Fields("ETEAVG ").Value)
            Else
                findactualAVG = 0
            End If



        End If


    End Function





    Public Function GetMajorAirportsByLatitudeLongitude( _
       ByVal latitude As Double, _
       ByVal longitude As Double, _
       ByVal minimumRunwayLength As Integer, _
       ByVal miles As Integer, _
       ByVal count As Integer) As DataTable

        Dim oConn As SqlConnection = Nothing
        Dim oAdp As SqlDataAdapter = Nothing
        Dim oParam As SqlParameter = Nothing
        Dim dt As New DataTable

        Try
            oConn = New SqlConnection(ConnectionStringHelper.getglobalconnectionstring("OptimizerServer"))
            oAdp = New SqlDataAdapter("sp_GetMajorAirportsByLatitudeLongitudeWithinDistance", oConn)
            dt = New DataTable
            oParam = Nothing

            oAdp.SelectCommand.CommandType = CommandType.StoredProcedure

            oParam = New SqlParameter("@Latitude", SqlDbType.Float)
            oParam.Value = latitude
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@Longitude", SqlDbType.Float)
            oParam.Value = longitude
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@MinimumRunwayLength", SqlDbType.Int)
            oParam.Value = minimumRunwayLength
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@Miles", SqlDbType.Int)
            oParam.Value = miles
            oAdp.SelectCommand.Parameters.Add(oParam)

            oParam = New SqlParameter("@Count", SqlDbType.Int)
            oParam.Value = count
            oAdp.SelectCommand.Parameters.Add(oParam)

            oAdp.Fill(dt)

            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            If oConn.State = ConnectionState.Open Then
                oConn.Close()
            End If
            dt.Dispose()
            oAdp.Dispose()
            oConn.Dispose()
        End Try
    End Function


End Class