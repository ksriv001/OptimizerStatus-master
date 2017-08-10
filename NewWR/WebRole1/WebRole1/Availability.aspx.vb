Imports System.Data.SqlClient

Public Class avaialability



    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            Me.txtdatefrom.Text = DateAdd(DateInterval.Day, 2, Now)
            Me.txtdateto.Text = DateAdd(DateInterval.Hour, 50, Now)

            drpcarrier.Items.Clear()

            If Not (IsNothing(Session("C"))) Then
                '20151103 - pab - fix error - Session("c") is integer on login page - Conversion from string "TMC" to type 'Double' is not valid.
                'If Session("C") = "TMC" Then
                Dim i As New ListItem
                If Session("C") = 65 Then

                    i.Text = "TMC"
                    i.Value = 65
                    drpcarrier.Items.Add(i)

                    '20151103 - pab - add other carriers
                ElseIf Session("C") = 49 Then

                    i.Text = "XO"
                    i.Value = 49
                    drpcarrier.Items.Add(i)

                ElseIf Session("C") = 100 Then

                    i.Text = "WU"
                    i.Value = 100
                    drpcarrier.Items.Add(i)

                ElseIf Session("C") = 104 Then

                    i.Text = "JLX"
                    i.Value = 104
                    drpcarrier.Items.Add(i)

                ElseIf Session("C") = 107 Then

                    i.Text = "ASI"
                    i.Value = 107
                    drpcarrier.Items.Add(i)


                ElseIf Session("C") = 108 Then

                    i.Text = "DELTA"
                    i.Value = 108
                    drpcarrier.Items.Add(i)

                End If
            Else

                '20151103 - pab - fix drop down and new carrier
                Dim i As New ListItem
                'i.Text = "XO"
                'i.Value = 49
                i = New ListItem("XO", 49)
                drpcarrier.Items.Add(i)

                i = New ListItem("TMC", 65)
                drpcarrier.Items.Add(i)

                'i.Text = "WU"
                'i.Value = 100
                i = New ListItem("WU", 100)
                drpcarrier.Items.Add(i)

                'i.Text = "JLX"
                'i.Value = 104
                i = New ListItem("JLX", 104)
                drpcarrier.Items.Add(i)

                i = New ListItem("ASI", 107)
                drpcarrier.Items.Add(i)


                i = New ListItem("DELTA", 108)
                drpcarrier.Items.Add(i)

            End If



        End If



        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")



        If Drpactype.Items.Count = 0 Then


            Dim cnoptimizerdataset As New ADODB.Connection

            If cnoptimizerdataset.State = 1 Then cnoptimizerdataset.Close()
            If cnoptimizerdataset.State = 0 Then
                cnoptimizerdataset.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDriver")
                cnoptimizerdataset.Open()
            End If

            Dim rs As New ADODB.Recordset


            Dim req As String
            req = "SELECT [aircrafttype], cnt FROM [carrieractypes] order by cnt desc "
            req = Replace(req, "%", Chr(34))



            rs.Open(req, cnoptimizerdataset, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)

            Do While Not rs.EOF

                If rs.Fields("aircrafttype").Value <> "" Then

                    Drpactype.Items.Add(rs.Fields("aircrafttype").Value)
                End If

                rs.MoveNext()

            Loop

            Drpactype.SelectedIndex = 2

        End If


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


        '   Dim ws As New net.cloudapp.aviationwebservice.WebService1

        Dim ws As New net.cloudapp.aviationwebservicewestuat.WebService1

        Dim t As Date = Now


        Dim s As String

        s = ws.OptimizeCASRepositionCost("pbaumgart@ctgi.com", "123", "False", "BJ40", "PBI", "HPN", "12/6/2015 3:58:54 PM", "12/6/2015 5:58:54 PM", "", "", "", "65", False)

        s = s


        s = ws.OptimizeCASRepositionCost("pbaumgart@ctgi.com", "123", "N", Drpactype.SelectedItem.Text.ToString.Trim, txtFrom.Text.ToString.Trim, txtTo.Text.ToString.Trim, txtdatefrom.Text.ToString.Trim, txtdateto.Text.ToString.Trim, "O", "", "", drpcarrier.SelectedValue, False)

        Me.txtStatus.Text = s & vbNewLine & "took " & DateDiff(DateInterval.Second, t, Now) & " seconds"


    End Sub

   
  
End Class