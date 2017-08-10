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
        </div>

        <table>

            <tr>
                <td> <h1>Cores Waiting</h1></td>
                 <td><h1>Cores Alive</h1></td>
                 <td>  <h1>Minutes Last Request
                       </h1></td>
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
                    
                    <telerik:RadRadialGauge ID="RadRadialGauge2" runat="server" Width="350px">
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
        
        SelectCommand="SELECT top 100  [ID], [Message], [severity] FROM [sys_log] ORDER BY [id] DESC">
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
       
        SelectCommand="SELECT top 5 [id], [FOSLastUpdate], [FOSRecords], [Optimized3] FROM [FOSLOG] ORDER BY [id] DESC">
    </asp:SqlDataSource>
        </li>
        <li class="three">
            <h5>Find Azure Status</h5>
            You can also find azure data center status
            <a href="https://www.windowsazure.com/en-us/support/service-dashboard/">Azure Cloud Status…</a>
        </li>
    </ol>
</asp:Content>
