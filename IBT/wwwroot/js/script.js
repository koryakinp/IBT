var fineUploader = document.getElementById('uploader');

if (fineUploader) {
    var uploader = new qq.FineUploader({
        element: fineUploader,
        debug: true,
    });
}

$('#file-upload-control').on('change', function () {
    var list = $('#file-list');
    list.empty();
    for (var i = 0; i < this.files.length; i++) {
        list.append("<li>" + this.files[i].name + "</li>")
    }
});