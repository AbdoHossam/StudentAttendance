// Call the dataTables jQuery plugin
$(document).ready(function() {
  $('#dataTable').DataTable();
});

//$(document).ready(function () {
//    // dynamic table
//    jQuery('#dataTable').dataTable({
//        "sPaginationType": "full_numbers",
//        "lengthMenu": [[100, 150, 200], [100, 150, 200]],
//        "aaSortingFixed": [[0, 'asc']],
//        "fnDrawCallback": function (oSettings) {
//            jQuery.uniform.update();
//        }
//    });
//});
