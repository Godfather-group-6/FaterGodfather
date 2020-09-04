using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
 
    public Transform _target = null;
    public Transform _targetMAP = null;
    public GameObject VisuPlayer;
    public Vector3 _offsetPos = Vector3.zero;
    public bool _followOnX = false;
    public bool _followOnY = false;

    public bool _smoothCam = false;
    public float _speedSmooth;
    public float Dezoom;
    public float ZoomSpeed;
    float Zoom;

    bool OnMap;

    Camera Cam;
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
    private void Awake()
    {
        Cam = this.gameObject.GetComponent<Camera>();
        Zoom = Cam.orthographicSize;
    }
    private void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnMap = !OnMap;
            if (OnMap)
            {
                VisuPlayer.SetActive(true);
            }
            else
            {
                VisuPlayer.SetActive(false);
            }
        } */
    }

    void FixedUpdate()
    {

        Vector2 newPosCam;
        if (OnMap)
        {
        TargetPos = new Vector2(_targetMAP.position.x, _targetMAP.position.y);
      
        if (Dezoom>Cam.orthographicSize)
        {
            Cam.orthographicSize += Time.fixedDeltaTime*ZoomSpeed ;
        }

        }
        else
        {
        TargetPos = new Vector2(_target.position.x, _target.position.y);
            if (Zoom< Cam.orthographicSize)
            {
                Cam.orthographicSize -= Time.fixedDeltaTime * ZoomSpeed;
            }
        }

        /*if (InNPCRange && NPCInRange !=null)
        {
            Vector2 NpcPos = NPCInRange.transform.position;
            newPosCam = TargetPos + (NpcPos - TargetPos) / 2;
        }
        else
        {*/

          

                newPosCam.x = _followOnX ? TargetPos.x + _offsetPos.x : _offsetPos.x;
                newPosCam.y = _followOnY ? TargetPos.y + _offsetPos.y : _offsetPos.y;

            

        


        if (_smoothCam)
        {
            newPosCam = Vector2.SmoothDamp(transform.position, newPosCam, ref _velocity, _speedSmooth);
        }
        transform.position = new Vector3(newPosCam.x, newPosCam.y, _offsetPos.z);
    }
}
