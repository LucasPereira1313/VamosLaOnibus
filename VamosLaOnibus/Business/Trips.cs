using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VamosLaOnibus.Models;
using VamosLaOnibus.Business;
using System.Globalization;

namespace VamosLaOnibus.Business
{
    public class Trips
    {
        Business.DataService database = new Business.DataService();

        /// <summary>
        /// Get all list of trips, doing  descend order and get total order.
        /// </summary>
        /// <param name="amount">Take total</param>
        /// <returns></returns>
        public async Task<List<TripWithImage>> GetStart(int amount)
        {
            try
            {
                TripResults datalist = await database.GetTripAsync();
                List<TripWithImage> datawithimage = null;

                if (datalist != null &&
                    datalist.results != null)
                {
                    datawithimage = datalist.ConvertWithImage();

                    return ( from TripWithImage x in datawithimage
                             orderby x.Price descending
                             select x ).Take(amount).ToList();

                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get all list of trips, doing  descend order and get total order.
        /// </summary>
        /// <param name="amount">Take total</param>
        /// <returns></returns>
        public async Task<List<TripWithImage>> GetStart(string date, string classbuss, string money)
        {
            try
            {
                TripResults datalist = await database.GetTripAsync();
                List<TripWithImage> datawithimage = null;

                if (datalist != null &&
                    datalist.results != null)
                {
                    datawithimage = datalist.ConvertWithImage();


                    DateTime datevalue;
                    if (!DateTime.TryParseExact(date, "yyyy-MM-dd", 
                                                CultureInfo.InvariantCulture,
                                                DateTimeStyles.None, 
                                                out datevalue))
                    {
                        datevalue = DateTime.Now;
                    }

                    double moneyvalue;
                    if (!double.TryParse(money, out moneyvalue))
                    {
                        moneyvalue = 0;
                    }


                    return ( from TripWithImage x in datawithimage
                             where x.BusClass.Equals(classbuss, StringComparison.CurrentCultureIgnoreCase)
                             orderby x.Price descending
                             select x ).ToList();

                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<String>> GetBusClass()
        {
            try
            {
                TripResults datalist = await database.GetTripAsync();
                List<TripWithImage> datawithimage = null;

                if (datalist != null &&
                    datalist.results != null)
                {
                    datawithimage = datalist.ConvertWithImage();

                    return ( from TripWithImage x in datawithimage
                             group x by x.BusClass into y
                             orderby y.Key ascending
                             select y.Key).ToList();

                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
