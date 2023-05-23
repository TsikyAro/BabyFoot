namespace BabyFootGasy;

public partial class PannelTerrain : Panel
{
    public PannelPlayer mitondraBol = null;
    public int index = 0;
    public PannelTerrain(PannelPlayer[] players1, PannelPlayer[] players2,PannelBallon ballon,PannelPossession possesion){
        this.setJoueur(players1);
        this.setJoueur(players2);
        this.Controls.Add(ballon);
        // this.Controls.Add(possesion);
        PictureBox pictureBox1 = new PictureBox();
        pictureBox1.Location = new Point(0,0);
        pictureBox1.Size = new Size(1000, 500);
        pictureBox1.Image = Image.FromFile("terrain.png");
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        this.Controls.Add(pictureBox1);
    }
    public void setJoueur(PannelPlayer[] pannelPlayers){
        for(int i = 0; i < pannelPlayers.Length; i++)
        {
            foreach (var pannelPlayer in pannelPlayers)
            {
                this.Controls.Add(pannelPlayer);
            }
        }
    }

}