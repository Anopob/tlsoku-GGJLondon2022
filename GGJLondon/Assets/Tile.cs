using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Color colour;
    private Image _image;
    
    void setColour(Color c)
    {
        colour = c;
        _Image.color =  c;
    }
 
    void setHighlight(bool on)
    {
        if (on)
        {
            setColour(Color.red);

        }
        
        else
        {
            setColour(Color.blue);
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
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
