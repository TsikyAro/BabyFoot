using System.Data.SqlClient;
namespace jeux{
    public class MisePersonne{
        private int idMise;
        public int idPersonne;
        public double montant;
        private int idMatch;

        public MisePersonne[] selectMisebyMatch(int idMatch,Connexion c){
            List<MisePersonne> MisePersonneList = new List<MisePersonne>();
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "SELECT * FROM MisePersonne where idMatch = " + idMatch;
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                MisePersonne temp = new MisePersonne(data.GetInt32(1),  Convert.ToDouble(data["montant"]),data.GetInt32(3));
                MisePersonneList.Add(temp);
            }
            MisePersonne[] MisePersonneArray = new MisePersonne[MisePersonneList.Count];
            con.Close();
            MisePersonneArray = MisePersonneList.ToArray();
            return MisePersonneArray;
        }
        public double montantJeton(int idMatch,Connexion c){
            double jeton = 0;
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "SELECT * FROM jeton where idMatch = " + idMatch;
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                jeton = Convert.ToDouble(data["montantJeton"]);
            }
            con.Close();
            return jeton;
        }
        public void insertJeton(int idMatch,double montant,Connexion c){
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "INSERT INTO jeton (idMatch,montantJeton) VALUES (@idMatch, @montant)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@montant", montant);
            cmd.Parameters.AddWithValue("@idMatch", idMatch);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void insertMise(int idPersonne,double montant,int idMatch,Connexion c){
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "INSERT INTO MisePersonne (idPersonne,montant,idMatch) VALUES ( @idPersonne,@montant,@idMatch)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            cmd.Parameters.AddWithValue("@montant", montant);
            cmd.Parameters.AddWithValue("@idMatch", idMatch);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public double sommeArgent(int idMatch,Connexion c){
            MisePersonne [] mise = this.selectMisebyMatch(idMatch,c);
            double somme =0;
            for(int i =0; i<mise.Length; i++){
                somme = somme +mise[i].montant;
            }
            return somme;
        }
        public double argentGagnant(int idMatch,Connexion c){
            double jeton = this.montantJeton(idMatch,c);
            double somme = this.sommeArgent(idMatch,c);
            double gagnant = somme - jeton;
            return gagnant;
        }
        public MisePersonne(int idPersonne,double montant,int idMatch){
            this.idMatch = idMatch;
            this.idPersonne = idPersonne;
            this.montant = montant;
        }

        public MisePersonne(){}
    }
}

