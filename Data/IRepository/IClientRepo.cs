using System.Collections.Generic;


namespace Data.Repository
{
    public interface IClientRepo
    {
        void Create(Client client);
        void Delete(int id);
        List<Client> Get();
        Client Get(int id);
        void Update(Client client);
    }
}