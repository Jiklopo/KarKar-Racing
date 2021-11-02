using System.Collections;
using System.Collections.Generic;
using Cars;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
	[SerializeField] protected List<AxleInfo> axleInfos;
	[SerializeField] protected float maxMotorTorque;
	[SerializeField] protected float maxSteeringAngle;

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