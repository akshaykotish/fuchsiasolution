<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Test_Assign.aspx.cs" Inherits="PTE_VG.Test_Assign" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Kotish/dist/css/swiper.css" rel="stylesheet" />
    <link href="Kotish/dist/css/swiper.min.css" rel="stylesheet" />
    <link href="Kotish/Switch.css" rel="stylesheet" />
    <link href="Kotish/Glow.css" rel="stylesheet" />
    <link href="Kotish/Question.css" rel="stylesheet" />
    <link href="Kotish/Modal.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <div class="main m1 animated pulse">
            <div class="header">
                
            <table>
                <tr>
                    <td>Batch Finder</td>
                    <td><table style="width:100%;" class="onmob">
                    <tr style="width:100%;">
                        <td style="width:50%;">
                            <div class="search-area">
                                <asp:TextBox ID="Create_Console" runat="server" CssClass="Search-Console" Placeholder="Create Batch" Width="68%" Height="30px" ></asp:TextBox>
                                <asp:Button ID="Create_Btn" runat="server" CssClass="Search-Btn" Text="Create" Width="28%" OnClick="Create_Btn_Click" />
                            </div>
                        </td>
                        <td style="width:50%;">
                            <div class="search-area">
                                <asp:TextBox ID="Search_Console" runat="server" CssClass="Search-Console" Placeholder="Search Batch" Width="68%" Height="30px" ></asp:TextBox>
                                <asp:Button ID="Search_Btn" runat="server" CssClass="Search-Btn" Text="Search" Width="28%" OnClick="Search_Btn_Click" />
                            </div>
                        </td>
                    </tr>
                </table></td>
                </tr>
            </table>
            </div>
            <div class="inn_box">
                <asp:GridView ID="All_Batch" runat="server" AutoGenerateColumns="false" BorderStyle="None" ShowHeader="true" GridLines="None" OnRowDataBound="All_Batch_RowDataBound" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                 <table  class="grid-head">
                                    <tr>
                                        <td style="width:25%;">
                                            Batch Name
                                        </td>
                                        <td style="width:25%;" class="onmob">
                                            Created On
                                        </td>
                                       <td style="width:10%;">
                                            Students
                                        </td>
                                       <td style="width:10%;">
                                            Tests
                                        </td>
                                         <td style="width:30%;">
                                            Test Assigned
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="grid-content">
                                    <tr>
                                        <td style="width:25%;">
                                            <asp:Label ID="Batch_Title" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:25%;" class="onmob">
                                            <asp:Label ID="Created_on" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:10%; text-align:center;">
                                            <asp:Label ID="Students" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:10%; text-align:center;">
                                            <asp:Label ID="Tests" runat="server"></asp:Label>
                                        </td>
                                         <td style="width:30%; text-align:center;">
                                            <asp:Button ID="Load_Tests" runat="server" CssClass="buttons" CommandName='<%# Eval("Batch_ID")%>' style="padding:0.5%;" Width="100px" Height="30px" Text="Load Test" OnCommand="Load_Tests_Command"/>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
         <div class="main m2 animated pulse">
             <div class="header">
                
            <table>
                <tr>
                    <td>Test Finder</td>
                    <td><div class="search-area">
                <asp:TextBox ID="Searh_Test_Console" runat="server" CssClass="Search-Console" Placeholder="Search Test"></asp:TextBox>
                <asp:Button ID="Search_Test_Btn" runat="server" CssClass="Search-Btn" Text="Search" OnClick="Search_Test_Btn_Click" />
            </div></td>
                </tr>
            </table>
            </div>
            <div class="inn_box" class="sizes">
                <asp:GridView ID="All_Test" runat="server" AutoGenerateColumns="false" BorderStyle="None" ShowHeader="true" GridLines="None" OnRowDataBound="All_Test_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                 <table class="grid-head">
                                    <tr>
                                        <td style="width:25%;">
                                            Test Name
                                        </td>
                                          <td style="width:25%;" class="onmob">
                                            No of Questions
                                        </td>
                                        <td style="width:25%;">
                                            View Test
                                        </td>
                                       <td style="width:25%;">
                                            Action
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="grid-content">
                                    <tr>
                                        <td style="width:20%;">
                                            <asp:Label ID="Test_Name" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:20%;" class="onmob">
                                            <asp:Label ID="dtl" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:20%; text-align:center;">
                                            <asp:Button ID="View_Question" runat="server" CssClass="buttons" style="padding:0.5%;" Width="100px" Height="30px" Text="View Test" OnCommand="View_Question_Command" />
                                        </td>
                                       <td style="width:20%; text-align:center;">
                                           <asp:Button ID="Action_Test_Btn" runat="server" CssClass="buttons" style="padding:0.5%;" Width="80px" Height="30px" BackColor="Red" Text="Remove" CommandArgument='<%# Eval("Test_ID") %>' OnCommand="Action_Test_Btn_Command" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="Batch_ID" runat="server" Value="0" Visible="false" />
</asp:Content>
