using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCliente.Application.DTOs.Response;
using SistemaCliente.Application.Interface;
using WebAppMVC.Extensions;
using WebAppMVC.Mappers;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class ClienteController : Controller
    {        
        private readonly IClienteApiService _clienteApiService;
        private readonly ITipoTelefoneApiService _tipoTelefoneApiService;

        public ClienteController(IClienteApiService clienteApiService, ITipoTelefoneApiService tipoTelefoneApiService)
        {
            _clienteApiService = clienteApiService;
            _tipoTelefoneApiService = tipoTelefoneApiService ?? throw new ArgumentNullException(nameof(tipoTelefoneApiService));
        }

        public async Task<IActionResult> Index()
        {
            var response = await _clienteApiService.GetAllAsync();

            if (!response.Success || response.Data == null)
            {
                ViewBag.ErrorMessage = response.Message ?? "Erro ao buscar os clientes.";
                return View(new List<ClienteViewModel>());
            }

            var viewModels = response.Data
                .Select(ClienteViewModelMapper.MapFromResponseDto)
                .ToList();

            return View(viewModels);
        }
                        
        public async Task<IActionResult> Details(int id)
        {
            var response = await _clienteApiService.GetByIdAsync(id);

            if (!response.Success)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(response.Data);
        }

        public async Task<IActionResult> Create()
        {
            var model = new ClienteViewModel();
            model.Telefones.Add(new TelefoneViewModel());

            await LoadTiposTelefone(); 
            return PartialView("_Form", model); 
        }
            
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                await LoadTiposTelefone();
                ViewBag.FormAction = "Create";
                var html = await this.RenderViewAsync("_Form", viewModel, true);
                return Json(new { isValid = false, html });
            }
                        
            await PreencherDescricaoTipoTelefone(viewModel.Telefones);


            var dto = ClienteViewModelMapper.MapToRequestDto(viewModel);
            var response = await _clienteApiService.CreateAsync(dto);

            if (response.Success)
            {             

                var clientesResponse = await _clienteApiService.GetAllAsync();

                var clientesViewModel = clientesResponse.Data
                    .Select(ClienteViewModelMapper.MapFromResponseDto)
                    .ToList();

                var html = await this.RenderViewAsync("_ViewAll", clientesViewModel, true);

                return Json(new { isValid = true, html });
            }
                       
            return Json(new { isValid = false, message = response.Message });

        }

        private async Task PreencherDescricaoTipoTelefone(List<TelefoneViewModel> telefones)
        {
            var tiposTelefoneResponse = await _tipoTelefoneApiService.GetAllAsync();

            if (tiposTelefoneResponse != null && tiposTelefoneResponse.Success && tiposTelefoneResponse.Data.Any())
            {                
                var tiposTelefoneMap = tiposTelefoneResponse.Data
                    .ToDictionary(t => t.CodigoTipoTelefone, t => t.DescricaoTipoTelefone);

                foreach (var telefone in telefones)
                {
                    if (telefone.CodigoTipoTelefone > 0)
                    {                        
                        if (tiposTelefoneMap.TryGetValue(telefone.CodigoTipoTelefone, out var descricao))
                        {
                            telefone.DescricaoTipoTelefone = descricao;
                        }
                    }
                }
            }
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _clienteApiService.GetByIdAsync(id);

            if (!response.Success || response.Data == null)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            var model = ClienteViewModelMapper.MapFromResponseDto(response.Data);

            if (model.Telefones == null || !model.Telefones.Any())
            {
                model.Telefones = new List<TelefoneViewModel>
                {
                    new TelefoneViewModel()
                };
            }
                await LoadTiposTelefone();
                ViewBag.FormAction = "Edit";

                return PartialView("_Form", model);
        }
                

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadTiposTelefone();
                return PartialView("_Form", model);
            }

            await PreencherDescricaoTiposTelefone(model);

            var dto = ClienteViewModelMapper.MapToRequestDto(model);
            var response = await _clienteApiService.UpdateAsync(id, dto);

            if (response.Success)
            {                
                var clientesResponse = await _clienteApiService.GetAllAsync();

                var clientesViewModel = clientesResponse.Data
                    .Select(ClienteViewModelMapper.MapFromResponseDto)
                    .ToList();

                var html = await this.RenderViewAsync("_ViewAll", clientesViewModel, true);

                return Json(new { isValid = true, html });
            }

            ModelState.AddModelError(string.Empty, response.Message);
            await LoadTiposTelefone();
            return PartialView("_Form", model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clienteApiService.GetByIdAsync(id);

            if (!response.Success)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(response);
        }

        [HttpPost, ActionName("Delete")]       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             var response = await _clienteApiService.DeleteAsync(id);
           
            if (response.Success)
            {                
                var clientesResponse = await _clienteApiService.GetAllAsync();

                var clientesViewModel = clientesResponse.Data
                    .Select(ClienteViewModelMapper.MapFromResponseDto)
                    .ToList();

                var html = await this.RenderViewAsync("_ViewAll", clientesViewModel, true);

                return Json(new { isValid = true, html });
            }
           
            var clientes = await _clienteApiService.GetAllAsync();
            return PartialView("_ClientesList", clientes.Data);
        }

        private async Task LoadTiposTelefone()
        {
            var response = await _tipoTelefoneApiService.GetAllAsync();

            if (response.Success && response.Data != null)
            {
                ViewBag.TiposTelefone = new SelectList(
                    response.Data,
                    nameof(TipoTelefoneResponseDto.CodigoTipoTelefone),
                    nameof(TipoTelefoneResponseDto.DescricaoTipoTelefone)
                );
            }
            else
            {
                ViewBag.TiposTelefone = new SelectList(new List<TipoTelefoneResponseDto>(), "CodigoTipoTelefone", "DescricaoTipoTelefone");
                ViewBag.ErrorMessage = response.Message ?? "Erro ao carregar tipos de telefone.";
            }
        }

        private async Task PreencherDescricaoTiposTelefone(ClienteViewModel model)
        {
            var response = await _tipoTelefoneApiService.GetAllAsync();

            if (!response.Success || response.Data == null)
                return;

            var tiposTelefone = response.Data.ToList();

            foreach (var telefone in model.Telefones)
            {
                if (telefone.CodigoTipoTelefone > 0)
                {
                    var tipo = tiposTelefone.FirstOrDefault(t => t.CodigoTipoTelefone == telefone.CodigoTipoTelefone);
                    telefone.DescricaoTipoTelefone = tipo?.DescricaoTipoTelefone;
                }
            }
        }


    }
}

