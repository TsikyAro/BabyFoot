namespace BabyFootGasy;

public partial class PannelPossession : Panel
{
    PannelPlayer[] players1;
    PannelPlayer[] players2;
    public int x=6;
    public int y = 6;
    public PannelPossession(   PannelPlayer[] players1,PannelPlayer[] players2){
        this.players1 = players1;
        this.players2 = players2;
    }
    protected override void OnPaint(PaintEventArgs e){
        base.OnPaint(e);
        this. ExtendedDraw(e);
    }
    private void ExtendedDraw(PaintEventArgs e){
       Graphics g = e.Graphics;
        Pen outlinePen = Pens.Blue;
        g.DrawRectangle(outlinePen, this.players1[x].positionx-20, this.players1[x].positiony+20, 50, 50);
        g.DrawRectangle(outlinePen, this.players2[y].positionx-20, this.players2[y].positiony+20, 50, 50);
    }
    public void setJoueur(PannelPlayer[][] pannelPlayers)
    {
        for(int i = 0; i < pannelPlayers.Length; i++)
        {
            foreach (var pannelPlayer in pannelPlayers[i])
            {
                this.Controls.Add(pannelPlayer);
            }
        }
    }

}