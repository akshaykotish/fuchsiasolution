<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Create_Batch.aspx.cs" Inherits="PTE_VG.Create_Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="scriptmngr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="Updt_Pnl" runat="server">
               <ContentTemplate>

    <div style="width:100%; animated pulse">
        <div class="box center-box">
            <h4>Create Batch</h4>
            <div class="search-area">
                <asp:TextBox ID="Create_Console" runat="server" CssClass="Search-Console" Placeholder="Batch Name" Height="18.5px"></asp:TextBox>
                <asp:Button ID="Create_Btn" runat="server" CssClass="Search-Btn" Text="Create" OnClick="Create_Btn_Click" />
            </div>
            <hr style="width:60%;" />
            <div>
                <asp:GridView ID="All_Batches" runat="server" AutoGenerateColumns="false" BorderStyle="None" ShowHeader="true" GridLines="None" OnRowDataBound="All_Batches_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                 <table style="font-size:small; width:100%;">
                                                    <tr style=" width:100%; font-weight:bold; background-color:whitesmoke; height:30px; text-align:center;">
                                                        <td style="width:25%;">
                                                            Batch Name
                                                        </td>
                                                        <td style="width:25%;">
                                                            Created On
                                                        </td>
                                                       <td style="width:25%;">
                                                            Total No. of students
                                                        </td>
                                                       <td style="width:25%;">
                                                            Test Assigned
                                                        </td>
                                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="font-size:small; width:100%;">
                                    <tr style=" background-color:white; color:gray; height:30px; text-align:left; width:100%;">
                                        <td style="width:25%;">
                                            <asp:Label ID="Batch_Name" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="Created_On" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:25%;">
                                           <asp:Label ID="Students_No" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:25%;">
                                           <asp:Label ID="Test_No" runat="server"></asp:Label>
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
           </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
