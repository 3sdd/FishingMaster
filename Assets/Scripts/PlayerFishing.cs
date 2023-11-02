using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{

    //釣り針
    public Transform hook;

    public float hookSpeed;

    public float minHookY;
    public float maxHookY;

    //Hook fishingHook;

    LineRenderer lineRenderer;

    private void Awake()
    {
        //fishingHook = GetComponentInChildren<Hook>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var preY = hook.position.y;
        var pos = hook.position + new Vector3(0, hookSpeed * vertical, 0) * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minHookY, maxHookY);
        hook.position = pos;


        //釣り糸の糸を更新
        var deltaY = pos.y - preY;
        if (deltaY != 0)
        {
            var py = lineRenderer.GetPosition(1);
            lineRenderer.SetPosition(1, new Vector3(0, py.y + deltaY, 0));
        }

    }

}
