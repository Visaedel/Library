function RolleriGetir() {
    $.ajax({
        type: "GET",
        url: `${BASE_API_URI}/api/Rol/TumRolller`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {

                var html = `<table class="table table-hover table-responsive">` +
                    `<tr><th style="width:50px">Id</th><th>Rol Adı</th><th></th></tr>`;
                var arr = response.data;
                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].rollId}</td><td>${arr[i].rollAd}</td>`;
                    html += `<td><i class="btn btn-danger" onclick='RolSil(${arr[i].rollId})'> Sil </i>
                    <button type="button" style="width:100px " class="btn btn-info" data-bs-toggle="collapse" onclick = 'RolDuzenle(${arr[i].rollId},"${arr[i].rollAd}")'> Düzenle </button></td>`;
                    html += `</tr>`
                }
                html += `</table>`;

                $("#divRolller").html(html);
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}
function RollKaydet() {
    var roll = {
        rollId: 0,
        rollAd: $("#inputRollAd").val()
    };
    $.ajax({
        type: "POST",
        url: `${BASE_API_URI}/api/Rol/Kaydet`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(roll),
        success: function (response) {
            if (response.success) {
                RolleriGetir();
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}

function RollSil(id) {
    if (confirm("Kaydı silmek istediğinizden emin misiniz?")) {
        $.ajax({
            type: "DELETE",
            url: `${BASE_API_URI}/api/Rol/${id}`,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.success) {
                    RolleriGetir();
                }
                else {
                    alert(response.message);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
            }
        });
    }
}

$(document).ready(function () {
    RolleriGetir();
});