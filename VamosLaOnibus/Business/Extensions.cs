using System;
using System.Collections.Generic;
using VamosLaOnibus.Models;

namespace VamosLaOnibus.Business
{
    public static class Extensions
    {

        /// <summary>
        /// Function extensions to convert
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static List<TripWithImage> ConvertWithImage(this TripResults data)
        {
            List<TripWithImage> data_result = new List<TripWithImage>();

            if (data != null &&
                data.results != null)
            {
                foreach (var item in data.results)
                {

                    TripWithImage data_value = new TripWithImage()
                    {
                        objectId = item.objectId,
                        Company = item.Company,
                        Origin = item.Origin,
                        Destination = item.Destination,
                        DepartureDate = item.DepartureDate,
                        createdAt = item.createdAt,
                        updatedAt = item.updatedAt,
                        Price = item.Price,
                        BusClass = item.BusClass,
                        ArrivalDate = item.ArrivalDate,
                    };


                    if (data_value.Company != null)
                    {
                        if (data_value.Company.Name.Equals("Cometa", StringComparison.CurrentCultureIgnoreCase))
                        {
                            data_value.ImageSrc = "Image/Comapany/cometa.png";
                        }
                        else if (data_value.Company.Name.Equals("1001", StringComparison.CurrentCultureIgnoreCase))
                        {
                            data_value.ImageSrc = "Image/Comapany/1001.png";
                        }
                        else if (data_value.Company.Name.Equals("catarinense", StringComparison.CurrentCultureIgnoreCase))
                        {
                            data_value.ImageSrc = "Image/Comapany/catarinense.png";
                        }
                    }

                    data_result.Add(data_value);
                }

                return data_result;

            }

            return null;
        }
    }
}
