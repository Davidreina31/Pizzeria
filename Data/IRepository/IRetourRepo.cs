using System.Collections.Generic;
using Data.Models;

namespace Data.Repository
{
    public interface IRetourRepo
    {
        void Create(Retour retour);
        void Delete(int id);
        List<Retour> Get();
        Retour Get(int id);
        void Update(Retour retour);
    }
}