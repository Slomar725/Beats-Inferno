using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetAll : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetAllBindings()
    {
        foreach (InputActionMap map in _inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
    }
}
