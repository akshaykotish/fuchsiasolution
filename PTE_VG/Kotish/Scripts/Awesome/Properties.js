var conatainer_prop_div = document.createElement('div');
conatainer_prop_div.classList.add("container");

function Fhusia_Properties(title, prop_title, prop_type, prop_value, prop_functn) {
    
    var prop_box = document.createElement('div');
    prop_box.classList.add('prop_box');

    var fhusia_box = document.createElement('div');
    fhusia_box.classList.add('fhusia_box');

    var title_box = document.createElement('div');
    title_box.classList.add('title_box');
    title_box.innerText = title;

    fhusia_box.appendChild(title_box);

    prop_box.appendChild(fhusia_box);


    var prop_content_box = document.createElement('div');
    prop_content_box.classList.add('prop_content_box');

    var section = document.createElement('div');
    section.classList.add('section');

    for (var i = 0; i < prop_title.length; i++)
    {
        var left = document.createElement('div');
        left.classList.add('left');

        var title_box = document.createElement('div');
        title_box.classList.add('title');
        title_box.innerText = prop_title[i];

        left.appendChild(title_box);
        section.appendChild(left);

        var right = document.createElement('div');
        right.classList.add('right');

        if (prop_type[i] == 'switch')
        {
            var switch_box = document.createElement('label');
            switch_box.classList.add('switch');


            var input = document.createElement('input');
            input.setAttribute('type', 'checkbox');
            if (prop_value[i] != '') {
                input.setAttribute(prop_value[i], prop_value[i]);
            }
            input.setAttribute('onclick', prop_functn[i]);

            var span = document.createElement('span');
            span.classList.add('slider');
            span.classList.add('round');

            switch_box.appendChild(input);
            switch_box.appendChild(span);

            right.appendChild(switch_box);

            section.appendChild(right);
        }
        else if (prop_type[i] == 'input') {
            var input_box = document.createElement('input');
            input_box.setAttribute('type', 'text');
            input_box.setAttribute('value', prop_value[i]);
            input_box.setAttribute('onclick', prop_functn[i]);

            right.appendChild(input_box);

            section.appendChild(right);
        }
        else if (prop_type[i] == 'button') {
            var input_box = document.createElement('input');
            input_box.setAttribute('type', 'button');
            input_box.setAttribute('value', prop_value[i]);
            input_box.setAttribute('onclick', prop_functn[i]);

            right.appendChild(input_box);

            section.appendChild(right);
        }
        else if (prop_type[i] == 'delete') {
            var input_box = document.createElement('input');
            input_box.setAttribute('type', 'button');
            input_box.setAttribute('value', prop_value[i]);
            input_box.classList.add('deletebtn');
            input_box.setAttribute('onclick', prop_functn[i]);

            right.appendChild(input_box);

            section.appendChild(right);
        }
    }

    prop_content_box.appendChild(section);

    prop_box.appendChild(prop_content_box);


    conatainer_prop_div.appendChild(prop_box);
    document.getElementById("Properties_Area").appendChild(conatainer_prop_div);
}


function Change_Block(name, email, contact, block) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            document.getElementById("winld").style.display = "block";

            setTimeout(function () {
                document.getElementById("winld").style.display = "none";;
            }, 500);
            Load_Batches("ALL");
            Print(temp_b_title);
            
        }
    };

    xhttp.open("POST", "../Admin_/APIs/Data.ashx?BLOCK_USER=Yes", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("name=" + name + "&email=" + email + "&contact=" + contact + "&block=" + block);
}

function Change_Batch(name, email, contact, batch_title, active) {

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            document.getElementById("winld").style.display = "block";
            setTimeout(function () {
                document.getElementById("winld").style.display = "none";
            }, 500);
            Load_Batches("ALL");
            Print(temp_b_title);
        }
    };
    if (active == "1") {
        batch_title = "0";
    }
    xhttp.open("POST", "../Admin_/APIs/Data.ashx?Change_Batch=Yes", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("name=" + name + "&email=" + email + "&contact=" + contact + "&batch=" + batch_title);
}


function Edit_Question(Question_Name, Question_Type, Question_Created_On) {

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            Load_Question("ALL");
            document.getElementById("winld").style.display = "block";
            setTimeout(function () {
                document.getElementById("winld").style.display = "none";
            }, 500);
            var url = "Put_Question.aspx?QID=" + this.responseText;
            var win = window.open(url, '_blank');
            win.focus();
        }
    };
    xhttp.open("POST", "../Admin_/APIs/Data.ashx?Edit_Question=Yes", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("Question_Name=" + Question_Name + "&Question_Type=" + Question_Type + "&Question_Created_On=" + Question_Created_On);
}

function Delete_Question(Question_Name, Question_Type, Question_Created_On) {

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            Load_Question("ALL");
            document.getElementById("winld").style.display = "block";
            setTimeout(function () {
                document.getElementById("winld").style.display = "none";
            }, 500);
        }
    };
    xhttp.open("POST", "../Admin_/APIs/Data.ashx?Delete_Question=Yes", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("Question_Name=" + Question_Name + "&Question_Type=" + Question_Type + "&Question_Created_On=" + Question_Created_On);
}
