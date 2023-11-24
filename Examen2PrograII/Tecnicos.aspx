<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Examen2PrograII.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contanie text-center"> 
        <h1>Tecnicos</h1>
    </div>

       <div>
       <br />
       <br />
       <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
       CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
       RowStyle-CssClass="rows" AllowPaging="True" />
       <br />
       <br />
       <br />

       <div>
           <div class="mb-3">
           <label for="exampleInputEmail1" class="form-label">TecnicoID</label>
           <asp:TextBox ID="tcodigo" class="form-control" runat="server" OnTextChanged="tcodigo_TextChanged"></asp:TextBox>
           </div>
           <div class="mb-3">
           <label for="exampleInputEmail1" class="form-label">Especialidad</label>
           <asp:TextBox ID="tespecialidad" class="form-control" runat="server" OnTextChanged="tdescripcion_TextChanged"></asp:TextBox>
           </div>
           <div class="container text-center">
           </div>
       <asp:Button ID="Button4" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button4_Click" />
       <asp:Button ID="Button3" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="Button3_Click" />
       <asp:Button ID="Button1" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="Button1_Click" />
       <asp:Button ID="Button2" runat="server" class="btn btn-outline-danger" Text="Consultar"  OnClick="Button2_Click"/>
           </div>

</asp:Content>
