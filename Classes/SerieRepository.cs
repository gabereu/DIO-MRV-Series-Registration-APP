using System.Collections.Generic;
using interfaces;

namespace Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> Series = new List<Serie>();

        public Serie GetById(int id)
        {
            return this.Series[id];
        }

        public List<Serie> Listing()
        {
            return this.Series;
        }

        public int NextId()
        {
            return this.Series.Count;
        }

        public void Push(Serie entity)
        {
            this.Series.Add(entity);
        }

        public void Remove(int id)
        {
            this.Series[id].Remove();
        }

        public void Update(Serie entity)
        {
            this.Series[entity.Id] = entity;
        }
    }
}