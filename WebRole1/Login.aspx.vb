
Public Class Loginform

    Inherits System.Web.UI.Page

    'Private session("carrierid") As Integer = 0


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then
                'Check if the browser support cookies
                If Request.Browser.Cookies Then
                    'Check if the cookies with name PBLOGIN exist on user's machine
                    If Request.Cookies("CASLOGIN") IsNot Nothing Then
                        'Pass the user name and password to the VerifyLogin method

                        If Request.Cookies("CASLOGIN")("UNAME").ToString() <> "" Then
                            If Request.Cookies("CASLOGIN")("UNAME") IsNot Nothing Then

                                UserName.Text = Request.Cookies("CASLOGIN")("UNAME").ToString()
                                '  Me.txtEmail2.Text = Request.Cookies("CASOPTIMIZERLOGIN")("UNAME").ToString()
                                '  Me.Session("email") = Request.Cookies("CASOPTIMIZERLOGIN")("UNAME").ToString()
                            End If
                        End If

                        If Request.Cookies("CASLOGIN")("UPASS") IsNot Nothing Then

                            If Request.Cookies("CASLOGIN")("UPASS").ToString() <> "" Then
                                '     Me.txtPassword.Text = Request.Cookies("CASOPTIMIZERLOGIN")("UPASS").ToString()
                                Dim p As String
                                p = Request.Cookies("CASLOGIN")("UPASS").ToString()
                                Password.Text = p

                            End If

                        End If


                        If UserName.Text <> "" Then
                            If Password.Text <> "" Then
                                Button1_Click(Nothing, Nothing)
                            End If
                        End If


                        'If Me.txtEmail2.Text.Trim <> "" Then ' Then
                        '    Session("email") = Me.txtEmail2.Text

                        '  '  Response.Redirect("login.aspx?email=" & Me.txtEmail2.Text)

                        'End If
                    End If
                End If
            End If
        Catch

            ' Response.Redirect("login.aspx")'?email=" & Me.txtEmail2.Text)
        End Try


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim da As New DataAccess

        Dim u, p As String
        u = UserName.Text
        p = Password.Text




        If RememberMe.Checked = True Then
            If UserName.Text <> "" Then
                If Password.Text <> "" Then
                    If (Request.Browser.Cookies) Then
                        If (Request.Cookies("CASLOGIN") Is Nothing) Then
                            Response.Cookies("CASLOGIN").Expires = DateTime.Now.AddDays(60)


                            Response.Cookies("CASLOGIN").Item("UNAME") = UserName.Text
                            'Write password to the cookie
                            Response.Cookies("CASLOGIN").Item("UPASS") = Password.Text

                        Else
                            Response.Cookies("CASLOGIN").Item("UNAME") = UserName.Text
                            'Write password to the cookie
                            Response.Cookies("CASLOGIN").Item("UPASS") = Password.Text
                        End If

                    End If
                End If
            End If
        End If


        Session.Timeout = 24 * 60 * 10


        FailureText.Text = "Checking Password"
        Session("carrierid") = 0


        If UserName.Text = "Ted" Then
            If Password.Text = "XO!23" Then
                Session("carrierid") = 49
            End If
        End If



        If LCase(UserName.Text) = "dhackett@coastalaviationsoftware.com" Then
            '20170331 - pab - remove ucase 
            'If UCase(Password.Text) = "234Gulfstream" Then
            If Password.Text = "234Gulfstream" Then
                Session("defaultemail") = "dhackett@coastalaviationsoftware.com"
                Session("carrierid") = 49
            End If
        End If

        If LCase(UserName.Text) = "rkane@coastalaviationsoftware.com" Then
            If UCase(Password.Text) = "XO!23" Then
                Session("defaultemail") = "rkane@coastalaviationsoftware.com"
                Session("carrierid") = 49
            End If
        End If



        'If LCase(UserName.Text) = "dhackett@coastalaviationsoftware.com" Then
        '    If UCase(Password.Text) = "TMC!23" Then
        '        Session("defaultemail") = "dhackett@coastalaviationsoftware.com"
        '        Session("carrierid") = 65
        '    End If
        'End If

        If LCase(UserName.Text) = "rkane@coastalaviationsoftware.com" Then
            If UCase(Password.Text) = "TMC!23" Then
                Session("defaultemail") = "rkane@coastalaviationsoftware.com"
                Session("carrierid") = 65
            End If
        End If


        If LCase(UserName.Text) = "rk" Then
            If UCase(Password.Text) = "TMC" Then
                Session("defaultemail") = "rkane@coastalaviationsoftware.com"
                Session("carrierid") = 65
            End If
        End If

        If LCase(UserName.Text) = "rk" Then
            If UCase(Password.Text) = "XO" Then
                Session("defaultemail") = "rkane@coastalaviationsoftware.com"
                Session("carrierid") = 49
            End If
        End If




        'If LCase(UserName.Text) = "rkodesh@xojet.com" Then
        '    If UCase(Password.Text) = "!CL30" Then
        '        session("defaultemail") = "rkodesh@xojet.com"
        '        session("carrierid") = 49
        '    End If
        'End If


        'If LCase(UserName.Text) = "tbotimer@xojet.com" Then
        '    If UCase(Password.Text) = "!C750" Then
        '        session("defaultemail") = "tbotimer@xojet.com"
        '        session("carrierid") = 49
        '    End If
        'End If



        'If UserName.Text = "emoore@tmcjets.com" Then
        '    If Password.Text = "BJ40!23" Then
        '        session("defaultemail") = "emoore@tmcjets.com"
        '        session("carrierid") = 65
        '    End If
        'End If


        'If UserName.Text = "srobbins@tmcjets.com" Then
        '    If Password.Text = "H850!23" Then
        '        session("defaultemail") = "srobbins@tmcjets.com"
        '        session("carrierid") = 65
        '    End If
        'End If


        'rk 8.31.13
        '20170120 - pab - kyle now working with us
        'If UserName.Text = "kshort@tmcjets.com" Then
        '    If Password.Text = "Hawker!23" Then
        '        Session("defaultemail") = "kshort@tmcjets.com"
        '        Session("carrierid") = 65
        '        Session("c") = 65
        '    End If
        'End If
        If UserName.Text.ToLower = "kyle" Then
            Dim dt As DataTable = da.GetUserPBNoCarrier(u, p)
            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    If p = dt.Rows(0).Item("UserPW") Then
                        Session("defaultemail") = dt.Rows(0).Item("useremail")
                        Session("carrierid") = dt.Rows(0).Item("CarrierID")
                        Session("c") = dt.Rows(0).Item("CarrierID")
                    End If
                End If
            End If
        End If




        'If UserName.Text = "cschau@tmcjets.com" Then
        '    If Password.Text = "H80H!23" Then
        '        Session("defaultemail") = "cschau@tmcjets.com"
        '        Session("carrierid") = 65
        '        Session("c") = 65
        '    End If
        'End If


        'If UserName.Text = "rbrennan@tmcjets.com" Then
        '    If Password.Text = "H80H!23" Then
        '        Session("defaultemail") = "rbrennan@tmcjets.com"
        '        Session("carrierid") = 65
        '        Session("c") = 65
        '    End If
        'End If


        'If UserName.Text = "demo@cas.com" Then
        '    If Password.Text = "demo" Then
        '        session("defaultemail") = "demo@cas.com"
        '        session("carrierid") = 65
        '    End If
        'End If


        If Session("carrierid") = 0 Then
            FailureText.Text = "Invalid password or user id"

            Exit Sub
        End If




        Dim ws As New coastalavtech.service.WebService1
        Session("cypher") = ws.createcypher(Session("defaultemail"))

        Dim s As String = Session("cypher").ToString

        'rk 7/31/2013 bump up session timeout.
        Session.Timeout = 9999

        Session("carrierid") = Session("carrierid")

        If Session("carrierid") <> 0 Then
            FailureText.Text = "Password Accepted"
            Response.Redirect("default.aspx", False)
            Exit Sub
        End If




    End Sub

    Private Sub RegisterHyperLink_Click(sender As Object, e As EventArgs)
        FailureText.Text = "Launch Optimizer"
        Response.Redirect("Default.aspx", False)

    End Sub


End Class