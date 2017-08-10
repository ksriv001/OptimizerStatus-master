<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportModel.aspx.vb" Inherits="WebRole1.ReportModel" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Report Model Tool</h1>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Entry Form:</h3>
        </header>
  <table>
           <tr><td> Model<span class="label">:</span></td>
          <td class="auto-style1">  <asp:TextBox ID="txtmodel" runat="server" Width="193px"></asp:TextBox>
        </td></tr>
      
       <tr><td> &nbsp;</td>
          <td class="auto-style1">  &nbsp;</td></tr>

       <tr><td> &nbsp;</td>
          <td class="auto-style1">  &nbsp;</td></tr>

       <tr><td> &nbsp;</td>
          <td class="auto-style1">  &nbsp;</td></tr>

       <tr><td> &nbsp;</td>
          <td class="auto-style1">  &nbsp;</td></tr>

      <tr><td> &nbsp;</td>
          <td class="auto-style1">  &nbsp;</td></tr>

      <tr><td> <span class="label">Click Here:</span></td>
          <td class="auto-style1">  <asp:LinkButton ID="LinkButton1" runat="server">Report</asp:LinkButton>
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
                <asp:TextBox ID="txtStatus" runat="server" Height="43px" TextMode="MultiLine" Width="856px"></asp:TextBox>
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
