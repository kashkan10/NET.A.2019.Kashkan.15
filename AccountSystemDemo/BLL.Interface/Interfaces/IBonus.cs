﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IBonus
    {
        double Add(int sum, CardType type);

        double Withdraw(int sum, CardType type);
    }
}
