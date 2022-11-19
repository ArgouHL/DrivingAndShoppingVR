using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GraphicRaycasterRaycaster : MonoBehaviour
{

   [SerializeField] private GraphicRaycaster m_Raycaster;
    [SerializeField] private PointerEventData m_PointerEventData;
    [SerializeField] private EventSystem m_EventSystem;

    void Start()
    {
        
        m_Raycaster = GetComponent<GraphicRaycaster>();
        
     
    }

    private void Update()
    {
        
    }
}
