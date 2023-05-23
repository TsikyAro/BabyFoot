using System.Numerics;
using Babyfoot;
using jeux;
namespace BabyFootGasy;

public partial class Form3 : Form
{
    PannelPlayer panel1 = new PannelPlayer(Color.AliceBlue);
    PannelPlayer[] players1;
    PannelPlayer[] players2;
    PannelBallon ballon = new PannelBallon();
    PannelPossession poses ;
    int score1 = 0;
    int score2 = 0;
    string score = "0:0";
    Label label ;
    
    int possession1 = 6;
    int possession2 = 6;
    PannelPlayer control1 ;
    PannelPlayer control2 ;
    int half;
    PannelTerrain terrain;
    Connexion con = new Connexion();
    Matchs match = new Matchs();
    Matchs last ;
    Label curseur1 = new Label {BackColor =  Color.AliceBlue, Location = new Point(10,10),Width = 20, Height = 20};
    Label curseur2 = new Label {BackColor =  Color.AliceBlue, Location = new Point(10,10),Width = 20, Height = 20};
    public Form3(){
        label = new Label();
        label.BringToFront();
        label.Text = score ;
        label.Font = new Font("Arial", 50);
        label.Location = new Point(450, 530);
        label.Size = new Size(500, 1000);
        label.BackColor = Color.Transparent;
        this.players1 = panel1.getJoueur1();
        this.players2 = panel1.getJoueur2();
        control1  = players1[6];
        control1.Controls.Add(curseur1);
        control2  = players2[6];
        control2.Controls.Add(curseur2);
        poses = new PannelPossession(players1,players2);
        this.ClientSize = new System.Drawing.Size(1030, 630);
        terrain = new PannelTerrain(this.players1,this.players2,ballon,poses);
        terrain.SetBounds(10,10,1000,500);
        this.KeyDown += new KeyEventHandler(clavier);
        this.Controls.Add(label);
        this.Controls.Add(terrain);
        last = match.getLastEnter(con);
        half =last.pointGagnant/2;
    }
    private void clavier(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Q:
                this.control1.Controls.Remove(curseur1);
                possession1 = possession1 + 1;
                if(possession1>=12){
                    possession1 = 0;
                }
                this.control1 = players1[possession1];
                this.control1.Controls.Add(curseur1);
            break;
            case Keys.P:
                this.control2.Controls.Remove(curseur2);
                possession2 = possession2 + 1;
                if(possession2>=12){
                    possession2 = 0;
                }
                this.control2 = players2[possession2];
                this.control2.Controls.Add(curseur2);
            break;
            
        }
        // ambonyambany1
        if(e.KeyCode == Keys.S && this.control1.Location.Y > 0){
            this.panel1.deplacement(this.control1,-5,0);
        } 
        else if(e.KeyCode == Keys.X && this.control1.Location.Y < 500 - 30){
            this.panel1.deplacement(this.control1,5,0);
        }
        // gauchedroite1
        if(e.KeyCode == Keys.Z && this.control1.Location.Y > 0){
            this.panel1.deplacement(this.control1,0,-5);
        } 
        else if(e.KeyCode == Keys.C && this.control1.Location.Y < 500 - 30){
            this.panel1.deplacement(this.control1,0,5);
        }
        //  ambonyambany2
        if(e.KeyCode == Keys.Up && this.control2.Location.Y > 0){
            this.panel1.deplacement(this.control2,-5,0);
        }
        else if(e.KeyCode == Keys.Down && this.control2.Location.Y < 500 - 30){
            this.panel1.deplacement(this.control2,5,0);
        }
        // gauchedroite2
        if(e.KeyCode == Keys.Left && this.control2.Location.Y > 0){
            this.panel1.deplacement(this.control2,0,-5);
        } 
        else if(e.KeyCode == Keys.Right && this.control2.Location.Y < 500 - 30){
            this.panel1.deplacement(this.control2,0,5);
        }
        this.misyBol(ballon);
        if(e.KeyCode == Keys.B)
        {
            ballon.tsyMisyMitondra = true;
            Random r = new Random();
            int x = r.Next(-5,5);
            int y = r.Next(-5,5);
            this.deplacementBallon(ballon,players1,players2,x,y);
        }
        if(terrain.mitondraBol != null)
        switch (e.KeyCode)
        {
            case Keys.T:
                ballon.tsyMisyMitondra = true;
                if(terrain.mitondraBol.equipe == 0){
                    this.deplacementBallon(ballon,players1,players2,10,0);
                    // MessageBox.Show("Joueur1 nahafaty: "+terrain.mitondraBol.intitule);
                }
                else{
                    this.deplacementBallon(ballon,players1,players2,-10,0);
                }
                
            break;
            case Keys.Y:
                ballon.tsyMisyMitondra = true;
                int max = terrain.index;
                // if(max < 3)
                // {
                    if(terrain.mitondraBol.equipe == 0){
                        int[] values = this.derivation(players1,ballon);
                        this.deplacementBallon(ballon,players1,players2,values[0],values[1]);
                    }
                    else{
                        int[] values = this.derivation(players2,ballon);
                        this.deplacementBallon(ballon,players1,players2,values[0],values[1]);
                    } 
                // }
            break;
        }
        
