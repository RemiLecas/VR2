using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToScene(string NameScene){
        SceneManager.LoadSceneAsync(NameScene);
   } 
   public void QuitGame(){
      Debug.Log("quit game");
     Application.Quit();
   }
}
