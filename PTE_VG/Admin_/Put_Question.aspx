<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Put_Question.aspx.cs" Inherits="PTE_VG.Put_Question" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Swiper demo</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1">
    <link href="Kotish/animate.css" rel="stylesheet" />
    <link href="Kotish/Design.css" rel="stylesheet" />
    <link href="Kotish/Glow.css" rel="stylesheet" />
    <link href="Kotish/ODA.css" rel="stylesheet" />
    <link href="Kotish/Reponsive.css" rel="stylesheet" />
    <link href="Kotish/Question.css" rel="stylesheet" />
    <link href="Kotish/Tab.css" rel="stylesheet" />
    <link href="Kotish/Switch.css" rel="stylesheet" />
    <link rel="stylesheet" href="../dist/css/swiper.min.css">
    <link href="Kotish/swiper-4.3.5/dist/css/swiper.min.css" rel="stylesheet" />
    <link href="Kotish/DDUpload.css" rel="stylesheet" />

    <style>
body {
    font-family: 'Questrial', sans-serif, Helvetica, sans-serif;
    background:none;
    background-color:whitesmoke;
}

.Sheet{
    margin:6%;
    padding:6%;
    border-radius:5px;
    
    box-shadow:5px 5px 5px gray;
    background-color:white;
   font-family:'Questrial', sans-serif;
   font-size:small;
            outline:none;
}

.mnstrm{
   padding:2%;
   border-radius:5px;
   margin:2%;
   color:black;
}

.comp_ttl{
    position:relative;
    font-size:30pt;
    text-align:left;
    font-weight:bold; 
    padding:0;
    margin:0;
    margin-left:-5%;
}

h4{
    color:dimgray;
    text-shadow:1px 1px whitesmoke;
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
            outline:none;
        }
