using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class MemberService
    {
        private readonly MemberContext _context;

        public MemberService(MemberContext context)
        {
            _context = context;
        }

        public MemberModel Get_Member_Information_By_ID(string id)
        {
            return _context.Members.Where(m => m.Id == int.Parse(id)).FirstOrDefault();
        }


        public MemberModel Get_Member_Address_By_ID(string id)
        {
            return _context.Members.Include(a => a.Addresses).Where(a => a.Id == int.Parse(id)).FirstOrDefault();
        }


        public IEnumerable<MemberModel> List_Members()
        {
            return _context.Members.ToList();
        }

        public MemberModel Add_Members(MemberModel data)
        {
            _context.Add(data);
            _context.SaveChanges();

            return data;
        }
    }

}
