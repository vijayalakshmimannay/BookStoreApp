﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IUserBL
    {
        public bool Registration(RegisterModel userRegistrationModel);
        public bool Login(LoginModel loginModel);
    }
}
