using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class VirusTaskGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField]
    Task ownerTask;

    private bool isDRagged = false;
    private Vector3 MouseDragStartPosition;
    private Vector3 SpriteDragStartPositon;

    GameObject lastFirstSelectedGameObject;
    GameObject virusobject;

    [SerializeField]
    BoxCollider2D trashCanCollider;

    

    public void show()
    {
        gameObject.SetActive(true);
        lastFirstSelectedGameObject = GameManager.Instance.EventSystem.firstSelectedGameObject;
        GameManager.Instance.EventSystem.firstSelectedGameObject = gameObject;
    }

    public void hide()
    {
        gameObject.SetActive(false);
        GameManager.Instance.EventSystem.firstSelectedGameObject = lastFirstSelectedGameObject;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(virusobject)
        {
            BoxCollider2D virusHitbox = virusobject.GetComponent<BoxCollider2D>();
            if(virusHitbox.bounds.Intersects(trashCanCollider.bounds))
            {
                Destroy(virusobject);
                ownerTask.SetAsResolved();
                StartCoroutine(delay());
            }
            virusobject = null;
        }
    }

   
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerPressRaycast.gameObject.name == "Virus")
        {
            virusobject = eventData.pointerPressRaycast.gameObject;
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if(virusobject)
        {
            virusobject.transform.position = eventData.position;
        }
    }
}
