using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.ViewModels;
using TaxFairy.Infrastructure.Data.Models;
using TaxFairy.Infrastructure.Repositories;

namespace TaxFairy.Core.Services
{
    public class VendorService : IVendorService
    {
        private readonly ITaxFairyDbRepository repo;


        public VendorService(ITaxFairyDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> CreateVendor(VendorCreateViewModel model)
        {
            bool created = false;

            if (!repo.All<Vendor>().Any(v=>v.Identifier== model.Identifier))
            {
                var vendor = new Vendor()
                {
                    Name = model.Name,
                    Identifier = model.Identifier,
                    TaxIdentifier = model.TaxIdentifier,
                    Address = model.Address,
                    АccountablePerson = model.АccountablePerson,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };
                if (vendor != null)
                {

                    await repo.AddAsync(vendor);
                    await repo.SaveChangesAsync();
                    created = true;
                }
            }
            else
            {
                created = false;
            }

            

            return created;
        }

        public async Task<IEnumerable<VendorListViewModel>> GetVendorList()
        {
            return await repo.All<Vendor>()
                .Select(v => new VendorListViewModel()
                {
                    Id = v.Id,
                    Name = v.Name,
                    AccountablePerson=v.АccountablePerson,
                    Identifier = v.Identifier,
                    TaxIdentifier = v.TaxIdentifier,

                })
                .ToListAsync();
        }

        public async Task<VendorEditViewModel> GetVendorToEdit(string id)
        {
            var vendor= await repo.GetByIdAsync<Vendor>(id);

            return new VendorEditViewModel()
            {
                Id = vendor.Id,
                Name = vendor.Name,
                АccountablePerson = vendor.АccountablePerson,
                Identifier = vendor.Identifier,
                TaxIdentifier = vendor.TaxIdentifier,
                Email = vendor.Email,
                PhoneNumber = vendor.PhoneNumber,

            };

        }
        public async Task<bool> EditVendor(VendorEditViewModel model)
        {
            bool result = false;
            var vendor = await repo.GetByIdAsync<Vendor>(model.Id);

            if (vendor != null)
            {
                vendor.Id = model.Id;
                vendor.Name = model.Name;
                vendor.АccountablePerson = model.АccountablePerson;
                vendor.Identifier = model.Identifier;
                vendor.TaxIdentifier = model.TaxIdentifier;
                vendor.Email = model.Email;
                vendor.PhoneNumber = model.PhoneNumber;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
