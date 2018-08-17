
var OrderService = function () {
    var fetchOrders = function (companyId, done, fail) {
        $.ajax({
            url: '/api/orders/' + companyId,
            type: 'GET'
        }).done(function (data) {
            done(data);
        }).fail(function (error) {
            fail(error);
        });
    };

    return {
        fetchOrders: fetchOrders
    };
}();