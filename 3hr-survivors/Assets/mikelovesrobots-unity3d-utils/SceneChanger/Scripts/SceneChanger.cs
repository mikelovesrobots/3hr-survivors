using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Tweens;
using Tweens.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public SceneFader sceneFader;
    public static SceneChanger Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        sceneFader.FadeIn(null);
    }

    public void ChangeScene(string sceneName)
    {
        sceneFader.FadeOut(() => SceneManager.LoadScene(sceneName));
    }
}
