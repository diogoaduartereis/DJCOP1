using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    // Start is called before the first frame update
    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();

        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
       
        quitMenu.enabled = false;

    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel(1); // To be continued
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
