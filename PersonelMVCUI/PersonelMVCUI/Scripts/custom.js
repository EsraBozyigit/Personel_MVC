$(function () {
   
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
       
        if (confirm("Departmanı Silmek İstediğinize Emin Misiniz"))
        {
            var id = $(this).data("id");
            var btn = $(this);
            $.ajax({
            type: "GET",
            url: "/Departman/Sil/" + id,
                success: function () {
                    btn.parent().parent().remove();
            }
        });
        }
        
    });
});
function CheckDateTypeIsValid(dateElement)
{
    var value = $(dateElement).val();
    if (value == '') {
        $(dateElement).valid("false");
    }
    else
    {
        $(dateElement).valid();
    }
}