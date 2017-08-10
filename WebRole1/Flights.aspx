
<%@ Page Title="Flight Status" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Flights.aspx.vb" Inherits="WebRole1.About" %><%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>




    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <hgroup class="title">
        <h1>&nbsp;</h1>
    </hgroup>

    <article>
        Carrier: <asp:DropDownList ID="DrpCarrier" runat="server">
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
       From:  <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Culture="en-US">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
            </DateInput>
           
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>

          
      To:  <telerik:RadDatePicker ID="RadDatePicker2" Runat="server" Culture="en-US">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
            </DateInput>
           
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>


       Aircraft: <asp:TextBox ID="txtAC" runat="server"   Width="52px"></asp:TextBox>
      
        
        Trip: <asp:TextBox ID="txtTrip" runat="server"   Width="61px"></asp:TextBox>

        &nbsp;&nbsp;
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
      


        Exclude Cancel
        <asp:CheckBox ID="CHKCancel" runat="server" Checked="True" />

         Exclude Stale
        <asp:CheckBox ID="CHKstale" runat="server" Checked="True" />



        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="FlightsSQL" runat="server" Text="Label"></asp:Label>



        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>

                <asp:BoundField DataField="RequesterName" HeaderText="Requester Name"   SortExpression="RequesterName"   ItemStyle-Wrap="False" >
<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="quotedtotalcost" HeaderText="quoted total cost"     SortExpression="quotedtotalcost"   ItemStyle-Wrap="False" DataFormatString="{0:C}" >

<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                 <asp:BoundField DataField="casupdate" HeaderText="CAS Update"   SortExpression="casupdate"   ItemStyle-Wrap="False" >
<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tripnumber" HeaderText="Trip" SortExpression="tripnumber" />
                <asp:BoundField DataField="AircraftID" HeaderText="Aircraft ID" SortExpression="AircraftID" />
                <asp:BoundField DataField="aircrafttype" HeaderText="Type" SortExpression="aircrafttype" />
               
                <asp:BoundField DataField="departureairporticao" HeaderText="A " SortExpression="departureairporticao" />
                <asp:BoundField DataField="arrivalairporticao" HeaderText="B  " SortExpression="arrivalairporticao" />
                <asp:BoundField DataField="ddgmt" HeaderText="DDGMT" SortExpression="ddgmt"  ItemStyle-Wrap="False"  >
<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="adgmt" HeaderText="ADMGT" SortExpression="adgmt"  ItemStyle-Wrap="False"  >
<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="flighttime" HeaderText="Minutes" SortExpression="flighttime" />
                <asp:BoundField DataField="nauticalmiles" HeaderText="Nautical" SortExpression="nauticalmiles" />
               
                <asp:BoundField DataField="deadhead" HeaderText="DH" SortExpression="deadhead" />
                <asp:BoundField DataField="paxcount" HeaderText="Pax" SortExpression="paxcount" />
                <asp:BoundField DataField="legtypecode" HeaderText="Type" SortExpression="legtypecode" />
                <asp:BoundField DataField="legratecode" HeaderText="Rate" SortExpression="legratecode" />
                <asp:BoundField DataField="legpurposecode" HeaderText="Purpose" SortExpression="legpurposecode" />
                <asp:BoundField DataField="tripstatus" HeaderText="trip status" SortExpression="tripstatus" />
                <asp:BoundField DataField="legstate" HeaderText="leg state" SortExpression="legstate" />
                <asp:BoundField DataField="CancelCode" HeaderText="Cancel Code" ReadOnly="True" SortExpression="CancelCode" />
                <asp:BoundField DataField="CancelDate" HeaderText="Cancel Date" ReadOnly="True" SortExpression="CancelDate" />
                <asp:BoundField DataField="PIC" HeaderText="PIC" ReadOnly="True" SortExpression="PIC" />
                <asp:BoundField DataField="SIC" HeaderText="SIC" SortExpression="SIC" />
               
            </Columns>
        </asp:GridView>
    </article>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand ="SELECT top 100  fostrips.[RequesterName], fostrips.quotedtotalcost ,	fosflights.casupdate,fosflights.cancelcode, fosflights.canceldate, fosflights.tripnumber, fosflights.AircraftID,  aircrafttype, fosflights.carrierid, fosflights.departureairporticao, fosflights.arrivalairporticao, CAST(fosflights.[DepartureDateGMT] + ' ' + fosflights.[DepartureTimeGMT] as datetime) as ddgmt, CAST(fosflights.[ArrivalDateGMT] + ' ' + fosflights.[ArrivalTimeGMT] as datetime) as adgmt,  flighttime, nauticalmiles, duration, deadhead, paxcount, legtypecode, legratecode, legpurposecode, tripstatus, legstate     FROM [FOSFlights]  WITH (NOLOCK)  LEFT JOIN fostrips  ON fosflights.carrierid=fostrips.carrierid and fosflights.tripnumber=fostrips.tripnumber where fosflights.departuredategmt = '10/8/2012'  "></asp:SqlDataSource>
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