$(document).ready(function () {
    $("#processButton").click(function () {
        var fileInput = document.getElementById("fileUpload");
        var file = fileInput.files[0];
    

        getBase64(file, function (base64File) {
            $.ajax({
                async: false,
                type: "POST",
                url: "Home.aspx/GetTopScorers",
                contentType: false,
                processData: false,
                data: JSON.stringify({ base64File: base64File }),
                success: function (response) {
                    $("#results").html(response.d.join("<br/>"));
                },
                failure: function (response) {
                    AJAX_Failure(response);
                },
                error: function (xhr) {
                    AJAX_Error(xhr);
                }
            }); // end of ajax.  
        });
       
        
    });
});

function getBase64(file, callback) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        var base64String = reader.result.replace("data:", "")
            .replace(/^.+,/, "");
        callback(base64String);
    };
    reader.onerror = function (error) {
        console.log('Error: ', error);
    };
}
