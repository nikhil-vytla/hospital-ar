using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : MonoBehaviour, IPointerClickHandler
{

    //Assign in editor
    public FoodType     foodType;

    public Camera       arCamera;
    public GameObject   imageTarget;

    public int          distance;
    public int          horizontalPosition;


    //State
    private Transform   currentTarget;
    private Transform   cameraOffset;
    private bool        lerp = false;
    private int         inventoryItems = 5;
    public bool isFlying = false;

    void Start()
    {
        // place this object in front of AR camera
        InitializePosition();

        // specify target transform
        currentTarget = imageTarget.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Constantly move towards target.
        if (lerp)
            transform.localPosition = Vector3.Lerp(transform.localPosition, arCamera.transform.InverseTransformPoint(currentTarget.position), Time.deltaTime);
        else
            InitializePosition();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // move towards target if the target within the view frustum of the camera
        Vector3 viewportPos = arCamera.WorldToViewportPoint(currentTarget.position);
        if (viewportPos.z > 0 
            && viewportPos.x >= 0 && viewportPos.x <= 1
            && viewportPos.y >= 0 && viewportPos.y <= 1)
        {
            lerp = true;
            isFlying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == imageTarget || other.transform.parent.gameObject == imageTarget)
        {
            Animal animal = imageTarget.GetComponentInChildren<Animal>();
            if (animal != null)
            {
                animal.TryFeed(this);
            }

            InitializePosition();
            lerp = false;
            isFlying = false;
        }
    }

    //Helper Functions
    private void InitializePosition()
    {
        Vector3 p = new Vector3((float)horizontalPosition / (float)(inventoryItems + 1), transform.lossyScale.y/2f + 0.2f, distance);
        transform.position = Camera.main.ViewportToWorldPoint(p);
    }

}
