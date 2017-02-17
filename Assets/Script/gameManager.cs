using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour {

    public GameObject[] players;
    public int[] buttonValue;
    public string[] alphabet;
    public int[,] brailleCharacters;
    int randomNumber;

    double myScore = 0;
    int comboCounter = 0;
    int showCombo = 1;
    double currentHealth = 3, maxHealth = 3;
    int previousNumber = 0, prevCounter = 0;

    Scene levelName;
    int i = 0, limit = 0;

    private Text activeBrailleText;
    private Text scoreText;
    private Text comboText;
    private Text healthText;

    public AudioMixer masterMixer;
    private float maxVol = 0f;
    private float minVol = -80f;
    private bool playMessySound = false;

    float volTimer = 1.0f;

    bool same = false; // Used to check if the arrays are the same

    public string CurrentBlah = "tutorial";
    // Use this for initialization
    void Start () {

        activeBrailleText = GameObject.Find("activeBrailleCharacter").GetComponent<Text>();
        activeBrailleText.text = "A";

        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        scoreText.text = "Score: " + myScore;

        comboText = GameObject.Find("comboText").GetComponent<Text>();
        comboText.text = "Multiplier: " + showCombo + "x";

        healthText = GameObject.Find("healthText").GetComponent<Text>();
        healthText.text = "Health: " + currentHealth;

        masterMixer.SetFloat("correctVersionVol", maxVol);
        masterMixer.SetFloat("falseVersionVol", minVol);


        //Player Array
        buttonValue = new int[6] { 0, 0, 0, 0, 0, 0 };

        //Array
        alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        //Database Array
        brailleCharacters = new int[26,6] {
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

        SetLevelNumbers();

        randomNumber = Random.Range(i, limit);
        previousNumber = randomNumber;
        activeBrailleText.text = alphabet[randomNumber];

    }
    
    void SetLevelNumbers()
    {
        levelName = SceneManager.GetActiveScene();
        
        if (levelName.name == "levelOne" || levelName.name == "tutorial")
        {
            i = 0;
            limit = 4;
        }
        else if (levelName.name == "levelTwo" ||levelName.name == "tutorialTwo")
        {
            i = 4;
            limit = 9;
        }
    }

    // Update is called once per frame
    void Update () {

        //Debug.Log("Number: " + randomNumber);
        if (playMessySound)
            setFalseVol();
        else
            setCorrectVol();

        //Debug.Log(i + "|" + limit);
    }

    void Awake()
    {
    }

    void Check()
    {
        if (same) // If they are the same, do this!
        {
            SetLevelNumbers();
            playMessySound = false;
            resetBoxValue();
            randomNumber = Random.Range(i, limit);
            while (previousNumber == randomNumber)
            {
                randomNumber = Random.Range(i, limit);
                //prevCounter++;
                //if (prevCounter >= 10) break;
            }
            prevCounter = 0;
            previousNumber = randomNumber;
            activeBrailleText.text = alphabet[randomNumber];

            addScore();
            scoreText.text = "Score: " + myScore;

            comboCounter++;

            currentHealth += 0.5;
            if (currentHealth > maxHealth)
            {
                currentHealth = 3;
            }
        }
        else // Else do this
        {
            playMessySound = true;
            Debug.Log("DEM ÄR INTE LIKA!!");
            resetBoxValue();
            comboCounter = 0;
            showCombo = 1;
            currentHealth--;
        }
    }

    // TODO(MARCUS): Maybe break up into smaller functions
    public void CompareArray()
    {
        SetLevelNumbers();
        int rightRow = randomNumber;
        //for (; i < limit; i++) 
        //{
        for (int j = 0; j < 6; j++) // Compare arrays
        {
            if (brailleCharacters[rightRow, j] != buttonValue[j])
            {
                same = false;
                break;
            }
            same = true;
        }
        //}

        Check();

        if (currentHealth <= 0)
        {
            Debug.Log("YOU ARE DIED!");
        }

        comboText.text = "Multiplier: " + showCombo + "x";
        healthText.text = "Health: " + currentHealth;


    }

    public void removeAnswer()
    {
        resetBoxValue();
    }

    void resetBoxValue()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("activeBoxTag");
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
        buttonValue[0] = 0;
        buttonValue[1] = 0;
        buttonValue[2] = 0;
        buttonValue[3] = 0;
        buttonValue[4] = 0;
        buttonValue[5] = 0;
    }

    void addScore()
    {
        if (comboCounter <= 3)
        {
            myScore += 1.0;
            showCombo = 1;
        }
        else if (comboCounter > 3 && comboCounter <= 6)
        {
            myScore += 2.0;
            showCombo = 2;
        }

        else if (comboCounter > 6)
        {
            myScore += 3.0;
            showCombo = 3;
        }
    }

    void setCorrectVol()
    {
        
        masterMixer.SetFloat("correctVersionVol", maxVol);
        masterMixer.SetFloat("falseVersionVol", minVol);
    }

    void setFalseVol()
    {
        masterMixer.SetFloat("correctVersionVol", minVol);
        masterMixer.SetFloat("falseVersionVol", maxVol);

        volTimer -= Time.deltaTime;
        Mathf.Round(volTimer);
        Debug.Log("Time Left:" + Mathf.Round(volTimer));

        if (volTimer < 0)
        {
            setCorrectVol();
            playMessySound = false;
            volTimer = 1.0f;
        }

    }


}
