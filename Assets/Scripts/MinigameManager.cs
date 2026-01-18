using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public TextMeshProUGUI controlInfoText;
    public TextMeshProUGUI timerText;

    public int numSecondsToDisplayStartInfo;

    public int timeLimit;

    public int numSecondsForCurtainsToStartMoving;

    public GameObject topCurtain;
    public GameObject bottomCurtain;

    public float curtainSpeed;

    private bool curtainsMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curtainsMoving = false;
        StartCoroutine(nameof(HideAndShowInfo));
    }

    // Update is called once per frame
    void Update()
    {
        if (curtainsMoving)
        {
            topCurtain.transform.position += new Vector3(0, -curtainSpeed * Time.deltaTime, 0);
            bottomCurtain.transform.position += new Vector3(0, curtainSpeed * Time.deltaTime, 0);
            Debug.Log("moving");
        }
    }

    void LoseGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator HideAndShowInfo()
    {
        yield return new WaitForSeconds(numSecondsToDisplayStartInfo);

        controlInfoText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);

        timerText.text = timeLimit.ToString();
        StartCoroutine(nameof(UpdateTimer));
    }

    private IEnumerator UpdateTimer()
    {
        for (int i = timeLimit; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            timerText.text = i.ToString();

            if (i <= numSecondsForCurtainsToStartMoving)
                curtainsMoving = true;
        }

        LoseGame();
        
    }
}
