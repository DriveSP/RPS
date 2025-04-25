using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField]private List<Card> deck;
    private List<Card> hand;
    private List<GameObject> cardPrefab;
    private Card cardPlayed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObtainCards()
    {
        List<Card> randomCards = GetRandomCards(deck, 3);
        foreach (var card in randomCards)
        {
            Debug.Log(card.name);
            hand.Add(card);
        }
    }

    private void FillDataCard(Card card)
    {

    }

    private List<Card> GetRandomCards(List<Card> source, int count)
    {
        return source.OrderBy(x => UnityEngine.Random.value).Take(count).ToList();
    }
}
