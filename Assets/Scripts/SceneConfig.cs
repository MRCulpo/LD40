using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfig : MonoBehaviour {

    public string scene;
    public static string MyScene;
    // Use this for initialization
    void Start ()
    {
        MyScene = scene;
    }

}