        if(e.KeyCode== Keys.Space){
            PannelPlayer player = new PannelPlayer(Color.Red);
            player.SetBounds(500, 450, 30, 30);
            Array.Resize(ref players1, players1.Length + 1);
            players1[players1.Length - 1] = player;
            this.terrain.Controls.Add(players1[players1.Length - 1]);
            player.BringToFront();
        }
    }
    public void misyBol(PannelBallon ballon){
        if(terrain.mitondraBol != null)
        {
            switch (terrain.mitondraBol.equipe)
            {
                case 0:
                    ballon.Location = new Point(terrain.mitondraBol.Location.X+30, terrain.mitondraBol.Location.Y+5);
                break;
                case 1:
                    ballon.Location = new Point(terrain.mitondraBol.Location.X-20, terrain.mitondraBol.Location.Y+5);
                break;
            }
        }
    }
    public double rayon(Control c){
        int longueur = c.Width;
        int hauteur = c.Height;
        if(longueur == hauteur)return longueur / 2;
        else return (longueur + hauteur) / 4; 
    }
    public double rayon2(Control c1, Control c2){
        return this.rayon(c1) + rayon(c2);
    }
    public double distance(Control c1, Control c2){
       return Math.Sqrt(Math.Pow((c2.Location.X - c1.Location.X), 2)+Math.Pow((c2.Location.Y - c1.Location.Y) , 2));
    }
    public bool colision(Control c1, Control c2){
        if(rayon2(c1,c2) >= distance(c1,c2))return true;
        else return false;
    }
    public bool checkCollision(PannelPlayer[] p1, PannelPlayer[]p2, PannelBallon ballon){
        for (int i = 0; i < p1.Length; i++)
        {
            if(colision(p1[i],ballon))
            {
                ballon.Location = new Point(p1[i].Location.X+30, p1[i].Location.Y+5);
                terrain.mitondraBol = p1[i];
                this.control1.Controls.Remove(curseur1);
                this.control1 = this.terrain.mitondraBol;
                this.control1.Controls.Add(curseur1);
                terrain.index = i;
                return false;
            }
        }
        for (int i = 0; i < p2.Length; i++)
        {
                // if(colision(p2[i],ballon) && p2[i] != this.terrain.mitondraBol)
                if(colision(p2[i],ballon))
                {
                    ballon.Location = new Point(p2[i].Location.X-20, p2[i].Location.Y+5);
                    terrain.mitondraBol = p2[i];
                    this.control2.Controls.Remove(curseur2);
                    this.control2 = this.terrain.mitondraBol;
                    this.control2.Controls.Add(curseur2);
                    terrain.index = i;
                    return false;
                }
        }
        return true;
    }
    public int[] derivation(PannelPlayer[] players, PannelBallon ballon){
        double min = 1000;
        PannelPlayer player = new PannelPlayer(Color.Red);
        int echelle = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if(this.distance(players[i],ballon) < min)
            {
                min = this.distance(players[i],ballon);
                echelle = (int) min/10;
                player = players[i];
            }
        }
        int x = (ballon.Location.X - player.Location.X)/echelle;
        int y = (ballon.Location.Y - player.Location.Y)/echelle;
        int[] reponse = {x,y};
        return reponse;
    }
    public void resete(){
        terrain.mitondraBol= null;
        this.ballon.SetBounds(490,240,20,20);
        this.ballon.tsyMisyMitondra = false;
    }
    public bool checkBut(PannelBallon ballon)
    {
        
        if(ballon.Location.X >= 980 && ballon.Location.Y <290 && ballon.Location.Y > 190){
            this.players1[0].score = this.players1[0].score + 1;
            score1 = players1[0].score;
            score = score1.ToString()+":"+score2.ToString(); 
            label.Text =score;
            MessageBox.Show("Joueur1 nahafaty: "+terrain.mitondraBol.intitule);
            this.resete();
            return true;
        }else if(ballon.Location.X <= 0 && ballon.Location.Y <290 && ballon.Location.Y > 190){
            this.players2[0].score = this.players2[0].score + 1;
            score2 = players2[0].score;
            score = score1.ToString()+":"+score2.ToString(); 
            label.Text =score;
            MessageBox.Show("Joueur1 nahafaty: "+terrain.mitondraBol.intitule);
            this.resete();
            return true;
        }
        if(score1==half+1 || score2==half+1 ){
            MessageBox.Show("Buuuut");
            Vola vola = new Vola();
            Score scor = new Score();
            MisePersonne mise = new MisePersonne();
            MisePersonne [] res = mise.selectMisebyMatch(last.idMatch,con);
            int j1 = 1;
            int j2 = 2;
            if(score1<score2){
                j1=j2;
                j2= 1;
            }
            double perdant = (res[1].montant )*-1;
            double gagnant = mise.argentGagnant(last.idMatch,con);
            vola.insertCaisse(j1,gagnant,last.idMatch,con);
            vola.insertCaisse(j2,perdant,last.idMatch,con);
            scor.insertScore(1,score1,last.idMatch,con);
            scor.insertScore(2,score2,last.idMatch,con);
            this.resete();
            AfficheState form = new AfficheState();
            form.Show();
            return true;
        }
        return false;
    }
    // public void scores1(int x,int u,PannelPlayer palyer){
    //     Connexion con = new Connexion();
    //     Matchs match = new Matchs();
    //     Matchs last = match.getLastEnter(con);
    //     int half =last.pointGagnant/2;
    //     if(palyer.score <= half){
    //         MessageBox.Show("Joueur1 nahafaty: "+terrain.mitondraBol.intitule);
    //         palyer.score =  palyer.score +u;
    //         score1 = palyer.score;
    //         score = score1.ToString()+":"+score2.ToString(); 
    //         label.Text =score;
    //         this.ballon.SetBounds(490,240,20,20);
    //         // x = x * -1;
    //         this.terrain.mitondraBol = null;
    //     }
    //     else if(palyer.score==half+1){
    //         // MessageBox.Show("Joueur1 nahafaty: "+terrain.mitondraBol.intitule);
    //         MessageBox.Show("Buuuut");
    //         Vola vola = new Vola();
    //         Score scor = new Score();
    //         MisePersonne mise = new MisePersonne();
    //         MisePersonne [] res = mise.selectMisebyMatch(last.idMatch,con);
    //         double perdant=0;
    //         if(res[1].idPersonne == 2){
    //             perdant = (res[1].montant )*-1;
    //         }
    //         double gagnant = mise.argentGagnant(last.idMatch,con);
    //         vola.insertCaisse(1,gagnant,last.idMatch,con);
    //         vola.insertCaisse(2,perdant,last.idMatch,con);
    //         scor.insertScore(1,score1,last.idMatch,con);
    //         scor.insertScore(2,score2,last.idMatch,con);
    //         AfficheState form = new AfficheState();
    //         form.Show();
    //     }
    // }
    // public void scores2(int x,int u, PannelPlayer player){
    //     Connexion con = new Connexion();
    //     Matchs match = new Matchs();
    //     Matchs last = match.getLastEnter(con);
    //     int half =last.pointGagnant/2;
    //      if(player.score <=half){
    //         MessageBox.Show("Joueur2 nahafaty: "+terrain.mitondraBol.intitule);
    //         player.score =  player.score +u; 
    //         score2 = player.score;
    //         score = score1.ToString()+":"+score2.ToString(); 
    //         label.Text =score;
    //         this.ballon.SetBounds(490,240,20,20);
    //         x = x * -1;
    //         this.terrain.mitondraBol = null;
    //     }
    //     else if(player.score==half+1){
    //         // MessageBox.Show("Joueur2 nahafaty: "+terrain.mitondraBol.intitule);
    //         MessageBox.Show("Buuuut");
    //         Vola vola = new Vola();
    //          Score scor = new Score();
            
    //         MisePersonne mise = new MisePersonne();
    //         MisePersonne [] res = mise.selectMisebyMatch(last.idMatch,con);
    //         double perdant=0;
    //         if(res[1].idPersonne == 2){
    //             perdant = (res[1].montant )*-1;
    //         }
    //         double gagnant = mise.argentGagnant(last.idMatch,con);
    //         vola.insertCaisse(1,perdant,last.idMatch,con);
    //         vola.insertCaisse(2,gagnant,last.idMatch,con);
    //         scor.insertScore(1,score1,last.idMatch,con);
    //         scor.insertScore(2,score2,last.idMatch,con);
    //         AfficheState form = new AfficheState();
    //         form.Show();
    //     }
    // }
    public void deplacementBallon(PannelBallon ballon,PannelPlayer[] p1, PannelPlayer[] p2,int x,int y){   
        int u = 1;
        while(ballon.tsyMisyMitondra){
            
            if (ballon.Location.X >= 980){
                x = x * -1;
                // this.scores1(x,u,players1[0]);
            }
            else if(ballon.Location.X <= 0)
            {
                x = x * -1;
                // this.scores2(x,u,players2[0]);
            }
            else if (ballon.Location.Y >= 480)
            {
                y = y * -1;
            }
            else if(ballon.Location.Y <= 0)
            {
                y = y * -1;
            }
            // else if(ballon.Location.X >= 980 && ballon.Location.Y >= 480)
            if(this.checkBut(ballon))break;
            ballon.Location = new Point(ballon.Location.X + x, ballon.Location.Y + y);
            ballon.tsyMisyMitondra = checkCollision(p1,p2,ballon);
            Thread.Sleep(15);
            this.Invalidate();
            this.Update();
        }
    }

}
