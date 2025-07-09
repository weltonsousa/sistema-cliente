using Microsoft.Extensions.Logging;
using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Interface;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaCliente.Application.Service
{
    public class ClienteApiService : IClienteApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClienteApiService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string resource = "https://localhost:7287/api/Clientes";     

        public ClienteApiService(HttpClient httpClient, ILogger<ClienteApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };            
        }

        public async Task<ApiResponse<IEnumerable<ClienteResponseDto>>> GetAllAsync()
        {
            
            try
            {                
                var response = await _httpClient.GetAsync(resource);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var cliente = JsonSerializer.Deserialize<IEnumerable<ClienteResponseDto>>(content, _jsonOptions);

                    _logger.LogInformation("cliente carregados com sucesso");
                    return ApiResponse<IEnumerable<ClienteResponseDto>>.SuccessResponse(cliente);
                }

                _logger.LogWarning("Falha ao carregar cliente. Status: {StatusCode}", response.StatusCode);
                return ApiResponse<IEnumerable<ClienteResponseDto>>.ErrorResponse(
                    $"Erro ao carregar cliente: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar cliente");
                return ApiResponse<IEnumerable<ClienteResponseDto>>.ErrorResponse(
                    "Erro interno ao carregar cliente");
            }

        }

        public async Task<ApiResponse<ClienteResponseDto>> GetByIdAsync(int id)
        {
           
            try
            {
                var response = await _httpClient.GetAsync($"{resource}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var cliente = JsonSerializer.Deserialize<ClienteResponseDto>(content, _jsonOptions);

                    _logger.LogInformation("cliente {Id} carregado com sucesso", id);
                    return ApiResponse<ClienteResponseDto>.SuccessResponse(cliente);
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<ClienteResponseDto>.ErrorResponse(
                        "cliente não encontrado", 404);
                }

                _logger.LogWarning("Falha ao carregar cliente {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<ClienteResponseDto>.ErrorResponse(
                    $"Erro ao carregar cliente: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar cliente {Id}", id);
                return ApiResponse<ClienteResponseDto>.ErrorResponse(
                    "Erro interno ao carregar cliente");
            }
        }

        public async Task<ApiResponse<ClienteResponseDto>> CreateAsync(ClienteDto dto)
        {
           
            try
            {
                var json = JsonSerializer.Serialize(dto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(resource, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var cliente = JsonSerializer.Deserialize<ClienteResponseDto>(responseContent, _jsonOptions);

                    _logger.LogInformation("cliente criado com sucesso");
                    return ApiResponse<ClienteResponseDto>.SuccessResponse(cliente, "cliente criado com sucesso");
                }

                _logger.LogWarning("Falha ao criar cliente. Status: {StatusCode}", response.StatusCode);
                return ApiResponse<ClienteResponseDto>.ErrorResponse(
                    $"Erro ao criar cliente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar cliente");
                return ApiResponse<ClienteResponseDto>.ErrorResponse(
                    "Erro interno ao criar cliente");
            }
        }

        public async Task<ApiResponse<bool>> UpdateAsync(int id, ClienteDto dto)
        {
            try
            {
                foreach (var telefone in dto.Telefones)
                {
                    telefone.CodigoCliente = id;
                    telefone.Ativo = true;
                   
                }
                
                                            
                var json = JsonSerializer.Serialize(dto, _jsonOptions);
                
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{resource}/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("cliente {Id} atualizado com sucesso", id);
                    return ApiResponse<bool>.SuccessResponse(true, "cliente atualizado com sucesso");
                }

                _logger.LogWarning("Falha ao atualizar cliente {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<bool>.ErrorResponse(
                    $"Erro ao atualizar cliente: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar cliente {Id}", id);
                return ApiResponse<bool>.ErrorResponse(
                    "Erro interno ao atualizar cliente");
            }
        }
              

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            
            try
            {
                var response = await _httpClient.DeleteAsync($"{resource}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("cliente {Id} excluído com sucesso", id);
                    return ApiResponse<bool>.SuccessResponse(true, "cliente excluído com sucesso");
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        "cliente não encontrado para exclusão", 404);
                }

                _logger.LogWarning("Falha ao excluir cliente {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<bool>.ErrorResponse(
                    $"Erro ao excluir cliente: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir cliente {Id}", id);
                return ApiResponse<bool>.ErrorResponse(
                    "Erro interno ao excluir cliente");
            }
        }
    }
}
