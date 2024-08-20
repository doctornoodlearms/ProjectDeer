public partial class EnemyController : Node {

	public static EnemyController Current;

	[Signal] public delegate void EnemyAssignedEventHandler(Character newEnemy);

	Enemy enemyCharacter;

	int enemyActionIndex;
	int enemyActionCount;

	public override void _EnterTree() {

		Current = this;
	}

	public override void _Ready() {

		enemyCharacter = Definitions.testEnemy;
	}

	public void AssignEnemy(Enemy newEnemy) {

		enemyCharacter = newEnemy;
		enemyActionCount = newEnemy.ActionList.Count;

		GlobalVariables.Current.EnemyMaxHealth = enemyCharacter.Health;
		GlobalVariables.Current.EnemyHealth = enemyCharacter.Health;
		EmitSignal(SignalName.EnemyAssigned, newEnemy);
	}

	public void PerformEnemyAction() {

		if (enemyActionIndex >= enemyActionCount) enemyActionIndex = 0;
		enemyCharacter.ActionList[enemyActionIndex]();
		enemyActionIndex++;
	}
}