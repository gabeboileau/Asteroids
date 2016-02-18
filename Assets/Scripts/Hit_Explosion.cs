using UnityEngine;
using System.Collections;

public class Hit_Explosion : MonoBehaviour
{
	public int lifeSpan = 3;

	void Start()
	{
		StartCoroutine(cr_ParticleLife());
	}


	private IEnumerator cr_ParticleLife()
	{
		yield return new WaitForSeconds(lifeSpan);
		GameObject.Destroy(this.gameObject);
	}

}
