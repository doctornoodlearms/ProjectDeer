using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

public partial class Enemy : Resource {

	public int Health { get; set; }
	public string EnemyName { get; set; }
	public List<Action> ActionList { get; set; }

	public Enemy(string name, int health, List<Action> actions) {

		EnemyName = name;
		Health = health;
		ActionList = actions;
	}
}