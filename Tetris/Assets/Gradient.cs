using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    public Color topColor, bottomColor;
    Color currentcolor;
    SpriteRenderer spriteRenderer;


    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    // Start is called before the first frame update
    void Start()
    {
        Gradient g = new Gradient();
        GradientColorKey[] gck = new GradientColorKey[2];
        GradientAlphaKey[] gak = new GradientAlphaKey[2];
        gck[0].color = Color.red;
        gck[0].time = 1.0F;
        gck[1].color = Color.blue;
        gck[1].time = -1.0F;
        gak[0].alpha = 0.0F;
        gak[0].time = 1.0F;
        gak[1].alpha = 0.0F;
        gak[1].time = -1.0F;
        g.SetKeys(gck, gak);
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.material.color = g.Evaluate(1);
        //currentcolor = topColor;
    }


    // Update is called once per frame
    void Update()
    {

        //if (currentcolor == topColor)
        //{
        //    currentcolor = bottomColor;
        //}
        //else if (currentcolor == bottomColor)
        //{
        //    currentcolor = topColor;
        //}

        //Color.Lerp(spriteRenderer.material.color, currentcolor, 0.1f);
        //spriteRenderer.material.color = currentcolor;
    }
}