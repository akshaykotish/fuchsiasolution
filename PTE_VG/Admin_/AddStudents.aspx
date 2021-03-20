<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="AddStudents.aspx.cs" Inherits="PTE_VG.AddStudents" %>
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
     <ContentTemplate>
           <div class="main animated pulse">
               <div class="m-section" style="background-color:white;">
                   <div class="header" style="padding:0.9%;">
                           <span style="font-size:15pt;">Add Student</span>
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
                                   Father Name 
                               </td>
                           </tr> 
                           <tr>
                               <td style="width:50%;">
                                   <asp:TextBox ID="Student_Name_box" runat="server" Placeholder="Name"></asp:TextBox>
                               </td>   
                               <td style="width:50%;">
                                   <asp:TextBox ID="Father_Name_box" runat="server" Placeholder="Father Name"></asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td style="width:50%;">
                                   Date of Birth
                               </td>
                               <td style="width:50%;">
                                   Date of Join
                               </td>
                          </tr> 
                          
                           <tr>
                            
                               <td style="width:50%;">
                                      <asp:TextBox ID="Date_Of_Birth" runat="server" TextMode="Date" Placeholder="Date Of Birth"></asp:TextBox>
                               </td>
                               <td style="width:50%;">
                                   <asp:TextBox ID="Date_Of_Join" runat="server" TextMode="Date" Placeholder="Date Of Join"></asp:TextBox>
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
                                   Batch
                               </td>
                           </tr>
                           <tr>
                               <td style="width:50%;">
                                   <asp:DropDownList ID="Institute" runat="server" Width="92%" Height="30px" Placeholder="Institute">
                                       
                                   </asp:DropDownList>
                              </td>
                               <td style="width:50%;">
                                   <asp:DropDownList ID="Batch" runat="server" Width="92%" Height="30px" Placeholder="Batch"></asp:DropDownList>
                               </td>
                           </tr>
                       </table>
                       <div>
                           <br />
                           <br />
                           <asp:Button ID="Add_Student" runat="server" CssClass="buttons" Text="Submit" OnClick="Add_Student_Click" />
                       </div>
                   </div>
               </div>
           </div>
</asp:Content>
