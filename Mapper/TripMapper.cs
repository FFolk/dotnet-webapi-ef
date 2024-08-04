using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.DTOs.Trip;
using dotnet_webapi_ef.Models;

namespace dotnet_webapi_ef.Mapper
{
    public static class TripMapper
    {
        //Method to map from Model => Dio
        public static TripDTO toTripDTO(this Trip trip)
        {
            return new TripDTO
            {
                Idx = trip.Idx,
                Name = trip.Name,
                Country = trip.Country,
                Destinationid = trip.Destinationid,
                Coverimage = trip.Coverimage,
                Detail = trip.Detail,
                Price = trip.Price,
                Duration = trip.Duration,
                Destination = trip.Destination.toDesinationDio()
            };
        }
    }
}

