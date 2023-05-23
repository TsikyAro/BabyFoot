namespace Babyfoot;

using BabyFootGasy;
using jeux;
public partial class Form2 : Form
{
    private Button button1;
    private TextBox textBox1;
    private  TextBox textBox2;
    private TextBox textBox3;
    public Form2()
    {
        InitializeComponent();
    }

    private void InitializeComponent(){
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            Label nomLabel = new Label(){
                Text = "Joueur1",
                Location = new Point(45, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            Label nomLabel2 = new Label(){
                Text = "Joueur2",
                Location = new Point(150, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            textBox2 = new System.Windows.Forms.TextBox(){
                Location = new Point(45,35),
                Size = new System.Drawing.Size(80, 23),
                Text = " " 
            } ;
            textBox3 = new System.Windows.Forms.TextBox(){
                Location = new Point(150,35),
                Size = new System.Drawing.Size(80, 23),
                Text = " " 
            } ;
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert Mise";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(nomLabel);
            this.Controls.Add(nomLabel2);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Name = "Form2";
            this.Text = "Insert Mise";
            this.ResumeLayout(false);

    }

    private void button1_Click(object sender, EventArgs e) {
        Connexion conex = new Connexion();
        Matchs match = new Matchs();
        Matchs last = match.getLastEnter(conex);
        MisePersonne mise = new MisePersonne();
        int j1= 1;
        int j2 = 2;
        string miseJ1= textBox2.Text;
        string miseJ2= textBox3.Text;
        mise.insertMise(j1,double.Parse(miseJ1),last.idMatch,conex);
        mise.insertMise(j2,double.Parse(miseJ2),last.idMatch,conex);
        mise.insertJeton(last.idMatch,200,conex);
        // MessageBox.Show("mise j1: " + miseJ1+"mise j2: "+miseJ2 );
        Form3 form3 = new Form3();
        form3.Show();
    }  
}

