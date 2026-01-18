using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreManager scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        gameObject.GetComponent<TextMeshProUGUI>().text = scoreManager.GetScore().ToString();
        scoreManager.ResetScore();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
