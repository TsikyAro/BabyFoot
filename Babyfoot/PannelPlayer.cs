using System.Drawing.Drawing2D;
namespace BabyFootGasy;

public partial class PannelPlayer : Panel
{
    public int score = 0;
    public string intitule = "joueur";
    public int number;
    public int equipe;
    public int positionx;
    public int positiony;
    public PannelPlayer[] joueur1;
    public PannelPlayer[] joueur2;
    public int [] ligne;
    Pen pen;
    Brush brush;
    float penWidth = 2.0f;
    int _edge = 30;
    Color _borderColor = Color.Black;
    public int Edge
    {
        get
        {
            return _edge;
        }
        set
        {
            _edge = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        ExtendedDraw(e);
    }

    private void ExtendedDraw(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        GraphicsPath path = new GraphicsPath();

        path.StartFigure();
        path.StartFigure();
        path.AddArc(GetLeftUpper(Edge), 180, 90);
        path.AddLine(Edge, 0, Width - Edge, 0);
        path.AddArc(GetRightUpper(Edge), 270, 90);
        path.AddLine(Width, Edge, Width, Height - Edge);
        path.AddArc(GetRightLower(Edge), 0, 90);
        path.AddLine(Width - Edge, Height, Edge, Height);
        path.AddArc(GetLeftLower(Edge), 90, 90);
        path.AddLine(0, Height - Edge, 0, Edge);
        path.CloseFigure();

        Graphics g = this.CreateGraphics();
        g.FillPath(brush, path);

        Region = new Region(path);
    }

    Rectangle GetLeftUpper(int e)
    {
        return new Rectangle(0, 0, e, e);
    }
    Rectangle GetRightUpper(int e)
    {
        return new Rectangle(Width - e, 0, e, e);
    }
    Rectangle GetRightLower(int e)
    {
        return new Rectangle(Width - e, Height - e, e, e);
    }
    Rectangle GetLeftLower(int e)
    {
        return new Rectangle(0, Height - e, e, e);
    }
    public PannelPlayer(Color color)
    {
        pen = new Pen(_borderColor, penWidth);
        brush = new SolidBrush(color);
    }
    public int[] makeTable(int nombre,int height,int playerH)
    {
        int[] table = new int[nombre];
        int value = (height/(nombre + 1));
        int resultat = 0-(playerH/2);
        for(int i = 0; i < nombre; i++)
         {
            resultat = resultat + value;
            table[i] = resultat;
        }
        return table;
    }
    public void deplacement(PannelPlayer lists, int y,int x){
        
            // MessageBox.Show(lists.Location.X+"fgh"+lists.equipe );

        if(lists.number > 3 && lists.Location.X  <= 150 && lists.equipe == 0 ){
            lists.Location = new Point(lists.Location.X-x,lists.Location.Y + y);
            MessageBox.Show(lists.Location.X.ToString());
        }
        else if(lists.number <= 3 && lists.Location.X  >= 360 && lists.equipe == 0)
        {
            if(x>0){
              lists.Location = new Point(lists.Location.X,lists.Location.Y + y);    

            }else{
                lists.Location = new Point(lists.Location.X+x,lists.Location.Y + y);   
            }
            MessageBox.Show(lists.Location.X.ToString());

        }else if(lists.number > 3 && lists.Location.X  >= 790 && lists.equipe == 1){
            if(x >0){
                 lists.Location = new Point(lists.Location.X,lists.Location.Y + y);     
            }else{
                lists.Location = new Point(lists.Location.X+x,lists.Location.Y + y);
                MessageBox.Show(lists.Location.X.ToString());
            }
        }
        else if(lists.number <= 3 && lists.Location.X  <= 600 && lists.equipe == 1)
        {
            
            lists.Location = new Point(lists.Location.X-x,lists.Location.Y + y);
            MessageBox.Show(lists.Location.X.ToString());
        }
        else{
            lists.Location = new Point(lists.Location.X+x,lists.Location.Y + y);
        }
    }

    public PannelPlayer[] getJoueur1()
    {
        PannelPlayer[] pannelPlayers =  new PannelPlayer[12];
        this.ligne = new int[4];
        int x = 0;
        int xvalue = x;
        int[] nombre = {1,3,5,3};
        int[] position = this.makeTable(nombre[0],500,30);
        int index = 0;
        int u =0;
        ligne[0]= xvalue;
        for(int i = 0; i < 12; i++)
        {

            if(i == 1 || i == 4 || i == 9) 
            {
                x = x + 1;
                u = u+1;
                index = 0;
                position = this.makeTable(nombre[x],500,30);
                xvalue = xvalue + 250;
                if(i == 1)xvalue = xvalue - 125;
                else if(i == 9)xvalue = xvalue + 85;
                ligne[u] = xvalue;
                // MessageBox.Show(ligne[u]+" huhu");
            }
            pannelPlayers[i] = new PannelPlayer(Color.DarkGray);
            pannelPlayers[i].SetBounds(xvalue,position[index],30,30);
            pannelPlayers[i].intitule =  pannelPlayers[i].intitule + i;
            pannelPlayers[i].number = i;
            this.positionx = xvalue;
            this.positiony = position[index];
            pannelPlayers[i].equipe = 0;
            joueur1= pannelPlayers;
            index++;
        }
        return joueur1;
    }
    public PannelPlayer[] getJoueur2()
    {
        PannelPlayer[] pannelPlayers =  new PannelPlayer[12];
        int x = 0;
        int xvalue = 1000-30;
        int[] nombre = {1,3,5,3};
        int[] position = this.makeTable(nombre[0],500,30);
        int index = 0;
        for(int i = 0; i < 12; i++)
        {
            if(i == 1 || i == 4 || i == 9) 
            {
                x = x + 1;
                index = 0;
                position = this.makeTable(nombre[x],500,30);
                xvalue = xvalue - 250;
                if(i == 1)xvalue = xvalue + 125;
                else if(i == 9)xvalue = xvalue - 85;
                // MessageBox.Show(xvalue+"fghj");
            }
            pannelPlayers[i] = new PannelPlayer(Color.DarkRed);
            pannelPlayers[i].SetBounds(xvalue,position[index],30,30);
            pannelPlayers[i].intitule =  pannelPlayers[i].intitule + i;
            pannelPlayers[i].equipe = 1;
            pannelPlayers[i].number = i;
            joueur2 = pannelPlayers;
            index++;
        }
        return joueur2;
    }
    
}