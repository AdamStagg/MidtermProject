using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Set everything up here
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
    }

    #region //Player
    public GameObject Player { get; private set; }
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
