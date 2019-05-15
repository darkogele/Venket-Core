//GOOD for only one picture 
//$(function () {
//    $('.custom-file-input').on('change', function () {    
//        let fileName = $(this).val().split("\\").pop();   
//        $('.custom-file-label').html(fileName);
//    });
//});


// Multiple Photos uploaded script
$(function () {
    $('.custom-file-input').on('change', function () {
        let fileLabel = $(this).next('.custom-file-label');
        let files = $(this)[0].files;
        if (files.length > 1) {
            fileLabel.html(files.length + ' files selected');
        }
        else if (files.length === 1) {
            fileLabel.html(files[0].name);
        }             
    });
});