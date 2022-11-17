using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMove : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;



    public void SetPlayerControl(PlayerControl e)
    {
        playerControl = e;
    }





    private void Update()
    {
        transform.position -= new Vector3(0, 0, playerControl.GetPlayerSpeed()) * Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (transform.position.z <= -200)
        {
            Destroy(this.gameObject);

        }
    }
}
