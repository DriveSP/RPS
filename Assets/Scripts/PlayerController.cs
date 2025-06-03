using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CardDealer
{

    public GameObject cardPlayed;
    public bool HasCardsObtained => this.cardsObtained;
    public List<GameObject> cardOnTablePlayer;
    public bool isPlayed;

    public void ObtainPlayerCards()
    {
        ObtainCards(true);
    }

    public override void LostHealth(float newHealth)
    {
        base.LostHealth(newHealth);
    }
}
