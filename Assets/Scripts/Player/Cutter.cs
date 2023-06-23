using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutter : MonoBehaviour
{
    public float reloadTime = 1f;
    public float destroyTime = 0.5f;
    public float rotationSpeed = 1f;
    public GameObject pointsText;
    public PlayerState playerState;
    public Animator animator;
    public AudioSource audioSource;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CutItem"))
        {
            if (Input.touchCount > 0)
            {
                Cut(collision);
            }
        }
    }

    public void Cut(Collider2D collision)
    {
        if (!playerState.isPlayerCutting)
        {
            playerState.isPlayerCutting = true;
            animator.Play("Cut");
            audioSource.Play();
            StartCoroutine(StartCutting(reloadTime));
            StartCoroutine(StartFalling(destroyTime, collision));
            CutItemState cutItemState = collision.gameObject.GetComponent<CutItemState>();
            SetPoints(cutItemState.points);
        }
    }

    IEnumerator StartCutting(float time)
    {
        yield return new WaitForSeconds(time);
        playerState.isPlayerCutting = false;

    }
    IEnumerator StartFalling(float time, Collider2D collision)
    {
        yield return new WaitForSeconds(time);
        collision.gameObject.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        StartCoroutine(StartDestroy(0.5f, collision));
    }

    IEnumerator StartDestroy(float time, Collider2D collision)
    {
        yield return new WaitForSeconds(time);
        Destroy(collision.gameObject);
    }

    public void SetPoints(int newPoints)
    {
        playerState.GetPoints(newPoints);
        Text text = pointsText.GetComponent<Text>();
        text.text = playerState.points.ToString();
    }
}
