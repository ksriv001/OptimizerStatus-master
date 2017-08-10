<%@ Page Title="Optimizer Status" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebRole1._Default" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>CAS Optimizer Status</h1> <h3> <asp:Label ID="lbllastcommand" runat="server" Text="Label"></asp:Label>
&nbsp;</h3>
            </hgroup>
            <p>
                To learn more about CAS, visit <a href="http://asp.net" title="ASP.NET Website">http://</a>www.coastalaviationsoftware.com.&nbsp; To book flights visit <a href="http://www.personifly.com" title="ASP.NET Forum">our forums</a></p>
            <p>
                &nbsp;</p>
            <p>
                <asp:HyperLink ID="hlSchedule" runat="server" Target="_blank">Optimizer Schedule</asp:HyperLink>
            </p>
        </div>

        <table>

            <tr>
                <td> <h1>Cores Waiting</h1></td>
                 <td><h1>Cores Alive</h1></td>
                 <td class="auto-style1">  <h1>Minutes Last Request
                       </h1></td>
                <td><h1>Open Connections</h1></td>
                 <td><h1>Last Run</h1></td>
            </tr>

            <tr>

                <td>
                   
                    <telerik:RadRadialGauge ID="RadRadialGauge1" runat="server" Width="350px">
                        <Scale MajorUnit="5" Max="100">
                            <Ranges>
                                <telerik:GaugeRange Color="Red" To="5" />
                                <telerik:GaugeRange Color="PaleVioletRed" From="6" To="10"></telerik:GaugeRange>
                                <telerik:GaugeRange Color="LightYellow" From="11" To="20" />
                                <telerik:GaugeRange Color="PaleGreen" From="21" To="40" />
                                <telerik:GaugeRange Color="Green" From="41" To="100" />
                                
                            </Ranges>
                        </Scale>
                    </telerik:RadRadialGauge>
                </td>


                 <td>
                    
                    <telerik:RadRadialGauge ID="RadRadialGauge2" runat="server" Width="360px">
                         <Scale MajorUnit="20" Max="400">
                            <Ranges>
                                   <telerik:GaugeRange Color="Red" To="100" />
                                <telerik:GaugeRange Color="Yellow" From="100" To="150"></telerik:GaugeRange>
                                <telerik:GaugeRange Color="Green" From="150" To="400" />
                            </Ranges>
                        </Scale>
                    </telerik:RadRadialGauge>
                </td>


                      <td class="auto-style1">
                  
                    <telerik:RadRadialGauge ID="RadRadialGauge3" runat="server" Width="350px">
                         <Scale MajorUnit="5" Max="100">
                            <Ranges>
                                   <telerik:GaugeRange Color="Red" To="10" />
                                <telerik:GaugeRange Color="PaleVioletRed" From="11" To="15"></telerik:GaugeRange>
                                <telerik:GaugeRange Color="LightYellow" From="16" To="30" />
                                <telerik:GaugeRange Color="PaleGreen" From="30" To="45" />
                                <telerik:GaugeRange Color="Green" From="46" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadRadialGauge>
                </td>

                <td>
                  
                    <telerik:RadRadialGauge ID="RadRadialGauge4" runat="server" Width="350px">
                         <Scale MajorUnit="2000" Max="20000">
                            <Ranges>
                                   <telerik:GaugeRange Color="Green" To="4000" />
                                <telerik:GaugeRange Color="Orange" From="4001" To="8000"></telerik:GaugeRange>
                                <telerik:GaugeRange Color="Red" From="8001" To="12000" />
                                <telerik:GaugeRange Color="DarkViolet" From="12001" To="20000" />
                            </Ranges>
                        </Scale>
                    </telerik:RadRadialGauge>
                </td>

                <td>
                   <h3> <asp:Label ID="Label1" runat="server" Text="Minutes Last Request"/></h3>
                                    </td>


            </tr>

        </table>


    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Last Five Log Entries</h5>
          <telerik:RadGrid ID="RadGrid2" runat="server" CellSpacing="0" 
        DataSourceID="SqlDataSource2" GridLines="None" PageSize="5" Height="200px">
        <ClientSettings>
            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
        </ClientSettings>
