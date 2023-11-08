using UnityEngine;
using UnityEngine.EventSystems;

public class Tap : MonoBehaviour
{
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask chipLayer;
    [SerializeField] private LayerMask playerLayer;
    private Player player;
    private bool canTap;

    private void Start()
    {
        canTap = true;
    }

    private void OnEnable()
    {
        Goal.onPlayerHitGoal += CantTap;
    }
    private void OnDisable()
    {
        Goal.onPlayerHitGoal -= CantTap;
    }

    private void Update()
    {
        if (canTap)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                int hitCounter = 0;

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, rayLength, playerLayer))
                {
                    if (player != null)
                    {
                        player.PlayerUnselected();
                    }
                    player = hit.collider.gameObject.GetComponent<Player>();
                    player.PlayerSelected();
                    hitCounter++;
                }

                if (hitCounter == 0)
                {
                    if (Physics.Raycast(ray, out hit, rayLength, chipLayer))
                    {
                        player.SetMovePosition(hit.collider.transform.position);
                    }
                }
            }
        }
    }

    private void CantTap()
    {
        canTap = false;
    }
}
