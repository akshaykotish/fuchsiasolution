var conatainer_div = document.createElement('div');
conatainer_div.classList.add("container");

function Loader(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, funct) {
    setTimeout(function () {
            document.getElementById("winld").style.display = "none";
        Fushi_Solution_Design(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, funct);
        }, 500);
}

function Fushi_Solution_Design(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, funct) {

    var awesome_box = document.createElement('div');
    awesome_box.classList.add("awesome_box");

    var fhusi_box = document.createElement('div');
    fhusi_box.classList.add("fhusi_box");

    var title_box = document.createElement('div');
    title_box.classList.add("title_box");
    title_box.innerText = design_title;

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
    conatainer_div.appendChild(awesome_box);
    document.getElementById("Awesome_Area").appendChild(conatainer_div);
}

function close_chng() {
    document.getElementById("chng_area").classList.remove("chng-area");
    document.getElementById("chng_area").classList.remove("chng");
    document.getElementById("chng_area").classList.add("chng");
    document.getElementById("propts").classList.remove("propts_show");
    document.getElementById("propts").classList.add("propts");
}

function Show_Chng_Area(e) {
    document.getElementById("chng_area").classList.add("chng-area");
    Print(e);
}

function Load_Batches(e) {
    conatainer_div.innerText = "";
    var data = "";
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            conatainer_div.innerText = "";
            data = this.responseText;

            var design_title = "", big_number = "", big_number_heading = "", section1_head = "", section1_value = "", section2_head = "", section2_value = "";
            var c = 0;
            var word = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i] == ';') {
                    Loader(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, "Show_Chng_Area('" + design_title + "')");
                    design_title = "";
                    big_number = "";
                    big_number_heading = "";
                    section1_head = "";
                    section1_value = "";
                    section2_head = "";
                    section2_value = "";
                    c = 0;
                }
                else {

                    if (data[i] == "," || i == data.length - 1) {
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
                            Status = word + data[i];
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

    xhttp.open("GET", "../Admin_/APIs/Data.ashx?Batch_Name=" + e, true);
    xhttp.send();
}


function Load_Question(e) {
    conatainer_div.innerText = "";
    var data = "";
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            conatainer_div.innerText = "";
            data = this.responseText;

            var design_title = "", big_number = "", big_number_heading = "", section1_head = "", section1_value = "", section2_head = "", section2_value = "";
            var c = 0;
            var word = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i] == ';') {
                    Loader(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, "show_properties_Question('" + design_title + "', '" + big_number_heading + "', '" + section1_value + "')");
                    design_title = "";
                    big_number = "";
                    big_number_heading = "";
                    section1_head = "";
                    section1_value = "";
                    section2_head = "";
                    section2_value = "";
                    c = 0;
                }
                else {

                    if (data[i] == "," || i == data.length - 1) {
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
                            Status = word + data[i];
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

    xhttp.open("GET", "../Admin_/APIs/Data.ashx?Question_Name=" + e, true);
    xhttp.send();
}

function show_properties_Question(Question_Name, Question_Type, Question_Created_On) {
    conatainer_prop_div.innerText = "";
    document.getElementById("propts").classList.remove("propts");
    document.getElementById("propts").classList.add("propts_show"); 
    
    var prop_title = ['Edit', 'Delete'];
    var prop_type = ['button', 'delete'];
    var prop_value = ['Edit', 'Delete'];
    prop_value.push('Delete');
    var prop_func = ["Edit_Question('" + Question_Name + "', '" + Question_Type + "', '" + Question_Created_On + "')", "Delete_Question('" + Question_Name + "', '" + Question_Type + "', '" + Question_Created_On + "')"];
    Fhusia_Properties(Question_Name, prop_title, prop_type, prop_value, prop_func);
}

function Search_Batches() {
    var e = "" + document.getElementById('Search_box').value;
    Load_Batches(e);
}

function Create_Question() {
    var url = "Put_Question.aspx?Create_Question=TRUE&Keyword=OMNI";
    var win = window.open(url, '_blank');
    win.focus();
    document.getElementById("winld").style.display = "block";
    setTimeout(function () {
        document.getElementById("winld").style.display = "none";
    }, 2000);
    Load_Question("ALL");
}

function Load_Test(e) {
    conatainer_div.innerText = "";
    var data = "";
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            conatainer_div.innerText = "";
            data = this.responseText;

            var design_title = "", big_number = "", big_number_heading = "", section1_head = "", section1_value = "", section2_head = "", section2_value = "";
            var c = 0;
            var word = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i] == ';') {
                    Loader(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value, "show_properties_Question('" + design_title + "', '" + big_number_heading + "', '" + section1_value + "')");
                    design_title = "";
                    big_number = "";
                    big_number_heading = "";
                    section1_head = "";
                    section1_value = "";
                    section2_head = "";
                    section2_value = "";
                    c = 0;
                }
                else {

                    if (data[i] == "," || i == data.length - 1) {
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
                            Status = word + data[i];
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

    xhttp.open("GET", "../Admin_/APIs/Data.ashx?Test_Name=" + e, true);
    xhttp.send();
}

function chapal() {
    alert("Hello");
}