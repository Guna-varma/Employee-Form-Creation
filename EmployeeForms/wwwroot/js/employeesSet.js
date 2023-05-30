$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#employeesSetTableData').DataTable({
        "ajax": { url: '/employeesSet/getAll' },
        "columns": [
            {
                data: null,
                "title": "S.No",
                "render": function (data, type, row, meta) {
                    // Calculate the serial number (index + 1)
                    var serialNumber = meta.row + meta.settings._iDisplayStart + 1;
                    return serialNumber;
                },
                "width": "5%"
            },
            { data: 'firstName', "width": "5%" },
            { data: 'lastName', "width": "5%" },
            { data: 'employeeCode', "width": "5%" },
            { data: 'gender', "width": "5%" },
            { data: 'bloodGroup', "width": "5%" },
            { data: 'accountNo', "width": "5%" },
            { data: 'ifscCode', "width": "5%" },
            { data: 'branch', "width": "5%" },
            { data: 'bankName', "width": "5%" },
            { data: 'accountType', "width": "5%" },
            { data: 'addresssLine1', "width": "5%" },
            { data: 'addressLine2', "width": "5%" },
            { data: 'city', "width": "5%" },
            { data: 'state', "width": "5%" },
            { data: 'pincode', "width": "5%" },
            { data: 'department.deptName', "width": "5%" },
            
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">

                                <a href="/employeesSet/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>

                                <a onClick="Delete('/employeesSet/delete?id=${data}')" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                            </div>`
                },
                "width": "15%"
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