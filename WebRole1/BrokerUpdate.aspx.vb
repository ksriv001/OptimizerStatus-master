Imports System.IO

Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration
Imports Telerik.Web.UI.Calendar
Public Class BrokerUpdate
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")

    End Sub



    Protected Sub BKRUpdate_Click(sender As Object, e As EventArgs) Handles BKRUpdate.Click

        Dim u As String
        Dim RegNo As String
        Dim OperatorName As String
        u = ""
        RegNo = ""
        OperatorName = ""

        RegNo = BKR_From.Text
        OperatorName = BKR_To.Text

        u = "UPDATE Aircraft SET Aircraft.Operator = 't1' where Registration = 't2'"

        u = Replace(u, "t2", RegNo)
        u = Replace(u, "t1", OperatorName)



        SqlDataSource1.ConnectionString = ConnectionStringHelper.getglobalconnectionstring("OptimizerDataSource")

        Dim con As SqlConnection = New SqlConnection(SqlDataSource1.ConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(u, con)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()









    End Sub

    Protected Sub BKR_To_TextChanged(sender As Object, e As EventArgs) Handles BKR_To.TextChanged

    End Sub
End Class