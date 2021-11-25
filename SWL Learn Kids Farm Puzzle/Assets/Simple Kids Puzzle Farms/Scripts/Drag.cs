using UnityEngine;
using System.Collections;

public class Drag: MonoBehaviour
{
    public Transform target;
    private Vector3 startPos;

    private GameManager gm;

    // 2D
    private Vector2 screenPoint;
	private Vector2 offset;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();

        startPos = transform.position;
    }

    void OnMouseDown()
    {
        GetComponent<Renderer>().sortingOrder = 0;
    }

	void OnMouseDrag()
	{
		Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		transform.position = curPosition;
	}

	void OnMouseUp()
	{
        if (CheckDistance(transform.position, target.position))
        {
            transform.position = target.position;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = -2;
            gm.PlayCorrectAudio();
            gm.CurPuzzleCount++;
        }
        else
        {
            GetComponent<Renderer>().sortingOrder = -1;
            gm.PlayWrongAudio();
            StartCoroutine(TranslateTo(transform, startPos, 0.5f));
        }
    }

    bool CheckDistance(Vector3 firstPos, Vector3 endPos)
    {
        return (Vector3.Distance(firstPos, endPos) < 1f);
    }

    IEnumerator TranslateTo(Transform thisTransform, Vector3 endPos, float value)
    {
        yield return Translation(thisTransform, thisTransform.position, endPos, value);
    }

    IEnumerator Translation(Transform thisTransform, Vector3 startPos, Vector3 endPos, float value)
    {
        float rate = 1.0f / value;
        float t = 0.0f;
        while (t < 1.0)
        {
            t += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return null;
        }
    }
}