﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRL
    {
        public bool Registration(RegisterModel model);
    }
}
