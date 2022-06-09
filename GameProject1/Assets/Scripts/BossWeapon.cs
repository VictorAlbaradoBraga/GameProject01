using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 4;
	public int enragedAttackDamage = 6;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
		for (int i = 0; i < colInfo.Length; i++)
		{
			colInfo[i].GetComponent<Health>().TakeDamage(attackDamage);
		}
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
		for (int i = 0; i < colInfo.Length; i++)
		{
			colInfo[i].GetComponent<Health>().TakeDamage(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}

