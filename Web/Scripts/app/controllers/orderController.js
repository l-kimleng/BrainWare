
var OrderController = function (orderService) {

    var renderOrders = function (data) {
        var $orders = $('#orders');
        var $orderList = $('<div/>');

        if (data) {
            $.each(data,
                function () {
                    var $div = $('<div/>').addClass('panel panel-default')
                        .append($('<div/>').addClass('panel-heading lead')
                            .text(this.description + ' (Total: $' + this.orderTotal + ')'))
                        .appendTo($orderList);

                    var $productList = $('<ul/>').addClass('list-group');

                    $.each(this.orderProducts,
                        function () {
                            $('<li/>').text(this.productName +
                                    ' (' +
                                    this.quantity +
                                    ' @@ $' +
                                    this.price +
                                '/ea)')
                                .addClass('list-group-item')
                                .appendTo($productList);
                        });

                    $productList.appendTo($div);
                });

            $orders.append($orderList);
        }
    };

    var fail = function (error) {
        alert(error);
    };

    var init = function () {
        orderService.fetchOrders(1, renderOrders, fail);
    };

    return {
        init: init
    };
}(OrderService);