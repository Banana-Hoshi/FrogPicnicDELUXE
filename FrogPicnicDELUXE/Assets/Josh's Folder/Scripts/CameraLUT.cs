using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLUT : MonoBehaviour
{
    //public Shader myShader = null;
    public Material m_renderMaterial;
    public Material normalLUT;
    public Material nightLUT;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_renderMaterial = normalLUT;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_renderMaterial = nightLUT;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_renderMaterial);
    }
}
