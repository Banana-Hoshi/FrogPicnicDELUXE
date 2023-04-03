using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleList : MonoBehaviour
{
    public List<Material> toonMaterials;
    public List<Material> shadowMaterials;

    public GameObject particles;

    public bool outlinesToggled;
    public bool shadowsToggled;
    public bool particlesToggled;

    private void Start()
    {
        outlinesToggled = true;
        particlesToggled = true;
    }

    public void ToggleOutlines()
    {
        if (outlinesToggled == true)
        {
            outlinesToggled = false;
            
            for (int i = 0; i <= toonMaterials.Count - 1; i++)
            {
                toonMaterials[i].SetFloat("_ShowOutline", 0);
            }
        }
        else if (outlinesToggled == false)
        {
            outlinesToggled = true;

            for (int i = 0; i <= toonMaterials.Count - 1; i++)
            {
                toonMaterials[i].SetFloat("_ShowOutline", 1);
            }
        }
    }

    public void ToggleShadows()
    {
        if (shadowsToggled == true)
        {
            shadowsToggled = false;

            for (int i = 0; i <= shadowMaterials.Count - 1; i++)
            {
                shadowMaterials[i].SetFloat("_ShowShadow", 0);
            }
        }
        else if (shadowsToggled == false)
        {
            shadowsToggled = true;

            for (int i = 0; i <= shadowMaterials.Count - 1; i++)
            {
                shadowMaterials[i].SetFloat("_ShowShadow", 1);
            }
        }
    }

    public void ToggleParticles()
    {
        if (particlesToggled == true)
        {
            particlesToggled = false;
            particles.SetActive(false);
        }else if (particlesToggled == false)
        {
            particlesToggled = true;
            particles.SetActive(true);
        }
    }
}
