using _2xBet.BLL.DTO;
using _2xBet.BLL.Interfaces;
using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Services
{
    public class CoefficentService : ICoefficentService
    {
        IUnitOfWork db;
        public CoefficentService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void AddCoeff(CoefficentDTO coefficentDTO)
        {
            if (coefficentDTO == null)
            {
                throw new ValidationException("Данные о пльзователе отсутствуют");
            }

            else
            {
                Coefficent coef = new Coefficent 
                {
                    CoeffDraw = coefficentDTO.CoeffDraw,
                    CoeffLose = coefficentDTO.CoeffLose,
                    CoeffWin = coefficentDTO.CoeffWin,
                    CommandCoeff_Id= coefficentDTO.CommandCoeff_Id,
                    MatchId = coefficentDTO.MatchId
                };

                db.Save();
            }
        }

        public void ChangeCoefficent(int id)
        {
            //  сделаю
        }

        public CoefficentDTO GetCoeff(int id)
        {
            Coefficent coeff = db.Coefficents.Get(id);
            if (id == null)
            {
                throw new ValidationException("Не установлен Id " );
            }
            else if (coeff == null)
            {
                throw new ValidationException("Данные  коэфициенты не найдены");
            }
            else
            {// надо маппер
                CoefficentDTO coefDTO = new CoefficentDTO();
                return coefDTO;
            }
        }
    }
}
