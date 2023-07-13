using System;
using BackendSolution.Models;

namespace BackendSolution.ServiceImpl
{
	public interface PersonServiceInterface
	{
        void SavePersonDetails(PersonRequest request);
        void UpdatePersonDetails(PersonRequest request);
        void DeletePersonDetails(PersonRequest request);
        Person SelectPersonDetails(PersonRequest request);
    }

}

