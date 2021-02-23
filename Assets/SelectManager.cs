using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Text EditAbleText;
    private Transform _selection;

    void Update()
    {
        
        if (_selection != null) {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            EditAbleText.text = "";
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f)) {
            Debug.DrawLine(ray.origin, hit.point);
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag)) {

                var adat = selection;
                    EditAbleText.text = adat.gameObject.GetComponent<GroundItem>().item.name;
                _selection = selection;
            }
        
        }
        
    }
}
