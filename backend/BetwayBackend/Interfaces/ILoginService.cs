using System;
using BackendSolution.Models;
using BetwayBackend.Request;
using Microsoft.EntityFrameworkCore;

namespace BetwayBackend.Interfaces
{
	public interface ILoginService
    { 
        Boolean Login(UserRequest user);
        void AddDetails(UserLogin userLogin);
        void PasswordReset(UserLogin userLogin);
    }
}

