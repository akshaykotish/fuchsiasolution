<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PTE_VG.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .time{

    }

    .date{
        position:fixed;
        left:6%;
        top:14%;
        font-size:40pt;
        color:black;
        text-shadow:1px 1px 4px gray;
        font-weight:bold;
        text-align:center;
        width:100px;
    }

    .month{
        position:fixed;
        left:6%;
        top:22%;
        font-size:20pt;
        color:black;
        text-shadow:1px 1px 4px gray;
        font-weight:bold;
        text-align:center;
        width:100px;
        text-transform:uppercase;
    }

    .status{
        width:500px;
        height:300px;
        position:fixed;
        left:42%;
        top:18%;
        color:black;
        font-size:medium;
    }

    .all_status {
        font-size: small;
        font-weight: bold;
        color: gray;
        text-transform: capitalize;
        letter-spacing: 1px;
        text-shadow: none;
        background-color: white;
        border-radius: 5px;
        width: 150px;
        height: 15px;
        overflow: hidden;
        margin: 3%;
        text-align: center;
        padding: 3%;
        padding-left:10%;
        background-position:left;
        background-position-x:4%;
        background-size:15%;
        background-repeat:no-repeat;
        box-shadow:1px 1px 1px gray;
        border:solid 3px whitesmoke;
    }

    .fhusia{
        position:fixed;
        right:5%;
        bottom:40%;
        font-size:70pt;
        height:40px;
        left:0;
        text-align:right;
        font-weight:bold;
        color:white;
        font-family: 'Josefin Sans', sans-serif;
        text-shadow: 0 0 20px #FFFAF0, 0 0 30px #FFAE42, 0 0 40px #FBE870, 0 0 50px #FBE7B2, 0 0 60px #F8D568, 0 0 70px #FFEB00, 0 0 80px #FFFAF0F66;
        -webkit-animation: fhusia 5s ease-in-out infinite alternate;
        -moz-animation: fhusia 5s ease-in-out infinite alternate;
        animation: fhusia 5s ease-in-out infinite alternate;

    }
    
    
@-webkit-keyframes fhusia {
    from {
        text-align:right;
        color:white;
        opacity:0.9;
   }

    to {
        text-align:right;
        opacity:1;
        color:white;
        text-shadow: 0 0 20px #FFFAF0, 0 0 30px #87CEFA, 0 0 40px #87CEFA, 0 0 50px #87CEFA, 0 0 60px #87CEFA, 0 0 70px #87CEFA, 0 0 80px #87CEFA;
    }
}


 .biglogo{
        background-image:url('Images/Icons/biglogo.png');
        background-position:center;
        background-size:contain;
        background-repeat:no-repeat;
        position:fixed;
        right:5%;
        top:15%;
        bottom:15%;
        font-size:70pt;
        left:60%;
        text-align:right;
        font-weight:bold;
        color:white;
        font-family: 'Josefin Sans', sans-serif;
        text-shadow: 0 0 20px #FFFAF0, 0 0 30px #FFAE42, 0 0 40px #FBE870, 0 0 50px #FBE7B2, 0 0 60px #F8D568, 0 0 70px #FFEB00, 0 0 80px #FFFAF0F66;
        -webkit-animation: fhusia 5s ease-in-out infinite alternate;
        -moz-animation: fhusia 5s ease-in-out infinite alternate;
        animation: fhusia 5s ease-in-out infinite alternate;
 }

    .menubox{
        width:0;
        height:0;
        display:none;
    }

    @media only screen and (max-width:600px) {
           .status{
               display:none;
           }

           .biglogo{
               display:none;
           }

           .fhusia{
               display:none;
           }

           .menubox{
               position:fixed;
               top:27%;
               left:2%;
               right:2%;
               bottom:13%;
               display:block;
           }

           .mbox
           {
               position:fixed;
               width:33%;
               height:13%;
               border-radius:8px;
               background-position:center;
               background-size:60%;
               background-repeat:no-repeat;
               vertical-align:text-bottom;
               vertical-align:bottom;
               vertical-align:baseline
           }

           .mboxtxt{
               margin-top:70%;
               text-align:center;
               color:darkslategray;
               font-size:large;
               font-family:'Questrial', sans-serif;
           }

           .date{
               left:38%;
           }
           .month{
               left:38%;
           }

    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="time" class="time">
            <span id="date" class="date">

            </span>
            <br />
            <span id="month" class="month">
           </span>

        </div>
    <div class="status">
             <p>Welcome <asp:Label ID="User_lbl" runat="server" ForeColor="Black" >Akshay Kotish</asp:Label> </p>
        <h1>Pearson Test of English</h1>        
        
        <p>
            <h4>Scored Practice Tests</h4>
Our official online practice tests are the best practice you can get with fast results.

The scored practice test is timed and scored just like the real PTE Academic test, so you get the best sense of how you will need to perform on test day.

Please note:

The tests are for practice only and you will NOT receive an accredited result.
Before you purchase a test, we recommend you check if your computer is compatible</p>
    </div>

    <div class="menubox">
        <div class="mbox" style="top:32%; left:10%; background-image:url('Images/Icons/question.png');" onclick="navigate_to('Questions.aspx')">
            <div class="mboxtxt">Question</div>
        </div>
        <div class="mbox" style="top:32%; right:10%; background-image:url('Images/Icons/batch.png');" onclick="navigate_to('Batches.aspx')">
            <div class="mboxtxt">Batch</div>
        </div>
        <div class="mbox" style="top:52%; left:10%; background-image:url('Images/Icons/Assignment.png');" onclick="navigate_to('Test_Maker.aspx')">
            <div class="mboxtxt">Assignment</div>
        </div>
        <div class="mbox" style="top:52%; right:10%; background-image:url('Images/Icons/Assign.png');" onclick="navigate_to('Test_Assign.aspx')">
            <div class="mboxtxt">Assign</div>
        </div>
        <div class="mbox" style="top:72%; left:10%; background-image:url('Images/Icons/check.png');" onclick="navigate_to('Test_Checker.aspx')">
            <div class="mboxtxt">Check</div>
        </div>
        <div class="mbox" style="top:72%; right:10%; background-image:url('Images/Icons/student.png');" onclick="navigate_to('MyStudents.aspx')">
            <div class="mboxtxt">Students</div>
        </div>
    </div>

    <script>
        var time = document.getElementById("time");
        var date = document.getElementById("date");
        var month = document.getElementById("month");
        var d = new Date();
        date.innerText = d.getDate();
        var m = d.getMonth();
        switch (m) { 
            case 0:
                month.innerText = "January";
                break;
            case 1:
                month.innerText = "Febuary";
                break;
            case 2:
                month.innerText = "March";
                break;
            case 3:
                month.innerText = "April";
                break;
            case 4:
                month.innerText = "May";
                break;
            case 5:
                month.innerText = "June";
                break;
            case 6:
                month.innerText = "July";
                break;
            case 7:
                month.innerText = "August";
                break;
            case 8:
                month.innerText = "September";
                break;
            case 9:
                month.innerText = "October";
                break;
            case 10:
                month.innerText = "November";
                break;
            case 11:
                month.innerText = "December";
                break;
        }

        function navigate_to(e) {
            window.location.replace(e);
        }
    </script>
</asp:Content>
