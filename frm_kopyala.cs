using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clipboardtextimageandfile
{
    public partial class frm_kopyala : Form
    {
        object kopya;
        public frm_kopyala()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height- this.Height); //Formu Sağ alt köşede başlat

            //this.TopMost = true; //Pop-upda kullanılıyor
            if (Clipboard.GetDataObject().GetFormats().Length > 0)
            {
                if (Clipboard.ContainsText()) //String.Builder
                {
                    kopya = Clipboard.GetText();
                }

                else if (Clipboard.ContainsImage()) //Embed Source
                {
                    kopya = Clipboard.GetImage();
                }

                else if (Clipboard.ContainsFileDropList()) //Shell IDList Array
                {
                    for (int i = 0; i < Clipboard.GetFileDropList().Count; i++)
                    {
                        kopya += Clipboard.GetFileDropList()[i]+"\n";
                    }
                }
            }
            else kopya = null;

            Ekle(kopya);
            tmr_gucelle.Start();
        }

        protected override void WndProc(ref Message m) //Form sürüklemesini kapat
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }
            base.WndProc(ref m);
        }
        //protected override void OnDeactivate(EventArgs e) //Pop-up form deaktif olursa
        //{
        //    base.OnDeactivate(e);
        //    this.Hide();
        //}

        void Ekle(object ekle)
        {
            if (ekle != null)
            {
                Button btn_kopya = new Button();
                btn_kopya.FlatStyle = FlatStyle.Flat;
                btn_kopya.FlatAppearance.BorderColor = Color.FromArgb(150, 20, 20, 20);
                btn_kopya.FlatAppearance.BorderSize = 0;
                btn_kopya.BackColor = btn_kopya.FlatAppearance.BorderColor;
                btn_kopya.ForeColor = Color.White;
                btn_kopya.FlatAppearance.MouseOverBackColor = btn_kopya.FlatAppearance.BorderColor;
                btn_kopya.FlatAppearance.MouseDownBackColor = btn_kopya.FlatAppearance.BorderColor;
                btn_kopya.Font = new System.Drawing.Font("arial", 11, FontStyle.Regular);
                btn_kopya.Cursor = Cursors.Hand;

                if (ekle is string)
                {
                    if (ekle.ToString().Length > 20) //Eğer kopyalanan metin 20 karakterden uzunsa
                    {
                        btn_kopya.Text = ekle.ToString().Substring(0, 20) + "..."; //20. karakteri al ve sonuna ... koy
                    }
                    else
                        btn_kopya.Text = ekle.ToString();
                    btn_kopya.Click += new EventHandler(btn_kopya_Click_Text);
                    btn_kopya.Name = ekle.ToString();
                }

                else if (ekle is Image)
                {
                    //*var img = new Bitmap(((Image)ekle),new Size(120,50));
                    btn_kopya.BackgroundImage = (Image)ekle; //img;
                    btn_kopya.BackgroundImageLayout = ImageLayout.Center;
                    btn_kopya.Click += new EventHandler(btn_kopya_Click_Image);
                }
                btn_kopya.Anchor = AnchorStyles.Left & AnchorStyles.Right;
                btn_kopya.Size = new System.Drawing.Size(flp_liste.ClientSize.Width - flp_liste.Margin.All * 2, 35);

                Button btn_kapat = new Button();
                btn_kapat.FlatAppearance.BorderSize = 0;
                btn_kapat.FlatStyle = FlatStyle.Flat;
                btn_kapat.Size = new System.Drawing.Size(35, 25);
                btn_kapat.Dock = DockStyle.Right;
                btn_kapat.Text = ('\u00b4').ToString(); //´
                btn_kapat.BackColor = btn_kopya.FlatAppearance.BorderColor;
                btn_kapat.ForeColor = Color.White;
                btn_kapat.Font = new System.Drawing.Font("symbol", 10, FontStyle.Bold);
                btn_kapat.Location = new Point(btn_kopya.Width - btn_kapat.Width - btn_kopya.FlatAppearance.BorderSize, btn_kopya.FlatAppearance.BorderSize);
                btn_kapat.Click += new EventHandler(btn_kapat_Click);

                ToolTip ttp_aciklama = new ToolTip();
                ttp_aciklama.SetToolTip(btn_kopya, DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                ttp_aciklama.SetToolTip(btn_kapat, "Sil");

                btn_kopya.Controls.Add(btn_kapat);
                flp_liste.Controls.Add(btn_kopya);
            }
        }

        void btn_kapat_Click(object sender, EventArgs e) //Çarpı işaretine basıldığında çarpı butonunun içinde olduğu nesneyi sil
        {
            ((Control)sender).Parent.Dispose(); //ActiveControl.Parent.Dispose();
        }

        void btn_kopya_Click_Text(object sender, EventArgs e)
        {
            Form frm_ac = new Form();
            frm_ac.Size = new Size(400, 400);
            frm_ac.StartPosition = FormStartPosition.CenterScreen;
            frm_ac.Icon = this.Icon;

            RichTextBox rtb_kopya = new RichTextBox();
            rtb_kopya.Text = ((Control)sender).Name;
            rtb_kopya.Dock = DockStyle.Fill;
            rtb_kopya.Font = new Font(rtb_kopya.Font.FontFamily, 10);

            ContextMenuStrip cms_sag = new System.Windows.Forms.ContextMenuStrip();
            cms_sag.Items.Add("Kaydet").Click += new EventHandler(frm_kopyala_Kaydet_Yazi_Click);
            rtb_kopya.ContextMenuStrip = cms_sag;

            frm_ac.Controls.Add(rtb_kopya);
            frm_ac.Text = ((Control)sender).Text;

            frm_ac.ShowDialog();
        }

        void frm_kopyala_Kaydet_Yazi_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_kaydet = new SaveFileDialog();
            sfd_kaydet.Filter = "*.txt|*.txt|*.rtf|*.rtf";

            if (sfd_kaydet.ShowDialog() == DialogResult.OK)
            {
                ((RichTextBox)ActiveForm.Controls[0]).SaveFile(sfd_kaydet.FileName);
            }
        }

        void btn_kopya_Click_Image(object sender, EventArgs e)
        {
            Form frm_ac = new Form();
            frm_ac.Size = new Size(400, 400);
            frm_ac.StartPosition = FormStartPosition.CenterScreen;
            frm_ac.Icon = this.Icon;

            PictureBox pcr_kopya = new PictureBox();
            pcr_kopya.Image = ((Button)sender).BackgroundImage;
            pcr_kopya.SizeMode = PictureBoxSizeMode.AutoSize;
            frm_ac.Controls.Add(pcr_kopya);

            ContextMenuStrip cms_sag = new System.Windows.Forms.ContextMenuStrip();
            cms_sag.Items.Add("Kaydet").Click += new EventHandler(frm_kopyala_Click);
            cms_sag.Items.Add("Kopyala").Click += delegate
            {
                Clipboard.SetImage(pcr_kopya.Image);
            };
            frm_ac.ContextMenuStrip = cms_sag;

            frm_ac.Text = ((Control)sender).Text;
            frm_ac.AutoScroll = true;

            frm_ac.ShowDialog();
        }

        void frm_kopyala_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_kaydet = new SaveFileDialog();
            sfd_kaydet.Filter = "*.jpg|*.jpg|*.png|*.png";

            if (sfd_kaydet.ShowDialog() == DialogResult.OK)
            {
                ((PictureBox)ActiveForm.Controls[0]).Image.Save(sfd_kaydet.FileName);
            }
        }

        private void flp_liste_Resize(object sender, EventArgs e) //Formun boyutu değiştirildiğinde panel içindeki nesnelerinde boylarının değişmesini sağlamak için
        {
            flp_liste.AutoScroll = false;
            for (int i = 0; i < flp_liste.Controls.Count; i++)
            {
                flp_liste.Controls[i].Width = flp_liste.ClientSize.Width - flp_liste.Margin.All * 2;
                flp_liste.Controls[i].Controls[0].Location = new Point(flp_liste.Controls[i].Width - flp_liste.Controls[i].Controls[0].Width - ((Button)flp_liste.Controls[i]).FlatAppearance.BorderSize, flp_liste.Controls[i].Height - flp_liste.Controls[i].Controls[0].Size.Height - flp_liste.Margin.All * 2);
            }
            flp_liste.HorizontalScroll.Minimum = this.Height; // HorizontalScrollBarın çıkmasını engelle
            flp_liste.AutoScroll = true;

        }

        private void tmr_gucelle_Tick(object sender, EventArgs e)
        {
            object kontrol = null;

            if (Clipboard.GetDataObject().GetFormats().Length > 0)
            {
                if (Clipboard.ContainsText()) //String.Builder
                {
                    kontrol = Clipboard.GetText();
                }

                else if (Clipboard.ContainsImage()) //Embed Source
                {
                    kontrol = Clipboard.GetImage();
                }

                else if (Clipboard.ContainsFileDropList()) //Shell IDList Array
                {
                    for (int i = 0; i < Clipboard.GetFileDropList().Count; i++)
                    {
                        kontrol += Clipboard.GetFileDropList()[i] + ",";
                    }
                }
            }
            else
                kontrol = null;

            if (kontrol is string)
            {
                if (kopya is string || kopya is Image)
                {
                    if (kontrol.ToString() != kopya.ToString())
                    {
                        Ekle(kontrol);
                        kopya = kontrol;
                    }
                }
                else if (kopya == null)
                {
                    Ekle(kontrol);
                    kopya = kontrol;
                }
            }
            else if (kontrol is Image)
            {
                if (kopya is Image)
                {
                    if (((Bitmap)kontrol).Size != ((Bitmap)kopya).Size) //Eğer kopyalanan resim ile daha önce hafızada bulunan resimin boyutu aynı değilse
                    {
                        Ekle(kontrol);
                        kopya = kontrol;
                    }
                    else
                    {
                        Bitmap btm_kontrol = new Bitmap((Bitmap)kontrol, new Size(50, 50));
                        Bitmap btm_kopya = new Bitmap((Bitmap)kopya, new Size(50, 50));
                        for (int i = 0; i < btm_kontrol.Width; i++) //Daha önce hafızada bulunan resim ile yeni resim aynı mı diye karşılaştır
                        {
                            for (int c = 0; c < btm_kontrol.Height; c++)
                            {
                                if (btm_kontrol.GetPixel(i, c) != btm_kopya.GetPixel(i, c))
                                {
                                    Ekle(kontrol);
                                    kopya = kontrol;
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Ekle(kontrol);
                    kopya = kontrol;
                }
            }
        }

        private void nti_alt_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            gosterToolStripMenuItem.Text = "Gizle";
        }

        private void frm_kopyala_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Select(true, true);
            this.WindowState = FormWindowState.Minimized;
            this.Hide(); //Formu gizle
            gosterToolStripMenuItem.Text = "Göster";
            nti_alt.Visible = true; //NotifyIconu göster
            nti_alt.ShowBalloonTip(1000);
            e.Cancel = true;         
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CopyBoardı Kapatmak İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void gosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                gosterToolStripMenuItem.Text = "Gizle";
            }
            else
            {
                this.Hide();
                gosterToolStripMenuItem.Text = "Göster";
            }
        }

        private void baslatDurdurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tmr_gucelle.Enabled)
            {
                tmr_gucelle.Enabled = false;
                baslatDurdurToolStripMenuItem.Text = "CopyBoardı Başlat";
            }
            else
            {
                tmr_gucelle.Enabled = true;
                baslatDurdurToolStripMenuItem.Text = "CopyBoardı Durdur";
            }
        }

        private void flp_liste_ControlAdded(object sender, ControlEventArgs e)
        {
            flp_liste.ScrollControlIntoView(e.Control);
        }
    }
}
