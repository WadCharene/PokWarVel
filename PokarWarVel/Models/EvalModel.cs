using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi.Model
{
    public class  EvalModel
    {
        #region Fields

        private Characters _monHero;
        private int _idEval;
        private long _idHero;
        private string _typeHero;
        private int _eval;
        private DateTime _date;
        private string _commentaire;

        
        #endregion

        #region Proprities

        public Characters MonHero
        {
            get { return _monHero; }
            set { _monHero = value; }
        }

        public int IdEval
        {
            get { return _idEval; }
            set { _idEval = value; }
        }


        public long IdHero
        {
            get { return _idHero; }
            set { _idHero = value; }
        }


        public string TypeHero
        {
            get { return _typeHero; }
            set { _typeHero = value; }
        }


        public int Eval1
        {
            get { return _eval; }
            set { _eval = value; }
        }


        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Commentaire
        {
            get { return _commentaire; }
            set { _commentaire = value; }
        }
        #endregion

        public bool save()
        {
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCmd = new SqlCommand();

            oConn.ConnectionString = @"Data Source=26R2-09\WADSQL;Initial Catalog=PokwarvelDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            try
            {

                oConn.Open();
                oCmd.CommandText = @"insert into eval(idHero,typeHero,eval,date,commentaire)VALUES(@idHero,@typeHero,@eval,@date,@commentaire)";
                oCmd.Connection = oConn;
                
                SqlParameter paramidHero = new SqlParameter("@idHero", this.IdHero);
                SqlParameter paramtypeHero = new SqlParameter("@typeHero", this.TypeHero);
                SqlParameter parameval = new SqlParameter("@eval", this.Eval1);
                SqlParameter paramdate = new SqlParameter("@date", DateTime.Now);
                SqlParameter paramcommentaire = new SqlParameter("@commentaire", this.Commentaire);

              
                oCmd.Parameters.Add(paramidHero);
                oCmd.Parameters.Add(paramtypeHero);
                oCmd.Parameters.Add(parameval);
                oCmd.Parameters.Add(paramdate);
                oCmd.Parameters.Add(paramcommentaire);

                

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

