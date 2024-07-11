using ETickets.Models;

namespace ETickets.Data.Services
{
    public interface IActorsServices
    {
        IEnumerable<Actor> GetAll();
        Actor GetById(int id);

        void add(Actor actor);
        void Delete(int id);
        Actor Update(int id, Actor newActor);
    }
}
