$(document).ready(function () {
    $('#btnUpload').on('click', function () {
        var fileExtension = ['csv','xml'];
        var filename = $('#postedFile').val();
        if (filename.length == 0) {
            alert("Please select a file.");
            return false;
        }
        else {
            var extension = filename.replace(/^.*\./, '');
            if ($.inArray(extension, fileExtension) == -1) {
                alert("Please select CSV (or) XML files.");
                return false;
            }
        }
    })
});