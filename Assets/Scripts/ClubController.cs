using UnityEngine;

namespace Assets.Scripts
{
    public class ClubController : MonoBehaviour
    {
        public float speed = 10f;
        public Vector3 targetPos;
        public bool isMoving;
        const int MOUSE = 0;
        // Use this for initialization1
        void Start()
        {

            targetPos = transform.position;
            isMoving = false;
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButton(MOUSE))
            {
                SetTarggetPosition();
            }
            if (isMoving)
            {
                MoveObject();
            }
        }
        void SetTarggetPosition()
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float point = 0f;

            if (plane.Raycast(ray, out point))
                targetPos = ray.GetPoint(point);

            isMoving = true;
        }
        void MoveObject()
        {
            transform.LookAt(targetPos);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (transform.position == targetPos)
                isMoving = false;
            Debug.DrawLine(transform.position, targetPos, Color.red);

        }
    }
}

//public class ClubController : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject club;
//    [SerializeField]
//    private Vector3 oldMousePos;

//	// Use this for initialization
//	void Start ()
//	{
//	    club = gameObject;
//	    oldMousePos = Input.mousePosition;
//	}

//	// Update is called once per frame
//	void Update ()
//	{
//	    var clubPosition = club.transform.position;
//	    var newPos = new Vector3(
//            clubPosition.x + (oldMousePos.x - Input.mousePosition.x),
//            clubPosition.y,
//            clubPosition.z + (oldMousePos.z - Input.mousePosition.z)
//        );

//	    club.transform.Translate(newPos);

//	    oldMousePos = Input.mousePosition;
//	}
//}
