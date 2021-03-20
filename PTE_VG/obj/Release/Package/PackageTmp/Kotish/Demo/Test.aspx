<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="PTE_VG.Kotish.Demo.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Test.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager runat="server" EnablePageMethods="true"></asp:scriptmanager>
        <script>
            var dta;
function Update_Text() {
    PageMethods.Update_Text("Hi", onSucess, onError);
}
            function onSucess(result) {
                console.log(obj);
            }

function onError(result) {
  
    console.log(result);
}
            Update_Text();
        </script>
        <script src="Test.js"></script>
    </form>
</body>
</html>
