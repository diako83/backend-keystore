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
    public async Task<ActionResult<ServiceResponse<Receipt>>> CreateReceipt(List<Product> getShoppingChart)
    {
        
        return Ok(await _receiptsService.CreateReceipt(getShoppingChart));
    }
    
}