using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REF_EnemyController : MonoBehaviour {


    [System.Serializable]
    public class EnemyStats
    {
        public float health = 100f;
        public int damage = 10;
    }

    public EnemyStats stats = new EnemyStats();
    public Transform enemyTf;
    public Rigidbody2D rb2d_Enemy;

    // Use this for initialization
    void Start () {

        rb2d_Enemy = GetComponent<Rigidbody2D>();

        if (enemyTf == null)
        {
            Debug.LogError("No Transform for the enemy");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DamageEnemy(int damage)
    {
        stats.health -= damage;
        if (stats.health <= 0)
        {
            Destroy(enemyTf.gameObject);
        }
    }
}
