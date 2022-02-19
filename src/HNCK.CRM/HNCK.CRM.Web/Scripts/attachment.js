$(document).ready(function () {
    $(".k-file-name").css("cursor", "pointer");
    $("body").on('click', '.k-file-name, .k-icon' ,function () {
        var fileName = this.innerText;
        var subjectId = $("#idsubject").val();
        window.location = "/Attachment/DownloadAttachment?subjectId=" + subjectId + "&fileName=" + fileName;
    });
});


function onError(e) {
    if ($('span.k-file-validation-message').last().length) {
        $('span.k-file-validation-message').last().html(e.XMLHttpRequest.responseText);
    } else {
        alert(e.XMLHttpRequest.responseText);
	}
};

