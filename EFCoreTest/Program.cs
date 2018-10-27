using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MyDbContext())
            {
                //var tour = new TourEntity();
                //tour.Name = "Tour";
                //tour.Price = 100;
                //tour.BeginDate = DateTime.Now;
                //tour.EndDate = DateTime.Now.AddDays(10);
                //ctx.Products.Add(tour);


                var hotel = new HotelEntity();
                hotel.Name = "Tour";
                hotel.Price = 100;
                hotel.Level = HotelLevel.Five;
                ctx.Products.Add(hotel);

                ctx.SaveChanges();

                var tours = ctx.Tours.ToList();

                var products = ctx.Products.ToList();
            }
        }
    }
}
