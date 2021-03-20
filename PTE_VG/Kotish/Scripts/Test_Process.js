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
        call_submit_btn();
    }
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

