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
    public int storedType;
    private int boardWidth, boardHeight;

    public void SetHighlight(int x, int y, bool isHighlightOn)
    {
        tiles[x, y].SetHighlight(isHighlightOn);
    }

    public void ShiftColumnUp(int column)
    {
        int temp = tiles[0, column].type;

        for (int i = 0; i < tiles.GetLength(1) - 1; i++)
        {
            tiles[i, column].SetType(tiles[i + 1, column].type);
        }

        tiles[tiles.GetLength(0) - 1, column].SetType(temp);
    }

    public void ShiftColumnDown(int column)
    {
        int temp = tiles[tiles.GetLength(0) - 1, column].type;

        for (int i = tiles.GetLength(1) - 1; i > 0; i--)
        {
            tiles[i, column].SetType(tiles[i - 1, column].type);
        }

        tiles[0, column].SetType(temp);
    }

    public void ShiftRowLeft(int row)
    {
        int temp = tiles[row, 0].type;
        for (int i = 0; i < tiles.GetLength(0) - 1; i++)
        {
            tiles[row, i].SetType(tiles[row, i + 1].type);
        }

        tiles[row, tiles.GetLength(0) - 1].SetType(temp);
    }

    public void ShiftRowRight(int row)
    {
        int temp = tiles[row, tiles.GetLength(0) - 1].type;

        for (int i = tiles.GetLength(0) - 1; i > 0; i--)
        {
            tiles[row, i].SetType(tiles[row, i - 1].type);
        }

        tiles[row, 0].SetType(temp);
    }

    public void SwapTiles(int tile1x, int tile1y, int tile2x, int tile2y)
    {
        tile1x = tile1x % boardWidth;
        tile1y = tile1y % boardHeight;
        tile2x = tile2x % boardWidth;
        tile2y = tile2y % boardHeight;
        Tile tile1 = tiles[tile1x,tile1y];
        Tile tile2 = tiles[tile2x,tile2y];
        int tempType = tile1.type;
        tile1.SetType(tile2.type);
        tile2.SetType(tempType);
    }
/*    
    public void ColourTile(int tilex, int tiley, Color colour)
    {
        Tile tile = tiles[tilex,tiley];
        tile.SetColour(colour);
    }
*/    
    // Stores a colour for painting, returns the old colour
    /*
    public Color StoreColour(Color colour)
    {
        Color temp = storedColour;
        storedColour = colour;
        storageDisplay.color = colour;
        return temp;
        
    }
    */
    
    public void SetTileType(int tilex, int tiley, int type)
    {
        Tile tile = tiles[tilex,tiley];
        tile.SetType(type);
    }
    
    // Stores a type for painting, returns the old colour
    public int StoreType(int type)
    {
        int temp = storedType;
        storedType = type;
//        storageDisplay.color = colour;
        return temp;
        
    }
    
    public Tile GetTile(int x, int y)
    {
        return tiles[x,y];
    }
    
    public void CreateBoard(int width, int height, int[,] layout)
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
                //t.SetColour(layout[i,j]);
                t.SetType(layout[i,j]);
                tiles[i,j] = t;
            }

        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
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
