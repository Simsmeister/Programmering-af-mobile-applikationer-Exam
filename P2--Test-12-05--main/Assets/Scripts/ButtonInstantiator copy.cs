using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInstantiatorCopy : MonoBehaviour
{
    public GameObject panel; 
    public GameObject[] button; 
    public float spawnWait; 
    public float spawnMostWait; 
    public float spawnLeastWait; 
    public int startWait; 
    public bool stop; 
    int randomButton; 
    
    public  void CloseAndStart() 
    {
        if (!stop)
        {
        StartCoroutine(WaitSpawner());
        stop=true;
        }
    }

    IEnumerator WaitSpawner() 
    {
        yield return new WaitForSeconds(startWait);

        while (stop) 
        {
            randomButton = Random.Range(0, 5);  
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
            GameObject newButton = Instantiate(button[randomButton]); 
            newButton.transform.SetParent(panel.transform, false);
            Component[] allExistingButtons = panel.GetComponentsInChildren<Lerp>();
            foreach (Lerp lerp in allExistingButtons) 
            {
                if (lerp.gameObject != newButton)
                {
                    lerp.StartLerp();
                }
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}

