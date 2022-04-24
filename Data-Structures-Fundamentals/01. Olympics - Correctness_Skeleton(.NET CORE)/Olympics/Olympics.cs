using System;
using System.Collections.Generic;
public class Olympics : IOlympics
{


    private Dictionary<int, Competitor> competitors;
    private Dictionary<int, Competition> competitions;

    public Olympics()
    {

        competitors = new Dictionary<int, Competitor>();
        competitions = new Dictionary<int, Competition>();
    }
    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (!competitions.ContainsKey(id))
        {
            competitions.Add(id, new Competition(name, id, 0, participantsLimit));
        }
        else
        {
            throw new ArgumentException();
        }

    }

    public void AddCompetitor(int id, string name)
    {
        if (!competitors.ContainsKey(id))
        {
            competitors.Add(id, new Competitor(id, name));
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public void Compete(int competitorId, int competitionId)
    {

        if (competitions.ContainsKey(competitionId) && competitors.ContainsKey(competitorId))
        {
            Competitor competitorToAdd = competitors[competitorId];

            competitions[competitionId].Competitors.Add(competitorToAdd);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public int CompetitionsCount()
    {
        return competitions.Count;
    }

    public int CompetitorsCount()
    {
        return competitors.Count;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        return competitions[competitionId].Competitors.Contains(comp);
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (competitions.ContainsKey(competitionId) && competitors.ContainsKey(competitorId))
        {
            Competition currentCompetition = competitions[competitionId];
            Competitor currentCompetitor = competitors[competitorId];

            if (currentCompetition.Competitors.Contains(currentCompetitor))
            {
                currentCompetition.Competitors.Remove(currentCompetitor);
                currentCompetitor.TotalScore -= currentCompetition.Score;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        else
        {
            throw new ArgumentException();
        }


    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Competition GetCompetition(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        throw new NotImplementedException();
    }
}