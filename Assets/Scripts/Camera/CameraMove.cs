using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform Player;
	[SerializeField] float m_speed = 0.1f;

	private Camera mycam;

    private void Awake()
    {
        mycam = GetComponent<Camera>();
    }

	public void Update()
	{

		mycam.orthographicSize = (Screen.height / 100f) / 0.7f;

		if (Player)
		{

			transform.position = Vector3.Lerp(transform.position, Player.position, m_speed) + new Vector3(0, 0, -12);
		}


	}
}
