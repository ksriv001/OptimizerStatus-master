<%@ Page Language="VB" AutoEventWireup="false" Inherits="WebRole1.TrafficShape4" Codebehind="TrafficShape4.aspx.vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script type="text/javascript" src="https://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6&s=1">
     
     </script>
<script type="text/javascript">
var map = null;
function EventMapLoad()
{
   
    //Add Shapes Here
   <%# myJS %>
}

function CreateMap()
{
    var isStaticMap = false;
	var mapStyle = VEMapStyle.Road; // VEMapStyle.Road VEMapStyle.Aerial VEMapStyle.Hybrid VEMapStyle.Birdseye
    //center of continental US
    var vll = new VELatLong(43.74999999999998, -99.71000000000001);
    //default zoom level
    var zoomLevel = 4;

    //clear pushpins, routes, etc.
    //clearMainMap();

    //if (map == null){createMainMap()};

    //map.Load();
    
    //map.LoadMap(vll, zoomLevel, mapStyle, isStaticMap, VEMapMode.Mode2D, true);
    
    //map.HideDashboard();
            

    map = new VEMap('myMap');
    
    //default zoom level
   //var zoomLevel = 14;

    map.onLoadMap = EventMapLoad;
    //map.LoadMap(new VELatLong(43.75, -99.71), 4, VEMapStyle.Road);
    map.LoadMap(vll, zoomLevel, mapStyle, isStaticMap, VEMapMode.Mode2D, true);
    
}




</script>
<title> - Fly Destination Direct</title>
<style type="text/css">
    body,td,th {
	    font-family: tahoma, Helvetica, sans-serif;
	    
    }
    body
    {
        margin:0px;
        font-family: tahoma, Helvetica, sans-serif;
        font-size: 12px;
        /*background-image:url(Images/SATSair/bg_repeat.gif);*/
        background-repeat:repeat-x;
        background-color:#FAFAFA;
    }
    </style>
<%--    <link href="http://www.doav.virginia.gov/doav_style02P.css" rel="stylesheet" type="text/css" media="print" />--%>    
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    
</head>
<body onload="CreateMap();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="center" >
                    <table border="0" cellpadding="0" cellspacing="0" style="border-left:solid 1px #DFDFDF;border-right:solid 1px #DFDFDF;">
                        <tr>
                            <td align="center" bgcolor="White">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" bgcolor="White" colspan="3">
                                          
                                        </td> 
                                    </tr>
                                </table> 
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="White" style="padding-top:10px;">
                                <h3 style="color:#003333;">Traffic Map
                                    </h3>
                                <h3 style="color:#003333;">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="White" style="padding:0px;">
                                <div>
                                    <asp:TextBox ID="txtFrom" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtTo" runat="server" Visible="false"></asp:TextBox>
                                    <%--<asp:Button ID="cmdGenerateJscript" runat="server" Text="Generate JScript" />
                                    <asp:Button ID="cmdPopulation" runat="server" Text="Generate Population map" />
                                    <asp:Button ID="cmdEURoutes" runat="server" Text="Generate Routes" />
                                    <asp:Button ID="ModelDetail" runat="server" Text="Generate Model Detail" /></div>
                                    <div>&nbsp;</div>--%>
                                   <%-- <asp:UpdatePanel ID="upSchedule" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center" style="padding-bottom:2px;padding-top:5px;">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="padding-bottom:3px;">
                                                                    <asp:LinkButton ID="lbPreviousDay" runat="server" Font-Bold="true" ForeColor="Black" Font-Underline="false" ></asp:LinkButton>
                                                                </td>
                                                                <td style="padding-left:10px;">
                                                                     
                                                                </td>
                                                                <td style="padding-left:6px;padding-right:10px;padding-bottom:5px;">
                                                                    <asp:Button ID="bttnGoToDate" runat="server" Text="Go" CssClass="inputField" />
                                                                </td>
                                                                <td style="padding-bottom:3px;">
                                                                    <asp:LinkButton ID="lbNextDay" runat="server" Font-Bold="true" ForeColor="Black" Font-Underline="false" >>></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>                                            
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel ID="pnlMap" runat="server">
                                            <div align="center" style="position:relative;width:800px;height:540px;z-index:10;">
                                                <div align="center" id="myMap" style="position:absolute;width:800px;height:540px;z-index:10;left:0px;top:0px;">
                                                </div>
                                            </div>
                                            </asp:Panel>
                                        <%--</ContentTemplate> 
                                  </asp:UpdatePanel> --%>
                               </div> 
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="middle" style="background-color:White;">
                                <table border="0" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td valign="middle" style="padding-right:150px;">
                                            &nbsp;<br/>&nbsp;
                                                                            <asp:HiddenField ID="hddnMode" runat="server" />
                                        </td>
                                    </tr>
                                </table> 
                            </td>
                        </tr>    
                    </table> 
                </td> 
            </tr> 
        </table> 
        
    
     
    </form>
</body>
</html>
