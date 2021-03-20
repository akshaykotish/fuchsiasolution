var conatainer_create = document.createElement('div');
conatainer_create.classList.add("container_create");


function Create_Section(title, head, ele_type, ele_placeholder, ele_value, btn_name, btn_click) {

    var create_box = document.createElement('div');
    create_box.classList.add("create_box");

    var fhusia_box = document.createElement('div');
    fhusia_box.classList.add("fhusi_box");

    var title_box = document.createElement('div');
    title_box.classList.add('titlebox');
    title_box.innerText = title;
    fhusia_box.appendChild(title_box);

    create_box.appendChild(fhusia_box);

    var content_box = document.createElement('div');
    content_box.classList.add("create_content_box");
    for (var i = 0; i <= ele_type.length; i++)
    {
        if (ele_type.length == i) {
            //Section----------------------------
            var section = document.createElement('div');
            section.classList.add("section");

            //LEFT ELEMENTS----------------------------

            var left_section = document.createElement('div');
            left_section.classList.add("left");

            //Button Section--------------------------------
            var btn = document.createElement('div');
            btn.classList.add('btn_section');
            btn.innerText = btn_name;
            btn.setAttribute("onclick", btn_click);
            left_section.appendChild(btn);
            //Button Section----------------------------OVER

            section.appendChild(left_section);
            //LEFT ELEMENTS------------------------OVER

            //RIGHT ELEMENTS----------------------------
            var right_section = document.createElement('div');
            right_section.classList.add("right");

            /*
            var t_ele = document.createElement('input');
            t_ele.setAttribute("type", ele_type[i]);
            t_ele.classList.add("inputele");
            t_ele.value = ele_value[i];
            t_ele.setAttribute("placeholder", ele_placeholder[i]);
            right_section.appendChild(t_ele);
            */

            section.appendChild(right_section);

            //RIGHT ELEMENTS------------------------OVER


            content_box.appendChild(section);
            //Section-----------------------OVER
        }
        else {
            //Section----------------------------
            var section = document.createElement('div');
            section.classList.add("section");

            //LEFT ELEMENTS----------------------------

            var left_section = document.createElement('div');
            left_section.classList.add("left");

            left_section.innerText = head[i];

            section.appendChild(left_section);
            //LEFT ELEMENTS------------------------OVER

            //RIGHT ELEMENTS----------------------------
            var right_section = document.createElement('div');
            right_section.classList.add("right");

            var t_ele = document.createElement('input');
            t_ele.setAttribute("type", ele_type[i]);
            t_ele.classList.add("inputele");
            t_ele.value = ele_value[i];
            t_ele.setAttribute("placeholder", ele_placeholder[i]);
            right_section.appendChild(t_ele);

            section.appendChild(right_section);

            //RIGHT ELEMENTS------------------------OVER


            content_box.appendChild(section);
            //Section-----------------------OVER
        }
        
    }
    create_box.appendChild(content_box);

    
    conatainer_create.appendChild(create_box);
    document.getElementById("Stud_Area").appendChild(conatainer_create);

    var a = document.getElementsByClassName("inputele");
    console.log(a[0].value);
}


function load_createSection() {

    conatainer_div_stud.innerText = "";
    conatainer_create.innerText = "";
    document.getElementById("chng_area").classList.add("chng-area");
    var t = 'Create Batch'
    var e = ['text', 'text'];
    var f = ['Title','Details'];
    var g = ['Batch Title', 'Batch Details'];
    var h = ['', '', ''];
    Create_Section(t, f, e, g, h, 'Create Batch', "Create_Batch()");
}

function Create_Batch() {
    var args = [];
    var v = document.getElementsByClassName("inputele");
    for (var i = 0; i < v.length; i++) {
        args.push(v[i].value);
    }
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            document.getElementById("winld").style.display = "block";

            setTimeout(function () {
                document.getElementById("winld").style.display = "none";
                Fushi_Solution_Design(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value);
            }, 500);


            close_chng();   
            Load_Batches("ALL");
        }
    };
    xhttp.open("POST", "../Admin_/APIs/Data.ashx?Add_Batch=Yes", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("title=" + args[0] + "&details=" + args[1]);


}