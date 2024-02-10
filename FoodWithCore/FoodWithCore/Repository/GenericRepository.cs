using FoodWithCore.Models;

namespace CoreAndFood.Repository
{
    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();
        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }
        public void AddT(T t)
        {
            c.Set<T>().Add(t);
            c.SaveChanges();
        }
        public void RemoveT(T t)
        {
            c.Set<T>().Remove(t);
            c.SaveChanges();
        }
        public void UpdateT(T t)
        {
            c.Set<T>().Update(t);
            c.SaveChanges();
        }
        public void FindT(int id)
        {
            c.Set<T>().Find(id);
        }
    }
}
