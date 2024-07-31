using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointBar : MonoBehaviour
{
    public int maxHitPoints = 10;
    private int _hitPoints = 10;

    public int hitPoints
    {
        get { return _hitPoints; }
        set
        {
            _hitPoints = value;
            UpdateScale();
        }
    }

    private void UpdateScale()
    {
        float scale = (float)_hitPoints / maxHitPoints;
        transform.localScale = new Vector3(scale, 1f, 1f);
    }
}
