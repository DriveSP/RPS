using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private CpuController cpuController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject panelWin;
    private bool matchChecked = false;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        cpuController = GameObject.FindGameObjectWithTag("CPU").GetComponent<CpuController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.isPlayed || !cpuController.isPlayed || matchChecked) return;
        CheckMatch();
        matchChecked = true;
    }

    private void CheckMatch()
    {
        GameObject cardPlayer = playerController.cardPlayed;
        GameObject cardCpu = cpuController.cardPlayed;
        CardController playerCardController = cardPlayer.GetComponent<CardController>();
        CardController cpuCardController = cardCpu.GetComponent<CardController>();

        bool playerWin = playerCardController.strongs.Any(strong => strong.cardName == cpuCardController.cardName);

        if (playerWin)
        {
            TMP_Text textWinUI = panelWin.transform.Find("TextWin").GetComponent<TMP_Text>();
            textWinUI.text = "Player win!";
            cpuController.LostHealth(-1);
            panelWin.SetActive(true);
            Debug.Log("Player win!");
        }
        else
        {
            
            TMP_Text textWinUI = panelWin.transform.Find("TextWin").GetComponent<TMP_Text>();
            textWinUI.text = "CPU win or draw!";
            playerController.LostHealth(-1);
            panelWin.SetActive(true);
            Debug.Log("CPU win or draw!");
        }
    }

    public void ResetMatchChecked()
    {
        matchChecked = false;
    }
}
