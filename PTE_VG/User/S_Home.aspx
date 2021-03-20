<%@ Page Title="" Language="C#" MasterPageFile="~/User/Student.Master" AutoEventWireup="true" CodeBehind="S_Home.aspx.cs" Inherits="PTE_VG.S_Home" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
          .date{
        position:fixed;
        left:6%;
        top:14%;
        font-size:40pt;
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
        text-shadow:1px 1px 4px gray;
        font-weight:bold;
        text-align:center;
        width:100px;
        text-transform:uppercase;
    }
    
    .search-areas {
        border-radius: 5px;
        background-color: white;
        overflow: hidden;
        outline: none;
        position:fixed;
        top:10%;
        right:35%;
        left:20%;
    }
    
    .Search-Console {
        border: none;
        height: 20px;
        width: 89%;
        outline: none;
        padding: 1%;
        border-bottom-left-radius: 4px;
        border-top-left-radius: 4px;
        background-color:whitesmoke;
    }

    .assignments{
       position:fixed;
       left:20%;
       right:0.5%;
       top:18%;
       bottom:10%;
       border-radius:7px;
       overflow:auto;
       padding:1%;
    }

    .sugar{
        position:relative;
        width:100%;
        display: inline-flex;
        flex-direction: row;
        justify-content: flex-start;
        flex-flow: wrap;
        display: normal;
        overflow: hidden;
    }

    .asgnmnt{
        padding:1%;
        background-color:white;
        border:none;
        box-shadow:1px 1px 4px gray;
        height:80px;
        width:300px;
        text-align:center;
        border-radius:8px;
        margin:2%;
        background-color:white;
        overflow:hidden;
        cursor:pointer;
        display: block;
        box-sizing: border-box;
        overflow: hidden;
    }

    .hdr{
        font-size:smaller;
        text-transform:capitalize;
        height:30%;
        color:gray;
        overflow:hidden;
    }

    .cntnt{
        font-size:medium;
        font-weight:bold;
        height:53%;
        overflow:hidden;
    }

        .percent {
            overflow: hidden;
            height: 20%;
            
        }

    .dates{
        font-size:medium;
        width:100%;
        color:white;
    }

    .flowerpot{
        position:fixed;
        width:300px;
        height:400px;
        bottom:10%;
        left:5%;
        background-image:url('Images/Icons/TreePot.png');
        background-position:center;
        background-size:contain;
        background-color:none;
        background-repeat:no-repeat;
    }

    .reportbtn{
        display:none;
    }

    @media only screen and (max-width:600px)
    {

        .search-areas{
            margin:0;
            position:fixed;
            left:1%;
            right:1%;
            top:10%;
        }

        .time{
            display:none;
        }

        .assignments{
            position:fixed;
            top:15%;
            left:1%;
            right:1%;
            bottom:8%;
        }

        .asgnmnt{
        padding:1%;
        background-color:white;
        border:none;
        box-shadow:1px 1px 4px gray;
        height:100px;
        width:100%;
        text-align:center;
        border-radius:8px;
        margin:2%;
        background-color:white;
        overflow:hidden;
        cursor:pointer;
        display: block;
        box-sizing: border-box;
        overflow: hidden;
        }

        .reportbtn{
            display:block;
           position:fixed;
           right:5%;
           top:20%;
           z-index:4;
           color:white;
        }
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div>
        <div id="time" class="time">
            <span id="date" class="date">
                
            </span>
            <br />
            <span id="month" class="month">
           </span>
        </div>
        <div class="reportbtn" onclick="navigate_to('Result.aspx')">
            Get Result
        </div>
      <div class="search-areas">
                <asp:TextBox ID="Search_Batch_Test_Console" runat="server" CssClass="Search-Console" Placeholder="Search Your Assignment" Width="68%"  Height="30px" BackColor="WhiteSmoke" ></asp:TextBox>
                <asp:Button ID="Search_Batch_Test_Btn" runat="server" CssClass="Search-Btn" Text="Search" Width="10%" Height="30px" ForeColor="Gray" OnClick="Search_Batch_Test_Btn_Click"/>
            </div> 
        <div id="assignments" runat="server" class="assignments animated pulse">
              
        </div>
    </div>
    <asp:HiddenField ID="Batch_Test_IDFld" runat="server" />
    <asp:Button ID="CHng_Pg" runat="server" OnClick="CHng_Pg_Click" Width="0px" Visible="false"  />
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
          

          function topush(e) {
              
              document.getElementById('<%= Batch_Test_IDFld.ClientID%>').value = e;
               <%= Page.ClientScript.GetPostBackEventReference(CHng_Pg, String.Empty) %> ;
          }

            function onSucess(result) {
                //alert(result);
            }

            function onError(result) {
                alert('Cannot process your request at the moment, please try later.');
            }
          
            function navigate_to(e) {
                window.location.replace(e);
            }
    </script>
</asp:Content>
