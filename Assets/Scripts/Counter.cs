using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yourTurns;

    private int counter = 0;

    private void OnEnable()
    {
        Player.onTurn += TurnCounter;
    }
    private void OnDisable()
    {
        Player.onTurn -= TurnCounter;
    }

    private void TurnCounter()
    {
        counter++;
        yourTurns.text = counter.ToString();
    }
}
