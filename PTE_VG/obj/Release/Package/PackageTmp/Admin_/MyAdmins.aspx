<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="MyAdmins.aspx.cs" Inherits="PTE_VG.MyAdmins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Kotish/dist/css/swiper.min.css" rel="stylesheet" />
    <link href="Kotish/Switch.css" rel="stylesheet" />
    <link href="Kotish/Glow.css" rel="stylesheet" />
    <link href="Kotish/Question.css" rel="stylesheet" />
    <link href="Kotish/Modal.css" rel="stylesheet" />

    <style>
        .main{
            left: 10%;
            right:10%;
            overflow:hidden;
        }

        
        .search_area{

        }

        .modal-content{
            width:30%;
            height:100px;
            box-shadow:2px 2px 5px gray;
            border-radius:8px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main animated pulse">
        <div class="header">
            Question Finder
        </div>
        <div class="search-area" style="background-color:whitesmoke;">
            <asp:TextBox ID="Search_Console" runat="server" CssClass="Search-Console" Placeholder="Type to find" Width="74%" Height="15px" ></asp:TextBox>
            <asp:Button ID="Find_Btn" runat="server" CssClass="Search-Btn" Text="Find" ForeColor="Gray" BackColor="WhiteSmoke" Width="10%" OnClick="Find_Btn_Click" /> 
            <asp:Button ID="Create_Question" runat="server" CssClass="Search-Btn" Text="Create" BackColor="WhiteSmoke" ForeColor="Gray" Width="10%" OnClick="Create_Question_Click" />
        </div>
        <div style="overflow:auto; overflow-x:hidden; height:70%; padding:1%;">
            <asp:GridView ID="All_Admins" runat="server" AutoGenerateColumns="false" BorderStyle="None" ShowHeader="true" GridLines="None" OnRowDataBound="All_Admins_RowDataBound" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table class="grid-head">
                                    <tr style="text-align:center;">
                                        <td style="width:12.5%;">
                                            Name
                                        </td>
                                       <td style="width:12.5%;">
                                            Contact
                                        </td>
                                        <td style="width:12.5%;">
                                            Email
                                        </td>
                                       <td style="width:12.5%;">
                                            Institute
                                        </td>
                                        <td style="width:12.5%; text-align:center;">
                                            Status 
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table class="grid-content">
                                    <tr>
                                        <td style="width:12.5%;">
                                            <asp:Label ID="Student_Name" runat="server"></asp:Label>
                                        </td>
                                       <td style="width:12.5%; text-align:center;">
                                           <asp:Label ID="Contact" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:12.5%; text-align:center;">
                                           <asp:Label ID="Email" runat="server"></asp:Label>
                                       </td>
                                       <td style="width:12.5%; text-align:center;">
                                          <asp:Label ID="Institute" runat="server"></asp:Label>
                                       </td>
                                        <td style="width:12.5%; text-align:center;">
                                            <asp:Button ID="Change_Status" runat="server" CssClass="buttons" Text="Remove" BorderStyle="None" OnCommand="Change_Status_Command" />                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
    </div>

    <div id="myModal" class="modal">
          <div class="modal-content">
                <span class="close">&times;</span>
            <p>Do you want to remove this question ?</p>
              <asp:Button ID="Confirm_Remove" runat="server" Text="Yes" CssClass="buttons" BackColor="Red" ForeColor="White" Width="100px" BorderStyle="None" />
          </div>
    </div>
    <asp:HiddenField ID="Ques_ID" runat="server" />
    <script src="Kotish/Modal.js"></script>
</asp:Content>
