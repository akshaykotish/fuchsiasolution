<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sheets.aspx.cs" Inherits="PTE_VG.Sheets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Kotish/Reponsive.css" rel="stylesheet" />
    <link href="Kotish/ODA.css" rel="stylesheet" />
    <link href="Kotish/animate.css" rel="stylesheet" />
    <link href="Kotish/Design.css" rel="stylesheet" />
    <link href="Kotish/Switch.css" rel="stylesheet" />
    <link href="Kotish/Glow.css" rel="stylesheet" />
    <link href="Kotish/Question.css" rel="stylesheet" />
    <script src="Kotish/Question.js"></script>
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
    text-decoration:underline;
}
</style>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updtpnl" runat="server">
        <ContentTemplate>
        <div class="Sheet animated pulse">
            <div class="fs comp_ttl ">
                 Fhusia Solutions
            </div>
            <br />
            <br /> 
            <div>
                <div style="font-size:small; letter-spacing:3px;">Test Paper Title</div>
                <h2><asp:Label ID="Sheet_title" runat="server">Test 1</asp:Label></h2>
            </div>
            <br />
            <br /> 
            
            <table id="studentdtl" runat="server" style="width:100%; padding:1%; border:solid 1px whitesmoke; border-radius:6px; box-shadow:4px 4px 8px whitesmoke;">
            <tr style="width:100%; ">
                <td style="width:7%; font-size:small; letter-spacing:3px;">
                   Student<br /><br />
                </td>
                <td style="width:18%; text-align:left; letter-spacing:3px;">
                   Details<br /><br />
                    
                </td>
                <td style="width:7%;">
                    
                </td>
                <td style="width:18%;">
                    
                    </td>
                <td style="width:7%;">
                    
                </td>
                <td style="width:18%;">
                   
                </td>
                <td style="width:7%;">
                   
                </td>
                <td style="width:18%;">
                    
                </td>
            </tr>
                <tr style="width:100%;">
                <td style="width:7%; text-align:right;">
                    Name :-
                </td>
                <td style="width:18%; ">
                    <asp:Label ID="Sheet_Name" runat="server" Font-Bold="true" ForeColor="Gray">Test Date</asp:Label>
                </td>
                <td style="width:7%; text-align:right;">
                    Contact :-
                </td>
                <td style="width:18%;">
                    <asp:Label ID="Sheet_Contact" runat="server" Font-Bold="true" ForeColor="Gray">Test Date</asp:Label>
                </td>
                <td style="width:7%; text-align:right;">
                    Email :-
                </td>
                <td style="width:18%;">
                    <asp:Label ID="Sheet_Email" runat="server" Font-Bold="true" ForeColor="Gray">Test Date</asp:Label>
                </td>
                <td style="width:7%; text-align:right;">
                    Date :-
                </td>
                <td style="width:18%;">
                    <asp:Label ID="Sheet_Date" runat="server" Font-Bold="true" ForeColor="Gray">Test Date</asp:Label>
                </td>
            </tr>
        </table>
            <br /><br /><br /><br />
            <div style="width:100%; border:solid 1px whitesmoke; border:solid 1px whitesmoke; border-radius:6px; box-shadow:4px 4px 8px whitesmoke;">
            <asp:GridView ID="All_Questions" runat="server" Width="100%" OnRowDataBound="All_Questions_RowDataBound" AutoGenerateColumns="false" ShowHeader="false" GridLines="None" OnRowCommand="All_Questions_RowCommand">
              <Columns>
                  <asp:TemplateField>
                      <ItemTemplate>
                          <div class="mnstrm">
                            <table style="width:90%;">
                              <tr style="width:100%;">
                                  <td style="width:10%; text-align:left; vertical-align:top;">
                                      <asp:Label ID="Serial_Number" runat="server" Font-Bold="true"></asp:Label>
                                  </td>
                                  <td style="width:85%;">
                                      <asp:Label ID="Question_Title" runat="server" Font-Bold="true"></asp:Label>
                                      <div>
                                              <div ID="ques_text_pnl" runat="server" style="font-weight:bold;">
                          
                                              </div>       
                                                <div ID="ques_img_pnl" runat="server">

                                                </div>
                                               <div ID="ques_audio_pnl" runat="server">

                                                </div>
                                              <div ID="ques_mcq_pnl" runat="server">
                          
                                              </div>       
                                              <div ID="ques_fill_up_pnl" runat="server">
                          
                                              </div>         
                                             </div> 
                                  </td>
                                  <td>

                                  </td>
                              </tr>
                                </table>
                              <br />
                          <table style="width:90%;">
                              <tr>
                                  <td style="width:10%; vertical-align:top;">
                                      Answer
                                  </td>
                                  <td style="width:85%;">
                                      <div ID="ans_audio_pnl" runat="server" style="width:100%;">

                                        </div>
                                      <div ID="ans_text_pnl" runat="server" style="width:100%;">
                          
                                      </div>       
                                      <div ID="ans_mcq_pnl" runat="server" style="width:100%;">
                          
                                      </div>       
                                      <div ID="ans_fill_ups_pnl" runat="server" style="width:100%;">
                          
                                      </div>       
                                  </td>
                                  <td>

                                  </td>
                              </tr>
                              <tr style="width:100%;">
                                  <td style="width:10%;">
                                       <asp:Label ID="Marks_get" runat="server" Font-Size="Medium" Font-Bold="true">0</asp:Label>  Marks
                                 </td>
                                  <td style="width:85%;">
                                           <asp:Label ID="Remark_get" runat="server" Font-Size="Smaller" Font-Bold="true"></asp:Label>
                                  </td>
                                  <td>

                                  </td>
                              </tr>
                              <tr>
                                  <td style="width:10%;">
                                      
                                  </td>
                                  <td style="width:85%;">
                                      
                                     <asp:Panel ID="Marks_Pnl" runat="server">
                                         <asp:TextBox ID="remark_box" runat="server" Visible="false" Width="350px" Height="40px" Placeholder="Give a review or feedback." TextMode="MultiLine"></asp:TextBox>
                                         <br />
                                         <asp:Button ID="Mark_btn0" runat="server" CssClass="buttons" Text="10" Visible="false"/>
                                         <asp:Button ID="Mark_btn1" runat="server" CssClass="buttons" Text="9" Visible="false"/>
                                         <asp:Button ID="Mark_btn2" runat="server" CssClass="buttons" Text="8" Visible="false"/>
                                         <asp:Button ID="Mark_btn3" runat="server" CssClass="buttons" Text="7" Visible="false"/>
                                         <asp:Button ID="Mark_btn4" runat="server" CssClass="buttons" Text="6" Visible="false"/>
                                         <asp:Button ID="Mark_btn5" runat="server" CssClass="buttons" Text="5" Visible="false"/>
                                         <asp:Button ID="Mark_btn6" runat="server" CssClass="buttons" Text="4" Visible="false"/>
                                         <asp:Button ID="Mark_btn7" runat="server" CssClass="buttons" Text="3" Visible="false"/>
                                         <asp:Button ID="Mark_btn8" runat="server" CssClass="buttons" Text="2" Visible="false"/>
                                         <asp:Button ID="Mark_btn9" runat="server" CssClass="buttons" Text="1" Visible="false"/> 
                                         
                                    </asp:Panel>
                                  </td>
                                  <td>

                                  </td>
                              </tr>
                          </table>
                            
                          </div>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
            </div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
