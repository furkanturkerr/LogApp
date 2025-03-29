<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="LogApp.WebForm3" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Başarılı</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f7f7f7;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .message-box {
            text-align: center;
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 500px;
        }

        h1 {
            color: #007bff;
        }

        .btn {
            margin-top: 30px;
        }

        .btn {
            background-color: #007bff;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
            margin: 10px;
        }

        .btn:hover {
            background-color: #45a049;
        }

        .btn:focus {
            outline: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="message-box">
        <h1>Giriş Başarılı!</h1>
        <p>Hoş geldiniz. Sisteme başarıyla giriş yaptınız.</p>
        
        <!-- Giriş Yap butonu -->
        <asp:Button ID="giris_btn" runat="server" CssClass="btn" Text="AnaMenü" OnClick="btnMainPage_Click" />
        <br />
        <asp:Button ID="arac_btn" runat="server" CssClass="btn" Text="Araçlarım" OnClick="btnVehicle_Click" />
        <br />
        <asp:Button ID="yuk_btn" runat="server" CssClass="btn" Text="Yükler" OnClick="btnCargo_Click" />
    </div>
    </form>
</body>
</html>
