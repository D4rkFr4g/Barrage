#pragma strict

var tmpPtclObj : ParticleSystem;

function Awake() {
	// get my ParticleSystem
	tmpPtclObj = gameObject.GetComponent(ParticleSystem);
}

function Update () {
	// When it finish the play, Destroy.
	if (tmpPtclObj.isStopped)
		Destroy(gameObject);
}