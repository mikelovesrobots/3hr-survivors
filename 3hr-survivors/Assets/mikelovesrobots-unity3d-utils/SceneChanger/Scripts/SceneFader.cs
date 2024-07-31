using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Tweens;
using Tweens.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
  public Canvas canvas;
  public UnityEngine.UI.Image image;
  public float transitionTime = 0.25f;
  public Color fadeColor = Color.black;

  public void FadeIn(Action onEnd = null)
  {
    var tween = GenerateFadeInTween((instance) =>
    {
      canvas.gameObject.SetActive(false);
      onEnd?.Invoke();
    });
    canvas.gameObject.SetActive(true);
    image.gameObject.AddTween(tween);

  }

  public void FadeOut(Action onEnd = null)
  {
    var tween = GenerateFadeOutTween((instance) => onEnd?.Invoke());
    canvas.gameObject.SetActive(true);
    image.gameObject.AddTween(tween);
  }

  ColorTween GenerateFadeOutTween(OnEndDelegate<Transform, Color> onEnd = null)
  {
    var transparentColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0f);
    var fullColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f);

    var tween = new ColorTween
    {
      from = transparentColor,
      to = fullColor,
      duration = transitionTime,
      easeType = EaseType.SineInOut,
      onUpdate = (_, value) => image.color = value,
      onEnd = onEnd
    };

    return tween;
  }

  ColorTween GenerateFadeInTween(OnEndDelegate<Transform, Color> onEnd = null)
  {
    var transparentColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0f);
    var fullColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f);

    var tween = new ColorTween
    {
      from = fullColor,
      to = transparentColor,
      duration = transitionTime,
      easeType = EaseType.SineInOut,
      onUpdate = (_, value) => image.color = value,
      onEnd = onEnd
    };

    return tween;
  }
}
