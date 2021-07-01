using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    #region Scene Transitions

    /*
     * Loads a scene without a transition, immediately switches to the new scene. Takes a string for the name of the scene to load.
     */
    public void LoadScene(string _sceneName)
    {
        throw new System.NotImplementedException();
    }
    /*
     * Loads a scene with a fading transition, takes time to wait for the unload. Takes a string for the name of the scene to load.
     */
    public void LoadSceneAsync(string _sceneName)
    {
        throw new System.NotImplementedException();
    }

    IEnumerator LoadSceneEnumerator(string _sceneName)
    {
        yield return null;
        throw new System.NotImplementedException();
    }

    IEnumerator LoadSceneEnumerator(int _buildIndex)
    {
        yield return null;
        throw new System.NotImplementedException();
    }
    /*
    * Loads a scene without a transition, immediately switches to the new scene. Takes a integer for the build index of the scene to load.
    */
    public void LoadScene(int _buildIndex)
    {
        throw new System.NotImplementedException();
    }
    /*
    * Loads a scene with a fading transition, takes time to wait for the unload. Takes a integer for the build index of the scene to load.
     */
    public void LoadSceneAsync(int _buildIndex)
    {
        throw new System.NotImplementedException();
    }

    #endregion

}
