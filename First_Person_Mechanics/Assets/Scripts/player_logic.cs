using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_logic : MonoBehaviour
{
    float m_rotationy;
    const float m_rotation_speed = 2.0f;
    float horizontalaxis;
    float verticalaxis;
    Vector3 horizontal_move;
    Vector3 vertical_move;
    Vector3 totalmove;
    CharacterController m_charactercontroller;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        m_charactercontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalaxis = Input.GetAxis("Horizontal");
        verticalaxis = Input.GetAxis("Vertical");
        m_rotationy += Input.GetAxis("Mouse X") * m_rotation_speed;
        transform.rotation = Quaternion.Euler(0, m_rotationy, 0);
    }
    private void FixedUpdate()
    {
        horizontal_move = transform.right * horizontalaxis * speed * Time.deltaTime;
        vertical_move = transform.forward * verticalaxis * speed * Time.deltaTime;
        totalmove = horizontal_move + vertical_move;
        if(m_charactercontroller)
        {
            m_charactercontroller.Move(totalmove);
        }
    }
    public float get_rotation_y()
    {
        return m_rotationy;
    }
}
