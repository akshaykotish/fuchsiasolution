var conatainer_div = document.createElement('div');
conatainer_div.classList.add("container");

function Loader(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value) {
    window.onload = function () {
        setTimeout(function () {
            document.getElementById("winld").style.display = "none";
            Fushi_Solution_Design(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value);
        }, 3100); 
   }
}

function Fushi_Solution_Design(design_title, big_number, big_number_heading, section1_head, section1_value, section2_head, section2_value) {
   
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

    //conatainer_div.appendChild(Fushi_Solution_Design('Batch 1', 36, 'Students', 'Created On', '21-08-2020', 'Total Assignment', 20));
    conatainer_div.appendChild(awesome_box);
    document.getElementById("Awesome_Area").appendChild(conatainer_div);
}