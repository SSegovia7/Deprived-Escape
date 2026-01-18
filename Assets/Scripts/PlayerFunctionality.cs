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

        Debug.Log("trigger");
        if (other.gameObject.CompareTag(keyTag))
        {
            Destroy(other.gameObject);
            gotKey = true;
            Debug.Log("got key");
        }
        else if (other.gameObject.CompareTag(doorTag) && gotKey)
        {
            SceneManager.LoadScene(nextSceneName);
            Debug.Log("got door");
        }
    }
}
