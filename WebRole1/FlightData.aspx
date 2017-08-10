
<%@ Page Title="Flight Data Mining" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlightData.aspx.vb" Inherits="WebRole1.FlightData" %><%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
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
    </aside>--%><%--<telerik:RadComboBox ID="RadComboBox3" Runat="server">
         </telerik:RadComboBox>--%><%-- <aside>
        <h3>Aside Title</h3>
        <p>        
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>--%><%--<telerik:RadComboBox ID="RadComboBox3" Runat="server">
         </telerik:RadComboBox>--%><%-- <aside>
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
    <hgroup class="title">
        <h1>&nbsp;</h1>
    </hgroup>

     
    <article>
         <span class="label">Carrier:</span>
         <asp:DropDownList ID="DrpCarrier" runat="server" AutoPostBack="True" style="height: 22px">
             <asp:ListItem Value="65">TMC</asp:ListItem>
             <asp:ListItem Selected="True" Value="104">JLX</asp:ListItem>
             <asp:ListItem Value="100">WU</asp:ListItem>
             <asp:ListItem Value="49">XO</asp:ListItem>
             <asp:ListItem Value="107">ASI</asp:ListItem>
               <asp:ListItem Value="108">Delta</asp:ListItem>
               <asp:ListItem Value="0">All</asp:ListItem>
         </asp:DropDownList>

         &nbsp;
        <asp:CheckBox ID="chkHistorical" runat="server" Text="Historical" />
         &nbsp;
        FROM:
        <telerik:RadDatePicker ID="RadDatePickerFrom" Runat="server" Culture="en-US" HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." WrapperTableSummary="Table holding date picker control for selection of dates.">
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
        TO:
         <telerik:RadDatePicker ID="RadDatePickerTo" Runat="server" Culture="en-US" HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." WrapperTableSummary="Table holding date picker control for selection of dates.">
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


        <span class="label">AC Type:</span> 
          <td class="auto-style1">  <asp:DropDownList ID="Drpactype" runat="server" Font-Size="Larger">
              </asp:DropDownList>

               <span class="label">
         &nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label1" runat="server" Text="WC"></asp:Label>
         &nbsp; RoundTrip<asp:CheckBox ID="chkRoundtrip" runat="server" />
    
         <br />
         Include LegType&nbsp;
         <telerik:RadComboBox ID="RadLegTypeInclude" Runat="server" CheckBoxes="True">
         </telerik:RadComboBox>
         Exclude Leg Type&nbsp;
         <telerik:RadComboBox ID="RadLegTypeExclude" Runat="server" CheckBoxes="True">
         </telerik:RadComboBox>
         <br />
         &nbsp;RequesterName&nbsp;
         <asp:TextBox ID="requestertxt" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AircraftID&nbsp; &nbsp;&nbsp;<asp:TextBox ID="txtAircraftID" runat="server"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <br />
         <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Broker&nbsp; &nbsp;<asp:DropDownList ID="DrpBkr" runat="server">
                       <asp:ListItem Selected="True" Value="ALLBKR">ALL</asp:ListItem>
                       <asp:ListItem Value="YESBKR">YES</asp:ListItem>
                       <asp:ListItem Value="NOBKR">NO</asp:ListItem>
         </asp:DropDownList>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BaseCode&nbsp;&nbsp;
         <asp:TextBox ID="txtBasecode" runat="server"></asp:TextBox>
         <br />
         Include Leg State
         <telerik:RadComboBox ID="RadLegStateInclude" Runat="server" CheckBoxes="True">
         </telerik:RadComboBox>
