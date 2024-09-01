using System.Threading.Tasks.Dataflow;
using Godot.Collections;

public partial class BuffController : Node {

	public static BuffController Current;

	[Signal] public delegate void PlayerBuff_AddedEventHandler(Buff newBuff);
	[Signal] public delegate void PlayerBuff_StackUpdateEventHandler(Buff newBuff);
	[Signal] public delegate void PlayerBuff_RemovedEventHandler(Buff newBuff);

	[Signal] public delegate void EnemyBuff_AddedEventHandler(Buff newBuff);
	[Signal] public delegate void EnemyBuff_StackUpdateEventHandler(Buff newBuff);
	[Signal] public delegate void EnemyBuff_RemovedEventHandler(Buff newBuff);

	Array<Buff> playerBuffs = new Array<Buff>();
	Array<Buff> enemyBuffs = new Array<Buff>();

	public void AddPlayerBuff(Buff newBuff, int stackCount = 1) {

		if (playerBuffs.Contains(newBuff)) {

			int currentBuffIndex = playerBuffs.IndexOf(newBuff);
			playerBuffs[currentBuffIndex].Stacks += stackCount;
			EmitSignal(SignalName.PlayerBuff_StackUpdate, playerBuffs[currentBuffIndex]);
		}
		else {

			newBuff.Stacks = stackCount;
			playerBuffs.Add(newBuff);
			EmitSignal(SignalName.PlayerBuff_Added, newBuff);
		}
	}
	public void AddEnemyBuff(Buff newBuff) {

		if (playerBuffs.Contains(newBuff)) {

			int currentBuffIndex = enemyBuffs.IndexOf(newBuff);
			enemyBuffs[currentBuffIndex].Stacks += newBuff.Stacks;
			EmitSignal(SignalName.EnemyBuff_StackUpdate, enemyBuffs[currentBuffIndex]);
		}
		else {

			enemyBuffs.Add(newBuff);
			EmitSignal(SignalName.EnemyBuff_Added, newBuff);
		}
	}
	public void RemovePlayerBuff(Buff targetBuff) {

		if (playerBuffs.Contains(targetBuff) == false) return;
		playerBuffs.Remove(targetBuff);
		EmitSignal(SignalName.PlayerBuff_Removed, targetBuff);
	}
	public void RemoveEnemyBuff(Buff targetBuff) {

		if (enemyBuffs.Contains(targetBuff) == false) return;
		enemyBuffs.Remove(targetBuff);
		EmitSignal(SignalName.EnemyBuff_Removed, targetBuff);
	}
	public void RemovePlayerBuffStacks(Buff targetBuff, int stacksRemoved) {

		if (playerBuffs.Contains(targetBuff) == false) return;
		int buffIndex = playerBuffs.IndexOf(targetBuff);

		if (playerBuffs[buffIndex].Stacks <= stacksRemoved) {

			RemovePlayerBuff(targetBuff);
		}
		else {

			playerBuffs[buffIndex].Stacks -= stacksRemoved;
			EmitSignal(SignalName.PlayerBuff_StackUpdate, playerBuffs[buffIndex]);
		}
	}
	public void RemoveEnemyBuffStacks(Buff targetBuff, int stacksRemoved) {

		if (enemyBuffs.Contains(targetBuff) == false) return;
		int buffIndex = enemyBuffs.IndexOf(targetBuff);

		if (enemyBuffs[buffIndex].Stacks <= stacksRemoved) {

			RemoveEnemyBuff(targetBuff);
		}
		else {

			enemyBuffs[buffIndex].Stacks -= stacksRemoved;
			EmitSignal(SignalName.EnemyBuff_StackUpdate, enemyBuffs[buffIndex]);
		}
	}

	public override void _EnterTree() {

		Current = this;
	}
}