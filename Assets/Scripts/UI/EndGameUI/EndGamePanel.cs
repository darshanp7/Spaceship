using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGamePanel : MonoBehaviour
{

    public Button continueButton;

    private void OnEnable()
    {
        SpaceshipEventsBroker.Die += Show;
        GameControllerEventsBroker.LevelEnded += Show;
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.Die -= Show;
        GameControllerEventsBroker.LevelEnded -= Show;
    }

    private void Show()
    {
        if (PlayerPrefs.GetInt("LevelProgress") >= PlayerPrefs.GetInt("TotalLevels"))
            continueButton.gameObject.SetActive(false);
        GetComponent<EndScore>().InitializeScores();
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnReplay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnContinue()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
