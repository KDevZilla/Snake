using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    public partial class FormSnake : Form
    {
        public FormSnake()
        {
            InitializeComponent();
        }

        Game Game = null;
        private void NewGame()
        {
            GameBuilder Builder = new GameBuilder();
            PanelMap PanelMap = new PanelMap();
            PanelMap.SetPanel(this.panel1);

            Game = Builder.setMapSize(30, 30)
                    .setDisplayMap(new PanelMap().SetPanel(this.panel1))
                    .Build();

            timer1.Interval = 50;
            timer1.Enabled = true;

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GameBuilder Builder = new GameBuilder();
            PanelMap PanelMap = new PanelMap();
            PanelMap.SetPanel(this.panel1);

            Game = Builder.setMapSize(30, 30)
                    .setDisplayMap(new PanelMap ().SetPanel (this.panel1 ))                    
                    .Build();

            timer1.Interval = 50;
            timer1.Enabled = true;

          
         
            

        }
      
      
        private enDirection TurnDirection = enDirection.Right;
        private enButton ConvertFromTurnDirToButton(enDirection Dir)
        {
            enButton B = enButton.Down;
            switch (TurnDirection)
            {
                case enDirection.Down:
                    B = enButton.Down;
                    break;
                case enDirection.Up:
                    B = enButton.Up;
                    break;
                case enDirection.Left:
                    B = enButton.Left;
                    break;
                case enDirection.Right:
                    B = enButton.Right;
                    break;
            }
            return B;
        }
        private void Turn(enDirection eDir)
        {
            enDirection OpositeDirection = enDirection.Left;
            switch (TurnDirection)
            {
                case enDirection.Down :
                    OpositeDirection = enDirection.Up;
                    break;
                case enDirection.Up :
                    OpositeDirection = enDirection.Down;
                    break;
                case enDirection.Left :
                    OpositeDirection = enDirection.Right;
                    break;
                case enDirection.Right :
                    OpositeDirection = enDirection.Left;
                    break;
            }

            if (eDir == OpositeDirection)
            {
                return;
            }

            TurnDirection = eDir;

            Game.Control.Push(ConvertFromTurnDirToButton(eDir));
        }

        private void Crawl()
        {
         
        }        
        private void button2_Click(object sender, EventArgs e)
        {
            

            Turn(enDirection.Right);
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Turn(enDirection.Down );


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Turn(enDirection.Up);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Turn(enDirection.Left);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game.Loop();
            StringBuilder strB = new StringBuilder();
            
            strB.Append("Score:").Append(Game.Score.ToString())
                .Append("  Bokies:").Append(Game.Snake.Bokie.Count.ToString());
            
            this.lblScore.Text = strB.ToString();
            
            if (Game.State == enGameState.End)
            {
                timer1.Enabled = false;
               
            }
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Turn(enDirection.Left);
            }

            if (e.KeyCode == Keys.Right)
            {
                Turn(enDirection.Right);
            }

            if (e.KeyCode == Keys.Up)
            {
                Turn(enDirection.Up);
            }

            if (e.KeyCode == Keys.Down)
            {
                Turn(enDirection.Down);
            }

            if (e.KeyCode == Keys.Space)
            {
                this.timer1.Enabled = !this.timer1.Enabled;
            }
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            this.Focus();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();

        }
    }
}
