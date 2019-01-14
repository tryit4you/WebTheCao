using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTheCao.Data.Interfaces;
using WebTheCao.ViewModels;

namespace WebTheCao.Areas.Admin.Components
{
    public class ChartCardViewComponent:ViewComponent
    {
        private readonly INopCardRepository _nopCardRepository;
        public readonly ICardRepository _cardRepository;
        public ChartCardViewComponent(INopCardRepository nopCardRepository,
            ICardRepository cardRepository)
        {
            _nopCardRepository = nopCardRepository;
            _cardRepository = cardRepository;
        }
        public IViewComponentResult Invoke()
        {
            var nopcards = _nopCardRepository.NopCards();
            var cards = _cardRepository.Cards();
            var data = (from card in cards
                        select new ChartCardViewModel
                        {
                            Label=card.Name,
                            Data=nopcards.Where(x=>x.cardId==card.Id).Count()
                        }).ToList();
            return View(data);
        }
    }
}
