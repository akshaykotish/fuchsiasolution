<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="PTE_VG.Question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Kotish/dist/css/swiper.css" rel="stylesheet" />
    <link href="Kotish/dist/css/swiper.min.css" rel="stylesheet" />
    <link href="Kotish/Switch.css" rel="stylesheet" />
    <link href="Kotish/Glow.css" rel="stylesheet" />
    <link href="Kotish/Question.css" rel="stylesheet" />
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
 
           <div class="animated pulse main">
               <div class="m-section" style="background-color:white; height:100%;">
                   <iframe src="Put_Question.aspx?Create_Question=TRUE&Keyword=OMNI" style="width:100%; height:100%; border:none; overflow:hidden;"></iframe>
               </div>
           </div>
</asp:Content>
