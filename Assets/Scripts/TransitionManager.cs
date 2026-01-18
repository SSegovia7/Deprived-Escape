using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{

    public float cameraSpeed;
    public float transitionTime;
    public float zoomSpeed;

    public string nextSceneToLoadName;

    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(nameof(GoToNextScene));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        cam.orthographicSize -= zoomSpeed * Time.deltaTime;
    }

    private IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nextSceneToLoadName);
    }
}
