var recordsChecked = [];

function recordsCheckedonChange(arg) {
	//alert("The selected ids are: [" + this.selectedKeyNames().join(", ") + "]");
	recordsChecked = [];
	recordsChecked = this.selectedKeyNames();
}

function GenerateDocuments(docxTemplate) {
	$.ajax({
		type: "POST",
		url: '/Subject/GenerateDocuments',
		data: {
			ids: recordsChecked,
			template: docxTemplate
		},
		success: function (response) {
			window.location = '/Subject/Download?fileName=' + response.fileName;;
		},
		failure: function (response) {
			alert(response.responseText);
		},
		error: function (response) {
			alert(response.responseText);
		}
	});
}

$("#GenerateDocument_01").click(function () {
	GenerateDocuments("01_svn_cudzinci.docx");
});

$("#GenerateDocument_02").click(function () {
	GenerateDocuments("02_spl_cudzinci.docx");
});


function subjectDelete(subject) {
	return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/Subject/Delete/{0}"><i class="hnck-text-red fas fa-trash-alt"></i></a></div>', subject.IdSubject);
}

function subjectDetail(subject) {
	return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/Subject/Detail/{0}"><i class="hnck-text-blue fas fa-address-card"></i></a></div>', subject.IdSubject);
}

function subjectUpdate(subject) {
	return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/Subject/Update/{0}"><i class="hnck-text-blue fas fa-edit"></i></a></div>', subject.IdSubject);
}

