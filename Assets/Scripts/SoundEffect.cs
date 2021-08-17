using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
   public static SoundEffect Instance;

public AudioClip explosionSound;
public AudioClip shotSound;
public AudioClip enemySound;

void Awake()
{
	if (Instance !=null)
	{
	Debug.LogError("Múltiplas instâncias no script SoundEffect.");
	}
	Instance = this;
}
public void MakeExplosionSound()
{
	MakeSound(explosionSound);
}
public void MakeShotSound()
{
	MakeSound(shotSound);
}
public void MakeEnemySound()
{
	MakeSound(enemySound);
}
	private void MakeSound(AudioClip originalClip)
	{
	AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
