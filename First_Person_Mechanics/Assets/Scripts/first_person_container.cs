using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_person_container : MonoBehaviour
{
    float m_rotationx=0;
    const float minx = -50f;
    const float maxx = 50f;
    const float rotationspeed = 2.0f;
    player_logic player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<player_logic>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rotationx -= Input.GetAxis("Mouse Y") * rotationspeed;
        m_rotationx = Mathf.Clamp(m_rotationx, minx, maxx);

    }
    private void LateUpdate()
    {
        if (player)
        {
            transform.rotation = Quaternion.Euler(m_rotationx, player.get_rotation_y(), 0);
        }
    }
}
