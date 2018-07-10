using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pk1329A02
{
    public class ShootablePole : MonoBehaviour
    {
        /* Initialize variables */
        Renderer rend;
        public int lives = 10;

        private void Start()
        {
            /* Get renderer for the Pole Game Objects */
            rend = GetComponent<Renderer>();
        }

        public void Damage()
        {
            /* Method to handle when a pole has been shot */
            lives -= 1;

            switch (lives)
            {
                case 1:
                    rend.material.SetColor("_Color", Color.yellow);
                    break;
                case 2:
                    rend.material.SetColor("_Color", Color.white);
                    break;
                case 3:
                    rend.material.SetColor("_Color", Color.red);
                    break;
                case 4:
                    rend.material.SetColor("_Color", Color.magenta);
                    break;
                case 5:
                    rend.material.SetColor("_Color", Color.green);
                    break;
                case 6:
                    rend.material.SetColor("_Color", Color.gray);
                    break;
                case 7:
                    rend.material.SetColor("_Color", Color.cyan);
                    break;
                case 8:
                    rend.material.SetColor("_Color", Color.blue);
                    break;
                case 9:
                    rend.material.SetColor("_Color", Color.black);
                    break;
                default:
                    gameObject.SetActive(false);
                    break;

            }
        }
    }

}
