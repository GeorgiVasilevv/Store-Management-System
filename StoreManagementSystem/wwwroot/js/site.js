function statistics() {
    $(document).ready(function () {
        $.get('https://localhost:7017/api/statistics', function (data) {
            $('#statistics_message').text('There are currently ' + data.totalStores + " Stores and " + data.totalProducts + " products.")
        });
    });
}