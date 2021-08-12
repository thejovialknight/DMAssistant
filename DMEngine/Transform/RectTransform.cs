using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Transform
{
    public class RectTransform : Component
    {
        public Rect rect = new Rect();
        public List<RectTransform> children = new List<RectTransform>();
        public RectTransform parent;

        public RectTransform()
        {

        }

        public RectTransform(Rect rect, RectTransform parent)
        {
            this.rect = rect;
            this.parent = parent;
        }

        public Vector2 GlobalPosition()
        {
            if (parent != null)
                return parent.rect.position + rect.position;
            else
                return rect.position;
        }

        public override void OnLink(IDataLinker linker)
        {
            rect = linker.LinkObject("Rect", rect);
        }
    }
}
