<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PTE_VG.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Kotish/dist/css/swiper.css" rel="stylesheet" />
    <link href="Kotish/dist/css/swiper.min.css" rel="stylesheet" />
    <link href="Kotish/Switch.css" rel="stylesheet" />
    <link href="Kotish/Glow.css" rel="stylesheet" />
    <link href="Kotish/Question.css" rel="stylesheet" />

    <style>
        .content{
            padding:3%;
            font-size:smaller;
        }
         input
        {
            margin:1%;
            padding:1%;
            border:solid 0.4px gray;
            
            width:89%;
            height:24px;
            background-color:white;
            color:gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main animated pulse">
               <div class="m-section" style="background-color:white;">
                   <div class="header" style="padding:0.9%;">
                           <span style="font-size:15pt;">My Profile</span>
                           <br />
                           <span style="font-size:x-small;" class="glow">Designed by <b>Akshay Kotish & Co.</b></span>
                       </div>
                   <div class="content">
                       <table>
                           <tr>
                               <td style="width:50%;">
                                   Name
                               </td>
                               <td style="width:50%;">
                                   
                               </td>
                           </tr> 
                           <tr>
                               <td style="width:50%;">
                                   <asp:TextBox ID="Admin_Name_box" runat="server" Placeholder="Name"></asp:TextBox>
                               </td>   
                               <td style="width:50%;">
                               
                               </td>
                           </tr>
                           <tr>
                               <td style="width:50%;">
                                   Contact
                               </td>
                               <td style="width:50%;">
                                   Email
                               </td>
                           </tr>
                           <tr>
                               <td style="width:50%;">
                                   <asp:TextBox ID="Contact" runat="server" TextMode="Phone" Placeholder="Contact"></asp:TextBox>
                               </td>
                               <td style="width:50%;">
                                   <asp:TextBox ID="Email" runat="server" TextMode="Email" Placeholder="Email"></asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td style="width:50%;">
                                   Institute
                               </td>
                               <td style="width:50%;">
                                   
                               </td>
                           </tr>
                           <tr>
                               <td style="width:50%;">
                                   <asp:TextBox ID="Institute" runat="server" Placeholder="Institute"></asp:TextBox>
                               </td>
                               <td style="width:50%;">
                               
                               </td>
                           </tr>
                           <tr style="background-color:whitesmoke;">
                               <td style="width:50%; text-align:right; font-size:small;">
                                Enter Password To Change
                               </td>
                               <td style="width:50%; text-align:left;">
                                   <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="40%" Placeholder="Password"></asp:TextBox>
                              </td>
                           </tr>
                           <tr>
                               <td style="width:50%; text-align:right;" >
                                <asp:Button ID="Update_Student" runat="server" CssClass="buttons" Text="Update" OnClick="Update_Student_Click" />
                           </td>
                               <td style="width:50%; text-align:left;">
                             <asp:Button ID="Logout" runat="server" CssClass="buttons" Text="Logout" BackColor="Red" ForeColor="White" OnClick="Logout_Click" />
                       </td>
                           </tr>
                       </table>
                   </div>
               </div>
           </div>
</asp:Content>
