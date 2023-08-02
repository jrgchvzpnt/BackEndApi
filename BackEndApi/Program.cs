using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;
using BackEndApi.Services.Contrato;
using BackEndApi.Services.Implementacion;
using AutoMapper;
using BackEndApi.DTOs;
using BackEndApi.Utilidades;
using System.Collections.Generic;



//     <>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VentasContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<ITipoProductoService, TipoProductoService>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region PETICIOES API REST
app.MapGet("/tipoproducto/lista", async 
    (
        ITipoProductoService _tipoproductoServicio,
        IMapper _mapper
    ) => {
        var listaTiposproductos = await _tipoproductoServicio.GetList();
        var listaTiposproductosDTO = _mapper.Map<List<TiposProductoDTO>>(listaTiposproductos);

        if (listaTiposproductosDTO.Count > 0)
            return Results.Ok(listaTiposproductosDTO);
        else
           return Results.NotFound();

    });

app.MapGet("/producto/lista", async
    (
        
        IProductoService _productoServicio,
        IMapper _mapper
    ) => {
    var listaproductos = await _productoServicio.GetList();
    var listaproductosDTO = _mapper.Map<List<ProductoDTO>>(listaproductos);

    if (listaproductosDTO.Count > 0)
        return Results.Ok(listaproductosDTO);
    else
        return Results.NotFound();
    });


app.MapPost("/producto/guardar", async(
      ProductoDTO modelo,
      IProductoService _productoServicio,
      IMapper _mapper

    ) => { 
        var _producto = _mapper.Map<Producto>(modelo);
        var _productocreado = await _productoServicio.Add(_producto);

        if (_productocreado.Id != 0)
            return Results.Ok(_mapper.Map<ProductoDTO>(modelo));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);



    });

app.MapPut("/producto/actualizar/{idProducto}", async (
      int idProducto,
      ProductoDTO modelo,
      IProductoService _productoServicio,
      IMapper _mapper

    ) => {
        var _encontrado = await _productoServicio.Get(idProducto);
        if (_encontrado is null) return Results.NotFound();

        var _producto = _mapper.Map<Producto>(modelo);

        _encontrado.NombreProducto = _encontrado.NombreProducto;
        _encontrado.DescripcionProducto = _encontrado.DescripcionProducto;
        _encontrado.Precio = _encontrado.Precio;
        _encontrado.Existencia = _encontrado.Existencia;
        _encontrado.TipoProductoId = _encontrado.TipoProductoId;
        _encontrado.FechaRegistro = _encontrado.FechaRegistro;

        var respuesta = await _productoServicio.Update(_encontrado);

        if (respuesta)
            return Results.Ok(_mapper.Map<ProductoDTO>(_encontrado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);



    });


app.MapDelete("/producto/eliminar/{idProducto}", async (
    int idProducto,
    IProductoService _productoServicio

    ) => {
        var _encontrado = await _productoServicio.Get(idProducto);
        if (_encontrado is null) return Results.NotFound();

        var respuesta = await _productoServicio.Delete(_encontrado);

        if (respuesta)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);

    });



#endregion


app.UseCors("NuevaPolitica");

app.Run();
