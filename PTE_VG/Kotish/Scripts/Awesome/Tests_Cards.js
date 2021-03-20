var conatainer_div_stud = document.createElement('div');
conatainer_div_stud.classList.add("container_stud");

var temp_b_title = "";

function Loader_Stud(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, funct, active, qid) {
    
        setTimeout(function () {
            document.getElementById("winld").style.display = "none";
            Fushi_Solution_Design_Stud(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, funct, active, qid);
        }, 3100);
    
}

function Fushi_Solution_Design_Stud(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, funct, active, qid) {

    var awesome_box = document.createElement('div');
    awesome_box.classList.add("awesome_box");

    var fhusi_box = document.createElement('div');
    fhusi_box.classList.add("fhusi_box");

    var title_box = document.createElement('div');
    title_box.classList.add("title_box");
    if (active == 0) {
        title_box.innerText = design_title + " (Not in test)";
        fhusi_box.style.backgroundColor = "#25e240";
    }
    else {
        title_box.innerText = design_title;
    }

    fhusi_box.appendChild(title_box);

    awesome_box.appendChild(fhusi_box);

    var content_box = document.createElement('div');
    content_box.classList.add("content_box");

    var content_box_left = document.createElement('div');
    content_box_left.classList.add("content_box_left");

    var content_box_left_content = document.createElement('div');
    content_box_left_content.classList.add("content_box_left_content");

    var content_box_left_content_big_number = document.createElement('div');
    content_box_left_content_big_number.classList.add("content_box_left_content_big_number");
    content_box_left_content_big_number.innerText = big_number;

    content_box_left_content.appendChild(content_box_left_content_big_number);

    var content_box_left_content_heading = document.createElement('div');
    content_box_left_content_heading.classList.add("content_box_left_content_heading");
    content_box_left_content_heading.innerText = big_number_heading;

    content_box_left_content.appendChild(content_box_left_content_heading);

    content_box_left.appendChild(content_box_left_content);

    content_box.appendChild(content_box_left);


    var content_box_right = document.createElement('div');
    content_box_right.classList.add("content_box_right");


    var content_box_right_content = document.createElement('div');
    content_box_right_content.classList.add("content_box_right_content");

    var content_box_right_content_section1 = document.createElement('div');
    content_box_right_content_section1.classList.add("content_box_right_content_section");

    var content_box_right_content_section1_heading = document.createElement('div');
    content_box_right_content_section1_heading.classList.add("content_box_right_content_section_heading");
    content_box_right_content_section1_heading.innerText = section1_head;

    content_box_right_content_section1.appendChild(content_box_right_content_section1_heading);

    var content_box_right_content_section1_value = document.createElement('div');
    content_box_right_content_section1_value.classList.add("content_box_right_content_section_value");
    content_box_right_content_section1_value.innerText = section1_value;

    content_box_right_content_section1.appendChild(content_box_right_content_section1_value);

    content_box_right_content.appendChild(content_box_right_content_section1);

    var content_box_right_content_section2 = document.createElement('div');
    content_box_right_content_section2.classList.add("content_box_right_content_section");

    var content_box_right_content_section2_heading = document.createElement('div');
    content_box_right_content_section2_heading.classList.add("content_box_right_content_section_heading");
    content_box_right_content_section2_heading.innerText = section2_head;

    content_box_right_content_section2.appendChild(content_box_right_content_section2_heading);

    var content_box_right_content_section2_value = document.createElement('div');
    content_box_right_content_section2_value.classList.add("content_box_right_content_section_value");
    content_box_right_content_section2_value.innerText = section2_value;

    content_box_right_content_section2.appendChild(content_box_right_content_section2_value);


    content_box_right_content.appendChild(content_box_right_content_section2);

    content_box_right.appendChild(content_box_right_content);

    content_box.appendChild(content_box_right);

    awesome_box.appendChild(content_box);
    awesome_box.setAttribute("onclick", funct);

    //conatainer_div.appendChild(Fushi_Solution_Design('Batch 1', 36, 'Students', 'Created On', '21-08-2020', 'Total Assignment', 20));
    conatainer_div_stud.appendChild(awesome_box);
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

            var design_title = "", big_number = "", big_number_heading = "", section1_head = "", section1_value = "", section2_head = "", section2_value = "", Active = "", QID = "";
            var c = 0;
            var word = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i] == "," || data[i] == ";") {
                        if (c == 0) {
                            design_title = word;
                        }
                        else if (c == 1) {
                            big_number = word;
                        }
                        else if (c == 2) {
                            big_number_heading = word;
                        }
                        else if (c == 3) {
                            section1_head = word;
                        }
                        else if (c == 4) {
                            section1_value = word;
                        }
                        else if (c == 5) {
                            section2_head = word;
                        }
                        else if (c == 6) {
                            section2_value = word;
                        }
                        else if (c == 7) {
                            Active = word;
                        }
                        else if (c == 8) {
                            QID = word;
                            //alert("Design Title = " + design_title + " - " + "Big Number = " + big_number + " - " + "Big Number Heading = " + big_number_heading + " - " + "Section Heading = " + section1_head + " - " + "Section1 Value = " + section1_value + " - " + "Section2 Head = " + section2_head + " - " + "Section2 Value = " + section2_value + " - " + "Active = " + Active + " - " + "QID = " + QID);
                            Fushi_Solution_Design_Stud(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, "show_test_properties('" + design_title + "', '" + e + "', '" + QID + "', '" + Active + "')", Active, QID);
                            design_title = "";
                            big_number = "";
                            big_number_heading = "";
                            section1_head = "";
                            section1_value = "";
                            section2_head = "";
                            section2_value = "";
                            Active = "";
                            QID = "";
                            c = -1;
                        }
                        c++;
                        word = "";
                    }
                    else {
                        word = word + data[i];
                    }
                
            }

            
        }
    };

    xhttp.open("GET", "../Admin_/APIs/Data.ashx?Test_Questions="+e, true);
    xhttp.send();
}

function show_test_properties(question_name, test_name, qid, active) {
    conatainer_prop_div.innerText = "";
    document.getElementById("propts").classList.remove("propts");
    document.getElementById("propts").classList.add("propts_show");

    var prop_title = [test_name, "Question"];
    var prop_type = ['switch', 'button'];
    var prop_value = [];
    if (active == '1') {
        prop_value.push('checked');
    }
    else {
        prop_value.push('');
    }

    prop_value.push('View');

    var prop_func = ["Add_Question_To_Test('" + test_name + "','" + question_name + "','" + active + "')","View_Question('" + qid + "')"];
    Fhusia_Properties(question_name, prop_title, prop_type, prop_value, prop_func);
}

function close_propts() {
    document.getElementById("propts").classList.remove("propts_show");
    document.getElementById("propts").classList.add("propts");
}


function View_Question(qid) {
    window.location.replace("Put_Question.aspx?QID=" + qid);
}

function Add_Question_To_Test(test, question, active) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
           
            data = this.responseText;
            Print(test);
        }
    };
    if (active == 0) {
        xhttp.open("GET", "../Admin_/APIs/Data.ashx?Add_Q_T=YES&Q=" + question + "&T=" + test, true);
        xhttp.send();
    }
    else {
        xhttp.open("GET", "../Admin_/APIs/Data.ashx?Remove_Q_T=YES&Q=" + question + "&T=" + test, true);
        xhttp.send(); 
    }
}