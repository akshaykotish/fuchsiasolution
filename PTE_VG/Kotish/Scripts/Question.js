//function submit() {

//    PageMethods.RegisterUser("dfr", "rers", onSucess, onError);
//    function onSucess(result) {
//        alert(result);
//    }

//    function onError(result) {
//        alert('Cannot process your request at the moment, please try later.');
//    }
//}

var ale = document.getElementById("alert");

function Update_Text() {
    var txt = document.getElementById("input_qs");
    PageMethods.Update_Text(txt.value, onSucess, onError);
}
var mcq_s_no = 0;
function Add_MCQ() {
    var mcq_txt = document.getElementById("mcq_txt");
    var ans_box = document.getElementById("ans_box");
    var MCQs = document.getElementById("MCQs");
    var mcq = "";
    mcq_s_no++;
    if (ans_box.checked == true) {
        PageMethods.MCQ_Add(mcq_txt.value, "1", onSucess, onError);
        mcq = "<span class='mcq ans'>" + mcq_s_no + ") " + mcq_txt.value + "</span>";
    }
    else {
        PageMethods.MCQ_Add(mcq_txt.value, "0", onSucess, onError);
        mcq = "<span class='mcq'>" + mcq_s_no + ") " + mcq_txt.value + "</span>";
    }
    MCQs.innerHTML = MCQs.innerHTML + mcq + "<br/>";
    
}

function Accept_Audio() {
    var aud_ans = document.getElementById("aud_ans");
    if (aud_ans.checked == true) {
        PageMethods.Accept_Audio_("1", onSucess, onError);
    }
    else {
        PageMethods.Accept_Audio_("0 ", onSucess, onError);
    }
}

function fill_up_text() {
    var fill_up_box = document.getElementById("fill_up_box");
    var txt = fill_up_box.value;
    txt = txt + " {FILLUP} ";
    fill_up_box.value = txt;
    fill_up_box.focus();
}

function Upload_Audio() {
    var aud = document.getElementById("audio_files").files[0];
    var audmsg = document.getElementById("aud-msg");
    var name = aud.name;
    var ext = name.split('.').pop();
    var xhr = new XMLHttpRequest();
    xhr.onload = function (e) {
        var result = e.target.result;
    };
    xhr.open('POST', '/Question.ashx?type=a&ext=' + ext, true);
    xhr.send(aud);
    audmsg.value = "Audio uploaded sucessfully."
}

function Upload_Img() {
    
    var img = document.getElementById("img_files").files[0];
    var imgmsg = document.getElementById("img-msg");
    var name = img.name;
    var ext = name.split('.').pop();
    var xhr = new XMLHttpRequest();
    xhr.onload = function (e) {
        var result = e.target.result;
    };
    xhr.open('POST', '/Question.ashx?type=p&ext=' + ext, true);
    xhr.send(img);
    imgmsg.value = "Image uploaded sucessfully.";
    
}

function Update_Fill_Up() {
    var f_u_box = document.getElementById("fill_up_box");
    PageMethods.Update_Fill_Ups(f_u_box.value, onSucess, onError);
}

function Accept_Text() {

    var text_ans = document.getElementById("text_ans");
    var accpt_txt = 0;
    if (text_ans.checked) {
        accpt_txt = 1;
    }
    PageMethods.Accept_Texts(accpt_txt, onSucess, onError);

}

function Update_Details() {
    var title = document.getElementById("ttl_box");
    var dur = document.getElementById("dur_box");
    var question_type = document.getElementById("question_type");
    var typee = question_type.value;
    
    PageMethods.Update_Details(title.value, dur.value, typee, onSucess, onError);

    ale.innerText = "Saved Sucessfully.";
}

var mrk_serial = 0;
function Marks() {
    var mrk_nm = document.getElementById("mrk_nm");
    var mrk_vl = document.getElementById("mrk_vl");
    var marks_view = document.getElementById("marks_view");
    PageMethods.Marking_Scheme(mrk_nm.value, mrk_vl.value, onSucess, onError);
    mrk_serial++;
    var mark = "<span class='mcq'>" + mrk_serial + ") " + mrk_nm.value + " - " + mrk_vl.value + "</span><br/>";
    marks_view.innerHTML = marks_view.innerHTML + mark;
}

function onSucess(result) {
    //alert(result);
    ale.innerText = "Saved Sucessfully.";
}

function onError(result) {
    ale.innerText = 'Cannot process your request at the moment, please try later.';
}



(
    function () {
        var dropzone = document.getElementById('audio_upld_area');

        var startAudUpload = function (files) {
            var audmsg = document.getElementById("aud-msg");
            console.log(files);
            var aud = files;
            var name = aud.name;
            var ext = name.split('.').pop();
            var xhr = new XMLHttpRequest();
            xhr.onload = function (e) {
                var result = e.target.result;
            };
            xhr.open('POST', '/Question.ashx?type=a&ext=' + ext, true);
            xhr.send(aud);

            audmsg.innerText = "Thanks for uploading Audio.";
        }

        dropzone.ondrop = function (e) {
            e.preventDefault();
            this.className = 'dropondrop';
            startAudUpload(e.dataTransfer.files[0]);

        }

        dropzone.ondragover = function () {
            this.className = 'dropdrag';
            return false;
        };

        dropzone.ondragleave = function () {
            this.className = 'dropzone';
            return false;
        }
    }()
);


(
    function () {
        var dropzone = document.getElementById('img_upld_area');

        var startImgUpload = function(files)
        {
            var imgmsg = document.getElementById("img-msg");
            console.log(files);
            var img = files;
            var name = img.name;
            alert(name);
            var ext = name.split('.').pop();
            var xhr = new XMLHttpRequest();
            xhr.onload = function (e) {
                var result = e.target.result;
            };
            xhr.open('POST', '/Question.ashx?type=p&ext=' + ext, true);
            xhr.send(img);
            imgmsg.innerText = "Thanks for Uploading Image.";
        }

        dropzone.ondrop = function (e) {
            e.preventDefault();
            this.className = 'dropondrop';
            startImgUpload(e.dataTransfer.files[0]);

        }

        dropzone.ondragover = function () {
            this.className = 'dropdrag';
            return false;
        };

        dropzone.ondragleave = function () {
            this.className = 'dropzone';
            return false;
        }
    }()  
);


