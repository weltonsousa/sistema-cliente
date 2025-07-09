using SistemaCliente.Application.DTOs.Response;

namespace SistemaCliente.Application.Extensions
{
    public static class ApiResponseExtensions
    {
        public static IEnumerable<T> GetSafeData<T>(this ApiResponse<IEnumerable<T>> response)
        {
            return response?.Data ?? Enumerable.Empty<T>();
        }
    }

}
