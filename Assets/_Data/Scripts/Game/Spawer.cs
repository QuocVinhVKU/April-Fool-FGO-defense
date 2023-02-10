using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class Spawer : MonoBehaviour
{
    public SpriteRenderer testSPR;

    //list tower prefabs to instiate 
    public List<GameObject> towerPrefabs;
    //transform of spwning tower 
    public Transform spawnTowerRoot;
    //list tower UI 
    public List<Image> towerUI;

    // id tower to spaw
    int spawID = -1;
    //SpawPoint Tilemap
    public Tilemap spawnTilemap;
    public Animator animQuacPanel;

    private void Update()
    {
        if(CanSpawn())
        {
            DetectSpawPoint();
        }
    }
    bool CanSpawn()
    {
        if(spawID == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void DetectSpawPoint()
    {
        //detect when mouse is clicked (first touch click)
        if (Input.GetMouseButtonDown(0))
        {
            //get the world space position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //get the position of the cell in tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            cellPosDefault = new Vector3Int(CheckNumber(cellPosDefault.x), CheckNumber(cellPosDefault.y), cellPosDefault.z);

            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                int towerCost = TowerCost(spawID);
                //check if currency enough to spawn
                if (GameManager.instance.currency.EnoughCurrency(towerCost))
                {
                    GameManager.instance.currency.Use(towerCost);
                    //spawn the tower 
                    SpawnTower(cellPosDefault);
                    //disable the collider
                    noCollider(cellPosDefault);
                }
                else
                {
                    StartCoroutine(animQuac());
                }
            }
        }

    }
    IEnumerator animQuac()
    {
        animQuacPanel.SetBool("not", true);
        yield return new WaitForSeconds(0.3f);
        animQuacPanel.SetBool("not", false);
    }
    public void RevertCellState(Vector3Int pos)
    {
        spriteCollider(pos);
    }
    public int TowerCost(int id)
    {
        switch (id)
        {
            case 0: return towerPrefabs[id].GetComponent<Tower_Jack>().cost;
            case 1: return towerPrefabs[id].GetComponent<Alice>().cost;
            case 2: return towerPrefabs[id].GetComponent<Elizabeth_Bathory>().cost;
            case 3: return towerPrefabs[id].GetComponent<ArtoriaSanta>().cost;
            case 4: return towerPrefabs[id].GetComponent<Tower_Tiamat>().cost;
            case 5: return towerPrefabs[id].GetComponent<Ecchan>().cost;
            case 6: return towerPrefabs[id].GetComponent<Billy>().cost;

            default: return -1;
        }
    }
    public void SpawnTower(Vector3Int pos)
    {
        GameObject tower = Instantiate(towerPrefabs[spawID], spawnTowerRoot);
        
        tower.transform.position = pos;
        tower.GetComponent<Servant>().Init(pos);
        DeselectTower();
    }
    //set collider type of tower spawned to None
    public void noCollider(Vector3Int cellPos) 
    {
        spawnTilemap.SetColliderType(cellPos, Tile.ColliderType.None);
        // x, y+1
        Vector3Int cellPosY1 = new Vector3Int(cellPos.x, cellPos.y + 1, cellPos.z);
        spawnTilemap.SetColliderType(cellPosY1, Tile.ColliderType.None);
        //x+1, y
        Vector3Int cellPosX1 = new Vector3Int(cellPos.x+1, cellPos.y, cellPos.z);
        spawnTilemap.SetColliderType(cellPosX1, Tile.ColliderType.None);
        //x+1,y+1
        Vector3Int cellPosXY = new Vector3Int(cellPos.x+1, cellPos.y + 1, cellPos.z);
        spawnTilemap.SetColliderType(cellPosXY, Tile.ColliderType.None);
    }
    //set collider type of tower spawned to Sprite
    public void spriteCollider(Vector3Int cellPos)
    {
        spawnTilemap.SetColliderType(cellPos, Tile.ColliderType.Sprite);
        // x, y+1
        Vector3Int cellPosY1 = new Vector3Int(cellPos.x, cellPos.y + 1, cellPos.z);
        spawnTilemap.SetColliderType(cellPosY1, Tile.ColliderType.Sprite);
        //x+1, y
        Vector3Int cellPosX1 = new Vector3Int(cellPos.x + 1, cellPos.y, cellPos.z);
        spawnTilemap.SetColliderType(cellPosX1, Tile.ColliderType.Sprite);
        //x+1,y+1
        Vector3Int cellPosXY = new Vector3Int(cellPos.x + 1, cellPos.y + 1, cellPos.z);
        spawnTilemap.SetColliderType(cellPosXY, Tile.ColliderType.Sprite);
    }
    public int CheckNumber(int num)
    {
        if (num % 2 != 0)
        {
            return num+1;
        }
        else return num;
    } 
    public void selectTower(int id)
    {
        DeselectTower();
        spawID = id;
        //hightlight tower
        towerUI[spawID].color = Color.white;
    }
    public void DeselectTower()
    {
        spawID = -1;
        foreach(var t in towerUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
}
