$(document).ready(function () {
    $('.btn-confirma-exclusao').click(function () {
        var produtoId = $(this).attr('produtoId');
        console.log(produtoId);
        $.ajax({
            type: 'GET',
            url: 'Produtos/Delete/' + produtoId,
            success: function (result) {
                $('#modalContentConfirmaExclusao').html(result);
                $('#modalConfirmaExclusao').modal();
            }
        });
    });
    $('.btn-detalhes').click(function () {
        var produtoId = $(this).attr('produtoId');
        console.log(produtoId);
        $.ajax({
            type: 'GET',
            url: 'Produtos/Details/' + produtoId,
            success: function (result) {
                $('#modalContentDetalhes').html(result);
                $('#modalDetalhes').modal();
            }
        });
    });
    $('.btn-editar').click(function () {
        var produtoId = $(this).attr('produtoId');
        console.log(produtoId);
        $.ajax({
            type: 'GET',
            url: 'Produtos/Edit/' + produtoId,
            success: function (result) {
                $('#modalContentEditar').html(result);
                $('#modalEditar').modal();
            }
        });
    });
    $('.btn-adicionar').click(function () {
        console.log('passou1');
        $('#modalContentAdicionar').html();
        $('#modalAdicionar').modal();
        console.log('passou2');
    });
})