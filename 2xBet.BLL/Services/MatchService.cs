using _2xBet.BLL.DTO;
using _2xBet.BLL.Infrastructure;
using _2xBet.BLL.Interfaces;
using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Services
{
   public class MatchService:IMatchService
    {
        IUnitOfWork db;
        public MatchService(IUnitOfWork unit)
        {
            db = unit;
        }
        public void CreateMatch(MatchDTO matchDTO)
        {
            if (matchDTO == null)
                throw new ValidationException("Пожалуйста,корректно укажите матч","");
            Match match = new Match
            {
                IsLive = false,
                League = matchDTO.League,
                Match_Id = matchDTO.Match_Id,
                Time = matchDTO.Time,
                TypeOfSport = matchDTO.TypeOfSport
            };
            db.Matches.Create(match);
            db.Save();

        }
        public MatchDTO GetMatch(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлен id матча", "");
            var match = db.Matches.Get(id.Value);
            if (match == null)
                throw new ValidationException("матч не найден", "");
            return new MatchDTO { IsLive = false, League = match.League, Match_Id = match.Match_Id, Time = match.Time, TypeOfSport = match.TypeOfSport };
        }
        public void DeleteMatch(int? id)
        {
            if (id == null)
                throw new ValidationException("не найден матч с данным id", "");
            else if (db.Matches.Get(id.Value) == null)
                throw new ValidationException("не найдена карточка", "");
            else
                db.Matches.Delete(id);
        }
        public void ChangeMatch(MatchDTO matchDTO)
        {
            Match match = db.Matches.Get(matchDTO.Match_Id);
            if (match == null)
            {
                throw new ValidationException("данный матч не найден или пуст", "");
            }
            match = new Match
            {
                IsLive = false,
                League = matchDTO.League,
                Match_Id = matchDTO.Match_Id,
                Time = matchDTO.Time,
                TypeOfSport = matchDTO.TypeOfSport
            };
            db.Matches.Create(match);
            db.Save();
        }
    }
}
