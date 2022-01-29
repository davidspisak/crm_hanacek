function subjectDelete(subject) {
	return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/Subject/Delete/{0}"><i class="hnck-text-red fas fa-trash-alt"></i></a></div>', subject.IdSubject);
}

function subjectDetail(subject) {
	return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/Subject/Detail/{0}"><i class="hnck-text-blue fas fa-address-card"></i></a></div>', subject.IdSubject);
}

function subjectUpdate(subject) {
	return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/Subject/Update/{0}"><i class="hnck-text-blue fas fa-edit"></i></a></div>', subject.IdSubject);
}