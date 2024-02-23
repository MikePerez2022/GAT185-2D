using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon2D : Weapon2D
{
	[SerializeField] Transform attackLeftTransform;
	[SerializeField] Transform attackRightTransform;
	[SerializeField, Range(0, 5)] float attackRadius = 1;

	public override bool Use(Animator animator)
	{
		bool used = false;
		if (ready)
		{
			if (animator != null && animationTriggerName != "")
			{
				animator.SetTrigger(animationTriggerName);
				ready = false;
				StartCoroutine(ResetAttackReadyCR(attackRate));

				used = true;
			}
		}

		return used;
	}

	public override void Attack(eDirection direction)
	{
		Vector3 position = (direction == eDirection.Right) ? attackRightTransform.position : attackLeftTransform.position;

		var colliders = Physics2D.OverlapCircleAll(position, attackRadius, layerMask);
		foreach (var collider in colliders)
		{
			if ((tagName == "" || collider.gameObject.CompareTag(tagName)) && collider.gameObject.TryGetComponent(out IDamagable damagable))
			{
				damagable.ApplyDamage(damage);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackLeftTransform.position, attackRadius);
		Gizmos.DrawWireSphere(attackRightTransform.position, attackRadius);
	}

	IEnumerator ResetAttackReadyCR(float time)
	{
		yield return new WaitForSeconds(time);
		ready = true;
	}

}
