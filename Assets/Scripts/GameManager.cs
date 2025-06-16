using System.Collections;
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
    public AudioClip[] clips;
    public AudioSource[] sources;
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

        //Compare two list. Strong list from card played by player and Weaks list from card played by CPU. If the cards match, boolean is true.
        bool playerWin = playerCardController.strongs.Any(strong => strong.cardName == cpuCardController.cardName); 

        if (playerWin)
        {
            //CPU lost health
            TMP_Text textWinUI = panelWin.transform.Find("TextWin").GetComponent<TMP_Text>();
            textWinUI.text = "Player win!";
            cpuController.LostHealth(-1);
            panelWin.SetActive(true);
            Debug.Log("Player win!");
            PlaySound("loseHp");
        }
        else
        {
            //Player lost health
            TMP_Text textWinUI = panelWin.transform.Find("TextWin").GetComponent<TMP_Text>();
            textWinUI.text = "CPU win or draw!";
            playerController.LostHealth(-1);
            panelWin.SetActive(true);
            Debug.Log("CPU win or draw!");
            PlaySound("loseHp");
        }

        
    }

    public void PlaySound(string call)
    {
        switch (call)
        {
            case "deal":
                for (int i = 0; i < 3; i++)
                {
                    sources[i].clip = clips[1];
                }
                StartCoroutine(PlayWithDelay(0.1f,3));
                break;
            case "put":
                sources[0].PlayOneShot(clips[2]);
                break;
            case "loseHp":
                sources[1].PlayOneShot(clips[0]);
                break;
        }
    }

    private IEnumerator PlayWithDelay(float delay, int lenght)
    {
        for (int i = 0; i < lenght; i++)
        {
            sources[i].Play();
            yield return new WaitForSeconds(delay);
            sources[i].clip = null;
        }
    }

    public void ResetMatchChecked()
    {
        matchChecked = false;
    }
}
