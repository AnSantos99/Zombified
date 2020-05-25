using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    // Get animator for main menu
    public Animator mainMenu;

    // Get animator for Level Selection Menu
    public Animator lvlSelectMenu;

    // Get animator for Settings Menu
    public Animator settingsMenu;

    // Get animator for credits Menu
    public Animator CreditsMenu;

    // Get animator for Camera Movement
    public Animator cameraMov;

    public AudioSource hoverSound;

    public AudioSource clickSound;

    public Nodes CharacterSel;

    public Nodes Settings;

     public Nodes Main;

     public GameObject StartupPanel;

     public LoadingScreen Load;

    void Start()
    {
        StartCoroutine(DisableLogos());
    }

    public IEnumerator DisableLogos()
     {
         yield return new WaitForSeconds(7);
         StartupPanel.SetActive(false);
     }

    public void PlayHoverSound()
    {
        hoverSound.Play();
    }

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    /// <summary>
    /// This method allows us to move the camera towards
    /// the level selection menu and activate the menu
    /// showing animation
    /// </summary>
    public void ShowLevelSelection()
    {
        lvlSelectMenu.SetBool("SceneSlideOut", false);
        lvlSelectMenu.SetBool("SceneSlideIn", true);

        // Hide main menu
        mainMenu.SetBool("HideMain", true);
        mainMenu.SetBool("ShowMain", false);

        // Show Selection Menu

        CharacterSel.ClickIt();
    }

    /// <summary>
    /// This method allows us to move the camera towards
    /// the settings menu and activate the menu
    /// showing animation
    /// </summary>
    public void ShowSettingsMenu()
    {
        // Hide main menu
        mainMenu.SetBool("HideMain", true);
        mainMenu.SetBool("ShowMain", false);

        // Show Settings Menu
        settingsMenu.SetBool("ShowSettings", true);
        settingsMenu.SetBool("HideSettings", false);

        Settings.ClickIt();
    }

    /// <summary>
    /// This method allows us to move the camera towards
    /// the main menu and activate the menu
    /// showing animation
    /// </summary>
    public void ShowMainMenu()
    {

        cameraMov.SetTrigger("MainMenu");
        cameraMov.ResetTrigger("Level Select");
        cameraMov.ResetTrigger("Settings");

        mainMenu.SetBool("HideMain", false);
        mainMenu.SetBool("ShowMain", true);

        lvlSelectMenu.SetBool("SceneSlideOut", true);
        lvlSelectMenu.SetBool("SceneSlideIn", false);

        settingsMenu.SetBool("ShowSettings", false);
        settingsMenu.SetBool("HideSettings", true);

        Main.ClickIt();
        
    }

    public void LoadScene(string name)
    {
        StartCoroutine(WaitAndLoad());
    }

    public IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2);
        Load.LoadScreen();
    }

    /// <summary>
    /// This method allows us to quit the application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
