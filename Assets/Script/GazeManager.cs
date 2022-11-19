using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GazeManager : MonoBehaviour
{
    [SerializeField] private Image gazeHole;
    [SerializeField] private GameObject gazeHoleBG;

    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;



    private GazeTarget nowGazeTarget;
    private GazeTarget previousGazeTarget;

    public float gazeTime = 2f;
    private float timer;
    private bool isGazeEndCalled = false;

    //[SerializeField] private Slider slider;




    private void FixedUpdate()
    {
        RaycastHit raycastHit;

        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = new Vector2(0, 0);
        List<RaycastResult> results = new List<RaycastResult>();
        


        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 400f))
        {




            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * raycastHit.distance, Color.yellow);
            //Debug.Log("Hit : " + raycastHit.transform.name);
            nowGazeTarget = raycastHit.transform.GetComponent<GazeTarget>();
            if (nowGazeTarget != null && previousGazeTarget != nowGazeTarget)
            {
                nowGazeTarget.GazeEnter();
                previousGazeTarget = nowGazeTarget;
            }
            else if (nowGazeTarget == null && previousGazeTarget != null)
            {
                OnGazeExit();


            }
            else if (nowGazeTarget != null && previousGazeTarget == nowGazeTarget)
            {
                timer += Time.deltaTime;
                gazeHoleBG.SetActive(true);
                gazeHole.fillAmount = timer / gazeTime;
                //slider.value = Mathf.Lerp(0, 100, timer / gazeTime);
                if (timer >= gazeTime && !isGazeEndCalled)
                {

                    timer = 0f;
                    //slider.value = Mathf.Lerp(0, 100, timer / gazeTime);
                    isGazeEndCalled = true;
                }
            }

        }
        else
        {
            if (previousGazeTarget != null)
                OnGazeExit();
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 500f, Color.white);
        }
    }

    private void OnGazeExit()
    {
        previousGazeTarget.GazeExit();
        previousGazeTarget = null;
        timer = 0f;
        gazeHole.fillAmount = 0;
        gazeHoleBG.SetActive(false);
        isGazeEndCalled = false;
    }


}
