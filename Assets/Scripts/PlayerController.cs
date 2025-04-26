using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField]private List<Card> deck;
    [SerializeField] GameObject cardPrefab;
    private Transform deckTransform;
    private List<Card> hand = new List<Card>();
    private List<GameObject> cardPrefabList;
    private Animator animatorCard;
    private Card cardPlayed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deckTransform = this.transform;
    }

    public void ObtainCards()
    {
        List<Card> randomCards = GetRandomCards(deck, 3);
        int cardCount = 1;
        foreach (var card in randomCards)
        {
            Debug.Log(card.name);
            hand.Add(card);
            GameObject newCard = Instantiate(cardPrefab, deckTransform);
            newCard.transform.localPosition = Vector3.zero;
            FillDataCard(card, newCard);


            Animator animatorCard = newCard.GetComponent<Animator>();

            if (animatorCard != null)
            {
                animatorCard.Play("Card"+cardCount);
            }
            else
            {
                Debug.LogWarning("Animator isn't exist");
            }
            cardCount++;
        }
    }

    private void FillDataCard(Card card, GameObject cardPrefab)
    {
        CardController cardController = cardPrefab.GetComponent<CardController>();
        TextMeshProUGUI titleCard = cardPrefab.GetComponentInChildren<TextMeshProUGUI>();
        titleCard.text = card.name;
        cardController.CardName = card.name;
        cardController.Description = card.description;
        cardController.Weaks = card.weaks;
        cardController.Strongs = card.strongs;
    }

    private List<Card> GetRandomCards(List<Card> source, int count)
    {
        return source.OrderBy(x => UnityEngine.Random.value).Take(count).ToList();
    }
}
