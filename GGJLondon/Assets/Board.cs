using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Tile tilePrefab;
    public Image storageDisplay;

    public Tile[,] tiles;
    public Color storedColour;
    private int boardWidth, boardHeight;

    public void SetHighlight(int x, int y, bool isHighlightOn)
    {
        tiles[x, y].SetHighlight(isHighlightOn);
    }

    public void ShiftColumnUp(int column)
    {
        Color temp = tiles[0, column].colour;

        for (int i = 0; i < tiles.GetLength(1) - 1; i++)
        {
            tiles[i, column].SetColour(tiles[i + 1, column].colour);
        }

        tiles[tiles.GetLength(0) - 1, column].SetColour(temp);
    }

    public void ShiftColumnDown(int column)
    {
        Color temp = tiles[tiles.GetLength(0) - 1, column].colour;

        for (int i = tiles.GetLength(1) - 1; i > 0; i--)
        {
            tiles[i, column].SetColour(tiles[i - 1, column].colour);
        }

        tiles[0, column].SetColour(temp);
    }

    public void ShiftRowLeft(int row)
    {
        Color temp = tiles[row, 0].colour;
        for (int i = 0; i < tiles.GetLength(0) - 1; i++)
        {
            tiles[row, i].SetColour(tiles[row, i + 1].colour);
        }

        tiles[row, tiles.GetLength(0) - 1].SetColour(temp);
    }

    public void ShiftRowRight(int row)
    {
        Color temp = tiles[row, tiles.GetLength(0) - 1].colour;

        for (int i = tiles.GetLength(0) - 1; i > 0; i--)
        {
            tiles[row, i].SetColour(tiles[row, i - 1].colour);
        }

        tiles[row, 0].SetColour(temp);
    }

    public void SwapTiles(int tile1x, int tile1y, int tile2x, int tile2y)
    {
        tile1x = tile1x % boardWidth;
        tile1y = tile1y % boardHeight;
        tile2x = tile2x % boardWidth;
        tile2y = tile2y % boardHeight;
        Tile tile1 = tiles[tile1x,tile1y];
        Tile tile2 = tiles[tile2x,tile2y];
        Color tempColour = tile1.colour;
        tile1.SetColour(tile2.colour);
        tile2.SetColour(tempColour);
    }
    
    public void ColourTile(int tilex, int tiley, Color colour)
    {
        Tile tile = tiles[tilex,tiley];
        tile.SetColour(colour);
    }
    
    // Stores a colour for painting, returns the old colour
    public Color StoreColour(Color colour)
    {
        Color temp = storedColour;
        storedColour = colour;
        storageDisplay.color = colour;
        return temp;
        
    }
    
    public Tile GetTile(int x, int y)
    {
        return tiles[x,y];
    }
    
    public void CreateBoard(int width, int height, Color[,] layout)
    {
        if ((layout.GetLength(0) != width) || (layout.GetLength(1) != height))
        {
            Debug.Log("Layout file doesn't match board size!");
            return;
        }
        
        tiles = new Tile[width,height];
        
        boardWidth = width;
        boardHeight = height;
        
        for (int i = 0; i < width; i++)
            for (int j = 0;  j < height; j++)
            {
                Tile t = Instantiate(tilePrefab, transform);
                t.x = i;
                t.y = j;
                t.SetColour(layout[i,j]);
                tiles[i,j] = t;
            }

        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        Color[,] puzzle;
        if (Random.Range(0,2) == 0)
            puzzle = new Color[,]{
                {Color.blue, Color.red, Color.green, Color.magenta},
                {Color.blue, Color.magenta, Color.red, Color.green},
                {Color.blue, Color.green, Color.red, Color.magenta},
                {Color.blue, Color.red, Color.green, Color.magenta},
            };
        else
            puzzle = new Color[,]{
                {Color.green, Color.red, Color.green, Color.magenta},
                {Color.blue, Color.magenta, Color.blue, Color.green},
                {Color.blue, Color.green, Color.magenta, Color.magenta},
                {Color.red, Color.red, Color.green, Color.magenta},
            };
        
        CreateBoard(4,4, puzzle);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    // ------- EVENTS ------
    /*
    void TileLeftClick(Vector2Int info)
    {
        SwapTiles(info[0], info[1],info[0]+1, info[1]);
    }
    */
}
