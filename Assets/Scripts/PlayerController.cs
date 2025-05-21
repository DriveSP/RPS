using UnityEngine;

public class PlayerController : CardDealer
{

    public Card cardPlayed;
    public bool HasCardsObtained => this.cardsObtained;
    public bool isPlayed { get; set; }

    void Update()
    {
        // Lógica específica si se requiere
    }

    public void ObtainPlayerCards()
    {
        ObtainCards(true);
    }

}
