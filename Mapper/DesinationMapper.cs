using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Controllers;
using dotnet_webapi_ef.DTOs.Desination;
using dotnet_webapi_ef.Models;

namespace dotnet_webapi_ef.Mapper
{
    public static class DesinationMapper
    {
        public static DestinationDTO toDesinationDio(this Destination destination)
        {
            return new DestinationDTO
            {
                Idx = destination.Idx,
                Zone = destination.Zone
            };

        }
    }
}