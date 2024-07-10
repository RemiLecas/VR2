using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
     public Canvas canvasToShow;
     
    public void AfficheMenu(){

        canvasToShow.gameObject.SetActive(true);
    }
}
