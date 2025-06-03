using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool isPlayerControlled { get; set; }
    public Sprite sprite;
    public Sprite back;
    public int id { get; set; }
    public bool cardFlipped { get; set; }
    public string cardName { get; set; }
    public string description { get; set; }
    public List<Card> strongs { get; set; }
    public List<Card> weaks { get; set; }

    public bool isPlayerCard { get; set; }
    private Vector3 initialScale;
    private PlayerController playerController;
    private Animator animator;

    private void Awake()
    {
        initialScale = transform.localScale;
        animator = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
    }

    //Zoom in
    private void IncreaseScale(bool status)
    {
        if (!isPlayerControlled) return;

        Vector3 finalScale = initialScale;

        if (status) finalScale = initialScale * 1.1f;

        transform.localScale = finalScale;
    }

    //Zoom in mouse hover
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!isPlayerControlled) return;

        Debug.Log("Enter mouse");
        IncreaseScale(true);
    }

    //Zoom out mouse hover
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (!isPlayerControlled) return;

        Debug.Log("Enter exit");
        IncreaseScale(false);
    }

    //When player click on this card, it move to the center table
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isPlayerControlled) return;

        if (playerController.isPlayed) return;
        playerController.isPlayed = true;
        playerController.cardPlayed = this.gameObject; //Set card played by player
        AnimationOnTable();
    }

    public void AnimationOnTable()
    {
        animator.Play((isPlayerCard ? "CardPlayed" : "CardCpuPlayed") + id); //If is player, execute player animations. Else execute cpu animation
    }
}
