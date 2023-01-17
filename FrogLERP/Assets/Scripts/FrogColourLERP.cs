using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogColourLERP : MonoBehaviour
{
    public Color colour1 = Color.red;
    public Color colour2 = Color.blue;
    public float t = 1f;
    Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }
    private void Update()
    {
        float lerp = Mathf.PingPong(Time.time, t) / t;
        render.material.color = Color.Lerp(colour1, colour2, lerp);
    }
}
