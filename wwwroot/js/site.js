// Função para abrir a modal de criação de jogo----
$(document).ready(function () {
    
    $('.btn-jogo-create').click(function () {
        $('#jogo-create').modal('show');
    });
})

// Função para abrir a modal de edição de jogo-----
    $('.btn-modal-edit').click(function () {
        var id = $(this).data('id');
        var editUrl = $(this).data('url');

        $.ajax({
            url: editUrl + '/' + id,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
               
                $('#id').val(data.id);
                $('#titulo').val(data.titulo);
                $('#genero').val(data.genero);
                $('#desenvolvedora').val(data.desenvolvedora);
                

                var dataLancamento = new Date(data.dataLancamento);
                var formattedDate = dataLancamento.toISOString().split('T')[0];
                $('#dataLancamento').val(formattedDate);

                $('#avaliacao').val(data.avaliacao);

                $('#modalEdit').modal('show');
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                alert('Erro ao carregar os dados do jogo.');
            }
        });
    });

// Função para abrir a modal delete de jogo
    $('.btn-modal-delete').click(function () {
        var id = $(this).data('id');
        var titulo = $(this).data('titulo');
        var deleteUrl = $(this).data('url');

        $('#modalDelete').modal('show');
        $('#gameTitleToDelete').text(titulo);

        $('#confirmDelete').off('click').on('click', function () {
            $.ajax({
                url: deleteUrl + '/' + id,
                type: 'DELETE',
                success: function (data) {
                    console.log('Game deleted successfully');
                    // Redirecionar para a página "Index" após a exclusão
                    window.location.href = "/Index";
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                    /* alert('Error deleting game.');*/
                    window.location.href = "Jogo/Index";
                }
            });
        });
    });




/*--------filme modal-------------*/

// Função para abrir a modal de criação de filme
$(document).ready(function () {
    $('.btn-filme-create').click(function () {
        $('#filme-create').modal('show');
    });
})


 // Função para abrir a modal de edição de filme
 $('.btn-filme-edit').click(function () {
    var id = $(this).data('id');
    var editUrl = $(this).data('url');

    console.log(id);
    console.log(editUrl);

    $.ajax({
        url: editUrl + '/' + id,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            console.log('Dados retorno:', data);
            $('#id').val(data.id);
            $('#titulo').val(data.titulo);
            $('#genero').val(data.genero);
           
            var dataLancamento = new Date(data.dataLancamento);
            var formattedDate = dataLancamento.toISOString().split('T')[0];
            $('#dataLancamento').val(formattedDate);
            $('#avaliacao').val(data.avaliacao);

            $('#modalFilmeEdit').modal('show');
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert('Erro ao carregar os dados do jogo.');
        }
    });
});

// Função para abrir a modal delete de filme
$('.btn-filme-delete').click(function () {
    var id = $(this).data('id');
    var titulo = $(this).data('titulo');
    var deleteUrl = $(this).data('url');

    $('#modalFilmeDelete').modal('show');
    $('#gameTitleToDelete').text(titulo);

    $('#confirmDelete').off('click').on('click', function () {
        $.ajax({
            url: deleteUrl + '/' + id,
            type: 'DELETE',
            success: function (data) {
                console.log('Game deleted successfully');
                // Redirecionar para a página "Index" após a exclusão
                window.location.href = "/Index";
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                /*alert('Error deleting game.');*/
                window.location.href = "Filme/Index";
            }
        });
    });
});

//Paginação------------------------------------------------------------

document.addEventListener('DOMContentLoaded', function () {
    let table = new DataTable('#minha-tabela');
});