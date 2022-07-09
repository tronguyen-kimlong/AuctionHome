// show popup
ajaxShow = (url, title) => {
    
    $.ajax({
        type: 'GET',
        url: url,
        success: (res) => {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
            console.log('call id form-modal success');
        },
        error: (er) => {
            console.log(er)
        }
    })
}

// error when I call this FC in the future. Perhepl, it need asp-route-id derective.
// call ajax to add or update
ajaxPost = myForm => {
    console.log(myForm.action);
    const id = myForm.action.substring(myForm.action.lastIndexOf("=") + 1); // noted: by default it just the id. If u try to change it to different parementer. that is huge problem
    console.log(id);
    alert(id + 'jaxpost');
    try {
        $.ajax({
            type: "POST",
            url: myForm.action,
            data: new FormData(myForm),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res == "successItem") {
                    
                    console.log(res);
                    
                    //
                    $("#view-all").html(res.html);
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#form-modal").modal('hide');
                    console.log(myForm)
                    window.location.reload();
                    
                } else {
                    $("#form-modal .modal-body").html(res);
                    alert("Something wrong when call enter data. Wrong valid in ajax")
                }

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


ajaxDelete = myForm => {
    alert("ajax delete")
    console.log(myForm.action);
    const id = myForm.action.substring(myForm.action.lastIndexOf("=") + 1); // noted: by default it just the id. If u try to change it to different parementer. that is huge problem
    console.log(id);
    if(confirm("Are you sure to DELETE this record with id = " + id) == true)
    try {
        $.ajax({
            type: "POST",
            url: myForm.action,
            data: new FormData(myForm),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res == "successDelete") {
                    
                    
                    console.log(res);

                    alert("Delete successful")
                    window.location.reload();
                    
                } else {
                   
                }

            },
            error: function (er) {
                alert("You can't to detele this record. It just have a proplem with FK or something else")
                console.log(er.responseText);
            }

        })
    } catch (e) {
        console.log(e)
    }

    return false
}