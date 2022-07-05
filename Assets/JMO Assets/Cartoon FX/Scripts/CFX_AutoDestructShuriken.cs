using UnityEngine;
using System.Collections;

// Cartoon FX  - (c) 2015 Jean Moreno

// Automatically destructs an object when it has stopped emitting particles and when they have all disappeared from the screen.
// Check is performed every 0.5 seconds to not query the particle system's state every frame.
// (only deactivates the object if the OnlyDeactivate flag is set, automatically used with CFX Spawn System)

[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
	// If true, deactivate the object instead of destroying it
	public bool OnlyDeactivate;
	
	void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}
	
	IEnumerator CheckIfAlive ()
	{
		ParticleSystem ps = this.GetComponent<ParticleSystem>();
		
		while(true && ps != null)
		{
			yield return new WaitForSeconds(0.5f);
			if(!ps.IsAlive(true))
			{
				if (OnlyDeactivate)
				{
#if UNITY_3_5
						this.gameObject.SetActiveRecursively(false);
#else
					this.gameObject.SetActive(false);
#endif
				}
				else
				{
					if (this.gameObject.name == "MissileEffect(Clone)")
						ObjectPool.Instance.Set(this.gameObject, ObjectFlag.PlayerMissileEffect);
					else
					{
						if (this.gameObject.name == "JellyDie(Clone)")
						{
							ObjectPool.Instance.Set(this.gameObject, ObjectFlag.MonsterBomb);
						}
						else if (this.gameObject.name == "JellyMissileEffect(Clone)")
						{
							ObjectPool.Instance.Set(this.gameObject, ObjectFlag.PlayerMissile);
						}
						else
						ObjectPool.Instance.Set(this.gameObject, ObjectFlag.MonsterBombEffect);
					}
				}
				break;
			}
		}
	}
}
