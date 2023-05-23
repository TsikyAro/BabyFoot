namespace Babyfoot;
using jeux;

public partial class Form1 : Form
{
    private Button button1;
    private TextBox textBox1;
    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent(){
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // Textbox
            //
                this.textBox1.Location = new System.Drawing.Point(50, 50);
                this.textBox1.Size = new System.Drawing.Size(200, 23);
                textBox1.Text = "Entrez le point gagnant..."; 
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Commencer  Match";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Start Match";
            this.ResumeLayout(false);

    }

    private void button1_Click(object sender, EventArgs e) {
        Connexion conex = new Connexion();
        string pointgagnant = textBox1.Text;
        MessageBox.Show("Vous avez saisi : " + pointgagnant);
        int point = int.Parse(pointgagnant);
        Matchs match = new Matchs();
        match.insertMatch(point,conex);
        Form2 form2 = new Form2();
        form2.Show(); // Ou form2.ShowDialog();
    }  
}

