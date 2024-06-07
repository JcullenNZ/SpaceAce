using TMPro;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{

    HighScoreManager highScoreManager;
public GameObject entryContainer;
public GameObject entryTemplate;





void Start()
{
    highScoreManager = HighScoreManager.Instance;
    if (highScoreManager == null)
    {
        Debug.LogError("HighScoreManager is null");
    return;
    }
    
    HighScores highScores = highScoreManager.GetHighScores();
    if (highScores == null)
    {
        Debug.LogError("HighScores is null");
        return;
    }
    
    DisplayHighScores(highScores);
    }

public void DisplayHighScores(HighScores highScores)
{
    Debug.Log("Displaying high scores: " + highScores.scores.Count);
    for(int i = 0; i < highScores.scores.Count; i++)
    {
        GameObject scoreEntry = Instantiate(entryTemplate, entryContainer.transform);
        scoreEntry.SetActive(true);
        TextMeshProUGUI pos = scoreEntry.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI name = scoreEntry.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI score = scoreEntry.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        pos.text = (i + 1).ToString();
        name.text = highScores.scores[i].playerName;
        score.text = highScores.scores[i].score.ToString();
    }
}

}
