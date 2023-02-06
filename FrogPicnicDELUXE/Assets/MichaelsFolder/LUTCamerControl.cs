using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUTCamerControl : MonoBehaviour
{
    public Material m_renderMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_renderMaterial);
    }
}
