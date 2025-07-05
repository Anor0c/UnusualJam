using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static MainMenuManager;

public class MainMenuManager : MonoBehaviour
{
    public enum Menus { MainMenu, Credits, QuitMenu };
    public Menus currentMenu = Menus.MainMenu;

    [Space]
    [Header ("Animator controller")]
    [SerializeField] private Animator BackgroundPanelAC;
    [SerializeField] private Animator MenuHolderAC;

    [Space]
    [Header("Menus")]
    [SerializeField] private GameObject MainMenuGO;
    [SerializeField] private GameObject CreditMenuGO;
    [SerializeField] private GameObject QuitMenuGO;


    public void StartCoroutineMenuTransition(int targetMenuµIndex)
    {
        StopAllCoroutines();
        StartCoroutine(StartMenuTransition(targetMenuµIndex));
    }
    private IEnumerator StartMenuTransition(int targetMenuµIndex)
    {
        //Exécute les activation et déésactivation dans l'ordre
        ExitCurrentMenu();
        yield return new WaitForSeconds(3f);
        SwitchOffCurrentMenu();
        EnterNewMenu(targetMenuµIndex);
    }

    private void ExitCurrentMenu()
    {
        //Selectionne quel menu désactiver
        switch (currentMenu)
        {
            case Menus.MainMenu:
                ToggleMainMenu(false);
                break;
            case Menus.Credits:
                ToggleCreditsMenu(false);
                break;
            case Menus.QuitMenu:
                ToggleQuitMenu(false);
                break;
        }
    }
    private void SwitchOffCurrentMenu()
    {
        //Désactive le menu lorsqu'il est en dehors de l'écran
        switch (currentMenu)
        {
            case Menus.MainMenu:
                MainMenuGO.SetActive(false);
                break;
            case Menus.Credits:
                CreditMenuGO.SetActive(false);
                break;
            case Menus.QuitMenu:
                QuitMenuGO.SetActive(false);
                break;
        }
    }
    private void EnterNewMenu(int targetMenuµIndex)
    {
        //Selectionne le menu à ouvrir
        switch (targetMenuµIndex)
        {
            case 0:
                ToggleMainMenu(true);
                currentMenu = Menus.MainMenu;
                break;
            case 1:
                ToggleCreditsMenu(true);
                currentMenu = Menus.Credits;
                break;
            case 2:
                ToggleQuitMenu(true);
                currentMenu = Menus.QuitMenu;
                break;
        }
    }

    //Fonctions pour afficher et désafficher les menus
    private void ToggleMainMenu(bool enter)
    {
        if (enter)
        {
            //If the menu opens
            MainMenuGO.SetActive(true);
            BackgroundPanelAC.SetTrigger("Open");
            MenuHolderAC.SetTrigger("Open");
        }
        else
        {
            //If the menu closes
            BackgroundPanelAC.SetTrigger("Close");
            MenuHolderAC.SetTrigger("Close");
        }

    }
    private void ToggleCreditsMenu(bool enter)
    {
        if (enter)
        {
            //If the menu opens
            CreditMenuGO.SetActive(true);
            BackgroundPanelAC.SetTrigger("Open");
            MenuHolderAC.SetTrigger("Open");

        }
        else
        {
            //If the menu closes
            BackgroundPanelAC.SetTrigger("Close");
            MenuHolderAC.SetTrigger("Close");
        }
    }
    private void ToggleQuitMenu(bool enter)
    {
        if (enter)
        {
            //If the menu opens
            QuitMenuGO.SetActive(true);
            BackgroundPanelAC.SetTrigger("Open");
            MenuHolderAC.SetTrigger("Open");

        }
        else
        {
            //If the menu closes
            BackgroundPanelAC.SetTrigger("Close");
            MenuHolderAC.SetTrigger("Close");
        }
    }


    public void StartGame()
    {
        //Fonction pour lancer la scène principale
        Debug.Log("THE GAME STARTS !");
        //SceneManager.LoadScene, etc
    }
    public void QuitGame()
    {
        //Fonctione pour quitter le jeu
        Application.Quit();
    }
}
