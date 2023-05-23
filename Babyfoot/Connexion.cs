using System.Data.SqlClient;
public class Connexion
{
    private static string connectionString ="Server=ETU2035-ARO;Database=baby;Trusted_Connection=True;";
    public Connexion(){}
    public  SqlConnection GetConnexion(){
        SqlConnection connexion = new SqlConnection(connectionString);
        return connexion;
    }
    
}
