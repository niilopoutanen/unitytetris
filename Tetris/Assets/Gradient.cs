using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    public Color topColor, bottomColor;
    Color currentcolor;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = topColor;
        currentcolor = topColor;
    }
    public void OnMouseDown()
    {
        Debug.LogError("click");
        if (currentcolor == topColor)
        {
            currentcolor = bottomColor;
        }
        else if (currentcolor == bottomColor)
        {
            currentcolor = topColor;
        }
        spriteRenderer.material.color = Color.Lerp(spriteRenderer.material.color, currentcolor, 0.1f);

    }


    // Update is called once per frame
    void Update()
    {
        
        if (currentcolor == topColor)
        {
            currentcolor = bottomColor;
        }
        else if (currentcolor == bottomColor)
        {
            currentcolor = topColor;
        }

        //Color.Lerp(spriteRenderer.material.color, currentcolor, 0.1f);
        spriteRenderer.material.color = currentcolor;
    }
}
