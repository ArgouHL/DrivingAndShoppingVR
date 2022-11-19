using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class GazeManager : MonoBehaviour
{
    [SerializeField] private Image gazeHole;
    [SerializeField] private GameObject gazeHoleBG;

    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;



    [SerializeField]  private GazeTarget nowGazeTarget;
    private GazeTarget previousGazeTarget;

    public float gazeTime = 2f;
    private float timer;
    private bool isGazeEndCalled = false;

    //[SerializeField] private Slider slider;

    private void Start()
    {
        m_EventSystem = EventSystem.current;
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.button = PointerEventData.InputButton.Left;
        gazeHole.fillAmount = 0;
        gazeHoleBG.SetActive(false);
    }

    private void Update()
    {

        
    }



    private void FixedUpdate()
    {
        m_PointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2);
        List<RaycastResult> rayResults = new List<RaycastResult>();
        m_EventSystem.RaycastAll(m_PointerEventData, rayResults);

        if (rayResults.Count > 0)
        {
            foreach (var result in rayResults)
            {
                print(result.gameObject.name);
                if( result.gameObject.GetComponent<GazeTarget>() == null)
                
                    continue;

                nowGazeTarget = result.gameObject.GetComponent<GazeTarget>();
                break;
               
            }
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
               
                if (timer >= gazeTime && !isGazeEndCalled)
                {

                    timer = 0f;
                    
                    isGazeEndCalled = true;
                    nowGazeTarget.GazeDone();
                }
            }

        }
        else
        {
            if (previousGazeTarget != null)
               OnGazeExit();
          
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
