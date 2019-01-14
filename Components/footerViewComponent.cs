using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTheCao.Data.Interfaces;

namespace WebTheCao.Components
{
    public class footerViewComponent:ViewComponent
    {
        private readonly IContactRepository _contactRepository;
        public footerViewComponent(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IViewComponentResult Invoke()
        {
            var contact = _contactRepository.Contacts().FirstOrDefault();
            return View(contact);
        }
    }
}
