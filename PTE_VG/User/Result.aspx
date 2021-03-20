<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="PTE_VG.Result" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Kotish/dist/css/swiper.css" rel="stylesheet" />
    <link href="Kotish/dist/css/swiper.min.css" rel="stylesheet" />
    <link href="Kotish/Switch.css" rel="stylesheet" />
    <link href="Kotish/Glow.css" rel="stylesheet" />
    <link href="Kotish/Question.css" rel="stylesheet" />
    <link href="Kotish/Modal.css" rel="stylesheet" />

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="main animated pulse" style="position:fixed; left:10%; right:10%;">
        <div class="header" style="padding:1.5%;">
            Question Finder
        </div>
        <div class="search-area" style="background-color:whitesmoke;">
            <asp:TextBox ID="Search_Console" runat="server" CssClass="Search-Console" Placeholder="Type to find" Width="80%" Height="30px" onkeydown="On_Down()" ></asp:TextBox>
            <asp:Button ID="Find_Btn" runat="server" CssClass="Search-Btn" Text="Find" ForeColor="Gray" BackColor="WhiteSmoke" Width="10%" OnClick="Find_Btn_Click" /> 
         </div>
        <div class="inn_box">
            <asp:GridView ID="All_Test" runat="server" AutoGenerateColumns="false" BorderStyle="None" ShowHeader="true" GridLines="None" OnRowDataBound="All_Test_RowDataBound" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table class="grid-head" style="padding:0.8%;">
                                    <tr>
                                        <td style="width:40%;">
                                            Name
                                        </td>
                                       <td style="width:10%;" class="onmob">
                                            Question Count
                                        </td>
                                        <td style="width:20%;" class="onmob">
                                            Date
                                        </td>
                                        <td style="width:10%;">
                                            Marks Count
                                        </td>
                                       <td style="width:20%;">
                                            Action
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="grid-content">
                                    <tr>
                                       <td style="width:40%;">
                                           <asp:Label ID="Test_Name" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:10%; text-align:center;" class="onmob">
                                            <asp:Label ID="Question_Count" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:20%;text-align:center;" class="onmob">
                                            <asp:Label ID="Date" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:10%;text-align:center;">
                                            <asp:Label ID="Marks_Count" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:20%;text-align:center;">
                                           <asp:Button ID="View_Test" runat="server" CssClass="buttons" Text="View Test"  OnCommand="View_Test_Command" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
    </div>

</asp:Content>
