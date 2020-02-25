using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{

    public Text goldCountText;
    public Text silverCountText;
    public Text bronzeCountText;

    public void InitializeScores()
    {
        ScoreManager scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        goldCountText.text = scoreManager.GoldCount.ToString();
        silverCountText.text = scoreManager.SilverCount.ToString();
        bronzeCountText.text = scoreManager.BronzeCount.ToString();
    }
}
