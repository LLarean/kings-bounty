using System;
using UnityEngine;

namespace KingsBounty
{
    public class Hero : MonoBehaviour
    {
        private Vector2 _vector2;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _vector2 = new Vector2(0, -1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                 _vector2 = new Vector2(0, 1);
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                 _vector2 = new Vector2(-1, 0);
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _vector2 = new Vector2(1, 0);
            }

            if (_vector2 != Vector2.zero)
            {
                transform.Translate(_vector2 );
                _vector2 = Vector2.zero;
            }
        }
    }
}
