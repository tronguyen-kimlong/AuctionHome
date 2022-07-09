﻿

   
var seconds = 1 * 1 * 1 * 10

    function timer() {
        var days = Math.floor(seconds / 24 / 60 / 60);
        var hoursLeft = Math.floor((seconds) - (days * 86400));
        var hours = Math.floor(hoursLeft / 3600);
        var minutesLeft = Math.floor((hoursLeft) - (hours * 3600));
        var minutes = Math.floor(minutesLeft / 60);
        var remainingSeconds = seconds % 60;
        function pad(n) {
            return (n < 10 ? "0" + n : n);
        }
        document.getElementById('countdown').innerHTML = pad(days) + ":" + pad(hours) + ":" + pad(minutes) + ":" + pad(remainingSeconds);
        if (seconds <= 0) {
            clearInterval(countdownTimer);
            document.getElementById('countdown').innerHTML = "Completed"; // completed to 0 timer
        } else {
            seconds--;
        }
    }
    var countdownTimer = setInterval('timer()', 1000);




