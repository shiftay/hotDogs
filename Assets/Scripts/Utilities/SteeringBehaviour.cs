using UnityEngine;


public abstract class SteeringBehaviour : MonoBehaviour {
	public Rigidbody2D objectToMove;
	public float maxSpeed;
	public float turnSpeed;
	public float wanderCircleDistance;
	public float wanderCircleRadius;
	public float wanderAngleAdjustment;

	public Vector2 Steering {get {return steering;}
							 set {steering = value;}}
	private float wanderAngle;
	private Vector2 steering = Vector2.zero;

	// void OnDrawGizmos()
	// {	
	// 	Gizmos.color = Color.red;
	// 	Gizmos.DrawWireSphere(transform.position, 3f);	
	// }
	void Start() {
		
	}

	// void FixedUpdate()
	// {
	// 	Wander();
	// 	ApplySteering();
	// }


	public void Reset() {
		steering = Vector2.zero;
	}
	
	public void Seek(Vector2 position, float slowingRadius = 0) {
		steering += DoSeek(position, slowingRadius);
	}
	
	public void Flee(Vector2 position) {
		steering += DoFlee(position);
	}
	
	public void Wander(){
		steering += DoWander();
	}
	// ------------ Experimental ------------
	public void Evade(Vector2 ahead,Vector2 evadePos) {
		steering += DoEvade(ahead, evadePos);
	}

	private Vector2 DoEvade(Vector2 ahead,Vector2 evadePos) {
		Vector2 desiredVelocity = new Vector2(ahead.x - evadePos.x, ahead.y - evadePos.y);
		return desiredVelocity.normalized * maxSpeed;
	}
	// ------------ Experimental ------------
	private Vector2 DoSeek(Vector2 position, float slowingRadius) {
		Vector2 desiredVelocity = position - (Vector2)transform.position;
		float distance = desiredVelocity.magnitude;
		if(distance < slowingRadius) {
			desiredVelocity = desiredVelocity.normalized * maxSpeed * (distance / slowingRadius);	
		}
		else {
			desiredVelocity = desiredVelocity.normalized * maxSpeed;
		}

		return desiredVelocity - objectToMove.velocity;
	}

	private Vector2 DoFlee(Vector2 position) {
		Vector2 desiredVelocity = (Vector2)transform.position - position;
		return desiredVelocity - objectToMove.velocity;
	}

	private Vector2 DoWander() {
		Vector2 circleCenter = objectToMove.velocity.normalized * wanderCircleDistance;
		Vector2 displacement = new Vector2(0,wanderCircleRadius);
		displacement = SetAngle(displacement, wanderAngle);
		wanderAngle += Random.Range(-1f,1f) * wanderAngleAdjustment;
		return circleCenter + displacement;
	}

	private Vector2 SetAngle(Vector2 vector, float rotation) {
		float length = vector.magnitude;
		vector.x = Mathf.Cos(rotation) * length;
		vector.y = Mathf.Sin(rotation) * length;
		return vector;
	}

	public void ApplySteering() {
		if(steering.magnitude > turnSpeed) {
			steering = steering.normalized * turnSpeed;
		}
		//objectToMove.GetComponent<Rigidbody>().velocity = (Vector2)objectToMove.GetComponent<Rigidbody>().velocity + steering;
		objectToMove.velocity += steering;

		if(objectToMove.velocity.magnitude > maxSpeed) {
			objectToMove.velocity = (objectToMove.velocity).normalized * maxSpeed;
		}
		// objectToMove.transform.rotation = Quaternion.LookRotation(objectToMove.velocity, Vector3.right);
		// objectToMove.transform.rotation = Quaternion.LookRotation(objectToMove.velocity);

		// Quaternion temp = objectToMove.transform.rotation;
		// temp = Quaternion.Euler(90f, temp.eulerAngles.y, temp.eulerAngles.z);
		// objectToMove.transform.rotation = temp;
	}
}
