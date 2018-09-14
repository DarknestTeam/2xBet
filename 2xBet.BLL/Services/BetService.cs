using _2xBet.BLL.DTO;
using _2xBet.BLL.Infrastructure;
using _2xBet.BLL.Interfaces;
using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Services
{
    public class BetService : IBetService
    {
        IUnitOfWork db;
        public BetService(IUnitOfWork  uow)
        {
            db = uow;
        }
        public IEnumerable<BetDTO> Bets()
        {   
            
            Mapper.Initialize(cfg => cfg.CreateMap<Bet,BetDTO>());
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bet, BetDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Bet>, List<BetDTO>>(db.Bets.GetAll());
     
        }

        public void ChangeBet(BetDTO betDTO)
        {
            Bet bet = db.Bets.Get(betDTO.Bet_Id);
            if (bet == null)
            {
                throw new ValidationException("Данная ставка не найдена. Проверьте введённые данные", "");
            }
            //else if (bet == null)
            //{
            //    throw new ValidationException("Данный пользователь не найден", "");
            //}
            else
            {
                bet = new Bet
                {
                    Choise = betDTO.Choise,
                    Date = betDTO.Date,
                    Result = betDTO.Result,
                    Amount = betDTO.Amount
                };
                db.Bets.Update(bet);
                db.Save();
            }
        }

        public void CreateBet(BetDTO betDTO)
        {
           /// Bet bet = db.Bets.Get(betDTO.Bet_Id);
            if (betDTO == null)
            {
                throw new ValidationException("Данные о ставке отсутствуют ", "");
            }

            else
            {
                //Bet bet = new Bet
                // {
                //     Bet_Id = betDTO.Bet_Id,
                //     Amount = betDTO.Amount,
                //     Choise = betDTO.Choise,
                //     Date = betDTO.Date,
                //     MatchId = betDTO.MatchId,
                //     Result = betDTO.Result,
                //     UserId = betDTO.UserId
                // };
                Mapper.Initialize(cfg => cfg.CreateMap<BetDTO, Bet>());
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BetDTO,Bet>()).CreateMapper();
                Bet bet = Mapper.Map<BetDTO, Bet>(betDTO);
                db.Bets.Create(bet);

                db.Save();
            }

        }

        public void Delete(int? Id)
        {
            if (Id == null)
            {
                throw new ValidationException("Не установлен Id ставки", "");
            }
            else if ((db.Bets.Get(Id) == null))
            {
                throw new ValidationException("Данная ставка не найдена", "");
            }
            else
            {
              db.Bets.Delete(Id);
            }

        }

        public BetDTO Get(int? id)
        {
            Bet bet = db.Bets.Get(id);
            if (id == null)
            {
                throw new ValidationException("Не установлен Id ставки", "");
            }
            else if (bet == null)
            {
                throw new ValidationException("Данная ставка не найдена", "");
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Bet, BetDTO>());
                BetDTO betDTO = Mapper.Map<Bet, BetDTO>(bet);
                return betDTO;
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
