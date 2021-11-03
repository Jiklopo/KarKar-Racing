using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cars
{
	public class PlayerCarController : Car
	{
		[SerializeField] protected float handBrakeTorque;

		private PlayerInputActions inputActions;
		private float defaultBrakeTorque;
		private bool handbrake;

		private void Awake()
		{
			defaultBrakeTorque = axleInfos[0].rightWheel.brakeTorque;
			inputActions = new PlayerInputActions();
			inputActions.Enable();

			inputActions.Controls.Handbrake.started += ProcessHandbrake;
			inputActions.Controls.Handbrake.canceled += ProcessHandbrake;
		}

		private void ProcessHandbrake(InputAction.CallbackContext context)
		{
			handbrake = context.started;
			var brakeTorque = handbrake ? handBrakeTorque : defaultBrakeTorque;

			foreach (var axleInfo in axleInfos)
			{
				axleInfo.leftWheel.brakeTorque = brakeTorque;
				axleInfo.rightWheel.brakeTorque = brakeTorque;
			}
		}

		private void FixedUpdate()
		{
			var motorTorque = handbrake
				? 0
				: inputActions.Controls.Gas.ReadValue<float>() * maxMotorTorque;
			var steering = inputActions.Controls.Steering.ReadValue<float>() * maxSteeringAngle;

			foreach (var info in axleInfos)
			{
				Accelerate(info, motorTorque);
				Steer(info, steering);
			}
		}
	}
}