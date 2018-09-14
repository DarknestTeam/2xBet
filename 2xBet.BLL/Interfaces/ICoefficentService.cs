using _2xBet.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Interfaces
{
    public interface ICoefficentService
    {
        void AddCoeff(CoefficentDTO coefficentDTO);
        void ChangeCoefficent(CoefficentDTO coefficentDTO);
        CoefficentDTO GetCoeff(int? id);
    }
}
