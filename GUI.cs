﻿using DemoOpenGLBasicsCS.movements;
using System;
using System.Windows.Forms;
using System.Threading;


namespace DemoOpenGLBasicsCS
{
    public partial class GUI : Form

    {
        private TView oglView;
        private Boolean buttonDown;

        public GUI()
        {
            InitializeComponent();

            oglView = new TView();
            oglView.Dock = DockStyle.Fill;
            panel.Controls.Add(oglView);
            panel.Focus();
            this.buttonDown = false; //needed for press the button and can hold it. It will be used in every button feature.
            Update_positions();
        }

        private void Update_positions()
        {
            tbx_x.Text = Math.Round(oglView.Kran1.X, 3).ToString();
            tbx_y.Text = Math.Round(oglView.Kran1.Y, 3).ToString();
            tbx_z.Text = Math.Round(oglView.Kran1.Z, 3).ToString();
            tbx_xz_movement.Text = Math.Round(oglView.Kran1.MovementfactorXZ, 3).ToString();
            tbx_y_movement.Text = Math.Round(oglView.Kran1.MovementfactorY, 3).ToString();
            
            tbx_tri_x.Text = Math.Round(Math.Cos(Math.PI * oglView.Kran1.Rotationangle / 180) * oglView.Kran1.Ropeposition, 3).ToString();
            tbx_tri_y.Text = Math.Round(oglView.Kran1.Towerheight - oglView.Kran1.Ropelength, 3).ToString();
            tbx_tri_z.Text = Math.Round(Math.Sin(Math.PI * oglView.Kran1.Rotationangle / 180) * oglView.Kran1.Ropeposition, 3).ToString();
            tbx_alpha.Text = oglView.Kran1.Rotationangle.ToString();
            tbx_rad.Text = Math.Round(oglView.Kran1.Radiant, 3).ToString();
            tbx_boomlength.Text = Math.Round(oglView.Kran1.Boomlength, 3).ToString();
            tbx_towerheight.Text = Math.Round(oglView.Kran1.Towerheight, 3).ToString();
            tbx_ropelength.Text = Math.Round(oglView.Kran1.Ropelength, 3).ToString();
            tbx_ropeposition.Text = Math.Round(oglView.Kran1.Ropeposition, 3).ToString();
        }

        private void Movement(interfaces.IMovement b)
        {
            //while (buttonDown)
            //{
                oglView.Kran1.setMovement(b);
                oglView.Kran1.move();
                oglView.Kran1.Draw();
                oglView.Refresh();
                oglView.Focus();
                Update_positions();
                Thread.Sleep(50);
                Application.DoEvents();
            //}
        }

        private void btn_links_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                buttonDown = true;
                Movement(new Left());
            }
        }

        private void btn_links_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDown = false;
        }

        private void btn_rechts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                buttonDown = true;
                Movement(new Right());
            }
        }

        private void btn_rechts_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDown = false;
        }

        private void btn_ausleger_vor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                buttonDown = true;
                Movement(new Forth());
            }
        }

        private void btn_ausleger_vor_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDown = false;
        }

        private void btn_ausleger_zurueck_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                buttonDown = true;
                Movement(new Back());
            }
        }

        private void btn_ausleger_zurueck_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDown = false;
        }

        private void btn_seil_hoch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                buttonDown = true;
                Movement(new Up());
            }
        }

        private void btn_seil_hoch_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDown = false;
        }

        private void btn_seil_runter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                buttonDown = true;
                Movement(new Down());
            }
        }

        private void btn_seil_runter_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDown = false;
        }
    }
}
