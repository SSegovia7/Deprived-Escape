using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    
}
