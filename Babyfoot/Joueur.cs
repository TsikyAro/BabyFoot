using System.Data.SqlClient;

namespace olona {
    public class Joueur{
        private int idJoueur;
        private double positionX;
        private double positionY;
        private int idBaton;
        public int possession = 0;
        // public Joueur ChangePied(Joueur change,Connexion c){

        // }  
        public void passe(Joueur mipasse,Connexion c){
            Joueur passina = this.ipassina(mipasse,c);
            passina.possession = 1;
            mipasse.possession = 0;
        }
        public Joueur ipassina(Joueur mipasse,Connexion c){
            Joueur [] tableJoueur = this.selectJoueurPasser(c,mipasse);
            Joueur minimum = tableJoueur[0];
            double min = Math.Abs(minimum.positionY - mipasse.positionY);
            for(int i =0; i<tableJoueur.Count(); i++){
                double val = Math.Abs(tableJoueur[i].positionY-mipasse.positionY);
                if(min > val){
                    minimum = tableJoueur[i];
                }
            }
            return minimum;
        }
        public Joueur[] selectChangementdePied(Connexion c,Joueur changement){
            List<Joueur> JoueurList = new List<Joueur>();
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "SELECT * FROM Joueur where positionX != "+changement.positionX;
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Joueur temp = new Joueur(data.GetInt32(0), data.GetDouble(1), data.GetDouble(2),data.GetInt32(3));
                JoueurList.Add(temp);
            }
            Joueur[] JoueurArray = new Joueur[JoueurList.Count];
            con.Close();
            JoueurArray = JoueurList.ToArray();
            return JoueurArray;
        }
        public Joueur[] selectJoueurPasser(Connexion c,Joueur passeJoueur){
            List<Joueur> JoueurList = new List<Joueur>();
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "SELECT * FROM Joueur where positionY != "+passeJoueur.positionY;
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Joueur temp = new Joueur(data.GetInt32(0), data.GetDouble(1), data.GetDouble(2),data.GetInt32(3));
                JoueurList.Add(temp);
            }
            Joueur[] JoueurArray = new Joueur[JoueurList.Count];
            con.Close();
            JoueurArray = JoueurList.ToArray();
            return JoueurArray;
        }
        public Joueur[] getDonnee(Connexion c)
        {
            List<Joueur> JoueurList = new List<Joueur>();
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "SELECT * FROM Joueur";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Joueur temp = new Joueur(data.GetInt32(0), data.GetDouble(1), data.GetDouble(2),data.GetInt32(3));
                JoueurList.Add(temp);
            }
            Joueur[] JoueurArray = new Joueur[JoueurList.Count];
            con.Close();
            JoueurArray = JoueurList.ToArray();
            return JoueurArray;
        }
        public Joueur(int idJoueur,double positionX,double positionY,int idBaton){
            this.idJoueur = idJoueur;
            this.positionX = positionX;
            this.positionY = idBaton;
        }
        public int IdBaton { get => idBaton; set => idBaton = value; }
        public double PositionY { get => positionY; set => positionY = value; }
        public double PositionX { get => positionX; set => positionX = value; }
    }
}