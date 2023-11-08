using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject turnVariants;
    [SerializeField] private GameObject id;
    private Vector3 movePosition;
    private bool canMove = true;
    private bool playerHitGoal = false;
    private int moveOrder = 0;

    public static Action<int> onSound;
    public static Action onTurn;

    private void Start()
    {
        movePosition = transform.position;
    }

    private void OnEnable()
    {
        Goal.onPlayerHitGoal += CantMove;
    }
    private void OnDisable()
    {
        Goal.onPlayerHitGoal -= CantMove;
    }

    public void PlayerSelected()
    {
        onSound?.Invoke(1);

        moveOrder = 1;
        turnVariants.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        movePosition = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }
    public void PlayerUnselected()
    {
        moveOrder = 3;
        turnVariants.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
    }
    public void SetMovePosition(Vector3 movePosition)
    {
        if (canMove)
        {
            onSound?.Invoke(2);

            this.movePosition = new Vector3(movePosition.x, 0.2f, movePosition.z);
            moveOrder = 2;

            onTurn?.Invoke();
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, movePosition);

        if(moveOrder == 1 && transform.position.y < 0.2f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            turnVariants.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        if(moveOrder == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition, distance * 10f * Time.deltaTime);
            turnVariants.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
            if (distance <= 0.01f)
            {
                moveOrder = 3;
            }
        }

        if(moveOrder == 3 && transform.position.y > -0.017f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, transform.position.z);
            turnVariants.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
            if (transform.position.y <= -0.017f)
            {
                onSound?.Invoke(3);
                PlayerUnselected();
            }
        }

        if (playerHitGoal)
        {
            turnVariants.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }
    }

    private void CantMove() //отключается движение фигурками, когда игрок достиг цели
    {
        canMove = false;
        playerHitGoal = true;
    }
}
