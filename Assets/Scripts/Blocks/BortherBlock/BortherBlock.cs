using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Blocks.BortherBlock
{
    public class BortherBlock : Block
    {
        public List<Borther> Borthers;
        protected override void OnTransformChanged()
        {
            base.OnTransformChanged();

            var blocks=FindObjectsOfType<BortherBlock>();

            var blocksPosition=blocks.Select(b => b.transform.position);
        
            foreach (var block in blocks)
            {
                block.Check(blocksPosition);
            }

        }

        private void Check(IEnumerable<Vector3> blocksPosition)
        {
            Borthers.ForEach(b=>b.Check(transform.position, blocksPosition));
        }
    }
}
