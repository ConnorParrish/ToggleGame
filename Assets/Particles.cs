using UnityEngine;
using System.Collections;

public class Randomcolor : MonoBehaviour {

	ParticleAnimator particleAni;

public void Start()
	{
		particleAni = GetComponent<ParticleAnimator> ();
		Color[] aniColors = particleAni.colorAnimation;

		for (int i = 0; i < aniColors.Length; i++) {
			aniColors [i].r = Random.Range (0.0f, 1.0f);
			aniColors [i].g = Random.Range (0.0f, 1.0f);
			aniColors [i].b = Random.Range (0.0f, 1.0f);
			aniColors [i].a = Random.Range (0.0f, 1.0f);
		}
		particleAni.colorAnimation = aniColors;
	}
}
