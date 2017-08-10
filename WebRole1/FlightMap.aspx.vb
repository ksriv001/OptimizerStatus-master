Public Class FlightMap
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ws As New coastalavtech.service.WebService1
        If Session("defaultemail") <> ws.getcypher(Session("cypher")) Then Response.Redirect("login.aspx")

    End Sub

End Class