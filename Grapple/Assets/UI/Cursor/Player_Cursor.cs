using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class Player_Cursor : MonoBehaviour
    {
        Player_Controller player;
        public float sensitivity;

        private void Awake()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length == 1)
            {
                player = players[0].GetComponentInChildren<Player_Controller>();
            }
            else { Debug.Log("More then one object with player tag"); };
        }
        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position = new Vector3(VirtualInputManager.Instance.cursorX * sensitivity, VirtualInputManager.Instance.cursorY * sensitivity, 0f);
        }
    }
}