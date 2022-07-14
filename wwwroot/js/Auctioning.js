cancelAuction = myForm => {
    console.log(myForm.action);
    const id = myForm.action.substring(myForm.action.lastIndexOf("=") + 1); // noted: by default it just the id. If u try to change it to different parementer. that is huge problem
    console.log(id);
    
    try {
        $.ajax({
            type: "POST",
            url: myForm.action,
            data: new FormData(myForm),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res == "You are not allow cancel this Auction. Because the time of Auction are limit 15 minutes left") {

                    alert(res);
                } 
                console.log(myForm)
                window.location.reload();
            },
            error: function (er) {
                console.log(er.responseText);
            }

        })
    } catch (e) {
        console.log(e)
    }

    return false
}
