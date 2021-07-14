using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*
 * Loads a scene without a transition, immediately switches to the new scene. Takes a string for the name of the scene to load.
 */
    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
    /*
     * Loads a scene with a fading transition, takes time to wait for the unload. Takes a string for the name of the scene to load.
     */
    public void LoadSceneAsync(string _sceneName)
    {
        LoadSceneEnumerator(_sceneName);
    }

    IEnumerator LoadSceneEnumerator(string _sceneName)
    {
        /*
         * Fader code fade out here
         */
        
        
        AsyncOperation unload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        AsyncOperation load = SceneManager.LoadSceneAsync(_sceneName);
        while (!unload.isDone || !load.isDone)
        {
            yield return null;
        }

        /*
         *  Fader code fade in here
         */
                
    }

    IEnumerator LoadSceneEnumerator(int _buildIndex)
    {
        /*
         * Fader code fade out here
         */


        AsyncOperation unload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        AsyncOperation load = SceneManager.LoadSceneAsync(_buildIndex);
        while (!unload.isDone || !load.isDone)
        {
            yield return null;
        }

        /*
         *  Fader code fade in here
         */
    }
    /*
    * Loads a scene without a transition, immediately switches to the new scene. Takes a integer for the build index of the scene to load.
    */
    public void LoadScene(int _buildIndex)
    {
        SceneManager.LoadScene(_buildIndex);
    }
    /*
    * Loads a scene with a fading transition, takes time to wait for the unload. Takes a integer for the build index of the scene to load.
     */
    public void LoadSceneAsync(int _buildIndex)
    {
        StartCoroutine(LoadSceneEnumerator(_buildIndex));
    }
}
