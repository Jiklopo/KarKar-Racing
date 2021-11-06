using Checkpoints;
using Events;
using TMPro;
using UnityEngine;

namespace UI
{
	public class PositionsPanel : UIElement
	{
		[SerializeField] private TextMeshProUGUI positionsText;
		
		private void Start()
		{
			GameBus.OnCheckPointPassed += UpdatePositionsText;
		}

		private void OnDestroy()
		{
			GameBus.OnCheckPointPassed -= UpdatePositionsText;
		}

		private void UpdatePositionsText(Car car)
		{
			positionsText.SetText($"{CheckpointsController.Instance.PlayerPos} / 4");
		}
	}
}