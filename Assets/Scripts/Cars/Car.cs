using System;
using System.Collections;
using System.Collections.Generic;
using Cars;
using UnityEditor;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
	[SerializeField] protected List<AxleInfo> axleInfos;
	[SerializeField] protected float maxMotorTorque;
	[SerializeField] protected float maxSteeringAngle;

	private void Update()
	{
		foreach (var info in axleInfos)
		{
			UpdateWheelsVisuals(info.leftWheel, info.leftWheelVisual);
			UpdateWheelsVisuals(info.rightWheel, info.rightWheelVisual);
		}

		OnUpdate();
	}

	protected virtual void OnUpdate()
	{
	}

	protected void Accelerate(AxleInfo axleInfo, float motorTorque)
	{
		if (!axleInfo.motor)
			return;

		axleInfo.rightWheel.motorTorque = motorTorque;
		axleInfo.leftWheel.motorTorque = motorTorque;
	}

	protected void Steer(AxleInfo axleInfo, float steeringAngle)
	{
		if (!axleInfo.steering)
			return;

		steeringAngle = Mathf.Clamp(steeringAngle, -maxSteeringAngle, maxSteeringAngle);
		axleInfo.rightWheel.steerAngle = steeringAngle;
		axleInfo.leftWheel.steerAngle = steeringAngle;
	}

	protected void UpdateWheelsVisuals(WheelCollider wheel, Transform visualWheel)
	{
		wheel.GetWorldPose(out var position, out var rotation);
		visualWheel.position = position;
		visualWheel.rotation = rotation;
	}
}