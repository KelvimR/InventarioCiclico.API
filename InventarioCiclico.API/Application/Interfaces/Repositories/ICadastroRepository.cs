using InventarioCiclico.API.Domain.Entities;

namespace InventarioCiclico.API.Application.Interfaces.Repositories;

public interface ICadastroRepository
{
    Task<List<Cadastro>> ObterCadastroPorEmpresa (string empresaId, CancellationToken cancellationToken);
    Task<Cadastro?> ObterCadastroPorNumeroPatrimonial(decimal numeroPatrimonial, CancellationToken cancellationToken);

    // Criar inserir cadastro
    // Criar atualizar cadastro

}
