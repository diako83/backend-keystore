using backend_keystore.Dto;
using backend_keystore.Dto.RecieptsDto;
using backend_keystore.Models;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;
using backend_keystore.Services.ReceiptServices;
using Microsoft.AspNetCore.Mvc;

namespace backend_keystore.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReceiptController:ControllerBase
{
    private readonly IReceiptsService _receiptsService;

    public ReceiptController(IReceiptsService receiptsService)
    {
        _receiptsService = receiptsService;
    }
    
    
    [HttpPost("receipt")]
    public async Task<ActionResult<ServiceResponse<ReceiptDto>>> CreateReceipt(List<ProductDto> getShoppingChart)
    {
        
        return Ok(await _receiptsService.CreateReceipt(getShoppingChart));
    }
    
}