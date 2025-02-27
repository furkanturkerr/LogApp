<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainPage.aspx.vb" Inherits="Logapp.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LogApp</title>
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
        
        .container {
            text-align: center;
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 500px;
        }
        
        .title {
            font-size: 24px;
            font-weight: bold;
            color: #333;
            margin-bottom: 20px;
        }

        .btn-container {
            margin-top: 30px;
        }

        .btn-container .asp-btn {
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

        .btn-container .asp-btn:hover {
            background-color: #45a049;
        }

        .btn-container .asp-btn:focus {
            outline: none;
        }

        @media (max-width: 600px) {
            .container {
                padding: 20px;
            }

            .title {
                font-size: 20px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <p class="title">LogApp'e Hoş Geldiniz</p>
        
        <div class="btn-container">
            <asp:Button ID="uye_btn" runat="server" Text="Kayıt Ol" CssClass="asp-btn" />
            <asp:Button ID="giris_btn" runat="server" Text="Giriş Yap" CssClass="asp-btn" />
        </div>
    </form>
</body>
</html>
