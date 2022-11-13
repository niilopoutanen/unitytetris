using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ColorSystem : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public GameObject grid;
    public GameObject menuBG;
    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                SetGameColors();
                break;
            case "Menu":
                SetMenuColors();
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGameColors()
    {
        var main = particleSystem.main;
        main.startColor = new Color(0, 200, 0);
        grid.GetComponent<SpriteRenderer>().color = new Color(0, 200, 0);
    }
    public void SetMenuColors()
    {
        menuBG.GetComponent<SpriteRenderer>().color = new Color(0, 0, 200);
    }
}
