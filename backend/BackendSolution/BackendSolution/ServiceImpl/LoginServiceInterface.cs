using System;
using BackendSolution.Models;

namespace BackendSolution.ServiceImpl
{
	public interface LoginServiceInterface
	{
        void SaveLoginDetails(UserLoginRequest saveUserRequest);
        bool LoginCheck(UserLoginRequest userLoginRequest);
        void ResetPassword(UserLoginRequest passwordRestRequest);
    }


}

