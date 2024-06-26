﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblBookings').DataTable({ // Burada eksik olan '$' işaretini ekledim.
        "ajax": {
            url: 'booking/getall'
        },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "15%" },
            { data: 'phone', "width": "10%" },
            { data: 'email', "width": "15%" },
            { data: 'status', "width": "10%" },
            { data: 'checkInDate', "width": "10%" },
            { data: 'nights', "width": "10%" },
            { data: 'totalCost', render: $.fn.dataTable.render.number(',','.',2), "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group">
                        <a href="/booking/bookingDetail?bookingId=${data}" class="btn btn-outline-success mx-2 ">
                            <i class="bi bi-pencil-square"></i>Detay
                        </a>
                    </div>`
                }
            }
        ]
    });

}