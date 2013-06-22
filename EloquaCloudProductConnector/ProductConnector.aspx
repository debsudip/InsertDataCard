<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductConnector.aspx.cs"
    Inherits="Philips.DigitalServices.Eloqua.EloquaCloudProductConnector.ProductConnector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function startTimer() {
            debugger;
            var timer = $find("<%=Timer1.ClientID%>")
            timer._startTimer();
        }

        function stopTimer() {

            var timer = $find("<%=Timer1.ClientID%>")
            timer._stopTimer();

        }
    </script>
    <style type="text/css">
        #form1
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <p>
        <p>
            &nbsp;</p>
        <p style="text-align: center">
            Welcome to Test Cloud Connector
        </p>
        <p style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p style="text-align: center">
            <asp:Label ID="Label2" runat="server" Style="text-align: center" Text="Label"></asp:Label>
        </p>
        <p style="text-align: center">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </p>
        </p>
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="False" 
            ontick="Timer1_Tick1" />
       
    </div>
    <asp:Button ID="btnStart" runat="server" onclick="btnStart_Click" 
        style="text-align: center" Text="Start" />
&nbsp;<asp:Button ID="btnStop" runat="server" onclick="btnStop_Click" 
        style="text-align: center" Text="Stop" />
    </form>
</body>
</html>
