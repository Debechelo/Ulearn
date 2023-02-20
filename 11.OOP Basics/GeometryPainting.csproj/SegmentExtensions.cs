using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GeometryTasks;

namespace GeometryPainting {
    public static class SegmentExtensions {
        public static Dictionary<Segment, Color> dict = new Dictionary<Segment, Color>();

        public static Color GetColor(this Segment segment) {
            if(!dict.ContainsKey(segment))
                return Color.Black;
            else
                return dict[segment];
        }

        public static void SetColor(this Segment segment, Color color) {
            if(color == null)
                color = Color.Black;
            dict[segment] = color;
        }
    }
}
