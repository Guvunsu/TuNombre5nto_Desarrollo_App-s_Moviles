using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementSystem : MonoBehaviour
{
    public static PlacementSystem Instance { get; private set; }
    public GameObject cube, mouseIndicator;
    public GameObject mageTower;
    public GameObject archTower;
    public GameObject warriorTower;
    public Grid m_grid;
    //public GridTestInput gridInput;
    public GameObject turretMap;

    private Vector3 m_lastPosition;
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private InputAction touchPosAction;
    [SerializeField] private InputAction touchAction;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

        touchPosAction = inputActions.FindActionMap("Player").FindAction("TouchPosition");
        touchAction = inputActions.FindActionMap("Player").FindAction("Place");
    }

    private void OnEnable()
    {
        touchAction.Enable();
        touchAction.performed += OnTouchPerformed;
        touchPosAction.Enable();
        touchPosAction.performed += OnTouchPositionPerformed;
    }

    private void OnDisable()
    {
        touchAction.Disable();
        touchAction.performed -= OnTouchPerformed;
        touchPosAction.performed -= OnTouchPositionPerformed;
        touchPosAction.Disable();
    }

    private void OnTouchPositionPerformed(InputAction.CallbackContext context)
    {
        Vector2 touchPos = context.ReadValue<Vector2>();
        m_lastPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 0));
        Debug.Log(touchPos);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 selectedPosition = m_lastPosition;
        mouseIndicator.transform.position = selectedPosition;
        Vector3Int cellPosition = m_grid.WorldToCell(selectedPosition);
        cube.transform.position = m_grid.GetCellCenterWorld(cellPosition);

    }

    private void OnTouchPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("On touch Performed");
        PlaceTower();
    }

    public void PlaceTower()
    {
        if (DoNotCollideWithOtherObject())
        {
            CreateObject();
        }
        else
        {
            Debug.Log("Can't build!");
            //Aquí puedes agregar acciones cuando no se construyan torretas.
        }
    }

    public void CreateObject()
    {
        GameObject newObject = Instantiate(mageTower, cube.transform.position, Quaternion.identity);
        GameObject newObject2 = Instantiate(archTower, cube.transform.position, Quaternion.identity);
        GameObject newObject3 = Instantiate(warriorTower, cube.transform.position, Quaternion.identity);
        newObject.transform.SetParent(turretMap.transform);
    }

    public bool DoNotCollideWithOtherObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit)
        {
            Debug.Log("Can't build over " + hit.collider.gameObject.name);
            return false;
        }
        else
        { return true; }
    }

    public void SetTowerSprite(Sprite towerSprite)
    {
        //
        mageTower.gameObject.GetComponent<SpriteRenderer>().sprite = towerSprite;
        archTower.gameObject.GetComponent<SpriteRenderer>().sprite = towerSprite;
        warriorTower.gameObject.GetComponent<SpriteRenderer>().sprite = towerSprite;
        mouseIndicator.gameObject.GetComponent<SpriteRenderer>().sprite = towerSprite;
    }
}