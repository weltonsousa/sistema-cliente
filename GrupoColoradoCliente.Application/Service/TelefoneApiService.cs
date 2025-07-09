using Microsoft.Extensions.Logging;
using SistemaCliente.Application.DTOs;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Interface;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SistemaCliente.Application.Service
{
    public class TelefoneApiService : ITelefoneApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TelefoneApiService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string resource = "https://localhost:7287/api/telefone";

        public TelefoneApiService(HttpClient httpClient, ILogger<TelefoneApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<ApiResponse<IEnumerable<TelefoneResponseDto>>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(resource);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var telefone = JsonSerializer.Deserialize<IEnumerable<TelefoneResponseDto>>(content, _jsonOptions);

                    _logger.LogInformation("Telefone carregados com sucesso");
                    return ApiResponse<IEnumerable<TelefoneResponseDto>>.SuccessResponse(telefone);
                }

                _logger.LogWarning("Falha ao carregar telefone. Status: {StatusCode}", response.StatusCode);
                return ApiResponse<IEnumerable<TelefoneResponseDto>>.ErrorResponse(
                    $"Erro ao carregar telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar telefone");
                return ApiResponse<IEnumerable<TelefoneResponseDto>>.ErrorResponse(
                    "Erro interno ao carregar telefone");
            }
        }

        public async Task<ApiResponse<TelefoneResponseDto>> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{resource}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var telefone = JsonSerializer.Deserialize<TelefoneResponseDto>(content, _jsonOptions);

                    _logger.LogInformation("Telefone {Id} carregado com sucesso", id);
                    return ApiResponse<TelefoneResponseDto>.SuccessResponse(telefone);
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<TelefoneResponseDto>.ErrorResponse(
                        "Telefone não encontrado", 404);
                }

                _logger.LogWarning("Falha ao carregar elefone {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<TelefoneResponseDto>.ErrorResponse(
                    $"Erro ao carregar telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar elefone {Id}", id);
                return ApiResponse<TelefoneResponseDto>.ErrorResponse(
                    "Erro interno ao carregar telefone");
            }
        }

        public async Task<ApiResponse<TelefoneResponseDto>> CreateAsync(TelefoneDto dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(resource, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var telefone = JsonSerializer.Deserialize<TelefoneResponseDto>(responseContent, _jsonOptions);

                    _logger.LogInformation("Telefone criado com sucesso");
                    return ApiResponse<TelefoneResponseDto>.SuccessResponse(telefone, "Telefone criado com sucesso");
                }

                _logger.LogWarning("Falha ao criar telefone. Status: {StatusCode}", response.StatusCode);
                return ApiResponse<TelefoneResponseDto>.ErrorResponse(
                    $"Erro ao criar telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar telefone");
                return ApiResponse<TelefoneResponseDto>.ErrorResponse(
                    "Erro interno ao criar telefone");
            }
        }

        public async Task<ApiResponse<bool>> UpdateAsync(int id, TelefoneDto dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{resource}/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Telefone {Id} atualizado com sucesso", id);
                    return ApiResponse<bool>.SuccessResponse(true, "Telefone atualizado com sucesso");
                }

                _logger.LogWarning("Falha ao atualizar telefone {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<bool>.ErrorResponse(
                    $"Erro ao atualizar telefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar telefone {Id}", id);
                return ApiResponse<bool>.ErrorResponse(
                    "Erro interno ao atualizar telefone");
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{resource}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Telefone {Id} excluído com sucesso", id);
                    return ApiResponse<bool>.SuccessResponse(true, "Telefone excluído com sucesso");
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        "Telefone não encontrado para exclusão", 404);
                }

                _logger.LogWarning("Falha ao excluir telefone {Id}. Status: {StatusCode}", id, response.StatusCode);
                return ApiResponse<bool>.ErrorResponse(
                    $"Erro ao excluir ttelefone: {response.StatusCode}",
                    (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir telefone {Id}", id);
                return ApiResponse<bool>.ErrorResponse(
                    "Erro interno ao excluir telefone");
            }
        }
    }
}
