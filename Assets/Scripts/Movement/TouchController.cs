using JetBrains.Annotations;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity;
    public Vector2 moveLimit = new Vector2(-3, 3);

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pastPosition.x);
        }
        pastPosition = Input.mousePosition;
    }

    public void Move(float speed)
    {
        var _newPos = transform.position + Vector3.right * Time.deltaTime * speed * velocity;
        _newPos.x = Mathf.Clamp(_newPos.x, moveLimit.x, moveLimit.y);
        transform.position = _newPos;
        //transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }

}
