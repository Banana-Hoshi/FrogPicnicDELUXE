using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleList : MonoBehaviour
{
    public List<Material> toonMaterials;
    public List<Material> shadowMaterials;
    public List<Material> decalMaterials;

    public GameObject particles;
    public GameObject cam;
    public GameObject fog;

    public bool outlinesToggled;
    public bool shadowsToggled;
    public bool particlesToggled;
    public bool doFToggled;
    public bool fogToggled;
    public bool decalToggled;

    private void Start()
    {
        outlinesToggled = true;
        particlesToggled = true;
        doFToggled = true;
        fogToggled = true;
        decalToggled = true;
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

    public void ToggleDoF()
    {
        if (doFToggled == true)
        {
            doFToggled = false;
            cam.GetComponent<DepthOfFieldEffect>().enabled = false;
        } else if (doFToggled == false)
        {
            doFToggled = true;
            cam.GetComponent<DepthOfFieldEffect>().enabled = true;
        }
    }
    public void ToggleFog()
    {
       if(fogToggled == true)
        {
            fogToggled = false;
            fog.SetActive(false);
        } else if(fogToggled == false)
        {
            fogToggled = true;
            fog.SetActive(true);
        }
    }

    public void ToggleSnow()
    {
        if (decalToggled == true)
        {
            decalToggled = false;

            for (int i = 0; i <= decalMaterials.Count - 1; i++)
            {
                decalMaterials[i].SetFloat("_ShowDecal", 0);
            }
        }
        else if (decalToggled == false)
        {
            decalToggled = true;

            for (int i = 0; i <= decalMaterials.Count - 1; i++)
            {
                decalMaterials[i].SetFloat("_ShowDecal", 1);
            }
        }
    }
}
