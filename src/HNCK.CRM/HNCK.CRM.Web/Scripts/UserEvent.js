function onDataBound() {
    var grid = this;
    grid.tbody.find('>tr').each(function () {
        var dataItem = grid.dataItem(this);
        var date = new Date();
        if (((dataItem.DueDate - Date.now()) / (1000 * 3600 * 24)) < 4) {
            $(this).removeClass('k-alt');
            $(this).addClass('hnck-bg-yellow');
        }
        if (dataItem.DueDate - Date.now() < 0) {
            $(this).removeClass('k-alt');
            $(this).removeClass('hnck-bg-yellow');
            $(this).addClass('hnck-bg-red');
        }

    })
};

function eventDone(userEvent) {
    return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/UserEvent/Done/{0}"><i class="hnck-text-green fas fa-check"></i></a></div>', userEvent.IdUserEvent)
};

function eventRemove(userEvent) {
    return kendo.format('<div class="d-flex justify-content-center"><a rel="nofollow" href="/UserEvent/Remove/{0}"><i class="hnck-text-red fas fa-trash-alt"></i></a></div>', userEvent.IdUserEvent)
};