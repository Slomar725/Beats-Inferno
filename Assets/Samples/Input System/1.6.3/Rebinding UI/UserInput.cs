using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
	public static UserInput instance;

	public bool DInput { get; private set; }
	public bool FInput { get; private set; }
	public bool JInput { get; private set; }
	public bool KInput { get; private set; }


	private PlayerInput _playerInput;
	
	private InputAction _DAction;
	private InputAction _FAction;
	private InputAction _JAction;
	private InputAction _KAction;




	private void Awake()
	{
		if(instance == null)
		{
			instance = null;
		}

		_playerInput = GetComponent<PlayerInput>();

		SetupInputActions();
	}

	private void Update()
	{
		UpdateInputs();
	}



	private void SetupInputActions()
	{
		_DAction = _playerInput.actions["Left"];
		_FAction = _playerInput.actions["LeftMiddle"];
		_JAction = _playerInput.actions["RightMiddle"];
		_KAction = _playerInput.actions["Right"];
	}

	private void UpdateInputs()
	{
		DInput = _DAction.WasPressedThisFrame();
		FInput = _DAction.WasPressedThisFrame();
		JInput = _DAction.WasPressedThisFrame();
		KInput = _DAction.WasPressedThisFrame();
	}
}
