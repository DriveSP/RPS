using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public abstract class CardDealer : MonoBehaviour
{
    [SerializeField] protected float hp, maxHp;
    [SerializeField] protected HealthBarUI healthBar;
    [SerializeField] private List<Card> deck;
    [SerializeField] GameObject cardPrefab;
    private CpuController _cpuController;
    private PlayerController _playerController;
    private Transform deckTransform;
    private List<Card> hand = new List<Card>();
    private Animator animatorCard;
    protected bool cardsObtained = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deckTransform = this.transform;
        _cpuController = GameObject.FindGameObjectWithTag("CPU").GetComponent<CpuController>();
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        healthBar.SetMaxHealth(maxHp);
    }

    public void ObtainCards(bool isPlayer)
    {
        if (cardsObtained) return;
        cardsObtained = true;

        List<Card> randomCards = GetRandomCards(deck, 3);
        int cardCount = 1;

        //Instantiate a card and fill it with data, then animate it to the center of the table
        foreach (var card in randomCards) 
        {
            Debug.Log(card.name);
            hand.Add(card); //Add a new card to the hand
            GameObject newCard = Instantiate(cardPrefab, deckTransform);
            newCard.transform.localPosition = Vector3.zero; //Card instantiated to deck position
            FillDataCard(cardCount, card, newCard, isPlayer);

            if (!isPlayer)
            {
                _cpuController.cardOnTableCpu.Add(newCard);
            }
            else
            {
                _playerController.cardOnTablePlayer.Add(newCard);
            }

            Animator animatorCard = newCard.GetComponent<Animator>();

            if (animatorCard != null)
            {
                animatorCard.Play((isPlayer ? "Card" : "CardCpu") + cardCount); //Move to the center of the table
            }
            else
            {
                Debug.LogWarning("Animator isn't exist");
            }
            cardCount++; //Card id
        }
    }

    //Get Datas from Card ScripteableObject and Fill CardController from CardPrefab
    private void FillDataCard(int id, Card card, GameObject cardPrefab, bool isPlayer)
    {
        CardController cardController = cardPrefab.GetComponent<CardController>();
        //TextMeshProUGUI titleCard = cardPrefab.GetComponentInChildren<TextMeshProUGUI>();
        Image spriteCard = cardPrefab.GetComponent<Image>();
        cardController.isPlayerControlled = isPlayer;
        cardController.id = id;
        cardController.sprite = card.sprite;
        cardController.back = card.back;
        spriteCard.sprite = isPlayer ? cardController.sprite : cardController.back; //If isn't player, then hide cpu's card
        //titleCard.text = card.name;
        cardController.cardName = card.name;
        cardController.description = card.description;
        cardController.weaks = card.weaks;
        cardController.strongs = card.strongs;
        cardController.isPlayerCard = isPlayer;
    }

    private List<Card> GetRandomCards(List<Card> source, int count)
    {
        return source.OrderBy(x => UnityEngine.Random.value).Take(count).ToList(); //Get list deck and give X card's number
    }

    public virtual void LostHealth(float newHealth)
    {
        hp += newHealth;
        hp = Mathf.Clamp(hp, 0, maxHp);

        healthBar.SetHealth(hp);
    }

    public void ResetCardsObtained()
    {
        cardsObtained = false;
    }
}
