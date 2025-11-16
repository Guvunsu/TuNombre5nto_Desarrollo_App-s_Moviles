using UnityEngine;

public class GridTest : MonoBehaviour
{
    public GameObject cube, blockPrefab, mouseIndicator;
    public Grid m_Grid;
    public GridTestInput gridInput;

    void Update()
    {
        Vector3 selectPosition = gridInput.GetSelectMapPos();
        mouseIndicator.transform.position = selectPosition;
        Vector3Int cellPosition = m_Grid.WorldToCell(selectPosition);
        cube.transform.position = m_Grid.GetCellCenterWorld(cellPosition);

        if (gridInput.GetPlacementInput())
        {
            Instantiate(blockPrefab, cube.transform.position, Quaternion.identity);
        }
    }
}
