using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	public class PlayerCarController : MonoBehaviour
	{
		[SerializeField] private List<AxleInfo> axleInfos;
		[SerializeField] private float maxMotorTorque;
		[SerializeField] private float maxSteeringAngle;
		[SerializeField] private float handBrakeTorque;
		
		private PlayerInputActions inputActions;
		private float defaultBrakeTorque;
		private bool isHandbraked;

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
			isHandbraked = context.started;
			var brakeTorque = isHandbraked ? handBrakeTorque : defaultBrakeTorque;

			foreach (var axleInfo in axleInfos)
			{
				axleInfo.leftWheel.brakeTorque = brakeTorque;
				axleInfo.rightWheel.brakeTorque = brakeTorque;
			}
		}

		private void FixedUpdate()
		{
			var motorTorque = isHandbraked
				? 0
				: inputActions.Controls.Gas.ReadValue<float>() * maxMotorTorque;
			var steering = inputActions.Controls.Steering.ReadValue<float>() * maxSteeringAngle;

			foreach (var info in axleInfos)
			{
				Accelerate(info, motorTorque);
				Steer(info, steering);
				UpdateWheelsVisuals(info.leftWheel, info.leftWheelVisual);
				UpdateWheelsVisuals(info.rightWheel, info.rightWheelVisual);
			}
		}

		private void Accelerate(AxleInfo axleInfo, float motorTorque)
		{
			if (!axleInfo.motor)
				return;

			axleInfo.rightWheel.motorTorque = motorTorque;
			axleInfo.leftWheel.motorTorque = motorTorque;
		}

		private void Steer(AxleInfo axleInfo, float steeringAngle)
		{
			if (!axleInfo.steering)
				return;

			axleInfo.rightWheel.steerAngle = steeringAngle;
			axleInfo.leftWheel.steerAngle = steeringAngle;
		}

		private void UpdateWheelsVisuals(WheelCollider wheel, Transform visualWheel)
		{
			wheel.GetWorldPose(out var position, out var rotation);
			visualWheel.position = position;
			visualWheel.rotation = rotation;
		}
	}
	
	[Serializable]
	public class AxleInfo {
		public WheelCollider leftWheel;
		public WheelCollider rightWheel;
		public Transform leftWheelVisual;
		public Transform rightWheelVisual;
		public bool steering;
		public bool motor;
	}
}