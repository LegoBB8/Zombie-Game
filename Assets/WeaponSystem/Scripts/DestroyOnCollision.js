#pragma strict

function OnTriggerEnter (other : Collider)
{	


if (other.tag == "bullet"){

       Destroy (gameObject);

}


}

