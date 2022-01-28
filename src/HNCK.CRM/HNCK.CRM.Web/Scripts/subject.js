function subjectDelete(subject) {
	return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/Home/Delete/{0}"><i class="hnck-text-red fas fa-trash-alt"></i></a></div>', subject.IdSubject);
}