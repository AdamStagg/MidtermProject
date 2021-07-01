using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager instance;

    private void Awake()
    {
        instance = this;
    }

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
}
