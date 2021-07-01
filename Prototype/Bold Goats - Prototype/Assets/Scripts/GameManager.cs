using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #region //Player
    GameObject player;
    public GameObject Player {
        get
        {
            return player;
        }
        private set
        {
            player = value;
        }
    }
    public void SetPlayer(GameObject _player)
    {
        Player = _player;
    }
    #endregion

    #region //HUD Parent object
    GameObject hudParent;
    public GameObject HUDParent
    {
        get
        {
            return hudParent;
        }
        private set
        {
            hudParent = value;
        }
    }

    public void SetHUDParent(GameObject _hudparent)
    {
        HUDParent = _hudparent;
    }
    #endregion

    #region //MainMenu

    GameObject mainMenu;
    public GameObject MainMenu
    {
        get
        {
            return mainMenu;
        }
        private set
        {
            mainMenu = value;
        }
    }

    public void SetMainMenu(GameObject _mainMenu)
    {
        MainMenu = _mainMenu;
    }
    #endregion

    #region Fader Object

    GameObject fader;
    public GameObject Fader
    {
        get
        {
            return fader;
        }
        private set
        {
            fader = value;
        }
    }

    public void SetFader(GameObject _fader)
    {
        Fader = _fader;
    }


    #endregion

}
