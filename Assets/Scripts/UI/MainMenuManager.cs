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


    public void StartCoroutineMenuTransition(int targetMenu�Index)
    {
        StopAllCoroutines();
        StartCoroutine(StartMenuTransition(targetMenu�Index));
    }
    private IEnumerator StartMenuTransition(int targetMenu�Index)
    {
        //Ex�cute les activation et d��sactivation dans l'ordre
        ExitCurrentMenu();
        yield return new WaitForSeconds(3f);
        SwitchOffCurrentMenu();
        EnterNewMenu(targetMenu�Index);
    }

    private void ExitCurrentMenu()
    {
        //Selectionne quel menu d�sactiver
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
        //D�sactive le menu lorsqu'il est en dehors de l'�cran
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
    private void EnterNewMenu(int targetMenu�Index)
    {
        //Selectionne le menu � ouvrir
        switch (targetMenu�Index)
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

    //Fonctions pour afficher et d�safficher les menus
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
        //Fonction pour lancer la sc�ne principale
        Debug.Log("THE GAME STARTS !");
        //SceneManager.LoadScene, etc
    }
    public void QuitGame()
    {
        //Fonctione pour quitter le jeu
        Application.Quit();
    }
}
