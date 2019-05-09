<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroPessoas.aspx.cs" Inherits="CadastroPessoas.CadastroPessoas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Panel runat="server" ID="pnlPrincipal">
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Nome da Pessoa: " Font-Size="Medium"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomePessoa" Height="30px" Columns="40" MaxLength="40"></asp:TextBox>
                        <asp:Label runat="server" ID="lblErroNome" Visible="false" Font-Size="Smaller" Font-Color="red" Text="*Campo de Nome é obrigatório e não deve conter números" ForeColor="Red"></asp:Label>
                     </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label runat="server" Text="Data de Nascimento: " Font-Size="Medium"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDtNascto" Height="30px" Columns="10" MaxLength="10" ></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label runat="server" Text="Dinheiro: " Font-Size="Medium" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtVrDinheiro" Height="30px" Columns="25"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Button runat="server" Text="Salvar" ID="btnGravaPessoa" OnClick="btnGravaPessoa_Click" Height="30px" Width="60px" Font-Size="Small" />
                        <asp:Button runat="server" Text="Limpar" ID="btnLimpa" OnClick="btnLimpa_Click" Height="30px" Width="60px" Font-Size="Small" />
                        <asp:Label runat="server" ID="lblEdita" Visible="false" Text="-1"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>

    </div>

    <div class="row">
        <asp:Panel runat="server" ID="pnlPessoasCadastradas">
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView runat="server" ID="gvPessoas" AutoGenerateColumns="false" Width="100%" OnSelectedIndexChanged="gvPessoas_SelectedIndexChanged" OnRowDeleting="gvPessoas_RowDeleting" DataKeyNames="Nome,Idade,Dinheiro,DtNascto">
                            <Columns>
                                <asp:BoundField HeaderText="Nome" DataField="Nome" />
                                <asp:BoundField HeaderText="Idade" DataField="Idade" />
                                <asp:BoundField HeaderText="Dinheiro" DataField="Dinheiro" />
                                <asp:BoundField DataField="DtNascto" Visible="false" />
                                <asp:ButtonField HeaderText="Editar" CommandName="select" Text="Editar" />
                                <asp:ButtonField HeaderText="Excluir" CommandName="delete" Text="Excluir" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label runat="server" Text="Não há pessoas cadastradas no momento"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Pessoa com mais dinheiro: " ID="lblDinheiroMax"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Pessoa com menos dinheiro: " ID="lblDinheiroMin"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>

