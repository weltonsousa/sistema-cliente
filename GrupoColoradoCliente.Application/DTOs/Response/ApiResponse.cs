namespace SistemaCliente.Application.DTOs.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Operação realizada com sucesso")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = 200
            };
        }

        public static ApiResponse<T> ErrorResponse(string message, int statusCode = 500)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Data = default(T),
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
