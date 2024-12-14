using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class ContactUsService
    {
        private ContactUsRepository _repository;

        public ContactUsService(ContactUsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public List<ContactUs> GetContactUsList() => _repository.GetContactUsList();




        public void AddContactUs(ContactUs contactUs)
        {
            _repository.AddContactUs(contactUs);
        }

        public void UpdateContactUs(ContactUs contactUs)
        {
            _repository.UpdateContactUs(contactUs);
        }


        public void DeleteContactUs(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Product ID", nameof(id));
            _repository.DeleteContactUs(id);
        }
    }
}