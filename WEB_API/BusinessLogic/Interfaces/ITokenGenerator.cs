﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken (UserContact contact); 
    }
}
