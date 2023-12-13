using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace ProductApi.Controllers;
[ApiController]
[Route("api/tproducts")]
public class ProductsController:ControllerBase
{
    private readonly RepositoriesContext _repositoriesContext;

    public ProductsController(RepositoriesContext repositoriesContext)
    {
        _repositoriesContext = repositoriesContext;
    }
    [HttpGet]
    public IActionResult GetAllTheProducts(){
        var resutl = _repositoriesContext.Products;
        if(resutl is null){
            return NotFound();
        }
        return Ok(resutl);
    }
    [HttpGet("{id:int}")]
    public IActionResult GetOneProduct([FromRoute(Name = "id")]int id){
        var product = _repositoriesContext.Products.Where(p=>p.ProductId==id).SingleOrDefault();
        if (product is null)
        {
            return NotFound($"There is no Product with the id:{id}!!!");
        }
        return Ok(product);
    }
    [HttpPost]
    public IActionResult AddOneProduct(Product product){
        if (product is null)
        {
            return BadRequest("You Can't add an empty product!!!");
        }
        _repositoriesContext.Products.Add(product);
        _repositoriesContext.SaveChanges();
        return Created($"The Product:{product.ToString()} is added successfully",product);
    }
    [HttpPut]
    public IActionResult UpdateOneProduct(int id, [FromBody] Product product){
        if (product is null && id == 0)
        {
            return BadRequest("You can't add an empty product or try to find a product with the id zero");
        }
        var item = _repositoriesContext.Products.Where(p=> p.ProductId==id).SingleOrDefault();
        if (item is null)
        {
            return NotFound($"Ther is no product with the Id:{id}");
        }
        item.ProductName=product.ProductName;
        item.Price= product.Price;
        _repositoriesContext.Products.Update(item);
        _repositoriesContext.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneProduct([FromRoute(Name ="id")]int id){
        var item = _repositoriesContext.Products.Where(p=>p.ProductId==id).SingleOrDefault();
        if (item is null)
        {
            return NotFound($"There is no product with the Id:{id}");
        }
        _repositoriesContext.Products.Remove(item);
        _repositoriesContext.SaveChanges();
        return Ok($"The Product: {item.ToString()} is deleted succesffuly!!!");
    }
    [HttpDelete]
    public IActionResult DeleteAllProducts(){
        _repositoriesContext.Products.ExecuteDelete();
        _repositoriesContext.SaveChanges();
        return NoContent();
    }
    /* using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
            ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        
                        await context.Response.WriteAsync(new ErrorDetails() { 
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
} */
}