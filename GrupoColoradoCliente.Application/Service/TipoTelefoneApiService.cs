using Microsoft.Extensions.Logging;
using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Interface;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SistemaCliente.Application.Service
{
    public class TipoTelefoneApiService : ITipoTelefoneApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TipoTelefoneApiService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string resource = "https://localhost:7287/api/tipotelefones";

        public TipoTelefoneApiService(HttpClient httpClient, ILogger<TipoTelefoneApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<ApiResponse<IEnumerable<TipoTelefoneResponseDto>>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(resource);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tiposTelefone = JsonSerializer.Deserialize<IEnumerable<TipoTelefoneResponseDto>>(content, _jsonOptions);

                    _logger.LogInformation("Tipos de telefone carregados com sucesso");
                    return ApiResponse<IEnumerable<TipoTelefoneResponseDto>>.SuccessResponse(tiposTelefone);
                }

                _logger.LogWarning("Falha ao carregar tipos de telefone. Status: {StatusCode}", response.StatusCode);
                return ApiResponse<IEnumerable<TipoTelefoneResponseDto>>.ErrorResponse(
                    $"Erro ao carregar tipos de telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar tipos de telefone");
                return ApiResponse<IEnumerable<TipoTelefoneResponseDto>>.ErrorResponse(
                    "Erro interno ao carregar tipos de telefone");
            }
        }

        public async Task<ApiResponse<TipoTelefoneResponseDto>> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{resource}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tipoTelefone = JsonSerializer.Deserialize<TipoTelefoneResponseDto>(content, _jsonOptions);

                    _logger.LogInformation("Tipo de telefone {Id} carregado com sucesso", id);
                    return ApiResponse<TipoTelefoneResponseDto>.SuccessResponse(tipoTelefone);
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<TipoTelefoneResponseDto>.ErrorResponse(
                        "Tipo de telefone não encontrado", 404);
                }

                _logger.LogWarning("Falha ao carregar tipo de telefone {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<TipoTelefoneResponseDto>.ErrorResponse(
                    $"Erro ao carregar tipo de telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar tipo de telefone {Id}", id);
                return ApiResponse<TipoTelefoneResponseDto>.ErrorResponse(
                    "Erro interno ao carregar tipo de telefone");
            }
        }

        public async Task<ApiResponse<TipoTelefoneResponseDto>> CreateAsync(TipoTelefoneDto dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(resource, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var tipoTelefone = JsonSerializer.Deserialize<TipoTelefoneResponseDto>(responseContent, _jsonOptions);

                    _logger.LogInformation("Tipo de telefone criado com sucesso");
                    return ApiResponse<TipoTelefoneResponseDto>.SuccessResponse(tipoTelefone, "Tipo de telefone criado com sucesso");
                }

                _logger.LogWarning("Falha ao criar tipo de telefone. Status: {StatusCode}", response.StatusCode);
                return ApiResponse<TipoTelefoneResponseDto>.ErrorResponse(
                    $"Erro ao criar tipo de telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar tipo de telefone");
                return ApiResponse<TipoTelefoneResponseDto>.ErrorResponse(
                    "Erro interno ao criar tipo de telefone");
            }
        }

        public async Task<ApiResponse<bool>> UpdateAsync(int id, TipoTelefoneDto dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{resource}/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Tipo de telefone {Id} atualizado com sucesso", id);
                    return ApiResponse<bool>.SuccessResponse(true, "Tipo de telefone atualizado com sucesso");
                }

                _logger.LogWarning("Falha ao atualizar tipo de telefone {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<bool>.ErrorResponse(
                    $"Erro ao atualizar tipo de telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar tipo de telefone {Id}", id);
                return ApiResponse<bool>.ErrorResponse(
                    "Erro interno ao atualizar tipo de telefone");
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{resource}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Tipo de telefone {Id} excluído com sucesso", id);
                    return ApiResponse<bool>.SuccessResponse(true, "Tipo de telefone excluído com sucesso");
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        "Tipo de telefone não encontrado para exclusão", 404);
                }

                _logger.LogWarning("Falha ao excluir tipo de telefone {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<bool>.ErrorResponse(
                    $"Erro ao excluir tipo de telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir tipo de telefone {Id}", id);
                return ApiResponse<bool>.ErrorResponse(
                    "Erro interno ao excluir tipo de telefone");
            }
        }
    }
}
