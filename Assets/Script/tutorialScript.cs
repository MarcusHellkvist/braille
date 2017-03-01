using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tutorialScript : MonoBehaviour {

    public int[] buttonValue;
    public string[] alphabet;
    public int[,] brailleCharacters;
    private Text activeBrailleText;
    public GameObject[] boxes;


    // Use this for initialization
    void Start () {
        //Player Array
        buttonValue = new int[6] { 0, 0, 0, 0, 0, 0 };
        //Array
        alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        //Database Array
        brailleCharacters = new int[26, 6] {
            { 1, 0, 0, 0, 0, 0 }, // Bokstaven A
            { 1, 1, 0, 0, 0, 0 }, // Bokstaven B
            { 1, 0, 0, 1, 0, 0 }, // Bokstaven C
            { 1, 0, 0, 1, 1, 0 }, // Bokstaven D
            { 1, 0, 0, 0, 1, 0 }, // Bokstaven E
            { 1, 1, 0, 1, 0, 0 }, // Bokstaven F
            { 1, 1, 0, 1, 1, 0 }, // Bokstaven G
            { 1, 1, 0, 0, 1, 0 }, // Bokstaven H
            { 0, 1, 0, 1, 0, 0 }, // Bokstaven I
            { 0, 1, 0, 1, 1, 0 }, // Bokstaven J
            { 1, 0, 1, 0, 0, 0 }, // Bokstaven K
            { 1, 1, 1, 0, 0, 0 }, // Bokstaven L
            { 1, 0, 1, 1, 0, 0 }, // Bokstaven M
            { 1, 0, 1, 1, 1, 0 }, // Bokstaven N
            { 1, 0, 1, 0, 1, 0 }, // Bokstaven O
            { 1, 1, 1, 1, 0, 0 }, // Bokstaven P
            { 1, 1, 1, 1, 1, 0 }, // Bokstaven Q
            { 1, 1, 1, 0, 1, 0 }, // Bokstaven R
            { 0, 1, 1, 1, 0, 0 }, // Bokstaven S
            { 0, 1, 1, 1, 1, 0 }, // Bokstaven T
            { 1, 0, 1, 0, 0, 1 }, // Bokstaven U
            { 1, 1, 1, 0, 0, 1 }, // Bokstaven V
            { 0, 1, 0, 1, 1, 1 }, // Bokstaven W
            { 1, 0, 1, 1, 0, 1 }, // Bokstaven X
            { 1, 0, 1, 1, 1, 1 }, // Bokstaven Y
            { 1, 0, 1, 0, 1, 1 } // Bokstaven Z
        };

        activeBrailleText = GameObject.Find("activeBrailleCharacter").GetComponent<Text>();
        activeBrailleText.text = "A";

        ShowLetter();

        
    }

    // Update is called once per frame
    void Update () {
	
	}

    void ShowLetter()
    {
        boxes[0].SetActive(true);
    }
}
