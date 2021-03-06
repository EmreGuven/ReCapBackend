using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : IEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return GetCarsDetails(filter).FirstOrDefault();
        }
        public List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using ReCapContext Cardb = new ReCapContext();
            var result = from c in Cardb.Cars
                         join b in Cardb.Brands
                         on c.BrandId equals b.BrandId
                         join cl in Cardb.Colors
                         on c.ColorId equals cl.ColorId
                         join g in Cardb.Gears
                         on c.GearId equals g.GearId
                         join f in Cardb.Fuels
                         on c.FuelId equals f.FuelId
                         select new CarDetailDto
                         {
                             CarId = c.Id,
                             BrandId = b.BrandId,
                             BrandName = b.BrandName,
                             ColorId = cl.ColorId,
                             ColorName = cl.ColorName,
                             GearId = c.GearId,
                             GearName = g.GearName,
                             FuelId = c.FuelId,
                             FuelName = f.FuelName,
                             CarName = c.CarName,
                             DailyPrice = c.DailyPrice,
                             ModelYear = c.ModelYear,
                             ImagePath = (from ci in Cardb.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()
                         };
            return filter != null ? result.Where(filter).ToList() : result.ToList();
        }

        public List<CarDetailDto> GetDtoByBrandId(int brandId)
        {
            return GetCarsDetails(b => b.BrandId == brandId);
        }

        public List<CarDetailDto> GetDtoByColorId(int colorId)
        {
            return GetCarsDetails(b => b.ColorId == colorId);
        }
    }
}
