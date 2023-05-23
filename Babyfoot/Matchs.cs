using System.Data.SqlClient;
namespace jeux{
    public class Matchs{
        public int idMatch;
        public int pointGagnant;

        public void insertMatch(int pointgagnant,Connexion c){
            SqlConnection con = c.GetConnexion();
            con.Open();
            Console.WriteLine(pointgagnant);
            String sql = "INSERT INTO Matchs (pointGagnant) VALUES ( @pointgagnant)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@pointgagnant", pointgagnant);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Matchs getLastEnter(Connexion c){
            Matchs temp = null ;
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "SELECT * FROM Matchs";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                 temp = new Matchs(data.GetInt32(0), data.GetInt32(1));
            }
            con.Close();
            return temp;
        }

        public Matchs(int idMatch,int pointGagnant){
            this.idMatch = idMatch;
            this.pointGagnant = pointGagnant;
        }
        public Matchs(){
        }

    }
}

