 <%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Test_Checker.aspx.cs" Inherits="PTE_VG.Test_Checker" EnableEventValidation="false"  %>
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
                    <td>Test & Batch Finder</td>
                        <td><div class="search-area" class="onmob">
                    <asp:TextBox ID="Search_Batch_Test_Console" runat="server" CssClass="Search-Console" Placeholder="Search Test or Batch" Width="68%" Height="30px" ></asp:TextBox>
                    <asp:Button ID="Search_Batch_Test_Btn" runat="server" CssClass="Search-Btn" Text="Search" Width="28%" OnClick="Search_Batch_Test_Btn_Click" />
                </div></td>
                </tr>
            </table>
             </div>
            <div class="inn_box">
                <asp:GridView ID="All_Test" runat="server" AutoGenerateColumns="false" BorderStyle="None" ShowHeader="true" GridLines="None" OnRowDataBound="All_Test_RowDataBound" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table class="grid-head">
                                    <tr>
                                        <td style="width:25%;">
                                            Test Name
                                        </td>
                                       <td style="width:25%;">
                                            Batch Name
                                        </td>
                                        <td style="width:20%;" class="onmob">
                                            Created On
                                        </td>
                                        <td style="width:15%; font-size:xx-small;" class="onmob">
                                            Question Count
                                        </td>
                                       <td style="width:15%; font-size:small;">
                                            Action
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="grid-content">
                                    <tr>
                                        <td style="width:25%;">
                                            <asp:Label ID="Test_Name" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="Batch_Name" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:20%;" class="onmob">
                                            <asp:Label ID="Created_On" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:15%; text-align:center;" class="onmob">
                                           <asp:Label ID="No_of_Questions" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:15%; text-align:center;">
                                           <asp:Button ID="Load_test_questions" runat="server" CssClass="buttons" CommandName='<%# Eval("Batch_Test_ID")%>' style="padding:0.5%;" Width="100px" Height="30px" Text="Load Students" OnCommand="Load_test_questions_Command" />
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
                    <td>Student Finder</td>
                    <td>
                        <div class="search-area">
                            <asp:TextBox ID="Student_Search_Console" runat="server" CssClass="Search-Console" Placeholder="Search Student" Width="68%" Height="30px" ></asp:TextBox>
                            <asp:Button ID="Student_Search_Button" runat="server" CssClass="Search-Btn" Text="Search" Width="28%" OnClick="Student_Search_Button_Click" />
                        </div>
                    </td>
                </tr>
            </table>
            </div>
            <div>
                <asp:GridView ID="All_Students" runat="server" AutoGenerateColumns="false" BorderStyle="None" ShowHeader="true" GridLines="None" OnRowDataBound="All_Students_RowDataBound" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table class="grid-head">
                                    <tr>
                                        <td style="width:30%;">
                                            Name
                                        </td>
                                        <td style="width:20%;" class="onmob">
                                            Contact
                                        </td>
                                       <td style="width:20%;" class="onmob">
                                            Email
                                        </td>
                                       <td style="width:15%;">
                                            Checked
                                        </td>
                                       <td style="width:15%;">
                                            Answer Sheet
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="grid-content">
                                    <tr>
                                        <td style="width:30%;">
                                            <asp:Label ID="Student_Name" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:20%;" class="onmob">
                                            <asp:Label ID="Contact" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:30%;" class="onmob">
                                            <asp:Label ID="Email" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:10%; text-align:center;">
                                            <asp:Label ID="IsChecked" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:10%; text-align:center;">
                                           <asp:Button ID="Load_Student_Sheet" runat="server" CssClass="buttons" CommandName='<%# Eval("Giving_ID")%>' style="padding:0.5%;" Width="100px" Height="30px" Text="Sheet" OnCommand="Load_Student_Sheet_Command" />
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
    <asp:HiddenField ID="batch_test_id_fld" runat="server" />
</asp:Content>
