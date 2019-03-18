using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour 
{
    public Canvas quitMenu;
    public Canvas instructionsMenu;
    public Button startText; // play button component
    public Button exitText;
    public Button instructions;

    // Start is called before the first frame update
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        instructionsMenu = instructionsMenu.GetComponent<Canvas>();

        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        instructions = instructions.GetComponent<Button>();

        quitMenu.enabled = false;
        instructionsMenu.enabled = false;
    }

    public void InstructionsPress()
    {
        quitMenu.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        instructionsMenu.enabled = true;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        instructionsMenu.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        instructionsMenu.enabled = false;
    }

    public void StartLevel()
    {
       Application.LoadLevel(1); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
