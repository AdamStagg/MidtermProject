using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RandomizePositionWindow : EditorWindow
{
    IRandomizable[] objs;


    [MenuItem("Window/Randomize Positions of Objects")]
    static void OpenWindow()
    {
        RandomizePositionWindow randomizePositionWindow = (RandomizePositionWindow)GetWindow(typeof(RandomizePositionWindow));

        randomizePositionWindow.minSize = new Vector2(600, 300);
        randomizePositionWindow.maxSize = new Vector2(1000, 500);

        randomizePositionWindow.Show();
    }

    private void OnGUI()
    {
         
        
    }
}
