var dtable;
$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        "ajax":
        {
            "url":"/Admin/Product/AllProducts"
        }        ,
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a href="/Admin/Product/CreateUpdate?id=${data}"> <i class="bi bi-pencil-square"></i></a>
                    <a onclick=removeproduct("/Admin/Product/Delete/${data}")> <i class="bi bi-trash3-fill"></i></a>
                      `

                }



            }


        ]
    });
});
function removeproduct(url) {
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
                type: 'Delete',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dtable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }

            });
        }
    }
    );
}
  