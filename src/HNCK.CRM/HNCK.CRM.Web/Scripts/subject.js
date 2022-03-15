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

$("#GenerateDocument_03").click(function () {
	GenerateDocuments("03_vyhlasenie_jedineho_spolocnika.docx");
});

$("#GenerateDocument_04").click(function () {
	GenerateDocuments("04_spravca_vkladu.docx");
});

$("#GenerateDocument_05").click(function () {
	GenerateDocuments("05_zakladatelska_listina.docx");
});

$("#GenerateDocument_06").click(function () {
	GenerateDocuments("06_splnomocnenie.docx");
});

$("#GenerateDocument_07").click(function () {
	GenerateDocuments("07_spl_danovi_autori.docx");
});

$("#GenerateDocument_08").click(function () {
	GenerateDocuments("08_vyhlasenie_do_or.docx");
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

