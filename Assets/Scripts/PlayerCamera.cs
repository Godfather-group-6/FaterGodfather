using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
 
    public Transform _target = null;
    public Vector3 _offsetPos = Vector3.zero;
    public bool _followOnX = false;
    public bool _followOnY = false;

    public bool _smoothCam = false;
    public float _speedSmooth;



    [HideInInspector]
    public bool InNPCRange;
    [HideInInspector]
    public GameObject NPCInRange;
    Vector2 TargetPos;
    private Vector2 _velocity = Vector2.zero;
    /*A BRANCHER DANS LA DETECTION DES NPC
     var: PlayerCamera Cam; 
     
     awake: Cam=  Camera.main.gameObject.GetComponent<PlayerCamera>();

        enter: Cam.InNPCRange = true;
            Cam.NPCInRange = this.gameObject;

        exit: Cam.InNPCRange = false;
            Cam.NPCInRange = null;
         */
    void Awake()
    {

    }

    void FixedUpdate()
    {


        Vector2 newPosCam;
     
        TargetPos = new Vector2(_target.position.x, _target.position.y);

        if (InNPCRange && NPCInRange !=null)
        {
            Vector2 NpcPos = NPCInRange.transform.position;
            newPosCam = TargetPos + (NpcPos - TargetPos) / 2;
        }
        else
        {

          

                newPosCam.x = _followOnX ? TargetPos.x + _offsetPos.x : _offsetPos.x;
                newPosCam.y = _followOnY ? TargetPos.y + _offsetPos.y : _offsetPos.y;

            

        }


        if (_smoothCam)
        {
            newPosCam = Vector2.SmoothDamp(transform.position, newPosCam, ref _velocity, _speedSmooth);
        }
        transform.position = new Vector3(newPosCam.x, newPosCam.y, _offsetPos.z);
    }
}
