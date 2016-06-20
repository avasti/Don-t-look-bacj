using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager_Intro : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textlines;

    public int currentLine;
    public int endAtLine;
    public float time = 6;

    public PlayerMovement player;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        if (textFile != null)
        {
            textlines = (textFile.text.Split('\n'));

        }

        if (endAtLine == 0)
        {
            endAtLine = textlines.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        time += Time.deltaTime;

        if(time >= 6)
        {
            if(!isTyping)
            {
                    currentLine += 1;
                    time = 0;

                    if (currentLine > endAtLine)
                    {
                        textBox.SetActive(false);
                    }
                    else
                    {
                        StartCoroutine(TextScroll(textlines[currentLine]));
                    }
                
            }else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }           
        }       

        if (time >= 6)
        {
            textBox.SetActive(false);
        }
    }

    private IEnumerator TextScroll (string lineOftext)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOftext.Length - 1))
        {
            theText.text += lineOftext[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);

        }
        theText.text = lineOftext;
        isTyping = false;
        cancelTyping = false;
    }
}
