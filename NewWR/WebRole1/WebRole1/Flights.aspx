
<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Flights.aspx.vb" Inherits="WebRole1.About" %><%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>




    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <hgroup class="title">
        <h1>&nbsp;</h1>
    </hgroup>

    <article>
        Carrier: <asp:DropDownList ID="DrpCarrier" runat="server" AutoPostBack="True">
             <asp:ListItem Value="65">TMC</asp:ListItem>
             <asp:ListItem Selected="True" Value="104">JLX</asp:ListItem>
             <asp:ListItem Value="100">WU</asp:ListItem>
             <asp:ListItem Value="49">XO</asp:ListItem>
             <asp:ListItem Value="107">ASI</asp:ListItem>
             <asp:ListItem Value="108">Delta</asp:ListItem>
            
         </asp:DropDownList>
          &nbsp;
        <asp:CheckBox ID="chkHistorical" runat="server" Text="Historical" />
       &nbsp;
       From:  <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Culture="en-US" HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." WrapperTableSummary="Table holding date picker control for selection of dates." AutoPostBack="True">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" autopostback="True"></DateInput>
           
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>

          
      To:  <telerik:RadDatePicker ID="RadDatePicker2" Runat="server" Culture="en-US" HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." WrapperTableSummary="Table holding date picker control for selection of dates." AutoPostBack="True">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" autopostback="True"></DateInput>
           
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>


       Aircraft: <asp:TextBox ID="txtAC" runat="server" AutoPostBack="True" Width="52px"></asp:TextBox>
      
        
        Trip: <asp:TextBox ID="txtTrip" runat="server" AutoPostBack="True" Width="61px"></asp:TextBox>

        &nbsp;&nbsp;
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
      


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="tripnumber" HeaderText="tripnumber" SortExpression="tripnumber" />
                <asp:BoundField DataField="AircraftID" HeaderText="AircraftID" SortExpression="AircraftID" />
                <asp:BoundField DataField="aircrafttype" HeaderText="aircrafttype" SortExpression="aircrafttype" />
                <asp:BoundField DataField="carrierid" HeaderText="carrierid" SortExpression="carrierid" />
                <asp:BoundField DataField="departureairporticao" HeaderText="departureairporticao" SortExpression="departureairporticao" />
                <asp:BoundField DataField="arrivalairporticao" HeaderText="arrivalairporticao" SortExpression="arrivalairporticao" />
                <asp:BoundField DataField="departuredategmt" HeaderText="departuredategmt" SortExpression="departuredategmt" />
                <asp:BoundField DataField="departuretimegmt" HeaderText="departuretimegmt" SortExpression="departuretimegmt" />
                <asp:BoundField DataField="flighttime" HeaderText="flighttime" SortExpression="flighttime" />
                <asp:BoundField DataField="nauticalmiles" HeaderText="nauticalmiles" SortExpression="nauticalmiles" />
                <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />
                <asp:BoundField DataField="deadhead" HeaderText="deadhead" SortExpression="deadhead" />
                <asp:BoundField DataField="paxcount" HeaderText="paxcount" SortExpression="paxcount" />
                <asp:BoundField DataField="legtypecode" HeaderText="legtypecode" SortExpression="legtypecode" />
                <asp:BoundField DataField="legratecode" HeaderText="legratecode" SortExpression="legratecode" />
                <asp:BoundField DataField="legpurposecode" HeaderText="legpurposecode" SortExpression="legpurposecode" />
                <asp:BoundField DataField="tripstatus" HeaderText="tripstatus" SortExpression="tripstatus" />
                <asp:BoundField DataField="legstate" HeaderText="legstate" SortExpression="legstate" />
            </Columns>
        </asp:GridView>
    </article>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"  SelectCommand="SELECT 	tripnumber, AircraftID,  aircrafttype, carrierid, departureairporticao, arrivalairporticao, departuredategmt, departuretimegmt, flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate   FROM [FOSFlights] where departuredate = '10/8/2012' and session = '2012-10-08 14:20:40.000'"></asp:SqlDataSource>
   <%-- <aside>
        <h3>Aside Title</h3>
        <p>        
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>--%>
</asp:Content>