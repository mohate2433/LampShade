using _0_Framework.Application;
using DiscountManagement.Application.Contract.Contract;
using DiscountManagement.Application.Contract.Dtos.ColleagueDiscounts;
using DiscountManagement.Domain.ColleagueDiscountAggregate;
using DiscountManagement.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Services
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OprationResult Define(DefineColleagueDiscount command)
        {
            var opration = new OprationResult();
            if (_colleagueDiscountRepository.Exists(x => x.DiscountRate == command.DiscountRate && x.ProductId == command.ProductId))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);
            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return opration.Succedded();
                
        }

        public OprationResult Edit(EditColleagueDiscount command)
        {

            var opration = new OprationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (colleagueDiscount == null) return opration.Failed(ApplicationMessages.NotFoundMessage);
            if (_colleagueDiscountRepository.Exists(x => 
            x.DiscountRate == command.DiscountRate && x.ProductId == command.ProductId && x.ID != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);
            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return opration.Succedded();
        }

        public EditColleagueDiscount GetDetail(long id)
        {
            return _colleagueDiscountRepository.GetDetail(id);
        }

        public OprationResult Remove(long id)
        {
            var opration = new OprationResult();
            var collegueDiscount = _colleagueDiscountRepository.Get(id);
            if (collegueDiscount == null) return opration.Failed(ApplicationMessages.NotFoundMessage);
            collegueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return opration.Succedded();
        }

        public OprationResult Restore(long id)
        {
                var opration = new OprationResult();
            var collegueDiscount = _colleagueDiscountRepository.Get(id);
            if (collegueDiscount == null) return opration.Failed(ApplicationMessages.NotFoundMessage);
            collegueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return opration.Succedded();
        }

        public List<ColleagueDiscountDto> Search(SearchColleagueDiscount search)
        {
            return _colleagueDiscountRepository.Search(search);
        }
    }
}
