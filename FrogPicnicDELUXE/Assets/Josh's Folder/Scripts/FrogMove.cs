using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    public List<Transform> points;

    int index;

    [Range(0.0f, 1.0f)]
    public float time;
    public float startTime = 0.0f;

    [Range(1.0f, 2.0f)]
    public float size;

    // Update is called once per frame
    void Update()
    {
        float t = startTime / 2.0f;
        Vector3 src = points[index].position;
        Vector3 dst = points[(index + 1) % points.Count].position;
        transform.position = Vector3.Lerp(src, dst, t);

        startTime += Time.deltaTime;
        if (startTime >= 2.0f)
        {
            startTime = 0.0f;
            ++index;
            index %= points.Count;
        }
        time = Mathf.Cos(Time.realtimeSinceStartup) * 0.5f + 0.5f;
        size = Mathf.Cos(Time.realtimeSinceStartup) * 0.5f + 0.5f;
    }
}
