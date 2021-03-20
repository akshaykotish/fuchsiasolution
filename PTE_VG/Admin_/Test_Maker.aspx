<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Test_Maker.aspx.cs" Inherits="PTE_VG.Test_Maker" EnableEventValidation="false" %>
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
    <link href="../Kotish/Styles/Awesome/Tests_Class.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Awesome/Create_Section.css" rel="stylesheet" />
    <link href="../Kotish/Styles/Awesome/Properties.css" rel="stylesheet" />
    <script src="../Kotish/Scripts/Awesome/Mid_Cards.js"></script>
    <script src="../Kotish/Scripts/Awesome/Tests_Cards.js"></script>
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
        <div class="Text" onclick="load_createSection()">
             Add New Test
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
    <%--<div>

        <div class="container">
            <div class="awesome_box">
                <div class="fhusi_box">
                    <div class="title_box">
                        Sample Question
                    </div>
                </div>
                <div class="content_box">
                    <div class="content_box_left">
                        <div class="content_box_left_content">
                            <div class="content_box_left_content_big_number">
                                R
                            </div>
                            <div class="content_box_left_content_heading">
                                Reading
                            </div>
                        </div>
                        
                    </div>
                    <div class="content_box_right">
                        <div class="content_box_right_content">
                            <div class="content_box_right_content_section">
                                <div class="content_box_right_content_section_heading">
                                    A
                                </div>
                                <div class="content_box_right_content_section_value">
                                    a
                                </div>
                                <div class="content_box_right_content_section_heading">
                                    B
                                </div>
                                <div class="content_box_right_content_section_value">
                                    b
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <script>
        window.onload = function () {
            Load_Test('ALL');
        }
    </script>
</asp:Content>
