<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/adm.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="BazarYasmin.adm.clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<ul class="nav navbar-nav side-nav">
                    <li >
                        <a href="../adm/inicio.aspx"><i class="fa fa-fw fa-dashboard"></i> Inicio</a>
                    </li>
                    <li>
                        <a href="../adm/pedidos.aspx"><i class="fa fa-fw fa-shopping-basket"></i> Pedidos</a>
                    </li>
              
                    <li>
                        <a href="../adm/productos.aspx"><i class="fa fa-fw fa-futbol-o"></i> Productos</a>
                    </li>
                    <li class="active">
                        <a href="../adm/clientes.aspx"><i class="fa fa-fw fa-user-circle-o"></i> Clientes</a>
                    </li>
                    
                </ul>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        Clientes <small>Mantenedor</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li class="active">
                            <i class="fa fa-user-circle-o"></i> Clientes
                            </li>
                        </ol>
                    </div>
                </div>

</asp:Content>

