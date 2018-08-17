
var OrderController = function (orderService) {

    var renderOrders = function (data) {
        var $orders = $('#orders');
        var $orderList = $('<ul/>');

        if (data) {
            $.each(data,
                function () {
                    var $li = $('<li/>').text(this.description + ' (Total: $' + this.orderTotal + ')')
                        .appendTo($orderList);

                    var $productList = $('<ul/>');

                    $.each(this.orderProducts,
                        function () {
                            $('<li/>').text(this.productName +
                                    ' (' +
                                    this.quantity +
                                    ' @@ $' +
                                    this.price +
                                    '/ea)')
                                .appendTo($productList);
                        });

                    $productList.appendTo($li);
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