using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Color colour;
    public int x,y = 0;
    
    private Image _image;
    private Outline _outline;
    
    public void setColour(Color c)
    {
        colour = c;
        _image.color =  c;

    }
 
    void setHighlight(bool on)
    {
        if (on)
        {
            _outline.effectColor = Color.yellow;
        }
        
        else
        {
            _outline.effectColor = Color.black;
        }
        
    }
 
    public void MouseIn()
    {
        setHighlight(true);
    }

    public void MouseOut()
    {
        setHighlight(false);
    }
 
    // Start is called before the first frame update
    void Awake()
    {
        _image = GetComponent<Image>();
        _outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
