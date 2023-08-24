function openModel(event, element) {
    $.ajaxSetup({ cache: false });
    event.preventDefault();
    $.get(element.href, function (data) {
        $('#dialogContent').html(data);
        $('#modDialog').modal('show');
    });
}