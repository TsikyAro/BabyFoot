using System.Data.SqlClient;

public class Score{
    public int idScore;
    public int idMatch;
    public int idPersonne;
    public int montant;

      
        public void insertScore(int idPersonne, int montant,int idMatch,Connexion c){
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "INSERT INTO Score (idPersonne,idMatch,score) VALUES ( @idPersonne,@idMatch,@montant)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            cmd.Parameters.AddWithValue("@montant", montant);
            cmd.Parameters.AddWithValue("@idMatch", idMatch);
            cmd.ExecuteNonQuery();
            MessageBox.Show("insertion avec succes");
            con.Close();
        }
        public Score selectscoreMatch(int idMatch,int idjoueur,Connexion c){
            // List<Score> ScoreList = new List<Score>();
             Score temp = null;
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = $"SELECT * FROM Score where idMatch = { idMatch} and idPersonne = {idjoueur}" ;
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                temp = new Score(data.GetInt32(0),data.GetInt32(1),data.GetInt32(2),data.GetInt32(3));
                // ScoreList.Add(temp);
            }
            // Score[] ScoreArray = new Score[ScoreList.Count];
            con.Close();
            // ScoreArray = ScoreList.ToArray();
            return temp;
        }
        public Score(int idCaisse,int idMatch,int idPersonne,int montant){
            this.idScore = idCaisse;
            this.idMatch = idMatch;
            this.idPersonne = idPersonne;
            this.montant = montant;
        }
        public Score(){}
}