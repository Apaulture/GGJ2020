using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public Sprite[] HUDSprites;

    // Start is called before the first frame update
    void Start()
    {

        int i = SatelliteHealth.Health - 1;

        Sprite model = HUDSprites[i];
        if (model)
        {

            SpriteRenderer sRenderer = GetComponentInChildren<SpriteRenderer>();
            sRenderer.sprite = HUDSprites[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
