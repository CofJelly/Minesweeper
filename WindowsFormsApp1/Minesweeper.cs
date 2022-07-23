using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Minesweeper : Form
    {
        private int InitialWidth;
        public Minesweeper()
        {
            InitializeComponent();
            InitialWidth = this.ClientSize.Width;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var boxSize = 30;
            var pixelsToEdge = 15;
            var currentHeight = 35;
            var width = Int32.Parse(WidthTextBox.Text);
            var height = Int32.Parse(HeightTextBox.Text);
            this.ClientSize = new Size(Math.Max(InitialWidth, width * boxSize + pixelsToEdge * 2), height * boxSize + pixelsToEdge * 2 + currentHeight);
            for(int i = 0;i<width;i++)
            {
                for(int j = 0;j<height;j++)
                {
                    var newButton = new Button();
                    newButton.Location = new Point(pixelsToEdge + boxSize * i, pixelsToEdge + boxSize * j + currentHeight);
                    newButton.Name = $"Button{i}-{j}";
                    newButton.Size = new Size(boxSize, boxSize);
                    newButton.UseVisualStyleBackColor = true;
                    newButton.Click += new EventHandler(ClickTile);
                    this.Controls.Add(newButton);
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            Game.Instance.Reset();
        }

        private void ClickTile(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Button))
                return;
            var button = (Button)sender;
            var coordsString = button.Name.Substring(6);
            var coordsArray = coordsString.Split('-');
            button.Text = Game.Instance.ButtonClick(Int32.Parse(coordsArray[0]), Int32.Parse(coordsArray[1]));
        }
    }
}
