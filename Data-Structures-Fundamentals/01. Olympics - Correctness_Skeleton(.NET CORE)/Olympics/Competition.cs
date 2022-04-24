using System.Collections.Generic;

public class Competition
{
    private ICollection<Competitor> competitorsCollection;

    public Competition(string name, int id, int score)
    {
        this.Name = name;
        this.Id = id;
        this.Score = score;
        this.competitorsCollection = new List<Competitor>();

    }
    public Competition(string name, int id, int score, int participantsLimit)
    {
        this.Name = name;
        this.Id = id;
        this.Score = score;
        this.competitorsCollection = new Competitor[participantsLimit];
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Score { get; set; }

    public ICollection<Competitor> Competitors => competitorsCollection;
}
