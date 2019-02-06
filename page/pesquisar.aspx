<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pesquisar.aspx.cs" Inherits="AulaBancoDados.page.pesquisar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtemail">Id:</label>
            <asp:TextBox runat="server" ID="txtpesquisa"></asp:TextBox>
            <asp:Button ID="btnPesquisar" runat="server" Text="PESQUISAR" OnClick="btnPesquisar_Click" />
            <span> - </span>
            <asp:Label ID="Label1" runat="server" Text="Deixe em Branco para Listar Tudo"></asp:Label>

        </div>
        <div>
            <asp:Label ID="lblResultado" runat="server" Text="[ Label de resultado ]"></asp:Label>
        </div>
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div> 
                        <a href="altera.aspx?id=<%#Eval("Id") %>" >
                            Id: <%#Eval("Id") %> <span> - </span>
                            Nome: <%#Eval("Nome") %> <span> - </span>
                            Endereco: <%#Eval("Endereco") %> <span> - </span>
                            Email: <%#Eval("Email") %> <span> - </span>
                            Nascimento: <%#Eval("Nascimento") %> <span> - </span>
                            Peso: <%#Eval("Peso") %>
                        </a>                       
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
