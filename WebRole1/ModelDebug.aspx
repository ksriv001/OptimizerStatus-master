<%@ Page Title="Optimizer Status" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModelDebug.aspx.vb" Inherits="WebRole1.ModelDebug" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>CAS Optimizer Status</h1> <h3>  
                    &nbsp;&nbsp; Model Number
                <asp:TextBox ID="txtModelNumber" runat="server"></asp:TextBox> <asp:Button ID="cmdModelReview" runat="server" Text="Review Model" />
                </h3>
            </hgroup>
            <p>
                To learn more about CAS, visit <a href="http://asp.net" title="ASP.NET Website">http://</a>www.coastalaviationsoftware.com.&nbsp; To book flights visit <a href="http://www.personifly.com" title="ASP.NET Forum">our forums</a></p>
        </div>

        <table>

            <tr>
                <td> <h1>Timeouts</h1></td>
                 <td><h1>Models Produced</h1></td>
                 <td>  <h1>Log Entries</h1></td>
                 <td><h1>Last Run</h1></td>
            </tr>

            <tr>

                <td>
                   
                    <telerik:RadRadialGauge ID="RadRadialGauge1" runat="server" Width="350px">
                        <Scale MajorUnit="5" Max="100">
                            <Ranges>
                                <telerik:GaugeRange Color="Red" From="15" To="100" />
                                <telerik:GaugeRange Color="PaleVioletRed" From="13" To="14"></telerik:GaugeRange>
                                <telerik:GaugeRange Color="LightYellow" From="8" To="12" />
                                <telerik:GaugeRange Color="PaleGreen" From="4" To="7" />
                                <telerik:GaugeRange Color="Green" From="0" To="3" />
                                
                            </Ranges>
                        </Scale>
                    </telerik:RadRadialGauge>
                </td>


                 <td>
                    
                    <telerik:RadRadialGauge ID="RadRadialGauge2" runat="server" Width="350px">
                         <Scale MajorUnit="50" Max="500">
                            <Ranges>
                                   <telerik:GaugeRange Color="Red" To="19" />
                                <telerik:GaugeRange Color="PaleVioletRed" From="20" To="59"></telerik:GaugeRange>
                                <telerik:GaugeRange Color="LightYellow" From="60" To="80" />
                                <telerik:GaugeRange Color="PaleGreen" From="80" To="100" />
                                <telerik:GaugeRange Color="Green" From="100" To="200" />
                                 <telerik:GaugeRange Color="PaleGreen" From="201" To="300" />
                                <telerik:GaugeRange Color="LightYellow" From="301" To="500" />
                            </Ranges>
                        </Scale>
                    </telerik:RadRadialGauge>
                </td>


                      <td>
                  
                    <telerik:RadRadialGauge ID="RadRadialGauge3" runat="server" Width="350px">
                         <Scale MajorUnit="5" Max="100">
                            <Ranges>
                                <telerik:GaugeRange Color="Red" From="40" To="100" />
                                <telerik:GaugeRange Color="PaleVioletRed" From="13" To="39"></telerik:GaugeRange>
                                <telerik:GaugeRange Color="LightYellow" From="8" To="12" />
                                <telerik:GaugeRange Color="PaleGreen" From="4" To="7" />
                                 <telerik:GaugeRange Color="Green" From="0" To="3" />
                            </Ranges>
                        </Scale>
                    </telerik:RadRadialGauge>
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
        </li>









        <li class="three">
            <h5>Model Evolution</h5>
          
            
             <telerik:RadGrid ID="RadGrid3" runat="server" CellSpacing="0" GridLines="None" 
        DataSourceID="SqlDataSource3">
<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:gridboundcolumn DataField="modelrunid" DataType="System.Int32" 
            FilterControlAltText="Filter Modelrunid column" HeaderText="modelrunid" ReadOnly="True" 
            SortExpression="modelrunid" UniqueName="modelrunid">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="iteration" DataType="System.Int32" 
            FilterControlAltText="Filter iteration column" HeaderText="iteration" 
            SortExpression="iteration" UniqueName="iteration">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="CASefficiency" DataType="System.Int32" 
            FilterControlAltText="Filter CASefficiency column" HeaderText="CASefficiency" 
            SortExpression="CASefficiency" UniqueName="CASefficiency">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="CAStotalrevenueexpense" DataType="System.Int32" 
            FilterControlAltText="Filter CAStotalrevenueexpense column" HeaderText="CAStotalrevenueexpense" 
            SortExpression="CAStotalrevenueexpense" UniqueName="CAStotalrevenueexpense">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="CASLongestEmptyLeg" DataType="System.Int32" 
            FilterControlAltText="Filter CASLongestEmptyLeg column" HeaderText="CASLongestEmptyLeg" 
            SortExpression="CASLongestEmptyLeg" UniqueName="CASLongestEmptyLeg">
        </telerik:GridBoundColumn>
        <telerik:gridboundcolumn DataField="CASAverageEmtpyNM" DataType="System.Int32" 
            FilterControlAltText="Filter CASAverageEmtpyNM column" HeaderText="CASAverageEmtpyNM" 
            SortExpression="CASAverageEmtpyNM" UniqueName="CASAverageEmtpyNM">
        </telerik:GridBoundColumn>
        
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
            
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
       
        SelectCommand="WITH
  cteReports (modelrunid, modelbasedon, iteration, CASefficiency, CAStotalrevenueexpense,CASLongestEmptyLeg,CASAverageEmtpyNM)
  AS
  (
    SELECT modelrunid, modelbasedon, 1, CASefficiency, CAStotalrevenueexpense,CASLongestEmptyLeg,CASAverageEmtpyNM
    FROM OptimizerLog
    WHERE modelrunid = (select  top 1  modelrunid from optimizerlog where CustomRunNumber  = '11302'    order by   castotalrevenueexpense)
    UNION ALL
    SELECT o.modelrunid, o.modelbasedon,r.iteration+1, o.CASefficiency, o.CAStotalrevenueexpense,o.CASLongestEmptyLeg,o.CASAverageEmtpyNM
    FROM Optimizerlog o
      INNER JOIN cteReports r
        ON o.modelrunid = r.modelbasedon
  )
SELECT top 15 modelrunid,iteration,CASefficiency, CAStotalrevenueexpense,CASLongestEmptyLeg,CASAverageEmtpyNM from ctereports
 ">
    </asp:SqlDataSource>
        </li>







        <li class="four">
            <h5>Find Azure Status</h5>
            You can also find azure data center status
            <a href="https://www.windowsazure.com/en-us/support/service-dashboard/">Azure Cloud Status…</a>
        </li>
    </ol>
</asp:Content>
