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

        if (other.gameObject.CompareTag(keyTag))
        {
            Destroy(other.gameObject);
            gotKey = true;
        }
        else if (other.gameObject.CompareTag(doorTag))
        {
            if (gotKey) {
                SceneManager.LoadScene(nextSceneName);
                GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>().AddScore();
            }
        }
    }
}
