var conatainer_div_stud = document.createElement('div');
conatainer_div_stud.classList.add("container_stud");

var temp_b_title = "";

function Loader_Stud(Name, Contact, Email, Father_Name, Date_Of_Join, Institute, Date_Of_Birth, Status, Active) {
    
        setTimeout(function () {
            document.getElementById("winld").style.display = "none";
            Fushi_Solution_Design_Stud(Name, Contact, Email, Father_Name, Date_Of_Join, Institute, Date_Of_Birth, Status, Active);
        }, 3100);
    
}

function Fushi_Solution_Design_Stud(Name, Contact, Email, Father_Name, Date_Of_Join, Institute, Date_Of_Birth, Status, Active) {
     var stud_box = document.createElement('div');
    stud_box.classList.add("stud_box");
    
    var fhusi_box = document.createElement('div');
    fhusi_box.classList.add("fhusi_box");

    var title_box = document.createElement('div');
    title_box.innerText = Name;
    title_box.classList.add("title_box");


    fhusi_box.appendChild(title_box);
    stud_box.appendChild(fhusi_box);

    var content_box = document.createElement('div');
    content_box.classList.add("content_box");


    var Section_Box = document.createElement('div');
    Section_Box.classList.add("Section_Box");

    var Sub_Section_Box1L = document.createElement('div');
    Sub_Section_Box1L.classList.add("Sub_Section_Box");

    var Contact_H = document.createElement('div');
    Contact_H.classList.add("content_box_section_heading");
    Contact_H.innerText = "Contact";

    Sub_Section_Box1L.appendChild(Contact_H);

    var Sub_Section_Box2L = document.createElement('div');
    Sub_Section_Box2L.classList.add("Sub_Section_Box");

    var Email_H = document.createElement('div');
    Email_H.classList.add("content_box_section_heading");
    Email_H.innerText = "Email";

    Sub_Section_Box2L.appendChild(Email_H);

    Section_Box.appendChild(Sub_Section_Box1L);
    Section_Box.appendChild(Sub_Section_Box2L);

    content_box.appendChild(Section_Box);

    var Section_Box_V = document.createElement('div');
    Section_Box_V.classList.add("Section_Box");

    var Sub_Section_Box1L_V = document.createElement('div');
    Sub_Section_Box1L_V.classList.add("Sub_Section_Box");

    var Contact_V = document.createElement('div');
    Contact_V.classList.add("content_box_section_value");
    Contact_V.innerText = Contact;

    Sub_Section_Box1L_V.appendChild(Contact_V);

    var Sub_Section_Box2L_V = document.createElement('div');
    Sub_Section_Box2L_V.classList.add("Sub_Section_Box");

    var Email_V = document.createElement('div');
    Email_V.classList.add("content_box_section_value");
    Email_V.innerText = Email;

    Sub_Section_Box2L_V.appendChild(Email_V);

    Section_Box_V.appendChild(Sub_Section_Box1L_V);
    Section_Box_V.appendChild(Sub_Section_Box2L_V);
    
  
    content_box.appendChild(Section_Box_V);

    //--------------------------------------------------

    var Section_Box_F_H = document.createElement('div');
    Section_Box_F_H.classList.add("Section_Box");

    var Sub_Section_Box1L_F_H = document.createElement('div');
    Sub_Section_Box1L_F_H.classList.add("Sub_Section_Box");

    var Father_Name_F_H = document.createElement('div');
    Father_Name_F_H.classList.add("content_box_section_heading");
    Father_Name_F_H.innerText = "Father Name";

    Sub_Section_Box1L_F_H.appendChild(Father_Name_F_H);
    Section_Box_F_H.appendChild(Sub_Section_Box1L_F_H);

    var Sub_Section_Box2L_I_H = document.createElement('div');
    Sub_Section_Box2L_I_H.classList.add("Sub_Section_Box");

    var Institute_I_H = document.createElement('div');
    Institute_I_H.classList.add("content_box_section_heading");
    Institute_I_H.innerText = "Institute";

    Sub_Section_Box2L_I_H.appendChild(Institute_I_H);

    Section_Box_F_H.appendChild(Sub_Section_Box1L_F_H);
    Section_Box_F_H.appendChild(Sub_Section_Box2L_I_H);

    content_box.appendChild(Section_Box_F_H);

    //--------------------------------------------------------

    var Section_Box_F_V = document.createElement('div');
    Section_Box_F_V.classList.add("Section_Box");

    var Sub_Section_Box2F_V = document.createElement('div');
    Sub_Section_Box2F_V.classList.add("Sub_Section_Box");

    var Father_Name_V = document.createElement('div');
    Father_Name_V.classList.add("content_box_section_value");
    Father_Name_V.innerText = Father_Name;

    Sub_Section_Box2F_V.appendChild(Father_Name_V);


    var Sub_Section_Box2I_V = document.createElement('div');
    Sub_Section_Box2I_V.classList.add("Sub_Section_Box");

    var Institute_V = document.createElement('div');
    Institute_V.classList.add("content_box_section_value");
    Institute_V.innerText = Institute;

    Sub_Section_Box2I_V.appendChild(Institute_V);

    Section_Box_F_V.appendChild(Sub_Section_Box2F_V);
    Section_Box_F_V.appendChild(Sub_Section_Box2I_V);


    content_box.appendChild(Section_Box_F_V);

    //--------------------------------------------------------

    var Section_Box_D_H = document.createElement('div');
    Section_Box_D_H.classList.add("Section_Box");

    var Sub_Section_Box1L_DJ_H = document.createElement('div');
    Sub_Section_Box1L_DJ_H.classList.add("Sub_Section_Box");

    var Date_OF_Join_H = document.createElement('div');
    Date_OF_Join_H.classList.add("content_box_section_heading");
    Date_OF_Join_H.innerText = "Date Of Join";

    Sub_Section_Box1L_DJ_H.appendChild(Date_OF_Join_H);

    var Sub_Section_Box2L_DB_H = document.createElement('div');
    Sub_Section_Box2L_DB_H.classList.add("Sub_Section_Box");

    var Date_Of_Birth_H = document.createElement('div');
    Date_Of_Birth_H.classList.add("content_box_section_heading");
    Date_Of_Birth_H.innerText = "Date Of Birth";

    Sub_Section_Box2L_DB_H.appendChild(Date_Of_Birth_H);

    Section_Box_D_H.appendChild(Sub_Section_Box1L_DJ_H);
    Section_Box_D_H.appendChild(Sub_Section_Box2L_DB_H);

    content_box.appendChild(Section_Box_D_H);

    //--------------------------------------------------------

    var Section_Box_D_V = document.createElement('div');
    Section_Box_D_V.classList.add("Section_Box");

    var Sub_Section_Box1L_DJ_V = document.createElement('div');
    Sub_Section_Box1L_DJ_V.classList.add("Sub_Section_Box");

    var Date_OF_Join_V = document.createElement('div');
    Date_OF_Join_V.classList.add("content_box_section_value");
    Date_OF_Join_V.innerText = Date_Of_Join;

    Sub_Section_Box1L_DJ_V.appendChild(Date_OF_Join_V);

    var Sub_Section_Box2L_DB_V = document.createElement('div');
    Sub_Section_Box2L_DB_V.classList.add("Sub_Section_Box");

    var Date_Of_Birth_V = document.createElement('div');
    Date_Of_Birth_V.classList.add("content_box_section_value");
    Date_Of_Birth_V.innerText = Date_Of_Birth;

    Sub_Section_Box2L_DB_V.appendChild(Date_Of_Birth_V);

    Section_Box_D_V.appendChild(Sub_Section_Box1L_DJ_V);
    Section_Box_D_V.appendChild(Sub_Section_Box2L_DB_V);

    content_box.appendChild(Section_Box_D_V);

    //--------------------------------------------------------

    if (Active == "0") {
        title_box.innerText = Name + " (Not in this Batch)";
        fhusi_box.style.backgroundColor = "#25e240";
    }
    if (Status == "0") {
        title_box.innerText = Name + " (User is Blocked)";
        fhusi_box.style.backgroundColor = "#e81b1b";    
    }

    stud_box.setAttribute("onclick", "show_properties('" + Name + "', '" + Email + "', '" + Contact + "', '" + Status + "', '" + Active + "')");

    stud_box.appendChild(content_box);
    conatainer_div_stud.appendChild(stud_box);
    document.getElementById("Stud_Area").appendChild(conatainer_div_stud);
}


