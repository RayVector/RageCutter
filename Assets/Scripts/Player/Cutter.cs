using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutter : MonoBehaviour
{
    public GameObject pointsText;
    public PlayerState playerState;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CutItem"))
        {
            // pc
            if (Input.GetMouseButtonDown(0))
            {
                CutItemState cutItemState = collision.gameObject.GetComponent<CutItemState>();
                SetPoints(cutItemState.points);
                Destroy(collision.gameObject);
            }
            // mobile
            if (Input.touchCount > 0)
            {
                Debug.Log(3);
                Destroy(collision.gameObject);
            }
        }
    }

    public void SetPoints(int newPoints)
    {
        playerState.GetPoints(newPoints);
        Text text = pointsText.GetComponent<Text>();
        text.text = playerState.points.ToString();
    }
}
