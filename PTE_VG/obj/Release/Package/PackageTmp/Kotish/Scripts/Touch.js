var myElement = document.getElementById("mnbdy");

myElement.addEventListener("touchstart", startTouch, false);
myElement.addEventListener("touchmove", moveTouch, false);

// Swipe Up / Down / Left / Right
var initialX = null;
var initialY = null;

function startTouch(e) {
    initialX = e.touches[0].clientX;
    initialY = e.touches[0].clientY;
};

function moveTouch(e) {
    if (initialX === null) {
        return;
    }

    if (initialY === null) {
        return;
    }

    var currentX = e.touches[0].clientX;
    var currentY = e.touches[0].clientY;

    var diffX = initialX - currentX;
    var diffY = initialY - currentY;

    if (Math.abs(diffX) > Math.abs(diffY)) {
        // sliding horizontally
        if (diffX > 0) {
            // swiped left 
            console.log("swiped left");
            change_loc();
        } else {
            // swiped right
            console.log("swiped right");
            change_loc();
        }
    } else {
        // sliding vertically
        if (diffY > 0) {
            // swiped up
            console.log("swiped up");
        } else {
            // swiped down
            console.log("swiped down");
        }
    }

    initialX = null;
    initialY = null;

    e.preventDefault();
};

function change_loc() {
    var sPath = window.location.pathname;
    var sPage = sPath.substring(sPath.lastIndexOf('/') + 1);
    var cnt = 0;
    if (sPage == "Dashboard.aspx") {
        cnt = 1;
    }
    else if (sPage == "Questions.aspx") {
        cnt = 2;
    }
    else if (sPage == "Batches.aspx") {
        cnt = 3;
    }
    else if (sPage == "Test_Maker.aspx") {
        cnt = 4;
    }
    else if (sPage == "Test_Assign.aspx") {
        cnt = 5;
    }
    else if (sPage == "Test_Checker.aspx") {
        cnt = 6;
    }
    else if (sPage == "MyStudents.aspx") {
        cnt = 7;
    }
    else {
        cnt = 0;
    }



    if (cnt == 1) {
        window.location.replace("Questions.aspx");
    }
    else if (cnt == 2) {
        window.location.replace("Batches.aspx");
    }
    else if (cnt == 3) {
        window.location.replace("Test_Maker.aspx");
    }
    else if (cnt == 4) {
        window.location.replace("Test_Assign.aspx");
    }
    else if (cnt == 5) {
        window.location.replace("Test_Checker.aspx");
    }
    else if (cnt == 6) {
        window.location.replace("MyStudents.aspx");
    }
    else {
        window.location.replace("Dashboard.aspx");
        cnt = 0;
    }
}