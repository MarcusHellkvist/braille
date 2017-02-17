using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public void startGame()
    {
        SceneManager.LoadScene("pickLevel");        
    }

    public void levelOne()
    {
        SceneManager.LoadScene(2);
    }
    public void levelTwo()
    {
        SceneManager.LoadScene(3);

    }

}
