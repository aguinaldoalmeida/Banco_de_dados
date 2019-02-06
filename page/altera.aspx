<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="altera.aspx.cs" Inherits="AulaBancoDados.page.altera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtnome">Nome:</label>
            <asp:TextBox ID="txtnome" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtend">Endereço:</label>
            <asp:TextBox runat="server" ID="txtend"></asp:TextBox>
        </div>
        <div>
            <label for="txtemail">Email:</label>
            <asp:TextBox runat="server" ID="txtemail"></asp:TextBox>
        </div>
        <div>
            <label for="txtnasc">Nascimento:</label>
            <asp:TextBox runat="server" ID="txtnasc"></asp:TextBox>
        </div>
        <div>
            <label for="txtpeso">Peso:</label>

            <asp:TextBox runat="server" ID="txtpeso"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblResultado" runat="server" Text="[ Label de resultado ]"></asp:Label>
        </div>
        <div>------------------------------------------------- </div>
        <div>
            <asp:Button ID="btnCriar" runat="server" Text="INSERIR" OnClick="btnCriar_Click" />
            <asp:Button ID="btnSalvar" runat="server" Text="SALVAR" OnClick="btnSalvar_Click" />
            <asp:Button ID="btnDeletar" runat="server" Text="DELETAR" OnClick="btnDeletar_Click" />
            <asp:Button ID="btnVoltar" runat="server" Text="VOLTAR" OnClick="btnVoltar_Click" />
        </div>
        
    </form>
</body>
</html>
