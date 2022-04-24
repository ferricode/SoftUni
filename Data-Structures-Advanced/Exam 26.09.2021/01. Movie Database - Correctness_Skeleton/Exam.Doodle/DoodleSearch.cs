using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Doodle
{
    public class DoodleSearch : IDoodleSearch
    {
        private List<Doodle> doodles;
        private Dictionary<string, Doodle> doodlesById;

        public DoodleSearch()
        {
            this.doodles = new List<Doodle>();
            doodlesById = new Dictionary<string, Doodle>();
        }
        public int Count => doodles.Count;

        public void AddDoodle(Doodle doodle)
        {
            doodles.Add(doodle);
            doodlesById[doodle.Id] = doodle;
        }

        public bool Contains(Doodle doodle)
        {
            return doodlesById.ContainsKey(doodle.Id);
        }

        public Doodle GetDoodle(string id)
        {
            if (!doodlesById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            return doodlesById[id];
        }

        public IEnumerable<Doodle> GetDoodleAds()
        {
            return doodles.Where(d => d.IsAd == true).OrderByDescending(d => d.Revenue).ThenByDescending(d => d.Visits);
        }

        public IEnumerable<Doodle> GetTop3DoodlesByRevenueThenByVisits()
        {
            return doodlesById.Values.Where(d => d.IsAd == true).OrderByDescending(d => d.Revenue).ThenByDescending(d => d.Visits).Take(3);
        }

        public double GetTotalRevenueFromDoodleAds()
        {
            double result= 0;
            foreach (var add in doodlesById.Values.Where(d => d.IsAd == true))
            {
                result += add.Revenue * add.Visits;
            }
            return result;
        }

        public void RemoveDoodle(string doodleId)
        {
            var doodleToremove = doodlesById[doodleId];
            if (doodleToremove==null)
            {
                throw new ArgumentException();
            }
            doodles.Remove(doodleToremove);
            doodlesById.Remove(doodleId);
        }

        public IEnumerable<Doodle> SearchDoodles(string searchQuery)
        {
            return this.doodles
                    .Where(d => d.Title.Contains(searchQuery))
                    .OrderBy(d => !d.IsAd)
                    .ThenBy(d => d.Title.StartsWith(searchQuery)
                                        ? (d.Title == searchQuery ? 0 : 1)
                                        : 2)
                    .ThenByDescending(d => d.Visits);
            //return  doodles.title.Substring(0, searchQuery)
        }

        public void VisitDoodle(string title)
        {
            var doodleToVisit = doodlesById.Values.FirstOrDefault(d => d.Title == title);
            if (doodleToVisit==null)
            {
                throw new ArgumentException();
            }
            doodles.FirstOrDefault(d => d.Title == title).Visits++;
            doodlesById[doodleToVisit.Id].Visits++;



        }
    }
}
