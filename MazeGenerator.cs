using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MazeGenerator : MonoBehaviour
{
    public GameObject player;
    public static int width = 5;
    public static int height = 5;
    public static int lev = 1;
    public static float timer;
    
    public Text level;
    public Text time;
    public Cell cellPrefab;
    public static Cell[,] cellMap;
    private List<Cell> cellHistoryList;

    public GameObject startPoint; //시작점
    public GameObject endPoint; //끝점
    public GameObject coin; //코인
    public GameObject trap; //함정
    
    // Start is called before the first frame update
    void Start()
    {
        level.text = lev + " 단계";
        timer = 60 * lev;
        time.text = timer + "초 안에 미로를 탈출하세요.\n(Coin을 획득해야 탈출가능)";

        BatchCells();
        MakeMaze(cellMap[0,0]);
        cellMap[0, 0].isLeftWall = false;
        cellMap[width - 1, height - 1].isRightWall = false;
        cellMap[0, 0].ShowWalls();
        cellMap[width - 1, height - 1].ShowWalls();

        Instantiate(startPoint, new Vector3(cellMap[0, 0].transform.position.x + 0.5f, //시작점 위치
            cellMap[0, 0].transform.position.y, 
            cellMap[0, 0].transform.position.z -0.5f), Quaternion.identity);
        Instantiate(endPoint, new Vector3(cellMap[width -1, height-1].transform.position.x + 0.5f, //엔드포인트 위치
            cellMap[width - 1, height - 1].transform.position.y, 
            cellMap[width - 1, height - 1].transform.position.z - 0.5f), Quaternion.identity);
        Instantiate(coin, new Vector3(cellMap[Random.Range(0, width - 1), Random.Range(0, height - 1)].transform.position.x + 0.5f,//코인 랜덤위치 생성
            cellMap[Random.Range(0, width - 1), Random.Range(0, height - 1)].transform.position.y - 0.5f,
            cellMap[Random.Range(0, width - 1), Random.Range(0, height - 1)].transform.position.z - 0.5f), Quaternion.identity);
        Instantiate(trap, new Vector3(cellMap[Random.Range(0, width - 1), Random.Range(0, height - 1)].transform.position.x + 0.5f,//함정 랜덤위치 생성
            cellMap[Random.Range(0, width - 1), Random.Range(0, height - 1)].transform.position.y,
            cellMap[Random.Range(0, width - 1), Random.Range(0, height - 1)].transform.position.z - 0.5f), Quaternion.identity);
    }
    private void BatchCells()
    {
        cellMap = new Cell[width, height];
        cellHistoryList = new List<Cell>();
        for(int x=0; x<width; x++)
        {
            for(int y=0; y<height; y++)
            {
                Cell _cell = Instantiate<Cell>(cellPrefab, this.transform);
                _cell.index = new Vector2Int(x, y);
                _cell.name = "cell_" + x + "_" + y;
                _cell.transform.localPosition = new Vector3(x * 1, 0, y * 1);

                cellMap[x, y] = _cell;
            }
        }
    }
    private void MakeMaze(Cell startCell)
    {
        Cell[] neighbors = GetNeighborCells(startCell);
        if(neighbors.Length > 0)
        {
            Cell nextCell = neighbors[Random.Range(0, neighbors.Length)];
            ConnectCells(startCell, nextCell);
            cellHistoryList.Add(nextCell);
            MakeMaze(nextCell);
        }
        else
        {
            if (cellHistoryList.Count > 0)
            {
                Cell lastCell = cellHistoryList[cellHistoryList.Count - 1];
                cellHistoryList.Remove(lastCell);
                MakeMaze(lastCell);
            }
        }
    }
    private Cell[] GetNeighborCells(Cell cell)
    {
        List<Cell> retCellList = new List<Cell>();
        Vector2Int index = cell.index;
        //forward
        if(index.y + 1 < height)
        {
            Cell neighbor = cellMap[index.x, index.y + 1];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        //back
        if (index.y - 1 >= 0)
        {
            Cell neighbor = cellMap[index.x, index.y - 1];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        //left
        if (index.x - 1 >= 0)
        {
            Cell neighbor = cellMap[index.x - 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        //right
        if (index.x + 1 < width)
        {
            Cell neighbor = cellMap[index.x + 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }

        return retCellList.ToArray();
    }
    private void ConnectCells(Cell c0, Cell c1)
    {
        Vector2Int dir = c0.index - c1.index;
        //forward
        if(dir.y <= -1)
        {
            c0.isForwardWall = false;
            c1.isBackWall = false;
        }
        //back
        else if(dir.y >= 1)
        {
            c0.isBackWall = false;
            c1.isForwardWall = false;
        }
        //left
        else if (dir.x >= 1)
        {
            c0.isLeftWall = false;
            c1.isRightWall = false;
        }
        //right
        else if (dir.x <= -1)
        {
            c0.isRightWall = false;
            c1.isLeftWall = false;
        }
        c0.ShowWalls();
        c1.ShowWalls();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
