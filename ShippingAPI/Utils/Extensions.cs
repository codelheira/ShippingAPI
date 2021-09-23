using ShippingAPI.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingAPI.Utils
{
    /// <summary>
    /// Uso de "Extension" para instanciar (factory) um objeto dinamico para servir de DTO
    /// </summary>
    public static class DataTransferObjectExtensions
    {
        /// <summary>
        /// Transforma o objeto da entidade Veiculo em uma DTO dinamica
        /// </summary>
        /// <param name="entity">Veiculo</param>
        /// <returns></returns>
        public static dynamic ToDTO(this Veiculo entity) => new
        {
            id = entity.Id,
            valor_cubico = entity.ValorCubico,
            nome_modelo = entity.NomeModelo,
            tipo_veiculo = entity.TipoVeiculo.ToDTO(),
        };
        /// <summary>
        /// Transforma o objeto da entidade TipoVeiculo em uma DTO dinamica
        /// </summary>
        /// <param name="entity">TipoVeiculo</param>
        /// <returns></returns>
        public static dynamic ToDTO(this TipoVeiculo entity) => new
        {
            id = entity.Id,
            tipo = entity.Tipo
        };
        /// <summary>
        /// Transforma o objeto da entidade StatusCarga em uma DTO dinamica
        /// </summary>
        /// <param name="entity">StatusCarga</param>
        /// <returns></returns>
        public static dynamic ToDTO(this StatusCarga entity) => new
        {
            id = entity.Id,
            status = entity.Status
        };
        /// <summary>
        /// Transforma o objeto da entidade Carga em uma DTO dinamica
        /// </summary>
        /// <param name="entity">Carga</param>
        /// <returns></returns>
        public static dynamic ToDTO(this Carga entity) => new
        {
            id = entity.Id,
            responsavel = entity.Responsavel,
            data_saida = entity.DataSaida,
            altura = entity.Altura,
            largura = entity.Largura,
            comprimento = entity.Comprimento,
            data_entrega = entity.DataEntrega,
            valor = entity.ValorCarga,
            origem = entity.Origem,
            destino = entity.Destino,
            veiculo = entity.Veiculo.NomeModelo,
            tipo_veiculo = entity.Veiculo.TipoVeiculo.Tipo,
            status = entity.Status.Status,
        };
        /// <summary>
        /// Transforma uma lista de entidade em uma DTO dinamica de paginação
        /// </summary>
        /// <param name="entity">Carga</param>
        /// <returns></returns>
        public static dynamic ToDTO(this IEnumerable<Carga> entity)
        {
            return new
            {
                hasNext = false,
                items = entity.Select(x => new
                {
                    id = x.Id,
                    responsavel = x.Responsavel,
                    data_saida = x.DataSaida,
                    valor = x.ValorCarga,
                    origem = x.Origem,
                    destino = x.Destino,
                    veiculo = x.Veiculo.NomeModelo,
                    tipo_veiculo = x.Veiculo.TipoVeiculo.Tipo,
                    status = x.Status.Status,
                })
            };
        }
    }
}
