using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToPlayground()
    {
        //PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.DeleteKey("CoinCount");
        SceneManager.LoadScene("playground");
    }
    public void ContinuePlay()
    {
            if(PlayerPrefs.HasKey("PrevScene"))
              {
                 string prevSceneName = PlayerPrefs.GetString("PrevScene");
                 SceneManager.LoadScene(prevSceneName);
              }
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
