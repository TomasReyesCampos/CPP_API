using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using AutoMapper;
using CPP.Entities.Data;
using CPP.Entities.Dtos;

namespace CPP.Api
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TipoProveedor, TipoProveedorDto>();
            CreateMap<TipoProveedorDto, TipoProveedor>();

            //Proveedor 
            CreateMap<Proveedor, ProveedorDto>();
            CreateMap<ProveedorDto, Proveedor>();

            //Sucursal 
            CreateMap<Sucursal, SucursalDto>();
            CreateMap<SucursalDto, Sucursal>();

            //Remision 
            CreateMap<RemisionAltaDto, Remision>();
            CreateMap<Remision, RemisionAltaDto>();
            CreateMap<Remision, RemisionDto>();
            CreateMap<RemisionDto, Remision>();

            CreateMap<OrdenPagarDto, Ordenes>();
        }

    }
}
