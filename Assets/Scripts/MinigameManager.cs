using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public List<GameObject> targetObjs;

    public int numSecondsToDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(nameof(DisplayAndRemoveInfo), targetObjs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DisplayAndRemoveInfo(List<GameObject> objs)
    {
        foreach (GameObject obj in objs)
            obj.SetActive(true);

        yield return new WaitForSeconds(numSecondsToDisplay);

        foreach (GameObject obj in objs)
            obj.SetActive(false);
    }
}
