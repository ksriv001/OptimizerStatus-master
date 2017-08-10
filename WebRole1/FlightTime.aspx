<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlightTime.aspx.vb" Inherits="WebRole1.FlightTime" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Historical Flight Time Tool</h1>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Entry Form:</h3>
        </header>
  <table>
           <tr><td> <span class="label">From:</span></td>
          <td class="auto-style1">  <asp:TextBox ID="txtFrom" runat="server" Width="124px"></asp:TextBox>
        </td></tr>
      
       <tr><td> <span class="label">To:</span></td>
          <td class="auto-style1">  <asp:TextBox ID="txtTo" runat="server" Width="124px"></asp:TextBox>
        </td></tr>

       <tr><td> <span class="label">AC Type:</span></td>
          <td class="auto-style1">  <asp:DropDownList ID="Drpactype" runat="server" Font-Size="Larger">
              </asp:DropDownList>
        </td></tr>

       <tr><td> <span class="label">Actual Minutes:</span></td>
          <td class="auto-style1">  <asp:TextBox ID="txtActual" runat="server" Width="124px" BackColor="White" Enabled="False"></asp:TextBox>
        </td></tr>

       <tr><td> <span class="label">Avg Minutes:</span></td>
          <td class="auto-style1">  <asp:TextBox ID="txtActualAVG" runat="server" Width="124px" BackColor="White" Enabled="False"></asp:TextBox>
        </td></tr>

      <tr><td> <span class="label">DUATS Time:</span></td>
          <td class="auto-style1">  <asp:TextBox ID="txtDuatsTime" runat="server" Width="124px" BackColor="White" Enabled="False"></asp:TextBox>
        </td></tr>

      <tr><td> <span class="label">Click Here:</span></td>
          <td class="auto-style1">  <asp:LinkButton ID="LinkButton1" runat="server">Calculate</asp:LinkButton>
        </td></tr>
      
  </table>
    </section>

    <section class="contact">
        <header>
            <h3>Notes:</h3>
        </header>
    </section>

    <section class="contact">
        <header>
            <h3>
                <asp:TextBox ID="txtStatus" runat="server" Height="257px" TextMode="MultiLine" Width="1296px"></asp:TextBox>
            </h3>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </header>
    </section>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1
        {
            width: 187px;
        }
    </style>
</asp:Content>
