<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="cuwMenu.ascx.vb" Inherits="labo4_2023.cuwMenu" %>

<header>
    <div class="row bg-info">
        <div class="col">
            LOGO
        </div>
    </div>
    <div class="row menu mt-1 mb-2">
        <div class="col">

            <%--MENU--%>
            <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" StaticSubMenuIndent="10px" Orientation="Horizontal">
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White"></DynamicHoverStyle>

                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>

                <DynamicMenuStyle BackColor="#B5C7DE"></DynamicMenuStyle>

                <DynamicSelectedStyle BackColor="#507CD1"></DynamicSelectedStyle>
                <Items>
<%--                    <asp:MenuItem NavigateUrl="~/altaAlumnos.aspx" Text="Alta Alumno" Value="Alta Alumno"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/consultaAlumnos.aspx" Text="Consulta" Value="Consulta"></asp:MenuItem>--%>
                </Items>
                <StaticHoverStyle BackColor="#284E98" ForeColor="White"></StaticHoverStyle>

                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></StaticMenuItemStyle>

                <StaticSelectedStyle BackColor="#507CD1"></StaticSelectedStyle>
            </asp:Menu>
            <%--FIN MENU--%>
        </div>
    </div>

</header>
