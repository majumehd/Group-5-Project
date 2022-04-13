using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public Image Background;
    public Sprite[] Sprites;
    public int x;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0,5);
        Background.sprite = Sprites[x];
    }

    //Update is called once per frame
    void Update()
    {

     
    }

}