function Print(e) {
    temp_b_title = e;
    var data = "";
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            conatainer_div_stud.innerText = "";
            conatainer_create.innerText = "";
            data = this.responseText;

            var Name = "", Contact = "", Email = "", Father_Name = "", Date_Of_Join = "", Institute = "", Date_Of_Birth = "", Status = "", Active = "";
            var c = 0;
            var word = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i] == ';') {
                    Fushi_Solution_Design_Stud(Name, Contact, Email, Father_Name, Date_Of_Join, Institute, Date_Of_Birth, Status, Active);
                    Name = "";
                    Contact = "";
                    Email = "";
                    Father_Name = "";
                    Date_Of_Join = "";
                    Institute = "";
                    Date_Of_Birth = "";
                    Status = "";
                    Active = "";
                    c = 0;
                }
                else {
                    
                    if (data[i] == "," || i == data.length - 2) {
                        if (c == 0) {
                            Name = word;
                        }
                        else if (c == 1) {
                            Father_Name = word;
                        }
                        else if (c == 2) {
                            Contact = word;
                        }
                        else if (c == 3) {
                            Email = word;
                        }
                        else if (c == 4) {
                            Date_Of_Join = word;
                        }
                        else if (c == 5) {
                            Institute = word;
                        }
                        else if (c == 6) {
                            Date_Of_Birth = word;
                        }
                        else if (c == 7) {
                            Status = word;
                        }
                        else if (c == 8) {
                            Active = word + data[i];
                        }
                        c++;
                        word = "";
                    }
                    else {
                        word = word + data[i];
                    }
                }
            }

            
        }
    };

    xhttp.open("GET", "../Admin_/APIs/Data.ashx?Batch="+e, true);
    xhttp.send();
}

function show_properties(name, email, contact, status, active) {
    conatainer_prop_div.innerText = "";
    document.getElementById("propts").classList.remove("propts");
    document.getElementById("propts").classList.add("propts_show");

    var prop_title = ['Block', temp_b_title];
    var prop_type = ['switch', 'switch'];
    var prop_value = [];
    if (status == '0') {
        prop_value.push('checked');
    }
    else {
        prop_value.push('');
    }

    if (active == '1') {
        prop_value.push('checked');
    }
    else {
        prop_value.push('');
    }
    var prop_func = ["Change_Block('" + name + "', '" + email + "', '" + contact + "', '"+ status +"')", "Change_Batch('" + name + "', '" + email + "', '" + contact + "','" + temp_b_title + "', '" + active + "')"];
    Fhusia_Properties(name, prop_title, prop_type, prop_value, prop_func);
}

function close_propts() {
    document.getElementById("propts").classList.remove("propts_show");
    document.getElementById("propts").classList.add("propts");
}
