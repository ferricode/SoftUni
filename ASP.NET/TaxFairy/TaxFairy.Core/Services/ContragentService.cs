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
    public class ContragentService : IContragentService
    {
        private readonly ITaxFairyDbRepository repo;


        public ContragentService(ITaxFairyDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> CreateContragent(ContragentCreateViewModel model)
        {
            bool created = false;

            if (!repo.All<Contragent>().Any(v => v.Identifier == model.Identifier))
            {
                var vendor = new Contragent()
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

    
        public async Task<IEnumerable<ContragentListViewModel>> GetContragentList()
        {
            return await repo.All<Contragent>()
                .Select(c => new ContragentListViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    АccountablePerson = c.АccountablePerson,
                    Identifier = c.Identifier,
                    TaxIdentifier = c.TaxIdentifier,

                })
                .ToListAsync();
        }

        public async Task<ContragentEditViewModel> GetContragentToEdit(string id)
        {
            var client = await repo.GetByIdAsync<Contragent>(id);

            return new ContragentEditViewModel()
            {
                Id = client.Id,
                Name = client.Name,
                AccountablePerson = client.АccountablePerson,
                Identifier = client.Identifier,
                TaxIdentifier = client.TaxIdentifier,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,

            };
        }
        public async Task<bool> EditContragent(ContragentEditViewModel model)
        {
            bool result = false;
            var client = await repo.GetByIdAsync<Contragent>(model.Id);

            if (client != null)
            {
                client.Id = model.Id;
                client.Name = model.Name;
                client.АccountablePerson = model.AccountablePerson;
                client.Identifier = model.Identifier;
                client.TaxIdentifier = model.TaxIdentifier;
                client.Email = model.Email;
                client.PhoneNumber = model.PhoneNumber;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
