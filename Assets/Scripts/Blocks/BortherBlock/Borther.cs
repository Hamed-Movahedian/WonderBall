using System.Collections.Generic;
using UnityEngine;

namespace Blocks.BortherBlock
{
    public class Borther : MonoBehaviour
    {
        public List<Vector3> NeighborsList;

        public void Check(Vector3 thisPos, IEnumerable<Vector3> otherPoses)
        {
            foreach (Vector3 neighbor in NeighborsList)
            {
                bool found = false;

                foreach (var otherPos in otherPoses)
                {
                    if (thisPos + neighbor == otherPos )
                    {
                        found = true;
                        break;
                    }

                }
                if (!found)
                {
                    gameObject.SetActive(true);
                    return;
                }
            }
            gameObject.SetActive(false);
        }
    }
}
