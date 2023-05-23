using System.Data.SqlClient;
namespace jeux{
    public class Personne{
        private int idPersonne;
        private string nomPersonne;
        private int intitule;
        

        public Personne[] getDonnee(Connexion c)
        {
            List<Personne> PersonneList = new List<Personne>();
            SqlConnection con = c.GetConnexion();
            con.Open();
            String sql = "SELECT * FROM Personne";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read())
            {
                Personne temp = new Personne(data.GetInt32(0), data.GetString(1), data.GetInt32(2));
                PersonneList.Add(temp);
            }
            Personne[] PersonneArray = new Personne[PersonneList.Count];
            con.Close();
            PersonneArray = PersonneList.ToArray();
            return PersonneArray;
        }
        public Personne(int idPersonne,string nom,int intitule){
            this.idPersonne = idPersonne;
            this.intitule = intitule;
            this.nomPersonne = nom;
        }

    }
}

