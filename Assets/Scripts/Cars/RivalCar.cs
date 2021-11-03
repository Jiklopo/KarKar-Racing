using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Cars
{
	public class RivalCar : Car
	{
		[SerializeField] private Transform target;
		[SerializeField] private float minDistanceToDestination = 2f;
		private NavMeshAgent navMeshAgent;
		private Queue<Vector3> cornersStack = new Queue<Vector3>();
		private Vector3 destination;
		private Vector3 direction;
		private float angle;
		private bool hasDestination;

		private void Start()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
			CalculatePath();
			UpdateDestination();
		}

		private void FixedUpdate()
		{
			var position = transform.position;
			var forward = transform.forward;
			if (!hasDestination || Vector3.Distance(position, destination) < minDistanceToDestination)
				UpdateDestination();
			
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
			if (cornersStack.Count != 0)
			{
				destination = cornersStack.Dequeue();
				hasDestination = true;
				return true;
			}

			Task.Run(CalculatePath);
			return false;
		}

		private async void CalculatePath()
		{
			await Task.Delay(1);
			var path = new NavMeshPath();
			if (!navMeshAgent.CalculatePath(target.position, path))
			{
				hasDestination = false;
				Debug.LogWarning("Failed to calculate path!");
				ResetCar();
				return;
			}

			cornersStack.Clear();
			foreach (var corner in path.corners)
				cornersStack.Enqueue(corner);
			Debug.Log($"Calculated Path: {string.Join(" ", path.corners)}");
		}

		private void ResetCar()
		{
			throw new NotImplementedException();
		}

		private void OnDrawGizmos()
		{
			if(!hasDestination)
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
			Gizmos.DrawRay( position, angleDirection * 10);
		}
	}
}