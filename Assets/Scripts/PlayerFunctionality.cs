using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFunctionality : MonoBehaviour
{
    public string keyTag;
    public string doorTag;
    public bool gotKey;

    public string nextSceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        SoundManager soundManager = gameManager.GetComponent<SoundManager>();

        if (other.gameObject.CompareTag(keyTag))
        {
            Destroy(other.gameObject);
            gotKey = true;
            soundManager.PlayKeySound();
        }
        else if (other.gameObject.CompareTag(doorTag))
        {
            if (gotKey) {
                gameManager.GetComponent<ScoreManager>().AddScore();
                soundManager.PlayWinSound();
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                soundManager.PlayWrongKeySound();
            }
        }
    }
}
