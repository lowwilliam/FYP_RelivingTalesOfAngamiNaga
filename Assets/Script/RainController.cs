using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public GameObject rainPanel;
    public Animator animatorRain;

    // Start is called before the first frame update
    void Start()
    {
        rainPanel.SetActive(false);
    }

    public void ToggleRain()
    {
        if (!rainPanel.activeSelf)
        {
            rainPanel.SetActive(true);
            animatorRain.SetBool("doRain", true);
        }
        else
        {
            rainPanel.SetActive(false);
        }
    }
}