</style>
</head>
<body>

        <div class="Sheet">
                <div class="fs comp_ttl ">
                 Fhusia Solutions
            </div>
            <br />
            <div>
                <div style="font-size:small; letter-spacing:3px;">Create Question</div>
            </div>
            <div>
                <h4>Question Title</h4>
                <input id="ttl_box" runat="server" type="text" placeholder="Question Title" />
            </div>
            <div>
                <h4>Question Type</h4>
                <select id="question_type" runat="server">
                    <option value="Reading">Reading</option>
                    <option value="Listening">Listening</option>
                    <option value="Writing">Writing</option>
                    <option value="Speaking">Speaking</option>
                  </select>
            </div>
            <br />
            <div>
                <h4>Write question text here</h4>
                <textarea id="input_qs" runat="server" placeholder="Enter your question text here.." style="width:98.5%; height:10vh; font-family:'Questrial', sans-serif;" onchange="Update_Text()"></textarea> 
            </div>   
            <br />
            <div>
              <h4>Accept Text Answer</h4>
                <label class="switch">
                      <input id="text_ans" runat="server" type="checkbox" onchange="Accept_Text()" >
                      <span class="slider round"></span>
                    </label>    
            </div>
                <br />
            <div>
                <h4>Upload Files</h4>
                <form runat="server">
                      <asp:ScriptManager ID="Scrpt" runat="server" EnablePageMethods="true"></asp:ScriptManager>
                         <table style="width:100%;">
                             <tr style="width:100%;">
                                 <td id="audio_upld_area" class="dropzone audio" style="width:50%; overflow:hidden; height:50px; vertical-align:top;" >
                                      <input id="audio_files" type="file" accep="audio/*" onchange="Upload_Audio()"/>
                                        <hr />
                                     <div id="aud-msg" class="upld-btm">
                                         Drop to upload audio
                                     </div>
                                 </td>
                                 <td class="dropzone img" style="width:50%; overflow:hidden; vertical-align:top; height:50px;" id="img_upld_area">
                                      <input id="img_files" type="file" accep="image/*" onchange="Upload_Img()" />
                                   <hr />
                                     <div id="img-msg" class="upld-btm">
                                         Drop to upload image
                                     </div>
                                 </td>
                             </tr>
                         </table>
                    </form>
            </div>
            <br />
            <div>
               <h4>MCQs</h4>
                 <div>
                  <table style="border-width:1px; border-style:solid; border-color:gray; overflow:hidden;margin:1%; width:66%; height:20px; font-size:small; border-radius:7px; background-color:white;">
                      <tr style="width:100%;">
                          <td style="font-weight:bold; width:20%; text-align:center;">Option</td>
                          <td style="width:40%;">
                              <input type="text" id="mcq_txt" runat="server" placeholder="Enter your MCQ here..." style="width:90%; height:20px; background-color:white; border:none; box-shadow:none;" />
                          </td>
                          <td style="text-align:right; width:15%; font-weight:bold;">
                              Answer
                          </td>
                          <td style="width:10%;">
                            <input id="ans_box" runat="server" type="checkbox" style="background-color:white; color:black;" />
                        </td>
                          <td style="width:15%;padding:1%; margin:-1%; margin-left:-1%; margin-right:-1%; margin-top:-1%; margin-bottom:-1%; background-color:whitesmoke; border-bottom-right-radius:5px; border-top-right-radius:5px; cursor:pointer; text-align:center;" onclick="Add_MCQ()">
                              Confirm
                          </td>
                      </tr>
                  </table>
                 
              </div>
              <div id="MCQs" runat="server" style="margin:1%; width:96%; box-shadow:3px 3px 6px gray; border-radius:7px; background-color:white;">
                  
              </div>
            </div>
            <br />
            <div>
              <h4>Accept Audio Answer</h4>
                <label class="switch">
                      <input id="aud_ans" runat="server" type="checkbox" onchange="Accept_Audio()" >
                      <span class="slider round"></span>
                    </label>    
            </div>
            <br />
            <div>
               <h4>Fill Ups</h4>
                <div>
                    <span style="font-size:medium; color:whitesmoke; text-shadow:1px 1px black;"></span> <span onclick="fill_up_text()" class="buttons" style="font-size:small; padding:1%; padding-left:4%; padding-right:4%; box-shadow:2px 2px 6px gray;">Insert Fill up</span>
                    <br />
                    <br />
                    <textarea id="fill_up_box" runat="server" onchange="Update_Fill_Up()" style="margin:1%; width:94%; height:100px; padding:1%; border-radius:7px; background-color:white; outline:none; font-family:'Questrial', sans-serif;" placeholder="Enter your fill ups here" ></textarea>
                 </div>     
            </div>
            <br />
            <div>
                <h4>Marking Scheme</h4>
                <div>
                   <table style="border-width:1px; border-style:solid; border-color:gray; overflow:hidden;margin:1%; width:66%; height:20px; font-size:small; border-radius:7px; background-color:white;">
                      <tr style="width:100%;">
                         <td style="width:45%;"><input id="mrk_nm" type="text" placeholder="Scheme Name" style="border:none;"/></td>
                         <td style="width:45%;"><input id="mrk_vl" type="text" placeholder="Scheme Value" style="border:none;"/></td>
                         <td style="width:10%; cursor:pointer; text-align:center; background-color:whitesmoke;" onclick="Marks()">Add</td>
                      </tr>
                  </table>
               <div id="marks_view" runat="server" style="margin:1%; width:94%; padding:1%; border-radius:7px; background-color:white;" placeholder="Marking Schemes here..">

               </div>
                </div>
            </div>
            <br />
            <div>
                <h4>Time Duration</h4>
                <input id="dur_box" runat="server" type="number" style="width:20%; height:20px; padding:1%;" placeholder="Duration" /> Seconds
            </div>
            <br />
            <div>
                <div class="buttons" style="width:100px; height:20px; text-align:center; background-color:slategrey; color:white; border:solid 1px white; font-size:large;" onclick="Update_Details()" >Save</div>
                <div id="alert" style="color:red;">
                
                </div>
            </div>
        </div>

        <script src="../Kotish/Scripts/Question.js"></script>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
    </div>
    <!-- Swiper JS -->
    <script src="Kotish/swiper-4.3.5/dist/js/swiper.min.js"></script>
    <!-- Initialize Swiper -->
    <script>
    var swiper = new Swiper('.swiper-container', {
        direction: 'vertical',
        slidesPerView: 1,
        spaceBetween: 30,
        mousewheel: true,
        pagination: {
          el: '.swiper-pagination',
          clickable: true,
        },
    });
    </script>
        
</body>
</html>