&nbsp;Exclude Leg State
         <telerik:RadComboBox ID="RadLegStateExclude" Runat="server" CheckBoxes="True">
         </telerik:RadComboBox>
         <br />
         Day of Week:</span></td>
          <td class="auto-style1">   <telerik:RadComboBox ID="drpDOW" runat="server">
             <Items>
                  <telerik:RadComboBoxItem runat="server" Text="All" Value="All" Checked="True" />
                 <telerik:RadComboBoxItem runat="server" Text="Sunday" Value="Sunday" />
                 <telerik:RadComboBoxItem runat="server" Text="Monday" Value="Monday" />
                 <telerik:RadComboBoxItem runat="server" Text="Tuesday" Value="Tuesday" />
                 <telerik:RadComboBoxItem runat="server" Text="Wednesday" Value="Wednesday" />
                 <telerik:RadComboBoxItem runat="server" Text="Thursday" Value="Thursday" />
                 <telerik:RadComboBoxItem runat="server" Text="Friday" Value="Friday" />
                 <telerik:RadComboBoxItem runat="server" Text="Saturday" Value="Saturday" />
             </Items>
         </telerik:RadComboBox>


                <span class="label">Trip Type:</span></td>
                 <telerik:RadComboBox ID="DrFlightType" runat="server">
             <Items>
                  <telerik:RadComboBoxItem runat="server" Text="All" Value="All" Checked="True" />
                 <telerik:RadComboBoxItem runat="server" Text="Revenue" Value="R"   />
                 <telerik:RadComboBoxItem runat="server" Text="Dead Head" Value="D"   />
                 <telerik:RadComboBoxItem runat="server" Text="Maintenance" Value="M"   />
                 <telerik:RadComboBoxItem runat="server" Text="SWAP" Value="S"   />
                 <telerik:RadComboBoxItem runat="server" Text="MXSC" Value="MX"   />
                 <telerik:RadComboBoxItem runat="server" Text="NC" Value="N"   />
                 <telerik:RadComboBoxItem runat="server" Text="AOG" Value="A"   />
                 <telerik:RadComboBoxItem runat="server" Text="AVAI" Value="AV"   />
                 <telerik:RadComboBoxItem runat="server" Text="OCF" Value="OCF"   />
                 <telerik:RadComboBoxItem runat="server" Text="SICK" Value="SICK"   />
                 <telerik:RadComboBoxItem runat="server" Text="Y" Value="Y"   />
                  
             </Items>
         </telerik:RadComboBox>

            <span class="label">Time of Day:</span></td>
                 <telerik:RadComboBox ID="DrTimeOfDay" runat="server">
             <Items>
                 <telerik:RadComboBoxItem runat="server" Text="All" Value="All" Checked="True" />
                 <telerik:RadComboBoxItem runat="server" Text="Morning" Value="AM"   />
                 <telerik:RadComboBoxItem runat="server" Text="Afternoon" Value="AMPM"   />
                 <telerik:RadComboBoxItem runat="server" Text="Evening" Value="PM"   />
                  
             </Items>
         </telerik:RadComboBox>

         <%--<telerik:RadComboBox ID="RadComboBox3" Runat="server">
         </telerik:RadComboBox>--%>

         <span class="label">
         <br />
         From:</span>
         <asp:TextBox ID="txtFrom" runat="server" Width="124px"></asp:TextBox>
              Radius
               <asp:TextBox ID="txtRadiusFrom" runat="server" Width="40px">0</asp:TextBox>
      
         <span class="label">To:</span>
         <asp:TextBox ID="txtTo" runat="server" Width="124px"></asp:TextBox>
              Radius
                 <asp:TextBox ID="txtRadiusTo" runat="server" Width="40px">0</asp:TextBox>


        &nbsp;&nbsp;Trip Number
         <asp:TextBox ID="txtTripNumber" runat="server" Width="60px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
         <asp:LinkButton ID="LinkSearch" runat="server">Search</asp:LinkButton>


        &nbsp;<asp:LinkButton ID="ExportToExcel" runat="server">Export to Excel</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total NM<asp:TextBox ID="txtNM" runat="server"></asp:TextBox>
        <br />
         <span class="label">Flights:</span>
        <asp:TextBox ID="txtcount" runat="server" Font-Size="Medium" Width="89px"></asp:TextBox>

        <span class="label">Minutes:</span>
        <asp:TextBox ID="txtminutes"  Font-Size="Medium" runat="server" Width="124px"></asp:TextBox>

          <span class="label">ProRev:</span>
        <asp:TextBox ID="txtproratecosts"  Font-Size="Medium" runat="server" Width="124px"></asp:TextBox>

           <span class="label">Exclude MX:</span>
        <asp:CheckBox ID="Chkmx" runat="server"  Checked="True"  />

           <span class="label">Exclude Cancel:</span>
        <asp:CheckBox ID="CHKCancel" runat="server" Checked="True" />


            <span class="label">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Data:</span>
        <asp:CheckBox ID="chkdetail" runat="server" />
        

        &nbsp;&nbsp;&nbsp; <strong>Exclude Stale</strong>:<asp:CheckBox ID="CHKstale1" runat="server" />
        

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EmptyDataText="Please set criteria and click search!">
            <Columns>
                <asp:BoundField DataField="Dep" HeaderText="Dep" SortExpression="Dep" />
                <asp:BoundField DataField="Arr" HeaderText="Arr" SortExpression="Arr" />
                <asp:BoundField DataField="RequesterName" HeaderText="Requester Name"   SortExpression="RequesterName"   ItemStyle-Wrap="False" />
                <asp:BoundField DataField="Operator" HeaderText="Operator" SortExpression="Operator" />
                <asp:BoundField DataField="Registration" HeaderText="Registration" SortExpression="Registration" />
                <asp:BoundField DataField="BrokerAircraft" HeaderText="Broker Aircraft" SortExpression="BrokerAircraft" />
                <asp:BoundField DataField="HomeBaseAirportCode" HeaderText="HomeBase AirportCode" SortExpression="HomeBaseAirportCode" />
                <asp:BoundField DataField="BaseCode" HeaderText="BaseCode" SortExpression="BaseCode" />
                <asp:BoundField DataField="quotedtotalcost" HeaderText="quoted total cost"   SortExpression="quotedtotalcost"   ItemStyle-Wrap="False" />
                <asp:BoundField DataField="quotedOwnerACcost" HeaderText="BKRcost"   SortExpression="quotedOwnerACcost"   ItemStyle-Wrap="False" />
                 <asp:BoundField DataField="proratedrevenue" HeaderText="prorated cost"   SortExpression="proratedrevenue"   ItemStyle-Wrap="False" />
                <asp:BoundField DataField="tripnumber" HeaderText="trip number" SortExpression="tripnumber" />
                <asp:BoundField DataField="AircraftID" HeaderText="Aircraft ID" SortExpression="AircraftID" />
                <asp:BoundField DataField="aircrafttype" HeaderText="aircraft type" SortExpression="aircrafttype" />
                <asp:BoundField DataField="carrierid" HeaderText="carrier id" SortExpression="carrierid" />
                <asp:BoundField DataField="departureairporticao" HeaderText="departure airport" SortExpression="departureairporticao" />
                <asp:BoundField DataField="arrivalairporticao" HeaderText="arrival airport" SortExpression="arrivalairporticao" />
                <asp:BoundField DataField="departuredategmt" HeaderText="departure dategmt" SortExpression="departuredategmt" />
                <asp:BoundField DataField="departuretimegmt" HeaderText="departure timegmt" SortExpression="departuretimegmt" />
                <asp:BoundField DataField="flighttime" HeaderText="flight time" SortExpression="flighttime" />
                <asp:BoundField DataField="nauticalmiles" HeaderText="nautical miles" SortExpression="nauticalmiles" />
                <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />
                <asp:BoundField DataField="deadhead" HeaderText="deadhead" SortExpression="deadhead" />
                <asp:BoundField DataField="paxcount" HeaderText="pax count" SortExpression="paxcount" />
                <asp:BoundField DataField="legtypecode" HeaderText="legtype code" SortExpression="legtypecode" />
                <asp:BoundField DataField="legratecode" HeaderText="legrate code" SortExpression="legratecode" />
                <asp:BoundField DataField="legpurposecode" HeaderText="legpurpose code" SortExpression="legpurposecode" />
                <asp:BoundField DataField="tripstatus" HeaderText="trip status" SortExpression="tripstatus" />
                <asp:BoundField DataField="legstate" HeaderText="leg state" SortExpression="legstate" />
                <asp:BoundField DataField="PIC" HeaderText="PIC" SortExpression="PIC" />
                <asp:BoundField DataField="SIC" HeaderText="SIC" SortExpression="SIC" />
                <asp:BoundField DataField="AircraftWeightClass" HeaderText="AircraftWeightClass" SortExpression="AircraftWeightClass" />

            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblsql" runat="server" Text="sql"></asp:Label>

    </article>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <asp:DropDownList ID="DrpWeight" runat="server" EnableTheming="False">
    </asp:DropDownList>
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