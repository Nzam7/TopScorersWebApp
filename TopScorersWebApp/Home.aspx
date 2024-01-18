<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TopScorersWebApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Top Scorers</title>

      <!-- Bootstrap CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <input type="file" id="fileUpload" />
    <button id="processButton">Process CSV</button>
    <div id="results"></div>


    <!-- JavaScript -->
    <script src="Scripts/jquery-3.7.0.min.js"></script>
    <script src="Scripts/bootstrap.bundle.js"></script>
    <script src="Scripts/App/AjaxHelper.js"></script>
    <script src="Scripts/App/Home.js"></script>
</body>
</html>
