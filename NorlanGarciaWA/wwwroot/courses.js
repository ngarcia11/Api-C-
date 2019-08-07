const uri = "api/courses";

$(document).ready(function () {
    getCourses();
});

function getCourses() {
    $.ajax(
        {
            type: "GET",
            URL: uri,
            cache: false,
            success: function (data) {
                const tBody = $("#courses");
                $(tBody).empty();

                $.each(data, function (k, item) {
                    const tr = $("<tr> </tr>")
                        .append($("<td></td>").text(item.courseId))
                        .append($("<td></td>").text(item.name))
                        .append($("<td></td>").text(item.duration))
                        .append($("<td></td>").text(item.InstructorName))
                        .append($("<td></td>").text(item.isActive ? 'Activo' : 'Inactivo'))
                        .append(
                            $("<td></td>").append(
                                $('<button class="btn btn-sm btn-danger"> Delete </button> ')
                                    .on("click", function () {
                                        deleteCourse(item.courseId);
                                    })
                            )
                        );
                        
    tr.appendTo(tBody)
});
            }

        })
}