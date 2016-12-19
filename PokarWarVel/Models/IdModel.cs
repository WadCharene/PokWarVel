using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MarvelApi.Model
{
    class IdModel
    {
        #region Fields

        private string _id;

       
        private string _nom;

     
        private string _prenom;

    
        private string _login;

       
        private string _pws;

       
        private DateTime _dateDeNaissance;


        private string _ville;

    
        private bool _sexe;

        #endregion

        #region proproties
        
      
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
   [Required]
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
    [Required]
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
 [Required][Display(Name = "Mot de passe  ")]
        public string Pws
        {
            get { return _pws; }
            set { _pws = value; }
        }
 [Required][Display (Name = "Date de Naissance ")]
        public DateTime DateDeNaissance
        {
            get { return _dateDeNaissance; }
            set { _dateDeNaissance = value; }
        }
        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }
    [Required]
        public bool Sexe
        {
            get { return _sexe; }
            set { _sexe = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        public bool save()
        {
            SqlConnection oConn = new SqlConnection ();
            SqlCommand oCmd = new SqlCommand ();

            oConn.ConnectionString =@"Data Source=26R2-09\WADSQL;Initial Catalog=PokwarvelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";



            try
            {

                oConn.Open();
                oCmd.CommandText = @"insert into identification(id,nom,prenom,date,login,pws,ville,sexe)VALUES(@id,@nom,@prenom,@date,@login,@pws,@ville,@sexe)";
                oCmd.Connection = oConn;

                SqlParameter paramid = new SqlParameter("@id", this.Id);
                SqlParameter paramnom = new SqlParameter("@nom", this.Nom);
                SqlParameter paramprenom = new SqlParameter("@prenom", this.Prenom);
                SqlParameter paramdate = new SqlParameter("@date", this._dateDeNaissance);
                SqlParameter paramlogin = new SqlParameter("@login", this.Login);
                SqlParameter parampws = new SqlParameter("@pws", this.Pws);
                SqlParameter paramville = new SqlParameter("@ville", this.Ville);
                SqlParameter paramsexe = new SqlParameter("@sexe", this.Sexe);
                
                
                oCmd.ExecuteNonQuery();
                oConn.Close();
            }
            catch (Exception)
            {
                if(oConn.State==System.Data.ConnectionState.Open)
                {

                    oConn.Close();

                }
                return false;
            }

            return true;
            }


            }

       
    
}
