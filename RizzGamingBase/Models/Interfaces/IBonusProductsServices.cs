﻿using RizzGamingBase.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
    public interface IBonusProductsServices
    {
        void Create(BonusProductsDto dto);
        List<BonusProductsDto> GetAll();
        void Edit(BonusProductsDto dto);
        void Delete(BonusProductsDto dto);
    }
}
