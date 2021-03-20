<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Test_Page.aspx.cs" Inherits="PTE_VG.Test_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Kotish/Question.css" rel="stylesheet" />
    <style>
        .rec{
            text-align:center;
            width:100px;
            height:25px;
            padding:0.8%;
            background-color:green;
            color:white;
            box-shadow:none;
            box-shadow:1px 1px 3px gray;
            border-radius:4px 4px;
            cursor:pointer;
        }

        .rec:active{
            background-color:whitesmoke;
        }

        .stoprec{
           text-align:center;
            width:100px;
            height:25px;
            padding:0.8%;
            background-color:orangered;
            color:white;
            box-shadow:none;
            box-shadow:1px 1px 3px gray;
            border-radius:4px 4px;
            cursor:pointer;
        }

        .stoprec:active{
            background-color:whitesmoke;
        }


        .modal-content{
            width:30%;
            height:100px;
            box-shadow:2px 2px 5px gray;
            border-radius:8px;
        }
        .main{
            position:fixed;
            left: 3%;
            right:3%;
            top:4%;
            bottom:4%;
            font-family:Calibri;
            overflow:hidden;
        }

        .smallr{
            font-size:x-small;
            color:gray;
        }

        .fillboxclass{
            border:none;
            background-color:whitesmoke;
            border-bottom-style:solid;
            border-bottom-color:gray;
            border-bottom-width:1px;
            box-shadow:1px 1px 4px gray;
            font-size:smaller;
            padding:0.3%;
            border-radius:3px 2px;
            font-size:small;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrpt_mngr" runat="server" EnablePageMethods="true"></asp:ScriptManager>
         <div id="mbox" runat="server" class="main animated pulse" style="position:fixed; left:2%; right:2%;top:10%; bottom:10%;">
             <div class="header" style="padding:0.5%;">
                 <table style="width:100%;">
                     <tr style="width:100%; font-size:smaller; color:gray;">
                         <td style="width:40%;">
                             <span class="smallr">Assignment</span>
                         </td>
                         <td style="width:40%;">
                             <span class="smallr">Batch</span>
                         </td>
                         <td style="width:20%;">
                             <span class="smallr">Time</span>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <asp:Label ID="Test_Title" runat="server" >Test Name:- -</asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="Batch_Title" runat="server"> Batch:- -</asp:Label>
                         </td>
                         <td>
                             <label id="Clock_Duration" runat="server">-1</label> Seconds
                         </td>
                     </tr>
                 </table>
             </div>
             <div class="inn_box" style="padding:1%;">
             <span class="smallr">Question</span><br />
             <div id="questions">
                <asp:Label ID="Ques_Title" runat="server" Font-Bold="true" Font-Size="Large" Width="90%" style="height:auto; max-width:96%;" >Question 1</asp:Label><br />
                 <asp:Label ID="Ques_Text" runat="server" Font-Size="Medium" Width="99%">This is the following question</asp:Label><br />
                 <div style="padding:1%;">
                        <div ID="div_audio_pnl" runat="server">

                        </div>
                        <div ID="div_image_pnl" runat="server">

                        </div>             
                 </div>
             </div> 
           <span class="smallr">Answer</span>
             <div id="answers">
                 <div id="text" runat="server">
                     <span style="font-size:medium; font-weight:bold; text-transform:capitalize;">Write your answer here</span><br />
                    <asp:TextBox ID="Text_ans" runat="server" Width="100%" Height="100px" TextMode="MultiLine" style="box-shadow:1px 1px 3px gray; border:solid 1px lightgray; border-radius:5px; width:95%; padding:1%; background-color:whitesmoke;"></asp:TextBox>
                 </div>
                 <br />
                 <div id="MCQs" runat="server">
                        <span style="font-size:medium; font-weight:bold; text-transform:capitalize;">Check on your answer</span><br />
                        <asp:CheckBoxList ID="Mcq_chk_boxs" runat="server" Font-Size="Medium"></asp:CheckBoxList>
                 </div>
                      <br />
                 <div id="ansAudio" runat="server"> 
                     <span style="font-size:medium; font-weight:bold; text-transform:capitalize;">Record Your Answer Here</span><br />
                       <audio id="audio_rec" src="#"></audio>
                       <div id="rec" class="rec" onclick="rec_audio();">Record</div>
                       <div id="stp" class="stoprec" onclick="stop_rec();">Stop</div>
                </div>
                      <br />
                <div id="fillups" runat="server">
                     <span style="font-size:medium; font-weight:bold; text-transform:capitalize;">Answer your fill ups</span><br />
                       <asp:UpdatePanel ID="fill_up_updt" runat="server">
                       <ContentTemplate>
                            <asp:Panel ID="fill_up_panel" runat="server" Font-Size="13pt" style="line-height: 16pt;">

                            </asp:Panel>
                       </ContentTemplate>
                       </asp:UpdatePanel>
                </div>
                      <br />
                <div class="sumbmt">
                    <span style="font-size:medium; font-weight:bold; text-transform:capitalize;">Lets Submit</span><br />
                       <div  class="rec" onclick="call_submit_btn()" style="background-color:whitesmoke; border:solid 1px whitesmoke; color:black;">Submit</div>
                       <asp:Button ID="Submit_Question_Btn" CssClass="buttons" runat="server" Text="Submit" OnClick="Submit_Question_Btn_Click" Visible="false" />
                    <br />
                </div>
             </div>
             </div>
            </div>
         </div>
        <asp:Panel ID="pnl" runat="server">

        </asp:Panel>
    <input id="fill_inpt" type="text" style="display:none;"/>
    <asp:HiddenField ID="fill_hdn" runat="server" />
    <asp:HiddenField ID="audio_blob" runat="server" />
    <asp:HiddenField ID="live_time" runat="server" />
    
    
    <asp:Button ID="Time_Btn" runat="server" Width="0px" Height="0px" OnClick="Time_Btn_Click" />
    <script>
        function fill_ups_ans() {
            var fill_up_s = document.getElementsByClassName("fillboxclass");
            var fill_in = document.getElementById("fill_inpt");
            var fill_hdn = document.getElementById('<%=fill_hdn.ClientID%>');
            var out = "";
            for (var i = 0; i < fill_up_s.length; i++) {
                out = out + fill_up_s[i].value + ";";
            }
            fill_hdn.value = out;
        }

        var myVar = setInterval(myTimer, 1000);

        function myTimer() {
            fill_ups_ans();

            var tm = Number(document.getElementById('<%= Clock_Duration.ClientID%>').innerText);
    
            if (Number(tm) > 0) {
                tm--;
            } else if (tm == 0) {
                stop_rec();
                var a = setTimeout(call_submit_btn, 3000);
            }
            document.getElementById('<%= live_time.ClientID %>').value = tm;
            document.getElementById('<%= Clock_Duration.ClientID%>').innerHTML = tm;
            
        }

        function call_submit_btn() {
                    <%= Page.ClientScript.GetPostBackEventReference(Time_Btn, String.Empty) %> ;
        }



        var recordedChunks;
        var strm;
        var mediarecord;

        var audio_rc = document.getElementById("audio_rec");

        var rec_btn = document.getElementById("rec");
        var stp_btn = document.getElementById("stp");
        stp_btn.style.display = "none";
        function rec_audio() {
            rec_btn.style.display = "none";
            stp_btn.style.display = "block";
            navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUsermedia || navigator.mozGetUserMedia || navigator.msGetUserMedia || navigator.oGetUserMedia;

            if (navigator.getUserMedia) {
                navigator.getUserMedia({
                    audio: true
                }, handleAudio, videoError);
            }
        }

        function handleAudio(stream) {
            recordedChunks = [];
            mediarecord = new MediaRecorder(stream);
            mediarecord.ondataavailable = handleDataAvailable;
            mediarecord.start();
        }


        function videoError(e) {

        }

        var cnt = 0;
        function stop_rec() {

            mediarecord.stop();
            if (mediarecord.state == "inactive") {
                let blob = new Blob(recordedChunks);
                audio_rc.src = URL.createObjectURL(blob);
                audio_rc.controls = true;
                audio_rc.autoplay = true;

                var xhr = new XMLHttpRequest();
                xhr.onload = function (e) {
                    var result = e.target.result;
                };

                xhr.open('POST', '/SaveF.aspx?cnt=' + cnt, true);
                xhr.send(blob);

                rec_btn.style.display = "block";
                stp_btn.style.display = "none";
                cnt = cnt + 1;
                if (cnt == 2) {
                    cnt = 0;
                }
                else {
                    alert("Audio is Recorded and Saved...");
                    //console.log("Recorded.");
                    stop_rec();
                }
            }
            else {
            }
        }

        function handleDataAvailable(event) {
            if (event.data.size > 0) {
                recordedChunks.push(event.data);

            } else {
                // ...
            }
        }


        function auto_test() {
            rec_audio();
            stop_rec();
        }
                  //  window.onload = auto_test;


    </script>
</asp:Content>
