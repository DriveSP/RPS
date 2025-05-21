using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CpuController : CardDealer
{
    [SerializeField] private PlayerController playerController;
    public Card cardPlayed;
    public bool isPlayed { get; set; }

    void Update()
    {
        if (playerController.HasCardsObtained)
        {
            ObtainCards(false);

            if (playerController.cardPlayed)
            {
                CpuPlay();
            }
        }
    }

    private void CpuPlay()
    {
        // Lógica de jugada CPU
    }
}