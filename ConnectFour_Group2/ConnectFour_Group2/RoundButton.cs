using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
	public class RoundButton : Button
	{
		public int row { get; set; }
		public int col { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {  //change flatstyle to flat when adding buttons

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(e);
        }
    }
}
