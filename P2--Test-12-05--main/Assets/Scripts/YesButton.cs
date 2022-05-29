using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       

public class YesButton : MonoBehaviour
{

    public GameObject guideMenu;      
    public GameObject guideMenuTwo;
    public GameObject guideMenuThree;
    public GameObject guideMenuFour;

    public ButtonInstantiator myButtonInstantiator;
    
    public void Closer()
    {
        GetComponent<ButtonInstantiator>();
        myButtonInstantiator.CloseAndStart();
        guideMenu.SetActive(false);
        guideMenuTwo.SetActive(false);
        guideMenuThree.SetActive(false);
        guideMenuFour.SetActive(false);
    }
    
    /*void Start()
    {
        GetComponent<ButtonInstantiator>(); We don't need to call this at the start, therefore moved into Closer method
    }*/

 

    public void CloserFirstButtons()
    {
        guideMenu.SetActive(false);
        guideMenuTwo.SetActive(false);
        guideMenuThree.SetActive(false);
    }

   
}