<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleta.aspx.cs" Inherits="AulaBancoDados.page.deleta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
        <div runat="server" id="pergunta">
            <div>
                <h1 runat="server" id="msg"></h1>
            </div>
            <div>
                <asp:Button ID="BtnSim" runat="server" OnClick="BtnSim_Click" Text="SIM" />
                <span>- </span>
                <asp:Button ID="BtnNao" runat="server" Text="NÃO" OnClick="BtnNao_Click" />
            </div>
        </div>
        
        <div runat="server" id="sucesso" visible="false">            
            <div>
                <h1>Apagado com Sucesso!</h1>
            </div>
            <div>
                <asp:Button ID="BtnVoltar" runat="server" OnClick="BtnVoltar_Click" Text="VOLTAR" />                
            </div>
        </div>
        
    </form>
</body>
</html>
