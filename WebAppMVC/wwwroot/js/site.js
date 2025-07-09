// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const formModal = new bootstrap.Modal(document.getElementById('formModal'));
const msgModal = new bootstrap.Modal(document.getElementById('msgModal'));
const confirmDeleteModal = new bootstrap.Modal(document.getElementById('confirmDeleteModal'));

let deleteUrl = "";

function showMessage(text) {
    $('#msgModalBody').text(text);
    msgModal.show();
    setTimeout(() => msgModal.hide(), 2000);
}

function showFormModal(btn, title) {
    const url = $(btn).data('url');
    $.get(url, function (html) {
        $('#formModal .modal-body').html(html);
        $('#formModalTitle').text(title);
        formModal.show();
    });
}

function ajaxSubmit(form) {
    $.ajax({
        type: $(form).attr('method'),
        url: $(form).attr('action'),
        data: $(form).serialize(),
        success: function (res) {
            if (res.isValid) {
                $('#view-all').html(res.html);
                formModal.hide();
                showMessage('Operação concluída!');
            } else {
                formModal.hide(); 
                showMessage(res.message || 'Erro na operação!');                
            }
        },
        error: () => showMessage('Erro inesperado!')
    });
    return false;
}

function deleteItem(btn) {
    deleteUrl = $(btn).data('url');
    confirmDeleteModal.show();
}

document.getElementById('confirmDeleteBtn').addEventListener('click', function () {
    $.post(deleteUrl, function (res) {       
        if (res.isValid) {
            $('#view-all').html(res.html);
            showMessage('Excluído com sucesso!');
        } else {
            showMessage(res.message || 'Falha ao excluir!');
        }
        confirmDeleteModal.hide();
    }).fail(() => {
        showMessage('Falha ao excluir!');
        confirmDeleteModal.hide();
    });
});

