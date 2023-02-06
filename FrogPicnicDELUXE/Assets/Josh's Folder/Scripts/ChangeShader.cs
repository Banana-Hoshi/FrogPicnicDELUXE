using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShader : MonoBehaviour
{
    Renderer rend;
    Shader standard;
    Shader ambient;
    Shader specular;
    Shader diffuseSpecular;
    Shader diffuseSpecularCustom;
    Shader toon;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        standard = Shader.Find("Standard");
        ambient = Shader.Find("Custom/StandardPBR");
        specular = Shader.Find("Custom/StandardSpecularPBR");

        toon = Shader.Find("Custom/ToonShader");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rend.material.shader = standard;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rend.material.shader = ambient;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rend.material.shader = specular;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            rend.material.shader = toon;
        }
    }
}
