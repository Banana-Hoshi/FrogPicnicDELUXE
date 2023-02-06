using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLUT : MonoBehaviour
{
    //public Shader myShader = null;
    public Material m_renderMaterial;
    public Material normalLUT;
    public Material warmLUT;
    public Material coldLUT;
    public Material customLUT;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            m_renderMaterial = normalLUT;
        }else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            m_renderMaterial = warmLUT;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            m_renderMaterial = coldLUT;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            m_renderMaterial = customLUT;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_renderMaterial);
    }
}
