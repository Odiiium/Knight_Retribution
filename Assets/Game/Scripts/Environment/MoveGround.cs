using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] Ground ground;
    internal float groundOffset;
    internal Vector3 startPos;

    private void Start()
    {
        startPos = ground.transform.position;
    }

    public void MovingGround(Ground _ground)
    {
        _ground.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 2.5f;
    }
    public void RepeatGround(Ground _ground)
    {
        groundOffset = _ground.GetComponent<BoxCollider2D>().size.x / 2;
        if (_ground.transform.position.x < startPos.x - groundOffset)
        {
            _ground.transform.position = startPos;
        }
    }
}
