using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToTrack;
    [SerializeField]
    private GameObject directionArrow;
    [SerializeField]
    private Canvas canvas;

    private GameObject currentDirectionArrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckIfObjectToTrackWithinScreen()) ShowDirectionArrow();
        else DestroyDirectionArrow();
    }

    void ShowDirectionArrow()
    {
        if (objectToTrack != null)
        {
            if(currentDirectionArrow == null)
            {
                currentDirectionArrow = Instantiate(directionArrow, canvas.transform);
                
            }
            GetDirectionOfTrackedObject();
            //MoveDirectionalArrowForward();
        }
    }

    void DestroyDirectionArrow()
    {
        if (currentDirectionArrow != null) Destroy(currentDirectionArrow);
    }

    void GetDirectionOfTrackedObject()
    {
        Vector2 screenSpaceItemToTrack = Camera.main.WorldToViewportPoint(objectToTrack.transform.position);
        Vector2 screenSpaceCurrentDirectionArrow = Camera.main.WorldToViewportPoint(currentDirectionArrow.transform.position);
        Vector2 direction = screenSpaceItemToTrack - screenSpaceCurrentDirectionArrow;

        currentDirectionArrow.transform.rotation = Quaternion.LookRotation(
                       Vector3.forward, 
                       direction           
                     );
    }

    void MoveDirectionalArrowForward()
    {
        Vector3 test = Vector3.zero + Camera.main.WorldToViewportPoint(currentDirectionArrow.transform.worldToLocalMatrix.MultiplyVector (currentDirectionArrow.transform.forward)) * 8;
        Debug.Log(test);
        currentDirectionArrow.transform.position = test;
    }
    

    bool CheckIfObjectToTrackWithinScreen()
    {
        if(objectToTrack != null)
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(objectToTrack.transform.position);
            return (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0);
        }
        
        return false;
    }
}
