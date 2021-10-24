using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaygroundSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text uiTextCoin;
    public Text uiTextBullet;
   
    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void SetTextCoin(int amount)
    {
        uiTextCoin.text = amount.ToString();
    }
    public void SetTextBullet(int amount)
    {
        uiTextBullet.text = amount.ToString();
    }
    
}
