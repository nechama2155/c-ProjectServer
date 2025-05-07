using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalCustomersService : IDalCustomers
    {
        dbcontext db ;
        
        public DalCustomersService(dbcontext data)
        {
            db = data;
        }

        public List<Customer> GetCustomers()
        {
            var a = db.Customers.
                      Include(x => x.ApartmentDetails)
                          .ThenInclude(c => c.Apartment)
                              .ThenInclude(s => s.Assessment)
                      .Include(x=>x.ApartmentDetails)
                          .ThenInclude(c=> c.Apartment)
                              .ThenInclude(s => s.Assessor)
                      .Include(x => x.ApartmentDetails)
                          .ThenInclude(a => a.Apartment)
                              .ThenInclude(s => s.Chats).ToList();
            return a;
        }
        public List<Assessor> GetAssessors(string id)
        {
            Customer? C = GetCustomers().Find(x => x.CustomerId == id);
            var a = C.ApartmentDetails.Select(x => x.Apartment).Select(c=>c.Assessor).ToList();
            return a;

        }
        public List<Models.Application> GetApplications(string id)
        {

            Customer? C = GetCustomers().Find(x => x.CustomerId == id);
            var a = C.ApartmentDetails.Select(x => x.Apartment).ToList();
            return a;

        }

        public List<Models.Assessment> GetAssessments(string id)
        {

            Customer? C = GetCustomers().Find(x => x.CustomerId == id);
            var a = C.ApartmentDetails.Select(x => x.Apartment).Select(c => c.Assessment).ToList();
            return a;


        }
        public List<Models.ApartmentDetail> GetApartmentsDetails(string id)
        {
            var a = db.ApartmentDetails.Where(x => x.CustomerId == id).ToList();
            return a;


        }

        public List<ICollection<Chat>> GetChats(string id)
        {
            List<Customer> lst = db.Customers.ToList();
            Customer? A = lst.Find(x => x.CustomerId == id);
            var a = A.ApartmentDetails.Select(x => x.Apartment).Select(r=>r.Chats).ToList();
            return a;

        }
        public async Task Add(Customer customer)
        {
          db.Customers.Add(customer);
          await  db.SaveChangesAsync();
        }

        public void Update(Customer customer)
        {
            Customer? cust = db.Customers.Find(customer.CustomerId);
            if (cust != null)
            {
                cust.CustomerFirstName = customer.CustomerFirstName;
                cust.CustomerLastName = customer.CustomerLastName;
                cust.CustomerCity = customer.CustomerCity;
                cust.CustomerAddress = customer.CustomerAddress;
                cust.CustomerPhone = customer.CustomerPhone;
                cust.CustomerEmail = customer.CustomerEmail;
            }
            db.SaveChanges();
        }
        public void Delete(string id)
        {
            var list = db.Customers.ToList();
            var c = list.Find(x => x.CustomerId == id);
            db.Customers.Remove(c);
            db.SaveChanges();

        }
    }
}
