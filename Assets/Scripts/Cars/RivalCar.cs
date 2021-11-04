using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Checkpoints;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Cars
{
	public class RivalCar : Car
	{
		[SerializeField] private float minDistanceToDestination = 2f;
		[SerializeField] private float onMeshThreshold = 3;
		private Transform target;
		private NavMeshAgent navMeshAgent;
		private Queue<Vector3> path = new Queue<Vector3>();
		private Vector3 destination;
		private Vector3 direction;
		private float angle;
		private bool hasDestination;

		protected override void OnAwake()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void Start()
		{
			target = CheckpointsController.Instance.GetNextCheckpoint(-1);
			UpdateDestination();
			CalculatePath();
		}

		private void FixedUpdate()
		{
			var tr = transform;
			var position = tr.position;
			var forward = tr.forward;
			if (!hasDestination || Vector3.Distance(position, destination) < minDistanceToDestination)
				UpdateDestination();

			if (!NavMesh.SamplePosition(position, out var hit, onMeshThreshold, NavMesh.AllAreas))
			{
				ResetCar();
				CalculatePath();
			}

			direction = Vector3.ProjectOnPlane(destination - position, Vector3.up).normalized;
			var dotProduct = Vector3.Dot(direction, forward);
			angle = Vector3.SignedAngle(forward, direction, Vector3.up) * dotProduct;
			var acceleration = maxMotorTorque * dotProduct;

			foreach (var info in axleInfos)
			{
				Steer(info, angle);
				Accelerate(info, acceleration);
			}
		}

		private bool UpdateDestination()
		{
			if (path.Count != 0)
			{
				destination = path.Dequeue();
				hasDestination = true;
				return true;
			}

			CalculatePath();
			return false;
		}

		private void CalculatePath()
		{
			var navMeshPath = new NavMeshPath();
			navMeshAgent.enabled = true;
			target = CheckpointsController.Instance.GetNextCheckpoint(target);
			if (!navMeshAgent.CalculatePath(target.position, navMeshPath))
			{
				hasDestination = false;
				Debug.LogWarning("Failed to calculate path!");
				ResetCar();
				return;
			}

			path.Clear();
			foreach (var corner in navMeshPath.corners)
				path.Enqueue(corner);
			Debug.Log($"Calculated Path: {string.Join(" ", navMeshPath.corners)}");
			UpdateResetPosition();
			navMeshAgent.ResetPath();
			navMeshAgent.enabled = false;
		}

		private void OnDrawGizmos()
		{
			if (!hasDestination)
				return;

			var position = transform.position;
			var forward = transform.forward;

			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(destination, 1f);
			Gizmos.DrawRay(position, direction * 10);

			Gizmos.color = Color.blue;
			Gizmos.DrawRay(position, forward * 10);

			var angleRotation = Quaternion.Euler(0, 0, angle);
			var angleDirection = angleRotation * forward;
			Gizmos.color = Color.red;
			Gizmos.DrawRay(position, angleDirection * 10);
		}
	}
}