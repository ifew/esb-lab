using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class UtilityService
    {
        private readonly UtilityContext _context;

        public UtilityService(UtilityContext context)
        {
            _context = context;
        }

        public IEnumerable<Zipcode> ListZipcode()
        {
            return _context.Zipcode.ToList();
        }

        public IEnumerable<Zipcode> ListZipcode_by_Province_Code(string id)
        {
            IEnumerable<Zipcode> listResult = _context.Zipcode
                    .Where(m => m.PROVINCE_CODE == int.Parse(id) && m.ZIP_CODE != 0 )
                    .GroupBy(m => m.ZIP_CODE)
                    .Select(m => m.FirstOrDefault())
                    .OrderBy(m => m.ZIP_CODE)
                    .ToList();

            return listResult;
        }

    }

}
