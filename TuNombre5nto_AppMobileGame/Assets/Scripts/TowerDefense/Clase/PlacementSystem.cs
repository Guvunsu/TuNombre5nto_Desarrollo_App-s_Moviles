using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public static PlacementSystem instance { get; private set; }
    public GameObject cube, blockPrefab, mouseIndicator;
    public Grid m_Grid;
    public GridTestInput gridInput;
    public GameObject turrentMap;

    public void Awake()
    {
        if (instance != null && instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }
    public void CreateObject()
    {
        Instantiate(blockPrefab, cube.transform.position, Quaternion.identity);
    }
    public bool DoNotCollideWithOtherObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit)
        {
            Debug.Log("Can´t Build Over" + hit.collider.gameObject.name);
            return false;
        }
        else { return true; }
    }
    void Update()
    {
        Vector3 selectPosition = gridInput.GetSelectMapPos();
        mouseIndicator.transform.position = selectPosition;
        Vector3Int cellPosition = m_Grid.WorldToCell(selectPosition);
        cube.transform.position = m_Grid.GetCellCenterWorld(cellPosition);

        if (gridInput.GetPlacementInput() && DoNotCollideWithOtherObject())
        {
            CreateObject();
        }
    }
}
