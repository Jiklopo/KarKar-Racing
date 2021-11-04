using System;
using Cars;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public abstract class Car : MonoBehaviour
{
	[SerializeField] protected List<AxleInfo> axleInfos;
	[SerializeField] protected float maxMotorTorque;
	[SerializeField] protected float maxSteeringAngle;
	[SerializeField] private float onTrackThreshold = 3f;

	protected Rigidbody rb;

	private Vector3 resetPosition;
	private Quaternion resetRotation;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		resetPosition = transform.position;
		OnAwake();
	}

	protected virtual void OnAwake()
	{
	}

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

	private void OnTriggerEnter(Collider other)
	{
		OnCheckpointCrossed(other.transform);
	}

	protected virtual void OnCheckpointCrossed(Transform checkpoint)
	{
		Debug.Log($"{name} crossed {checkpoint.name} at {Time.time}");
		UpdateResetPosition();
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

	protected void UpdateResetPosition()
	{
		resetPosition = transform.position;
		resetRotation = transform.rotation;
	}

	protected void ResetCar()
	{
		var prevBrakeTorque = axleInfos[0].leftWheel.brakeTorque;
		var tr = transform;
		DoForEachWheel(w => w.brakeTorque = Mathf.Infinity);
		tr.position = resetPosition;
		tr.rotation = resetRotation;
		rb.velocity = Vector3.zero;
		DoForEachWheel(w => w.brakeTorque = prevBrakeTorque);
	}

	protected void DoForEachWheel(Action<WheelCollider> action)
	{
		foreach (var info in axleInfos)
		{
			action(info.leftWheel);
			action(info.rightWheel);
		}
	}

	protected bool IsOnTrack()
	{
		return NavMesh.SamplePosition(transform.position, out var hit, onTrackThreshold, NavMesh.AllAreas);
	}
}