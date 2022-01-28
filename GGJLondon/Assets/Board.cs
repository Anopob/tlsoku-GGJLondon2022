using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Tile tilePrefab;

    private Tile[,] tiles;
    private Color storedColour;
    
    public void SwapTiles(int tile1x, int tile1y, int tile2x, int tile2y)
    {
        Tile tile1 = tiles[tile1x,tile1y];
        Tile tile2 = tiles[tile2x,tile2y];
        Color tempColour = tile1.colour;
        tile1.colour = tile2.colour;
        tile2.colour = tempColour;
    }
    
    public void ColourTile(int tilex, int tiley, Color colour)
    {
        Tile tile = tiles[tilex,tiley];
        tile.setColour(colour);
    }
    
    private void CreateBoard(int width, int height, Color[,] layout)
    {
        if ((layout.GetLength(0) != width) || (layout.GetLength(1) != height))
        {
            Debug.Log("Layout file doesn't match board size!");
            return;
        }
        
        tiles = new Tile[width,height];
        
        
        for (int i = 0; i < width; i++)
            for (int j = 0;  j < height; j++)
            {
                Tile t = Instantiate(tilePrefab, transform);
                t.x = i;
                t.y = j;
                t.setColour(layout[i,j]);
                tiles[i,j] = t;
            }

        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Color[,] puzzle = new Color[,]{
            {Color.blue, Color.red, Color.green, Color.magenta},
            {Color.blue, Color.magenta, Color.red, Color.green},
            {Color.blue, Color.green, Color.red, Color.magenta},
            {Color.blue, Color.red, Color.green, Color.magenta},
        };
        
        CreateBoard(4,4, puzzle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
