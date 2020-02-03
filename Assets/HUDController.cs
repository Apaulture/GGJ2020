using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public Sprite[] HUDSprites;

    // Start is called before the first frame update
    public void UpdateHealth(int health)
    {
        int i = health - 1;

        Sprite model = HUDSprites[i];
        if (model)
        {
            SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
            sRenderer.sprite = HUDSprites[i];
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