<MasterTableView DataSourceID="SqlDataSource2" AutoGenerateColumns="False" 
            DataKeyNames="ID">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" 
            FilterControlAltText="Filter ID column" HeaderText="ID" ReadOnly="True" 
            SortExpression="ID" UniqueName="ID">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Message" 
            FilterControlAltText="Filter Message column" HeaderText="Message" 
            SortExpression="Message" UniqueName="Message">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="severity" DataType="System.Int32" 
            FilterControlAltText="Filter severity column" HeaderText="severity" 
            SortExpression="severity" UniqueName="severity">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
  <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        
        SelectCommand="SELECT top 100  [ID], [Message], [severity] FROM [sys_log]  WITH (NOLOCK)  ORDER BY [id] DESC">
    </asp:SqlDataSource>
        </li>
        <li class="two">
            <h5>View Last Five FOS Uploads</h5>
          
            
             <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" 
        DataSourceID="SqlDataSource1">
<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:gridboundcolumn DataField="id" DataType="System.Int32" 
            FilterControlAltText="Filter id column" HeaderText="id" ReadOnly="True" 
            SortExpression="id" UniqueName="id">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="FOSLastUpdate" DataType="System.DateTime" 
            FilterControlAltText="Filter FOSLastUpdate column" HeaderText="FOSLastUpdate" 
            SortExpression="FOSLastUpdate" UniqueName="FOSLastUpdate">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="FOSRecords" DataType="System.Int32" 
            FilterControlAltText="Filter FOSRecords column" HeaderText="FOSRecords" 
            SortExpression="FOSRecords" UniqueName="FOSRecords">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="Optimized3" 
            FilterControlAltText="Filter Optimized3 column" HeaderText="Optimized3" 
            SortExpression="Optimized3" UniqueName="Optimized3">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
            
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
       
        SelectCommand="SELECT top 5 [id], [FOSLastUpdate], [FOSRecords], [Optimized3] FROM [FOSLOG]  WITH (NOLOCK)  ORDER BY [id] DESC">
    </asp:SqlDataSource>
            New
        </li>
        <%--3rd list starts--%>

        <li class="three">
            <h5>View Open Connections and hosts</h5>
 <telerik:RadGrid ID="RadGrid3" runat="server" CellSpacing="0" GridLines="None" 
        DataSourceID="SqlDataSource3" AutoGenerateColumns="false">
                 <ClientSettings>
            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
        </ClientSettings>
<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:gridboundcolumn DataField="#Sessions" DataType="System.Int32" 
            FilterControlAltText="Filter #Sessions column" HeaderText="#Sessions" ReadOnly="True" 
            SortExpression="#Sessions" UniqueName="#Sessions">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="Host_name"  
            FilterControlAltText="Filter Host_name column" HeaderText="Host_name" 
            SortExpression="Host_name" UniqueName="Host_name">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="Program_name" DataType="System.Int32" 
            FilterControlAltText="Filter Program_name column" HeaderText="Program_name" 
            SortExpression="Program_name" UniqueName="Program_name">
        </telerik:GridBoundColumn>
       
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
            
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
       
        SelectCommand="select count(Host_name) as [#Sessions],host_name, program_name from  sys.dm_exec_sessions  group by host_name,program_name order by [#Sessions] desc">
    </asp:SqlDataSource>
        </li>
        <%--3rd list ends--%>

        <li class="four">
            <h5>Find Azure Status</h5>
            You can also find azure data center status
            <a href="https://www.windowsazure.com/en-us/support/service-dashboard/">Azure Cloud Status…</a>
        </li>
    </ol>
    <a class="twitter-timeline"
  href="https://twitter.com/TwitterDev"
  data-tweet-limit="3">
Tweets by @TwitterDev
</a>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 684px;
        }
    </style>
</asp:Content>



