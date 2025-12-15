using Fantasy.Backend.UnitsOfWork.Interfaces;
using Fantasy.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Backend.Controllers;

[ApiController]
public class GenericController<T> : Controller where T: class
{
    private readonly IGenericUnitOfWork<T> _unitOfWork;

    public GenericController(IGenericUnitOfWork<T> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAsync()
    {
        var response = await _unitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetAsync(int id)
    {
        var response = await _unitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound();
    }

    [HttpPost]
    public virtual async Task<IActionResult> PostAsync(T model)
    {
        var response = await _unitOfWork.AddAsync(model);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest(response.Message);
    }

    [HttpPut]
    public virtual async Task<IActionResult> PutAsync(T model)
    {
        var response = await _unitOfWork.UpdateAsync(model);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest(response.Message);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await _unitOfWork.DeleteAsync(id);
        if (response.WasSuccess)
        {
            return NoContent();
        }
        return BadRequest(response.Message);
    }

    [HttpGet("paginated")]
    public virtual async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var response = await _unitOfWork.GetAsync(pagination);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("totalRecords")]
    public virtual async Task<IActionResult> GetTotalRecordsAsync()
    {
        var response = await _unitOfWork.GetTotalRecordsAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }
}
