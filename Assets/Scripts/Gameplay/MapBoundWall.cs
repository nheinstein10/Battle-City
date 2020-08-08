using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class MapBoundWall : MonoBehaviour {
		[SerializeField] List<GameObject> walls;

		private void Start() {
			Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 15f)));
			InitWall();
		}

		public void InitWall() {
			walls[0].GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height, 10f));
			walls[1].GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2f, 10f));
			walls[2].GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0f, 10f));
			walls[3].GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height / 2f, 10f));

			// collider size
			Vector3 p1, p2;
			float distanceInWorldUnit;

			p1 = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 10f));
			p2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10f));
			distanceInWorldUnit = (p2 - p1).magnitude;
			walls[0].GetComponent<BoxCollider2D>().size = new Vector2(distanceInWorldUnit, walls[0].GetComponent<BoxCollider2D>().size.y);

			p1 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10f));
			p2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 10f));
			distanceInWorldUnit = (p2 - p1).magnitude;
			walls[1].GetComponent<BoxCollider2D>().size = new Vector2(walls[1].GetComponent<BoxCollider2D>().size.x, distanceInWorldUnit);

			p1 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 10f));
			p2 = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 10f));
			distanceInWorldUnit = (p2 - p1).magnitude;
			walls[2].GetComponent<BoxCollider2D>().size = new Vector2(distanceInWorldUnit, walls[2].GetComponent<BoxCollider2D>().size.y);

			p1 = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 10f));
			p2 = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 10f));
			distanceInWorldUnit = (p2 - p1).magnitude;
			walls[3].GetComponent<BoxCollider2D>().size = new Vector2(walls[3].GetComponent<BoxCollider2D>().size.x, distanceInWorldUnit);
		}
	}
}
