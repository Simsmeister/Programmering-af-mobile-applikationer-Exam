using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInstantiator : MonoBehaviour
{
    public GameObject panel; //Panel to be instantiated upon
    public GameObject[] button; //Array of buttons
    public float spawnWait; //Time between spawns
    public float spawnMostWait; //Upper time between spawns
    public float spawnLeastWait; //Lower timer between spawns
    public int startWait; //Time before first spawn
    public bool stop; // Bool needed for while loop
    int randomButton; // random integer for button array
    
    /* The following method was removed due to not being needed
    void Start()
    {
        //StartCoroutine(WaitSpawner());
    } */
    
    public  void CloseAndStart() //Method used to start and stop Coruoutine. YesButton accesses it
    {
        if (!stop)
        {
        //StopCoroutine(WaitSpawner()); Didn't work, so instead made an if-statement containing a bool
        StartCoroutine(WaitSpawner());
        stop=true;
        }
    }

    /* The following method was used to generate a random integer between two variables, but was moved into (waitSpawner method)
    void Update() 
    {
        
    }

   The following method was moved to Lerp script instead
   void lerpPusher() 
    {
        
    } */

    IEnumerator WaitSpawner() //Method using IEnumerator class to specify the coroutine
    {
        yield return new WaitForSeconds(startWait);

        while (stop) //while loop
        {
            randomButton = Random.Range(0, 5);  
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

            GameObject newButton = Instantiate(button[randomButton]); //as GameObject; this part wasn't needed
            newButton.transform.SetParent(panel.transform, false);
            Component[] allExistingButtons = panel.GetComponentsInChildren<Lerp>();
            foreach (Lerp animate in allExistingButtons) //All existing buttons is every button holding a Lerp scrpt
            {
                if (animate.gameObject != newButton) //Check if a button is a new button, if it's not it lerps
                {
                    animate.StartLerp();
                }
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}

