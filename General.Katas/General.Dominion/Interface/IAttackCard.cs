﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Dominion.Interface
{
    public interface IAttackCard : ICard
    {
        void Attack(Game game);
    }
}
