using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board : IBoard
{
    private Dictionary<string, Card> deckByName;
    private List<Card> deck;


    public Board()
    {
        this.deckByName = new Dictionary<string, Card>();
        this.deck = new List<Card>();
        
    }
    public bool Contains(string name)
    {
        return deckByName.ContainsKey(name);
    }

    public int Count()
    {
        return this.deckByName.Count;
    }

    public void Draw(Card card)
    {
        if (!deckByName.ContainsValue(card))
        {
            deckByName.Add(card.Name, card);
            deck.Add(card);
            
        }
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        throw new NotImplementedException();
    }

    public void Heal(int health)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        throw new NotImplementedException();
    }

    public void Play(string attackerCardName, string attackedCardName)
    {

        Card attacker = deckByName[attackedCardName];
        Card attacked = deckByName[attackedCardName];
        if (attacker != null && attackedCardName != null)
        {
            if (attacker.Level == attacked.Level)
            {
                if (attacked.Health > 0)
                {
                    attacked.Health -= attacker.Damage;
                    if (attacked.Health <= 0)
                    {
                        attacker.Score += attacked.Level;
                    }
                }
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

    public void Remove(string name)
    {
       
        if (deckByName.ContainsKey(name))
        {
            deckByName.Remove(name);
            deck.Remove(deckByName[name]);
           
        }
        else
        {
          throw new  ArgumentException();
        }

    }

    public void RemoveDeath()
    {
        
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        List<Card> searchedCards = new List<Card>();
        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i].Level==level)
            {
                searchedCards.Add(deck[i]);
            }
        }

        return searchedCards.OrderByDescending(x => x.Score);

      
    }
}