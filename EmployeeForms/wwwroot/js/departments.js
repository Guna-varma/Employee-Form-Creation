$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#departmentTableData').DataTable({
        "ajax": { url: '/department/getAll' },
        "columns": [
            {
                data: null,
                "title": "S.No",
                "render": function (data, type, row, meta) {
                    // Calculate the serial number (index + 1)
                    var serialNumber = meta.row + meta.settings._iDisplayStart + 1;
                    return serialNumber;
                },
                "width": "10%"
            },
            { data: 'deptCode', "width": "15%" },
            { data: 'deptName', "width": "15%" },
            { data: 'deptLocation', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/department/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a onClick="Delete('/department/delete?id=${data}')" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                        </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });
}