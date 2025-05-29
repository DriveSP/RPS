using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public abstract class CardDealer : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private List<Card> deck;
    [SerializeField] GameObject cardPrefab;
    private Transform deckTransform;
    private List<Card> hand = new List<Card>();
    private Animator animatorCard;
    protected bool cardsObtained = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deckTransform = this.transform;
    }

    public void ObtainCards(bool isPlayer)
    {
        if (cardsObtained) return;
        cardsObtained = true;

        List<Card> randomCards = GetRandomCards(deck, 3);
        int cardCount = 1;
        foreach (var card in randomCards)
        {
            Debug.Log(card.name);
            hand.Add(card);
            GameObject newCard = Instantiate(cardPrefab, deckTransform);
            newCard.transform.localPosition = Vector3.zero;
            FillDataCard(cardCount, card, newCard, isPlayer);


            Animator animatorCard = newCard.GetComponent<Animator>();

            if (animatorCard != null)
            {
                animatorCard.Play((isPlayer ? "Card" : "CardCpu") + cardCount);
            }
            else
            {
                Debug.LogWarning("Animator isn't exist");
            }
            cardCount++;
        }
    }

    private void FillDataCard(int id, Card card, GameObject cardPrefab, bool isPlayer)
    {
        CardController cardController = cardPrefab.GetComponent<CardController>();
        TextMeshProUGUI titleCard = cardPrefab.GetComponentInChildren<TextMeshProUGUI>();
        Image spriteCard = cardPrefab.GetComponent<Image>();
        cardController.isPlayerControlled = isPlayer;
        cardController.id = id;
        spriteCard.sprite = card.sprite;
        titleCard.text = card.name;
        cardController.cardName = card.name;
        cardController.description = card.description;
        cardController.weaks = card.weaks;
        cardController.strongs = card.strongs;
    }

    private List<Card> GetRandomCards(List<Card> source, int count)
    {
        return source.OrderBy(x => UnityEngine.Random.value).Take(count).ToList();
    }
}
