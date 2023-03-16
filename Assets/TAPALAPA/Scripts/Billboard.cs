using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// *note this is all referenced from the csulb fps workshop on 3/3/2023
public class Billboard : MonoBehaviour
{
    // used to change into different types of billboarding when needed
    public enum BillboardType { LookAtCam, CameraForward};
    [SerializeField] BillboardType _billboardType;

    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (_billboardType)
        {
            case (BillboardType.LookAtCam):
                transform.LookAt(Camera.main.transform.position + (Vector3.up * 0.15f), Vector3.up);
                break;
            case (BillboardType.CameraForward):
                transform.forward = Camera.main.transform.forward;
                break;
            default:
                break;
        }
    }
}
