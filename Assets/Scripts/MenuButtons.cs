using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] CpuController cpuController;
    [SerializeField] private GameObject panelWin;

    //Reset main values from CPU and Player for move on to the next round
    public void ResetMatch()
    {
        playerController.isPlayed = false;
        playerController.cardPlayed = null;
        cpuController.isPlayed = false;
        cpuController.cardPlayed = null;
        cpuController.randomCard = null;

        playerController.ResetCardsObtained();
        cpuController.ResetCardsObtained();

        foreach (GameObject card in cpuController.cardOnTableCpu)
        {
            Destroy(card);
        }
        cpuController.cardOnTableCpu.Clear();

        foreach (GameObject card in playerController.cardOnTablePlayer)
        {
            Destroy(card);
        }
        playerController.cardOnTablePlayer.Clear();
        GameManager.Instance.ResetMatchChecked();
        panelWin.SetActive(false);

    }
}
