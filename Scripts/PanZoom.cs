using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 2;
    public float zoomOutMax = 5;

    public float minX, minY, maxX, maxY;

    float newMinX, newMaxX, newMinY, newMaxY;

    float zoomDifference;
    float camSize;

    void Update()
    {
        camSize = Camera.main.orthographicSize;

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //Zoom in and out
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        //Pan
        else if(Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;

            //Boundaries
            //zoomdifference gets bigger as camera zooms in
            zoomDifference = zoomOutMax - camSize;

            newMinX = minX - zoomDifference;
            newMaxX = zoomDifference + maxX;
   
            newMinY = minY - zoomDifference;
            newMaxY = zoomDifference + maxY;
            
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, newMinX, newMaxX), Mathf.Clamp(transform.position.y, newMinY, newMaxY), -10);
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
