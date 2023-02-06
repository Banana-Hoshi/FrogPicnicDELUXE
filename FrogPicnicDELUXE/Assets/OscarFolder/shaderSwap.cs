using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderSwap : MonoBehaviour
{
    public Material[] materials;
    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            render.sharedMaterial = materials[1];
            Debug.Log("pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            render.sharedMaterial = materials[2];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            render.sharedMaterial = materials[3];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            render.sharedMaterial = materials[4];
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            render.sharedMaterial = materials[5];
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            render.sharedMaterial = materials[0];
        }
    }
}

