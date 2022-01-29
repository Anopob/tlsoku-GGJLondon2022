using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Tile : MonoBehaviour
{
    public Color colour;
    public int x,y = 0;    
    
    private Image _image;
    private Outline _outline;
    
    public void SetColour(Color c)
    {
        colour = c;
        _image.color =  c;

    }
 
    public void SetHighlight(bool on)
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
        SendMessageUpwards(nameof(LevelManager.TileHighlightOn), new Vector2Int(x, y));
    }

    public void MouseOut()
    {
        SendMessageUpwards(nameof(LevelManager.TileHighlightOff), new Vector2Int(x, y));
    }
    
    public void MouseClicked(BaseEventData e)
    {
        PointerEventData pointerEventData = e as PointerEventData;

        if (pointerEventData.button == PointerEventData.InputButton.Left )
        {
            SendMessageUpwards("TileLeftClick", new Vector2Int(x,y));
            Debug.Log("Left Click");
        }
        if (pointerEventData.button == PointerEventData.InputButton.Right )
        {
            SendMessageUpwards("TileRightClick", new Vector2Int(x,y));
            Debug.Log("Right Click");
        }
        
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
