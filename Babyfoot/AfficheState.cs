namespace Babyfoot;
using Babyfoot;
using jeux;
public partial class AfficheState : Form{
    Label label1 = new Label();
    Label label2 = new Label();
    Label label3 = new Label();
    Label label4 = new Label();

    public AfficheState()
    {
        InitializeComponent();
    }


      private void InitializeComponent(){
            Connexion con = new Connexion();
            Score scr = new Score();
            Matchs mat  = new Matchs();
            Matchs last = mat.getLastEnter(con);
            Score score1 = scr.selectscoreMatch(last.idMatch,1,con);
            Score score2 = scr.selectscoreMatch(last.idMatch,2,con);
            Vola vola = new Vola();
            Vola caisse1 = vola.selectMisebyMatch(last.idMatch,1,con);
            Vola caisse2 = vola.selectMisebyMatch(last.idMatch,2,con);
            MisePersonne mis = new MisePersonne();
            double jeton = mis.montantJeton(last.idMatch,con);
            // // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            Image image = Image.FromFile("statistique.png");
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(0,0);
            pictureBox1.Size = new Size(800, 800);
            pictureBox1.Image =image;
            using (Graphics graphics = Graphics.FromImage(image)){
                // Définir la police et la taille du texte
                Font font = new Font("Arial", 24, FontStyle.Bold);
                // Définir la couleur du texte
                Color color = Color.White;
                // Définir les coordonnées où le texte sera dessiné
                int x = 50;
                int y = 50;
                // Définir les coordonnées où le texte sera dessiné
                int positionx = 250;
                int positiony = 250;
                // Dessiner le texte sur l'image
                graphics.DrawString("Statistique du Match", font, new SolidBrush(color), x, y);
                graphics.DrawString(score1.montant.ToString(), font, new SolidBrush(color),  positionx, positiony);
                graphics.DrawString(score2.montant.ToString(), font, new SolidBrush(color),  positionx+250, positiony);
                graphics.DrawString("Vola:", font, new SolidBrush(color),  15, positiony+50);
                graphics.DrawString(caisse1.montant.ToString(), font, new SolidBrush(color),  positionx , positiony+50);
                graphics.DrawString(caisse2.montant.ToString(), font, new SolidBrush(color),  positionx+250 , positiony+50);
                graphics.DrawString("Jeton:", font, new SolidBrush(color),  15, positiony+150);
                graphics.DrawString(jeton.ToString(), font, new SolidBrush(color),  positionx+150 , positiony+150);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox1);
            this.Name = "Form2";
            this.Text = "Statistique Match";
            this.ResumeLayout(false);

    }
}

