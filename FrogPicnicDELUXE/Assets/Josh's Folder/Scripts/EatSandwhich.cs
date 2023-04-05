using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EatSandwhich : MonoBehaviour
{
    public int WinCondition = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WinCondition == 2)
        {
            Debug.Log("YOU WIN");
        } else if(WinCondition == 4)
        {
            Debug.Log("Eww Stinky worm");
            Invoke("RestartLevel", 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sandwhich"))
        {
            WinCondition += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("worm"))
        {
            Destroy(other.gameObject);
            WinCondition = 4;
        }
        if (other.CompareTag("Water"))
        {
            Invoke("NextLevel", 0.15f);
        }
    }
    private void NextLevel()
    {
        Application.LoadLevel(1);

    }
    private void RestartLevel()
    {
        Application.LoadLevel(0);
    }
}
