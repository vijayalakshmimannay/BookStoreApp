﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRL
    {
        public bool Registration(RegisterModel model);
        public bool UserLogin(LoginModel loginModel);
        public string ForgetPassword(string EmailId);
       // public bool ResetPassword(ResetModel resetModel);
    }
}
