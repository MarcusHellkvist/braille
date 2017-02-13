using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public int boxValue = 0;
    public int myID;
    public gameManager gm;
    public GameObject isActive;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if(gm.buttonValue[myID - 1] == 0){
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
