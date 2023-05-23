using System.Data.SqlClient;

public class Vola{
    public int idCaisse;
    public int idMatch;
    public int idPersonne;
    public double montant;

      
        public void insertCaisse(int idPersonne,double montant,int idMatch,Connexion c){
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "INSERT INTO caisse (idPersonne,idMatch,montant) VALUES ( @idPersonne,@idMatch,@montant)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            cmd.Parameters.AddWithValue("@montant", montant);
            cmd.Parameters.AddWithValue("@idMatch", idMatch);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"insertion avec succes {idPersonne} et {montant}");
            con.Close();
        }
        public Vola selectMisebyMatch(int idMatch,int idJoueur,Connexion c){
             Vola temp = null;
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = $"SELECT * FROM Caisse where idMatch ={idMatch} and idPersonne={idJoueur} ";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                temp = new Vola(data.GetInt32(0), data.GetInt32(1),data.GetInt32(2),Convert.ToDouble(data["montant"]));
               
            }
            con.Close();
            return temp;
        }
        public Vola(int idCaisse,int idMatch,int idPersonne,double montant){
            this.idCaisse = idCaisse;
            this.idMatch = idMatch;
            this.idPersonne = idPersonne;
            this.montant = montant;
        }
        public Vola(){}
}