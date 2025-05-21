using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool isPlayerControlled { get; set; }
    public int id { get; set; }
    public bool cardFlipped { get; set; }
    public string cardName { get; set; }
    public string description { get; set; }
    public List<Card> strongs { get; set; }
    public List<Card> weaks { get; set; }

    private Vector3 initialScale;
    private PlayerController playerController;
    private Animator animator;

    private void Awake()
    {
        initialScale = transform.localScale;
        animator = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
    }

    private void IncreaseScale(bool status)
    {
        if (!isPlayerControlled) return;

        Vector3 finalScale = initialScale;

        if (status) finalScale = initialScale * 1.1f;

        transform.localScale = finalScale;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!isPlayerControlled) return;

        Debug.Log("Enter mouse");
        IncreaseScale(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (!isPlayerControlled) return;

        Debug.Log("Enter exit");
        IncreaseScale(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isPlayerControlled) return;

        if (playerController.isPlayed) return;
        playerController.isPlayed = true;

        animator.Play("CardPlayed"+id);
    }
}
