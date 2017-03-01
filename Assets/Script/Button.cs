using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public int boxValue = 0;
    public int myID;
    public tutorialScript ts;
    public gameManager gm;
    public GameObject isActive;
    bool canClick;
    public Scene CurrentScene;
    // Use this for initialization
    void Start () {

        CurrentScene = SceneManager.GetActiveScene();
        Debug.Log(CurrentScene.name);

        if (!CurrentScene.name.Contains("tutorial"))
            canClick = true;
        else
            canClick = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (canClick)
        {
            if (gm.buttonValue[myID - 1] == 0)
            {
                gm.buttonValue[myID - 1] = 1;
                isActive.SetActive(true);
            }
            else
            {
                gm.buttonValue[myID - 1] = 0;
                isActive.SetActive(false);
            }
        }
    }

    void OnMouseOver() {
        if (isActive.activeSelf)
        {
            Debug.Log("HEJ");
        }
    }
}
