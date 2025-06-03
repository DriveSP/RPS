using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CpuController : CardDealer
{
    [SerializeField] private PlayerController playerController;
    public List<GameObject> cardOnTableCpu;
    public GameObject randomCard;
    public GameObject cardPlayed;
    public bool isPlayed { get; set; }

    void Update()
    {
        if (playerController.HasCardsObtained)
        {
            ObtainCards(false);

            if (playerController.isPlayed)
            {
                if (isPlayed) return;
                CpuPlay();
            }
        }
    }

    private void CpuPlay()
    {
        randomCard = cardOnTableCpu[UnityEngine.Random.Range(0, cardOnTableCpu.Count)];
        CardController randomController = randomCard.GetComponent<CardController>();
        randomController.AnimationOnTable();
        Image spriteCard = randomCard.GetComponent<Image>();
        spriteCard.sprite = randomController.sprite;
        cardPlayed = randomCard;
        isPlayed = true;
    }

    public override void LostHealth()
    {
        base.LostHealth();
    }
}