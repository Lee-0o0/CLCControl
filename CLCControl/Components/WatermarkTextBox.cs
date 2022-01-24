using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CLCControls.Components
{
    public partial class WatermarkTextBox : TextBox
    {
        private string _emptyTextTip;
        private Color _emptyTextTipColor = Color.DarkGray;
        private const int WM_PAINT = 0xF;

        public WatermarkTextBox()
            : base()
        {
        }

        [DefaultValue("")]
        public string WatermarkText
        {
            get { return _emptyTextTip; }
            set
            {
                _emptyTextTip = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "DarkGray")]
        public Color EmptyTextTipColor
        {
            get { return _emptyTextTipColor; }
            set
            {
                _emptyTextTipColor = value;
                base.Invalidate();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                WmPaint(ref m);
            }
        }

        private void WmPaint(ref Message m)
        {
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                if (Text.Length == 0
                    && !string.IsNullOrEmpty(_emptyTextTip)
                    && !Focused)
                {
                    TextFormatFlags format = TextFormatFlags.EndEllipsis;

                    if (RightToLeft == RightToLeft.Yes)
                    {
                        format |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                    }
                    if (this.Multiline == true)
                    {
                        format |= TextFormatFlags.WordBreak;
                    }
                    else
                    {
                        format |= TextFormatFlags.VerticalCenter;
                    }

                    TextRenderer.DrawText(
                        graphics,
                        _emptyTextTip,
                        Font,
                        base.ClientRectangle,
                        _emptyTextTipColor,
                        format);
                }
            }
        }
    }
}
