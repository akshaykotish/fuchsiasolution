<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="PTE_VG.Questions" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Loading_win{
            position:fixed;
            top:0;
            left:0;
            bottom:0;
            right:0;
            text-align:center;
            background-color:#808080;
            vertical-align:central;
            z-index:1000;
            opacity:0.7;
            height:100%;
            width:100%;
        }
    </style>
    <link href="../Kotish/Styles/Awesome/Add_New.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Awesome/Search_Section.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Awesome/Mid_Cards.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Change_Modal.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Awesome/Stud_Class.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Awesome/Create_Section.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Awesome/Properties.css" rel="stylesheet" />
    <script src="../Kotish/Scripts/Awesome/Mid_Cards.js"></script>
    <script src="../Kotish/Scripts/Awesome/Stud_Cards.js"></script>
    <script src="../Kotish/Scripts/Awesome/Create_Section.js"></script>
    <script src="../Kotish/Scripts/Awesome/Properties.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div id="winld" class="Loading_win">
        <div style="height:45%; width:100%;">

        </div>
        <img src="../Images/Icons/Loading.gif" width="40" height="40" />
    </div>
    <div class="Search_Section">
        <input id="Search_box" type="text" placeholder="Search Batches" onkeyup="Search_Batches('ALL')" />
    </div>

    <div class="Add_New_Section">
        <div class="Plus_btn">
            +
        </div>
        <div class="Text" onclick="Create_Question()">
             Add New Batch
        </div>
    </div>
    <div id="Awesome_Area">

    </div>
    <div class="chng" id="chng_area">
        <div class="close" onclick="close_chng()">
            X
        </div>
        <div id="Stud_Area">

        </div>
    </div>
    <div id="propts" class="propts">
        <div class="close" onclick="close_propts()">
            X
        </div>
        <div id="Properties_Area">

        </div>
    </div>
    <script>
        window.onload = function () {
            Load_Question('ALL');
            setTimeout(function () {
                document.getElementById("winld").style.display = "none";
        }, 500);
        }
    </script>
</asp:Content>