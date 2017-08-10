
<%@ Page Title="Flight Data Mining" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlightData.aspx.vb" Inherits="WebRole1.FlightData" %><%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadComboBox ID="RadComboBox1" Runat="server">
    </telerik:RadComboBox>
    <telerik:RadComboBox ID="RadComboBox2" Runat="server">
    </telerik:RadComboBox>
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
    </aside>--%><%-- <aside>
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
    <telerik:RadDatePicker ID="RadDatePicker1" Runat="server" Culture="en-US">
    </telerik:RadDatePicker>
    <hgroup class="title">
        <h1>&nbsp;</h1>
    </hgroup>

     
    <article>
         <span class="label">Carrier:</span>
         <asp:DropDownList ID="DrpCarrier" runat="server" AutoPostBack="False">
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
        FROM:
        <telerik:RadDatePicker ID="RadDatePickerFrom" Runat="server" Culture="en-US" HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." WrapperTableSummary="Table holding date picker control for selection of dates." AutoPostBack="True">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" autopostback="True"></DateInput>
           
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>
        TO:
         <telerik:RadDatePicker ID="RadDatePickerTo" Runat="server" Culture="en-US" HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." WrapperTableSummary="Table holding date picker control for selection of dates." AutoPostBack="True">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" autopostback="True"></DateInput>
           
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>


        <span class="label">AC Type:</span> 
          <td class="auto-style1">  <asp:DropDownList ID="Drpactype" runat="server" Font-Size="Larger">
              </asp:DropDownList>

               <span class="label">Day of Week:</span></td>
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

         <telerik:RadComboBox ID="RadComboBox3" Runat="server">
         </telerik:RadComboBox>

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


        &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:LinkButton ID="LinkSearch" runat="server">Search</asp:LinkButton>


        &nbsp;<asp:LinkButton ID="ExportToExcel" runat="server">Export to Excel</asp:LinkButton>
        <br />
         <span class="label">Flights:</span>
        <asp:TextBox ID="txtcount" runat="server" Font-Size="Medium" Width="89px"></asp:TextBox>

        <span class="label">Minutes:</span>
        <asp:TextBox ID="txtminutes"  Font-Size="Medium" runat="server" Width="124px"></asp:TextBox>

           <span class="label">Exclude MX:</span>
        <asp:CheckBox ID="Chkmx" runat="server"  Checked="True"  />

           <span class="label">Exclude Cancel:</span>
        <asp:CheckBox ID="CHKCancel" runat="server" Checked="True" />


            <span class="label">Return Data:</span>
        <asp:CheckBox ID="chkdetail" runat="server" />
        

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EmptyDataText="Please set criteria and click search!">
            <Columns>
                <asp:BoundField DataField="tripnumber" HeaderText="tripnumber" SortExpression="tripnumber" />
                <asp:BoundField DataField="AircraftID" HeaderText="AircraftID" SortExpression="AircraftID" />
                <asp:BoundField DataField="aircrafttype" HeaderText="aircrafttype" SortExpression="aircrafttype" />
                <asp:BoundField DataField="carrierid" HeaderText="carrierid" SortExpression="carrierid" />
                <asp:BoundField DataField="departureairport" HeaderText="departureairport" SortExpression="departureairport" />
                <asp:BoundField DataField="arrivalairport" HeaderText="arrivalairport" SortExpression="arrivalairport" />
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
        <br />
        <asp:Label ID="lblsql" runat="server" Text="sql"></asp:Label>

    </article>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
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